using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosam_App.Logic.Gobal
{
    class GameList
    {
        public readonly string gameName;

        public static readonly GameList AssettoCorsa = new GameList("AssettoCorsa");
        public static readonly GameList eurotrucks2 = new GameList("eurotrucks2");

        GameList(string gameName)
        {
            this.gameName = gameName;
        }
    }
}
