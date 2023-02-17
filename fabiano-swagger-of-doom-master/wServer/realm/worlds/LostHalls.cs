using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class LostHalls : World
    {
        public LostHalls()
        {
            Name = "Lost Halls";
            ClientWorldName = "Lost Halls";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.lh.jm", MapType.Json);
        }
    }
}
