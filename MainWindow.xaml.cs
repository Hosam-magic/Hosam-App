using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Web.Script.Serialization;
using System.Windows;
using Hosam_App.Logic.DTO;
using  Hosam_App.Logic.Service;
using  Hosam_App.Logic.Gobal.GobalVariable;



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
            ResizeMode = ResizeMode.NoResize;

        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public void Window_Loaded(Object sender ,RoutedEventArgs e) {
            Trace.WriteLine("AAA");
            
            gobalTimer.AutoReset = true;
            gobalTimer.Interval = 3000;
            gobalTimer.Elapsed += gobalTimer_Elapsed;
            gobalTimer.Start();
        }
        private static void gobalTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //List<GameDetail> gameStartList = getGameStartList();
            //if (gameStartList.Count == 1)
            //{
            //    Trace.WriteLine(gameStartList[0].viewName);
            //    Trace.WriteLine(gameStartList[0].path);
            //    Trace.WriteLine("end");
            //}
            //else if (gameStartList.Count > 1)
            //{
            //    Trace.WriteLine("警告! 偵測起動一款以上的遊戲同時啟動，遊戲名稱如下");
            //    foreach (GameDetail data in gameStartList)
            //    {
            //        Trace.WriteLine(data.viewName);
            //    }
            //}
            //else if (gameStartList.Count ==0 )
            //{
            //    Trace.WriteLine("沒有任何遊戲沒啟動");
            //}

            //SupportGameStatus.supportGamesData = GameDetectService.updateRunningGameStatus();

            //if (SupportGameStatus.supportGamesData.Count == 1) { }


        }

        //public static void addJson()
        //{
        //    SupportGamesDataDTO jsonData = new SupportGamesDataDTO();
        //    GameDetailDTO data = new GameDetailDTO();
        //    data.gameName = "AssetoCorsa";
        //    data.viewName = "AC";

        //    GameDetailDTO data2 = new GameDetailDTO();
        //    data2.gameName = "NeedForSpeed";
        //    data2.viewName = "NF";

        //    List<GameDetailDTO> dataList = new List<GameDetailDTO>();
        //    dataList.Add(data);
        //    dataList.Add(data2);

        //    jsonData.gameList = dataList;

        //    String json = new JavaScriptSerializer().Serialize(jsonData);

        //    System.IO.File.WriteAllText(@"F:\game.txt", json);

        //}
    }
}
