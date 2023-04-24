using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ UndeadLair = () => Behav()
            .Init("Septavius the Ghost God",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(8, "LeWait")
                    ),
                    new State("LeWait",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x0000FF0C, 0.5, 4),
                        new TimedTransition(2000, "SpawnTime")
                    ),
                    new State("SpawnTime",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Spawn("Ghost Warrior of Septavius", 4, 0.8),
                            new Spawn("Ghost Mage of Septavius", 4, 0.8),
                            new Spawn("Ghost Rogue of Septavius", 4, 0.8),
                            new TimedTransition(0, "NewCycle")
                    ),
                    new State("NewCycle",
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 45, coolDown: 900000, coolDownOffset: 0),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 49, coolDown: 900000, coolDownOffset: 200),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 53, coolDown: 900000, coolDownOffset: 400),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 57, coolDown: 900000, coolDownOffset: 600),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 61, coolDown: 900000, coolDownOffset: 800),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 65, coolDown: 900000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 69, coolDown: 900000, coolDownOffset: 1200),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 73, coolDown: 900000, coolDownOffset: 1400),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 77, coolDown: 900000, coolDownOffset: 1600),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 81, coolDown: 900000, coolDownOffset: 1800),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 85, coolDown: 900000, coolDownOffset: 2000),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 89, coolDown: 900000, coolDownOffset: 2200),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 93, coolDown: 900000, coolDownOffset: 2400),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 97, coolDown: 900000, coolDownOffset: 2600),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 101, coolDown: 900000, coolDownOffset: 2800),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 105, coolDown: 900000, coolDownOffset: 3000),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 109, coolDown: 900000, coolDownOffset: 3200),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 113, coolDown: 900000, coolDownOffset: 3400),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 117, coolDown: 900000, coolDownOffset: 3600),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 121, coolDown: 900000, coolDownOffset: 3800),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 125, coolDown: 900000, coolDownOffset: 4000),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 129, coolDown: 900000, coolDownOffset: 4200),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 133, coolDown: 900000, coolDownOffset: 4400),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 137, coolDown: 900000, coolDownOffset: 4600),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 141, coolDown: 900000, coolDownOffset: 4800),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 145, coolDown: 900000, coolDownOffset: 5000),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 149, coolDown: 900000, coolDownOffset: 5200),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 153, coolDown: 900000, coolDownOffset: 5400),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 157, coolDown: 900000, coolDownOffset: 5600),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 161, coolDown: 900000, coolDownOffset: 5800),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 165, coolDown: 900000, coolDownOffset: 6000),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 169, coolDown: 900000, coolDownOffset: 6200),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 173, coolDown: 900000, coolDownOffset: 6400),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 177, coolDown: 900000, coolDownOffset: 6600),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 181, coolDown: 900000, coolDownOffset: 6800),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 185, coolDown: 900000, coolDownOffset: 7000),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 189, coolDown: 900000, coolDownOffset: 7200),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 193, coolDown: 900000, coolDownOffset: 7400),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 197, coolDown: 900000, coolDownOffset: 7600),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 201, coolDown: 900000, coolDownOffset: 7800),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 205, coolDown: 900000, coolDownOffset: 8000),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 72, fixedAngle: 209, coolDown: 900000, coolDownOffset: 8200),
                        new Shoot(12, projectileIndex: 4, count: 12, shootAngle: 30, coolDown: 1200, coolDownOffset: 400),
                        new TimedTransition(8200, "QuietPhase"),
                        new HpLessTransition(.45, "Invuln")
                    ),
                    new State("QuietPhase",
                        new Wander(0.25),
                        new Shoot(15, count: 12, shootAngle: 14, projectileIndex: 1, coolDown: 700, coolDownOffset: 200),
                        new Shoot(15, count: 3, shootAngle: 10, predictive: 0.4, projectileIndex: 3, coolDown: 200),
                        new HpLessTransition(.45, "Invuln")
                    ),
                    new State("Invuln",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x0000FF0C, 0.5, 4),
                        new Wander(0.3),
                        new TimedTransition(2500, "SpawnTimeTwo")
                    ),
                    new State("SpawnTimeTwo",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Spawn("Ghost Warrior of Septavius", 3, 0.8),
                            new Spawn("Ghost Mage of Septavius", 3, 0.8),
                            new Spawn("Ghost Rogue of Septavius", 3, 0.8),
                            new TimedTransition(0, "Chase")
                    ),
                    new State("Chase",
                        new Follow(.4, 8, 1),
                        new Shoot(12, count: 3, shootAngle: 15, predictive: 0.1, projectileIndex: 0, coolDown: 400, coolDownOffset: 400),
                        new Shoot(10, projectileIndex: 4, count: 10, shootAngle: 36, coolDown: 800)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("The Realmdex", 0.0001),
                new ItemLoot("Boneshatter", 0.004),
                new ItemLoot("Ectoplasm Blade", 0.005),
                new ItemLoot("Soul Buster", 0.01),
                new ItemLoot("Soulkeeper", 0.01),
                new ItemLoot("Mercy of Yazanahar", 0.01),
                new ItemLoot("Shattered War Axe", 0.01),
                new ItemLoot("Spectral Armor", 0.04),
                new ItemLoot("Ghostly Disguise", 0.05),
                new ItemLoot("Doom Bow", 0.04),
                new ItemLoot("The Necronomicon", 0.05),
                new ItemLoot("Bow of the Morning Star", 0.02),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.1),
                new ItemLoot("Potion of Wisdom", 1.0),
                new ItemLoot("Potion of Wisdom", 0.8),
                new ItemLoot("Potion of Attack", 0.25),
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
            .Init("Ghost Warrior of Septavius",
                new State(
                    new Shoot(8, coolDown: 800),
                    new State("Follow",
                        new Prioritize(
                            new Wander(0.2),
                            new Protect(1, "Septavius the Ghost God", protectionRange: 1, reprotectRange: 2)
                        )
                    ),
                    new State("Wander",
                        new Wander(0.3)
                    )
                ),
                new ItemLoot("Health Potion", 0.2),
                new ItemLoot("Magic Potion", 0.2)
            )
            .Init("Ghost Mage of Septavius",
                new State(
                    new Shoot(14, coolDown: 1200),
                    new State("Follow",
                        new Prioritize(
                            new Wander(0.2),
                            new Protect(1, "Septavius the Ghost God", protectionRange: 1, reprotectRange: 2)
                        )
                    ),
                    new State("Wander",
                        new Wander(0.3)
                    )
                ),
                new ItemLoot("Health Potion", 0.2),
                new ItemLoot("Magic Potion", 0.2)
            )
            .Init("Ghost Rogue of Septavius",
                new State(
                    new Shoot(10, coolDown: 1000),
                    new State("Follow",
                        new Prioritize(
                            new Wander(0.2),
                            new Protect(1, "Septavius the Ghost God", protectionRange: 1, reprotectRange: 2)
                        )
                    ),
                    new State("Wander",
                        new Wander(0.3)
                    )
                ),
                new ItemLoot("Health Potion", 0.2),
                new ItemLoot("Magic Potion", 0.2)
            )
            .Init("Lair Burst Trap",
                new State(
                    new PlayerWithinTransition(2, "BOOM"),
                    new State("BOOM",
                        new Shoot(10, shootAngle: 45, count: 8, projectileIndex: 0, fixedAngle: 0, coolDown: 9999),
                        new Suicide()
                    )
                )
            )
            .Init("Lair Blast Trap",
                new State(
                    new PlayerWithinTransition(2, "BOOM"),
                    new State("BOOM",
                        new Shoot(8, shootAngle: 18, count: 6, projectileIndex: 0, coolDown: 9999),
                        new Suicide()
                    )
                )
            )
        .Init("Lair Ghost Bat",
            new State(
              new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(10, "Follow")
                  ),
              new State("Follow",
                new NoPlayerWithinTransition(11, "Wander"),
                new Follow(5.0, 10, coolDown: 0),
                  new Shoot(10, projectileIndex: 0, coolDown: 3000)
                  )))
                .Init("Lair Grey Spectre",
                   new State(
                   new Wander(0.4),
                    new Grenade(4, 50, 8, coolDown: 1000),
                    new Shoot(10, projectileIndex: 0, coolDown: 1000)
                       ))
                .Init("Lair Blue Spectre",
                    new State(
                        new Wander(0.4),
                    new Grenade(4, 70, 8, coolDown: 1000),
                    new Shoot(10, projectileIndex: 0, coolDown: 1000)
                        ))
                   .Init("Lair White Spectre",
                     new State(
                    new Wander(0.4),
                    new Grenade(4, 140, 8, coolDown: 1000),
                    new Shoot(10, projectileIndex: 0, coolDown: 1000)
                         ))
                .Init("Lair Skeleton",
                       new State(
                           new State("Wander",
                           new Wander(0.4),
                           new PlayerWithinTransition(5, "Follow")
                           ),
                       new State("Follow",
                          new Shoot(10, projectileIndex: 0, coolDown: 1000),
                           new NoPlayerWithinTransition(11, "Wander"),
                             new Follow(1.0, 10, coolDown: 0)
                           )))
        .Init("Lair Skeleton King",
            new State(
                new State("Wander",
                new PlayerWithinTransition(5, "Follow"),
                new Wander(0.4)
                    ),
                new State("Follow",
                    new NoPlayerWithinTransition(11, "Wander"),
                    new Shoot(10, count: 3, projectileIndex: 0, coolDown: 1000),
                    new Follow(1.0, 10, coolDown: 0)
                    )))
        .Init("Lair Skeleton Mage",
            new State(
                new State("Wander",
                    new PlayerWithinTransition(5, "Follow"),
                    new Wander(0.4)
                    ),
                new State("Follow",
                    new NoPlayerWithinTransition(11, "Wander"),
                    new Follow(1.0, 10, coolDown: 0),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1000)
                    )))
        .Init("Lair Skeleton Swordsman",
            new State(
                new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(5, "Follow")
                    ),
                new State("Follow",
                    new Follow(1.0, 10, coolDown: 0),
                    new Shoot(10, projectileIndex: 0, coolDown: 1),
                    new NoPlayerWithinTransition(11, "Wander")
                    )))
        .Init("Lair Skeleton Veteran",
            new State(
                new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(5, "Follow")
                    ),
                new State("Follow",
                    new NoPlayerWithinTransition(11, "Wander"),
                    new Shoot(10, projectileIndex: 0, coolDown: 1000),
                    new Follow(1.0, 10, coolDown: 0)
                    )))
        .Init("Lair Mummy",
            new State(
                new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(5, "Follow")
                    ),
                new State("Follow",
                    new NoPlayerWithinTransition(11, "Wander"),
                    new Shoot(10, projectileIndex: 0, coolDown: 1000),
                    new Follow(1.0, 10, coolDown: 0)
                      )))
        .Init("Lair Mummy King",
            new State(
                new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(5, "Follow")
                    ),
                new State("Follow",
                    new NoPlayerWithinTransition(11, "Wander"),
                    new Shoot(10, projectileIndex: 0, coolDown: 1000),
                    new Follow(1.0, 10, coolDown: 0)
                      )))
        .Init("Lair Mummy Pharaoh",
            new State(
                new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(5, "Follow")
                    ),
                new State("Follow",
                    new NoPlayerWithinTransition(11, "Wander"),
                    new Shoot(10, projectileIndex: 0, coolDown: 1000),
                    new Follow(1.0, 10, coolDown: 0)
                    )))
        .Init("Lair Big Brown Slime",
            new State(
                new Wander(0.4),
                    new TransformOnDeath("Lair Little Brown Slime"),
                    new TransformOnDeath("Lair Little Brown Slime"),
                    new TransformOnDeath("Lair Little Brown Slime"),
                new Shoot(10, count: 3, coolDown: 500)
           // new TransformOnDeath("Lair Little Brown Slime", min: 5, max: 6, probability: 1, returnToSpawn: false)
           ))
        .Init("Lair Little Brown Slime",
            new State(
                new Wander(0.4),
                new Shoot(10, count: 3, coolDown: 500, coolDownOffset: 400)
                 ))
        .Init("Lair Big Black Slime",
            new State(
                new Wander(0.4),
                new TransformOnDeath("Lair Medium Black Slime"),
                new TransformOnDeath("Lair Medium Black Slime"),
                new Shoot(10, count: 1, coolDown: 500)
           //   new TransformOnDeath("Lair Medium Black Slime", min: 3, max: 4, probability: 1, returnToSpawn: false)
           ))
        .Init("Lair Medium Black Slime",
            new State(
                new Wander(0.4),
                new TransformOnDeath("Lair Little Black Slime"),
                new TransformOnDeath("Lair Little Black Slime"),
                //   new TransformOnDeath("Lair Small Black Slime", min: 5, max: 6, probability: 1, returnToSpawn: false),
                new Shoot(10, count: 1, coolDown: 500, coolDownOffset: 400)
                ))
        .Init("Lair Little Black Slime",
            new State(
                new Wander(0.4),
                new Shoot(10, count: 3, coolDown: 500, coolDownOffset: 400)
                ))
         .Init("Lair Construct Giant",
            new State(
                new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(5, "Follow")
                    ),
                new State("Follow",
                    new NoPlayerWithinTransition(11, "Wander"),
                    new Shoot(10, count: 3, projectileIndex: 0, coolDown: 1000),
                    new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000),
                    new Follow(1.0, 10, coolDown: 0)
                     )))
         .Init("Lair Construct Titan",
            new State(
                new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(5, "Follow")
                    ),
                new State("Follow",
                    new NoPlayerWithinTransition(11, "Wander"),
                    new Shoot(10, count: 3, projectileIndex: 0, coolDown: 1000),
                    new Shoot(10, count: 3, projectileIndex: 1, coolDown: 1000),
                    new Follow(1.0, 10, coolDown: 0)
                    )))
          .Init("Lair Brown Bat",
            new State(
              new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(10, "Follow")
                  ),
              new State("Follow",
                new NoPlayerWithinTransition(11, "Wander"),
                new Follow(5.0, 10, coolDown: 0),
                  new Shoot(10, projectileIndex: 0, coolDown: 3000)
                  )))
        .Init("Lair Reaper",
            new State(
                 new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(10, "Follow")
                  ),
              new State("Follow",
                new NoPlayerWithinTransition(11, "Wander"),
                new Follow(1.5, 10, coolDown: 0),
                  new Shoot(10, projectileIndex: 0, coolDown: 200)
                  )))
        .Init("Lair Vampire",
            new State(
                new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(10, "Follow")
                  ),
              new State("Follow",
                new NoPlayerWithinTransition(11, "Wander"),
                new Follow(1.5, 10, coolDown: 0),
                  new Shoot(10, projectileIndex: 0, coolDown: 500),
                  new Shoot(10, projectileIndex: 1, coolDown: 1000)
                    )))
        .Init("Lair Vampire King",
            new State(
                new State("Wander",
                    new Wander(0.4),
                    new PlayerWithinTransition(10, "Follow")
                  ),
              new State("Follow",
                new NoPlayerWithinTransition(11, "Wander"),
                new Follow(1.5, 10, coolDown: 0),
                  new Shoot(10, projectileIndex: 0, coolDown: 500),
                  new Shoot(10, projectileIndex: 1, coolDown: 1000)
                )));
    }
}