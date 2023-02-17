using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class WoodlandLabyrinth : World
    {
        public WoodlandLabyrinth()
        {
            Name = "Woodland Labyrinth";
            ClientWorldName = "Woodland Labyrinth";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.wlab.jm", MapType.Json);
        }
    }
}
