using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ LightLord = () => Behav()
            .Init("The Light Lord",
                new State(
                    new State("HelloWorld",
                        new Taunt("I see you have chosen to fight me."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "HelloWorld2")
                    ),
                    new State("HelloWorld2",
                        new Taunt("You will not come out greater than me."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x00FF00, 1.5, 1),
                        new Shoot(25, projectileIndex: 4, count: 60, shootAngle: 6, fixedAngle: 0, predictive: 0.6, coolDown: 20000, coolDownOffset: 2200),
                        new TimedTransition(2500, "LaserShow")
                    ),
                    new State("LaserShow",
                        new Taunt("It's time for a laser show!"),
                        new Shoot(25, projectileIndex: 0, count: 12, shootAngle: 30, fixedAngle: 20, coolDown: 800),
                        new Shoot(25, projectileIndex: 0, count: 9, shootAngle: 20, predictive: 0.4, coolDown: 1000, coolDownOffset: 400),
                        new Shoot(25, projectileIndex: 1, count: 16, shootAngle: 15, coolDown: 1400, coolDownOffset: 1000),
                        new HpLessTransition(.73, "PlasmaParty")
                    ),
                    new State("PlasmaParty",
                        new Taunt("Have some plasma!"),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(25, projectileIndex: 2, count: 15, shootAngle: 20, coolDown: 1200),
                        new Shoot(25, projectileIndex: 1, count: 15, shootAngle: 20, coolDown: 1000),
                        new Shoot(25, projectileIndex: 2, count: 4, shootAngle: 8, predictive: 0.2, coolDown: 700),
                        new Shoot(25, projectileIndex: 2, count: 12, shootAngle: 30, predictive: 0.6, fixedAngle: 110, coolDown: 650, coolDownOffset: 400),
                        new HpLessTransition(.46, "LightSpam")
                    ),
                    new State("LightSpam",
                        new Taunt("Be blasted by light!"),
                        new Shoot(25, projectileIndex: 1, count: 15, shootAngle: 22, coolDown: 800),
                        new Shoot(25, projectileIndex: 3, count: 10, shootAngle: 10, predictive: 0.8, coolDown: 800),
                        new Shoot(25, projectileIndex: 3, count: 20, shootAngle: 18, fixedAngle: 85, coolDown: 1000, coolDownOffset: 400),
                        new Shoot(25, projectileIndex: 3, count: 5, shootAngle: 15, predictive: 0.2, coolDown: 800, coolDownOffset: 400),
                        new HpLessTransition(.19, "quiet")
                    ),
                    new State("quiet",
                        new Wander(.05),
                        new Taunt("Get back!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, projectileIndex: 4, count: 60, shootAngle: 6, fixedAngle: 0, predictive: 0.6, coolDown: 300),
                        new TimedTransition(1600, "quiet2")
                    ),
                    new State("quiet2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "lordrage")
                    ),
                    new State("lordrage",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Follow(.08, 15, 3),
                        new Taunt("This ends here!"),
                        new Shoot(25, projectileIndex: 0, count: 6, shootAngle: 4, predictive: 0.1, coolDown: 250),
                        new Shoot(25, projectileIndex: 1, count: 15, shootAngle: 24, predictive: 0.4, coolDown: 800),
                        new Shoot(25, projectileIndex: 2, count: 18, shootAngle: 20, fixedAngle: 0, coolDown: 1000, coolDownOffset: 350),
                        new Shoot(25, projectileIndex: 3, count: 24, shootAngle: 15, fixedAngle: 0, coolDown: 1700, coolDownOffset: 700)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Wand of the Galaxy", 0.0005),
                new ItemLoot("Crown of the Universe", 0.0005),
                new ItemLoot("Plasma Bee Wand", 0.003),
                new ItemLoot("Beacon of Light", 0.003),
                new ItemLoot("Laser Gun", 0.003),
                new ItemLoot("Lightsaber", 0.003),
                new ItemLoot("Star of Light", 0.003),
                new ItemLoot("Lightshow", 0.003),
                new ItemLoot("Skull of the Light Lord", 0.003),
                new ItemLoot("Spaceship's Anchor", 0.003),
                new ItemLoot("Hide of Light", 0.003),
                new ItemLoot("Light Core", 0.003),
                new ItemLoot("Light's Orbit", 0.003),
                new ItemLoot("Plasmastone", 0.003),
                new ItemLoot("Plasma Sprout", 0.003),
                new ItemLoot("Tablet of Doom", 0.004),
                new ItemLoot("The Great Lightsword", 0.0095),
                new ItemLoot("V-L Spark Armor", 0.01),
                new ItemLoot("Starcrash Ring", 0.01),
                new ItemLoot("Backpack", 0.1),
                new ItemLoot("Path of Loot Key", 0.001),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.85),
                new ItemLoot("Greater Potion of Life", 1.0),
                new ItemLoot("Greater Potion of Life", 0.4),
                new ItemLoot("Greater Potion of Defense", 1.0),
                new ItemLoot("Greater Potion of Defense", 0.4),
                new ItemLoot("Greater Potion of Attack", 1.0),
                new ItemLoot("Greater Potion of Attack", 0.4),
                new ItemLoot("Greater Potion of Wisdom", 1.0),
                new ItemLoot("Greater Potion of Wisdom", 0.4),
                new TierLoot(12, ItemType.Weapon, 0.22),
                new TierLoot(6, ItemType.Ability, 0.22),
                new TierLoot(13, ItemType.Armor, 0.22),
                new ItemLoot("Ring of Unbound Health", 0.15)
                )
            )
            ;
    }
}