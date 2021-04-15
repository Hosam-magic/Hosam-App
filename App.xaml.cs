using System;
using System.Collections.Generic;
using System.Windows;
using Hosam_App.Logic.Controller;
using System.Timers;
using Hosam_App.Logic.Entity;
using Hosam_App.Logic.Repository;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Service;
using Hosam_App.Logic.Gobal;
using System.IO;

namespace Hosam_App
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        static Timer gobalTimer = new Timer(100);
        
        void App_Startup(object sender, StartupEventArgs e)
        {
            DataBaseService.CheckDataComplete();

            //定時執行更新
            gobalTimer.Start();
            gobalTimer.Elapsed += GobalTimerEvent;
        }

        void App_Close(object sender, EventArgs e)
        {
            GameDetectService.Close();
        }

        void GobalTimerEvent(object sender, ElapsedEventArgs e)
        {
            GameDetectController.Update();
            //List<GameData> data = (List<GameData>)GameDetectController.GetData(null).data;
            Console.WriteLine(PhsicalData.x);

        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }
    }
}
