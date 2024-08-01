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
    /// Interaction logic for frmAddOrder.xaml
    /// </summary>
    public partial class frmAddOrder : Window
    {
        Order or=new Order();
        IBL bL = BL.FactoryBL.GetBL();
        private List<GuestRequest> lstGR = new List<GuestRequest>();
        private List<Host> lstHost = new List<Host>();
        public frmAddOrder()
        {
            InitializeComponent();
            grdAddOrder.DataContext = or;
            cmbStatus.ItemsSource = Enum.GetValues(typeof(BE.OrderStatus));
            cmbStatus.SelectedIndex = 0;
            button.Content = "ADD";

            cmbGRequest.DisplayMemberPath = "PrivateName";
            cmbGRequest.ItemsSource = bL.GetRequest();
            cmbGRequest.SelectedIndex = 0;
            cmbHostUnit.DisplayMemberPath = "HostingUnitName";
            cmbHostUnit.ItemsSource = bL.GetHostUnit();
            cmbHostUnit.SelectedIndex = 0;
        }
        public frmAddOrder(Order dr)
        {
            InitializeComponent();
            grdAddOrder.DataContext = or;
            cmbStatus.ItemsSource = Enum.GetValues(typeof(BE.OrderStatus));
            cmbStatus.SelectedIndex = 0;
            cmbGRequest.DisplayMemberPath = "PrivateName";
            cmbGRequest.ItemsSource = bL.GetRequest();
            cmbGRequest.SelectedIndex = 0;
            cmbHostUnit.DisplayMemberPath = "HostingUnitName";
            cmbHostUnit.ItemsSource = bL.GetHostUnit();
            cmbHostUnit.SelectedIndex = 0;

            cmbGRequest.Text = dr.GuestRequestKey.ToString();
            cmbHostUnit.Text = dr.HostingUnitKey.ToString();
            orderKeyTextBox.Text = dr.OrderKey.ToString();
            createDateDatePicker.SelectedDate = dr.CreateDate;
            createDateDatePicker.IsEnabled = false;
            orderDateDatePicker.SelectedDate = dr.OrderDate;
            orderDateDatePicker.IsEnabled = false;
            sumOfFeeTextBox.Text = dr.SumOfFee.ToString();
            sumOfFeeTextBox.IsEnabled = false;
            button.Content = "Update Status";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // orderViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            or = new Order();
            if (IsFillObject())
            {
                if(button.Content.ToString() == "ADD")
                    bL.AddOrder(or);
                if (button.Content.ToString() == "Update Status")
                {
                    bL.UpdateOrder(or);
                }
                    
            }
            this.Close();
        }
        public bool IsFillObject()
        {
            lstGR = bL.GetRequest();
            lstHost = bL.GetHost();
            bool valid = true;
            or.Status = (BE.OrderStatus)(cmbStatus.SelectedValue);
            //valid = false;
            or.HostingUnitKey = Convert.ToInt32(bL.FindUnit(cmbHostUnit.Text));
            or.GuestRequestKey = Convert.ToInt32(bL.FindGR(cmbGRequest.Text));
            try
            {

               or.OrderDate = Convert.ToDateTime(orderDateDatePicker.SelectedDate.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }
            try
            {

                or.CreateDate = Convert.ToDateTime(createDateDatePicker.SelectedDate.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }

            return valid;
        }

        private void cmbGRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
