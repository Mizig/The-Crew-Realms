#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Phoenix = () => Behav()
            .Init("Phoenix Lord",
                new State(
                    new Shoot(10, 4, 7, predictive: 0.5, coolDown: 600),
                    new Prioritize(
                        new StayCloseToSpawn(0.3, 2),
                        new Wander(0.4)
                        ),
                    new SpawnGroup("Pyre", 16, coolDown: 5000),
                    new Taunt(0.7, 10000,
                        "Alas, {PLAYER}, you will taste death but once!",
                        "I have met many like you, {PLAYER}, in my thrice thousand years!",
                        "Purge yourself, {PLAYER}, in the heat of my flames!",
                        "The ashes of past heroes cover my plains!",
                        "Some die and are ashes, but I am ever reborn!"
                        ),
                    new TransformOnDeath("Phoenix Egg")
                    )
            )
            .Init("Birdman Chief",
                new State(
                    new Prioritize(
                        new Protect(0.5, "Phoenix Lord", 15, 10, 3),
                        new Follow(1, range: 9),
                        new Wander(0.5)
                        ),
                    new Shoot(10)
                    ),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Birdman",
                new State(
                    new Prioritize(
                        new Protect(0.5, "Phoenix Lord", 15, 11, 3),
                        new Follow(1, range: 7),
                        new Wander(0.5)
                        ),
                    new Shoot(10, predictive: 0.5)
                    ),
                new ItemLoot("Health Potion", 0.05)
            )
            .Init("Phoenix Egg",
                new State(
                    new State("shielded",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "unshielded")
                        ),
                    new State("unshielded",
                        new Flash(0xff0000, 1, 5000),
                        new State("grow",
                            new ChangeSize(20, 150),
                            new TimedTransition(800, "shrink")
                            ),
                        new State("shrink",
                            new ChangeSize(-20, 130),
                            new TimedTransition(800, "grow")
                            )
                        ),
                    new TransformOnDeath("Phoenix Reborn")
                    )
            )
            .Init("Phoenix Reborn",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(0.9, 5),
                        new Wander(0.9)
                        ),
                    new SpawnGroup("Pyre", 4, coolDown: 1000),
                    new State("born_anew",
                        new Shoot(10, projectileIndex: 0, count: 12, shootAngle: 30, fixedAngle: 10, coolDown: 100000,
                            coolDownOffset: 500),
                        new Shoot(10, projectileIndex: 0, count: 12, shootAngle: 30, fixedAngle: 25, coolDown: 100000,
                            coolDownOffset: 1000),
                        new TimedTransition(1800, "xxx")
                        ),
                    new State("xxx",
                        new Shoot(10, projectileIndex: 1, count: 4, shootAngle: 7, predictive: 0.5, coolDown: 600),
                        new TimedTransition(2800, "yyy")
                        ),
                    new State("yyy",
                        new Shoot(10, projectileIndex: 0, count: 12, shootAngle: 30, fixedAngle: 10, coolDown: 100000,
                            coolDownOffset: 500),
                        new Shoot(10, projectileIndex: 0, count: 12, shootAngle: 30, fixedAngle: 25, coolDown: 100000,
                            coolDownOffset: 1000),
                        new Shoot(10, projectileIndex: 1, predictive: 0.5, coolDown: 350),
                        new TimedTransition(4500, "xxx")
                        )
                    ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Primal Flame", 0.004),
                new ItemLoot("Face of Hades", 0.004),
                new ItemLoot("Firestorm", 0.005),
                new ItemLoot("Staff of Demonic Power", 0.01),
                new ItemLoot("Wheel of Flames", 0.01),
                new ItemLoot("Hellfire Orb", 0.01),
                new ItemLoot("Ring of Solar Focus", 0.01),
                new ItemLoot("Phoenix Ashes", 0.05),
                new ItemLoot("The Scorched Armor", 0.05),
                new ItemLoot("Prism of Dancing Swords", 0.05),
                new ItemLoot("Staff of the Rising Sun", 0.05),
                new ItemLoot("Ring of the Burning Sun", 0.05),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.15),
                new ItemLoot("Potion of Dexterity", 0.6),
                new ItemLoot("Potion of Speed", 0.5),
                new ItemLoot("Potion of Vitality", 0.4),
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
            ;
    }
}