using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class SantasDen : World
    {
        public SantasDen()
        {
            Name = "Santa's Den";
            ClientWorldName = "Santa's Den";
            Background = 0;
            AllowTeleport = true;
            Difficulty = 4;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.santasden.jm", MapType.Json);
        }
    }
}
