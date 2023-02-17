using System;
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
        private _ CandyLand = () => Behav()
        .Init("Candy Gnome",
            new State(
                new DropPortalOnDeath("Candyland Portal", 100),
                new Prioritize(
                    new StayBack(1.5, 55),
                    new Wander(1.4)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Super Mushroom", 0.04),
                new ItemLoot("Harlequin Armor", 0.05),
                new ItemLoot("Candy Ring", 0.15),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Potion of Attack", 0.25),
                new ItemLoot("Potion of Defense", 0.25),
                new ItemLoot("Potion of Speed", 0.25),
                new ItemLoot("Potion of Dexterity", 0.25),
                new ItemLoot("Potion of Vitality", 0.25),
                new ItemLoot("Potion of Wisdom", 0.25),
                new TierLoot(6, ItemType.Weapon, 0.15),
                new TierLoot(7, ItemType.Weapon, 0.15),
                new TierLoot(2, ItemType.Ability, 0.17),
                new TierLoot(3, ItemType.Ability, 0.17),
                new TierLoot(7, ItemType.Armor, 0.12),
                new TierLoot(8, ItemType.Armor, 0.12),
                new TierLoot(2, ItemType.Ring, 0.13),
                new TierLoot(3, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Desire Troll",
                new State(
                    new Wander(0.5),
                    new Grenade(6, 200, range: 8, coolDown: 3000),
                    new Shoot(15, 3, 5, angleOffset: 30 / 3, projectileIndex: 0, coolDown: 2100),
                    new Shoot(15, 5, 10, angleOffset: 60 / 3, projectileIndex: 2, coolDown: 1950),
                    new Shoot(15, 1, 0, angleOffset: 30 / 3, projectileIndex: 1, coolDown: 1950)
                ),
                new Threshold(0.001,
                new ItemLoot("Harbinger", 0.004),
                new ItemLoot("Insurgency Amulet", 0.01),
                new ItemLoot("Candy-Coated Armor", 0.05),
                new ItemLoot("Pixie-Enchanted Sword", 0.02),
                new ItemLoot("Seal of the Enchanted Forest", 0.03),
                new ItemLoot("Fairy Plate", 0.03),
                new ItemLoot("Ring of Pure Wishes", 0.03),
                new ItemLoot("Candy Ring", 0.1),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Potion of Attack", 0.25),
                new ItemLoot("Potion of Defense", 0.25),
                new ItemLoot("Potion of Speed", 0.25),
                new ItemLoot("Potion of Dexterity", 0.25),
                new ItemLoot("Potion of Vitality", 0.25),
                new ItemLoot("Potion of Wisdom", 0.25),
                new TierLoot(8, ItemType.Weapon, 0.15),
                new TierLoot(9, ItemType.Weapon, 0.15),
                new TierLoot(4, ItemType.Ability, 0.17),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(9, ItemType.Armor, 0.12),
                new TierLoot(10, ItemType.Armor, 0.12),
                new TierLoot(4, ItemType.Ring, 0.13),
                new TierLoot(5, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Gigacorn",
                new State(
                    new Wander(0.5),
                    new Charge(2.0, 10f, 4000),
                    new Shoot(20, 1, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 2100),
                    new Shoot(20, 1, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 2200),
                    new Shoot(20, 1, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 2300),
                    new Shoot(20, 1, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 2400),
                    new Shoot(20, 3, 15, angleOffset: 40 / 3, projectileIndex: 1, coolDown: 4000),
                    new Shoot(20, 3, 15, angleOffset: 20 / 3, projectileIndex: 1, coolDown: 2000)
                ),
                new Threshold(0.001,
                new ItemLoot("Bonemail of the Fallen", 0.004),
                new ItemLoot("Candy-Coated Armor", 0.05),
                new ItemLoot("Pixie-Enchanted Sword", 0.02),
                new ItemLoot("Seal of the Enchanted Forest", 0.03),
                new ItemLoot("Fairy Plate", 0.03),
                new ItemLoot("Ring of Pure Wishes", 0.03),
                new ItemLoot("Candy Ring", 0.1),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Potion of Attack", 0.25),
                new ItemLoot("Potion of Defense", 0.25),
                new ItemLoot("Potion of Speed", 0.25),
                new ItemLoot("Potion of Dexterity", 0.25),
                new ItemLoot("Potion of Vitality", 0.25),
                new ItemLoot("Potion of Wisdom", 0.25),
                new TierLoot(8, ItemType.Weapon, 0.15),
                new TierLoot(9, ItemType.Weapon, 0.15),
                new TierLoot(4, ItemType.Ability, 0.17),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(9, ItemType.Armor, 0.12),
                new TierLoot(10, ItemType.Armor, 0.12),
                new TierLoot(4, ItemType.Ring, 0.13),
                new TierLoot(5, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Spoiled Creampuff",
                new State(
                    new Shoot(20, 2, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 1500),
                    new Shoot(20, 4, 15, angleOffset: 40 / 3, projectileIndex: 1, coolDown: 1000),
                    new Spawn("Big Creampuff", maxChildren: 2, initialSpawn: 2, coolDown: 5000)
                ),
                new Threshold(0.001,
                new ItemLoot("Ji Robe", 0.0005),
                new ItemLoot("Candy-Coated Armor", 0.05),
                new ItemLoot("Pixie-Enchanted Sword", 0.02),
                new ItemLoot("Seal of the Enchanted Forest", 0.03),
                new ItemLoot("Fairy Plate", 0.03),
                new ItemLoot("Ring of Pure Wishes", 0.03),
                new ItemLoot("Candy Ring", 0.1),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Potion of Attack", 0.25),
                new ItemLoot("Potion of Defense", 0.25),
                new ItemLoot("Potion of Speed", 0.25),
                new ItemLoot("Potion of Dexterity", 0.25),
                new ItemLoot("Potion of Vitality", 0.25),
                new ItemLoot("Potion of Wisdom", 0.25),
                new TierLoot(8, ItemType.Weapon, 0.15),
                new TierLoot(9, ItemType.Weapon, 0.15),
                new TierLoot(4, ItemType.Ability, 0.17),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(9, ItemType.Armor, 0.12),
                new TierLoot(10, ItemType.Armor, 0.12),
                new TierLoot(4, ItemType.Ring, 0.13),
                new TierLoot(5, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Big Creampuff",
                new State(
                    new Wander(0.5),
                    new Shoot(20, 1, 0, angleOffset: 40 / 3, projectileIndex: 0, coolDown: 1000),
                    new Spawn("Small Creampuff", maxChildren: 2, initialSpawn: 0.5, coolDown: 5000)
                )
            )
            .Init("Small Creampuff",
                new State(
                    new Wander(.5),
                    new Shoot(20, 3, 30, angleOffset: 40 / 3, projectileIndex: 1, coolDown: 1400)
                )
            );
    }
}
