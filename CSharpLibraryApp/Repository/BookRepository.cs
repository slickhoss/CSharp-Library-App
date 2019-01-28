using  System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace Repository
{
    /// <summary>
    /// Repository Class
    /// Provides basic CRUD functionality with SQL
    /// </summary>
    public static class BookRepository
    {
        /// <summary>
        /// Connection String
        /// </summary>
        public static string connectionString = "Server = tcp:DESKTOP-8j6savc,1433;"
                                                + "Initial Catalog = master;"
                                                + "User ID = sa;"
                                                + "Password = andrehoong;"
                                                + "Encrypt = true;"
                                                + "TrustServerCertificate = true;"
                                                + "Connection Timeout = 30;";

        /// <summary>
        /// Create function for book table
        /// </summary>
        public static int CreateBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Books (sku, title, author, genre, publisher, publishedYear)"
                                +"VALUES(@sku, @title, @author, @genre, @publisher, @publishedYear)";
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@sku", book.Sku);
                    command.Parameters.AddWithValue("@title", book.Title);
                    command.Parameters.AddWithValue("@author", book.Author);
                    command.Parameters.AddWithValue("@genre", book.Genre);
                    if (!String.IsNullOrWhiteSpace(book.Publisher))
                    {
                        command.Parameters.AddWithValue("@publisher", book.Publisher);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@publisher", DBNull.Value);
                    }
                    if (book.PublishedYear != 0)
                    {
                        command.Parameters.AddWithValue("@publishedYear", book.PublishedYear);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@publishedYear", DBNull.Value);
                    }
                    command.Connection = connection;
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        
        /// <summary>
        /// Read function for book table
        /// </summary>
        public static BookCollection GetBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                BookCollection bookCollection = new BookCollection();
                string query = @"SELECT bookId, sku, title, author, genre, publisher, publishedYear, checkedOut,dateCheckedOut, dueDate, checkedOutUserLogin FROM Books ORDER BY sku ASC";
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Connection = connection;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int id;
                        string bookId;
                        string sku;
                        string title;
                        string author;
                        string genre;
                        string publisher = null;
                        int publishedYear = 0;
                        bool checkedOut;
                        DateTime dateCheckedOut = DateTime.MinValue;
                        DateTime dueDate = DateTime.MinValue;
                        string checkedOutUserLogin = null;
                        while (reader.Read())
                        {
                            id = (int)reader["bookId"];
                            bookId = id.ToString();
                            sku = reader["sku"] as string;
                            title = reader["title"] as string;
                            author = reader["author"] as string;
                            genre = reader["genre"] as string;
                            if (!reader.IsDBNull(5))
                            {
                                publisher = reader["publisher"] as string;
                            }
                            if (!reader.IsDBNull(6))
                            {
                                publishedYear = (int)reader["publishedYear"];
                            }
                            checkedOut = (bool)reader["checkedOut"];
                            if (!reader.IsDBNull(8))
                            {
                                dateCheckedOut = (DateTime)reader["dateCheckedOut"];
                            }
                            if (!reader.IsDBNull(9))
                            {
                                dueDate = (DateTime)reader["dueDate"];
                            }
                            if(!reader.IsDBNull(10))
                            {
                                checkedOutUserLogin = reader["checkedOutUserLogin"] as string;   
                            }
                            bookCollection.Add(new Book { BookId = bookId, Sku = sku, Title = title, Author = author, Genre = genre, Publisher = publisher, PublishedYear = publishedYear, CheckedOut = checkedOut, DateCheckedOut = dateCheckedOut, DueDate = dueDate, CheckedUserOutLogin = checkedOutUserLogin });
                            publisher = null;
                            publishedYear = 0;
                            dueDate = DateTime.MinValue;
                            dateCheckedOut = DateTime.MinValue;
                            checkedOutUserLogin = null;
                        }
                    }
                    return bookCollection;
                }
            }
        }

        /// <summary>
        /// Update function for table book
        /// </summary>
        public static int UpdateBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Books SET sku = @sku, title = @title, author = @author, genre = @genre, publisher = @publisher, publishedYear = @publishedYear, checkedOut = @checkedOut, dateCheckedOut = @dateCheckedOut, dueDate = @dueDate, checkedOutUserLogin = @checkedOutUserLogin WHERE bookId = @bookId";
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@sku", book.sku);
                    command.Parameters.AddWithValue("@title", book.title);
                    command.Parameters.AddWithValue("@author", book.author);
                    command.Parameters.AddWithValue("@genre", book.genre);
                    if (!String.IsNullOrWhiteSpace(book.Publisher))
                    {
                        command.Parameters.AddWithValue("@publisher", book.publisher);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@publisher", DBNull.Value);
                    }
                    if (book.publishedYear != 0)
                    {
                        command.Parameters.AddWithValue("@publishedYear", book.PublishedYear);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@publishedYear", DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@checkedOut", book.CheckedOut);
                    if (book.DateCheckedOut != DateTime.MinValue)
                    {
                        command.Parameters.AddWithValue("@dateCheckedOut", book.DateCheckedOut);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@dateCheckedOut", DBNull.Value);
                    }
                    if (book.DueDate != DateTime.MinValue)
                    {
                        command.Parameters.AddWithValue("@dueDate", book.DueDate);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@dueDate", DBNull.Value);
                    }
                    if (book.CheckedUserOutLogin != null)
                    {
                        command.Parameters.AddWithValue("@checkedOutUserLogin", book.CheckedUserOutLogin);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@checkedOutUserLogin", DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@bookId", Int16.Parse(book.BookId));
                    command.Connection = connection;
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Delete function for table book
        /// </summary>
        public static int DeleteBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM Books WHERE bookId = @bookId";
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("bookId", book.BookId);
                    command.Connection = connection;
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        ///Login function - verifies an account with a matching login/password pair exist in the table 
        /// </summary>
        public static int LogIn(Account account)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT userLogin, password FROM Account WHERE userLogin = @userLogin AND password = @password";
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@userLogin", account.UserLogin);
                    command.Parameters.AddWithValue("@password", account.Password);
                    command.Connection = connection;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return 1;
                        }
                    }
                }
                return 0;
            }
        }

        /// <summary>
        /// Creates function for table Account
        /// </summary>
        public static int CreateAccount(Account account)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Account (email, userLogin, password)"
                        + "VALUES(@email, @userLogin, @password)";
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@email", account.Email);
                    command.Parameters.AddWithValue("@userLogin", account.UserLogin);
                    command.Parameters.AddWithValue("@password", account.Password);
                    command.Connection = connection;
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}