using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Boshy = () => Behav()
            .Init("Boshy",
                new State(
                    new State("GetNear",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(9, "Timer")
                    ),
                    new State("Timer",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xffffffff, 1, 5),
                        new TimedTransition(5000, "Phase1")
                    ),
                    new State("Phase1",
                        new Wander(0.15),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 8, predictive: 0.4, coolDown: 200),
                        new Shoot(25, projectileIndex: 1, count: 24, shootAngle: 15, fixedAngle: 0, coolDown: 2400, coolDownOffset: 1000),
                        new TimedTransition(10000, "Phase2")
                    ),
                    new State("Phase2",
                        new Shoot(25, projectileIndex: 3, count: 20, shootAngle: 18, fixedAngle: 0, coolDown: 240000, coolDownOffset: 800),
                        new Shoot(25, projectileIndex: 1, count: 20, shootAngle: 18, fixedAngle: 0, coolDown: 240000, coolDownOffset: 800),
                        new Shoot(25, projectileIndex: 2, count: 20, shootAngle: 18, fixedAngle: 0, coolDown: 240000, coolDownOffset: 800),
                        new Shoot(25, projectileIndex: 3, count: 20, shootAngle: 18, fixedAngle: 8, coolDown: 240000, coolDownOffset: 2800),
                        new Shoot(25, projectileIndex: 1, count: 20, shootAngle: 18, fixedAngle: 8, coolDown: 240000, coolDownOffset: 2800),
                        new Shoot(25, projectileIndex: 2, count: 20, shootAngle: 18, fixedAngle: 8, coolDown: 240000, coolDownOffset: 2800),
                        new Shoot(25, projectileIndex: 3, count: 20, shootAngle: 18, fixedAngle: 16, coolDown: 240000, coolDownOffset: 4800),
                        new Shoot(25, projectileIndex: 1, count: 20, shootAngle: 18, fixedAngle: 16, coolDown: 240000, coolDownOffset: 4800),
                        new Shoot(25, projectileIndex: 2, count: 20, shootAngle: 18, fixedAngle: 16, coolDown: 240000, coolDownOffset: 4800),
                        new Shoot(25, projectileIndex: 3, count: 20, shootAngle: 18, fixedAngle: 24, coolDown: 240000, coolDownOffset: 6800),
                        new Shoot(25, projectileIndex: 1, count: 20, shootAngle: 18, fixedAngle: 24, coolDown: 240000, coolDownOffset: 6800),
                        new Shoot(25, projectileIndex: 2, count: 20, shootAngle: 18, fixedAngle: 24, coolDown: 240000, coolDownOffset: 6800),
                        new Shoot(25, projectileIndex: 3, count: 20, shootAngle: 18, fixedAngle: 32, coolDown: 240000, coolDownOffset: 8800),
                        new Shoot(25, projectileIndex: 1, count: 20, shootAngle: 18, fixedAngle: 32, coolDown: 240000, coolDownOffset: 8800),
                        new Shoot(25, projectileIndex: 2, count: 20, shootAngle: 18, fixedAngle: 32, coolDown: 240000, coolDownOffset: 8800),
                        new TimedTransition(9600, "Phase3")
                    ),
                    new State("Phase3",
                        new Follow(.15, 12, 3),
                        new TossObject("Mini Boshy", 3, 0, 90000001, coolDownOffset: 0),
                        new TossObject("Mini Boshy", 3, 90, 90000001, coolDownOffset: 0),
                        new TossObject("Mini Boshy", 3, 180, 90000001, coolDownOffset: 0),
                        new TossObject("Mini Boshy", 3, 270, 90000001, coolDownOffset: 0),
                        new Shoot(25, projectileIndex: 1, count: 9, shootAngle: 10, coolDown: 2800),
                        new Shoot(25, projectileIndex: 1, count: 9, shootAngle: 10, predictive: 0.5, coolDown: 2800, coolDownOffset: 1400),
                        new TimedTransition(9000, "Phase1")
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Boshy's Minigun", 0.0001),
                new ItemLoot("Boshy Gun", 0.0005),
                new ItemLoot("Larry Gun", 0.004),
                new ItemLoot("Executioner's Guillotine", 0.004),
                new ItemLoot("Heart of Boshy", 0.01),
                new ItemLoot("Elemental Pendant", 0.01),
                new ItemLoot("Gargoyle Stoneplate", 0.01),
                new ItemLoot("Path of Loot Key", 0.00025),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.7),
                new ItemLoot("Potion of Life", 1.0),
                new ItemLoot("Potion of Mana", 1.0),
                new ItemLoot("Potion of Attack", 1.0),
                new ItemLoot("Potion of Defense", 1.0),
                new ItemLoot("Potion of Vitality", 1.0),
                new ItemLoot("Potion of Wisdom", 1.0),
                new ItemLoot("Potion of Speed", 1.0),
                new ItemLoot("Potion of Dexterity", 1.0),
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
            .Init("Mini Boshy",
                new State(
                    new Prioritize(
                        new Protect(1, "Boshy"),
                        new Wander(0.42)
                    ),
                    new State("Default",
                        new Shoot(9, 1, projectileIndex: 0, coolDown: 350),
                        new TimedTransition(28600, "Suicide")
                    ),
                    new State("Suicide",
                        new Suicide()
                    )
                )
            )
            ;
    }
}