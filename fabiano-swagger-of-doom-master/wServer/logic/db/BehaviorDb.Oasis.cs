#region

using wServer.logic.behaviors;
using wServer.logic.loot;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Oasis = () => Behav()
            .Init("Oasis Giant",
                new State(
                    new DropPortalOnDeath("Candyland Portal", 60),
                    new Shoot(10, 4, 7, predictive: 1),
                    new Prioritize(
                        new StayCloseToSpawn(0.3, 2),
                        new Wander(0.4)
                        ),
                    new SpawnGroup("Oasis", 20, coolDown: 5000),
                    new Taunt(0.7, 10000,
                        "Come closer, {PLAYER}! Yes, closer!",
                        "I rule this place, {PLAYER}!",
                        "Surrender to my aquatic army, {PLAYER}!",
                        "You must be thirsty, {PLAYER}. Enter my waters!",
                        "Minions! We shall have {PLAYER} for dinner!"
                        )
                    ),
                new Threshold(0.001,
                new ItemLoot("Yeti Walkers", 0.004),
                new ItemLoot("Thunderfall's Storm", 0.01),
                new ItemLoot("Penetrating Blast Spell", 0.04),
                new ItemLoot("Sandstone Seal", 0.05),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Potion of Speed", 0.6),
                new ItemLoot("Potion of Defense", 0.3),
                new ItemLoot("Potion of Vitality", 0.3),
                new TierLoot(5, ItemType.Weapon, 0.15),
                new TierLoot(6, ItemType.Weapon, 0.15),
                new TierLoot(1, ItemType.Ability, 0.17),
                new TierLoot(2, ItemType.Ability, 0.17),
                new TierLoot(6, ItemType.Armor, 0.12),
                new TierLoot(7, ItemType.Armor, 0.12),
                new TierLoot(2, ItemType.Ring, 0.13),
                new TierLoot(3, ItemType.Ring, 0.13),
                new EggLoot(EggRarity.Common, 0.1),
                new EggLoot(EggRarity.Uncommon, 0.05),
                new EggLoot(EggRarity.Rare, 0.01),
                new EggLoot(EggRarity.Legendary, 0.001)
                )
            )
            .Init("Oasis Ruler",
                new State(
                    new Prioritize(
                        new Protect(0.5, "Oasis Giant", 15, 10, 3),
                        new Follow(1, range: 9),
                        new Wander(0.5)
                        ),
                    new Shoot(10)
                    ),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Oasis Soldier",
                new State(
                    new Prioritize(
                        new Protect(0.5, "Oasis Giant", 15, 11, 3),
                        new Follow(1, range: 7),
                        new Wander(0.5)
                        ),
                    new Shoot(10, predictive: 0.5)
                    ),
                new ItemLoot("Health Potion", 0.05)
            )
            .Init("Oasis Creature",
                new State(
                    new Prioritize(
                        new Protect(0.5, "Oasis Giant", 15, 12, 3),
                        new Follow(1, range: 5),
                        new Wander(0.5)
                        ),
                    new Shoot(10, coolDown: 400)
                    ),
                new ItemLoot("Health Potion", 0.05)
            )
            .Init("Oasis Monster",
                new State(
                    new Prioritize(
                        new Protect(0.5, "Oasis Giant", 15, 13, 3),
                        new Follow(1, range: 3),
                        new Wander(0.5)
                        ),
                    new Shoot(10, predictive: 0.5)
                    ),
                new ItemLoot("Magic Potion", 0.05)
            )
            ;
    }
}