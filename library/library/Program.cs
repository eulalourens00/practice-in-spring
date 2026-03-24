using library.DataBaseHelper;
using library.Forms;
using System;
using System.Windows.Forms;

namespace library
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //string dbPath = (@"C:\practice-in-spring\library\library\library.db");
            //if (!File.Exists(dbPath))
            //{
            //    MessageBox.Show($"Файл БД не найден по пути:\n{dbPath}\n\nСоздам новый.", "Внимание",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    MessageBox.Show("zaebix", "Ok");
            //}
            //try
            //{
            //    var db = new DatabaseHelper(dbPath);
            //    var books = db.GetAllBooks();
            //    MessageBox.Show($"БД работает\nНайдено книг: {books.Count}", "Успех",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Ошибка подключения к БД:\n{ex.Message}", "Ошибка",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            Application.Run(new LoginForm());
        }
    }
}