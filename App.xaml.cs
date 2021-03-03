using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Hosam_App.Logic.Gobal.GobalVariable;
using Hosam_App.Logic.Service;
using Hosam_App.ErrorCode;
using Hosam_App.Logic.Controller;
using System.Timers;
using Hosam_App.Logic.DTO;

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
            GameDetectController.Start();
            gobalTimer.Start();
            gobalTimer.Elapsed += GobalTimerEvent;
        }

        void App_Close(object sender, EventArgs e)
        {
            GameDetectController.Close();
        }

        void GobalTimerEvent(object sender, ElapsedEventArgs e)
        {
            GameDetectController.Update();
            List<RunningGameDTO> data = (List<RunningGameDTO>)GameDetectController.GetData().data;
            //Console.WriteLine(data[1].lastRunTime);
            //Console.WriteLine(data[1].isRunning);
        }
    }
}
