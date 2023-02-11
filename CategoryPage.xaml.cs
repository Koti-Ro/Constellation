
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        
        public CategoryPage()
        {
            InitializeComponent();
            CategoryGrid.ItemsSource = AppConnect.model.Categories.ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddCategory());
        }

        private void btnRef_Click(object sender, RoutedEventArgs e)
        {
            CategoryGrid.ItemsSource = AppConnect.model.Categories.ToList();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить данные?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (CategoryGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < CategoryGrid.SelectedItems.Count; i++)
                    {
                        Categories prodObj = CategoryGrid.SelectedItems[i] as Categories;
                        AppConnect.model.Categories.Remove(prodObj);
                    }
                    AppConnect.model.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Hет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            CategoryGrid.ItemsSource = AppConnect.model.Categories.ToList();
        }

       
    }
}
