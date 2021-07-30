using System;
using System.Windows;
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
        static Timer gobalTimer = new Timer(1000);
        static Timer testTimer = new Timer(10);

        void App_Startup(object sender, StartupEventArgs e)
        {
            DataBaseController.CheckDataComplete();
            GameController.Initialize();

            //定時執行更新
            gobalTimer.Start();
            //testTimer.Start();
            gobalTimer.Elapsed += GobalTimerEvent;
            //testTimer.Elapsed += TestTimerEvent;

            //測試區

        }

        void App_Close(object sender, ExitEventArgs e)
        {
            gobalTimer.Elapsed -= GobalTimerEvent;
        }
        void GobalTimerEvent(object sender, ElapsedEventArgs e)
        {
            GameController.UpdateGameStatus();
        }
        void TestTimerEvent(object sender, ElapsedEventArgs e)
        {

            ActionResult result = DataReaderController.GetPhsycalData();

            PhsycalData data = (PhsycalData)result.data;

            if (!result.scucess)
            {
                Console.WriteLine(result.erroroMsg);
            }

            Console.WriteLine(data.x);

        }
    }
}
