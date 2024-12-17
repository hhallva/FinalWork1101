using Microsoft.Data.SqlClient;
using System.Data;


namespace ExamWork.Classes
{
    public class DataAccessLayer
    {
        #region Свойства
        public static string ServerName { get; set; } = @"MSI";
        public static string DatabaseName { get; set; } = "Exam";
        public static string Login { get; set; } = @"MSI\slavv";
        public static string Password { get; set; } = "";
        public static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new()
                {
                    DataSource = ServerName,
                    UserID = Login,
                    //Password = Password,
                    InitialCatalog = DatabaseName,
                    IntegratedSecurity = true,
                    TrustServerCertificate = true
                };
                return builder.ConnectionString;
            }
        }
        #endregion

        #region Методы
        //Метод определяющий существует ли пользователь в БД или нет (для авторизации)
        public static bool IsUserExist(string login, string password)
        {
            SqlConnection connection = new(ConnectionString);
            connection.Open();

            string query = "SELECT * FROM ExamUser WHERE UserLogin = @login AND UserPassword = @password";

            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            return command.ExecuteScalar() != null;
        }

        //Метод получающий данные пользователя из БД 
        public static User GetUserData(string login, string password)
        {
            SqlConnection connection = new(ConnectionString);
            connection.Open();

            string query = "SELECT * FROM ExamUser WHERE UserLogin = @login AND UserPassword = @password";

            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            var reader = command.ExecuteReader();

            DataTable table = new();
            table.Load(reader);

            User user = new()
            {
                Name = table.Rows[0]["UserName", DataRowVersion.Current].ToString(),
                Patronymic = table.Rows[0]["UserPatronymic", DataRowVersion.Current].ToString(),
                Surname = table.Rows[0]["UserSurname", DataRowVersion.Current].ToString(),
                Login = table.Rows[0]["UserLogin", DataRowVersion.Current].ToString(),
                Password = table.Rows[0]["UserPassword", DataRowVersion.Current].ToString(),
                RoleID = Convert.ToInt32(table.Rows[0]["RoleID", DataRowVersion.Current]),
            };
            return user;
        }

        //Метод получающий данные о товарах в соответствии с выбранными фильтами
        public static List<Product> GetProductsData(string filtersQuery)
        {
            SqlConnection connection = new(ConnectionString);
            connection.Open();

            string query = $"SELECT * FROM ExamProduct {filtersQuery}";
            SqlCommand command = new(query, connection);

            var reader = command.ExecuteReader();

            List<Product> products = new();
            while (reader.Read())
            {
                Product product = new()
                {
                    ArticleNumber = reader["ProductArticleNumber"].ToString(),
                    Name = reader["ProductName"].ToString(),
                    Description = reader["ProductDescription"].ToString(),
                    Category = reader["ProductCategory"].ToString(),
                    Manufacturer = reader["ProductManufacturer"].ToString(),
                    Cost = Convert.ToDouble(reader["ProductCost"]),
                    DiscountAmount = Convert.ToInt32(reader["ProductDiscountAmount"]),
                    QuantityInStock = Convert.ToInt32(reader["ProductQuantityInStock"]),
                    Status = reader["ProductStatus"].ToString(),
                };
                products.Add(product);
            }
            return products;
        }

        //Метод получающий количество товаров
        public static int GetProductsCount()
        {
            SqlConnection connection = new(ConnectionString);
            connection.Open();

            string query = $"SELECT * FROM ExamProduct";
            SqlCommand command = new(query, connection);

            var reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            return count;
        }
        #endregion
    }
}
