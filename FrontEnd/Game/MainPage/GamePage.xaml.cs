using Hosam_App.FrontEnd.Model.Gmae;
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
    /// GamePage.xaml 的互動邏輯
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePageViewModel gamePageViewModel;
        public GamePage(string gameId)
        {
            try
            {
                InitializeComponent();

                GameData gameData = GetGameData(gameId);
                gamePageViewModel = new GamePageViewModel(gameData);
                DataContext = gamePageViewModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(gamePageViewModel.gameName);
        }

        private GameData GetGameData(string id)
        {
            ActionResult result = GameController.GetOneGameDataById(id);
            return (GameData)result.data;
        }
    }
}
