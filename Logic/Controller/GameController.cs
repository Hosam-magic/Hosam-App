

using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
using Hosam_App.Logic.Service;
using System;
using System.Collections.Generic;

namespace Hosam_App.Logic.Controller
{
    class GameController
    {

        public static ActionResult Initialize()
        {
            //把遊戲執行狀態清空，避免舊資料影響程式判斷，並停止可能卡住的副程式
            return GameService.Initialize();
        }

        public static ActionResult UpdateGameStatus()
        {
            return GameService.UpdateGameStatus();
        }

        //取得遊戲資料與其相對硬的設定黨
        // sort = 0 以 gameName 做小到大排序
        // sort = 1 以 lastRunTime 作大到小排序
        public static ActionResult GetData(string id ,int isFavorite , int isRunning, int sort)
        {
            return GameService.GetGameData(id , isFavorite, isRunning, sort);
        }

        public static ActionResult RunGame(string path)
        {
            return GameService.RunGame(path);
        }

        public static ActionResult ChangeMotionSetting(GameData gameData, MotionSetting motionSetting)
        {
            return GameService.ChangeMotionSetting(gameData, motionSetting);
        }

    }
}
