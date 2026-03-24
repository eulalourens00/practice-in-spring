using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using library.Models;

namespace library.DataBaseHelper
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string databasePath = @"C:\practice-in-spring\library\library\library.db")
        {
            string fullPath = Path.GetFullPath(databasePath);
            _connectionString = $"Data Source={fullPath};Version=3;";

            if (!File.Exists(fullPath))
            {
                MessageBox.Show("Di nahuy", "Ok");
                CreateDatabase(fullPath);
            }
        }

        private void CreateDatabase(string dbPath)
        {
            SQLiteConnection.CreateFile(dbPath);

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string createUsers = @"
                    CREATE TABLE Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Login TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL
                    )";

                string createBooks = @"
                    CREATE TABLE Books (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Author TEXT NOT NULL,
                        Year INTEGER,
                        Quantity INTEGER DEFAULT 1,
                        AvailableQuantity INTEGER DEFAULT 1
                    )";

                string createLoans = @"
                    CREATE TABLE Loans (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserId INTEGER NOT NULL,
                        BookId INTEGER NOT NULL,
                        LoanDate DATETIME NOT NULL,
                        DueDate DATETIME NOT NULL,
                        ReturnDate DATETIME,
                        FOREIGN KEY (UserId) REFERENCES Users(Id),
                        FOREIGN KEY (BookId) REFERENCES Books(Id)
                    )";

                using (var cmd = new SQLiteCommand(createUsers, connection))
                    cmd.ExecuteNonQuery();
                using (var cmd = new SQLiteCommand(createBooks, connection))
                    cmd.ExecuteNonQuery();
                using (var cmd = new SQLiteCommand(createLoans, connection))
                    cmd.ExecuteNonQuery();

                string insertAdmin = @"
                    INSERT INTO Users (Login, Password, Role) 
                    VALUES ('admin', 'admin', 'admin')";
                using (var cmd = new SQLiteCommand(insertAdmin, connection))
                    cmd.ExecuteNonQuery();
            }
        }

        // АВТОРИЗАЦИЯ
        public User GetUser(string login, string password)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE Login = @login AND Password = @password";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Login = reader["Login"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Title, Author, Year, Quantity, AvaliableQuantity FROM Books ORDER BY Title";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            Year = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            Quantity = reader.GetInt32(4),
                            AvailableQuantity = reader.GetInt32(5)
                        });
                    }
                }
            }
            return books;
        }

        public List<Book> GetAvailableBooks()
        {
            var books = new List<Book>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Books WHERE AvailableQuantity > 0 ORDER BY Title";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            Year = reader["Year"] != DBNull.Value ? Convert.ToInt32(reader["Year"]) : 0,
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"])
                        });
                    }
                }
            }
            return books;
        }

        public void AddBook(Book book)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO Books (Title, Author, Year, Quantity, AvailableQuantity) 
                    VALUES (@title, @author, @year, @quantity, @quantity)";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@title", book.Title);
                    cmd.Parameters.AddWithValue("@author", book.Author);
                    cmd.Parameters.AddWithValue("@year", book.Year);
                    cmd.Parameters.AddWithValue("@quantity", book.Quantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBook(Book book)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    UPDATE Books 
                    SET Title = @title, Author = @author, Year = @year, Quantity = @quantity, 
                        AvailableQuantity = AvailableQuantity + (@quantity - Quantity)
                    WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", book.Id);
                    cmd.Parameters.AddWithValue("@title", book.Title);
                    cmd.Parameters.AddWithValue("@author", book.Author);
                    cmd.Parameters.AddWithValue("@year", book.Year);
                    cmd.Parameters.AddWithValue("@quantity", book.Quantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBook(int bookId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string checkQuery = "SELECT COUNT(*) FROM Loans WHERE BookId = @id AND ReturnDate IS NULL";
                using (var cmd = new SQLiteCommand(checkQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", bookId);
                    int activeLoans = Convert.ToInt32(cmd.ExecuteScalar());
                    if (activeLoans > 0)
                        throw new Exception("Нельзя удалить книгу: есть читатели, которые её не вернули");
                }

                string query = "DELETE FROM Books WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", bookId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool BorrowBook(int userId, int bookId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {
                    string checkQuery = "SELECT AvailableQuantity FROM Books WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(checkQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", bookId);
                        int available = Convert.ToInt32(cmd.ExecuteScalar());
                        if (available <= 0)
                            return false;
                    }

                    string updateBook = "UPDATE Books SET AvailableQuantity = AvailableQuantity - 1 WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(updateBook, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", bookId);
                        cmd.ExecuteNonQuery();
                    }

                    string insertLoan = @"
                        INSERT INTO Loans (UserId, BookId, LoanDate, DueDate) 
                        VALUES (@userId, @bookId, @loanDate, @dueDate)";
                    using (var cmd = new SQLiteCommand(insertLoan, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.Parameters.AddWithValue("@loanDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@dueDate", DateTime.Now.AddDays(14));
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool ReturnBook(int loanId)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {
                    string getBookQuery = "SELECT BookId FROM Loans WHERE Id = @id AND ReturnDate IS NULL";
                    int bookId;
                    using (var cmd = new SQLiteCommand(getBookQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", loanId);
                        var result = cmd.ExecuteScalar();
                        if (result == null)
                            return false;
                        bookId = Convert.ToInt32(result);
                    }

                    string updateLoan = "UPDATE Loans SET ReturnDate = @returnDate WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(updateLoan, connection))
                    {
                        cmd.Parameters.AddWithValue("@returnDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@id", loanId);
                        cmd.ExecuteNonQuery();
                    }

                    string updateBook = "UPDATE Books SET AvailableQuantity = AvailableQuantity + 1 WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(updateBook, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", bookId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public List<Loan> GetUserActiveLoans(int userId)
        {
            var loans = new List<Loan>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT l.*, b.Title as BookTitle 
                    FROM Loans l
                    JOIN Books b ON l.BookId = b.Id
                    WHERE l.UserId = @userId AND l.ReturnDate IS NULL
                    ORDER BY l.DueDate";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            loans.Add(new Loan
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                BookId = Convert.ToInt32(reader["BookId"]),
                                LoanDate = Convert.ToDateTime(reader["LoanDate"]),
                                DueDate = Convert.ToDateTime(reader["DueDate"]),
                                ReturnDate = reader["ReturnDate"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["ReturnDate"]) : (DateTime?)null,
                                BookTitle = reader["BookTitle"].ToString()
                            });
                        }
                    }
                }
            }
            return loans;
        }

        public List<Loan> GetAllActiveLoans()
        {
            var loans = new List<Loan>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT l.*, b.Title as BookTitle, u.Login as UserLogin
                    FROM Loans l
                    JOIN Books b ON l.BookId = b.Id
                    JOIN Users u ON l.UserId = u.Id
                    WHERE l.ReturnDate IS NULL
                    ORDER BY l.DueDate";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loans.Add(new Loan
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            BookId = Convert.ToInt32(reader["BookId"]),
                            LoanDate = Convert.ToDateTime(reader["LoanDate"]),
                            DueDate = Convert.ToDateTime(reader["DueDate"]),
                            ReturnDate = null,
                            BookTitle = reader["BookTitle"].ToString(),
                            UserLogin = reader["UserLogin"].ToString()
                        });
                    }
                }
            }
            return loans;
        }
    }
}
