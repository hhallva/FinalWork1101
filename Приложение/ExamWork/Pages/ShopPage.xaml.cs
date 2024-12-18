using DataBaseLibrary.Models;
using DataBaseLibrary.Services;
using ExamWork.Classes;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DAL = ExamWork.Classes.DataAccessLayer;

namespace ExamWork.Pages
{
    public partial class ShopPage : Page
    {
        private ProductService _service = new();

        internal List<ExamProduct> Products { get; set; }

        public string SortQuery { get; set; }

        public ShopPage()
        {
            InitializeComponent();
        }
        
        //Метод загружающий данные после загрузки страницы
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            border.Height = 0;
            //Вывод ФИО на страницу
            UserFullnameLabel.Content = $"{App.Current.Resources["UserSurname"].ToString()} " +
                                         $"{App.Current.Resources["UserName"].ToString()} " +
                                         $"{App.Current.Resources["UserPatronymic"].ToString()}";

            if ((string)App.Current.Resources["UserName"] == "Гость" || (byte)App.Current.Resources["RoleID"] == 2)
            {
                ExitImage.Visibility = Visibility.Hidden;
                EnterImage.Visibility = Visibility.Visible;
                OrderWorkImage.Visibility = Visibility.Collapsed;
            }
            else 
            {
                ExitImage.Visibility = Visibility.Visible;
                EnterImage.Visibility = Visibility.Hidden;
                OrderWorkImage.Visibility = Visibility.Visible;
            }

            //Подписка на обновление данных
            /*
            SortComboBox.SelectionChanged += QueryBuilder;
            DiscountFilterComboBox.SelectionChanged += QueryBuilder;
            SearchTextBox.TextChanged += QueryBuilder;
            */

            //Загружаем изначальные данные без фильтров
            UpdateProduct();
        }

   
        private async void UpdateProduct()
        {
            Products = await _service.GetProductsAsync("");

            foreach (ExamProduct product in Products)           
                CreateProductContainer(product);
            countLabel.Content = $"Показано {Products.Count} из {await _service.GetProductsCountAsync()}";
        }

        private void QueryBuilder(object sender, RoutedEventArgs e)
        {
            //Очищаем все карточки товаров
            MainStackPanel.Children.Clear();

            //Сбор запроса в соответствии с данными фильтов 
            SortQuery = $"WHERE ProductName LIKE '%{SearchTextBox.Text}%'";
            switch (DiscountFilterComboBox.SelectedIndex)
            {
                case 0:
                    SortQuery += "";
                    break;
                case 1:
                    SortQuery += "AND ProductDiscountAmount BETWEEN 0 AND 9.99";
                    break;
                case 2:
                    SortQuery += "AND ProductDiscountAmount BETWEEN 10 AND 14.99";
                    break;
                case 3:
                    SortQuery += "AND ProductDiscountAmount BETWEEN 15 AND 100";
                    break;
            }

            switch (SortComboBox.SelectedIndex)
            {
                case 0:
                    SortQuery += " ORDER BY ROUND(ProductCost - (ProductCost * ProductDiscountAmount*0.01),2) ASC";
                    break;
                case 1:
                    SortQuery += " ORDER BY ROUND(ProductCost - (ProductCost * ProductDiscountAmount*0.01),2) DESC";
                    break;
            }

            //Обновляем карточки товаров
            UpdateProduct();
        }

        private void CreateProductContainer(ExamProduct product)
        {
            Border border = new()
            {
                Height = 130,
                Background = new SolidColorBrush(Color.FromArgb(255, 224, 223, 223)),
                Margin = new Thickness(10)
            };

            StackPanel productStackPanel = new()
            {
                Margin = new Thickness(10),
                Tag = product.ArticleNumber,
            };

            Grid grid = new Grid();

            StackPanel stackPanel2 = new();

            Label nameProductLabel = new()
            {
                Content = product.Name,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 16
            };

            Label manufacturerProductLabel = new()
            {
                Content = product.Manufacturer,
                HorizontalAlignment = HorizontalAlignment.Left,
                Foreground = new SolidColorBrush(Color.FromArgb(255, 152, 144, 144))
            };

            Label descriptionLabel = new()
            {
                Margin = new Thickness(0, -10, 0, 0),
                Content = product.Description,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            StackPanel stackPanel3 = new()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, -5, 0, 0),
            };

            Label textLabel = new()
            {
                Content = "Цена:",
                FontSize = 16
            };

            TextBlock CostTextBlock = new()
            {
                Text = product.Cost.ToString(),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 16,
                Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0))
            };

            Button addProductItemButton = new()
            {
                Content = "Заказать",
                Background = new SolidColorBrush(Color.FromRgb(166, 166, 166)),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                Width = 100,
                Height = 30,

            };

            MainStackPanel.Children.Add(border);
            border.Child = productStackPanel;

            productStackPanel.Children.Add(grid);
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            grid.Children.Add(stackPanel2);
            stackPanel2.Children.Add(nameProductLabel);
            stackPanel2.Children.Add(descriptionLabel);
            stackPanel2.Children.Add(manufacturerProductLabel);
            stackPanel2.Children.Add(stackPanel3);

            stackPanel3.Children.Add(textLabel);
            stackPanel3.Children.Add(CostTextBlock);
            
          
            addProductItemButton.Click += AddProduct_Click;
            grid.Children.Add(addProductItemButton);
            Grid.SetColumn(addProductItemButton, 1);
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
           //необходимо реализовать добавление товара в корзину
        }

        private void CartImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //необходимо реализовать переход в корзину
        }

        private void Image_MouseDown(object sender, RoutedEventArgs e) 
            => App.CurrentFrame.Navigate(new AuthorizationPage());

        private void OrderWorkImage_MouseDown(object sender, MouseButtonEventArgs e) 
            => App.CurrentFrame.Navigate(new OrdersWorkPage());

        private void ExitImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Resources["UserID"] = null;
            App.Current.Resources["UserName"] = null;
            App.Current.Resources["UserSurname"] = null;
            App.Current.Resources["UserPatronymic"] = null;
            App.Current.Resources["UserLogin"] = null;
            App.Current.Resources["UserPassword"] = null;
            App.CurrentFrame.Navigate(new AuthorizationPage());
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation();
            if (!IsToggle)
            {
                animation.To = 180;
                animation.Duration = TimeSpan.FromSeconds(0.3);
                border.BeginAnimation(Border.HeightProperty, animation);
                IsToggle = true;
            }
            else
            {
                animation.To = 0;
                animation.Duration = TimeSpan.FromSeconds(0.3);
                border.BeginAnimation(Border.HeightProperty, animation);
                IsToggle = false;
            }
        }
    }
}