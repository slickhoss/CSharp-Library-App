using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Repository;

namespace CSharpLibraryApp
{
    public partial class EditDialog : Form
    {
        public EditDialog()
        {
            InitializeComponent();
        }

        //dialog fields
        public bool admin;
        public string userLogin;
        public string bookId;
        public string sku;
        public string title;
        public string author;
        public string genre;
        public string publisher;
        public string publishedYear;
        public bool checkedOut;
        public DateTime dateCheckedOut;
        public DateTime dueDate;

        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public string UserLogin
        {
            get { return userLogin; }
            set { userLogin = value; }
        }

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

        public string PublishedYear
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

        private void EditDialog_Load(object sender, EventArgs e)
        {
            checkOutButton.Hide();
            returnButton.Hide();
            skuTextBox.Text = this.Sku;
            titleTextBox.Text = this.Title;
            authorTextBox.Text = this.Author;
            genreTextBox.Text = this.Genre;
            publisherTextBox.Text = this.Publisher;
            publishedYearTextBox.Text = this.PublishedYear;
            checkedOutCheckBox.Checked = this.CheckedOut;
            if (this.CheckedOut == true)
            {
                checkedOutByLabel2.Text = this.UserLogin;
                checkedOutDateLabel2.Text = this.DateCheckedOut.ToString("MM/dd/yyyy");
                dueDateLabel2.Text = this.DueDate.ToString("MM/dd/yyyy");
            }
            else
            {
                checkedOutByLabel.Text = "";
                checkedOutByLabel2.Text = "";
                checkedOutDateLabel.Text = "";
                checkedOutDateLabel2.Text = "";
                dueDateLabel.Text = "";
                dueDateLabel2.Text = "";
            }
            if (this.BookId == null)
            {
                checkedOutCheckBox.Enabled = false;
            }
            //end user configuration
            if (this.Admin != true)
            {
                saveButton.Hide();
                deleteButton.Hide();
                checkOutButton.Show();
                returnButton.Show();
                skuTextBox.Enabled = false;
                titleTextBox.Enabled = false;
                authorTextBox.Enabled = false;
                genreTextBox.Enabled = false;
                publisherTextBox.Enabled = false;
                publishedYearTextBox.Enabled = false;
                checkedOutCheckBox.Enabled = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.BookId = this.BookId;
            book.Sku = skuTextBox.Text;
            book.Title = titleTextBox.Text;
            book.Author = authorTextBox.Text;
            book.Genre = genreTextBox.Text;
            book.Publisher = publisherTextBox.Text;
            book.PublishedYear = Int16.Parse(publishedYearTextBox.Text);
            book.CheckedOut = checkedOutCheckBox.Checked;
            if(book.BookId != null)
            {
                if (book.CheckedOut == true)
                {
                    book.DateCheckedOut = DateTime.Now;
                    book.DueDate = book.DateCheckedOut.AddDays(14);
                }
                BookRepository.UpdateBook(book);
                this.DialogResult = DialogResult.OK;
            }
            if (book.BookId == null)
            {
                BookRepository.CreateBook(book);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.BookId = this.bookId;
            BookRepository.DeleteBook(book);
            this.DialogResult = DialogResult.OK;
        }

        private void checkOutButton_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.BookId = this.BookId;
            book.Sku = this.Sku;
            book.Title = this.Title;
            book.Author = this.Author;
            book.Genre = this.Genre;
            book.Publisher = this.Publisher;
            book.PublishedYear = Int16.Parse(this.PublishedYear);
            book.DateCheckedOut = DateTime.Now;
            book.DueDate = book.DateCheckedOut.AddDays(14);
            book.CheckedUserOutLogin = this.UserLogin;
            book.CheckedOut = true;
            BookRepository.UpdateBook(book);
            this.DialogResult = DialogResult.OK;
        }
    }
}
