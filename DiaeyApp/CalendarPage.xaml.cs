using DiaeyApp;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DiaryApp
{

    public partial class CalendarPage : Window
    {
        DiaryContext db;
        public CalendarPage()
        {
            InitializeComponent();

            db = new DiaryContext();

            LoadDataGridData();

        }

        private void LoadDataGridData()
        {
            // Получаем все записи из базы данных
            List<Note> notes = db.Notes.ToList();

            dataGrid.ItemsSource = notes;
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void lblNote_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtNote.Focus();
        }

        private void lblTime_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtTime.Focus();
        }

        private void txtNote_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNote.Text) && txtNote.Text.Length > 0)
                lblNote.Visibility = Visibility.Collapsed;
            else
                lblNote.Visibility = Visibility.Visible;
        }

        private void txtTime_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTime.Text) && txtTime.Text.Length > 0)
                lblTime.Visibility = Visibility.Collapsed;
            else
                lblTime.Visibility = Visibility.Visible;
        }

        private void Image_MouseUp_Calendar(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из TextBox'ов
            string noteText = txtNote.Text;
            string timeText = txtTime.Text;

            // Создаем новую запись
            Note note = new Note(noteText, timeText);

            // Добавляем новую запись в базу данных
            db.Notes.Add(note);
            db.SaveChanges();

            // Очищаем поля после сохранения
            txtNote.Text = "";
            txtTime.Text = "";

            LoadDataGridData();
        }
    }
}