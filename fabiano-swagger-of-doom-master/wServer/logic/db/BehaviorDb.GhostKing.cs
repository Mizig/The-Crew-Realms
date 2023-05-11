#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ GhostKing = () => Behav()
            .Init("Ghost King",
                new State(
                    new DropPortalOnDeath("Ice Cave Portal", 100),
                    new State("Idle",
                        new BackAndForth(0.3, 3),
                        new HpLessTransition(0.99999, "EvaluationStart1")
                        ),
                    new State("EvaluationStart1",
                        new Taunt("Hello there warrior. Prehaps you will end my sorrow?"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new StayCloseToSpawn(0.4, 3),
                            new Wander(0.4)
                            ),
                        new TimedTransition(3300, "Bossfight")
                        ),
                    new State("Bossfight",
                        new Shoot(13, 10, 36, defaultAngle: 0, coolDown: 1200),
                        new Shoot(7, 5, 25, defaultAngle: 0, coolDown: 1600, coolDownOffset: 400),
                        new Follow(.18, 13, 1)
                        )
                    ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Elithor's Soul Bottle", 0.004),
                new ItemLoot("Deception", 0.01),
                new ItemLoot("Words of Wisdom", 0.01),
                new ItemLoot("Heart of the Mountains", 0.01),
                new ItemLoot("Ghost King's Crown", 0.02),
                new ItemLoot("Strike Amulet", 0.02),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.15),
                new ItemLoot("Potion of Mana", 0.2),
                new ItemLoot("Potion of Wisdom", 0.7),
                new ItemLoot("Potion of Vitality", 0.6),
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
            .Init("Ghost Master",
                new State(
                    new State("Attack1",
                        new State("NewLocation1",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0xff00ff00, 0.2, 10),
                            new Prioritize(
                                new StayCloseToSpawn(2, 7),
                                new Wander(2)
                                ),
                            new TimedTransition(1000, "Att1")
                            ),
                        new State("Att1",
                            new Shoot(10, 4, 90, fixedAngle: 0, coolDown: 400),
                            new TimedTransition(9000, "NewLocation1")
                            ),
                        new HpLessTransition(0.99, "Attack2")
                        ),
                    new State("Attack2",
                        new State("Intro",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0xff00ff00, 0.2, 10),
                            new ChangeSize(20, 140),
                            new TimedTransition(1000, "NewLocation2")
                            ),
                        new State("NewLocation2",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0xff00ff00, 0.2, 10),
                            new Prioritize(
                                new StayCloseToSpawn(2, 7),
                                new Wander(2)
                                ),
                            new TimedTransition(1000, "Att2")
                            ),
                        new State("Att2",
                            new Shoot(10, 4, 90, fixedAngle: 45, coolDown: 400),
                            new TimedTransition(6000, "NewLocation2")
                            ),
                        new HpLessTransition(0.98, "Attack3")
                        ),
                    new State("Attack3",
                        new State("Intro",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0xff00ff00, 0.2, 10),
                            new ChangeSize(20, 180),
                            new TimedTransition(1000, "NewLocation3")
                            ),
                        new State("NewLocation3",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0xff00ff00, 0.2, 10),
                            new Prioritize(
                                new StayCloseToSpawn(2, 7),
                                new Wander(2)
                                ),
                            new TimedTransition(1000, "Att3")
                            ),
                        new State("Att3",
                            new Shoot(10, 4, 90, fixedAngle: 22.5, coolDown: 400),
                            new TimedTransition(3000, "NewLocation3")
                            ),
                        new HpLessTransition(0.94, "KillKing")
                        ),
                    new State("KillKing",
                        new Taunt("Your secret soul master is dying, Your Majesty"),
                        new Order(30, "Ghost King", "Killed"),
                        new TimedTransition(3000, "Suicide")
                        ),
                    new State("Suicide",
                        new Taunt("I cannot live with my betrayal..."),
                        new Shoot(0, 8, 45, fixedAngle: 22.5),
                        new Decay(0)
                        ),
                    new State("Decay",
                        new Decay(0)
                        )
                    ),
                new ItemLoot("Purple Drake Egg", 0.03),
                new ItemLoot("White Drake Egg", 0.001),
                new ItemLoot("Tincture of Dexterity", 0.02)
            )
            .Init("Actual Ghost King",
                new State(
                    new Taunt(0.9, "I am still so very alone"),
                    new ChangeSize(-20, 95),
                    new Flash(0xff000000, 0.4, 100),
                    new BackAndForth(0.5, 3)
                    )
            )
            .Init("Small Ghost",
                new State(
                    new TransformOnDeath("Medium Ghost"),
                    new State("NewLocation",
                        new Taunt(0.1, "Switch!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xff00ff00, 0.2, 10),
                        new Prioritize(
                            new StayCloseToSpawn(2, 7),
                            new Wander(2)
                            ),
                        new TimedTransition(1000, "Attack")
                        ),
                    new State("Attack",
                        new Taunt(0.1, "Save the King's Soul!"),
                        new Shoot(10, 4, 90, fixedAngle: 0, coolDown: 400),
                        new TimedTransition(9000, "NewLocation")
                        ),
                    new State("Decay",
                        new Decay(0)
                        ),
                    new Decay(160000)
                    ),
                new ItemLoot("Magic Potion", 0.02),
                new ItemLoot("Ring of Magic", 0.02),
                new ItemLoot("Ring of Attack", 0.02)
            )
            .Init("Medium Ghost",
                new State(
                    new TransformOnDeath("Large Ghost"),
                    new State("Intro",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xff00ff00, 0.2, 10),
                        new ChangeSize(20, 140),
                        new TimedTransition(1000, "NewLocation")
                        ),
                    new State("NewLocation",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xff00ff00, 0.2, 10),
                        new Prioritize(
                            new StayCloseToSpawn(2, 7),
                            new Wander(2)
                            ),
                        new TimedTransition(1000, "Attack")
                        ),
                    new State("Attack",
                        new Taunt(0.02, "I come back more powerful than you could ever imagine"),
                        new Shoot(10, 4, 90, fixedAngle: 45, coolDown: 800),
                        new TimedTransition(6000, "NewLocation")
                        ),
                    new State("Decay",
                        new Decay(0)
                        ),
                    new Decay(160000)
                    ),
                new ItemLoot("Magic Potion", 0.02),
                new ItemLoot("Ring of Speed", 0.02),
                new ItemLoot("Ring of Attack", 0.02),
                new ItemLoot("Iron Quiver", 0.02)
            )
            .Init("Large Ghost",
                new State(
                    new State("Intro",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xff00ff00, 0.2, 10),
                        new ChangeSize(20, 180),
                        new TimedTransition(1000, "NewLocation")
                        ),
                    new State("NewLocation",
                        new Taunt(0.01,
                            "The Ghost King protects this sacred ground",
                            "The Ghost King gave his heart to the Ghost Master.  He cannot die.",
                            "Only the Secret Ghost Master can kill the King."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xff00ff00, 0.2, 10),
                        new Prioritize(
                            new StayCloseToSpawn(2, 7),
                            new Wander(2)
                            ),
                        new TimedTransition(1000, "Attack")
                        ),
                    new State("Attack",
                        new Taunt(0.01, "The King's wife died here.  For her memory."),
                        new Shoot(10, 8, 45, fixedAngle: 22.5, coolDown: 800),
                        new TimedTransition(3000, "NewLocation"),
                        new EntityNotExistsTransition("Ghost King", 30, "AttackKingGone")
                        ),
                    new State("AttackKingGone",
                        new Taunt(0.01, "The King's wife died here.  For her memory."),
                        new Shoot(10, 8, 45, fixedAngle: 22.5, coolDown: 800, coolDownOffset: 800),
                        new TransformOnDeath("Imp", 2, 3),
                        new TimedTransition(3000, "NewLocation")
                        ),
                    new State("Decay",
                        new Decay(0)
                        ),
                    new Decay(160000)
                    ),
                new ItemLoot("Magic Potion", 0.02),
                new ItemLoot("Tincture of Defense", 0.02),
                new ItemLoot("Blue Drake Egg", 0.02),
                new ItemLoot("Yellow Drake Egg", 0.02)
            )
            ;
    }
}