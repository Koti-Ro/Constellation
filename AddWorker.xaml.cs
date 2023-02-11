using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using System.Xml.Linq;

namespace Constellation
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Page
    {
        public AddWorker()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    Workers servObj = new Workers()
            //    {
            //        idWorker = Convert.ToInt32(tbID.Text),
            //        FirstName = tbFName.Text,
            //        MiddleName = tbMName.Text,
            //        LastName=tbLName.Text,
            //        Birthday=Convert.ToDateTime(tbBday.Text),
            //        Phone= tbPhone.Text,
            //        Mail=tbMail.Text,

            //    };
            //    AppConnect.model.Workers.Add(servObj);

            //    AppConnect.model.SaveChanges();
            //    AppFrame.frameMain.GoBack();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    MessageBox.Show("Ошибка:" + ex.Message.ToString(), "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
        }
    }
}
