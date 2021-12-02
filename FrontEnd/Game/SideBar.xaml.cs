using Hosam_App.FrontEnd.Game.MainPage;
using Hosam_App.FrontEnd.Model.Gmae;
using Hosam_App.Logic.Controller;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Hosam_App.FrontEnd.Game
{
    /// <summary>
    /// SideBar.xaml 的互動邏輯
    /// </summary>
    public partial class SideBar : Page
    {
        public static GameViewModel gameViewModel;
        static Timer reflshTimer = new Timer(3000);

        public SideBar()
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            // 用xname 取得frame :
            gameViewModel = new GameViewModel ();
            InitializeComponent();
            DataContext = gameViewModel;
        }
        private void SideBarLoad(object sender, RoutedEventArgs e)
        {
            //刷新[我的最愛]清單
            RefreshFavoriteList(0);

            //起動左下角刷新的Timer
            reflshTimer.Elapsed += ReflashTimerEvent;
            reflshTimer.Start();

            //設定右側顯示的class
            sideBarFrame.NavigationService.Navigate(new GameLibrary());
        }

        private void SortChange(object sender, RoutedEventArgs e)
        {
            //更改排序的方式
            if (gameViewModel.favoriteSort == 0)
            {
                gameViewModel.sortIcon = PackIconKind.SortClockAscendingOutline;
                gameViewModel.favoriteSort = 1;
            }
            else if (gameViewModel.favoriteSort == 1)
            {
                gameViewModel.sortIcon = PackIconKind.SortAlphabeticalAscending;
                gameViewModel.favoriteSort = 0;
            }

            RefreshFavoriteList(gameViewModel.favoriteSort);
        }
        void FavoriteSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            GameData gameData = (GameData)FavoriteList.SelectedItem;
            sideBarFrame.NavigationService.Navigate(new GamePage(gameData.id));
        }

        private void RefreshFavoriteList(int sort)
        {
            ActionResult result = GameController.GetGameList(1, -1, sort);
            List<GameData> data = (List<GameData>)result.data;
            gameViewModel.favoriteGameList = data;
        }

        void ReflashTimerEvent(object sender, ElapsedEventArgs e)
        {
            ActionResult result = GameController.GetGameList(-1, 1, 0);
            List<GameData> dataList = (List<GameData>)result.data;

            try
            {
                if (dataList.Count == 0)
                {
                    gameViewModel.playGameName = null;
                    gameViewModel.isPlayingVisible = false;
                }

                else if (dataList.Count == 1)
                {
                    gameViewModel.isPlayingVisible = true;
                    gameViewModel.playGameName = dataList[0].gameName;
                }
                else if (dataList.Count > 1)
                {
                    gameViewModel.isPlayingVisible = false;
                    gameViewModel.playGameName = null;

                    MessageBox.Show("錯誤!執行兩個以上的遊戲");
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine("AAA");
                Console.WriteLine(ee.Message);
            }


        }


    }
}
