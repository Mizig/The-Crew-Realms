#region

using wServer.logic.behaviors;
using wServer.logic.loot;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ RedDemon = () => Behav()
            .Init("Red Demon",
                new State(
                    new Shoot(10, projectileIndex: 0, count: 5, shootAngle: 5, predictive: 1, coolDown: 1000),
                    new Shoot(11, projectileIndex: 1, count: 1, coolDown: 6000),
                    new Prioritize(
                        new StayCloseToSpawn(0.8, 5),
                        new Follow(1, range: 7),
                        new Wander(0.4)
                        ),
                    new Grenade(range: 12, damage: 100, radius: 5, coolDown: 2000),
                    new TossObject("Imp", 7, coolDown: 3200, randomToss: false),
                    new TossObject("Demon", 7, coolDown: 4400, randomToss: false),
                    new TossObject("Demon Warrior", 7, coolDown: 5600, randomToss: false),
                    new Taunt(0.7, 10000,
                        "I will deliver your soul to Oryx, {PLAYER}!",
                        "Oryx will not end our pain. We can only share it... with you!",
                        "Our anguish is endless, unlike your lives!",
                        "There can be no forgiveness!",
                        "What do you know of suffering? I can teach you much, {PLAYER}",
                        "Would you attempt to destroy us? I know your name, {PLAYER}!",
                        "You cannot hurt us. You cannot help us. You will feed us.",
                        "Your life is an affront to Oryx. You will die."
                        )
                    ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Retro Clarent", 0.0001),
                new ItemLoot("Clarent", 0.004),
                new ItemLoot("Drakenguard", 0.004),
                new ItemLoot("Bloodlord's Cranium", 0.004),
                new ItemLoot("Lycaon's Heart", 0.004),
                new ItemLoot("Hell's Inferno", 0.01),
                new ItemLoot("Head of the Firebreather", 0.01),
                new ItemLoot("Scorching Scepter", 0.01),
                new ItemLoot("Amulet of the Underworld", 0.01),
                new ItemLoot("Waraxe of Judgement", 0.01),
                new ItemLoot("The Crimson Anchor", 0.01),
                new ItemLoot("Mithril Sword", 0.04),
                new ItemLoot("Book of Flames", 0.04),
                new ItemLoot("Skull of Endless Torment", 0.05),
                new ItemLoot("Fire Dragon Battle Armor", 0.05),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.15),
                new ItemLoot("Potion of Attack", 0.9),
                new ItemLoot("Potion of Dexterity", 0.9),
                new ItemLoot("Potion of Vitality", 0.9),
                new TierLoot(7, ItemType.Weapon, 0.10),
                new TierLoot(3, ItemType.Ability, 0.06),
                new TierLoot(8, ItemType.Armor, 0.10),
                new TierLoot(3, ItemType.Ring, 0.06),
                new TierLoot(8, ItemType.Weapon, 0.08),
                new TierLoot(4, ItemType.Ability, 0.08),
                new TierLoot(9, ItemType.Armor, 0.08),
                new TierLoot(4, ItemType.Ring, 0.03),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Imp",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(1.4, 15),
                        new Wander(0.8)
                        ),
                    new Shoot(12, predictive: 0.4, coolDown: 200)
                    ),
                new ItemLoot("Missile Wand", 0.02),
                new ItemLoot("Serpentine Staff", 0.02),
                new ItemLoot("Fire Bow", 0.02)
            )
            .Init("Demon",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(1.4, 15),
                        new Follow(1.4, range: 7),
                        new Wander(0.4)
                        ),
                    new Shoot(10, 2, 7, predictive: 0.5)
                    ),
                new ItemLoot("Fire Bow", 0.03)
            )
            .Init("Demon Warrior",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(1.4, 15),
                        new Follow(1, range: 2.8),
                        new Wander(0.4)
                        ),
                    new Shoot(10, 3, 7, predictive: 0.5)
                    ),
                new ItemLoot("Obsidian Dagger", 0.03),
                new ItemLoot("Steel Shield", 0.02)
            )
            ;
    }
}