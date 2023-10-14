using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp6
{
    public static class Validator
    {
        public static bool ValidatePassword(string password)
        {
            if (password.Length < 6) return false;
            else return true;
        }
        public static bool ValidateEmail(string email)
        {
            return (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"));
        }
        public static bool ValidateName(string name)
        {
            if (name.Length < 3) return false;
            else return true;
        }
        public static bool ValidateIsAnyEmpty(string name, string email, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return true;
            }
            else return false;
        }
        public static bool ValidateIsAnyEmpty(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return true;
            }
            else return false;
        }
    }
}

