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
using System.Threading;


namespace Hosam_App
{
    /// <summary>
    /// Home.xaml 的互動邏輯
    /// </summary>
    public partial class Home : Page
    {
        MainWindow _mainWindow =null;
        public Home()
        {
            InitializeComponent();
        }


        private void PopupBox_OnClosed(object sender, RoutedEventArgs e)
        {

        }

        private void PopupBox_OnOpened(object sender, RoutedEventArgs e)
        {

        }

        private void Adjust_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow = Window.GetWindow(this) as MainWindow;
           
            this._mainWindow.Main.Navigate(new Uri("Adjust/adjust_Ctrl.xaml", UriKind.Relative));
        }

        private void Game_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            _mainWindow = Window.GetWindow(this) as MainWindow;

            this._mainWindow.Main.Navigate(new Uri("Game/GameCtrl_Page.xaml", UriKind.Relative));
        }
    }
}
