using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hosam_App.Logic.DTO;

namespace Hosam_App.Logic.Gobal.DefaultValue
{
    class DefaultGameDataStatus
    {
        public static readonly StaticGameDTO [] defaultGameStatusArray = new StaticGameDTO[] 
        {
             new StaticGameDTO{ viewName = "AC",gameName="AssettoCorsa",path="",driver="",configId="",lastRunTime=""},
             new StaticGameDTO{ viewName = "wechat-test",gameName="WeChat",path="",driver="",configId="",lastRunTime=""}  
        };

    }
}
