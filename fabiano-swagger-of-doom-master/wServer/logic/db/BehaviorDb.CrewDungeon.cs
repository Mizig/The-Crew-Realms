using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ CrewDungeon = () => Behav()
            .Init("The Crew Spawner",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("WaitForPlayer",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(10, "Timer")
                    ),
                    new State("Timer",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(5000, "Spawn1Wait")
                    ),
                    new State("Spawn1Wait",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("Spawning the next boss in 3 seconds."),
                        new TimedTransition(3000, "Spawn1")
                    ),
                    new State("Spawn1",
                        new Spawn("Glaceon", coolDown: 2500, maxChildren: 1, initialSpawn: 1),
                        new TimedTransition(400, "WaitForDead1")
                    ),
                    new State("WaitForDead1",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Glaceon", 40, "Spawn2Wait")
                    ),
                    new State("Spawn2Wait",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("Spawning the next boss in 10 seconds."),
                        new TimedTransition(10000, "Spawn2")
                    ),
                    new State("Spawn2",
                        new Spawn("Quibbley", coolDown: 2500, maxChildren: 1, initialSpawn: 1),
                        new TimedTransition(400, "WaitForDead2")
                    ),
                    new State("WaitForDead2",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Quibbley", 40, "Spawn3Wait")
                    ),
                    new State("Spawn3Wait",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("Spawning the next boss in 10 seconds."),
                        new TimedTransition(10000, "Spawn3")
                    ),
                    new State("Spawn3",
                        new Spawn("Akari", coolDown: 2500, maxChildren: 1, initialSpawn: 1),
                        new TimedTransition(400, "WaitForDead3")
                    ),
                    new State("WaitForDead3",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Akari", 40, "Finished")
                    ),
                    new State("Finished",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("Congratulations, you have reached the end of the crew dungeon..."),
                        new TimedTransition(3000, "Finished2")
                    ),
                    new State("Finished2",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("...For now.")
                    )
                )
            )
            .Init("Glaceon",
                new State(
                    new State("Talk",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("You should not have entered my chamber."),
                        new Flash(0x1E83FF, 1, 10),
                        new TimedTransition(2000, "Talk2")
                    ),
                    new State("Talk2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Wander(0.1),
                        new Taunt("I will guard the rest of the crew from your filthy hands!"),
                        new Flash(0x1E83FF, 1, 10),
                        new TimedTransition(2000, "Fight")
                    ),
                    new State("Fight",
                        new Wander(0.4),
                        new Follow(0.2, 8, 4),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 10, predictive: 0.4, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(25, projectileIndex: 0, count: 2, shootAngle: 90, predictive: 0.4, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(25, projectileIndex: 1, count: 20, shootAngle: 18, fixedAngle: 11, coolDown: 2400, coolDownOffset: 200),
                        new Shoot(25, projectileIndex: 1, count: 20, shootAngle: 18, fixedAngle: 20, coolDown: 2400, coolDownOffset: 1400),
                        new HpLessTransition(.1, "GN")
                    ),
                    new State("GN",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Well played."),
                        new TimedTransition(2000, "Suicide")
                    ),
                    new State("Suicide",
                        new Suicide()
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Snow's Edge", 0.003),
                new ItemLoot("Winter Mountain Orb", 0.003),
                new ItemLoot("Inuit Magic Robe", 0.003),
                new ItemLoot("Sheer Titanium Ornament", 0.003),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.4),
                new ItemLoot("Potion of Life", 1.0),
                new ItemLoot("Potion of Mana", 1.0),
                new ItemLoot("Potion of Wisdom", 1.0),
                new ItemLoot("Potion of Speed", 1.0),
                new TierLoot(10, ItemType.Weapon, 0.15),
                new TierLoot(11, ItemType.Weapon, 0.15),
                new TierLoot(12, ItemType.Weapon, 0.15),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(6, ItemType.Ability, 0.17),
                new TierLoot(11, ItemType.Armor, 0.12),
                new TierLoot(12, ItemType.Armor, 0.12),
                new TierLoot(13, ItemType.Armor, 0.12),
                new TierLoot(5, ItemType.Ring, 0.17),
                new TierLoot(6, ItemType.Ring, 0.05)
                )
            )
            .Init("Quibbley",
                new State(
                    new State("Talk",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("The best knight around"),
                        new Flash(0x1E83FF, 1, 10),
                        new TimedTransition(2000, "Talk2")
                    ),
                    new State("Talk2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Wander(0.1),
                        new Taunt("i'm always blinking :)"),
                        new Flash(0x1E83FF, 1, 10),
                        new TimedTransition(2000, "Fight")
                    ),
                    new State("Fight",
                        new Wander(0.1),
                        new Follow(0.3, 15, 1),
                        new Shoot(14, projectileIndex: 1, count: 1, shootAngle: 10, predictive: 0.3, coolDown: 400),
                        new Shoot(10, projectileIndex: 0, count: 6, shootAngle: 11, coolDown: 2000),
                        new HpLessTransition(.1, "GN")
                    ),
                    new State("GN",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Bro ate"),
                        new TimedTransition(2000, "Suicide")
                    ),
                    new State("Suicide",
                        new Suicide()
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Bunny's Slayer", 0.003),
                new ItemLoot("Buckler of the Bun", 0.003),
                new ItemLoot("Rabbit Wear", 0.003),
                new ItemLoot("Bunny Ears", 0.003),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.4),
                new ItemLoot("Potion of Life", 1.0),
                new ItemLoot("Potion of Attack", 1.0),
                new ItemLoot("Potion of Defense", 1.0),
                new ItemLoot("Potion of Vitality", 1.0),
                new TierLoot(10, ItemType.Weapon, 0.15),
                new TierLoot(11, ItemType.Weapon, 0.15),
                new TierLoot(12, ItemType.Weapon, 0.15),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(6, ItemType.Ability, 0.17),
                new TierLoot(11, ItemType.Armor, 0.12),
                new TierLoot(12, ItemType.Armor, 0.12),
                new TierLoot(13, ItemType.Armor, 0.12),
                new TierLoot(5, ItemType.Ring, 0.17),
                new TierLoot(6, ItemType.Ring, 0.05)
                )
            )
            .Init("Akari",
                new State(
                    new State("Talk",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(":3"),
                        new Flash(0x1E83FF, 1, 10),
                        new TimedTransition(2000, "Talk2")
                    ),
                    new State("Talk2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Wander(0.1),
                        new Taunt("time to defeat racism"),
                        new Flash(0x1E83FF, 1, 10),
                        new TimedTransition(2000, "Fight")
                    ),
                    new State("Fight",
                        new Wander(0.1),
                        new Follow(0.15, 10, 1),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 8, predictive: 0.9, coolDown: 800),
                        new Shoot(25, projectileIndex: 1, count: 12, shootAngle: 30, coolDown: 2200),
                        new HpLessTransition(.1, "GN")
                    ),
                    new State("GN",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("i will be seen again"),
                        new TimedTransition(2000, "Suicide")
                    ),
                    new State("Suicide",
                        new Suicide()
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.4),
                new ItemLoot("Potion of Mana", 1.0),
                new ItemLoot("Potion of Dexterity", 1.0),
                new ItemLoot("Potion of Vitality", 1.0),
                new ItemLoot("Potion of Wisdom", 1.0),
                new TierLoot(10, ItemType.Weapon, 0.15),
                new TierLoot(11, ItemType.Weapon, 0.15),
                new TierLoot(12, ItemType.Weapon, 0.15),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(6, ItemType.Ability, 0.17),
                new TierLoot(11, ItemType.Armor, 0.12),
                new TierLoot(12, ItemType.Armor, 0.12),
                new TierLoot(13, ItemType.Armor, 0.12),
                new TierLoot(5, ItemType.Ring, 0.17),
                new TierLoot(6, ItemType.Ring, 0.05)
                )
            )
            ;
    }
}