#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Oryx = () => Behav()
            .Init("Oryx the Mad God 2",
                new State(
                    new State("Attack",
                        new Wander(.05),
                        new Shoot(25, projectileIndex: 0, count: 10, shootAngle: 36, fixedAngle: 45, coolDown: 1200, coolDownOffset: 500),
                        new Shoot(25, projectileIndex: 1, count: 4, shootAngle: 10, predictive: 1.0, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 4, shootAngle: 10, predictive: 1.0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 3, shootAngle: 10, predictive: 0.8, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 4, shootAngle: 10, predictive: 0.6, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 3, shootAngle: 10, predictive: 0.4, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 4, shootAngle: 10, predictive: 0.2, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Taunt(1, 7000, "It is over for you! I have another {HP} HP!"),
                        new Spawn("Henchman of Oryx", 3, coolDown: 9000),
                        new Spawn("Oryx Brute", 3, coolDown: 9000),
                        new HpLessTransition(.3, "prepareRage")
                    ),
                    new State("prepareRage",
                        new Follow(.05, 15, 3),
                        new Taunt("Well...Fought..."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, 30, fixedAngle: 0, projectileIndex: 7, coolDown: 2500, coolDownOffset: 2000),
                        new Shoot(25, 30, fixedAngle: 30, projectileIndex: 8, coolDown: 2500, coolDownOffset: 2500),
                        new TimedTransition(7250, "rage")
                    ),
                    new State("rage",
                        new Taunt("...But you will die NOW!"),
                        new Follow(.08, 15, 3),
                        new Shoot(25, 30, projectileIndex: 7, coolDown: 15000, fixedAngle: 0, coolDownOffset: 7000),
                        new Shoot(25, 30, projectileIndex: 8, coolDown: 15000, fixedAngle: 30, coolDownOffset: 7500),
                        new Shoot(25, projectileIndex: 0, count: 10, shootAngle: 36, fixedAngle: 45, coolDown: 1300, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 1, count: 4, shootAngle: 10, predictive: 1.0, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 4, shootAngle: 10, predictive: 1.0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 3, shootAngle: 10, predictive: 1.0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 12, shootAngle: 30, fixedAngle: 45, coolDown: 2000,
                            coolDownOffset: 2500),
                        new Shoot(25, projectileIndex: 5, count: 3, shootAngle: 10, predictive: 1.0, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 4, shootAngle: 10, predictive: 1.0, coolDown: 1000,
                            coolDownOffset: 1000),
                        //new TossObject("Monstrosity Scarab", 7, 0, coolDown: 1000, randomToss: true),
                        new Taunt(1, 6000, "Get away from my {HP} HP!")
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00003),
                new ItemLoot("Admin Crown", 0.0005),
                new ItemLoot("Sword of Oryx", 0.0043),
                new ItemLoot("Helm of Oryx", 0.0043),
                new ItemLoot("Armor of Oryx", 0.0043),
                new ItemLoot("Ring of Oryx", 0.0043),
                new ItemLoot("Saturn's Orbit", 0.0047),
                new ItemLoot("Mask of the Mad God", 0.01),
                new ItemLoot("Vulcanstriker", 0.01),
                new ItemLoot("Rip of Soul", 0.01),
                new ItemLoot("Death's Gem", 0.01),
                new ItemLoot("Thousand Shot", 0.05),
                new ItemLoot("Sword of Valor", 0.05),
                new ItemLoot("Sword of the Mad God", 0.03),
                new ItemLoot("Onyx Shield of the Mad God", 0.03),
                new ItemLoot("Almandine Armor of Anger", 0.03),
                new ItemLoot("Almandine Ring of Wrath", 0.03),
                new ItemLoot("Backpack", 0.15),
                new ItemLoot("Path of Loot Key", 0.001),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.85),
                new ItemLoot("Greater Potion of Life", 0.4),
                new ItemLoot("Greater Potion of Mana", 0.4),
                new ItemLoot("Greater Potion of Attack", 1.0),
                new ItemLoot("Greater Potion of Defense", 1.0),
                new ItemLoot("Greater Potion of Vitality", 1.0),
                new ItemLoot("Greater Potion of Wisdom", 1.0),
                new ItemLoot("Greater Potion of Speed", 0.25),
                new ItemLoot("Greater Potion of Dexterity", 0.25),
                new TierLoot(12, ItemType.Weapon, 0.17),
                new TierLoot(6, ItemType.Ability, 0.2),
                new TierLoot(13, ItemType.Armor, 0.15),
                new TierLoot(6, ItemType.Ring, 0.11)
                )
            )
            .Init("Henchman of Oryx",
                new State(
                    new Prioritize(
                        new Orbit(.1, 1, target: "Oryx the Mad God 2", radiusVariance: 0.5),
                        new Follow(.2, 8, 3, coolDown: 0)
                        ),
                    new Shoot(8, projectileIndex: 0, predictive: 1, coolDown: 1500),
                    new Shoot(8, projectileIndex: 1, count: 3, shootAngle: 20, coolDown: 1500, coolDownOffset: 500)
                    )
            )
            .Init("Monstrosity Scarab",
                new State(
                    new State("searching",
                        new Prioritize(
                            new Follow(2, range: 0)
                            ),
                        new PlayerWithinTransition(2, "creeping"),
                        new TimedTransition(5000, "creeping")
                        ),
                    new State("creeping",
                        new Shoot(2, 10, 36, fixedAngle: 0),
                        new Decay(0)
                        )
                    )
            )
            .Init("Oryx the Mad God 1",
                new State(
                    new DropPortalOnDeath("Locked Wine Cellar Portal", 100, PortalDespawnTimeSec: 120),
                    new State("Attack",
                        new Wander(.05),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 45, fixedAngle: 100, coolDown: 1500, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 1, count: 3, shootAngle: 10, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0.2, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 2, shootAngle: 10, predictive: 0.4, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0.6, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 2, shootAngle: 10, predictive: 0.8, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 3, shootAngle: 10, predictive: 1, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Taunt(1, 8000, "I am {HP} times more powerful than you!"),
                        new Spawn("Oryx Brute", 3, coolDown: 5000),
                        new HpLessTransition(.2, "prepareRage")
                    ),
                    new State("prepareRage",
                        new Follow(.1, 15, 3),
                        new Taunt("You are much stronger than I thought..."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, 30, fixedAngle: 0, projectileIndex: 7, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(25, 30, fixedAngle: 30, projectileIndex: 8, coolDown: 4000, coolDownOffset: 4500),
                        new TimedTransition(10000, "rage")
                    ),
                    new State("rage",
                        new Follow(.1, 15, 3),
                        new Spawn("Oryx Brute", 2, coolDown: 2000),
                        new Shoot(25, 30, projectileIndex: 7, coolDown: 90000001, coolDownOffset: 8000),
                        new Shoot(25, 30, projectileIndex: 8, coolDown: 90000001, coolDownOffset: 8500),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 45, fixedAngle: 100, coolDown: 1500, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 1, count: 3, shootAngle: 10, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0.2, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 2, shootAngle: 10, predictive: 0.4, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0.6, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 2, shootAngle: 10, predictive: 0.8, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 3, shootAngle: 10, predictive: 1, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Taunt(1, 8000, "But I will not give up! For my realm!")
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Handcannon", 0.0005),
                new ItemLoot("Harbinger of Fury", 0.0043),
                new ItemLoot("Oryx's Decapitator", 0.0043),
                new ItemLoot("Seal of Oryx", 0.0043),
                new ItemLoot("Vanguard of Oryx", 0.0043),
                new ItemLoot("Amulet of Pure Madness", 0.0043),
                new ItemLoot("Amulet of Oryx", 0.004),
                new ItemLoot("The Twilight Grimoire", 0.0047),
                new ItemLoot("Jackpot", 0.01),
                new ItemLoot("Ring of Derpades", 0.05),
                new ItemLoot("Captain America Sword", 0.05),
                new ItemLoot("Band of Oryx", 0.05),
                new ItemLoot("Path of Loot Key", 0.0005),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.75),
                new ItemLoot("Potion of Attack", 1.0),
                new ItemLoot("Potion of Defense", 1.0),
                new ItemLoot("Potion of Vitality", 1.0),
                new ItemLoot("Potion of Wisdom", 1.0),
                new ItemLoot("Wine Cellar Incantation", 1.0),
                new TierLoot(10, ItemType.Weapon, 0.15),
                new TierLoot(11, ItemType.Weapon, 0.15),
                new TierLoot(12, ItemType.Weapon, 0.15),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(6, ItemType.Ability, 0.17),
                new TierLoot(11, ItemType.Armor, 0.12),
                new TierLoot(12, ItemType.Armor, 0.12),
                new TierLoot(13, ItemType.Armor, 0.12),
                new TierLoot(5, ItemType.Ring, 0.17)
                )
            )
            .Init("Ring Element",
                new State(
                    new State(
                        new Shoot(50, 12, projectileIndex: 0, coolDown: 700, coolDownOffset: 200),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(20000, "Despawn")
                        ),
                    new State("Despawn", //new Decay(time:0)
                        new Suicide()
                        )
                    )
            )
            .Init("Minion of Oryx",
                new State(
                    new Wander(0.4),
                    new Shoot(3, 3, 10, 0, coolDown: 1000),
                    new Shoot(3, 3, projectileIndex: 1, shootAngle: 10, coolDown: 1000)
                    ),
                new TierLoot(7, ItemType.Weapon, 0.2),
                new ItemLoot("Health Potion", 0.03)
            )
            .Init("Guardian Element 1",
                new State(
                    new State(
                        new Orbit(1, 1, target: "Oryx the Mad God 1", radiusVariance: 0),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, 3, 10, 0, coolDown: 1000),
                        new TimedTransition(10000, "Grow")
                        ),
                    new State("Grow",
                        new ChangeSize(100, 200),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Orbit(1, 1, target: "Oryx the Mad God 1", radiusVariance: 0),
                        new Shoot(3, 1, 10, 0, coolDown: 700),
                        new TimedTransition(10000, "Despawn")
                        ),
                    new State("Despawn",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Orbit(1, 1, target: "Oryx the Mad God 1", radiusVariance: 0),
                        new ChangeSize(100, 100),
                        new Suicide()
                        )
                    )
            )
            .Init("Guardian Element 2",
                new State(
                    new State(
                        new Orbit(1.3, 9, target: "Oryx the Mad God 1", radiusVariance: 0),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, 3, 10, 0, coolDown: 1000),
                        new TimedTransition(20000, "Despawn")
                        ),
                    new State("Despawn", new Suicide()
                        )
                    )
            );
    }
}