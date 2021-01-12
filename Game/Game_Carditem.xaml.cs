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
using System.Threading;
using System.Windows.Threading;
using System.ComponentModel;

namespace Hosam_App.Game
{
    /// <summary>
    /// Game_Carditem.xaml 的互動邏輯
    /// </summary>
    public partial class Game_Carditem : UserControl
    {
        //註冊 Carditem 的GameName  
        public static readonly DependencyProperty GameNameProperty = DependencyProperty.Register("GameName", typeof(string), typeof(Game_Carditem));

        // State 0 = available  1 = Need upgraded 2 = Disatable
        public static readonly DependencyProperty GameStatesProperty = DependencyProperty.Register("GameStates", typeof(int), typeof(Game_Carditem),new UIPropertyMetadata(default(int)));


        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.2) };

        int _GameStates;
        public Game_Carditem()
        {
            InitializeComponent();
            timer.Tick+= ButtonStates;
            timer.Start();
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
        
        public int GameStates //轉換GameStates
        {            
            get
            {
                return (int)GetValue(GameNameProperty);
            }
            set
            {
                SetValue(GameNameProperty, value);
            }
        }void ButtonStates(object sender, EventArgs e) {   //ButtonStates           
            switch (_GameStates)
            {
                case 0:
                  GameBton.Background = new SolidColorBrush(Color.FromArgb(255, 20, 204, 0));
                   GameText.Text = "Play";
                    break;
                case 1:
                   GameBton.Background = new SolidColorBrush(Color.FromArgb(255, 241, 143 , 1));
                    GameText.Text = "Upgraded";
                    break;

                case 2:
                    GameBton.Background = new SolidColorBrush(Color.FromArgb(255, 242, 27, 63));
                    GameBton.IsEnabled =false;
                   GameText.Text = "disatable";
                    break;
                default:
                    _GameStates = 0;
                    break;
            }
        }
    }

}
