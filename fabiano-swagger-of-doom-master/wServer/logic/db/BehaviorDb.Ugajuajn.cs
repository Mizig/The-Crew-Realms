using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Ugajuajn = () => Behav()
            .Init("Ugajuajn",
                new State(
                    new State("Wander",
                        new Wander(.36),
                        new Shoot(25, projectileIndex: 0, count: 20, shootAngle: 18, fixedAngle: 0, coolDown: 300),
                        new Shoot(25, projectileIndex: 1, count: 3, shootAngle: 16, coolDown: 1500),
                        new HpLessTransition(0.42, "Chase")
                    ),
                    new State("Chase",
                        new Follow(.24, 10, 2),
                        new Taunt("ugajuajn ANGERY!"),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(25, projectileIndex: 0, count: 20, shootAngle: 18, coolDown: 200),
                        new Shoot(25, projectileIndex: 1, count: 7, shootAngle: 25, coolDown: 1500)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("maiuash's Blessing", 0.0001),
                new ItemLoot("Arcanuo's Zol Lance", 0.0025),
                new ItemLoot("Dreadcool", 0.0008),
                new ItemLoot("Dreadcull", 0.004),
                new ItemLoot("A Gruesome Concept", 0.004),
                new ItemLoot("Slime Staff", 0.004),
                new ItemLoot("The Eternal Kinstone", 0.004),
                new ItemLoot("Overgrown Skull", 0.01),
                new ItemLoot("Petrified Dragonroot", 0.01),
                new ItemLoot("Bow of the Ugajuajn", 0.01),
                new ItemLoot("Elimination", 0.01),
                new ItemLoot("The Odyssey", 0.01),
                new ItemLoot("Star Ring", 0.01),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.05),
                new ItemLoot("Potion of Defense", 0.7),
                new ItemLoot("Potion of Speed", 0.5),
                new ItemLoot("Potion of Vitality", 0.7),
                new ItemLoot("Potion of Wisdom", 0.7),
                new TierLoot(9, ItemType.Weapon, 0.15),
                new TierLoot(10, ItemType.Weapon, 0.15),
                new TierLoot(4, ItemType.Ability, 0.17),
                new TierLoot(10, ItemType.Armor, 0.12),
                new TierLoot(11, ItemType.Armor, 0.12),
                new TierLoot(4, ItemType.Ring, 0.13)
                )
            )
            ;
    }
}