using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class ChickenHouse : World
    {
        public ChickenHouse()
        {
            Name = "Chicken House";
            ClientWorldName = "Chicken House";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.chicken.jm", MapType.Json);
        }
    }
}
