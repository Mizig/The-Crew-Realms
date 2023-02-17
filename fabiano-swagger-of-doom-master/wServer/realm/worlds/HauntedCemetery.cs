using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class HauntedCemetery : World
    {
        public HauntedCemetery()
        {
            Name = "Haunted Cemetery";
            ClientWorldName = "Haunted Cemetery";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.cem.jm", MapType.Json);
        }
    }
}
