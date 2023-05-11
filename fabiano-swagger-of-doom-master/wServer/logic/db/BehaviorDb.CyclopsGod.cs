#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ CyclopsGod = () => Behav()
            .Init("Cyclops God",
                new State(
                    new DropPortalOnDeath("Spider Den Portal", 20, PortalDespawnTimeSec: 100),
                    new State("idle",
                        new PlayerWithinTransition(11, "blade_attack"),
                        new HpLessTransition(0.8, "blade_attack")
                        ),
                    new State("blade_attack",
                        new Prioritize(
                            new Follow(0.4, range: 7),
                            new Wander(0.4)
                            ),
                        new Shoot(10, projectileIndex: 4, count: 1, shootAngle: 15, predictive: 0.5, coolDown: 100000),
                        new Shoot(10, projectileIndex: 4, count: 2, shootAngle: 10, predictive: 0.5, coolDown: 100000,
                            coolDownOffset: 700),
                        new Shoot(10, projectileIndex: 4, count: 3, shootAngle: 8.5, predictive: 0.5, coolDown: 100000,
                            coolDownOffset: 1400),
                        new Shoot(10, projectileIndex: 4, count: 4, shootAngle: 7, predictive: 0.5, coolDown: 100000,
                            coolDownOffset: 2100),
                        new TimedTransition(4000, "if_cloaked1")
                        ),
                    new State("if_cloaked1",
                        new Shoot(10, projectileIndex: 4, count: 15, shootAngle: 24, fixedAngle: 8, coolDown: 1500,
                            coolDownOffset: 400),
                        new TimedTransition(10000, "wave_attack"),
                        new PlayerWithinTransition(10.5, "wave_attack")
                        ),
                    new State("wave_attack",
                        new Prioritize(
                            new Follow(0.6, range: 5),
                            new Wander(0.6)
                            ),
                        new Shoot(9, projectileIndex: 0, coolDown: 700, coolDownOffset: 700),
                        new Shoot(9, projectileIndex: 1, coolDown: 700, coolDownOffset: 700),
                        new Shoot(9, projectileIndex: 2, coolDown: 700, coolDownOffset: 700),
                        new Shoot(9, projectileIndex: 3, coolDown: 700, coolDownOffset: 700),
                        new TimedTransition(3800, "if_cloaked2")
                        ),
                    new State("if_cloaked2",
                        new Shoot(10, projectileIndex: 4, count: 15, shootAngle: 24, fixedAngle: 8, coolDown: 1500,
                            coolDownOffset: 400),
                        new TimedTransition(10000, "idle"),
                        new PlayerWithinTransition(10.5, "idle")
                        ),
                    new Taunt(0.7, 10000, "I will floss with your tendons!",
                        "I smell the blood of an Englishman!",
                        "I will suck the marrow from your bones!",
                        "You will be my food, {PLAYER}!",
                        "Blargh!!",
                        "Leave my castle!",
                        "More wine!"
                        ),
                    new StayCloseToSpawn(1.2, 5),
                    new Spawn("Cyclops", 5, coolDown: 10000),
                    new Spawn("Cyclops Warrior", 5, coolDown: 10000),
                    new Spawn("Cyclops Noble", 5, coolDown: 10000),
                    new Spawn("Cyclops Prince", 5, coolDown: 10000),
                    new Spawn("Cyclops King", 5, coolDown: 10000)
                    ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Dice of the Royals", 0.0005),
                new ItemLoot("Mask of Thunders", 0.0005),
                new ItemLoot("General's Greatsword", 0.004),
                new ItemLoot("Wall of Gore", 0.004),
                new ItemLoot("Vest of Doomed Souls", 0.004),
                new ItemLoot("Shadowsteel Plate", 0.005),
                new ItemLoot("Colossal Skull", 0.01),
                new ItemLoot("Throwing Spear", 0.01),
                new ItemLoot("Bracelet of the Demolished", 0.01),
                new ItemLoot("Final Hour", 0.05),
                new ItemLoot("Tome of Purification", 0.05),
                new ItemLoot("St. Abraham's Wand", 0.08),
                new ItemLoot("Bone Dagger", 0.08),
                new ItemLoot("Chasuble of Holy Light", 0.1),
                new ItemLoot("Ring of Divine Faith", 0.1),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.15),
                new ItemLoot("Potion of Attack", 0.7),
                new ItemLoot("Potion of Defense", 0.7),
                new ItemLoot("Potion of Speed", 0.7),
                new TierLoot(7, ItemType.Weapon, 0.15),
                new TierLoot(8, ItemType.Weapon, 0.15),
                new TierLoot(3, ItemType.Ability, 0.17),
                new TierLoot(4, ItemType.Ability, 0.17),
                new TierLoot(8, ItemType.Armor, 0.12),
                new TierLoot(9, ItemType.Armor, 0.12),
                new TierLoot(3, ItemType.Ring, 0.13),
                new TierLoot(4, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Cyclops",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(1.2, 5),
                        new Follow(1.2, range: 1),
                        new Wander(0.4)
                        ),
                    new Shoot(3)
                    ),
                new ItemLoot("Golden Sword", 0.02),
                new ItemLoot("Studded Leather Armor", 0.02),
                new ItemLoot("Health Potion", 0.05)
            )
            .Init("Cyclops Warrior",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(1.2, 5),
                        new Follow(1.2, range: 1),
                        new Wander(0.4)
                        ),
                    new Shoot(3)
                    ),
                new ItemLoot("Golden Sword", 0.03),
                new ItemLoot("Golden Shield", 0.02),
                new ItemLoot("Health Potion", 0.05)
            )
            .Init("Cyclops Noble",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(1.2, 5),
                        new Follow(1.2, range: 1),
                        new Wander(0.4)
                        ),
                    new Shoot(3)
                    ),
                new ItemLoot("Golden Dagger", 0.02),
                new ItemLoot("Studded Leather Armor", 0.02),
                new ItemLoot("Health Potion", 0.05)
            )
            .Init("Cyclops Prince",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(1.2, 5),
                        new Follow(1.2, range: 1),
                        new Wander(0.4)
                        ),
                    new Shoot(3)
                    ),
                new ItemLoot("Mithril Dagger", 0.02),
                new ItemLoot("Plate Mail", 0.02),
                new ItemLoot("Seal of the Divine", 0.01),
                new ItemLoot("Health Potion", 0.05)
            )
            .Init("Cyclops King",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(1.2, 5),
                        new Follow(1.2, range: 1),
                        new Wander(0.4)
                        ),
                    new Shoot(3)
                    ),
                new ItemLoot("Golden Sword", 0.02),
                new ItemLoot("Mithril Armor", 0.02),
                new ItemLoot("Health Potion", 0.05)
            )
            ;
    }
}
