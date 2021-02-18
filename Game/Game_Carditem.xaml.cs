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
        int State = 0;

        public Game_Carditem()
        {
            InitializeComponent();
            ButtonStates();
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
        
       void ButtonStates() {   //ButtonStates           
            switch (State) {
                case 0:
                    VisualStateManager.GoToState(this, "Play", true);
                    break;
                case 1:
                    VisualStateManager.GoToState(this, "Update", true);
                    break;
                case 2:
                    VisualStateManager.GoToState(this, "disabled", true);
                    break;
                default:
                    VisualStateManager.GoToState(this, "Play", true);
                    break;
            }
        }

        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            if (State > 2)
            {
                State = 0;
            }
            else {
                State++;
            }
            ButtonStates();
        }
    }

}
