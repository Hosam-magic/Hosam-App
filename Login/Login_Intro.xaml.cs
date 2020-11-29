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

namespace Hosam_App
{
    /// <summary>
    /// Login_Intro.xaml 的互動邏輯
    /// </summary>
    public partial class Login_Intro : Page
    {
        private const string V = "Login/Login_Load.xaml";
        MainWindow _mainWindow =null;
        public Login_Intro()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow = Window.GetWindow(this) as MainWindow;


            this._mainWindow.Main.Navigate(new Uri(V, UriKind.Relative));
        }
    }
}
