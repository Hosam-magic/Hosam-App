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
        }
        private void SideBarLoad(object sender, RoutedEventArgs e)
        {
            RefreshFavoriteList(0);
        }

        private void RefreshFavoriteList(int sort)
        {
            ActionResult result = GameController.GetData(null, -1, -1, sort);
            List<GameData> data = (List<GameData>)result.data;
            GameList.ItemsSource = data;
        }
    }
}
