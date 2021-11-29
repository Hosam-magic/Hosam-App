using Hosam_App.Logic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosam_App.Logic.Gobal
{
    class BaseData
    {
        public static readonly string[] supposeGameArray = new string[] { "AssettoCorsa", "eurotrucks2" };

        public static readonly MotionSetting baseMotionSetting = new MotionSetting
        {
            name = "原廠設定",
            gobalStrength =1,
            xStrength =1,
            yStrength = 1,
            zStrength = 1,
            delayTime =100
        };
    }
}
