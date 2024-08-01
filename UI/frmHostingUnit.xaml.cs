using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Converters;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;
using Microsoft.Win32;
using System.Data;

namespace UI
{
    /// <summary>
    /// Interaction logic for frmHostingUnit.xaml
    /// </summary>
    public partial class frmHostingUnit : Window
    {
        IBL bL = FactoryBL.GetBL();
        HostingUnit hu = new HostingUnit();
        private List<HostingUnit> lstHostingUnit = new List<HostingUnit>();
        
        public frmHostingUnit()
        {
            InitializeComponent();
            DataContext = lstHostingUnit;
            lstHostingUnit = bL.GetHostUnit();
            hostingUnitDataGrid.DataContext = lstHostingUnit;
            btnUpdate_Copy.IsEnabled = false;
            btnDelete_Copy.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new frmAddHostingUnit().ShowDialog();
            lstHostingUnit = bL.GetHostUnit();
            hostingUnitDataGrid.DataContext = lstHostingUnit;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (hostingUnitDataGrid.SelectedItem != null)
            {
                new frmAddHostingUnit((HostingUnit)(hostingUnitDataGrid.SelectedItem)).ShowDialog();
            }
            lstHostingUnit = bL.GetHostUnit();
            hostingUnitDataGrid.DataContext = lstHostingUnit;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
            if (hostingUnitDataGrid.SelectedItem != null)
            {
                HostingUnit hu = (HostingUnit)hostingUnitDataGrid.SelectedItem;
                MessageBoxResult ans = MessageBox.Show($"Are you sure you want to delete this hosting Unit?", "Remove hosting Unit", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (ans == MessageBoxResult.Yes)
                {
                    try
                    {
                        bL.DeleteHostUnit(hu);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                    
            }
            lstHostingUnit = bL.GetHostUnit();
            hostingUnitDataGrid.DataContext = lstHostingUnit;
        }

        private void hostingUnitDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (hostingUnitDataGrid.SelectedItem != null)
            {
                btnUpdate_Copy.IsEnabled = true;
                btnDelete_Copy.IsEnabled = true;
                labelHost.Content = hostingUnitDataGrid.SelectedItem.ToString();
            }
            else
                MessageBox.Show("אנא בחר מהרשימה");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
