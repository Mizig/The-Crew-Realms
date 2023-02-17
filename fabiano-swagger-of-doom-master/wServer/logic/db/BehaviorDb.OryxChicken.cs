﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.transitions;
using wServer.logic.loot;
using wServer.logic.behaviors;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ OryxChicken = () => Behav()
            .Init("Test Egg",
                new State(
                    new State("Idle",
                        new HpLessTransition(630000, "1")
                    ),
                    new State("1",
                        new HpLessTransition(610000, "2"),
                        new SetAltTexture(1)
                    ),
                    new State("2",
                        new HpLessTransition(590000, "3"),
                        new SetAltTexture(2)
                    ),
                    new State("3",
                        new HpLessTransition(570000, "4"),
                        new SetAltTexture(3)
                    ),
                    new State("4",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new SetAltTexture(4),
                        new TimedTransition(250, "Break")
                    ),
                    new State("Break",
                        new Transform("TestChicken 2")
                    )
                )
            )
            .Init("TestChicken 2",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(0.6, 5),
                        new Wander(0.6)
                    ),
                    new State("Idle",
                        new ChangeSize(20, 100),
                        new TimedTransition(600, "Start")
                    ),
                    new State("Start",
                        new Taunt("CLUCK!"),
                        new State("Shoot",
                            new EntityNotExistsTransition("TestChicken Small", 10, "Spawn Minions"),
                            new Shoot(10, 2)
                        ),
                        new State("Spawn Minions",
                            new Spawn("TestChicken Small", 3, 1),
                            new TimedTransition(0, "Shoot")
                        )
                    ),
                    new State("Death",
                        new Shoot(100, 10, projectileIndex: 6),
                        new Suicide()
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Purity", 0.0005),
                new ItemLoot("Claw of the Beast", 0.004),
                new ItemLoot("Cosmic Cortex", 0.004),
                new ItemLoot("Grey Belt", 0.01),
                new ItemLoot("Rabbit's Foot", 0.01),
                new ItemLoot("Anatis Staff", 0.01),
                new ItemLoot("Chicken Leg of Doom", 0.01),
                new ItemLoot("Cheater Robe", 0.01),
                new ItemLoot("Cheater Light Armor", 0.01),
                new ItemLoot("Cheater Heavy Armor", 0.01),
                new ItemLoot("Useless Katana", 0.01),
                new ItemLoot("Toy Knife", 0.01),
                new ItemLoot("Precisely Calibrated Stringstick", 0.01),
                new ItemLoot("Barely Attuned Magic Thingy", 0.01),
                new ItemLoot("Lethargic Sentience", 0.01),
                new ItemLoot("Unstable Anomaly", 0.01),
                new ItemLoot("Sunshine Shiv", 0.01),
                new ItemLoot("Robobow", 0.01),
                new ItemLoot("Spicy Wand of Spice", 0.01),
                new ItemLoot("KoalaPOW", 0.01),
                new ItemLoot("Doctor Swordsworth", 0.01),
                new ItemLoot("Arbiter's Wrath", 0.01),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Potion of Life", 1.0),
                new ItemLoot("Potion of Mana", 1.0),
                new ItemLoot("Potion of Defense", 0.4),
                new ItemLoot("Potion of Attack", 0.4),
                new ItemLoot("Potion of Speed", 0.4),
                new ItemLoot("Potion of Dexterity", 0.4),
                new ItemLoot("Potion of Vitality", 0.2),
                new ItemLoot("Potion of Wisdom", 0.2),
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
                new EggLoot(EggRarity.Common, 0.20),
                new EggLoot(EggRarity.Uncommon, 0.10),
                new EggLoot(EggRarity.Rare, 0.05),
                new EggLoot(EggRarity.Legendary, 0.005)
                )
            )
            .Init("TestChicken Small",
                new State(
                    new Prioritize(
                        new Protect(0.6, "TestChicken 2"),
                        new Wander(0.6)
                    ),
                    new State("Default",
                        new Shoot(10, 8, projectileIndex: 2, coolDown: 1000)
                    ),
                    new State("Despawn",
                        new Suicide()
                    )
                )
            );
    }
}
