﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExamWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserFullnameLabel.Content = $"{App.Current.Resources["UserSurname"].ToString()} " +
                                       $"{App.Current.Resources["UserName"].ToString()} " +
                                       $"{App.Current.Resources["UserPatronymic"].ToString()}";
        }

        private void BackImage_MouseDown(object sender, MouseButtonEventArgs e)
             => App.CurrentFrame.Navigate(new CartPage());

    }
}
