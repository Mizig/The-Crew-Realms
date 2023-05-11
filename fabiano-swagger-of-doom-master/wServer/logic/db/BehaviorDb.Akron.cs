using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Akron = () => Behav()
            .Init("Akron Magma Spawner",
                new State(
                    new OnDeathBehavior(new ApplySetpiece("AkronMagma")),
                    new State("Default",
                        new Suicide()
                    )
                )
            )
            .Init("Akron Helper",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("WaitingForHeal",
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                    ),
                    new State("Heal",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Heal(15, "Heros", 200),
                        new TimedTransition(400, "Finished")
                    ),
                    new State("Finished",
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                    )
                )
            )
            .Init("Akron Worm",
                new State(
                    new State("Wait",
                        new Wander(0.15),
                        new TimedTransition(1000, "Worming")
                    ),
                    new State("Worming",
                        new Wander(0.25),
                        new Follow(0.2, 10, 1),
                        new Shoot(25, projectileIndex: 0, count: 1, fixedAngle: 60, coolDown: 1200),
                        new Shoot(25, projectileIndex: 0, count: 1, fixedAngle: 180, coolDown: 1200, coolDownOffset: 400),
                        new Shoot(25, projectileIndex: 0, count: 1, fixedAngle: 300, coolDown: 1200, coolDownOffset: 800),
                        new Shoot(25, projectileIndex: 1, count: 1, coolDown: 200)
                    )
                )
            )
            .Init("Akron, Ancient Deity",
                new State(
                    new State("WaitToStart",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(5, "SpawnHelper")
                    ),
                    new State("SpawnHelper",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new InvisiToss("Akron Helper", 0, 0, 90000, coolDownOffset: 0),
                        new TimedTransition(0, "StartTalk1")
                    ),
                    new State("StartTalk1",
                        new Taunt("..."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(3000, "StartTalk2")
                    ),
                    new State("StartTalk2",
                        new Taunt("Ah, it is them who have awoken me. Let us see if they are worthy to stand before me."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(3000, "StartTalk3")
                    ),
                    new State("StartTalk3",
                        new Taunt("For billions of years I have lived. I have in my memory the early days of this planet. When Earth was but rock and fire. Before other life had even begun to evolve."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(3000, "FirestormHeal")
                    ),
                    new State("FirestormHeal",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Order(46, "Akron Helper", "Heal"),
                        new TimedTransition(200, "Firestorm")
                    ),
                    new State("Firestorm",
                        new Taunt("Perhaps I existed long before even that, but I am unable to recollect further into history."),
                        new Shoot(25, projectileIndex: 0, count: 15, shootAngle: 24, coolDown: 1800),
                        new Shoot(25, projectileIndex: 2, count: 20, shootAngle: 18, fixedAngle: 20, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 1, count: 12, shootAngle: 30, predictive: 0.5, coolDown: 1000, coolDownOffset: 400),
                        new Shoot(25, projectileIndex: 2, count: 7, shootAngle: 9, predictive: 0.9, coolDown: 1200, coolDownOffset: 600),
                        new Shoot(25, projectileIndex: 0, count: 6, shootAngle: 32, predictive: 0.5, coolDown: 1800, coolDownOffset: 600),
                        new Shoot(25, projectileIndex: 1, count: 4, shootAngle: 15, coolDown: 200, coolDownOffset: 200),
                        new TossObject("shtrs FireBomb", 25, coolDown: 2600),
                        new HpLessTransition(.85, "WormsSpawn"),
                        new TimedTransition(25000, "FirestormStagger")
                    ),
                    new State("FirestormStagger",
                        new Flash(0x1E83FF, 1, 10), //blue flash
                        new HpLessTransition(.85, "WormsSpawn")
                    ),
                    new State("WormsSpawn",
                        new Taunt("I have lost all memory of the world from which I came."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Akron Worm", 7, 45, 9999, coolDownOffset: 1000),
                        new TossObject("Akron Worm", 7, 135, 9999, coolDownOffset: 1000),
                        new TossObject("Akron Worm", 7, 225, 9999, coolDownOffset: 1000),
                        new TossObject("Akron Worm", 7, 315, 9999, coolDownOffset: 1000),
                        new TimedTransition(2400, "WormsWait")
                    ),
                    new State("WormsWait",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Akron Worm", 99, "WormsStagger")
                    ),
                    new State("WormsStagger",
                        new Flash(0x1E83FF, 1, 10), //blue flash
                        new HpLessTransition(.70, "IcestrikeWait")
                    ),
                    new State("IcestrikeWait",
                        new Taunt("Countless times I have been weakened and enslaved. Yet ultimately I remain, while my enemies succumb to the flow of time."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "Icestrike")
                    ),
                    new State("Icestrike",
                        //shot patterns
                        new TossObject("shtrs Ice Shield", 10, coolDown: 2800),
                        new HpLessTransition(.55, "VenomInvuln"),
                        new TimedTransition(25000, "IcestrikeStagger")
                    ),
                    new State("IcestrikeStagger",
                        new Flash(0x1E83FF, 1, 10), //blue flash
                        new HpLessTransition(.55, "VenomInvuln")
                    ),
                    new State("VenomInvuln",
                        new Taunt("I witnessed species evolve and head into eternal extinction. I wonder how long Man will survive?"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        //grenade patterns
                        new TimedTransition(8000, "VenomHittable")
                    ),
                    new State("VenomHittable",
                        //grenade patterns
                        new HpLessTransition(.4, "MagmaStartup"),
                        new TimedTransition(22000, "VenomStagger")
                    ),
                    new State("VenomStagger",
                        new Flash(0x1E83FF, 1, 10), //blue flash
                        new HpLessTransition(.4, "MagmaStartup")
                    ),
                    new State("MagmaStartup",
                        new Taunt("For aeons I have pondered the meaning of my existence. Alas, I am still unable to find my answer."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xFF0000, 1, 10), //red flash
                        new TimedTransition(1600, "MagmaThrow")
                    ),
                    new State("MagmaThrow",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Akron Magma Spawner", 1, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 2, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 2, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 3, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 3, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 3, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 4, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 4, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 4, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 4, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 5, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 5, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 5, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 5, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 5, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 6, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 6, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 6, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 6, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 7, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 7, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 7, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 7, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 8, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 8, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 8, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 8, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 9, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 9, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 9, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 9, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 10, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 10, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 10, coolDown: 25000, randomToss: true),
                        new TossObject("Akron Magma Spawner", 10, coolDown: 25000, randomToss: true),
                        new TimedTransition(3000, "MagmaWorm")
                    ),
                    new State("MagmaWorm",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Akron Worm", 4, 180, 9999),
                        new TimedTransition(2000, "MagmaShoot")
                    ),
                    new State("MagmaShoot",
                        new Shoot(25, projectileIndex: 0, count: 15, shootAngle: 24, coolDown: 1800),
                        new Shoot(25, projectileIndex: 2, count: 15, shootAngle: 24, fixedAngle: 20, coolDown: 1800, coolDownOffset: 650),
                        new Shoot(25, projectileIndex: 1, count: 12, shootAngle: 30, predictive: 0.5, coolDown: 1800, coolDownOffset: 1300),
                        new Shoot(25, projectileIndex: 2, count: 8, shootAngle: 15, predictive: 0.9, coolDown: 2000, coolDownOffset: 1800),
                        new Shoot(25, projectileIndex: 0, count: 3, shootAngle: 28, predictive: 0.7, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 1, count: 2, shootAngle: 0, predictive: 0.4, coolDown: 200, coolDownOffset: 200),
                        new HpLessTransition(.25, "HolyWait"),
                        new TimedTransition(20000, "MagmaStagger")
                    ),
                    new State("MagmaStagger",
                        new Flash(0x1E83FF, 1, 10), //blue flash
                        new HpLessTransition(.25, "HolyWait")
                    ),
                    new State("HolyWait",
                        new Flash(0x1E83FF, 1, 10) //blue flash
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.0001),
                new ItemLoot("True Shielding of Oryx", 0.000667),
                new ItemLoot("Robe of Oddish", 0.000667),
                new ItemLoot("Mari's Vest", 0.000667),
                new ItemLoot("Path of Loot Key", 0.25),
                new ItemLoot("Transformation Shard", 0.25),
                new ItemLoot("Red Bagston", 1.0),
                new ItemLoot("Backpack", 1.0),
                new ItemLoot("Gold Cache", 1.0),
                new ItemLoot("Gold Cache", 1.0),
                new ItemLoot("Gold Cache", 0.65)
                )
            )
            ;
    }
}