using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Repository;


namespace CSharpLibraryApp
{
    public partial class MainForm : Form
    {
        private bool admin;
        private string userLogin;
        private BookCollection bookCollection;
        //private BookViewModel bookViewModel;
        public MainForm()
        {
            InitializeComponent();
        }

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

        private void MainForm_Load(object sender, EventArgs e)
        {
           bookCollection = new BookCollection();
           //bookViewModel = new BookViewModel();
           bookDataGridView.AutoGenerateColumns = false;
            viewButton.Hide();
           loadDataGridView();
           setDataGridView();
        }

        public void loadDataGridView()
        {
            // end user configuration
            if (admin == false)
            {
                viewButton.Show();
                newButton.Hide();
                editButton.Hide();
            }
            bookCollection = BookRepository.GetBooks();
            bookDataGridView.DataSource = bookCollection;
            //bookViewModel.Books = BookRepository.GetBooks();
            //bookDataGridView.DataSource = bookViewModel.Books;
        }

        //data grid view configuration
        public void setDataGridView ()
        {
            bookDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bookDataGridView.MultiSelect = false;
            bookDataGridView.AllowUserToAddRows = false;
            bookDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            bookDataGridView.AllowUserToOrderColumns = false;
            bookDataGridView.AllowUserToResizeColumns = false;
            bookDataGridView.AllowUserToResizeRows = false;
            bookDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            DataGridViewTextBoxColumn sku = new DataGridViewTextBoxColumn();
            sku.Name = "Sku";
            sku.DataPropertyName = "Sku";
            sku.HeaderText = "Sku";
            sku.Width = 60;
            sku.SortMode = DataGridViewColumnSortMode.Programmatic;
            bookDataGridView.Columns.Add(sku);

            DataGridViewTextBoxColumn title = new DataGridViewTextBoxColumn();
            title.Name = "Title";
            title.DataPropertyName = "Title";
            title.HeaderText = "Title";
            title.Width = 160;
            //title.SortMode = DataGridViewColumnSortMode.NotSortable;
            bookDataGridView.Columns.Add(title);

            DataGridViewTextBoxColumn author = new DataGridViewTextBoxColumn();
            author.Name = "Author";
            author.DataPropertyName = "Author";
            author.HeaderText = "Author";
            author.Width = 121;
            //author.SortMode = DataGridViewColumnSortMode.NotSortable;
            bookDataGridView.Columns.Add(author);

            DataGridViewTextBoxColumn genre = new DataGridViewTextBoxColumn();
            genre.Name = "Genre";
            genre.DataPropertyName = "Genre";
            genre.HeaderText = "Genre";
            genre.Width = 80;
            //genre.SortMode = DataGridViewColumnSortMode.NotSortable;
            bookDataGridView.Columns.Add(genre);

            DataGridViewTextBoxColumn publisher = new DataGridViewTextBoxColumn();
            publisher.Name = "Publisher";
            publisher.DataPropertyName = "Publisher";
            publisher.HeaderText = "Publisher";
            publisher.Width = 120;
            //publisher.SortMode = DataGridViewColumnSortMode.NotSortable;
            bookDataGridView.Columns.Add(publisher);

            DataGridViewTextBoxColumn publishedYear = new DataGridViewTextBoxColumn();
            publishedYear.Name = "Published Year";
            publishedYear.DataPropertyName = "PublishedYear";
            publishedYear.HeaderText = "Published Year";
            publishedYear.Width = 80;
            //publishedYear.SortMode = DataGridViewColumnSortMode.NotSortable;
            bookDataGridView.Columns.Add(publishedYear);

            DataGridViewCheckBoxColumn checkedOut = new DataGridViewCheckBoxColumn();
            checkedOut.Name = "Checked Out";
            checkedOut.DataPropertyName = "CheckedOut";
            checkedOut.HeaderText = "Checked Out";
            //checkedOut.SortMode = DataGridViewColumnSortMode.NotSortable;
            bookDataGridView.Columns.Add(checkedOut);

            DataGridViewTextBoxColumn dateCheckedOut = new DataGridViewTextBoxColumn();
            dateCheckedOut.Name = "Date Checked Out";
            dateCheckedOut.DataPropertyName = "DateCheckedOutString";
            dateCheckedOut.HeaderText = "Date Checked Out";
            dateCheckedOut.Width = 67;
            //dateCheckedOut.SortMode = DataGridViewColumnSortMode.NotSortable;
            bookDataGridView.Columns.Add(dateCheckedOut);

            DataGridViewTextBoxColumn dueDate = new DataGridViewTextBoxColumn();
            dueDate.Name = "Due Date";
            dueDate.DataPropertyName = "DueDateString";
            dueDate.HeaderText = "Due Date";
            dueDate.Width = 67;
            //dueDate.SortMode = DataGridViewColumnSortMode.NotSortable;
            bookDataGridView.Columns.Add(dueDate);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = bookDataGridView.CurrentRow.Index;
                Book book = bookCollection[index];
                //Book book1 = bookViewModel.Books[index];
                EditDialog editDialog = new EditDialog() { Admin = true };
                editDialog.BookId = book.BookId;
                editDialog.Sku = book.Sku;
                editDialog.Title = book.Title;
                editDialog.Author = book.Author;
                editDialog.Genre = book.Genre;
                editDialog.Publisher = book.Publisher;
                editDialog.PublishedYear = book.PublishedYear.ToString();
                editDialog.CheckedOut = book.CheckedOut;
                editDialog.DateCheckedOut = book.DateCheckedOut;
                editDialog.DueDate = book.DueDate;
                editDialog.ShowDialog();
                if (editDialog.DialogResult == DialogResult.OK)
                {
                    loadDataGridView();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Book book1 = bookViewModel.Books[index];
                EditDialog editDialog = new EditDialog() { Admin = true };
                editDialog.BookId = null;
                
                editDialog.ShowDialog();
                if (editDialog.DialogResult == DialogResult.OK)
                {
                    loadDataGridView();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            int index = bookDataGridView.CurrentRow.Index;
            Book book = bookCollection[index];
            EditDialog editDialog = new EditDialog() { Admin = false};
            editDialog.BookId = book.BookId;
            editDialog.Sku = book.Sku;
            editDialog.Title = book.Title;
            editDialog.Author = book.Author;
            editDialog.Genre = book.Genre;
            editDialog.Publisher = book.Publisher;
            editDialog.PublishedYear = book.PublishedYear.ToString();
            editDialog.CheckedOut = book.CheckedOut;
            editDialog.dateCheckedOut = book.dateCheckedOut;
            editDialog.DueDate = book.DueDate;
            if (!String.IsNullOrWhiteSpace(book.CheckedOutUserLogin))
            {
                editDialog.UserLogin = book.CheckedOutUserLogin;
            }
            editDialog.ShowDialog();
            if (editDialog.DialogResult == DialogResult.OK)
            {
                loadDataGridView();
            }
        }
    }
}
