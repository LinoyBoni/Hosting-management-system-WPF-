using System;
using System.Collections.Generic;
using System.Data;
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
using BE;
using BL;
namespace UI
{
    /// <summary>
    /// Interaction logic for frmSignIn.xaml
    /// </summary>
    public partial class frmSignIn : Window
    {
        private List<Host> lstHost;
        IBL bL = FactoryBL.GetBL();
        public frmSignIn()
        {
            InitializeComponent();
            lstHost = new List<Host>();
            lstHost = bL.GetHost();
           // txtPass.t = "*";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(host.IsChecked.ToString() == "True")
            {
                foreach(Host st in lstHost)
                    {
                        if (st.Pass == Convert.ToInt32(txtPass.Text))
                        {
                            if (Convert.ToInt32(st.HostKey) == Convert.ToInt32(txtId.Text))
                            {
                                new FormShowHost(st.HostKey).ShowDialog();
                                break;
                            }
                        }  
                        else
                            MessageBox.Show("username or password is invalid", "error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    }
            }
            if (guest.IsChecked.ToString() == "True")
                new formShowGuestRequest(txtId.Text).ShowDialog();
            if(guest.IsChecked.ToString() =="False" && host.IsChecked.ToString()=="False" && manager.IsChecked.ToString() == "False")
                MessageBox.Show("please choose user", "", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void manager_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = "";
            txtPass.Text = "";
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void guest_Checked(object sender, RoutedEventArgs e)
        {
            txtPass.Visibility = Visibility.Hidden;
            labelPass.Visibility = Visibility.Hidden;
        }

        private void host_Checked(object sender, RoutedEventArgs e)
        {
            txtPass.Visibility = Visibility.Visible;
            labelPass.Visibility = Visibility.Visible;
        }
    }
}
