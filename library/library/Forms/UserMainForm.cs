using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library.DataBaseHelper;
using library.Models;
namespace library.Forms
{
    public partial class UserMainForm : Form
    {
        private DatabaseHelper _db;
        private User _currentUser;
        private DataTable _availableBooksTable;

        public UserMainForm(DatabaseHelper db, User user)
        {
            InitializeComponent();
            _db = db;
            _currentUser = user;
            if (user.Role == "admin")
                this.Text = "Библиотека — Администратор (просмотр книг)";
            else
                this.Text = $"Библиотека — {user.Login}";

            LoadBooks();
        }

        private void LoadBooks()
        {
            var books = _db.GetAllBooks();
            var booksTable = new DataTable();
            booksTable.Columns.Add("Id", typeof(int));
            booksTable.Columns.Add("Название", typeof(string));
            booksTable.Columns.Add("Автор", typeof(string));
            booksTable.Columns.Add("Год", typeof(int));
            booksTable.Columns.Add("Всего", typeof(int));
            booksTable.Columns.Add("Доступно", typeof(int));

            foreach (var book in books)
            {
                booksTable.Rows.Add(book.Id, book.Title, book.Author, book.Year, book.Quantity, book.AvailableQuantity);
            }

            BooksDataGrid.DataSource = booksTable;
            BooksDataGrid.Columns["Id"].Visible = false;
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Вы вошли как: {_currentUser.Login}\nРоль: Читатель", "Профиль",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string search = SearchBox.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(search))
            {
                LoadBooks();
                return;
            }

            var books = _db.GetAllBooks();
            var filtered = books.FindAll(b => b.Title.ToLower().Contains(search) || b.Author.ToLower().Contains(search));

            var filteredTable = new DataTable();
            filteredTable.Columns.Add("Id", typeof(int));
            filteredTable.Columns.Add("Название", typeof(string));
            filteredTable.Columns.Add("Автор", typeof(string));
            filteredTable.Columns.Add("Год", typeof(int));
            filteredTable.Columns.Add("Всего", typeof(int));
            filteredTable.Columns.Add("Доступно", typeof(int));

            foreach (var book in filtered)
            {
                filteredTable.Rows.Add(book.Id, book.Title, book.Author, book.Year, book.Quantity, book.AvailableQuantity);
            }
            BooksDataGrid.DataSource = filteredTable;
            BooksDataGrid.Columns["Id"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("По всем вопросам: library@support.ru", "Поддержка",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BooksDataGrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(BooksDataGrid.Rows[e.RowIndex].Cells["Id"].Value);
            var books = _db.GetAllBooks();
            var book = books.Find(b => b.Id == id);

            if (book != null)
            {
                var form = new BookEditForm(_db, book);
                form.ShowDialog();
            }
        }
    }
}
