using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Common;
using Repository;
using System.Data.SqlClient;

namespace Valdiation
{
    public static class Validator
    {
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

        public static bool isValidAccount(Account account)
        {
            if (!IsValidEmail(account.Email))
            {
                errorMessages.Add("Please provide a valid email");
                return false;
            }
            return true;
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
