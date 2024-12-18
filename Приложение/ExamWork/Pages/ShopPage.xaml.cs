using DataBaseLibrary.Models;
using DataBaseLibrary.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ExamWork.Pages
{
    public partial class ShopPage : Page
    {
        private List<ExamProduct> Products { get; set; }

        private ProductService _service = new();

        private bool IsToggle;

        public ShopPage()
        {
            InitializeComponent();

            SearchTextBox.TextChanged += Filters_Changed;
            FromTextBox.TextChanged += Filters_Changed;
            ToTextBox.TextChanged += Filters_Changed;
            SortComboBox.SelectionChanged += Filters_Changed;
            ManufacturerComboBox.SelectionChanged += Filters_Changed;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            border.Height = 0;

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

            await FillManufacturerComboBoxAsync();
            await UpdateProductAsync();
        }

        private async void Filters_Changed(object sender, RoutedEventArgs e)
        {
            MainStackPanel.Children.Clear();
            await UpdateProductAsync();
        }

        private async Task UpdateProductAsync()
        {
            try
            {
                decimal? fromCost = null;
                decimal? toCost = null;

                if (!string.IsNullOrWhiteSpace(FromTextBox.Text) && decimal.TryParse(FromTextBox.Text, out decimal parsedFromCost))
                    fromCost = parsedFromCost;

                if (!string.IsNullOrWhiteSpace(ToTextBox.Text) && decimal.TryParse(ToTextBox.Text, out decimal parsedToCost))
                    toCost = parsedToCost;


                Products = await _service.GetProductsAsync(
                SearchTextBox.Text,
                SortComboBox.SelectedIndex,
                fromCost.GetValueOrDefault(), // Если fromCost == null, будет использовано значение по умолчанию 0
                toCost, // Может быть null, это обрабатывается в методе GetProductsAsync
                ManufacturerComboBox.SelectedValue.ToString()
                );

                foreach (ExamProduct product in Products)
                    CreateProductContainer(product);
                countLabel.Content = $"Показано {Products.Count} из {await _service.GetProductsCountAsync()}";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("A second operation was started on this context instance before a previous operation completed. This is usually caused by different threads concurrently using the same instance of DbContext. For more information on how to avoid threading issues with DbContext, see https://go.microsoft.com/fwlink/?linkid=2097913."))
                    MessageBox.Show("Ты слишком быстро вводишь символы!");
                if (ex.Message.Contains($" is out of range."))
                    MessageBox.Show("Это слишком большое число!");
                else
                    MessageBox.Show($"Ошибка: {ex}");
            }
        }

        public async Task FillManufacturerComboBoxAsync()
        {
            try
            {
                var manufacturers = await _service.GetManufacturersAsync();

                if (manufacturers != null)
                    foreach (var manufacturer in manufacturers)
                        ManufacturerComboBox.Items.Add(manufacturer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}");
            }
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

        private void OrderWorkImage_MouseDown(object sender, MouseButtonEventArgs e)
         => App.CurrentFrame.Navigate(new OrdersWorkPage());

        private void CartImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //необходимо реализовать переход в корзину
        }

        private void EnterImage_MouseDown(object sender, RoutedEventArgs e)
            => App.CurrentFrame.Navigate(new AuthorizationPage());

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
    }
}