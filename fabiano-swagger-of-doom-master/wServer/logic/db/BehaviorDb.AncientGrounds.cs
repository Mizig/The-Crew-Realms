using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ AncientGrounds = () => Behav()
            .Init("md1 Head of Shaitan",
                new State(
                ),
                new Threshold(0.001,
                new ItemLoot("Skull of Endless Torment", 0.1),
                new ItemLoot("Greater Potion of Dexterity", 1.00),
                new ItemLoot("Greater Potion of Dexterity", 1.00)
                )
            )
            ;
    }
}