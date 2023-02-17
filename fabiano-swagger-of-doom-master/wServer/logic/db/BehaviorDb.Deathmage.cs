#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Deathmage = () => Behav()
            .Init("Skeleton",
                new State(
                    new Shoot(3),
                    new State("Default",
                        new Prioritize(
                            new Follow(1, range: 1),
                            new Wander(0.4)
                            )
                        ),
                    new State("Protect",
                        new Prioritize(
                            new Protect(1, "Deathmage"),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        ),
                    new State("Circling",
                        new Prioritize(
                            new Orbit(1, 10),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        ),
                    new State("Engaging",
                        new Prioritize(
                            new Follow(1, 15, 1),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        )
                    ),
                new ItemLoot("Long Sword", 0.02),
                new ItemLoot("Dirk", 0.02)
            )
            .Init("Skeleton Swordsman",
                new State(
                    new Shoot(3),
                    new State("Default",
                        new Prioritize(
                            new Follow(1, range: 1),
                            new Wander(0.4)
                            )
                        ),
                    new State("Protect",
                        new Prioritize(
                            new Protect(1, "Deathmage"),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        ),
                    new State("Circling",
                        new Prioritize(
                            new Orbit(1, 10),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        ),
                    new State("Engaging",
                        new Prioritize(
                            new Follow(1, 15, 1),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        )
                    ),
                new ItemLoot("Long Sword", 0.03),
                new ItemLoot("Steel Shield", 0.02),
                new ItemLoot("Bronze Helm", 0.02)
            )
            .Init("Skeleton Veteran",
                new State(
                    new Shoot(3),
                    new State("Default",
                        new Prioritize(
                            new Follow(1, range: 1),
                            new Wander(0.4)
                            )
                        ),
                    new State("Protect",
                        new Prioritize(
                            new Protect(1, "Deathmage"),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        ),
                    new State("Circling",
                        new Prioritize(
                            new Orbit(1, 10),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        ),
                    new State("Engaging",
                        new Prioritize(
                            new Follow(1, 15, 1),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        )
                    ),
                new ItemLoot("Long Sword", 0.03),
                new ItemLoot("Golden Shield", 0.02),
                new ItemLoot("Cloak of Darkness", 0.01),
                new ItemLoot("Spider Venom", 0.01)
            )
            .Init("Skeleton Mage",
                new State(
                    new Shoot(10),
                    new State("Default",
                        new Prioritize(
                            new Follow(1, range: 7),
                            new Wander(0.4)
                            )
                        ),
                    new State("Protect",
                        new Prioritize(
                            new Protect(1, "Deathmage"),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        ),
                    new State("Circling",
                        new Prioritize(
                            new Orbit(1, 10),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        ),
                    new State("Engaging",
                        new Prioritize(
                            new Follow(1, 15, 1),
                            new Wander(0.4)
                            ),
                        new EntityNotExistsTransition("Deathmage", 10, "Default")
                        )
                    ),
                new ItemLoot("Missile Wand", 0.02),
                new ItemLoot("Comet Staff", 0.02),
                new ItemLoot("Comet Staff", 0.02),
                new ItemLoot("Fire Nova Spell", 0.02)
            )
            .Init("Deathmage",
                new State(
                    new State("Waiting",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 5),
                            new Wander(0.4)
                            ),
                        new Order(10, "Skeleton", "Protect"),
                        new Order(10, "Skeleton Swordsman", "Protect"),
                        new Order(10, "Skeleton Veteran", "Protect"),
                        new Order(10, "Skeleton Mage", "Protect"),
                        new PlayerWithinTransition(15, "Attacking")
                        ),
                    new State("Attacking",
                        new Taunt(0.2, 2000, "{PLAYER}, you will soon be my undead slave!",
                            "My skeletons will make short work of you.",
                            "You will never leave this graveyard alive!"
                            ),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 5),
                            new Follow(0.8, range: 8),
                            new Wander(0.4)
                            ),
                        new Shoot(10, 3, 15, predictive: 1),
                        new State("Circling",
                            new Orbit(0.8, 5),
                            new Order(10, "Skeleton", "Circling"),
                            new Order(10, "Skeleton Swordsman", "Circling"),
                            new Order(10, "Skeleton Veteran", "Circling"),
                            new Order(10, "Skeleton Mage", "Circling"),
                            new TimedTransition(2000, "Engaging")
                            ),
                        new State("Engaging",
                            new Order(10, "Skeleton", "Engaging"),
                            new Order(10, "Skeleton Swordsman", "Engaging"),
                            new Order(10, "Skeleton Veteran", "Engaging"),
                            new Order(10, "Skeleton Mage", "Engaging"),
                            new TimedTransition(2000, "Circling")
                            ),
                        new NoPlayerWithinTransition(30, "Waiting")
                        ),
                    new Spawn("Skeleton", 4, coolDown: 8000),
                    new Spawn("Skeleton Swordsman", 2, coolDown: 8000),
                    new Spawn("Skeleton Veteran", 1, coolDown: 8000),
                    new Spawn("Skeleton Mage", 1, coolDown: 8000)
                    ),
                new Threshold(0.001,
                new ItemLoot("Skull of Vampirism", 0.004),
                new ItemLoot("The Gravedigger's Shovel", 0.009),
                new ItemLoot("Dagger of Tindailius", 0.01),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Potion of Attack", 0.7),
                new ItemLoot("Magic Potion", 0.50),
                new ItemLoot("Magic Potion", 0.50),
                new TierLoot(4, ItemType.Weapon, 0.15),
                new TierLoot(5, ItemType.Weapon, 0.15),
                new TierLoot(1, ItemType.Ability, 0.17),
                new TierLoot(2, ItemType.Ability, 0.17),
                new TierLoot(5, ItemType.Armor, 0.12),
                new TierLoot(6, ItemType.Armor, 0.12),
                new TierLoot(1, ItemType.Ring, 0.13),
                new TierLoot(2, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            ;
    }
}