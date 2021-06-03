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
    class DataReaderController
    {
        public static ActionResult Adjust(MotionSetting newSetting)
        {
            return DataReaderService.Adjust(newSetting);
        }

        public static ActionResult GetPhsycalData()
        {
            return DataReaderService.GetPhsycalData();
        }
    }
}
