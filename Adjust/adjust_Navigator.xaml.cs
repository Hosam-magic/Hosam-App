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

namespace Hosam_App.Adjust
{
    /// <summary>
    /// adjust_Navigator.xaml 的互動邏輯
    /// </summary>
    public partial class adjust_Navigator : Page
    {
        MainWindow _mainWindow = null;
        Button[] MemeorySlotBtn;
        Button addbutton;
        int RowDef, MaxSlotNumer = 5;
        public adjust_Ctrl _adjust_Ctrl;
        adjust_Page _adjust_Page;
        
        public adjust_Navigator()
        {
            InitializeComponent();
            RowDef = 3;
            MemeorySlotBtn = new Button[MaxSlotNumer];


            Generator();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalChange("Home.xaml");
        }
        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalChange("Game/GameCtrl_Page.xaml");
        }
        private void AdjustButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalChange("Adjust/adjust_Ctrl.xaml");
        }
        void GlobalChange(string Path)
        {
            _mainWindow = Window.GetWindow(this) as MainWindow;
            this._mainWindow.Main.Navigate(new Uri(Path, UriKind.Relative));
        }
        void Generator()
        {
            RowDefinition[] _rowDefinition = new RowDefinition[RowDef + 1];
            for (int i = 0; i <= RowDef; i++)
            {
                _rowDefinition[i] = new RowDefinition();
                _rowDefinition[i].Height = new GridLength(1, GridUnitType.Star);
                MemeorySlot.RowDefinitions.Add(_rowDefinition[i]);
                if (i < RowDef) // 4
                {
                    MemeorySlotBtn[i] = new Button();
                    MemeorySlotBtn[i].SetValue(Grid.RowProperty, i);
                    MemeorySlot.Children.Add(MemeorySlotBtn[i]);
                    MemeorySlotBtn[i].Name = "MemeorySlotbtn" + i;   //未來更改名字保留 (json)
                    MemeorySlotBtn[i].Background = null;
                    MemeorySlotBtn[i].BorderBrush = null;
                    MemeorySlotBtn[i].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    MemeorySlotBtn[i].Content = "MemeorySlot " + i;
                    MemeorySlotBtn[i].Click += Slot_Click;
                }
                else if (i == RowDef)
                {
                    addbutton = new Button();
                    addbutton.SetValue(Grid.RowProperty, i);
                    MemeorySlot.Children.Add(addbutton);
                    addbutton.Name = "add";
                    addbutton.Background = null;
                    addbutton.BorderBrush = null;
                    addbutton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    addbutton.Content = "add ";
                    addbutton.Click += Add_Slot_Click;
                }
            }
        }
        void Add_Slot_Click(object sender, RoutedEventArgs e)
        {
            if (RowDef < MaxSlotNumer)
            {
                RowDefinition _addrowDefinition = new RowDefinition();
                _addrowDefinition.Height = new GridLength(1, GridUnitType.Star);
                MemeorySlot.RowDefinitions.Add(_addrowDefinition);
                addbutton.SetValue(Grid.RowProperty, RowDef + 1);
                MemeorySlotBtn[RowDef] = new Button();
                MemeorySlotBtn[RowDef].SetValue(Grid.RowProperty, RowDef);
                MemeorySlot.Children.Add(MemeorySlotBtn[RowDef]);
                MemeorySlotBtn[RowDef].Name = "MemeorySlotbtn" + RowDef;
                MemeorySlotBtn[RowDef].Background = null;
                MemeorySlotBtn[RowDef].BorderBrush = null;
                MemeorySlotBtn[RowDef].Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                MemeorySlotBtn[RowDef].Content = "MemeorySlot" + RowDef;
                MemeorySlotBtn[RowDef].Click += Slot_Click;
                RowDef++;
                Console.WriteLine(RowDef);
            }
        }
        void Slot_Click(object sender, RoutedEventArgs e)
        {
            Button _button = (Button)sender;
            string R = _button.Content.ToString();
            if (_adjust_Page == null)
            {
                _adjust_Page = _adjust_Ctrl._adjust_Page;
                switch (R)
                {
                    case "MemeorySlot 0":
                        _adjust_Page.ReflashThePage("hello", 12, 51, 19);
                        break;
                    case "MemeorySlot 1":
                        _adjust_Page.ReflashThePage("fffwfwfwfff", 18, 98, 6);
                        break;
                    case "MemeorySlot 2":
                        _adjust_Page.ReflashThePage("asdaf", 20, 70, 87);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                _adjust_Page = _adjust_Ctrl._adjust_Page;
                switch (R)
                {
                    case "MemeorySlot 0":
                        _adjust_Page.ReflashThePage("hello", 12, 51, 19);
                        break;
                    case "MemeorySlot 1":
                        _adjust_Page.ReflashThePage("fffwfwfwfff", 18, 98, 6);
                        break;
                    case "MemeorySlot 2":
                        _adjust_Page.ReflashThePage("asdaf", 20, 70, 87);
                        break;
                    default:
                        break;
                }
            }
        }
   
    }
}
