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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersWorkPage.xaml
    /// </summary>
    public partial class OrdersWorkPage : Page
    {
        public OrdersWorkPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Вывод ФИО на страницу
            UserFullnameLabel.Content = $"{App.Current.Resources["UserSurname"].ToString()} " +
                                         $"{App.Current.Resources["UserName"].ToString()} " +
                                         $"{App.Current.Resources["UserPatronymic"].ToString()}";
            
            //Проверка на роль
            switch (Convert.ToInt32(App.Current.Resources["RoleID"]))
            {
                case 1: //Менеджер
                    RoleLabel.Content = "(Менеджер)";
                    break;
                case 3://Администратор
                    RoleLabel.Content = "(Администратор)";
                    break;
            }

        }

        private void BackImage_MouseDown(object sender, MouseButtonEventArgs e) 
            => App.CurrentFrame.Navigate(new ShopPage());
    }
}
