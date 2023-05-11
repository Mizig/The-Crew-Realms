﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class CrystalCore : World
    {
        public CrystalCore()
        {
            Name = "Crystal Core";
            ClientWorldName = "Crystal Core";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.core.jm", MapType.Json);
        }
    }
}