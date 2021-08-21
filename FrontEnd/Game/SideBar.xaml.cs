using Hosam_App.Logic.Controller;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hosam_App.FrontEnd.Game
{
    /// <summary>
    /// SideBar.xaml 的互動邏輯
    /// </summary>
    public partial class SideBar : Page
    {
        GameViewModel gameViewModel ;
        static int sort = 0;
        static Timer reflshTimer = new Timer(3000);
        public SideBar()
        {
            
            gameViewModel  = new GameViewModel { IsPlayingVisible = false, PlayGameName = "AAA" };
            InitializeComponent();
            DataContext = gameViewModel;
        }
        private void SideBarLoad(object sender, RoutedEventArgs e)
        {
            //刷新[我的最愛]清單
            RefreshFavoriteList(sort);

            //起動左下角刷新的Timer
            reflshTimer.Elapsed += ReflashTimerEvent;
            reflshTimer.Start();
        }
        private void SortChange(object sender, RoutedEventArgs e)
        {
            int oldsort = sort;
            //更改排序的方式
            if (oldsort == 0)
            {
                SideBarSortButton2.Kind = MaterialDesignThemes.Wpf.PackIconKind.SortClockAscendingOutline;
                sort = 1;               
            }
            if (oldsort == 1)
            {
                SideBarSortButton2.Kind = MaterialDesignThemes.Wpf.PackIconKind.SortAlphabeticalAscending;
                sort = 0;
            }

            RefreshFavoriteList(sort);
        }

        private void RefreshFavoriteList(int sort)
        {
            ActionResult result = GameController.GetData(null,1,-1, sort);
            List<GameData> data = (List<GameData>)result.data;
            SideGameList.ItemsSource = data;
        }

        void ReflashTimerEvent(object sender, ElapsedEventArgs e)
        {
            ActionResult result = GameController.GetData(null, -1, 1, 0);
            List<GameData> dataList = (List<GameData>)result.data;

            try
            {

                if (dataList.Count == 0)
                {
                    gameViewModel.PlayGameName = null;
                    gameViewModel.IsPlayingVisible = false;
                }

                if (dataList.Count == 1)
                {
                    gameViewModel.IsPlayingVisible = true;
                    gameViewModel.PlayGameName = dataList[0].gameName;
                }
                if (dataList.Count > 1)
                {
                    gameViewModel.IsPlayingVisible = false;
                    gameViewModel.PlayGameName = null;

                    MessageBox.Show("錯誤!執行兩個以上的遊戲");
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }


        }


}
