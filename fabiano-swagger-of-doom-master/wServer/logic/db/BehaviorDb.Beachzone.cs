using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Beachzone = () => Behav()
            .Init("Masked Party God",
                new State(
                    new Heal(1, "Self", 10000),
                    new State("1",
                        new Taunt(true, "Oh no, Mixcoatl is my brother, I prefer partying to fighting."),
                        new SetAltTexture(1),
                        new TimedTransition(2500, "2")
                    ),
                    new State("2",
                        new Taunt(true, "Lets have a fun-time in the sun-shine!"),
                        new SetAltTexture(2),
                        new TimedTransition(2500, "3")
                    ),
                    new State("3",
                        new Taunt(true, "Nothing like relaxin' on the beach."),
                        new SetAltTexture(3),
                        new TimedTransition(2500, "4")
                    ),
                    new State("4",
                        new Taunt(true, "Chillin' is the name of the game!"),
                        new SetAltTexture(1),
                        new TimedTransition(2500, "5")
                    ),
                    new State("5",
                        new Taunt(true, "I hope you're having a good time!"),
                        new SetAltTexture(2),
                        new TimedTransition(2500, "6")
                    ),
                    new State("6",
                        new Taunt(true, "How do you like my shades?"),
                        new SetAltTexture(3),
                        new TimedTransition(2500, "7")
                    ),
                    new State("7",
                        new Taunt(true, "EVERYBODY BOOGEY!"),
                        new SetAltTexture(1),
                        new TimedTransition(2500, "8")
                    ),
                    new State("8",
                        new Taunt(true, "What a beautiful day!"),
                        new SetAltTexture(2),
                        new TimedTransition(2500, "9")
                    ),
                    new State("9",
                        new Taunt(true, "Whoa there!"),
                        new SetAltTexture(3),
                        new TimedTransition(2500, "10")
                    ),
                    new State("10",
                        new Taunt(true, "Oh SNAP!"),
                        new SetAltTexture(1),
                        new TimedTransition(2500, "11")
                    ),
                    new State("11",
                        new Taunt(true, "Ho!"),
                        new SetAltTexture(2),
                        new TimedTransition(2500, "end")
                    ),
                    new State("end",
                        new SetAltTexture(3),
                        new TimedTransition(2500, "1")
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Top Hat", 0.002),
                new ItemLoot("Mark of Loot", 0.003),
                new ItemLoot("Lucky Potion", 0.005),
                new ItemLoot("Philosopher's Stone", 0.01),
                new ItemLoot("Red Bagston", 0.1),
                new ItemLoot("Ring of Fortune", 0.2),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 1),
                new ItemLoot("Soft Drink", 0.5),
                new ItemLoot("Fries", 0.44),
                new ItemLoot("Great Taco", 0.38),
                new ItemLoot("Power Pizza", 0.32),
                new ItemLoot("Chocolate Cream Sandwich Cookie", 0.26),
                new ItemLoot("Grapes of Wrath", 0.20),
                new ItemLoot("Superburger", 0.14),
                new ItemLoot("Double Cheeseburger Deluxe", 0.1),
                new ItemLoot("Ambrosia", 0.06),
                new ItemLoot("Irn Bru", 0.03)
                )
            );
    }
}
