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
    public partial class LoginForm : Form
    {
        private DatabaseHelper _db;

        public LoginForm()
        {
            InitializeComponent();
            _db = new DatabaseHelper(@"C:\practice-in-spring\library\library\library.db");
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _db.GetUser(login, password);

            if (user != null)
            {
                if (user.Role == "admin")
                {
                    var adminForm = new AdminMainForm(_db);
                    adminForm.Show();
                }
                else
                {
                    var userForm = new UserMainForm(_db, user);
                    userForm.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
