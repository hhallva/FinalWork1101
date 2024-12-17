using DataBaseLibrary.Models;
using DataBaseLibrary.Services;
using System.Windows;
using System.Windows.Controls;

namespace ExamWork.Pages
{
    public partial class AuthorizationPage : Page
    {
        private UserService _service = new();

        public AuthorizationPage()
        {
            InitializeComponent();

            //Значения для теста В КОНЦЕ УБРАТЬ
            loginTextBox.Text = "loginDEmgu2018";
            passwordBox.Password = "0gC3bk";
        }

        #region Методы
        private async void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
           
                if (await _service.IsUserExistAsync(loginTextBox.Text, passwordBox.Password))
                {
                    ExamUser user = await _service.GetUserAsync(loginTextBox.Text, passwordBox.Password);
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
            ExamUser user = new();
            AcceptUserData(user);

            App.CurrentFrame.Navigate(new ShopPage());
        }

        //Метод для присвоения ресурсам значений 
        private void AcceptUserData(ExamUser user)
        {
            App.Current.Resources["UserID"] = user.UserId;
            App.Current.Resources["RoleID"] = user.RoleId;
            App.Current.Resources["UserName"] = user.Name;
            App.Current.Resources["UserSurname"] = user.Surname;
            App.Current.Resources["UserPatronymic"] = user.Patronymic;
            App.Current.Resources["UserLogin"] = user.Login;
            App.Current.Resources["UserPassword"] = user.Password;
        }
        #endregion
    }
}
