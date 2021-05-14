using Hosam_App.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hosam_App.Logic.Service;
using Hosam_App.ErrorCode;

namespace Hosam_App.Logic.Controller
{
    class DataBaseController
    {
        public static ActionResult CheckDataComplete()
        {
            try
            {
                return DataBaseService.CheckDataComplete();
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }
    }
}
