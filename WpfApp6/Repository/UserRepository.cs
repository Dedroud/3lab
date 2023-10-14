using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace WpfApp6.Repository
{
    public static class UserRepository
    {
        private static readonly ObservableCollection<UserModel> Users = new ObservableCollection<UserModel>
        {
            new UserModel("Alex", "Alex@mail.ru", "123456")
        };
        public static IEnumerable<UserModel> GetUser() { return Users; }
        public static void AddUser(UserModel user) { Users.Add(user); }
        public static void RemoveUser(UserModel user) { Users.Remove(user); }
        public static string CheckUser(UserModel user)
        {
            foreach (var item in Users)
            {
                if (user.email == item.email && user.password == item.password)
                {
                    return null;
                }
            }
            return "Такого пользователя не существует!";
        }
        public static string RegisterUser(UserModel user)
        {
            foreach (var item in Users)
            {
                if (item.email == user.email)
                {
                    return "Данная почта уже используется!";
                }
            }
            return null;

        }
    }
}
