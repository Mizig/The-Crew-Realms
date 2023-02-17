using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class TheNest : World
    {
        public TheNest()
        {
            Name = "The Nest";
            ClientWorldName = "The Nest";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.thenest.jm", MapType.Json);
        }
    }
}
