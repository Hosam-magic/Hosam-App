
namespace Hosam_App.Logic.DTO
{
    public class StaticGameDTO
    {
        public string viewName;
        public string gameName;
        public string path;
        public string driver;
    }
    public class RunningGameDTO : StaticGameDTO
    {
        public bool isRunning;
    }
}
