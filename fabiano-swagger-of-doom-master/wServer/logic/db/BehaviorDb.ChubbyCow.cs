using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ ChubbyCow = () => Behav()
            .Init("Chubby Cow",
                new State(
                    new DropPortalOnDeath("The Crew Dungeon Portal", 100),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(8, "Wandering")
                    ),
                    new State("WanderingWait",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "Charge1")
                    ),
                    new State("Wandering",
                        new Taunt("Moo"),
                        new Wander(0.33),
                        new Follow(.1, 12, 4),
                        new Shoot(25, projectileIndex: 0, count: 9, shootAngle: 40, coolDown: 600),
                        new Shoot(25, projectileIndex: 1, count: 20, shootAngle: 18, fixedAngle: 0, coolDown: 1200, coolDownOffset: 400),
                        new Shoot(25, projectileIndex: 2, count: 8, shootAngle: 45, fixedAngle: 22, coolDown: 1800, coolDownOffset: 1000),
                        new TimedTransition(7000, "Charge1")
                    ),
                    new State("Charge1",
                        new Taunt("MOO!!!"),
                        new Follow(0.9, 12, 0.1),
                        new Flash(0xfff00000, 0.5, 2),
                        new Shoot(25, projectileIndex: 1, count: 36, shootAngle: 10, fixedAngle: 0, coolDown: 600, coolDownOffset: 100),
                        new Shoot(25, projectileIndex: 2, count: 5, shootAngle: 10, coolDown: 200),
                        new TimedTransition(1000, "Charge2")
                    ),
                    new State("Charge2",
                        new Wander(0.1),
                        new Shoot(25, projectileIndex: 2, count: 8, shootAngle: 16, predictive: 0.4, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(25, projectileIndex: 0, count: 9, shootAngle: 40, coolDown: 600),
                        new TimedTransition(3000, "Wandering")
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Old Farmer's Leather Book", 0.0005),
                new ItemLoot("Page of Catatonia", 0.004),
                new ItemLoot("Rhongomyniad", 0.0038),
                new ItemLoot("Mad King's Crook", 0.01),
                new ItemLoot("The Gilded Blade", 0.01),
                new ItemLoot("March of the Army", 0.01),
                new ItemLoot("Super Mushroom", 0.04),
                new ItemLoot("Cow Horns", 0.05),
                new ItemLoot("Cow Skin Shield", 0.05),
                new ItemLoot("Milky Orb", 0.05),
                new ItemLoot("Path of Loot Key", 0.00025),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.5),
                new ItemLoot("Greater Potion of Life", 1.0),
                new ItemLoot("Greater Potion of Defense", 1.0),
                new ItemLoot("Greater Potion of Vitality", 1.0),
                new ItemLoot("Greater Potion of Speed", 0.4),
                new ItemLoot("Milk Bottle", 1.0),
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
            ;
    }
}