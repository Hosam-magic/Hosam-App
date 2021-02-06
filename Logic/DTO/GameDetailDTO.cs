
using System.Collections.Generic;

namespace Hosam_App.Logic.DTO
{
    public class StaticGameDTO
    {
        public string viewName;
        public string gameName;
        public string path;
        public string driver;
        public string configId;
        public string lastRunTime;

        public StaticGameDTO(string viewName , string gameName ,string path , string driver ,string configId , string lastRunTime)
        {
            this.viewName = viewName;
            this.gameName = gameName;
            this.path = path;
            this.driver = driver;
            this.configId = configId;
            this.lastRunTime = lastRunTime;
        }

        public static List<RunningGameDTO> StaticListToRunList(List<StaticGameDTO> staticGameList)
        {
            List<RunningGameDTO> runningList = new List<RunningGameDTO>();

            foreach (StaticGameDTO staticData in staticGameList)
            {
                RunningGameDTO runningData = new RunningGameDTO(staticData.viewName, staticData.gameName,
                    staticData.path, staticData.driver,
                    staticData.configId, staticData.lastRunTime, false);

                runningList.Add(runningData);
            }
            return runningList;
        }
    }
    public class RunningGameDTO : StaticGameDTO
    {
        public bool isRunning;

        public RunningGameDTO (string viewName, string gameName, string path, string driver, string configId, string lastRunTime , bool isRunning)
            :base(viewName,gameName,  path,  driver,  configId,  lastRunTime)

        {
            this.viewName = viewName;
            this.gameName = gameName;
            this.path = path;
            this.driver = driver;
            this.configId = configId;
            this.lastRunTime = lastRunTime;
            this.isRunning = isRunning;
        }

        public static List<StaticGameDTO> RunListToStaticList(List<RunningGameDTO> runningList)
        {
            List<StaticGameDTO> staticList = new List<StaticGameDTO>();

            foreach (RunningGameDTO runningData in runningList)
            {
                StaticGameDTO staticData = new StaticGameDTO(runningData.viewName, runningData.gameName, 
                    runningData.path, runningData.driver , 
                    runningData.configId , runningData.lastRunTime);

                staticList.Add(staticData);
            }

            return staticList;
        }
    }
}
