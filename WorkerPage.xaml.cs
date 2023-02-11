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
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            InitializeComponent();
            WorkerGrid.ItemsSource = AppConnect.model.Workers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void tbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var cur = AppConnect.model.Workers.ToList();

            cur = cur.Where(x => x.FirstName.ToLower().StartsWith(tbSearch.Text.ToLower()) ||
            x.MiddleName.ToLower().StartsWith(tbSearch.Text.ToLower()) ||
            x.LastName.ToLower().StartsWith(tbSearch.Text.ToLower())
            ).ToList();

            WorkerGrid.ItemsSource = cur.ToList();
        }

        private void btnRef_Click(object sender, RoutedEventArgs e)
        {
            WorkerGrid.ItemsSource = AppConnect.model.Workers.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddWorker());
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить данные?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (WorkerGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < WorkerGrid.SelectedItems.Count; i++)
                    {
                        Workers prodObj = WorkerGrid.SelectedItems[i] as Workers;
                        AppConnect.model.Workers.Remove(prodObj);
                    }
                    AppConnect.model.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Hет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            WorkerGrid.ItemsSource = AppConnect.model.Workers.ToList();
        }
    }
}
