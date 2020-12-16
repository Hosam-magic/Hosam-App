using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Web.Script.Serialization;
using System.Windows;
using Hosam_App.DTO;
using static Hosam_App.Service.GameDetectService;
using Newtonsoft.Json;



namespace Hosam_App
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isGameStart = false;
        public static Timer gobalTimer = new Timer();

        public MainWindow()
        {
            InitializeComponent();
        }
        public void Window_Loaded(Object sender ,RoutedEventArgs e) {
            Trace.WriteLine("AAA");
            
            gobalTimer.AutoReset = true;
            gobalTimer.Interval = 500;
            gobalTimer.Elapsed += gobalTimer_Elapsed;
            gobalTimer.Start();
        }
        private static void gobalTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            List<GameDetail> a = getGameStartList();
            if (a.Count == 0)
            {
                Trace.WriteLine("遊戲沒啟動");
            }
            else
            {
                Trace.WriteLine(a[0].viewName);
                Trace.WriteLine(a[0].path);
                Trace.WriteLine("end");
            }
 
        }

        public static void addJson()
        {
            SupportGames jsonData = new SupportGames();
            GameDetail data = new GameDetail();
            data.gameName = "AssetoCorsa";
            data.viewName = "AC";

            GameDetail data2 = new GameDetail();
            data2.gameName = "NeedForSpeed";
            data2.viewName = "NF";

            List<GameDetail> dataList = new List<GameDetail>();
            dataList.Add(data);
            dataList.Add(data2);

            jsonData.gameList = dataList;

            String json = new JavaScriptSerializer().Serialize(jsonData);

            System.IO.File.WriteAllText(@"F:\game.txt",json);

        }
    }
}
