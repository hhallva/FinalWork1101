using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.Classes
{
    public class User
    {
        #region Свойства
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        #endregion

        #region Констуркторы 
        public User(string name, string patronymic, string surname, string login, string password, int role)
        {
            Name = name;
            Patronymic = patronymic;
            Surname = surname;
            Login = login;
            Password = password;
            RoleID = role;
        }

        public User() : this("Гость", string.Empty, string.Empty, string.Empty, string.Empty, 2) { }
        #endregion

    }
}
