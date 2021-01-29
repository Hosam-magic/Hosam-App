using System.Collections.Generic;
using Hosam_App.Logic.DTO;

namespace Hosam_App.Logic.Gobal.GobalVariable
{
    class GameStatus
    {
        public static List<RunningGameDTO> GameStatusList = new List<RunningGameDTO>();


        public static List<RunningGameDTO> StaticListToRunList (List<StaticGameDTO> staticGameList)
        { 
            List<RunningGameDTO> runningList = new List<RunningGameDTO>();

            foreach (StaticGameDTO staticData in staticGameList)
            {
                RunningGameDTO runningData = new RunningGameDTO();

                runningData.viewName = staticData.viewName;
                runningData.gameName = staticData.gameName;
                runningData.path = staticData.path;
                runningData.driver = staticData.driver;
                runningData.isRunning = false;

                runningList.Add(runningData);
            }
            return runningList;
        }

        public static List<StaticGameDTO> RunListToStaticList(List<RunningGameDTO> runningList)
        {
            List<StaticGameDTO> staticList = new List<StaticGameDTO>();

            foreach (RunningGameDTO runningData in runningList)
            {
                StaticGameDTO staticData = new StaticGameDTO();

                staticData.viewName = runningData.viewName;
                staticData.gameName = runningData.gameName;
                staticData.path = runningData.path;
                staticData.driver = runningData.driver;

                staticList.Add(staticData);
            }

            return staticList;
        }
    }
}
