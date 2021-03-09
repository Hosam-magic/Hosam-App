using Hosam_App.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Hosam_App.ErrorCode;
using System.ComponentModel;
using Hosam_App.Logic.Entity;
using Hosam_App.Logic.Repository;

namespace Hosam_App.Logic.Service
{


    public class GameDetectService
    {

        public static ActionResult GetGameData(string gameName)
        {
            try
            {
                List<GameData> gameData = new List<GameData>();
                if (gameName == null)
                {
                    gameData = GameDataRepository.GetAllGameData();
                }
                else
                {
                    gameData = GameDataRepository.GetGameDataByName(gameName);
                }
                return new ActionResult(true, gameData);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
            
        }

        public static ActionResult UpdateGameStatus()
        {
            try
            {
                //讀取全局變數中的運行資料
                List<GameData> supGameList = GameDataRepository.GetAllGameData();

                List<Process> processlist = Process.GetProcesses().ToList();

                //檢查是否執行程序的名稱 = 支援的遊戲名稱 ，如果相同加到 List 中 
                foreach (GameData supGame in supGameList)
                {
                    var findedProcess = processlist.Find(x => x.ProcessName.Contains(supGame.gameName));

                    bool needUpdate = false;

                    //DB顯示未執行，但有在處理程序中找到
                    if (findedProcess != null && supGame.isRunning == 0)
                    {
                        supGame.isRunning = 1;
                        supGame.path = findedProcess.MainModule.FileName;
                        supGame.lastRunTime = DateTime.Now.ToString();

                        needUpdate = true;
                    }
                    //DB顯示有執行，但有沒有處理程序中找到
                    if (findedProcess == null && supGame.isRunning == 1)
                    {
                        supGame.isRunning = 0;
                        needUpdate = true;
                    }

                    if (needUpdate)
                    {
                        //進行資料更新
                        GameDataRepository.UpdateGameData(supGame);
                    }
                }

               return new ActionResult(true);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }

            
        }

        public static ActionResult RunGame(string path)
        {
            try
            {
                List<GameData> data = GameDataRepository.GetGameDataByPath(path);
                

                //如果全局變數中沒有該路徑報錯
                if (data.Count == 0)
                {
                    return new ActionResult(false, SoftLogicErr.dataNotFound.getCode(), SoftLogicErr.dataNotFound.getMsg());
                }

                Process.Start(path);
                return new ActionResult(true);
            }
            catch (Win32Exception)
            {
                return new ActionResult(false, SoftLogicErr.pathNotFound.getCode(), SoftLogicErr.pathNotFound.getMsg());
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
            
            
        }

    }
}
