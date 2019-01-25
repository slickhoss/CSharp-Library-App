using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Data Class for book object
    /// </summary>
    public class Book
    {
        public string bookId;
        public string sku;
        public string title;
        public string author;
        public string genre;
        public string publisher;
        public int publishedYear;
        public bool checkedOut;
        public DateTime dateCheckedOut;
        public DateTime dueDate;
        public string dueDateString;
        public string checkedOutUserLogin;

        public string BookId
        {
            get { return bookId; }
            set { bookId = value; }
        }

        public string Sku
        {
            get { return sku; }
            set { sku = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public int PublishedYear
        {
            get { return publishedYear; }
            set { publishedYear = value; }
        }

        public bool CheckedOut
        {
            get { return checkedOut; }
            set { checkedOut = value; }
        }

        public DateTime DateCheckedOut
        {
            get { return dateCheckedOut; }
            set { dateCheckedOut = value; }
        } 

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public string DateCheckedOutString
        {
            get
            {
                if (dateCheckedOut == DateTime.MinValue)
                {
                    return null;
                }
                return dateCheckedOut.ToString("MM/dd/yyyy");
            }
        }

        public string DueDateString
        {
            get
            {
                if (dueDate == DateTime.MinValue)
                {
                    return null;
                }
                return dueDate.ToString("MM/dd/yyyy");
            }
        }

        public string CheckedUserOutLogin
        {
            get { return checkedOutUserLogin; }
            set { checkedOutUserLogin = value; }
        }
    }
}
