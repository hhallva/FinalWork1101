using ExamWork.Classes;
using DAL = ExamWork.Classes.DataAccessLayer;
using System.Windows;
using System.Windows.Controls;

namespace ExamWork.Pages
{
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();

            //Значения для теста В КОНЦЕ УБРАТЬ
            loginTextBox.Text = "loginDEmgu2018";
            passwordBox.Password = "0gC3bk";
        }

        #region Методы
        //Метод для выполнения авторизации пользователя
        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (DAL.IsUserExist(loginTextBox.Text, passwordBox.Password))
            {
                User user = DAL.GetUserData(loginTextBox.Text, passwordBox.Password);
                AcceptUserData(user);

                App.CurrentFrame.Navigate(new ShopPage());
            }
            else
            {
                MessageBox.Show("Пользователь не может быть авторизован. \nЛогин или пароль введены неверно.",
                                "Сообщение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        //Метод для выполнения авторизации пользователя как гостя
        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new();
            AcceptUserData(user);

            App.CurrentFrame.Navigate(new ShopPage());
        }

        //Метод для присвоения ресурсам значений 
        private static void AcceptUserData(User user)
        {
            App.Current.Resources["UserName"] = user.Name;
            App.Current.Resources["UserSurname"] = user.Surname;
            App.Current.Resources["UserPatronymic"] = user.Patronymic;
            App.Current.Resources["UserLogin"] = user.Login;
            App.Current.Resources["UserPassword"] = user.Password;
            App.Current.Resources["RoleID"] = user.RoleID;
        }
        #endregion
    }
}
