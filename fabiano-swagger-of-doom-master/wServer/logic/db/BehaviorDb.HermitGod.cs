#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ HermitGod = () => Behav()
            .Init("Hermit God",
                new State(
                    new DropPortalOnDeath("Ocean Trench Portal", 100),
                    new State("invis",
                        new SetAltTexture(3),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new InvisiToss("Hermit Minion", 9, 0, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit Minion", 9, 45, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit Minion", 9, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit Minion", 9, 135, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit Minion", 9, 180, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit Minion", 9, 225, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit Minion", 9, 270, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit Minion", 9, 315, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit God Tentacle", 5, 45, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit God Tentacle", 5, 90, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit God Tentacle", 5, 135, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit God Tentacle", 5, 180, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit God Tentacle", 5, 225, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit God Tentacle", 5, 270, 90000001, coolDownOffset: 0),
                        new InvisiToss("Hermit God Tentacle", 5, 315, 90000001, coolDownOffset: 0),

                        //new Spawn("Hermit God Tentacle", 8, 8, coolDown:9000001),
                        new TimedTransition(1000, "check")
                        ),
                    new State("check",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Hermit God Tentacle", 20, "active")
                        ),
                    new State("active",
                        new SetAltTexture(2),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(500, "active2")
                        ),
                    new State("active2",
                        new SetAltTexture(0),
                        new Shoot(25, 3, 10, 0, coolDown: 200),
                        new Wander(.2),
                        new TossObject("Whirlpool", 6, 0, 90000001, 100),
                        new TossObject("Whirlpool", 6, 45, 90000001, 100),
                        new TossObject("Whirlpool", 6, 90, 90000001, 100),
                        new TossObject("Whirlpool", 6, 135, 90000001, 100),
                        new TossObject("Whirlpool", 6, 180, 90000001, 100),
                        new TossObject("Whirlpool", 6, 225, 90000001, 100),
                        new TossObject("Whirlpool", 6, 270, 90000001, 100),
                        new TossObject("Whirlpool", 6, 315, 90000001, 100),
                        new HpLessTransition(.4, "rage")
                        ),
                    new State("rage",
                        new SetAltTexture(4),
                        new Wander(.2),
                        new TossObject("Hermit Minion", 9, 0, 7000, coolDownOffset: 0),
                        new TossObject("Hermit Minion", 9, 45, 7000, coolDownOffset: 0),
                        new TossObject("Hermit Minion", 9, 90, 7000, coolDownOffset: 0),
                        new TossObject("Hermit Minion", 9, 135, 7000, coolDownOffset: 0),
                        new TossObject("Hermit Minion", 9, 180, 7000, coolDownOffset: 0),
                        new TossObject("Hermit Minion", 9, 225, 7000, coolDownOffset: 0),
                        new TossObject("Hermit Minion", 9, 270, 7000, coolDownOffset: 0),
                        new TossObject("Hermit Minion", 9, 315, 7000, coolDownOffset: 0),
                        new Flash(0xfFF0000, .8, 9000001),
                        new Shoot(25, 7, 9, 0, coolDown: 400),
                        new Shoot(25, 8, projectileIndex: 1, coolDown: 1200),
                        new Shoot(25, 20, projectileIndex: 2, coolDown: 1600, coolDownOffset: 400)
                        )
                    ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Deep Blue Anchor", 0.0005),
                new ItemLoot("Poseidon's Gauntlet", 0.0038),
                new ItemLoot("Octopussy", 0.01),
                new ItemLoot("Helm of Erebus", 0.01),
                new ItemLoot("An Astonishing Happening", 0.01),
                new ItemLoot("The Rainstorm", 0.01),
                new ItemLoot("Robe of Split Worlds", 0.01),
                new ItemLoot("Shadow Suit", 0.01),
                new ItemLoot("Helm of the Juggernaut", 0.05),
                new ItemLoot("Path of Loot Key", 0.00025),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.5),
                new ItemLoot("Potion of Life", 0.5),
                new ItemLoot("Potion of Mana", 0.5),
                new ItemLoot("Potion of Attack", 1.0),
                new ItemLoot("Potion of Defense", 1.0),
                new ItemLoot("Potion of Speed", 1.0),
                new ItemLoot("Greater Potion of Dexterity", 1.0),
                new ItemLoot("Potion of Vitality", 1.0),
                new ItemLoot("Potion of Wisdom", 1.0),
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
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Whirlpool",
                new State(
                    new State("active",
                        new Shoot(25, 8, projectileIndex: 0, coolDown: 1000, coolDownOffset: 300),
                        new Shoot(25, 1, projectileIndex: 1, coolDown: 400, coolDownOffset: 100),
                        new Orbit(.5, 4, target: "Hermit God", radiusVariance: 0),
                        new EntityNotExistsTransition("Hermit God", 50, "despawn")
                        ),
                    new State("despawn",
                        new Suicide()
                        )
                    )
            )
            .Init("Hermit God Tentacle",
                new State(
                    new Prioritize(
                        new Orbit(.5, 5, target: "Hermit God", radiusVariance: 0.5),
                        new Follow(0.85, range: 1, duration: 2000, coolDown: 0)
                        ),
                    new Shoot(4, 8, projectileIndex: 0, coolDown: 1000)
                    )
            )
            .Init("Hermit Minion",
                new State(
                    new Prioritize(
                        new Wander(.5),
                        new Follow(0.85, 3, 1, 2000, 0)
                        ),
                    new Shoot(5, 1, 1, 1, coolDown: 2800),
                    new Shoot(5, 3, 1, 0, coolDown: 800)
                    )
            );
    }
}
