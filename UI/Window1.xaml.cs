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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new frmHostingUnit().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new frmGuestRequest().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new frmOrder().ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new formShowGuestRequest().ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new FormShowHost().ShowDialog();
        }
    }
}
