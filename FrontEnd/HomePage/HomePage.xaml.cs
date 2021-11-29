using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Hosam_App.Logic.Controller;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
using Hosam_App.Logic.Service;

namespace Hosam_App.FrontEnd.HomePage
{
    /// <summary>
    /// HomePage.xaml 的互動邏輯
    /// </summary>
    public partial class HomePage : Page
    {
        public static GameData lastRunGame;

        public HomePage()
        {
            InitializeComponent();
        }
        private void HomePageLoad(object sender, RoutedEventArgs e)
        {
            try
            {
                //補上如果沒有最後一個執行遊戲的狀況

                //查找最後一次執行的遊戲
                ActionResult result = GameController.GetGameList(-1,-1, 1);
                List<GameData> data = (List<GameData>)result.data;
                lastRunGame = data[0];

                //將最後一個遊戲的圖片替換上去
                //必須要 ToString ，否則會找不到路徑
                string imageName = lastRunGame.gameName.ToString();
                ImageBrush b = new ImageBrush();

                b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/HomePage/" + imageName + ".jpg"));
                LastRunGameGrid.Background = b;
            }
            catch (IOException iox)
            {
                if (iox.Message.Contains("resources"))
                {
                    MessageBox.Show("顯示圖片失敗，圖片路徑毀損");
                }
                else
                {
                    MessageBox.Show("不明錯誤，詳細請查詢Log檔");
                    LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name + "\r\n" + iox.GetType() + "\r\n" + iox.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("不明錯誤，詳細請查詢Log檔");
                LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name + "\r\n" + ex.GetType() + "\r\n" + ex.Message);
            }


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com.tw/");
        }

        private void RunGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(lastRunGame.path))
            {
                GameController.RunGame(lastRunGame.path);
            }
            
        }
    }
}
