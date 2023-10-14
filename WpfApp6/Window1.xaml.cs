using WpfApp6.Repository;
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
using Todo.Entities;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Validator.ValidateName(UserBox.Text) == false)
            {
                MessageBox.Show("Некорректное имя");
            }
            else if (Validator.ValidateEmail(MailBox.Text) == false)
            {
                MessageBox.Show("Некорректная почта");
            }
            else if (Validator.ValidatePassword(PassBox.Password) == false)
            {
                MessageBox.Show("некорректный пароль");
            }
            else if (PassBox.Password != ReturnPassBox.Password)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else
            {
                var registerUser = new UserModel(UserBox.Text, MailBox.Text, PassBox.Password);
                if (UserRepository.RegisterUser(registerUser) == null)
                {
                    var window3 = new Task();
                    window3.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(UserRepository.RegisterUser(registerUser));
                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
