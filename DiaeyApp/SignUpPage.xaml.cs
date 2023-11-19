using DiaeyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiaryApp
{

    public partial class SignUpPage : Window
    {
        DiaryContext db;

        public SignUpPage()
        {
            InitializeComponent();

            db = new DiaryContext();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void textName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtName.Focus();
        }

        private void textSurName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtSurName.Focus();
        }

        private void textUserName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUserName.Focus();
        }

        private void textPhoneNumber_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPhoneNumber.Focus();
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }

        private void Button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.Trim();
            string surname = txtSurName.Text.Trim();
            string username = txtUserName.Text.Trim();
            string emailBox = txtEmail.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string password = passwordBox.Password.Trim();

            if (emailBox == null && password == null && name == null && surname == null && username == null && phoneNumber == null)
            {
                MessageBox.Show("Поля должны быть заполнены");
                txtEmail.Background = Brushes.Red;
                passwordBox.Background = Brushes.Red;
                txtName.Background = Brushes.Red;
                txtSurName.Background = Brushes.Red;
                txtUserName.Background = Brushes.Red;
                txtPhoneNumber.Background = Brushes.Red;
            }
            else
            {
               User user = new User(name, surname, username, phoneNumber, emailBox, password);
               db.Users.Add(user);
               db.SaveChanges();

              CalendarPage calendarPage = new CalendarPage();
              calendarPage.Show();
              this.Hide();
            }
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && txtName.Text.Length > 0)
                textName.Visibility = Visibility.Collapsed;
            else
                textName.Visibility = Visibility.Visible;
        }

        private void txtSurName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSurName.Text) && txtSurName.Text.Length > 0)
                textSurName.Visibility = Visibility.Collapsed;
            else
                textSurName.Visibility = Visibility.Visible;
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && txtUserName.Text.Length > 0)
                textUserName.Visibility = Visibility.Collapsed;
            else
                textUserName.Visibility = Visibility.Visible;
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

        private void txtPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPhoneNumber.Text) && txtPhoneNumber.Text.Length > 0)
                textPhoneNumber.Visibility = Visibility.Collapsed;
            else
                textPhoneNumber.Visibility = Visibility.Visible;
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }
    }
}
