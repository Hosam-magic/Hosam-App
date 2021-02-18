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

namespace Hosam_App.Game.GameIcon
{
    /// <summary>
    /// UserControl1.xaml 的互動邏輯
    /// </summary>
    public partial class Game_ListBar : UserControl
    {
        public static readonly DependencyProperty GameNameProperty = DependencyProperty.Register("GameName", typeof(string), typeof(Game_ListBar));

        public Game_ListBar()
        {
            InitializeComponent();
        }
        public string GameName    //轉換GameName;
        {
            get
            {
                return (string)GetValue(GameNameProperty);
            }
            set
            {
                SetValue(GameNameProperty, value);
            }
        }
    }
}
