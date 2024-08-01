using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BL;
using BE;
namespace UI
{
    /// <summary>
    /// Interaction logic for frmGuestRequest.xaml
    /// </summary>
    public partial class frmGuestRequest : Window
    {
        IBL bL = FactoryBL.GetBL();
        GuestRequest gr = new GuestRequest();
        private List<GuestRequest> lstGuestRequest = new List<GuestRequest>();
        public frmGuestRequest()
        {
            InitializeComponent();
            lstGuestRequest = bL.GetRequest();
            guestRequestDataGrid.DataContext = lstGuestRequest;
            btnUpdate.IsEnabled = false;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new frmAddGuestRequest().ShowDialog();
            lstGuestRequest = bL.GetRequest();
            guestRequestDataGrid.DataContext = lstGuestRequest;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (guestRequestDataGrid.SelectedItem != null)
            {
                new frmAddGuestRequest((GuestRequest)(guestRequestDataGrid.SelectedItem)).ShowDialog();
            }
            lstGuestRequest = bL.GetRequest();
            guestRequestDataGrid.DataContext = lstGuestRequest;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (guestRequestDataGrid.SelectedItem != null)
            {
                GuestRequest gr = (GuestRequest)guestRequestDataGrid.SelectedItem;
                //bL.DeleteHostUnit(gr);
            }
            lstGuestRequest = bL.GetRequest();
            guestRequestDataGrid.DataContext = lstGuestRequest;
        }

        private void guestRequestDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (guestRequestDataGrid.SelectedItem != null)
            {
                btnUpdate.IsEnabled = true;
            }
            else
                MessageBox.Show("אנא בחר מהרשימה");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(Rdn.IsChecked.ToString() == "True")
            {
                guestRequestDataGrid.ItemsSource = bL.RequestByArea(Area.north);
            }
        }

        private void Rde_Checked(object sender, RoutedEventArgs e)
        {
            if (Rde.IsChecked.ToString() == "True")
            {
                guestRequestDataGrid.ItemsSource = bL.RequestByArea(Area.east);
            }

        }

        private void Rdw_Checked(object sender, RoutedEventArgs e)
        {
            if (Rdw.IsChecked.ToString() == "True")
            {
                guestRequestDataGrid.ItemsSource = bL.RequestByArea(Area.west);
            }

        }

        private void Rds_Checked(object sender, RoutedEventArgs e)
        {
            if (Rds.IsChecked.ToString() == "True")
            {
                guestRequestDataGrid.ItemsSource = bL.RequestByArea(Area.south);
            }

        }

        private void rdALL_Checked(object sender, RoutedEventArgs e)
        {
            if (rdALL.IsChecked.ToString() == "True")
            {
                lstGuestRequest = bL.GetRequest();
              //  guestRequestDataGrid.DataContext = lstGuestRequest;
                guestRequestDataGrid.ItemsSource = lstGuestRequest;
            }

        }
        //private void txtSelect_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    Enum.GetValues(typeof(BE.Area));
        //    BE.Area a = Convert.(txtSelect.Text));
        //    try
        //    {
        //        //  lstGuestRequest = bL.RequestByArea((Area)(Convert.ToInt32(txtSelect.Text)
        //        guestRequestDataGrid.ItemsSource = bL.RequestByArea((Area)(Convert.ToInt32(txtSelect.Text)));
        //    }
        //    catch
        //    { }
        //}
    }
}
