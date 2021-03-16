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
    /// GameCtrl_List.xaml 的互動邏輯
    /// </summary>
    public partial class Game_List : Page
    {
        Button[] _PageButton;
        int CurPage, PageNumber;
        public Game_List(int i)
        {
            PageNumber = 10;
            CurPage = 0;
            InitializeComponent();
            _PageButton = new Button[PageNumber];
            PageGenerator();
            if (i != 0)
            {
                InsertListGridRow(i);
            }
        }   
         /// <summary>
         /// ListBar 的自動展開邏輯
         /// </summary>
        void InsertListGridRow(int ButtonNumber)
        {
            if (ButtonNumber > 0)
            {
                RowDefinition[] Rows = new RowDefinition[ButtonNumber];
                for (int i = 0; i < ButtonNumber; i++)
                {
                    GameIcon.Game_ListBar _Game_ListBar = new GameIcon.Game_ListBar();
                    Rows[i] = new RowDefinition();
                    Rows[i].Height = new GridLength(1, GridUnitType.Star);
                    MainGrid.RowDefinitions.Add(Rows[i]);
                    _Game_ListBar.SetValue(Grid.RowProperty, i);
                    _Game_ListBar.HorizontalAlignment = HorizontalAlignment.Center;
                    _Game_ListBar.VerticalAlignment = VerticalAlignment.Center;
                    string Name = "Name" + i.ToString();
                    _Game_ListBar.GameName = Name;
                    MainGrid.Children.Add(_Game_ListBar);
                    _Game_ListBar.Height = 98;
                    _Game_ListBar.Width = 718;
                }
            }
        }  
         /// <summary>
         /// 頁面切換按鈕展開 
         /// </summary>
        void PageGenerator()
        {
            ColumnDefinition[] PageColDef = new ColumnDefinition[PageNumber];
            for (int i = 0; i < PageNumber; i++)
            {                
                PageColDef[i] = new ColumnDefinition();
                PageColDef[i].Width = new GridLength(1, GridUnitType.Star);
                PageChangeGrid.ColumnDefinitions.Add(PageColDef[i]);
                _PageButton[i] = new Button();
                PageChangeGrid.Children.Add(_PageButton[i]);
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
                if (i == PageNumber)
                {
                }
            }
            DispalyPageButtonNumber();
        }
        
         /// <summary>
         /// 換頁按鈕事件
         /// </summary>
        private void PageBtnEvent(object sender, RoutedEventArgs e)
        {
            CurPage = int.Parse(((Button)sender).Content.ToString());
            DispalyPageButtonNumber();
        }

        /// <summary>
        /// 換頁button的控制邏輯
        /// </summary>
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
