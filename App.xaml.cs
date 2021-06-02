using System;
using System.Collections.Generic;
using System.Windows;
using Hosam_App.Logic.Controller;
using System.Timers;
using Hosam_App.Logic.Entity;
using Hosam_App.Logic.Repository;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Service;

namespace Hosam_App
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        static Timer gobalTimer = new Timer(500);
        
        void App_Startup(object sender, StartupEventArgs e)
        {
            DataBaseController.CheckDataComplete();
            GameController.Initialize();

            //定時執行更新
            gobalTimer.Start();
            gobalTimer.Elapsed += GobalTimerEvent;

            //測試區
            ActionResult a = GameController.GetData("21df46a5-d5bc-46cf-94ff-183264a321d5");
            Console.WriteLine();
        }

        void App_Close(object sender, ExitEventArgs e)
        {
            gobalTimer.Elapsed -= GobalTimerEvent;
        }

        void GobalTimerEvent(object sender, ElapsedEventArgs e)
        {
            GameController.UpdateGameStatus();

        }
    }
}
