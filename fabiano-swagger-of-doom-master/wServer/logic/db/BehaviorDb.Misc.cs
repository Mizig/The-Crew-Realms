using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using wServer.logic.behaviors.Drakes;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Misc = () => Behav()
            .Init("Ultimate Doom",
                new State(
                    new State("Goodbye",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new InvisiToss("Archdemon Malphas", 1, 0, 90000001),
                        new InvisiToss("shtrs Defense System", 1, 0, 90000001),
                        new InvisiToss("Masked Party God", 1, 0, 90000001),
                        new InvisiToss("vlntns Botany Bella", 1, 0, 90000001),
                        new InvisiToss("Boshy", 1, 0, 90000001),
                        new InvisiToss("Gigacorn", 1, 0, 90000001),
                        new InvisiToss("Candy Gnome", 1, 0, 90000001),
                        new InvisiToss("Spoiled Creampuff", 1, 0, 90000001),
                        new InvisiToss("Desire Troll", 1, 0, 90000001),
                        new InvisiToss("Arena Headless Horseman", 1, 0, 90000001),
                        new InvisiToss("TestChicken 2", 1, 0, 90000001),
                        new InvisiToss("Crystal Prisoner", 1, 0, 90000001),
                        new InvisiToss("Chubby Cow", 1, 0, 90000001),
                        new InvisiToss("Cube God", 1, 0, 90000001),
                        new InvisiToss("Cyclops God", 1, 0, 90000001),
                        new InvisiToss("Davy Jones", 1, 0, 90000001),
                        new InvisiToss("Deathmage", 1, 0, 90000001),
                        new InvisiToss("Ent Ancient", 1, 0, 90000001),
                        new InvisiToss("Ghost King", 1, 0, 90000001),
                        new InvisiToss("Mama Megamoth", 1, 0, 90000001),
                        new InvisiToss("Ghost Ship", 1, 0, 90000001),
                        new InvisiToss("Grand Sphinx", 1, 0, 90000001),
                        new InvisiToss("Great Coil Snake", 1, 0, 90000001),
                        new InvisiToss("Hermit God", 1, 0, 90000001),
                        new InvisiToss("ic Esben the Unwilling", 1, 0, 90000001),
                        new InvisiToss("Lich", 1, 0, 90000001),
                        new InvisiToss("The Light Lord", 1, 0, 90000001),
                        new InvisiToss("Marble Brick Colossus", 1, 0, 90000001),
                        new InvisiToss("Lord of the Lost Lands", 1, 0, 90000001),
                        new InvisiToss("Dr Terrible", 1, 0, 90000001),
                        new InvisiToss("Killer Bee Queen", 1, 0, 90000001),
                        new InvisiToss("Oasis Giant", 1, 0, 90000001),
                        new InvisiToss("Thessal the Mermaid Goddess", 1, 0, 90000001),
                        new InvisiToss("Oryx the Mad God 1", 1, 0, 90000001),
                        new InvisiToss("Oryx the Mad God 2", 1, 0, 90000001),
                        new InvisiToss("Oryx Stone Guardian Left", 1, 0, 90000001),
                        new InvisiToss("Oryx Stone Guardian Right", 1, 0, 90000001),
                        new InvisiToss("Pentaract Tower", 1, 0, 90000001),
                        new InvisiToss("Phoenix Lord", 1, 0, 90000001),
                        new InvisiToss("Red Demon", 1, 0, 90000001),
                        new InvisiToss("Evil Santa", 1, 0, 90000001),
                        new InvisiToss("shtrs Bridge Sentinel", 1, 0, 90000001),
                        new InvisiToss("shtrs Twilight Archmage", 1, 0, 90000001),
                        new InvisiToss("shtrs The Forgotten King", 1, 0, 90000001),
                        new InvisiToss("Skull Shrine", 1, 0, 90000001),
                        new InvisiToss("Stheno the Snake Queen", 1, 0, 90000001),
                        new InvisiToss("Spectral Sentry", 1, 0, 90000001),
                        new InvisiToss("Limon the Sprite God", 1, 0, 90000001),
                        new InvisiToss("Arachna the Spider Queen", 1, 0, 90000001),
                        new InvisiToss("Tomb Defender", 1, 0, 90000001),
                        new InvisiToss("Tomb Support", 1, 0, 90000001),
                        new InvisiToss("Tomb Attacker", 1, 0, 90000001),
                        new InvisiToss("Ugajuajn", 1, 0, 90000001),
                        new InvisiToss("Septavius the Ghost God", 1, 0, 90000001),
                        new InvisiToss("Murderous Megamoth", 1, 0, 90000001),
                        new TimedTransition(200, "haha")
                    ),
                    new State("haha",
                        new Suicide(),
                        new Taunt("GOODBYE!!!!!!!!!!!!!!!!!")
                    )
                )
            )
            .Init("Spirit Prism Bomb",
                new State(
                    new State("Idle",
                        new TimedTransition(1000, "Explode")
                    ),
                    new State("Explode",
                        new Prioritize(
                            new StayCloseToSpawn(3, 3)
                        ),
                        new State("Explode 1",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new ChangeSize(100, 0),
                            new PlaySound(),
                            new Aoe(2, false, 500, 750, false, 0xFF9933),
                            new TimedTransition(100, "Explode 2")
                        ),
                        new State("Explode 2",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 500, 750, false, 0xFF9933),
                            new TimedTransition(100, "Explode 3")
                        ),
                        new State("Explode 3",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 500, 750, false, 0xFF9933),
                            new TimedTransition(100, "Explode 4")
                        ),
                        new State("Explode 4",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 500, 750, false, 0xFF9933),
                            new TimedTransition(100, "Explode 5")
                        ),
                        new State("Explode 5",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 500, 750, false, 0xFF9933),
                            new TimedTransition(100, "Explode 6")
                        ),
                        new State("Explode 6",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 500, 750, false, 0xFF9933),
                            new Decay(0)
                        )
                    )
                )
            )
            .Init("Cosmic Prism Bomb",
                new State(
                    new State("Idle",
                        new TimedTransition(200, "Explode")
                    ),
                    new State("Explode",
                        new Prioritize(
                            new StayCloseToSpawn(3, 3)
                        ),
                        new State("Explode 1",
                            new PlaySound(),
                            new Aoe(4, false, 2500, 3000, false, 0x41316B),
                            new TimedTransition(100, "Explode 2")
                        ),
                        new State("Explode 2",
                            new PlaySound(),
                            new Aoe(4, false, 2500, 3000, false, 0x41316B),
                            new TimedTransition(100, "Explode 3")
                        ),
                        new State("Explode 3",
                            new PlaySound(),
                            new Aoe(4, false, 2500, 3000, false, 0x41316B),
                            new TimedTransition(100, "Explode 4")
                        ),
                        new State("Explode 4",
                            new PlaySound(),
                            new Aoe(4, false, 2500, 3000, false, 0x41316B),
                            new Decay(0)
                        )
                    )
                )
            )
            .Init("Big Firecracker",
                new State(
                    new State("Explode",
                        new Prioritize(
                            new StayCloseToSpawn(3, 3)
                        ),
                        new State("Explode 1",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(2, 4), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(250, "Explode 2")
                        ),
                        new State("Explode 2",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(2, 4), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 3")
                        ),
                        new State("Explode 3",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(2, 4), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 4")
                        ),
                        new State("Explode 4",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(2, 4), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 5")
                        ),
                        new State("Explode 5",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(2, 4), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 6")
                        ),
                        new State("Explode 6",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(2, 4), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 7")
                        ),
                        new State("Explode 7",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(2, 4), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 8")
                        ),
                        new State("Explode 8",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(2, 4), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 9")
                        ),
                        new State("Explode 9",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(2, 4), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 10")
                        ),
                        new State("Explode 10",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(2, 4), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new Decay(0)
                        )
                    )
                )
            )
            .Init("Lil Firecracker",
                new State(
                    new State("Explode",
                        new Prioritize(
                            new StayCloseToSpawn(3, 3)
                        ),
                        new State("Explode 1",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(1, 2), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 2")
                        ),
                        new State("Explode 2",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(1, 2), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 3")
                        ),
                        new State("Explode 3",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(1, 2), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 4")
                        ),
                        new State("Explode 4",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(1, 2), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 5")
                        ),
                        new State("Explode 5",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(1, 2), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 6")
                        ),
                        new State("Explode 6",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(1, 2), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 7")
                        ),
                        new State("Explode 7",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(1, 2), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 8")
                        ),
                        new State("Explode 8",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(1, 2), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 9")
                        ),
                        new State("Explode 9",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(1, 2), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new TimedTransition(100, "Explode 10")
                        ),
                        new State("Explode 10",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(Random.Next(1, 2), false, 100, 100, true, (uint)Random.Next(0x0000000, 0xFFFFFF)),
                            new Decay(0)
                        )
                    )
                )
            )
            .Init("Rock Candy Grenade",
                new State(
                    new State("Explode",
                        new Prioritize(
                            new StayCloseToSpawn(3, 3)
                        ),
                        new State("Explode 1",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 100, 200, true, 0xFF6633),
                            new TimedTransition(100, "Explode 2")
                        ),
                        new State("Explode 2",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 100, 200, true, 0xFF6633),
                            new TimedTransition(100, "Explode 3")
                        ),
                        new State("Explode 3",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 100, 200, true, 0xFF6633),
                            new TimedTransition(100, "Explode 4")
                        ),
                        new State("Explode 4",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 100, 200, true, 0xFF6633),
                            new TimedTransition(100, "Explode 5")
                        ),
                        new State("Explode 5",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 100, 200, true, 0xFF6633),
                            new TimedTransition(100, "Explode 6")
                        ),
                        new State("Explode 6",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 100, 200, true, 0xFF6633),
                            new TimedTransition(100, "Explode 7")
                        ),
                        new State("Explode 7",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 100, 200, true, 0xFF6633),
                            new TimedTransition(100, "Explode 8")
                        ),
                        new State("Explode 8",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 100, 200, true, 0xFF6633),
                            new TimedTransition(100, "Explode 9")
                        ),
                        new State("Explode 9",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 100, 200, true, 0xFF6633),
                            new TimedTransition(100, "Explode 10")
                        ),
                        new State("Explode 10",
                            new JumpToRandomOffset(-1, 1, -1, 1),
                            new PlaySound(),
                            new Aoe(2, false, 100, 200, true, 0xFF6633),
                            new Decay(0)
                        )
                    )
                )
            )
            .Init("Zombie Trickster",
                new State(
                    new Wander(1)
                )
            )
            .Init("White Drake",
                new State(
                    new DrakeFollow(),
                    new WhiteDrakeAttack()
                )
            )
            .Init("Blue Drake",
                new State(
                    new DrakeFollow(),
                    new BlueDrakeAttack()
                )
            )
            .Init("Purple Drake",
                new State(
                    new DrakeFollow(),
                    new PurpleDrakeAttack()
                )
            )
            .Init("Orange Drake",
                new State(
                    new DrakeFollow(),
                    new OrangeDrakeAttack()
                )
            )
            .Init("Yellow Drake",
                new State(
                    new DrakeFollow(),
                    new YellowDrakeAttack()
                )
            )
            .Init("Green Drake",
                new State(
                    new DrakeFollow(),
                    new GreenDrakeAttack()
                )
            )
            .Init("West Tutorial Gun",
                new State(
                    new Shoot(32, fixedAngle: 180, coolDown: new Cooldown(3000, 1000))
                    )
            )
            .Init("North Tutorial Gun",
                new State(
                    new Shoot(32, fixedAngle: 270, coolDown: new Cooldown(3000, 1000))
                    )
            )
            .Init("East Tutorial Gun",
                new State(
                    new Shoot(32, fixedAngle: 0, coolDown: new Cooldown(3000, 1000))
                    )
            )
            .Init("South Tutorial Gun",
                new State(
                    new Shoot(32, fixedAngle: 90, coolDown: new Cooldown(3000, 1000))
                    )
            )
            .Init("Evil Chicken",
                new State(
                    new Wander(0.3)
                    )
            )
            .Init("Evil Chicken Minion",
                new State(
                    new Wander(0.3),
                    new Protect(0.3, "Evil Chicken God")
                    )
            )
            .Init("Evil Chicken God",
                new State(
                    new Prioritize(
                        new Follow(0.4, range: 5),
                        new Wander(0.3)
                        ),
                    new Reproduce("Evil Chicken Minion", densityMax: 12)
                    )
            )
            .Init("Evil Hen",
                new State(
                    new Wander(0.3)
                    ),
                new ItemLoot("Minor Health Potion", 1)
            )
            .Init("Kitchen Guard",
                new State(
                    new Prioritize(
                        new Follow(0.6, range: 6),
                        new Wander(0.4)
                        ),
                    new Shoot(7)
                    )
            )
            .Init("Butcher",
                new State(
                    new Prioritize(
                        new Follow(0.8, range: 1),
                        new Wander(0.4)
                        ),
                    new Shoot(3)
                    ),
                new ItemLoot("Minor Health Potion", 0.1),
                new ItemLoot("Minor Magic Potion", 0.1)
            )
            .Init("Bonegrind the Butcher",
                new State(
                    new State("Begin",
                        new Wander(0.6),
                        new PlayerWithinTransition(10, "AttackX")
                        ),
                    new State("AttackX",
                        new Taunt("Ah, fresh meat for the minions!"),
                        new Shoot(6, coolDown: 1400),
                        new Prioritize(
                            new Follow(0.6, 9, 3),
                            new Wander(0.6)
                            ),
                        new TimedTransition(4500, "AttackY"),
                        new HpLessTransition(0.3, "Flee")
                        ),
                    new State("AttackY",
                        new Prioritize(
                            new Follow(0.6, 9, 3),
                            new Wander(0.6)
                            ),
                        new Sequence(
                            new Shoot(7, 4, fixedAngle: 25),
                            new Shoot(7, 4, fixedAngle: 50),
                            new Shoot(7, 4, fixedAngle: 75),
                            new Shoot(7, 4, fixedAngle: 100),
                            new Shoot(7, 4, fixedAngle: 125)
                            ),
                        new TimedTransition(5200, "AttackX"),
                        new HpLessTransition(0.3, "Flee")
                        ),
                    new State("Flee",
                        new Taunt("The meat ain't supposed to bite back! Waaaaa!!"),
                        new Flash(0xff000000, 10, 100),
                        new Prioritize(
                            new StayBack(0.5, 6),
                            new Wander(0.5)
                            )
                        )
                    ),
                new ItemLoot("Minor Health Potion", 1),
                new ItemLoot("Minor Magic Potion", 1)
            )
            .Init("White Fountain",
                new State(
                    new NexusHealHp(11, 2000, 200),
                    new NexusHealMp(11, 2000, 200)
                    )
            )
            .Init("Winter Fountain Frozen", //Frozen <3
                                            //Kabam let it go :DDD
                new State(
                    new NexusHealHp(11, 2000, 200),
                    new NexusHealMp(11, 2000, 200)
                    )
            )
            .Init("Sheep",
                new State(
                    new PlayerWithinTransition(15, "player_nearby"),
                    new State("player_nearby",
                        new Prioritize(
                            new StayCloseToSpawn(0.1, 2),
                            new Wander(0.1)
                            ),
                        new Taunt(0.001, 1000, "baa", "baa baa")
                        )
                    )
            )
            .Init("Realm Portal Opener",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true)
                )
            );
    }
}
