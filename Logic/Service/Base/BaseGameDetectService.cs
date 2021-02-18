using Hosam_App.Logic.DTO;
using Hosam_App.Logic.Gobal.GobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosam_App.Logic.Service.Base
{
    class BaseGameDetectService
    {
        public static List<RunningGameDTO> GetRunningStatus()
        {
            return GameStatus.GameStatusList;
        }
    }
}
