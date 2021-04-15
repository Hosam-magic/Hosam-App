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
                //如果傳進來的 gmaeName 是 null ，就回傳所有資料
                List<GameData> gameData = GameDataRepository.GetGameData(gameName);

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
                //讀取資料庫中所有遊戲資訊
                List<GameData> supGameList = GameDataRepository.GetGameData(null);

                List<Process> processlist = Process.GetProcesses().ToList();

                //存放哪些遊戲被關閉或開啟
                List<GameData> stopGameList = new List<GameData>();
                List<GameData> startGameList = new List<GameData>();

                //檢查是否執行程序的名稱 = 支援的遊戲名稱 ，如果相同加到 List 中 
                foreach (GameData supGame in supGameList)
                {
                    var findedProcess = processlist.Find(x => x.ProcessName.Contains(supGame.gameName));

                    bool needUpdate = false;

                    //DB顯示未執行，但有在處理程序中找到
                    if (findedProcess != null && supGame.isRunning != 1)
                    {
                        supGame.isRunning = 1;
                        supGame.path = findedProcess.MainModule.FileName;
                        supGame.lastRunTime = DateTime.Now.ToString();

                        //加入被起動的遊戲清單
                        startGameList.Add(supGame);

                        needUpdate = true;
                    }
                    //DB顯示有執行，但有沒有處理程序中找到
                    if (findedProcess == null && supGame.isRunning != 0)
                    {
                        supGame.isRunning = 0;

                        //加入被停止的遊戲清單
                        stopGameList.Add(supGame);

                        needUpdate = true;
                    }

                    if (needUpdate)
                    {
                        //進行資料更新
                        GameDataRepository.UpdateGameData(supGame);
                    }

                    //依照起動與停止的記錄做出對應的行為
                    if (stopGameList.Count != 0)
                    {
                        //停止相對應的區動
                        foreach (GameData stopGame in stopGameList)
                        {
                            GameDriverService.Stop(stopGame.gameName);
                        }
                        
                    }

                    if (startGameList.Count > 1)
                    { return new ActionResult(false, SoftLogicErr.detactMultipleGame.getCode(), SoftLogicErr.detactMultipleGame.getMsg()); }

                    if (startGameList.Count == 1)
                    {
                        //起動相對應的區動
                        foreach (GameData startGame in startGameList)
                        {
                            GameDriverService.Start(startGame.gameName ,1000);
                        }
                            
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


                //如果DB中沒有該路徑報錯
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
