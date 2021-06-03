using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Hosam_App.Logic.Controller;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
using Hosam_App.Logic.Service;

namespace Hosam_App
{
    /// <summary>
    /// Login_Intro.xaml 的互動邏輯
    /// </summary>
    public partial class Login_Intro : Page
    {
         string V = "Login/Login_Load.xaml";
        MainWindow _mainWindow =null;
        public Login_Intro()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow = Window.GetWindow(this) as MainWindow;
            this._mainWindow.Main.Navigate(new Uri(V, UriKind.Relative));

            GameController.Initialize();


        }
    }
}
