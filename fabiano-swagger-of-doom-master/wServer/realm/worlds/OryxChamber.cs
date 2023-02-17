using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class OryxChamber : World
    {
        public OryxChamber()
        {
            Name = "OryxChamber";
            ClientWorldName = "Oryx's Chamber";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.OChamber.jm", MapType.Json);
        }
    }
}
