

using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Service;
using System;
using System.Collections.Generic;

namespace Hosam_App.Logic.Controller
{
    class GameDetectController
    {
        public static ActionResult Start()
        {
            try
            {
                List<RunningGameDTO> runningData = (List<RunningGameDTO>)GameDetectService.GetRunningStatus().data;
                //如果已經有 running data 代表已經啟動過了
                if (runningData.Count != 0)
                {
                    return new ActionResult(false, SoftLogicErr.alreadyStart.getCode(), SoftLogicErr.alreadyStart.getMsg());
                }

                return GameDetectService.InitGamedataVariable();

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
                List<RunningGameDTO> runningData = (List<RunningGameDTO>)GameDetectService.GetRunningStatus().data;

                //如果沒有 running data 提示須先啟動
                if (runningData.Count == 0)
                {
                    return new ActionResult(false, SoftLogicErr.needStart.getCode(), SoftLogicErr.needStart.getMsg());
                }
                return GameDetectService.UpdateRunningGameStatus();
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        public static ActionResult GetData()
        {
            try
            {
                return GameDetectService.GetRunningStatus();
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }


        public static ActionResult Close()
        {
            try
            {
                List<RunningGameDTO> runningData = (List<RunningGameDTO>)GameDetectService.GetRunningStatus().data;

                //如果沒有 running data 提示須先啟動
                if (runningData.Count == 0)
                {
                    return new ActionResult(false, SoftLogicErr.needStart.getCode(), SoftLogicErr.needStart.getMsg());
                }

                return GameDetectService.SaveGameStatusToTxt();
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }
    }
}
