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
    /// Interaction logic for frmAddGuestRequest.xaml
    /// </summary>
    /// 
    
    public partial class frmAddGuestRequest : Window
    {
        GuestRequest gr = new GuestRequest();
        IBL bL = BL.FactoryBL.GetBL();
        string GuestID;
        public frmAddGuestRequest()
        {
            InitializeComponent();
            grdAdd.DataContext = gr;
            cmbArea.ItemsSource = Enum.GetValues(typeof(BE.Area));
            cmbArea.SelectedIndex = 0;
            cmbSubArea.IsEnabled = false;
            cmbSubArea.ItemsSource = Enum.GetValues(typeof(BE.Area));
            cmbSubArea.SelectedIndex = 0;
            cmbType.ItemsSource = Enum.GetValues(typeof(BE.Type));
            cmbType.SelectedIndex = 0;
            cmbPool.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbPool.SelectedIndex = 0;
            cmbJacuzzi.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbJacuzzi.SelectedIndex = 0;
            cmbGarden.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbGarden.SelectedIndex = 0;
            cmbChildrenAttraction.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbChildrenAttraction.SelectedIndex = 0;
            btnAdd.Content = "ADD";
        }
        public frmAddGuestRequest(string id)
        {
            InitializeComponent();
            GuestID = id;
            grdAdd.DataContext = gr;
            cmbArea.ItemsSource = Enum.GetValues(typeof(BE.Area));
            cmbArea.SelectedIndex = 0;
            cmbSubArea.IsEnabled = false;
            cmbSubArea.ItemsSource = Enum.GetValues(typeof(BE.Area));
            cmbSubArea.SelectedIndex = 0;
            cmbType.ItemsSource = Enum.GetValues(typeof(BE.Type));
            cmbType.SelectedIndex = 0;
            cmbPool.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbPool.SelectedIndex = 0;
            cmbJacuzzi.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbJacuzzi.SelectedIndex = 0;
            cmbGarden.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbGarden.SelectedIndex = 0;
            cmbChildrenAttraction.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbChildrenAttraction.SelectedIndex = 0;
            btnAdd.Content = "ADD";
        }
        public frmAddGuestRequest(GuestRequest dr)
        {
            InitializeComponent();
            grdAdd.DataContext = gr;
            cmbArea.ItemsSource = Enum.GetValues(typeof(BE.Area));
            cmbArea.SelectedIndex = 0;
            cmbSubArea.IsEnabled = false;
            cmbSubArea.ItemsSource = Enum.GetValues(typeof(BE.Area));
            cmbSubArea.SelectedIndex = 0;
            cmbType.ItemsSource = Enum.GetValues(typeof(BE.Type));
            cmbType.SelectedIndex = 0;
            cmbPool.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbPool.SelectedIndex = 0;
            cmbJacuzzi.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbJacuzzi.SelectedIndex = 0;
            cmbGarden.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbGarden.SelectedIndex = 0;
            cmbChildrenAttraction.ItemsSource = Enum.GetValues(typeof(BE.Interest));
            cmbChildrenAttraction.SelectedIndex = 0;

            //guestRequestKeyTextBox.Text = dr.GuestRequestKey.ToString();
            privateNameTextBox.Text = dr.PrivateName;
            familyNameTextBox.Text = dr.FamilyName;
            mailAddressTextBox.Text = dr.MailAddress;
            statusCheckBox.IsChecked = dr.Status;
            registrationDateDatePicker.SelectedDate = dr.RegistrationDate;
            entryDateDatePicker.SelectedDate = dr.EntryDate;
            releaseDateDatePicker.SelectedDate = dr.ReleaseDate;
            cmbArea.Text = dr.Area.ToString();
            cmbGarden.Text = dr.Garden.ToString();
            cmbChildrenAttraction.Text = dr.ChildrensAttractions.ToString();
            cmbJacuzzi.Text = dr.Jacuzzi.ToString();
            cmbPool.Text = dr.Pool.ToString();
            if(cmbArea.Text == BE.Area.center.ToString())
                cmbSubArea.Text = dr.SubAreaCenter.ToString();
            if (cmbArea.Text == BE.Area.east.ToString())
                cmbSubArea.Text = dr.SubAreaEast.ToString();
            if (cmbArea.Text == BE.Area.north.ToString())
                cmbSubArea.Text = dr.SubAreaNorth.ToString();
            if (cmbArea.Text == BE.Area.south.ToString())
                cmbSubArea.Text = dr.SubAreaSouth.ToString();
            if (cmbArea.Text == BE.Area.west.ToString())
                cmbSubArea.Text = dr.SubAreaWest.ToString();

            cmbType.Text = dr.Type.ToString();
            //cmbSubArea.DisplayMemberPath =
            adultsTextBox.Text = dr.Adults.ToString();
            childrenTextBox.Text = dr.Children.ToString();
            btnAdd.Content = "UPDATE";

            //guestRequestKeyTextBox.IsEnabled = false;
            privateNameTextBox.IsEnabled = false;
            familyNameTextBox.IsEnabled = false;
            mailAddressTextBox.IsEnabled = false;
            registrationDateDatePicker.IsEnabled = false;
            entryDateDatePicker.IsEnabled = false;
            releaseDateDatePicker.IsEnabled = false;
            cmbArea.IsEnabled = false;
            cmbGarden.IsEnabled = false;
            cmbChildrenAttraction.IsEnabled = false;
            cmbJacuzzi.IsEnabled = false;
            cmbPool.IsEnabled = false;
            cmbSubArea.IsEnabled = false;
            cmbType.IsEnabled = false;
            adultsTextBox.IsEnabled = false;
            childrenTextBox.IsEnabled = false;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }

        private void cmbArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbArea.SelectedValue.ToString() == Area.center.ToString())
            {
                cmbSubArea.IsEnabled = true;
                cmbSubArea.ItemsSource = Enum.GetValues(typeof(BE.centerArea));
                cmbSubArea.SelectedIndex = 0;
            }
            if (cmbArea.SelectedValue.ToString() == Area.east.ToString())
            {
                cmbSubArea.IsEnabled = true;
                cmbSubArea.ItemsSource = Enum.GetValues(typeof(BE.eastArea));
                cmbSubArea.SelectedIndex = 0;
            }
            if (cmbArea.SelectedValue.ToString() == Area.north.ToString())
            {
                cmbSubArea.IsEnabled = true;
                cmbSubArea.ItemsSource = Enum.GetValues(typeof(BE.northArea));
                cmbSubArea.SelectedIndex = 0;
            }
            if (cmbArea.SelectedValue.ToString() == Area.south.ToString())
            {
                cmbSubArea.IsEnabled = true;
                cmbSubArea.ItemsSource = Enum.GetValues(typeof(BE.southArea));
                cmbSubArea.SelectedIndex = 0;
            }
            if (cmbArea.SelectedValue.ToString() == Area.west.ToString())
            {
                cmbSubArea.IsEnabled = true;
                cmbSubArea.ItemsSource = Enum.GetValues(typeof(BE.westArea));
                cmbSubArea.SelectedIndex = 0;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            gr = new GuestRequest();
            if (IsFillObject())
            {
                if(btnAdd.Content.ToString() == "ADD")
                    bL.AddClientRequest(gr);
                if (btnAdd.Content.ToString() == "UPDATE")
                {
                  //  gr.GuestRequestKey = Convert.ToInt32(guestRequestKeyTextBox.Text);
                    bL.UpdateRequest(gr);
                }
                    
            }
            this.Close();
        }
        public bool IsFillObject()
        {
            bool valid = true;
            gr.ID = GuestID;//לעשות תקינות??
            gr.Area= (BE.Area)(cmbArea.SelectedValue);
            gr.ChildrensAttractions= (BE.Interest)(cmbChildrenAttraction.SelectedValue);
            gr.Garden= (BE.Interest)(cmbGarden.SelectedValue);
            gr.Jacuzzi= (BE.Interest)(cmbJacuzzi.SelectedValue);
            gr.Pool= (BE.Interest)(cmbPool.SelectedValue);
            gr.Type= (BE.Type)(cmbType.SelectedValue);
            if (gr.Area == BE.Area.center)
                gr.SubAreaCenter = (BE.centerArea)(cmbSubArea.SelectedValue);
            if (gr.Area == BE.Area.east)
                gr.SubAreaEast = (BE.eastArea)(cmbSubArea.SelectedValue);
            if (gr.Area == BE.Area.north)
                gr.SubAreaNorth = (BE.northArea)(cmbSubArea.SelectedValue);
            if (gr.Area == BE.Area.south)
                gr.SubAreaSouth = (BE.southArea)(cmbSubArea.SelectedValue);
            if (gr.Area == BE.Area.west)
                gr.SubAreaWest = (BE.westArea)(cmbSubArea.SelectedValue);
            gr.SubArea = cmbSubArea.SelectedValue.ToString();//לבדוק שזה עובד
            gr.Status = Convert.ToBoolean( statusCheckBox.IsChecked);
            try
            {
                gr.PrivateName = privateNameTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }
            try
            {
                gr.FamilyName = familyNameTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }
            try
            {
                gr.MailAddress = mailAddressTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }
            try
            {
                gr.Adults = Convert.ToInt32(adultsTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }
            try
            {
                gr.Children = Convert.ToInt32(childrenTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }
            try
            {
                gr.EntryDate = Convert.ToDateTime(entryDateDatePicker.SelectedDate.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }
            try
            {
                gr.ReleaseDate = Convert.ToDateTime(releaseDateDatePicker.SelectedDate.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }
            try
            {
                gr.RegistrationDate = Convert.ToDateTime(registrationDateDatePicker.SelectedDate.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valid = false;
            }
            return valid;
        }

        private void cmbGarden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
