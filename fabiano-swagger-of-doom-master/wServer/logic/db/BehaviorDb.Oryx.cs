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
                new ItemLoot("Covering of Winter Goddess", 0.002),
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
                new ItemLoot("Santa's Battle Attire", 0.002),
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
                new ItemLoot("Christmas Garments", 0.002),
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
                new ItemLoot("Elicia Blanket", 0.0005),
                new ItemLoot("Peppermint Candy Bow", 0.008),
                new ItemLoot("Festive Quiver", 0.008),
                new ItemLoot("Elf Suit", 0.008),
                new ItemLoot("Merrystone", 0.008),
                new ItemLoot("Star of the North Pole", 0.009),
                new ItemLoot("Wand of Ornaments", 0.009),
                new ItemLoot("North Pole's Slasher", 0.009),
                new ItemLoot("North Pole's Orb", 0.009),
                new ItemLoot("Chocolate Cookie", 0.009),
                new ItemLoot("Robe of Celebration", 0.009),
                new ItemLoot("Santa's Battlesuit", 0.009),
                new ItemLoot("Kurisumasu no Uwagi", 0.009),
                new ItemLoot("Santa's Coat", 0.009),
                new ItemLoot("Santa Hat", 0.009),
                new ItemLoot("Santa's Mitten", 0.009),
                //new ItemLoot("Ring of the New Sun", 0.008),
                new ItemLoot("Frosty's Walking Stick", 0.05),
                new ItemLoot("Path of Loot Key", 0.000125),
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
                new ItemLoot("Blondie's Claws", 0.0005),
                new ItemLoot("Morningstar of Honey", 0.004),
                new ItemLoot("Ring of the Cosmos", 0.004),
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
                new ItemLoot("Wand of the Galaxy", 0.0005),
                new ItemLoot("Crown of the Universe", 0.0005),
                new ItemLoot("Plasma Bee Wand", 0.005),
                new ItemLoot("Beacon of Light", 0.005),
                new ItemLoot("Laser Gun", 0.005),
                new ItemLoot("Lightsaber", 0.005),
                new ItemLoot("Star of Light", 0.005),
                new ItemLoot("Lightshow", 0.005),
                new ItemLoot("Lightspeed Travel Cloak", 0.005),
                new ItemLoot("Skull of the Light Lord", 0.005),
                new ItemLoot("Hide of Light", 0.005),
                new ItemLoot("Light Core", 0.005),
                new ItemLoot("Light's Orbit", 0.005),
                new ItemLoot("Plasmastone", 0.005),
                new ItemLoot("Plasma Sprout", 0.005),
                new ItemLoot("Tablet of Doom", 0.005),
                new ItemLoot("The Great Lightsword", 0.01),
                new ItemLoot("Starcrash Ring", 0.011),
                new ItemLoot("Backpack", 0.1),
                new ItemLoot("Path of Loot Key", 0.001),
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
            .Init("Marble Brick Colossus",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(10, "First")
                    ),
                    new State("First",
                        new Taunt("Look upon my mighty bulwark."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "Placeholderr")
                    ),
                    new State("First",
                        new Taunt("Call of voice, for naught. Plea of mercy, for naught. None may enter this chamber and live!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, projectileIndex: 2, count: 10, shootAngle: 36, coolDown: 500, coolDownOffset: 250),
                        new TimedTransition(4000, "Placeholderr")
                    ),
                    new State("Placeholderr",
                        new Follow(.18, 20, 1),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 10, coolDown: 1000),
                        new Shoot(25, projectileIndex: 1, count: 9, shootAngle: 25, predictive: 0.4, coolDown: 1600, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 10, shootAngle: 36, coolDown: 500, coolDownOffset: 250),
                        new HpLessTransition(0.12, "DeathBoom")
                    ),
                    new State("DeathBoom",
                        new Taunt("I feel myself… slipping… into the void… it is so… dark…"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3000, "BlowUp")
                    ),
                    new State("BlowUp",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, projectileIndex: 0, count: 36, shootAngle: 10, fixedAngle: 0, coolDown: 9999),
                        new Shoot(25, projectileIndex: 1, count: 18, shootAngle: 20, fixedAngle: 6, coolDown: 9999),
                        new Suicide()
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Snare of the Lurking Titan", 0.0005),
                new ItemLoot("Omnipotence Ring", 0.004),
                new ItemLoot("Sword of the Colossus", 0.009),
                new ItemLoot("Marble Seal", 0.009),
                new ItemLoot("Breastplate of New Life", 0.009),
                new ItemLoot("Magical Lodestone", 0.009),
                new ItemLoot("Bow of the Void", 0.009),
                new ItemLoot("Quiver of the Shadows", 0.009),
                new ItemLoot("Armor of Nil", 0.009),
                new ItemLoot("Sourcestone", 0.009),
                new ItemLoot("Staff of Unholy Sacrifice", 0.009),
                new ItemLoot("Skull of Corrupted Souls", 0.009),
                new ItemLoot("Ritual Robe", 0.009),
                new ItemLoot("Bloodshed Ring", 0.009),
                new ItemLoot("Path of Loot Key", 0.0005),
                new ItemLoot("Greater Potion of Life", 1.0),
                new ItemLoot("Greater Potion of Mana", 1.0),
                new ItemLoot("Greater Potion of Attack", 1.0),
                new ItemLoot("Greater Potion of Defense", 1.0),
                new TierLoot(12, ItemType.Weapon, 0.14),
                new TierLoot(6, ItemType.Ability, 0.14),
                new TierLoot(13, ItemType.Armor, 0.14),
                new ItemLoot("Ring of Unbound Health", 0.1)
                )
            )
            .Init("Chubby Cow",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(8, "WanderingWait")
                    ),
                    new State("WanderingWait",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "Charge1")
                    ),
                    new State("Wandering",
                        new Taunt("Moo"),
                        new Wander(0.33),
                        new Follow(.1, 20, 4),
                        new Shoot(25, projectileIndex: 0, count: 9, shootAngle: 40, coolDown: 600),
                        new Shoot(25, projectileIndex: 1, count: 20, shootAngle: 18, fixedAngle: 0, coolDown: 1200, coolDownOffset: 400),
                        new Shoot(25, projectileIndex: 2, count: 8, shootAngle: 45, fixedAngle: 22, coolDown: 1800, coolDownOffset: 1000),
                        new TimedTransition(7000, "Charge1")
                    ),
                    new State("Charge1",
                        new Taunt("MOO!!!"),
                        new Follow(1, 20, 0.1),
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
                new ItemLoot("Old Farmer's Leather Book", 0.0005),
                new ItemLoot("Page of Catatonia", 0.004),
                new ItemLoot("March of the Army", 0.01),
                new ItemLoot("Cow Horns", 0.05),
                new ItemLoot("Cow Skin Shield", 0.05),
                new ItemLoot("Milky Orb", 0.05),
                new ItemLoot("Path of Loot Key", 0.00025),
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
            .Init("Spectral Sentry",
                new State(
                    new DropPortalOnDeath("Lost Halls Portal", 100),
                    new State("Wandering",
                        new Wander(0.45),
                        new Shoot(25, projectileIndex: 0, count: 12, shootAngle: 30, fixedAngle: 0, coolDown: 1200),
                        new Shoot(25, projectileIndex: 1, count: 12, shootAngle: 30, fixedAngle: 11, coolDown: 1400, coolDownOffset: 600),
                        new Shoot(25, projectileIndex: 2, count: 10, shootAngle: 36, fixedAngle: 22, coolDown: 1600, coolDownOffset: 1000)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Soulfester", 0.0005),
                new ItemLoot("Ghost Robe", 0.004),
                new ItemLoot("Scythe of Death", 0.004),
                new ItemLoot("Gileon's Spirit", 0.004),
                new ItemLoot("Harlequin's Crossbow", 0.01),
                new ItemLoot("Cloak of Bloody Surprises", 0.05),
                new ItemLoot("Path of Loot Key", 0.00025),
                new ItemLoot("Greater Potion of Speed", 1.0),
                new ItemLoot("Greater Potion of Dexterity", 1.0),
                new ItemLoot("Greater Potion of Wisdom", 1.0),
                new ItemLoot("Greater Potion of Vitality", 1.0),
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
                new ItemLoot("Handcannon", 0.0005),
                new ItemLoot("Sword of Oryx", 0.0043),
                new ItemLoot("Helm of Oryx", 0.0043),
                new ItemLoot("Armor of Oryx", 0.0043),
                new ItemLoot("Ring of Oryx", 0.0043),
                new ItemLoot("Saturn's Orbit", 0.0047),
                new ItemLoot("Vulcanstriker", 0.01),
                new ItemLoot("Death's Gem", 0.01),
                new ItemLoot("Thousand Shot", 0.05),
                new ItemLoot("Sword of the Mad God", 0.03),
                new ItemLoot("Onyx Shield of the Mad God", 0.03),
                new ItemLoot("Almandine Armor of Anger", 0.03),
                new ItemLoot("Almandine Ring of Wrath", 0.03),
                new ItemLoot("Backpack", 0.15),
                new ItemLoot("Path of Loot Key", 0.001),
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
                new ItemLoot("Boshy Gun", 0.0005),
                new ItemLoot("Harbinger of Fury", 0.0043),
                new ItemLoot("Oryx's Decapitator", 0.0043),
                new ItemLoot("Seal of Oryx", 0.0043),
                new ItemLoot("Vanguard of Oryx", 0.0043),
                new ItemLoot("Amulet of Pure Madness", 0.0043),
                new ItemLoot("The Twilight Grimoire", 0.0047),
                new ItemLoot("Jackpot", 0.01),
                new ItemLoot("Captain America Sword", 0.05),
                new ItemLoot("Band of Oryx", 0.05),
                new ItemLoot("Path of Loot Key", 0.0005),
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