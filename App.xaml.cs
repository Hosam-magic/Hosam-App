using System;
using System.Collections.Generic;
using System.Windows;
using Hosam_App.Logic.Controller;
using System.Timers;
using Hosam_App.Logic.DTO;
using System.IO;
using System.Data.SQLite;
using System.Configuration;
using Hosam_App.Logic.Service.Base;
using Hosam_App.Logic.Entity;

namespace Hosam_App
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        static Timer gobalTimer = new Timer(2000);
        
        void App_Startup(object sender, StartupEventArgs e)
        {

            //定時執行更新
            gobalTimer.Start();
            gobalTimer.Elapsed += GobalTimerEvent;

            //ActionResult result = GameDetectController.runGame("E:\\軟體\\WeChat\\WeChat.exe");
            
            //Console.WriteLine(result.erroroMsg);
            //Console.WriteLine(result.erroroMsg);
            //Console.WriteLine(result.erroroMsg);

        }





        void GobalTimerEvent(object sender, ElapsedEventArgs e)
        {
            GameDetectController.Update();
            List<GameData> data = (List<GameData>)GameDetectController.GetData(null).data;
            //Console.WriteLine(data[0].lastRunTime);
            //Console.WriteLine(data[0].isRunning);
        }
    }
}
