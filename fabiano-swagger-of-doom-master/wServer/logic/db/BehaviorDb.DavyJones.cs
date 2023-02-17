#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ DavyJones = () => Behav()
            .Init("Davy Jones",
                new State(
                    new State("Wait",
                        new Wander(.1),
                        new TimedTransition(5000, "Floating")
                        ),
                    new State("Floating",
                        new Wander(.25),
                        new Shoot(10, 5, 10, 0, coolDown: 800),
                        new Shoot(10, 1, 10, 1, coolDown: 1600)
                        )
                    ),
                new Threshold(0.001,
                new ItemLoot("Soul Warden", 0.004),
                new ItemLoot("Seal of the Necropolis", 0.004),
                new ItemLoot("The Nuruaj", 0.01),
                new ItemLoot("The Darkin Skull", 0.01),
                new ItemLoot("Shiny Diver's Breastplate", 0.01),
                new ItemLoot("Entropy Reactor", 0.04),
                new ItemLoot("Orb of Aether", 0.045),
                new ItemLoot("Spirit Dagger", 0.05),
                new ItemLoot("Ghostly Prism", 0.05),
                new ItemLoot("Spectral Cloth Armor", 0.08),
                new ItemLoot("Captain's Ring", 0.10),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Potion of Attack", 1.0),
                new ItemLoot("Potion of Wisdom", 1.0),
                new ItemLoot("Potion of Attack", 0.75),
                new ItemLoot("Potion of Wisdom", 0.75),
                new TierLoot(9, ItemType.Weapon, 0.15),
                new TierLoot(10, ItemType.Weapon, 0.15),
                new TierLoot(11, ItemType.Weapon, 0.15),
                new TierLoot(4, ItemType.Ability, 0.17),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(10, ItemType.Armor, 0.12),
                new TierLoot(11, ItemType.Armor, 0.12),
                new TierLoot(12, ItemType.Armor, 0.12),
                new TierLoot(4, ItemType.Ring, 0.13),
                new TierLoot(5, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Ghost Lanturn Off",
                new State(
                    new TransformOnDeath("Ghost Lanturn On")
                    )
            )
            .Init("Ghost Lanturn On",
                new State(
                    new State("idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "deactivate")
                        ),
                    new State("deactivate",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Ghost Lanturn Off", 10, "shoot"),
                        new TimedTransition(10000, "gone")
                        ),
                    new State("shoot",
                        new Shoot(10, 6, coolDown: 9000001, coolDownOffset: 100),
                        new TimedTransition(1000, "gone")
                        ),
                    new State("gone",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Transform("Ghost Lanturn Off")
                        )
                    )
            );
    }
}