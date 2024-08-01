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

namespace UI
{
    /// <summary>
    /// Interaction logic for FormShowHost.xaml
    /// </summary>
    public partial class FormShowHost : Window
    {
        public FormShowHost()
        {
            InitializeComponent();
        }
        public FormShowHost(string name)
        {
            InitializeComponent();
            wel.Content = "Welcome " + name;
            label.Content = DateTime.Now.ToString();
        }

        private void HostingUnits_Click(object sender, RoutedEventArgs e)
        {
            new frmHostingUnit().ShowDialog();
        }

        private void btnRequest_MouseEnter(object sender, MouseEventArgs e)
        {
            //
        }

        private void btnRequest_Click_1(object sender, RoutedEventArgs e)
        {
            new frmGuestRequest().ShowDialog();
        }
        private void Btnorder_Click_1(object sender, RoutedEventArgs e)
        {
            new frmOrder().ShowDialog();
        }
    }
}
