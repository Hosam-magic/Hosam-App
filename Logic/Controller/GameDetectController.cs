

using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Service;
using System;
using System.Collections.Generic;

namespace Hosam_App.Logic.Controller
{
    class GameDetectController
    {

        public static ActionResult Update()
        {
            try
            {
                return GameDetectService.UpdateGameStatus();
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
                return GameDetectService.GetGameData(gameName);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        public static ActionResult RunGame(string path)
        {


            return GameDetectService.RunGame(path);

        }

    }
}
