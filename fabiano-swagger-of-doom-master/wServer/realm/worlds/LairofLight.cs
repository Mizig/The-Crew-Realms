using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class LairofLight : World
    {
        public LairofLight()
        {
            Name = "Lair of Light";
            ClientWorldName = "Lair of Light";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.light.jm", MapType.Json);
        }
    }
}
