﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        _ CubeGod = () => Behav()
            .Init("Cube God",
                new State(
                    new DropPortalOnDeath("Chicken House Portal", 100),
                    new StayCloseToSpawn(0.3, range: 7),
                           new Wander(0.5),
                             new Shoot(10, count: 14, predictive: 0.6, shootAngle: 8, coolDown: 900),
                             new Shoot(10, count: 9, projectileIndex: 1, predictive: 0.2, shootAngle: 6, coolDown: 1500, coolDownOffset: 300),
                             new Spawn("Cube Overseer", maxChildren: 3, initialSpawn: 1, coolDown: 100000),
                             new Spawn("Cube Defender", maxChildren: 3, initialSpawn: 2, coolDown: 100000),
                             new Spawn("Cube Blaster", maxChildren: 3, initialSpawn: 2, coolDown: 100000)
                ),
                new Threshold(0.001,
                new ItemLoot("Karen Jacket", 0.0005),
                new ItemLoot("Essence of Death", 0.004),
                new ItemLoot("Phantom Cleaver", 0.004),
                new ItemLoot("Tome of Fleshly Desires", 0.004),
                new ItemLoot("The Gravedigger's Disguise", 0.01),
                new ItemLoot("Dirk of Cronus", 0.05),
                new ItemLoot("Path of Loot Key", 0.00025),
                new ItemLoot("Potion of Life", 0.5),
                new ItemLoot("Potion of Mana", 0.5),
                new ItemLoot("Potion of Attack", 1.0),
                new ItemLoot("Potion of Defense", 1.0),
                new ItemLoot("Potion of Speed", 1.0),
                new ItemLoot("Greater Potion of Dexterity", 1.0),
                new ItemLoot("Potion of Vitality", 1.0),
                new ItemLoot("Potion of Wisdom", 1.0),
                new TierLoot(9, ItemType.Weapon, 0.15),
                new TierLoot(10, ItemType.Weapon, 0.15),
                new TierLoot(11, ItemType.Weapon, 0.15),
                new TierLoot(4, ItemType.Ability, 0.17),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(10, ItemType.Armor, 0.12),
                new TierLoot(11, ItemType.Armor, 0.12),
                new TierLoot(12, ItemType.Armor, 0.12),
                new TierLoot(4, ItemType.Ring, 0.13),
                new TierLoot(5, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Cube Overseer",
                new State(
                    new StayCloseToSpawn(0.3, range: 7),
                             new Wander(1),
                             new Shoot(10, count: 4, predictive: 0.9, projectileIndex: 0, coolDown: 1250)
                )
            )
            .Init("Cube Defender",
                new State(
                    new Wander(0.5),
                             new StayCloseToSpawn(0.03, range: 7),
                             new Follow(0.4, acquireRange: 9, range: 2),
                             new Shoot(10, count: 1, coolDown: 1000, predictive: 0.9, projectileIndex: 0)
                )
            )
            .Init("Cube Blaster",
                new State(
                    new Wander(0.5),
                             new StayCloseToSpawn(0.03, range: 7),
                             new Follow(0.4, acquireRange: 9, range: 2),
                             new Shoot(10, count: 2, predictive: 0.9, projectileIndex: 0, coolDown: 1500),
                             new Shoot(10, count: 1, predictive: 0.9, projectileIndex: 0, coolDown: 1500)
                )
            );
    }
}
