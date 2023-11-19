using DiaryApp;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DiaeyApp
{

    public partial class LoginPage : Window
    {
        DiaryContext db;

        public LoginPage()
        {
            InitializeComponent();

            db = new DiaryContext();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            string emailBox = txtEmail.Text.Trim();
            string password = passwordBox.Password.Trim();

            if(emailBox == null &&  password == null)
            {
                MessageBox.Show("Поля должны быть заполнены");
                txtEmail.Background = Brushes.Red;
                passwordBox.Background = Brushes.Red;
            }
            else
            {
                User user = db.Users.Where(u => u.Email == emailBox && u.Password == password).FirstOrDefault();

                if (user != null)
                {
                    CalendarPage page = new CalendarPage();
                    page.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage signUpPage = new SignUpPage();
            signUpPage.Show();
            this.Hide();
        }
    }
}