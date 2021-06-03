

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

        public static ActionResult GetData(string id)
        {
            return GameService.GetGameData(id);
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
