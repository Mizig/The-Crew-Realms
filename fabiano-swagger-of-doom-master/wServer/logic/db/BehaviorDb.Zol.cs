using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Zol = () => Behav()
            .Init("Zol Tile Worker",
                new State(
                    new State("Off",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Spawn("Zol Tile Off Spawner", maxChildren: 1, initialSpawn: 1, coolDown: 9999),
                        new TimedTransition(5000, "On")
                    ),
                    new State("On",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Spawn("Zol Tile On Spawner", maxChildren: 1, initialSpawn: 1, coolDown: 9999),
                        new TimedTransition(5000, "Off")
                    )
                )
            )
            .Init("Zol Tile Off Spawner",
                new State(
                    new OnDeathBehavior(new ApplySetpiece("ZolTileOff")),
                    new State("Default",
                        new Suicide()
                    )
                )
            )
            .Init("Zol Tile On Spawner",
                new State(
                    new OnDeathBehavior(new ApplySetpiece("ZolTileOn")),
                    new State("Default",
                        new Suicide()
                    )
                )
            )
            ;
    }
}