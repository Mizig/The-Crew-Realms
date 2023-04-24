using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ IceCave = () => Behav()
        .Init("Mini Yeti",
            new State(
                new State("idle",
                    new Orbit(1.0, 2, 10, "Big Yeti"),
                    new Shoot(10, 1, projectileIndex: 0, coolDown: 1000)
                    )
                )
            )
        .Init("Big Yeti",
            new State(
                new Follow(0.5, 10, 2, -1, 0),
                new State(";d",
                    new PlayerWithinTransition(10, "idle")
                    ),
                new State("idle",
                    new Spawn("Mini yeti", maxChildren: 3, initialSpawn: 0.5, coolDown: 10000),
                    new TimedTransition(1000, ":P")
                    ),
                new State(":P",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Flash(0xfFF0000, 1, 9000001),
                    new TimedTransition(2000, ":O")
                    ),
                new State(":O",
                    new Spawn("Mini yeti", maxChildren: 3, initialSpawn: 0.5, coolDown: 10000),
                    new Taunt(probability: 0.2, text: "BROOOOOOOOOOOOOOOOWR"),
                    new Taunt(probability: 0.2, text: "Mwruuuu!"),
                    new Taunt(probability: 0.2, text: "Mrr..."),
                    new Taunt(probability: 0.2, text: "BWEEE!"),
                    new Taunt(probability: 0.2, text: "mar...mar..."),
                    new TimedTransition(3000, ":P")
                    )
                )
            )
        .Init("Snow Bat Mama",
            new State(
                new Wander(1.0),
                new Follow(1.0, 1, 6, 0, coolDown: 100),
                new State(":P",
                    new Shoot(10, 1, projectileIndex: 0, coolDown: 2000),
                    new Shoot(10, 1, projectileIndex: 1, coolDown: 2000, coolDownOffset: 600),
                    new Shoot(10, 1, projectileIndex: 2, coolDown: 2000, coolDownOffset: 1200),
                    new Shoot(10, 1, projectileIndex: 3, coolDown: 2000, coolDownOffset: 1800),
                    new Spawn("Snow Bat", 3, 1.0, coolDown: 4000)
                    )
                )
            )
        .Init("Snow Bat",
            new State(
                new Wander(1.0),
                new Follow(1.0, 1, 6, 0, coolDown: 100),
                new State(":D",
                    new Shoot(8, 1, projectileIndex: 0, coolDown: 400)
                    )
                )
            )
        .Init("ic Esben the Unwilling",
                new State(
                    new State("Inital",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(6, "Pause")
                    ),
                    new State("Pause",
                        new SetAltTexture(1),
                        new Taunt("I see you have entered my chamber..."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "Pause2")
                    ),
                    new State("Pause2",
                        new SetAltTexture(1),
                        new Wander(0.1),
                        new Taunt("Good luck on freeing me from my curse."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "Fight1")
                    ),
                    new State("Fight1",
                        new SetAltTexture(0),
                        new Wander(0.4),
                        new Shoot(12, projectileIndex: 2, count: 11, shootAngle: 15, predictive: 0.5, coolDown: 1000, coolDownOffset: 400),
                        new Shoot(12, projectileIndex: 0, count: 3, shootAngle: 25, predictive: 0.2, coolDown: 1600),
                        new Shoot(12, projectileIndex: 1, count: 10, shootAngle: 36, coolDown: 400),
                        new TossObject("Big Yeti", 8, coolDown: 3000),
                        new TossObject("Snow Bat Mama", 8, coolDown: 5000),
                        new HpLessTransition(.5, "Invuln1")
                    ),
                    new State("Invuln1",
                        new SetAltTexture(1),
                        new ReturnToSpawn(once: true, speed: 0.5),
                        new Taunt("Keep fighting heroes!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3000, "Invuln2")
                    ),
                    new State("Invuln2",
                        new SetAltTexture(0),
                        new Wander(0.2),
                        new TossObject("ic boss purifier", 10, 0, 7000, coolDownOffset: 0),
                        new TossObject("ic boss purifier", 10, 45, 7000, coolDownOffset: 0),
                        new TossObject("ic boss purifier", 10, 90, 7000, coolDownOffset: 0),
                        new TossObject("ic boss purifier", 10, 135, 7000, coolDownOffset: 0),
                        new TossObject("ic boss purifier", 10, 180, 7000, coolDownOffset: 0),
                        new TossObject("ic boss purifier", 10, 225, 7000, coolDownOffset: 0),
                        new TossObject("ic boss purifier", 10, 270, 7000, coolDownOffset: 0),
                        new TossObject("ic boss purifier", 10, 315, 7000, coolDownOffset: 0),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "Fight2")
                    ),
                    new State("Fight2",
                        new SetAltTexture(0),
                        new Follow(0.2, range: 2),
                        new Shoot(12, projectileIndex: 1, count: 3, shootAngle: 18, predictive: 0.6, coolDown: 400),
                        new Shoot(12, projectileIndex: 2, count: 10, shootAngle: 20, coolDown: 1000),
                        new Shoot(12, projectileIndex: 3, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 200),
                        new HpLessTransition(.1, "DeathAnim")
                    ),
                    new State("DeathAnim",
                        new SetAltTexture(1),
                        new Taunt("Thank you. I will be sure to reward you greatly for this."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Spawn("ic CreepyTime", 12, coolDown: 10000),
                        new Spawn("ic CreepyTime", 12, coolDown: 10000),
                        new Spawn("ic CreepyTime", 12, coolDown: 10000),
                        new Spawn("ic CreepyTime", 12, coolDown: 10000),
                        new Spawn("ic CreepyTime", 12, coolDown: 10000),
                        new Spawn("ic CreepyTime", 12, coolDown: 10000),
                        new Spawn("ic CreepyTime", 12, coolDown: 10000),
                        new TimedTransition(3000, "Suicide")
                    ),
                    new State("Suicide",
                        new Suicide()
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Z Saber", 0.0005),
                new ItemLoot("Snowstorm Armor", 0.005),
                new ItemLoot("Frozen Time", 0.005),
                new ItemLoot("Glazed Edge", 0.01),
                new ItemLoot("North Pole's Slasher", 0.01),
                new ItemLoot("North Pole's Orb", 0.01),
                new ItemLoot("Garbs of the Frozen Queen", 0.01),
                new ItemLoot("Crown of the Ice", 0.01),
                new ItemLoot("Aegis of the Citadel", 0.01),
                new ItemLoot("Staff of Esben", 0.05),
                new ItemLoot("Skullish Remains of Esben", 0.05),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.25),
                new ItemLoot("Potion of Mana", 1),
                new ItemLoot("Potion of Defense", 1),
                new ItemLoot("Potion of Dexterity", 1),
                new TierLoot(9, ItemType.Weapon, 0.10),
                new TierLoot(4, ItemType.Ability, 0.08),
                new TierLoot(10, ItemType.Armor, 0.10),
                new TierLoot(4, ItemType.Ring, 0.08),
                new TierLoot(10, ItemType.Weapon, 0.08),
                new TierLoot(5, ItemType.Ability, 0.08),
                new TierLoot(11, ItemType.Armor, 0.08),
                new TierLoot(5, ItemType.Ring, 0.03),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
        .Init("ic boss purifier",
            new State(
                new State(":D",
                    new Spawn("ic Whirlwind", 1, 1, coolDown: 100000),
                    //new Spawn("ic CreepyTime", 1, 1, coolDown: 100000),
                    new Shoot(6, 1, 0, defaultAngle: 0, angleOffset: 0, projectileIndex: 0, predictive: 1,
                    coolDown: 1600, coolDownOffset: 200)
                    )
                )
            )
        .Init("ic Whirlwind",
            new State(
                new Follow(0.5, 6, 1, -1, 0),
                new State("shoot1",
                    new Shoot(5, 7, projectileIndex: 0, fixedAngle: fixedAngle_RingAttack2, coolDown: 1500),
                    new TimedTransition(1000, "shoot2")
                    ),
                new State("shoot2",
                    new Shoot(5, 7, projectileIndex: 1, fixedAngle: fixedAngle_RingAttack2, coolDown: 1500),
                    new TimedTransition(1000, "shoot1")
                    )
                )
            )
        .Init("ic CreepyTime",
            new State(
                new State("idle",
                    new Wander(1.5)
                    )
                )
            )
        ;
    }
}
