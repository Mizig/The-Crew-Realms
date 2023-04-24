using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class MadLab : World
    {
        public MadLab()
        {
            Name = "Mad Lab";
            ClientWorldName = "Mad Lab";
            Background = 0;
            Difficulty = 3;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.lab.jm", MapType.Json);
        }
    }
}
