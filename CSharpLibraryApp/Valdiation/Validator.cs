using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;
using Common;
using Repository;
using System.Data.SqlClient;

namespace Valdiation
{
    /// <summary>
    /// Validator Class
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// static collection of strings for error
        /// </summary>
        private static List<string> errorMessages;
        static Validator()
        {
            errorMessages = new List<string>();
        }
        public static string GetMessage
        {
            get
            {
                string result = null;
                foreach (string s in errorMessages)
                {
                    result += s + "\n";
                }
                errorMessages.Clear();
                return result;
            }
        }

        public static string skuRegex = @"^[A-Z]{3}[0-9]{4}";

        /// <summary>
        /// boolean function to test if email is valid
        /// </summary>
        public static bool IsValidEmail(String email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException f)
            {
                return false;
            }
        }

        public static bool isValidBook(Book book)
        {
            bool result = true;
            if (String.IsNullOrWhiteSpace(book.Sku) || !Regex.IsMatch(book.Sku, skuRegex))
            {
                result = false;
                errorMessages.Add("Sku must be in format of AAA1001");
            }
            if (String.IsNullOrWhiteSpace(book.Title))
            {
                result = false;
                errorMessages.Add("Title is required");
            }

            if (String.IsNullOrWhiteSpace(book.Author))
            {
                result = false;
                errorMessages.Add("Author is required");
            }

            if (String.IsNullOrWhiteSpace(book.Publisher))
            {
                result = false;
                errorMessages.Add("Publisher is required");
            }
            return result;
        }

        /// <summary>
        /// Validation function for object account
        /// Enforces : 
        ///  - valid email
        ///  - unique userLogin
        /// </summary>
        public static bool isValidAccount(Account account)
        {
            if (!IsValidEmail(account.Email))
            {
                errorMessages.Add("Please provide a valid email");
                return false;
            }
            return true;
        }

        public static int CreateBook(Book book)
        {
            if (isValidBook(book))
            {
                BookRepository.CreateBook(book);
                return 1;
            }
            return 0;
        }
        
        public static int UpdateBook (Book book)
        {
            if (isValidBook(book))
            {
                BookRepository.UpdateBook(book);
                return 1;
            }
            return 0;
        }

        public static int CreateAccount(Account account)
        {
            if (isValidAccount(account))
            {
                try
                {
                    BookRepository.CreateAccount(account);
                    return 1;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        errorMessages.Add("UserLogin has been taken");
                        return 0;
                    }
                }
            }
            return 0;
        }
    }
}
