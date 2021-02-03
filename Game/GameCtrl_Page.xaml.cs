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
    /// GameCtrl_Page.xaml 的互動邏輯
    /// </summary>
    public partial class GameCtrl_Page : Page
    {
        public Game_Navigation _game_Navigation;
        public Game_Library _game_Library;

        GameCtrl_Page _thispage;
        public GameCtrl_Page()
        {
            InitializeComponent();
            _thispage = this;
            if (_game_Navigation == null)
            {
                _game_Navigation = new Game.Game_Navigation();
            }
             if (_game_Library == null) {

                _game_Library = new Game.Game_Library();
            }
            _game_Navigation._GameCtrl_Page = _thispage;
            Game_Navigation.Navigate(_game_Navigation);
            Game_Page.Navigate(_game_Library);
        }            /// <summary>
                     /// 請輸入你想要更改的頁面位置
                     /// </summary>
        public void ChangePage(string Path) {
            try
            {
                Game_Page.Navigate(new Uri(Path, UriKind.Relative));
            }
            catch { 
            
            
            
            }
        }
    }
}
