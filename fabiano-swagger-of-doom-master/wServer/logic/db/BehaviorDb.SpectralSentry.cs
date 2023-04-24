using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ SpectralSentry = () => Behav()
            .Init("Spectral Sentry",
                new State(
                    new DropPortalOnDeath("Lost Halls Portal", 100),
                    new State("Wandering",
                        new Wander(0.45),
                        new Shoot(25, projectileIndex: 0, count: 12, shootAngle: 30, fixedAngle: 0, coolDown: 1200),
                        new Shoot(25, projectileIndex: 1, count: 12, shootAngle: 30, fixedAngle: 11, coolDown: 1400, coolDownOffset: 600),
                        new Shoot(25, projectileIndex: 2, count: 10, shootAngle: 36, fixedAngle: 22, coolDown: 1600, coolDownOffset: 1000)
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Yukari Sakuragi's Umbrella", 0.0005),
                new ItemLoot("Soulfester", 0.0005),
                new ItemLoot("Ghost Robe", 0.004),
                new ItemLoot("Scythe of Death", 0.004),
                new ItemLoot("Gileon's Spirit", 0.004),
                new ItemLoot("Crest of Ruin", 0.0035),
                new ItemLoot("Harlequin's Crossbow", 0.01),
                new ItemLoot("Cloak of Bloody Surprises", 0.05),
                new ItemLoot("Path of Loot Key", 0.00025),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.5),
                new ItemLoot("Greater Potion of Speed", 1.0),
                new ItemLoot("Greater Potion of Dexterity", 1.0),
                new ItemLoot("Greater Potion of Wisdom", 1.0),
                new ItemLoot("Greater Potion of Vitality", 1.0),
                new TierLoot(10, ItemType.Weapon, 0.15),
                new TierLoot(11, ItemType.Weapon, 0.15),
                new TierLoot(12, ItemType.Weapon, 0.15),
                new TierLoot(5, ItemType.Ability, 0.17),
                new TierLoot(6, ItemType.Ability, 0.17),
                new TierLoot(11, ItemType.Armor, 0.12),
                new TierLoot(12, ItemType.Armor, 0.12),
                new TierLoot(13, ItemType.Armor, 0.12),
                new TierLoot(5, ItemType.Ring, 0.17)
                )
            )
            ;
    }
}