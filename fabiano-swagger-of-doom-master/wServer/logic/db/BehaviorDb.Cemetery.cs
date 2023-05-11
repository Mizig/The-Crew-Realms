using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Cemetery = () => Behav()
            .Init("Arena Horseman Anchor",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
                )
            .Init("Arena Headless Horseman",
                new State(
                    new Spawn("Arena Horseman Anchor", 1, 1),
                    new State("EverythingIsCool",
                        new State("Circle",
                            new Shoot(15, 3, shootAngle: 25, projectileIndex: 0, coolDown: 1000),
                            new Shoot(15, projectileIndex: 1, coolDown: 600),
                            new Shoot(15, 8, projectileIndex: 2, coolDown: 1500),
                            new Orbit(0.9, 5, 10, "Arena Horseman Anchor"),
                            new TimedTransition(5000, "Shoot")
                        ),
                        new State("Shoot",
                            new ReturnToSpawn(),
                            new ConditionalEffect(ConditionEffectIndex.Armored),
                            new Flash(0xF0E68C, 1, 6),
                            new Shoot(15, 3, shootAngle: 25, projectileIndex: 0, coolDown: 800),
                            new Shoot(15, projectileIndex: 1, coolDown: 400),
                            new Shoot(15, 8, projectileIndex: 2, coolDown: 1500),
                            new TimedTransition(3400, "Circle")
                        )
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Sebafra's Soulcatcher", 0.004),
                new ItemLoot("Cloak of Vampirism", 0.004),
                new ItemLoot("Odin's Ravens", 0.01),
                new ItemLoot("Oracle's Nightmare", 0.01),
                new ItemLoot("Undead's Gross Bow", 0.009),
                new ItemLoot("Carrier's Suit", 0.01),
                new ItemLoot("Sincryer's Demise", 0.01),
                new ItemLoot("Soul's Guidance", 0.05),
                new ItemLoot("Plague Poison", 0.05),
                new ItemLoot("Resurrected Warrior's Armor", 0.05),
                new ItemLoot("Etherite Dagger", 0.03),
                new ItemLoot("Ghastly Drape", 0.04),
                new ItemLoot("Mantle of Skuld", 0.04),
                new ItemLoot("Spectral Ring of Horrors", 0.04),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.1),
                new ItemLoot("Potion of Attack", 0.8),
                new ItemLoot("Potion of Wisdom", 0.7),
                new ItemLoot("Potion of Speed", 0.6),
                new ItemLoot("Potion of Defense", 0.5),
                new ItemLoot("Potion of Dexterity", 0.4),
                new ItemLoot("Potion of Vitality", 0.3),
                new ItemLoot("Health Potion", 0.20),
                new ItemLoot("Magic Potion", 0.20),
                new TierLoot(8, ItemType.Weapon, 0.15),
                new TierLoot(9, ItemType.Weapon, 0.15),
                new TierLoot(4, ItemType.Ability, 0.17),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(9, ItemType.Armor, 0.12),
                new TierLoot(10, ItemType.Armor, 0.12),
                new TierLoot(4, ItemType.Ring, 0.13),
                new TierLoot(5, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.05),
                new EggLoot(EggRarity.Uncommon, 0.025)
                )
            )
            ;
    }
}