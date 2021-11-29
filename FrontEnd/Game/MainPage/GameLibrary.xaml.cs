using Hosam_App.Logic.Controller;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
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

namespace Hosam_App.FrontEnd.Game.MainPage
{
    /// <summary>
    /// GameLibrary.xaml 的互動邏輯
    /// </summary>
    public partial class GameLibrary : Page
    {
        public GameLibrary()
        {
            InitializeComponent();
            DataContext = SideBar.gameViewModel;
        }
        private void SideBarLoad(object sender, RoutedEventArgs e)
        {
            RefreshGameList(0);
        }

        private void RefreshGameList(int sort)
        {
            ActionResult result = GameController.GetGameList(-1, -1, sort);
            List<GameData> data = (List<GameData>)result.data;
            SideBar.gameViewModel.gameList = data;
        }

        private void NavigatToGamePage(object sender, RoutedEventArgs e)
        {
            GameData gameData = ((Button)sender).Tag as GameData;
            NavigationService.Navigate(new GamePage(gameData.id));
        }
    }
}
