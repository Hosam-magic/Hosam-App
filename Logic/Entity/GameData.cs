

namespace Hosam_App.Logic.Entity
{
    public class GameData
    {
        public string id;
        public string gameName { get; set; }
        public string path;
        public string driverId;
        public string configId;   
        public MotionSetting motionSetting;
        public string lastRunTime;
        public int   isRunning;

    }
}
