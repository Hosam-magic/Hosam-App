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

namespace Hosam_App.FrontEnd.Game
{
    /// <summary>
    /// SideBar.xaml 的互動邏輯
    /// </summary>
    public partial class SideBar : Page
    {
        static int sort = 0;
        public SideBar()
        {
            InitializeComponent();
        }
        private void SideBarLoad(object sender, RoutedEventArgs e)
        {
            RefreshFavoriteList(sort);
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
            ActionResult result = GameController.GetData(null, sort);
            List<GameData> data = (List<GameData>)result.data;
            SideGameList.ItemsSource = data;
        }

    }
}
