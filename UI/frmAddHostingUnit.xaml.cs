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
using System.Data;

namespace UI
{
    /// <summary>
    /// Interaction logic for addHostingUnit.xaml
    /// </summary>
    public partial class frmAddHostingUnit : Window
    {
        //public BE.HostingUnit currentHostingUnit { get; set; }
        IBL bL = BL.FactoryBL.GetBL();
        BE.HostingUnit hu=new BE.HostingUnit();
        private List<HostingUnit> lstHostingUnit = new List<HostingUnit>();
        public frmAddHostingUnit()
        {
            //set the fields of combobox and ect.
            InitializeComponent();
            //this.currentHostingUnit = hu;
            mainGridAdd.DataContext = hu;
            areaCMB.ItemsSource = Enum.GetValues(typeof(BE.Area));
            ownerCMB.DisplayMemberPath = "PrivateName";
            ownerCMB.ItemsSource = bL.GetHost();
            ownerCMB.SelectedIndex = 0;
            areaCMB.SelectedIndex = 0;
            
        }
        public frmAddHostingUnit(HostingUnit dr)//update
        {
            InitializeComponent();
            //hostingUnitKeyTXT.Text = dr.HostingUnitKey.ToString();
            ownerCMB.ItemsSource = bL.GetHost();
            ownerCMB.SelectedIndex = 0;
            ownerCMB.DisplayMemberPath = "PrivateName";
            ownerCMB.Text = dr.Owner.PrivateName;
            hostingUnitTXT.Text = dr.HostingUnitName;
            areaCMB.ItemsSource = Enum.GetValues(typeof(BE.Area));
            areaCMB.Text = dr.Area.ToString();
            button.Content = "UPDATE";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           hu = new BE.HostingUnit();
            if (IsFillObject())
            {
                if (button.Content.ToString() == "ADD")
                {
                    bL.AddHostUnit(hu);
                }
                else
                    if (button.Content.ToString() == "UPDATE")
                {
                   // hu.HostingUnitKey = Convert.ToInt32(hostingUnitKeyTXT.Text);
                    bL.UpdateHostUnit(hu);
                } 
                lstHostingUnit = bL.GetHostUnit();
            }
            this.Close();
        }
        public bool IsFillObject()
        {
            //לבדוק את OWNER
            bool valid = true;
            hu.Area = (BE.Area)(areaCMB.SelectedValue);
            hu.Owner = (Host)(ownerCMB.SelectedValue);
            try
            {
                hu.HostingUnitName = hostingUnitTXT.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }

            return valid;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }
    }
}
