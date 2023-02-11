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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            MainGrid.ItemsSource = AppConnect.model.Main.ToList();
        }

        private void btnWorkers_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new WorkerPage());
        }

        private void btnFoods_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new FoodPage());
        }        

        private void btnRef_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.ItemsSource = AppConnect.model.Main.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функция находится в разработке! (Потому что я хлебушек)", "Упс!", MessageBoxButton.OK);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void btnGen_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
