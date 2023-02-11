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
    /// Логика взаимодействия для FoodPage.xaml
    /// </summary>
    public partial class FoodPage : Page
    {
        public FoodPage()
        {
            InitializeComponent();
            FoodGrid.ItemsSource = AppConnect.model.Foods.ToList();
            cmbCategory.ItemsSource = AppConnect.model.Foods.Select(x => x.Categories.Name).Distinct().ToList();
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new CategoryPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void tbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var cur = AppConnect.model.Foods.ToList();

            cur = cur.Where(x => x.Name.ToLower().StartsWith(tbSearch.Text.ToLower())
            ).ToList();

            FoodGrid.ItemsSource = cur.ToList();
        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            if (cmbCategory.SelectedIndex >= 0)
            {                
                var cur = AppConnect.model.Foods.ToList();
                cur = cur.Where(x => x.Categories.Name.ToString().StartsWith(cmbCategory.SelectedItem.ToString())).ToList();
                FoodGrid.ItemsSource = cur.ToList();
            }
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            cmbCategory.SelectedIndex = -1;
            FoodGrid.ItemsSource = AppConnect.model.Foods.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddCategory());
        }

        private void btnRef_Click(object sender, RoutedEventArgs e)
        {
            FoodGrid.ItemsSource = AppConnect.model.Foods.ToList();
        }
        
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить данные?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (FoodGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < FoodGrid.SelectedItems.Count; i++)
                    {
                        Foods prodObj = FoodGrid.SelectedItems[i] as Foods;
                        AppConnect.model.Foods.Remove(prodObj);
                    }
                    AppConnect.model.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Hет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            FoodGrid.ItemsSource = AppConnect.model.Foods.ToList();
        }

        private void btnProizvod_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new CategoryPage());
        }
    }
}
