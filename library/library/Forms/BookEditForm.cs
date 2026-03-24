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
    public partial class BookEditForm : Form
    {
        private DatabaseHelper _db;
        private Book _book;

        public BookEditForm(DatabaseHelper db, Book book)
        {
            InitializeComponent();
            _db = db;
            _book = book;
            LoadBookData();
            this.Text = $"Книга: {_book.Title}";
        }

        private void LoadBookData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Поле", typeof(string));
            table.Columns.Add("Значение", typeof(string));

            table.Rows.Add("ID", _book.Id);
            table.Rows.Add("Название", _book.Title);
            table.Rows.Add("Автор", _book.Author);
            table.Rows.Add("Год издания", _book.Year);
            table.Rows.Add("Всего экземпляров", _book.Quantity);
            table.Rows.Add("Доступно сейчас", _book.AvailableQuantity);

            OneBookDataGrid.DataSource = table;
            OneBookDataGrid.Columns[0].Width = 120;
            OneBookDataGrid.Columns[1].Width = 250;
            OneBookDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void DeleteBookBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangeBookBtn_Click(object sender, EventArgs e)
        {

        }
        
    }
}
