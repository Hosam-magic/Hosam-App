using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
using Hosam_App.Logic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosam_App.Logic.Controller
{
    class MotionSettingController
    {
        //新增單筆
        public static ActionResult SaveSetting(MotionSetting motionSetting)
        {
            try
            {
                return MotionSettingService.SaveSetting( motionSetting );
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        //讀取設定，若 id 為 null 則回傳全部
        public static ActionResult GetSetting(string id)
        {
            try
            {
                return MotionSettingService.GetSetting(id);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        //更新單筆
        public static ActionResult UpdateSetting(MotionSetting motionSetting)
        {
            try
            {
                return MotionSettingService.UpdateSetting(motionSetting);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        //刪除單筆
        public static ActionResult DeleteSetting(MotionSetting motionSetting)
        {
            try
            {
                return MotionSettingService.DeleteSetting(motionSetting);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }
    }
}
