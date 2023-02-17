using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class CrystalCave : World
    {
        public CrystalCave()
        {
            Name = "Crystal Cave";
            ClientWorldName = "Crystal Cave";
            Background = 0;
            AllowTeleport = true;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.crystal.jm", MapType.Json);
        }
    }
}
