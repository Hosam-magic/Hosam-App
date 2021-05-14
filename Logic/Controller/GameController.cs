﻿

using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Service;
using System;
using System.Collections.Generic;

namespace Hosam_App.Logic.Controller
{
    class GameController
    {

        public static ActionResult Initialize()
        {
            try
            {
                //把遊戲執行狀態清空，避免舊資料影響程式判斷
                return GameService.ResetAllRunningStatus();
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        public static ActionResult Update()
        {
            try
            {
                return GameService.UpdateGameStatus();
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        public static ActionResult GetData(string gameName)
        {
            try
            {
                return GameService.GetGameData(gameName);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        public static ActionResult RunGame(string path)
        {


            return GameService.RunGame(path);

        }

    }
}
