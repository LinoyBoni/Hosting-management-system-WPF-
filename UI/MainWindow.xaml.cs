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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Diagnostics;
namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"E:\23.1\Project01_0824_3173_dotNet5780\UI\bin\Debug\music.wav");
        bool soundFlag = true;
        Random rnd = new Random();
        string[] arr = new string[4];
        //----------------progressBar---------------------------
        BackgroundWorker worker;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
             //player.PlayLooping();

            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            arr[0] = "please wait...!";
            arr[1] = "few minutes....";
            arr[2] = "loading tsimmer site manegement system...";
            arr[3] = "almost there...";
            if (worker.IsBusy != true)
            {
                worker.RunWorkerAsync(12);
            }
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // BackgroundWorker worker = sender as BackgroundWorker;

            int length = (int)e.Argument;

            for (int i = 1; i <= length; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    e.Result = stopwatch.ElapsedMilliseconds; // Unnecessary
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(i * 100 / length);
                }
            }

            e.Result = stopwatch.ElapsedMilliseconds;
        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelMessege.Content = arr[rnd.Next(0, 4)];
            int progress = e.ProgressPercentage;
            resultLabel.Content = (progress + "%");
            resultProgressBar.Value = progress;
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                // e.Result throw System.InvalidOperationException
                resultLabel.Content = "Canceled!";
            }
            else if (e.Error != null)
            {
                // e.Result throw System.Reflection.TargetInvocationException
                resultLabel.Content = "Error: " + e.Error.Message; // Exception Message
            }
            else
            {
                if (resultProgressBar.Value == 100)
                {
                    labelMessege.Content = "Done!";
                    //resultLabel.Content = "100%";
                   // System.Threading.Thread.Sleep(6000);
                    new frmSignIn().ShowDialog();

                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new frmHostingUnit().ShowDialog();
        }

        private void btnAddGuestRequest_Click(object sender, RoutedEventArgs e)
        {
            new frmGuestRequest().ShowDialog();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            new frmOrder().ShowDialog();
        }
        private void Pause_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (soundFlag) //music is being playing
            {
                player.Stop();
                pause.Source = new ImageSourceConverter().ConvertFromString(@"E:\23.1\Project01_0824_3173_dotNet5780\UI\images\play.jpg") as ImageSource;
                
                soundFlag = false;
            }
            else //music is not being playing
            {
                player.PlayLooping();
                pause.Source = new ImageSourceConverter().ConvertFromString(@"E:\23.1\Project01_0824_3173_dotNet5780\UI\images\pause.jpg") as ImageSource;
                soundFlag = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new formShowGuestRequest().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new FormShowHost().ShowDialog();
        }
    }
}