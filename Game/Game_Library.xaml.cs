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
    /// Game_Library.xaml 的互動邏輯
    /// </summary>
    public partial class Game_Library : Page
    {
        Game.Game_Carditem[] _game_Carditems;
        Button[] _PageButton;
        int PageDisplayMaxValue = 5;
        int PageNumber=5, CurPage = 0;
        public Game_Library()
        {
            InitializeComponent();
            AutoGen(5);
            _PageButton = new Button[PageNumber];
            autoGenPage(PageNumber);
            DispalyPageButtonNumber();
        }

        void AutoGen(int Number)
        {
            _game_Carditems = new Game_Carditem[Number];

            if (Number > 0 && Number <= PageDisplayMaxValue)
            {

                for (int i = 0; i < PageDisplayMaxValue; i++)
                {
                    RowDefinition _RowDefinition = new RowDefinition();
                    _RowDefinition.Height = new GridLength(1, GridUnitType.Star);
                    Random rnd = new Random();
                    int R = rnd.Next(0, 3);
                    _game_Carditems[i] = new Game_Carditem();
                    Game_Carditem_Bar.RowDefinitions.Add(_RowDefinition);
                    Game_Carditem_Bar.Children.Add(_game_Carditems[i]);
                    _game_Carditems[i].Height = 100;
                    _game_Carditems[i].Width = 718;
                    Console.WriteLine(_game_Carditems[i].ActualWidth);
                    _game_Carditems[i].GameName = "Game" + i.ToString();
                    _game_Carditems[i].State = R;
                    _game_Carditems[i].SetValue(Grid.RowProperty, i);
                    _game_Carditems[i].DataContext = "pack://application:,,,/Game/GameIcon/ProjectCarIcon.jpg";
                }
            }
        }
        void autoGenPage(int page)
        {
            ColumnDefinition[] PageColDef = new ColumnDefinition[page];

            for (int i = 0; i < page; i++)
            {
                PageColDef[i] = new ColumnDefinition();
                PageColDef[i].Width = new GridLength(1, GridUnitType.Star);
                PageBtn.ColumnDefinitions.Add(PageColDef[i]);
                _PageButton[i] = new Button();
                PageBtn.Children.Add(_PageButton[i]);
                _PageButton[i].Name = "_PageButton" + i.ToString();
                _PageButton[i].Content = i.ToString();
                _PageButton[i].SetValue(Grid.ColumnProperty, i);
                _PageButton[i].Width = 45;
                _PageButton[i].Height = 45;
                _PageButton[i].HorizontalAlignment = HorizontalAlignment.Center;
                _PageButton[i].VerticalAlignment = VerticalAlignment.Center;
                _PageButton[i].Background = null;
                _PageButton[i].BorderBrush = null;
                _PageButton[i].Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                _PageButton[i].FontSize = 20;
                _PageButton[i].Click += PageBtnEvent;
            }
        }
        private void PageBtnEvent(object sender, RoutedEventArgs e)
        {
            CurPage = int.Parse(((Button)sender).Content.ToString());
            DispalyPageButtonNumber();
        }
        void DispalyPageButtonNumber()
        {
            for (int i = 0; i < PageNumber; i++)
            {
                if (CurPage == i)
                {
                    _PageButton[CurPage].Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    _PageButton[CurPage].FontSize = 25;
                }
                else if (CurPage != i)
                {
                    _PageButton[i].Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    _PageButton[i].FontSize = 20;
                }
            }
        }
    }
    }
