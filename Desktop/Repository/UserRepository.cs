﻿using System.Collections.Generic;
using System.Windows.Documents;
using Entities;

namespace Desktop.Repository
{
    public class UserRepository
    {
        private static readonly List<UserModel> Users = new List<UserModel>
        {
            new UserModel("alex@mail.ru", "Alex", "alex123"),
        };

        public static UserModel LogIn(string email, string password)
        {
            foreach (var item in Users)
            {
                if (item.email == email && item.password == password)
                {
                    return item;
                }
            }
            return null;
        }

        public static UserModel Registration(string name, string email, string password)
        {
            foreach (var item in Users)
            {
                if(item.email == email)
                {
                    return null;
                }
            }
            var user = new UserModel(email, name, password);
            Users.Add(user);
            return user;
        }

        public static string NameTranfer(string loginEmail)
        {
            var name = "";
            foreach (var user in Users)
            {
                if (loginEmail == user.email)
                {
                    name = user.name;
                    return name;
                }
            }
            return null;
        }
    }
}