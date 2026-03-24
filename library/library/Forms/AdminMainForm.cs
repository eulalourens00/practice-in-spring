using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library.Models;
using library.DataBaseHelper;
using library.Forms;

namespace library.Forms
{
    public partial class AdminMainForm : Form
    {
        private DatabaseHelper _db;
        private DataTable _booksTable;

        public AdminMainForm(DatabaseHelper db)
        {
            InitializeComponent();
            _db = db;
            this.Text = "Библиотека — Администратор";
        }

        private void AddBookBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void CheckAllBooksBtn_Click(object sender, EventArgs e)
        {
            var adminUser = new User { Id = 0, Login = "admin", Role = "admin" };
            var userForm = new UserMainForm(_db, adminUser);
            userForm.ShowDialog();
        }

        private void AddNewUserBtn_Click(object sender, EventArgs e)
        {
            string login = Microsoft.VisualBasic.Interaction.InputBox("Введите логин:", "Новый пользователь", "");
            if (string.IsNullOrEmpty(login)) return;

            string password = Microsoft.VisualBasic.Interaction.InputBox("Введите пароль:", "Новый пользователь", "");
            if (string.IsNullOrEmpty(password)) return;

            try
            {
                string dbPath = @"C:\practice-in-spring\library\library\library.db";
                using (var connection = new System.Data.SQLite.SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Login, Password, Role) VALUES (@login, @password, 'user')";
                    using (var cmd = new System.Data.SQLite.SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Пользователь {login} добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("По всем вопросам: library@support.ru", "Поддержка",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
