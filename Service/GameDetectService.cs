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

             List<Process> processlist = Process.GetProcesses().ToList();

            bool isNeedUpdate = false;

            //檢查是否執行程序的名稱 = 支援的遊戲名稱 ，如果相同加到 List 中 
            foreach (GameDetail detail in supportGameData.gameList)
            {
                var findedProcess = processlist.Find(x => x.ProcessName.Contains(detail.gameName));

                if (findedProcess != null)
                {
                    //檢查起動列表內是否已經有同樣的APP，避免重複加入 (ex AC一次就啟動兩個 AssetoCorsa.exe)
                    if (!gameStartList.Exists (x =>x.gameName == findedProcess.ProcessName))
                    {
                        //檢查遊戲路徑不等於執行程序的路徑時進行更新，並標註為需要更新
                        if (detail.path != findedProcess.MainModule.FileName)
                        {
                            detail.path = findedProcess.MainModule.FileName;
                            isNeedUpdate = true;
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
