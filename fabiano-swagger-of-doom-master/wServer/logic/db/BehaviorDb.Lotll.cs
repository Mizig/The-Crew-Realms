using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using wServer.realm;
using wServer.realm.entities;
using wServer.realm.entities.player;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ LordOfTheLostLands = () => Behav()
            .Init("Lord of the Lost Lands",
                new State(
                    new DropPortalOnDeath("Lair of Light Portal", 100),
                    new HpLessTransition(0.05, "death"),
                    new State("waiting",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(10, "wander")
                        ),
                    new State("wander",
                        new SetAltTexture(0),
                        new Taunt("HALT!"),
                        new Wander(0.3),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(8, "beginning")
                        ),
                    new State("beginning",
                        new SetAltTexture(0),
                        new Taunt("YOU HAVE NO RIGHT TO TACKLE A MEMBER OF HIS ARMY!"),
                        new Wander(0.3),
                        new Shoot(12, count: 1, projectileIndex: 1, coolDown: 500),
                        new Shoot(12, count: 7, shootAngle: 7, coolDownOffset: 1000, angleOffset: 270, coolDown: 2000),
                        new Shoot(12, count: 7, shootAngle: 7, coolDownOffset: 1000, angleOffset: 90, coolDown: 2000),
                        new Shoot(12, count: 7, shootAngle: 7, coolDown: 2000),
                        new Shoot(12, count: 7, shootAngle: 7, angleOffset: 180, coolDown: 2000),
                        new TossObject("Guardian of the Lost Lands", 10, coolDown: 1500, randomToss: false),
                        new HpLessTransition(0.66, "shotgun")
                        ),
                    new State("shotgun",
                        new SetAltTexture(0),
                        new Follow(0.3, range: 1),
                        new Shoot(12, count: 3, shootAngle: 10, projectileIndex: 1, coolDown: 1000, coolDownOffset: 400),
                        new Shoot(12, count: 7, shootAngle: 7, coolDownOffset: 1000, angleOffset: 270, coolDown: 2000),
                        new Shoot(12, count: 7, shootAngle: 7, coolDownOffset: 1000, angleOffset: 90, coolDown: 2000),
                        new Shoot(12, count: 7, shootAngle: 7, coolDown: 2000),
                        new Shoot(12, count: 7, shootAngle: 7, angleOffset: 180, coolDown: 2000),
                        new TossObject("Guardian of the Lost Lands", 10, coolDown: 1500, randomToss: false),
                        new HpLessTransition(0.33, "crystalstart")
                        ),
                    new State("crystalstart",
                        new SetAltTexture(3),
                        new Taunt("GATHERING POWER!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1200, "crystalmid")
                        ),
                    new State("crystalmid",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Protection Crystal", 6, 90, coolDown: 9999999, randomToss: false),
                        new TossObject("Protection Crystal", 6, 270, coolDown: 9999999, randomToss: false),
                        new TimedTransition(2100, "checkforcrystals")
                        ),
                    new State("checkforcrystals",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Guardian of the Lost Lands", 10, coolDown: 2000, randomToss: false),
                        new EntitiesNotExistsTransition(9999, "final", "Protection Crystal")
                        ),
                    new State("final",
                        new SetAltTexture(0),
                        new Taunt("I MUST DEFEND OUR LANDS!"),
                        new Wander(0.3),
                        new Shoot(12, count: 1, projectileIndex: 1, predictive: 1, coolDown: 300),
                        new Shoot(12, count: 7, shootAngle: 7, coolDownOffset: 600, angleOffset: 270, coolDown: 1200),
                        new Shoot(12, count: 7, shootAngle: 7, coolDownOffset: 800, angleOffset: 90, coolDown: 1200),
                        new Shoot(12, count: 7, shootAngle: 7, coolDownOffset: 200, coolDown: 1200),
                        new Shoot(12, count: 7, shootAngle: 7, angleOffset: 180, coolDown: 1200),
                        new TossObject("Guardian of the Lost Lands", 10, coolDown: 1000, randomToss: false),
                        new HpLessTransition(0.05, "death")
                        ),
                    new State("death",
                        new Taunt("NOOOOOOOOOOOOOOO!"),
                        new SetAltTexture(3),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, true),
                        new Flash(0xFF0000, 0.2, 3),
                        new Shoot(25, count: 30, shootAngle: 12, fixedAngle: 0, projectileIndex: 0, coolDownOffset: 3800, coolDown: 99999),
                        new Shoot(25, count: 30, shootAngle: 12, fixedAngle: 4, projectileIndex: 1, coolDownOffset: 4000, coolDown: 99999),
                        new Shoot(25, count: 25, shootAngle: 15, fixedAngle: 9, projectileIndex: 2, coolDownOffset: 4200, coolDown: 99999),
                        new TimedTransition(4400, "dead")
                        ),
                    new State("dead",
                        new Suicide()
                        )
                    ),
                new Threshold(0.001,
                new ItemLoot("Lucky Slasher", 0.0005),
                new ItemLoot("Lightspeed Travel Cloak", 0.005),
                new ItemLoot("Thusala's Slasher", 0.004),
                new ItemLoot("Gravachrome", 0.004),
                new ItemLoot("Queen's Crown", 0.01),
                new ItemLoot("Garbs of the Frozen Queen", 0.01),
                new ItemLoot("Shield of Ogmur", 0.04),
                new ItemLoot("Path of Loot Key", 0.00025),
                new ItemLoot("Potion of Life", 0.5),
                new ItemLoot("Potion of Mana", 0.5),
                new ItemLoot("Potion of Attack", 1.0),
                new ItemLoot("Potion of Defense", 1.0),
                new ItemLoot("Greater Potion of Speed", 1.0),
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
                new TierLoot(6, ItemType.Ring, 0.1),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Protection Crystal",
                new State(
                    new Shoot(8.4, count: 4, projectileIndex: 0, shootAngle: 11, coolDown: 600),
                    new State("Begin",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2500, "Twirl1")
                        ),
                    new State("Twirl1",
                        new Shoot(20, count: 1, projectileIndex: 1, fixedAngle: 0, coolDown: 1000),
                        new TimedTransition(100, "Twirl2")
                        ),
                    new State("Twirl2",
                        new Shoot(20, count: 1, projectileIndex: 1, fixedAngle: 45, coolDown: 1000),
                        new TimedTransition(100, "Twirl3")
                        ),
                    new State("Twirl3",
                        new Shoot(20, count: 1, projectileIndex: 1, fixedAngle: 90, coolDown: 1000),
                        new TimedTransition(100, "Twirl4")
                        ),
                    new State("Twirl4",
                        new Shoot(20, count: 1, projectileIndex: 1, fixedAngle: 135, coolDown: 1000),
                        new TimedTransition(100, "Twirl5")
                        ),
                    new State("Twirl5",
                        new Shoot(20, count: 1, projectileIndex: 1, fixedAngle: 180, coolDown: 1000),
                        new TimedTransition(100, "Twirl6")
                        ),
                    new State("Twirl6",
                        new Shoot(20, count: 1, projectileIndex: 1, fixedAngle: 225, coolDown: 1000),
                        new TimedTransition(100, "Twirl7")
                        ),
                    new State("Twirl7",
                        new Shoot(20, count: 1, projectileIndex: 1, fixedAngle: 270, coolDown: 1000),
                        new TimedTransition(100, "Twirl8")
                        ),
                    new State("Twirl8",
                        new Shoot(20, count: 1, projectileIndex: 1, fixedAngle: 315, coolDown: 1000),
                        new TimedTransition(100, "Twirl1")
                        )
                    )
            )
            .Init("Guardian of the Lost Lands",
                new State(
                    new State("Tough",
                        new Follow(0.35, 8, 1),
                        new Spawn("Knight of the Lost Lands", initialSpawn: 1, maxChildren: 1),
                        new Shoot(8.4, count: 6, shootAngle: 60, projectileIndex: 1, coolDown: 2000),
                        new Shoot(8.4, count: 6, projectileIndex: 0, coolDown: 1300),
                        new HpLessTransition(0.35, "Scrub")
                        ),
                    new State("Scrub",
                        new StayBack(0.75, 5),
                        new Shoot(8.4, count: 6, shootAngle: 60, projectileIndex: 1, coolDown: 2000),
                        new Shoot(8.4, count: 5, projectileIndex: 0, coolDown: 1300)
                        )
                ),
                new ItemLoot("Health Potion", 0.09),
                new ItemLoot("Magic Potion", 0.09)
            )
            .Init("Knight of the Lost Lands",
                new State(
                    new State("Fighting",
                        new Follow(0.4, 8, 1),
                        new Shoot(8.4, count: 3, shootAngle: 12, projectileIndex: 0, coolDown: 1500)
                        )
                    ),
                new ItemLoot("Health Potion", 0.06),
                new ItemLoot("Magic Potion", 0.06)
            );
    }
}
