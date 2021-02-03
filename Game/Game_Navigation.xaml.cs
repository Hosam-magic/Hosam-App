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

namespace Hosam_App.Game
{
    /// <summary>
    /// Game_Navigation.xaml 的互動邏輯
    /// </summary>
    public partial class Game_Navigation : Page
    {
     public GameCtrl_Page _GameCtrl_Page;
        MainWindow _mainWindow = null;
        Game_List _Game_List;

        public Game_Navigation()
        {
            InitializeComponent();
            if (_Game_List == null) {
                _Game_List = new Game_List(5);
            }
        }

        private void GameLibrary_Click(object sender, RoutedEventArgs e)
        {
            _GameCtrl_Page.ChangePage("Game/Game_Library.xaml");
        }
        /// <summary>
        /// GamelistNumber 不能超過5 ，不然會溢框
        /// </summary>
        private void GameList_Click(object sender, RoutedEventArgs e)
        {
            _GameCtrl_Page.Game_Page.Navigate( _Game_List);

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalChange("Home.xaml");
        }

        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalChange("Game/GameCtrl_Page.xaml");
        }

        private void AdjustButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalChange("Adjust/adjust_Ctrl.xaml");
        }
        void GlobalChange(string Path) {
            _mainWindow = Window.GetWindow(this) as MainWindow;
            this._mainWindow.Main.Navigate(new Uri(Path, UriKind.Relative));
        }
    }
}
