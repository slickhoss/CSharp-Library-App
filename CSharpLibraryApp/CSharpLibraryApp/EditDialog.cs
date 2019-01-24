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
            skuTextBox.Text = this.Sku;
            titleTextBox.Text = this.Title;
            authorTextBox.Text = this.Author;
            genreTextBox.Text = this.Genre;
            publisherTextBox.Text = this.Publisher;
            publishedYearTextBox.Text = this.PublishedYear;
            checkedOutCheckBox.Checked = this.CheckedOut;
            if (this.CheckedOut == true)
            {
                checkedOutDateLabel2.Text = this.DateCheckedOut.ToString("MM/dd/yyyy");
                dueDateLabel2.Text = this.DueDate.ToString("MM/dd/yyyy");
            }
            else
            {
                checkedOutDateLabel.Text = "";
                checkedOutDateLabel2.Text = "";
                dueDateLabel.Text = "";
                dueDateLabel2.Text = "";
            }
            if (this.BookId == null)
            {
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
    }
}
