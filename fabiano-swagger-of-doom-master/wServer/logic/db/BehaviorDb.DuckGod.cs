using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ DuckGod = () => Behav()
            .Init("Duck God",
                new State(
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(0.1, range: 1),
                        new Wander(0.4)
                        ),
                    new Shoot(10, projectileIndex: 0, count: 6, shootAngle: 50, coolDown: 200),
                    new Shoot(9, projectileIndex: 1, count: 1, coolDown: 600)
                    ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Ring of the New Sun", 0.001),
                new ItemLoot("Duckie Staff", 0.005),
                new ItemLoot("Teh Duck Quiver", 0.005),
                new ItemLoot("Duck Floatie", 0.005),
                new ItemLoot("Anatis Staff", 0.02),
                new ItemLoot("Hunter's Chestplate", 0.0003),
                new ItemLoot("Hunter's Robe", 0.0003),
                new ItemLoot("Hunter's Garbs", 0.0003),
                new ItemLoot("Hunter's Suit", 0.0003),
                new ItemLoot("Hunter's Hide", 0.0003),
                new ItemLoot("Hunter's Armor", 0.0003),
                new ItemLoot("Hunter's Amulet", 0.0003),
                new ItemLoot("Hunter's Ring", 0.0003),
                new ItemLoot("Hunter's Staff", 0.0003),
                new ItemLoot("Hunter's Rod", 0.0003),
                new ItemLoot("Hunter's Crossbow", 0.0003),
                new ItemLoot("Hunter's Bow", 0.0003),
                new ItemLoot("Hunter's Wand", 0.0003),
                new ItemLoot("Hunter's Cane", 0.0003),
                new ItemLoot("Hunter's Dagger", 0.0003),
                new ItemLoot("Hunter's Throwing Knife", 0.0003),
                new ItemLoot("Hunter's Spear", 0.0003),
                new ItemLoot("Hunter's Sword", 0.0003),
                new ItemLoot("Hunter's Katana", 0.0003),
                new ItemLoot("Hunter's Blade", 0.0003),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.05),
                new ItemLoot("Potion of Life", 0.25),
                new ItemLoot("Potion of Mana", 0.25),
                new ItemLoot("Health Potion", 0.10),
                new ItemLoot("Magic Potion", 0.10),
                new TierLoot(9, ItemType.Weapon, 0.12),
                new TierLoot(10, ItemType.Weapon, 0.12),
                new TierLoot(4, ItemType.Ability, 0.14),
                new TierLoot(5, ItemType.Ability, 0.14),
                new TierLoot(10, ItemType.Armor, 0.09),
                new TierLoot(11, ItemType.Armor, 0.09),
                new TierLoot(4, ItemType.Ring, 0.10),
                new TierLoot(5, ItemType.Ring, 0.10),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            ;
    }
}