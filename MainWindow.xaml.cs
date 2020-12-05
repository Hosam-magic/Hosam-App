using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using Hosam_App.DTO;
using Newtonsoft.Json;


namespace Hosam_App
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isGameStart = false;
        public static Timer gobalTimer;

        public MainWindow()
        {
            InitializeComponent();
        }
        public void MainFromLoad() {

            gobalTimer.AutoReset = true;
            gobalTimer.Interval = 3000;
            gobalTimer.Elapsed += gobalTimer_Elapsed;
        }
        private static void gobalTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            searchGame();
        }
        public static void searchGame() {

            if (!isGameStart)
            {
                string jsonString = System.IO.File.ReadAllText("");
                SupportGamesData data = JsonConvert.DeserializeObject<SupportGamesData>(jsonString);
           
                Console.WriteLine();
                Process[] processlist = Process.GetProcesses();
            }
           
        }

    }
}
