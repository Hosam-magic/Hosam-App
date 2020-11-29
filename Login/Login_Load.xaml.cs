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

namespace Hosam_App
{
    /// <summary>
    /// Login_Load.xaml 的互動邏輯
    /// </summary>
    public partial class Login_Load : Page
    {
        MainWindow _mainWindow = null;
        public Login_Load()
        {
            InitializeComponent();
        }IEnumerator Cunting() {
            
             _mainWindow = Window.GetWindow(this) as MainWindow;
            _mainWindow.Width = 1200;
            this._mainWindow.Main.Navigate(new Uri("", UriKind.Relative));
            yield return null;
        }
    }
}
