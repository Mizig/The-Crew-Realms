#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ GreatCoilSnake = () => Behav()
            .Init("Great Coil Snake",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(0.8, 5),
                        new Wander(0.4)
                        ),
                    new State("Waiting",
                        new PlayerWithinTransition(15, "Attacking")
                        ),
                    new State("Attacking",
                        new Shoot(10, projectileIndex: 0, coolDown: 700, coolDownOffset: 600),
                        new Shoot(10, 10, 36, 1, coolDown: 2000),
                        new TossObject("Great Snake Egg", 4, 0, 5000, coolDownOffset: 0),
                        new TossObject("Great Snake Egg", 4, 90, 5000, 600),
                        new TossObject("Great Snake Egg", 4, 180, 5000, 1200),
                        new TossObject("Great Snake Egg", 4, 270, 5000, 1800),
                        new NoPlayerWithinTransition(30, "Waiting")
                        )
                    ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Pyrus Draconia", 0.004),
                new ItemLoot("Reaper's Bow", 0.004),
                new ItemLoot("Spiritclaw", 0.0095),
                new ItemLoot("Core of Corruption", 0.01),
                new ItemLoot("Oath of Cinder", 0.01),
                new ItemLoot("Robes of Aldragine", 0.01),
                new ItemLoot("Forgotten Zol Gem", 0.0095),
                new ItemLoot("Midnight Star", 0.05),
                new ItemLoot("Void Blade", 0.05),
                new ItemLoot("pD Armor", 0.05),
                new ItemLoot("Staff of the Crystal Serpent", 0.10),
                new ItemLoot("Cracked Crystal Skull", 0.13),
                new ItemLoot("Robe of the Tlatoani", 0.16),
                new ItemLoot("Crystal Bone Ring", 0.19),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.15),
                new ItemLoot("Potion of Dexterity", 0.70),
                new ItemLoot("Potion of Wisdom", 0.50),
                new ItemLoot("Pollen Powder", 0.50),
                new ItemLoot("Pollen Powder", 0.50),
                new ItemLoot("Pollen Powder", 0.50),
                new TierLoot(5, ItemType.Weapon, 0.15),
                new TierLoot(6, ItemType.Weapon, 0.15),
                new TierLoot(1, ItemType.Ability, 0.17),
                new TierLoot(2, ItemType.Ability, 0.17),
                new TierLoot(6, ItemType.Armor, 0.12),
                new TierLoot(7, ItemType.Armor, 0.12),
                new TierLoot(2, ItemType.Ring, 0.13),
                new TierLoot(3, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Great Snake Egg",
                new State(
                    new TransformOnDeath("Great Temple Snake", 1, 2),
                    new State("Wait",
                        new TimedTransition(2500, "Explode"),
                        new PlayerWithinTransition(2, "Explode")
                        ),
                    new State("Explode",
                        new Suicide()
                        )
                    )
            )
            .Init("Great Temple Snake",
                new State(
                    new Prioritize(
                        new Follow(0.6),
                        new Wander(0.4)
                        ),
                    new Shoot(10, 2, 7, 0, coolDown: 1000, coolDownOffset: 0),
                    new Shoot(10, 6, 60, 1, coolDown: 2000, coolDownOffset: 600),
                    new TimedTransition(6000, "bye"),
                    new State("bye",
                        new Suicide()
                        )
                    )
            )
            ;
    }
}
