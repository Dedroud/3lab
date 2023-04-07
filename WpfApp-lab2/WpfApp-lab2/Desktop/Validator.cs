using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Desktop
{
    public class Validator
    {
        public static bool PassValid(TextBox passtb)
        {
            if (passtb.Text.Length < 6) return false;
            else return true;
        }

        public static bool EmailValid(TextBox mailtb)
        {
            var trimmedEmail = mailtb.Text.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(mailtb.Text);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool NameValid(TextBox nametb)
        {
            if (nametb.Text.Length > 3) return true;
            else return false;
        }

        public static bool RepeatPassValid(TextBox passtb, TextBox reppasstb)
        {
            if (passtb.Text == reppasstb.Text) return true;
            else return false;
        }

    }
}
