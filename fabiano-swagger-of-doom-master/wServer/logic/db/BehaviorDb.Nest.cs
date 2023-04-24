using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Nest = () => Behav()
            .Init("Killer Bee Queen",
                new State(
                    new State("HelloWorld",
                        new Taunt("I am the big bee!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(6000, "Attack")
                    ),
                    new State("Attack",
                        new Taunt("*loud buzzing*"),
                        new Wander(.3),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 15, coolDown: 1300),
                        new Shoot(25, projectileIndex: 1, count: 7, shootAngle: 7, predictive: 0.4, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(25, projectileIndex: 2, count: 12, shootAngle: 30, fixedAngle: 125, coolDown: 1300, coolDownOffset: 650),
                        new HpLessTransition(0.20, "Pause")
                    ),
                    new State("Pause",
                        new Wander(.05),
                        new Taunt("*angry buzzing*"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3000, "Final")
                    ),
                    new State("Final",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Follow(.22, 20, 1),
                        new Taunt("DIE!!!"),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 13, coolDown: 1100),
                        new Shoot(25, projectileIndex: 0, count: 5, shootAngle: 4, predictive: 0.8, coolDown: 1800, coolDownOffset: 600),
                        new Shoot(25, projectileIndex: 1, count: 7, shootAngle: 7, predictive: 0.4, coolDown: 850, coolDownOffset: 400),
                        new Shoot(25, projectileIndex: 2, count: 12, shootAngle: 30, fixedAngle: 45, coolDown: 1000, coolDownOffset: 550)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Giant Asian Hornet", 0.0001),
                new ItemLoot("Blondie's Claws", 0.0005),
                new ItemLoot("Morningstar of Honey", 0.004),
                new ItemLoot("Ring of the Cosmos", 0.004),
                new ItemLoot("Beastly Dice", 0.004),
                new ItemLoot("Bee Wand", 0.01),
                new ItemLoot("Beehemoth Quiver Yellow", 0.025),
                new ItemLoot("Beehemoth Quiver Blue", 0.025),
                new ItemLoot("Beehemoth Quiver Red", 0.025),
                new ItemLoot("Bottle of Condensed Honey", 0.045),
                new ItemLoot("Queen's Stinger Dagger", 0.045),
                new ItemLoot("Hivemaster Helm", 0.045),
                new ItemLoot("Nectar Crossfire", 0.05),
                new ItemLoot("Honeytomb Snare", 0.05),
                new ItemLoot("Honey Circlet", 0.05),
                new ItemLoot("Beehemoth Armor Yellow", 0.03),
                new ItemLoot("Beehemoth Armor Blue", 0.03),
                new ItemLoot("Beehemoth Armor Red", 0.03),
                new ItemLoot("Honey Scepter", 0.05),
                new ItemLoot("Orb of Sweet Demise", 0.05),
                new ItemLoot("Path of Loot Key", 0.0005),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.5),
                new ItemLoot("Potion of Life", 1.0),
                new ItemLoot("Potion of Mana", 1.0),
                new ItemLoot("Greater Potion of Dexterity", 1.0),
                new ItemLoot("Greater Potion of Dexterity", 1.0),
                new TierLoot(12, ItemType.Weapon, 0.15),
                new TierLoot(6, ItemType.Ability, 0.15),
                new TierLoot(13, ItemType.Armor, 0.15),
                new ItemLoot("Ring of Unbound Health", 0.1)
                )
            )
            ;
    }
}