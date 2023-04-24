using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ OceanTrench = () => Behav()
            .Init("Thessal the Mermaid Goddess",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Wander(0.22),
                        new TimedTransition(6000, "Fight")
                    ),
                    new State("Fight",
                    new Wander(0.22),
                    new Shoot(25, projectileIndex: 0, count: 12, shootAngle: 30, coolDown: 4000, coolDownOffset: 400), //armorbreak
                    new Shoot(25, projectileIndex: 1, count: 1, coolDown: 200), //trident
                    new Shoot(25, projectileIndex: 2, count: 5, shootAngle: 12, predictive: 0.4, coolDown: 2000), //supertrident
                    new Shoot(25, projectileIndex: 3, count: 20, shootAngle: 18, fixedAngle: 0, coolDownOffset: 3000, coolDown: 5000) //weaken
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Poseidon's Trident", 0.0005),
                new ItemLoot("Robe of the Draconic Overlord", 0.005),
                new ItemLoot("Wavebreaker", 0.005),
                new ItemLoot("Bow of Warped Coral", 0.01),
                new ItemLoot("Flames of Purity", 0.01),
                new ItemLoot("Covering of Mermaid Goddess", 0.01),
                new ItemLoot("Radiant Wand of Royalism", 0.01),
                new ItemLoot("Oceanic Treasure", 0.04),
                new ItemLoot("Coral Anchor", 0.04),
                new ItemLoot("Coral Bow", 0.05),
                new ItemLoot("Coral Venom Trap", 0.05),
                new ItemLoot("Coral Silk Armor", 0.08),
                new ItemLoot("Coral Ring", 0.1),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.4),
                new ItemLoot("Potion of Mana", 1),
                new ItemLoot("Potion of Mana", 0.25),
                new ItemLoot("Potion of Wisdom", 0.25),
                new ItemLoot("Potion of Attack", 0.25),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Coral Gift",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3000, "CGift")
                    ),
                    new State("CGift")
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Poseidon's Trident", 0.0001),
                new ItemLoot("Robe of the Draconic Overlord", 0.001),
                new ItemLoot("Wavebreaker", 0.001),
                new ItemLoot("Bow of Warped Coral", 0.003),
                new ItemLoot("Flames of Purity", 0.003),
                new ItemLoot("Covering of Mermaid Goddess", 0.003),
                new ItemLoot("Radiant Wand of Royalism", 0.003),
                new ItemLoot("Oceanic Treasure", 0.022),
                new ItemLoot("Coral Anchor", 0.02),
                new ItemLoot("Coral Bow", 0.033),
                new ItemLoot("Coral Venom Trap", 0.033),
                new ItemLoot("Coral Silk Armor", 0.06),
                new ItemLoot("Coral Ring", 0.08),
                new ItemLoot("Potion of Mana", 0.25),
                new ItemLoot("Potion of Wisdom", 0.25),
                new ItemLoot("Coral Juice", 0.5),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            ;
    }
}