using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ SantasDen = () => Behav()
            .Init("Classy Snowman",
                new State(
                    new State("Snowy",
                        new Wander(.15),
                        new Follow(.1, 10, .2),
                        new Shoot(10, projectileIndex: 0, count: 4, shootAngle: 11, coolDown: 1700),
                        new Shoot(9, projectileIndex: 1, count: 8, shootAngle: 45, fixedAngle: 0, coolDown: 1200)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Covering of Winter Goddess", 0.004),
                new TierLoot(10, ItemType.Weapon, 0.07),
                new TierLoot(5, ItemType.Ability, 0.07),
                new TierLoot(11, ItemType.Armor, 0.07),
                new TierLoot(5, ItemType.Ring, 0.04)
                )
            )
            .Init("Cool Snowman",
                new State(
                    new State("Snowy2",
                        new Wander(.15),
                        new Follow(.1, 10, .2),
                        new Shoot(10, projectileIndex: 0, count: 4, shootAngle: 11, coolDown: 1700),
                        new Shoot(7, projectileIndex: 1, count: 1, predictive: 0.5, coolDown: 600)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Santa's Battle Attire", 0.004),
                new TierLoot(10, ItemType.Weapon, 0.07),
                new TierLoot(5, ItemType.Ability, 0.07),
                new TierLoot(11, ItemType.Armor, 0.07),
                new TierLoot(5, ItemType.Ring, 0.04)
                )
            )
            .Init("Frosty Snowman",
                new State(
                    new State("Snowy3",
                        new Wander(.15),
                        new Follow(.1, 10, .2),
                        new Shoot(10, projectileIndex: 0, count: 4, shootAngle: 11, coolDown: 1700),
                        new Shoot(7, projectileIndex: 1, count: 1, predictive: 0.5, coolDown: 800)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Christmas Garments", 0.004),
                new TierLoot(10, ItemType.Weapon, 0.07),
                new TierLoot(5, ItemType.Ability, 0.07),
                new TierLoot(11, ItemType.Armor, 0.07),
                new TierLoot(5, ItemType.Ring, 0.04)
                )
            )
            .Init("Evil Santa",
                new State(
                    new State("Wait",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(8, "Begin")
                    ),
                    new State("Begin",
                        new Taunt("Ho ho ho!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "Presents")
                    ),
                    new State("Presents",
                        new Taunt("Have some presents!"),
                        new Wander(.25),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 24, coolDown: 1400),
                        new Shoot(25, projectileIndex: 1, count: 5, shootAngle: 20, predictive: 0.2, coolDown: 1800, coolDownOffset: 600),
                        new Shoot(25, projectileIndex: 2, count: 8, shootAngle: 45, fixedAngle: 0, coolDown: 1000),
                        new HpLessTransition(0.5, "Naughty")
                    ),
                    new State("Naughty",
                        new Follow(.25, 15, 3),
                        new Taunt("You've been naughty today!"),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 45, fixedAngle: 0, coolDown: 1800),
                        new Shoot(25, projectileIndex: 1, count: 8, shootAngle: 45, fixedAngle: 22, coolDown: 1800, coolDownOffset: 900),
                        new Shoot(25, projectileIndex: 2, count: 10, shootAngle: 36, fixedAngle: 0, coolDown: 800),
                        new Shoot(25, projectileIndex: 3, count: 4, shootAngle: 13, coolDown: 300),
                        new Shoot(25, projectileIndex: 3, count: 4, shootAngle: 90, coolDown: 600)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Elicia Blanket", 0.0005),
                new ItemLoot("Peppermint Candy Bow", 0.008),
                new ItemLoot("Festive Quiver", 0.008),
                new ItemLoot("Elf Suit", 0.008),
                new ItemLoot("Merrystone", 0.008),
                new ItemLoot("Star of the North Pole", 0.009),
                new ItemLoot("Wand of Ornaments", 0.009),
                new ItemLoot("Chocolate Cookie", 0.009),
                new ItemLoot("Robe of Celebration", 0.009),
                new ItemLoot("Santa's Battlesuit", 0.009),
                new ItemLoot("Kurisumasu no Uwagi", 0.009),
                new ItemLoot("Santa's Coat", 0.009),
                new ItemLoot("Santa Hat", 0.009),
                new ItemLoot("Santa's Mitten", 0.009),
                new ItemLoot("Holiday Ring", 0.004),
                new ItemLoot("Frosty's Walking Stick", 0.05),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.2),
                new ItemLoot("Potion of Life", 0.25),
                new ItemLoot("Potion of Mana", 0.25),
                new ItemLoot("Potion of Attack", 0.25),
                new ItemLoot("Potion of Defense", 0.25),
                new ItemLoot("Potion of Speed", 0.25),
                new ItemLoot("Potion of Dexterity", 0.25),
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
                new TierLoot(5, ItemType.Ring, 0.13)
                )
            )
            ;
    }
}