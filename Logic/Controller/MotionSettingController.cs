using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Entity;
using Hosam_App.Logic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hosam_App.Logic.Controller
{
    class MotionSettingController
    {
        //新增單筆
        public static ActionResult SaveSetting(MotionSetting motionSetting)
        {
            return MotionSettingService.SaveSetting(motionSetting);
        }

        //讀取設定，若 id 為 null 則回傳全部
        public static ActionResult GetSetting(string id)
        {
            return MotionSettingService.GetSetting(id);
        }

        //更新單筆
        public static ActionResult UpdateSetting(MotionSetting motionSetting)
        {
            return MotionSettingService.UpdateSetting(motionSetting);
        }

        //刪除單筆
        public static ActionResult DeleteSetting(MotionSetting motionSetting)
        {
            return MotionSettingService.DeleteSetting(motionSetting);
        }
    }
}
