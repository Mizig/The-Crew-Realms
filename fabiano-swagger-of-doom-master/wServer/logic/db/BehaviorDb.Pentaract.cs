using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.logic.loot;
using wServer.logic.behaviors;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Pentaract = () => Behav()
            .Init("Pentaract",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Entry",
                        new PentaractStar(250),
                        new EntitiesNotExistsTransition(50, "Suicide", "Pentaract Tower"),
                        new State("EntryTimer",
                            new TimedTransition(20000, "RespawnTowers")
                        ),
                        new State("RespawnTowers",
                            new Order(50, "Pentaract Tower Corpse", "Respawn"),
                            new TimedTransition(0, "EntryTimer")
                        )
                    ),
                    new State("Suicide",
                        new Suicide()
                    )
                )
            )
            .Init("Pentaract Tower",
                new State(
                    new Spawn("Pentaract Eye", 5, 1),
                    new Shoot(20, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 800),
                    new Grenade(4, 130, 10, coolDown: 1000),
                    new TransformOnDeath("Pentaract Tower Corpse"),
                    new CopyDamageOnDeath("Pentaract Tower Corpse", 2)
                )
            )
            .Init("Pentaract Eye",
                new State(
                    new Swirl(5, 20, targeted: false),
                    new Shoot(10, coolDown: 200)
                )
            )
            .Init("Pentaract Tower Corpse",
                new State(
                    new DropPortalOnDeath("Crystal Cave Portal", 40),
                    new State("Entry",
                        new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                        new EntitiesNotExistsTransition(50, "Suicide", "Pentaract")
                    ),
                    new State("Respawn",
                        new Transform("Pentaract Tower")
                    ),
                    new State("Suicide",
                        new Suicide()
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("The Realm Eye", 0.00012),
                new ItemLoot("Nightmare Gem", 0.002),
                new ItemLoot("The Apex Bulwark", 0.002),
                new ItemLoot("Unholy Wand", 0.003),
                new ItemLoot("Pernicious Fate-36", 0.005),
                new ItemLoot("Skull of Ravagers", 0.005),
                new ItemLoot("Dirk of Notorious Agents", 0.005),
                new ItemLoot("Zol Wraps", 0.005),
                new ItemLoot("Force Between Avex", 0.005),
                new ItemLoot("Night Dice", 0.02),
                new ItemLoot("Unholy Short Sword", 0.02),
                new ItemLoot("Seal of Blasphemous Prayer", 0.02),
                new ItemLoot("Annoying Firecracker Katana", 0.03),
                new ItemLoot("Path of Loot Key", 0.00025),
                new ItemLoot("Transformation Shard", 0.0005),
                new ItemLoot("Gold Cache", 0.15),
                new ItemLoot("Potion of Life", 0.2),
                new ItemLoot("Potion of Mana", 0.2),
                new ItemLoot("Potion of Attack", 0.4),
                new ItemLoot("Potion of Defense", 0.4),
                new ItemLoot("Potion of Speed", 0.4),
                new ItemLoot("Potion of Dexterity", 0.4),
                new ItemLoot("Greater Potion of Vitality", 0.4),
                new ItemLoot("Potion of Wisdom", 0.4),
                new TierLoot(9, ItemType.Weapon, 0.07),
                new TierLoot(10, ItemType.Weapon, 0.07),
                new TierLoot(11, ItemType.Weapon, 0.07),
                new TierLoot(4, ItemType.Ability, 0.08),
                new TierLoot(5, ItemType.Ability, 0.08),
                new TierLoot(10, ItemType.Armor, 0.06),
                new TierLoot(11, ItemType.Armor, 0.06),
                new TierLoot(12, ItemType.Armor, 0.06),
                new TierLoot(4, ItemType.Ring, 0.06),
                new TierLoot(5, ItemType.Ring, 0.06),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            );
    }
}
