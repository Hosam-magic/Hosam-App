using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
using Hosam_App.Logic.Repository;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Reflection;

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
                    return new ActionResult(false, SoftLogicErr.nameAlreadyExist.GetCode(), SoftLogicErr.nameAlreadyExist.GetMsg());
                }

                return new ActionResult(false, SoftLogicErr.dbException.GetCode(), SoftLogicErr.dbException.GetMsg());
            }
            catch (Exception e)
            {
                LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name +  "\r\n" + e.GetType() + "\r\n" + e.Message);
                return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
            }
        }

        public static ActionResult GetSetting(string id)
        {
            try
            {
                List<MotionSetting> result = MotionSettingRepository.GetSetting(id);

                return new ActionResult(true, result);
            }
            catch (SQLiteException e)
            {
                return new ActionResult(false, SoftLogicErr.dbException.GetCode(), SoftLogicErr.dbException.GetMsg());
            }
            catch (Exception e)
            {
                LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name +  "\r\n" + e.GetType() + "\r\n" + e.Message);
                return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
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
                    return new ActionResult(false, SoftLogicErr.nameAlreadyExist.GetCode(), SoftLogicErr.nameAlreadyExist.GetMsg());
                }

                return new ActionResult(false, SoftLogicErr.dbException.GetCode(), SoftLogicErr.dbException.GetMsg());
            }
            catch (Exception e)
            {
                LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name +  "\r\n" + e.GetType() + "\r\n" + e.Message);
                return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
            }
        }

        public static ActionResult DeleteSetting(MotionSetting motionSetting)
        {
            try
            {
                MotionSettingRepository.DeleteSetting(motionSetting);

                return new ActionResult(true);
            }
            catch (SQLiteException e)
            {
                return new ActionResult(false, SoftLogicErr.dbException.GetCode(), SoftLogicErr.dbException.GetMsg());
            }
            catch (Exception e)
            {
                LogService.WriteLog("Err function name：" + MethodBase.GetCurrentMethod().Name +  "\r\n" + e.GetType() + "\r\n" + e.Message);
                return new ActionResult(false, SoftLogicErr.unexceptErr.GetCode(), SoftLogicErr.unexceptErr.GetMsg());
            }
        }
    }
}
