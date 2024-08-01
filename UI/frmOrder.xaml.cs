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
    /// Interaction logic for frmOrder.xaml
    /// </summary>
    public partial class frmOrder : Window
    {
        IBL bL = FactoryBL.GetBL();
        Order or = new Order();
        private List<Order> lstOrder = new List<Order>();
        public frmOrder()
        {
            InitializeComponent();
            DataContext = lstOrder;
            lstOrder = bL.GetOrder();
            orderDataGrid.DataContext = lstOrder;
            btnUpdate.IsEnabled = false;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // orderViewSource.Source = [generic data source]
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new frmAddOrder().ShowDialog();
            lstOrder = bL.GetOrder();
            orderDataGrid.DataContext = lstOrder;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (orderDataGrid.SelectedItem != null)
            {
                new frmAddOrder((Order)(orderDataGrid.SelectedItem)).ShowDialog();
            }
            lstOrder = bL.GetOrder();
            orderDataGrid.DataContext = lstOrder;
        }

        private void orderDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (orderDataGrid.SelectedItem != null)
            {
                btnUpdate.IsEnabled = true;
                labelD.Content = ((Order)(orderDataGrid.SelectedItem)).ToString();
            }
            else
                MessageBox.Show("אנא בחר מהרשימה");
        }

    }
}
