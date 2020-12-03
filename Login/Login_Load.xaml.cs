using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Threading;
using System.Windows.Threading;

namespace Hosam_App
{
    /// <summary>
    /// Login_Load.xaml 的互動邏輯
    /// </summary>
    public partial class Login_Load : Page
    {
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.2) };
        int sec = 0;

        MainWindow _mainWindow;
        public Login_Load()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }private void timer_Tick(object sender, EventArgs e) {
            float dispalyNumber = 0;
            dispalyNumber = sec *10;
            if (sec < 10)
            {
                sec++;
                LoadingNumber.Text = " " +dispalyNumber.ToString()+"%";
                _mainWindow = Window.GetWindow(this) as MainWindow;

            }
            else {
                _mainWindow.Width = 1200;
                _mainWindow.Height = 900;
                _mainWindow.viewbox.Width = 1200;
                
                _mainWindow.Main.Width = 1200;
                _mainWindow.Main.Height = 900;
                this._mainWindow.Main.Navigate(new Uri("Home.xaml", UriKind.Relative));
            }
        }
    }
}
