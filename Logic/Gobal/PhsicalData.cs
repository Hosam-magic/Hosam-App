using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosam_App.Logic.Gobal
{
    class PhsicalData
    {
        public static double x; //左右
        public static double y; //前後
        public static double z; //上下

        public static void Save(double x , double y, double z)
        {
            PhsicalData.x = x;
            PhsicalData.y = y;
            PhsicalData.z = z;
        }


        public static void Clear()
        {
            x = 0; y = 0; z = 0;
        }

    }
}
