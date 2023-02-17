using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class PathOfLoot : World
    {
        public PathOfLoot()
        {
            Name = "Path Of Loot";
            ClientWorldName = "Path of Loot";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.PathMap.jm", MapType.Json);
        }
    }
}
