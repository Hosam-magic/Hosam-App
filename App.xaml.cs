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
        static Timer gobalTimer = new Timer(2000);
        
        void App_Startup(object sender, StartupEventArgs e)
        {
            //定時執行更新
            gobalTimer.Start();
            gobalTimer.Elapsed += GobalTimerEvent;

        }

        void GobalTimerEvent(object sender, ElapsedEventArgs e)
        {
            GameDetectController.Update();
            List<GameData> data = (List<GameData>)GameDetectController.GetData(null).data;
        }
    }
}
