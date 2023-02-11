using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Page
    {
        
        public AddCategory()
        {
            InitializeComponent();
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Categories servObj = new Categories()
                {
                    idCategory = Convert.ToInt32(tbID.Text),
                    Name = tbName.Text,
                };
                AppConnect.model.Categories.Add(servObj);


                AppConnect.model.SaveChanges();
                AppFrame.frameMain.GoBack();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message.ToString(), "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
