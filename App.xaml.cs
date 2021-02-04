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

namespace Hosam_App
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        GameDetectService gameDetectService = new GameDetectService();

        void App_Startup(object sender, StartupEventArgs e)
        {

            //GameDetectService.InitGamedataTxt();
            //Console.WriteLine("fsaddfsdfsadfsdfs");
            //GameDetectService.InitGamedataVariable();
            //Trace.WriteLine(GameStatus.GameStatusList[0].gameName);
            //GameStatus.GameStatusList[0].gameName = "abc";
            //Trace.WriteLine(GameStatus.GameStatusList[0].gameName);

           

        }
    }
}
