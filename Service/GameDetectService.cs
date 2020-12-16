using Hosam_App.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Hosam_App.Service
{
    public class GameDetectService
    {
        public static List<GameDetail> getGameStartList()
        {
            List<GameDetail> gameStartList = new List<GameDetail>();

            //讀取支援遊戲列表的 txt
            string jsonString = System.IO.File.ReadAllText(@"F:\game.txt");
            SupportGames supportGameData = JsonConvert.DeserializeObject<SupportGames>(jsonString);

            Process[] processlist = Process.GetProcesses();

            bool isNeedUpdate = false;

            //檢查是否執行程序的名稱 = 支援的遊戲名稱 ，如果相同加到 List 中 
            foreach (GameDetail detail in supportGameData.gameList)
            {
                foreach (Process process in processlist)
                {
                    if (process.ProcessName.Contains(detail.gameName))
                    {
            
                        //檢查遊戲路徑不等於執行程序的路徑時進行更新，並標註為需要更新
                        if (detail.path!= process.MainModule.FileName)
                        {
                            detail.path = process.MainModule.FileName;
                            isNeedUpdate = true ;
                        }

                        gameStartList.Add(detail);
                    }
                }
            }

            //如果有資料的更新才寫入txt
            if (isNeedUpdate)
            {
                String json = new JavaScriptSerializer().Serialize(supportGameData);
                System.IO.File.WriteAllText(@"F:\game.txt", json);
            }

            return gameStartList;
        }
    }
}
