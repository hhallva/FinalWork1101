using ExamWork.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DAL = ExamWork.Classes.DataAccessLayer;

namespace ExamWork.Pages
{
    public partial class ShopPage : Page
    {
        internal List<Product> Products { get; set; }
        public string SortQuery { get; set; }

        public ShopPage()
        {
            InitializeComponent();
        }
        
        //Метод загружающий данные после загрузки страницы
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Вывод ФИО на страницу
            UserFullnameLabel.Content = $"{App.Current.Resources["UserSurname"].ToString()} " +
                                         $"{App.Current.Resources["UserName"].ToString()} " +
                                         $"{App.Current.Resources["UserPatronymic"].ToString()}";
            //Подписка на обновление данных
            SortComboBox.SelectionChanged += QueryBuilder;
            DiscountFilterComboBox.SelectionChanged += QueryBuilder;
            SearchTextBox.TextChanged += QueryBuilder;

            //Загружаем изначальные данные без фильтров
            UpdateProduct();
        }

        //Метод выводящий карточки товаров
        private void UpdateProduct()
        {
            Products = DAL.GetProductsData(SortQuery);
            foreach (Product product in Products)
            {
                CreateProductContainer(product);
            }
            countLabel.Content = $"Показано {Products.Count} из {DAL.GetProductsCount()}";
        }

        //Метод для сбора данных из фильтров и поиска, и для составления запроса в БД
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

        //Метод для создания карточек товаров из листа товаров
        private void CreateProductContainer(Product product)
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
                Margin = new Thickness(0, -10, 0, 0),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 152, 144, 144))
            };

            Label вescriptionLabel = new()
            {
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

            TextBlock discounCostTextBlock = new()
            {
                Text = Math.Round(product.Cost - (product.Cost * product.DiscountAmount * 0.01), 2).ToString(),
                Height = 20,
                FontSize = 18
            };

            Border imageBorder = new()
            {
                Background = new SolidColorBrush(Color.FromArgb(255, 206, 194, 194)),
                Height = 100,

            };

            Image image = new()
            {
                Source = new BitmapImage(new Uri("/Images/product.png", UriKind.Relative))
            };

            MainStackPanel.Children.Add(border);
            border.Child = productStackPanel;

            productStackPanel.Children.Add(grid);
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            grid.Children.Add(stackPanel2);
            stackPanel2.Children.Add(nameProductLabel);
            stackPanel2.Children.Add(manufacturerProductLabel);
            stackPanel2.Children.Add(вescriptionLabel);
            stackPanel2.Children.Add(stackPanel3);

            stackPanel3.Children.Add(textLabel);
            stackPanel3.Children.Add(discounCostTextBlock);

            //Условие для скидко (чтоб скидка была показана и цена перечеркнута)
            if (product.DiscountAmount > 0)
            {
                TextBlock CostTextBlock = new()
                {
                    Text = product.Cost.ToString(),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontSize = 16,
                    TextDecorations = TextDecorations.Strikethrough,
                    Foreground = new SolidColorBrush(Color.FromArgb(255, 93, 93, 93))
                };

                Label discountLabel = new()
                {
                    Content = $"-{product.DiscountAmount}%",
                    FontSize = 40,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 10, 5),
                    Background = new SolidColorBrush((product.DiscountAmount < 15) ? Colors.White : Colors.Chartreuse),
                };

                stackPanel3.Children.Add(CostTextBlock);
                grid.Children.Add(discountLabel);
                Grid.SetColumn(discountLabel, 1);
            }

            imageBorder.Child = image;
            grid.Children.Add(imageBorder);

            Grid.SetColumn(stackPanel2, 0);
            Grid.SetColumn(imageBorder, 2);


            //Контекствое меню
            MenuItem addProductItem = new() 
            {
                Header = "Добавить к заказу",
            };
            addProductItem.Click += AddProduct_Click;

            ContextMenu productContextMenu = new();
            productContextMenu.Items.Add(addProductItem);

            //Проверка на роль
            switch (Convert.ToInt32(App.Current.Resources["RoleID"]))
            {
                case 1: //Менеджек

                    break;
                case 3://Администратор

                    break;
            }
            
            MainStackPanel.ContextMenu = productContextMenu;
            
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
           //необходимо реализовать добавление товара в корзину
        }

        //Метод отправляющий нас на стартовую страницу
        private void ExitImage_MouseDown(object sender, RoutedEventArgs e)
        {
            App.CurrentFrame.Navigate(new AuthorizationPage());
        }

        //Метод отправляющий нас на страницу карзины
        private void CartImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //необходимо реализовать переход в корзину
        }

    }
}
