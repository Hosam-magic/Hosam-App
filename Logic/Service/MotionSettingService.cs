using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
using Hosam_App.Logic.Repository;
using System;
using System.Data.SQLite;

namespace Hosam_App.Logic.Service
{
    class MotionSettingService
    {
        public static ActionResult SaveSetting(MotionSetting motionSetting)
        {
            try
            {
                MotionSettingRepository.SaveSetting(motionSetting);

                return new ActionResult(true);
            }
            catch (SQLiteException e)
            {
                //因 name 設為 uk 所以 exception 訊息含有 UNIQUE 判斷為名子重複
                if (e.Message.Contains("UNIQUE"))
                {
                    return new ActionResult(false, SoftLogicErr.nameAlreadyExist.getCode(), SoftLogicErr.nameAlreadyExist.getMsg());
                }

                return new ActionResult(false, SoftLogicErr.dbException.getCode(), SoftLogicErr.dbException.getMsg());
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        public static ActionResult UpdateSetting(MotionSetting motionSetting)
        {
            try
            {
                MotionSettingRepository.UpdateSetting(motionSetting);

                return new ActionResult(true);
            }
            catch (SQLiteException e)
            {
                //因 name 設為 uk 所以 exception 訊息含有 UNIQUE 判斷為名子重複
                if (e.Message.Contains("UNIQUE"))
                {
                    return new ActionResult(false, SoftLogicErr.nameAlreadyExist.getCode(), SoftLogicErr.nameAlreadyExist.getMsg());
                }

                return new ActionResult(false, SoftLogicErr.dbException.getCode(), SoftLogicErr.dbException.getMsg());
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }
    }
}
