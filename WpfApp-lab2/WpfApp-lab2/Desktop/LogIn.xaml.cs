using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validator.EmailValid(Login)==false)
            {
                MessageBox.Show("Ошибка в указанном адресе E-mail");
            }
            else if (Validator.PassValid(Pass)==false)
            {
                MessageBox.Show("Ошибка в указанном пароле!");
            }
            else
            {
                var wind = new Window1 ();
                wind.Show();
                this.Close();
            }
        }          

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var wind = new Registration();
            wind.Show();
            this.Close();
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var wind = new Registration();
            wind.Show();
            this.Close();
        }
    }
}
