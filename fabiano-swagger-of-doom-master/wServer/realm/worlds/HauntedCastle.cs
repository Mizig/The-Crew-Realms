using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class HauntedCastle : World
    {
        public HauntedCastle()
        {
            Name = "Haunted Castle";
            ClientWorldName = "Haunted Castle";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.hauntedcastle.jm", MapType.Json);
        }
    }
}
