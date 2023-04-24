using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class IceCave : World
    {
        public IceCave()
        {
            Name = "Ice Cave";
            ClientWorldName = "Ice Cave";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 4;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.icecave.jm", MapType.Json);
        }
    }
}
