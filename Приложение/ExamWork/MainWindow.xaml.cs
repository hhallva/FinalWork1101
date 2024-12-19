﻿using ExamWork.Pages;
using System.Windows;

namespace ExamWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            App.CurrentFrame = MainFrame;
            MainFrame.Navigate(new AuthorizationPage());
        }
    }
}