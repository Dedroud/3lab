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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Todo.Entities;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 taskWindow = new Window1();
            taskWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
  
            if (Validator.ValidateEmail(Mail.Text) == false)
            {
                MessageBox.Show("Некорректная почта");
            }
            else if (Validator.ValidatePassword(Pass.Password) == false)
            {
                MessageBox.Show("Некорректный пароль");
            }
            else
            {
                var loginuser = new UserModel("", Mail.Text, Pass.Password);
                if (UserRepository.CheckUser(loginuser) == null)
                {

                    var window3 = new Task();
                    window3.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(UserRepository.CheckUser(loginuser));
                }
            }
        }
    }
}
