using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Gobal.GobalVariable;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;
using System.IO;
using Hosam_App.Logic.Gobal.DefaultValue;
using Hosam_App.ErrorCode;

namespace Hosam_App.Logic.Service
{


    public class GameDetectService
    {


        static string installPath = "F:/";
        static string txtPath = "game.txt";

        static string fullTxtPath = Path.Combine(installPath, txtPath);

        public static ActionResult InitGamedataTxt()
        {
            try
            {
                //如果還有舊的檔案進行刪除
                if (File.Exists(fullTxtPath))
                {
                    File.Delete(fullTxtPath);
                }

                //將程式內鍵的資料寫入txt中
                string json = new JavaScriptSerializer().Serialize(DefaultGameDataStatus.defaultGameStatusArray);
                File.WriteAllText(fullTxtPath, json);

                return new ActionResult(true);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
           
        }

        public static ActionResult InitGamedataVariable()
        {
            try
            {
                //如果該檔案不存在，進行檔案的初始化
                if (!File.Exists(fullTxtPath))
                {
                    InitGamedataTxt();
                }

                //將檔案中的資料放入全局變數中
                string gameDataJson = File.ReadAllText(fullTxtPath);
                List<StaticGameDTO> supportGameList = JsonConvert.DeserializeObject<List<StaticGameDTO>>(gameDataJson);

                GameStatus.GameStatusList = GameStatus.StaticListToRunList(supportGameList);

                return new ActionResult(true);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
           
        }

        public static List<RunningGameDTO> GetRunningStatus()
        {
                return GameStatus.GameStatusList;
        }

        public static ActionResult UpdateRunningGameStatus()
        {
            try
            {
                //讀取全局變數中的運行資料
                List<RunningGameDTO> runningList = (List<RunningGameDTO>)GetRunningStatus().data;

                List<Process> processlist = Process.GetProcesses().ToList();

                //檢查是否執行程序的名稱 = 支援的遊戲名稱 ，如果相同加到 List 中 
                foreach (RunningGameDTO gameStatus in runningList)
                {
                    var findedProcess = processlist.Find(x => x.ProcessName.Contains(gameStatus.gameName));

                    //判斷是否有在執行
                    if (findedProcess != null)
                    {
                        gameStatus.isRunning = true;

                        //檢查遊戲路徑不等於執行程序的路徑時，將執行路徑更新
                        if (gameStatus.path != findedProcess.MainModule.FileName)
                        {
                            gameStatus.path = findedProcess.MainModule.FileName;
                        }
                    }
                    else
                    {
                        gameStatus.isRunning = false;
                    }

                }

               //將更新的資料寫入全局變數中
               GameStatus.GameStatusList = runningList;

               return new ActionResult(true);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }

            
        }

        public static ActionResult SaveGameStatusToTxt()
        {
            try
            {
                //型態轉換
                List<RunningGameDTO> runningList = (List<RunningGameDTO>)GetRunningStatus().data;
                List<StaticGameDTO> staticGameList = GameStatus.RunListToStaticList(runningList);

                string json = new JavaScriptSerializer().Serialize(staticGameList);
                File.WriteAllText(fullTxtPath, json);

                return new ActionResult(true);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
            
        }



    }
}
