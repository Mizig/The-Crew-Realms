using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ TreasureCave = () => Behav()
            .Init("Golden Oryx Effigy",
                new State(
                    new State("GetNear",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(8, "Timer")
                    ),
                    new State("Timer",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xffffffff, 1, 5),
                        new TimedTransition(2000, "Phase1")
                    ),
                    new State("Phase1",
                        new Shoot(18, projectileIndex: 0, count: 18, shootAngle: 20, coolDown: 1400, coolDownOffset: 200),
                        new Shoot(14, projectileIndex: 1, count: 5, shootAngle: 12, coolDown: 100)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Paladin's Waraxe", 0.004),
                new ItemLoot("Loremaker's Staff", 0.01),
                new ItemLoot("Mysterious Totem", 0.01),
                new ItemLoot("Magical Incantation", 0.01),
                new ItemLoot("Hero's Garb", 0.01),
                new ItemLoot("Platinum Argarius", 0.01),
                new ItemLoot("Sword of the Fallen", 0.04),
                new ItemLoot("Helm of the Fallen", 0.05),
                new ItemLoot("Ivory Ring", 0.05),
                new ItemLoot("Gold Cache", 0.1),
                new ItemLoot("Potion of Attack", 1.0),
                new ItemLoot("Potion of Defense", 1.0),
                new ItemLoot("Potion of Speed", 1.0),
                new TierLoot(8, ItemType.Weapon, 0.15),
                new TierLoot(9, ItemType.Weapon, 0.15),
                new TierLoot(4, ItemType.Ability, 0.17),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(9, ItemType.Armor, 0.12),
                new TierLoot(10, ItemType.Armor, 0.12),
                new TierLoot(4, ItemType.Ring, 0.13),
                new TierLoot(5, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Treasure Rat",
                new State(
                    new State("Basic",
                        new Wander(speed: 0.4),
                        new StayBack(speed: 0.5, distance: 6),
                        new Shoot(radius: 8, projectileIndex: 0, count: 1, coolDown: 1200)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
                )
            )
            .Init("Treasure Plunderer",
                new State(
                    new State("Basic",
                        new Wander(speed: 0.1),
                        new Follow(speed: 0.25, acquireRange: 9, range: 2),
                        new Grenade(range: 9, damage: 115, radius: 6, coolDown: 1600)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
                )
            )
            .Init("Treasure Robber",
                new State(
                    new State("Basic",
                        new Wander(speed: 0.1),
                        new Follow(speed: 0.25, acquireRange: 9, range: 2),
                        new Shoot(radius: 8, projectileIndex: 0, count: 4, shootAngle: 9, coolDown: 1200)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
                )
            )
            .Init("Treasure Thief",
                new State(
                    new State("Basic",
                        new Wander(speed: 0.2),
                        new StayBack(speed: 0.4, distance: 8),
                        new Grenade(range: 8, damage: 60, radius: 3, coolDown: 200)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Health Potion", 0.15),
                new ItemLoot("Magic Potion", 0.15),
                new TierLoot(7, ItemType.Weapon, 0.07),
                new TierLoot(8, ItemType.Weapon, 0.07),
                new TierLoot(3, ItemType.Ability, 0.1),
                new TierLoot(4, ItemType.Ability, 0.1),
                new TierLoot(8, ItemType.Armor, 0.05),
                new TierLoot(9, ItemType.Armor, 0.05),
                new TierLoot(3, ItemType.Ring, 0.07),
                new TierLoot(4, ItemType.Ring, 0.07)
                )
            )
            .Init("Treasure Enemy",
                new State(
                    new State("Basic",
                        new Wander(speed: 0.05),
                        new Shoot(radius: 8, projectileIndex: 0, count: 1, predictive: 0.3, coolDown: 1600),
                        new Shoot(radius: 8, projectileIndex: 1, count: 2, shootAngle: 10, predictive: 0.3, coolDown: 1600, coolDownOffset: 200)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("Health Potion", 0.15),
                new ItemLoot("Magic Potion", 0.15),
                new TierLoot(7, ItemType.Weapon, 0.07),
                new TierLoot(8, ItemType.Weapon, 0.07),
                new TierLoot(3, ItemType.Ability, 0.1),
                new TierLoot(4, ItemType.Ability, 0.1),
                new TierLoot(8, ItemType.Armor, 0.05),
                new TierLoot(9, ItemType.Armor, 0.05),
                new TierLoot(3, ItemType.Ring, 0.07),
                new TierLoot(4, ItemType.Ring, 0.07)
                )
            )
            .Init("Treasure Pot",
                new State(
                ),
                new Threshold(0.001,
                new ItemLoot("Health Potion", 0.15),
                new ItemLoot("Magic Potion", 0.15),
                new TierLoot(7, ItemType.Weapon, 0.07),
                new TierLoot(8, ItemType.Weapon, 0.07),
                new TierLoot(3, ItemType.Ability, 0.1),
                new TierLoot(4, ItemType.Ability, 0.1),
                new TierLoot(8, ItemType.Armor, 0.05),
                new TierLoot(9, ItemType.Armor, 0.05),
                new TierLoot(3, ItemType.Ring, 0.07),
                new TierLoot(4, ItemType.Ring, 0.07)
                )
            )
            ;
    }
}