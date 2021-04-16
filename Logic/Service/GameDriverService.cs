using Hosam_App.ErrorCode;
using Hosam_App.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hosam_App.Logic.Gobal;
using AssettoCorsaSharedMemory;

namespace Hosam_App.Logic.Service
{
    class GameDriverService
    {
        static AssettoCorsa ac;
        public static ActionResult Start(string gameName, int delayTime)
        {
            try
            {
                if (gameName == GameList.AssettoCorsa.gameName)
                {
                    ac = new AssettoCorsa();
                    ac.Start();
                    ac.PhysicsInterval = delayTime;
                    ac.PhysicsUpdated += AcToPhysicalData;

                }

                return new ActionResult(true);
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        public static ActionResult Stop(string gameName)
        {
            try
            {
                if (gameName == GameList.AssettoCorsa.gameName)
                {
                    ac.Stop();
                    ac.PhysicsUpdated -= AcToPhysicalData;
                }

                PhsicalData.Clear();

                return null;
            }
            catch (Exception e)
            {
                return new ActionResult(false, SoftLogicErr.unexceptErr.getCode(), SoftLogicErr.unexceptErr.getMsg());
            }
        }

        public static void AcToPhysicalData(object sender, PhysicsEventArgs e)
        {
            double x = Math.Round(e.Physics.AccG[0],5);
            double y = Math.Round(e.Physics.AccG[2], 5);
            double z = Math.Round(e.Physics.AccG[1], 5);


            PhsicalData.Save(x, y, z);
        }
    }
}
