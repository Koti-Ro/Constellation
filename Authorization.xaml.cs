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

namespace Constellation
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void btnAutoriz_Click(object sender, RoutedEventArgs e)
        {
            
            if (tbLogin.Text == "admin" && tbPass.Text == "ad1")
            {
                AppFrame.frameMain.Navigate(new MainPage());
            }           
            else 
            {
                if (tbLogin.Text == "user" && tbPass.Text == "us1")
                {
                    AppFrame.frameMain.Navigate(new UserPage());
                }
                else
                {
                    MessageBox.Show("Логин или пароль введены не правильно или не заполены!\nПопробуйте снова!", "Упс!", MessageBoxButton.OK);
                }                    
            }            
            tbLogin.Text = "";
            tbPass.Text = "";
        }
    }
}
