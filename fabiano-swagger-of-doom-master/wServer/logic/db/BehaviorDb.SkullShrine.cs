#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ SkullShrine = () => Behav()
            .Init("Skull Shrine",
                new State(
                    new DropPortalOnDeath("The Nest Portal", 100),
                    new Shoot(25, 9, 10, predictive: 1),
                    new Spawn("Red Flaming Skull", 8, coolDown: 5000),
                    new Spawn("Blue Flaming Skull", 10, coolDown: 1000),
                    new Reproduce("Red Flaming Skull", 10, 8, 5000),
                    new Reproduce("Blue Flaming Skull", 10, 10, 1000)
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Butcher's Plate", 0.0005),
                new ItemLoot("Atonement", 0.004),
                new ItemLoot("Blazing Machete", 0.004),
                new ItemLoot("Flaming Horizons Anchor", 0.004),
                new ItemLoot("Nightmare Gem Gem's Gem", 0.004),
                new ItemLoot("Necrotic Boneplate", 0.004),
                new ItemLoot("The Flamarang", 0.005),
                new ItemLoot("Crown of War", 0.0098),
                new ItemLoot("Devil Dice", 0.01),
                new ItemLoot("Demon Summoning Tome", 0.01),
                new ItemLoot("The Infernus", 0.01),
                new ItemLoot("Orb of Conflict", 0.05),
                new ItemLoot("Hell's Breastplate", 0.04),
                new ItemLoot("Flaming Boomerang", 0.05),
                new ItemLoot("Path of Loot Key", 0.00025),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.5),
                new ItemLoot("Potion of Life", 0.5),
                new ItemLoot("Potion of Mana", 0.5),
                new ItemLoot("Greater Potion of Attack", 1.0),
                new ItemLoot("Potion of Defense", 1.0),
                new ItemLoot("Potion of Speed", 1.0),
                new ItemLoot("Potion of Vitality", 1.0),
                new ItemLoot("Potion of Dexterity", 1.0),
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
            .Init("Red Flaming Skull",
                new State(
                    new Prioritize(
                        new Wander(.6),
                        new Follow(.6, 20, 3)
                        ),
                    new Shoot(15, 2, 5, 0, predictive: 1, coolDown: 750)
                    )
            )
            .Init("Blue Flaming Skull",
                new State(
                    new Prioritize(
                        new Orbit(1, 20, target: "Skull Shrine", radiusVariance: 0.5),
                        new Wander(.6)
                        ),
                    new Shoot(15, 2, 5, 0, predictive: 1, coolDown: 750)
                    )
            );
    }
}
