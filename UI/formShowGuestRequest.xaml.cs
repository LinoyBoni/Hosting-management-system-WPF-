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
    /// Interaction logic for formShowGuestRequest.xaml
    /// </summary>
    public partial class formShowGuestRequest : Window
    {
        IBL bL = FactoryBL.GetBL();
        string st;
        GuestRequest gr = new GuestRequest();
        private List<GuestRequest> lstGuestRequest = new List<GuestRequest>();
        public formShowGuestRequest()
        {
            InitializeComponent();
            label.Content = DateTime.Now.ToString();
          
        }
        public formShowGuestRequest(string name)
        {
            InitializeComponent();
            st = name;
            lblName.Content = "Welcome " + name;
            label.Content = DateTime.Now.ToString();
            grpD.Visibility = Visibility.Hidden;
        }
        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            new frmAddGuestRequest(st).ShowDialog();
            lstGuestRequest = bL.GetRequest();
            dataGridRequest.ItemsSource = lstGuestRequest;
        }
        private void btnAdd_MouseEnter_1(object sender, MouseEventArgs e)
        {
            btnAdd.Width = 200;
            btnAdd.Height = 90;
        }
        private void btnAdd_MouseLeave_1(object sender, MouseEventArgs e)
        {
            btnAdd.Width = 180;
            btnAdd.Height = 70;
        }
        private void dataGridRequest_MouseEnter(object sender, MouseEventArgs e)
        {
        }
        private void dataGridRequest_MouseLeave(object sender, MouseEventArgs e)
        {
            grpD.Visibility = Visibility.Hidden;
        }
        private void dataGridRequest_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            grpD.Visibility = Visibility.Visible;
            if (dataGridRequest.SelectedItem != null)
                labelDetails.Content = ((GuestRequest)(dataGridRequest.SelectedItem)).ToString();
        }
    }
}
