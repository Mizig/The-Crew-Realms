using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class TreasureCave : World
    {
        public TreasureCave()
        {
            Name = "Treasure Cave";
            ClientWorldName = "Treasure Cave";
            Background = 0;
            AllowTeleport = true;
            Difficulty = 3;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.treasurecave.jm", MapType.Json);
        }
    }
}
