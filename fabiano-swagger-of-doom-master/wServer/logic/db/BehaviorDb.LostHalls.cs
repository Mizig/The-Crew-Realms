using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ LostHalls = () => Behav()
            .Init("Marble Brick Colossus",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(9, "First")
                    ),
                    new State("First",
                        new Taunt("Look upon my mighty bulwark."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3000, "Shots")
                    ),
                    new State("Shots",
                        new Taunt("Call of voice, for naught. Plea of mercy, for naught. None may enter this chamber and live!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, projectileIndex: 2, count: 10, shootAngle: 36, coolDown: 500, coolDownOffset: 250),
                        new TimedTransition(3000, "Fight1")
                    ),
                    new State("Fight1",
                        new Follow(.15, 20, 1),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 10, coolDown: 1000),
                        new Shoot(25, projectileIndex: 1, count: 9, shootAngle: 25, predictive: 0.4, coolDown: 1600, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 10, shootAngle: 36, coolDown: 500, coolDownOffset: 250),
                        new HpLessTransition(0.52, "Invulnerable")
                    ),
                    new State("Invulnerable",
                        new Taunt("You have seen your last glimpse of sunlight!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(once: false, speed: 1),
                        new Shoot(25, projectileIndex: 2, count: 4, shootAngle: 90, fixedAngle: 0, coolDown: 100, coolDownOffset: 1000),
                        new TimedTransition(3000, "Fight2")
                    ),
                    new State("Fight2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(25, projectileIndex: 0, count: 6, shootAngle: 8, coolDown: 600),
                        new Shoot(25, projectileIndex: 1, count: 5, shootAngle: 20, predictive: 0.4, coolDown: 1400, coolDownOffset: 200),
                        new Shoot(25, projectileIndex: 2, count: 4, shootAngle: 90, fixedAngle: 0, coolDown: 100),
                        new HpLessTransition(0.1, "DeathBoom")
                    ),
                    new State("DeathBoom",
                        new Taunt("I feel myself… slipping… into the void… it is so… dark…"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3000, "BlowUp")
                    ),
                    new State("BlowUp",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, projectileIndex: 0, count: 36, shootAngle: 10, fixedAngle: 0, coolDown: 9999),
                        new Shoot(25, projectileIndex: 1, count: 18, shootAngle: 20, fixedAngle: 6, coolDown: 9999),
                        new Suicide()
                    )
                ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Mari's Spirit", 0.0005),
                new ItemLoot("Omnipotence Ring", 0.004),
                new ItemLoot("Sword of the Colossus", 0.009),
                new ItemLoot("Marble Seal", 0.009),
                new ItemLoot("Breastplate of New Life", 0.009),
                new ItemLoot("Magical Lodestone", 0.009),
                new ItemLoot("Bow of the Void", 0.009),
                new ItemLoot("Quiver of the Shadows", 0.009),
                new ItemLoot("Armor of Nil", 0.009),
                new ItemLoot("Sourcestone", 0.009),
                new ItemLoot("Staff of Unholy Sacrifice", 0.009),
                new ItemLoot("Skull of Corrupted Souls", 0.009),
                new ItemLoot("Ritual Robe", 0.009),
                new ItemLoot("Bloodshed Ring", 0.009),
                new ItemLoot("Path of Loot Key", 0.0005),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.5),
                new ItemLoot("Greater Potion of Life", 1.0),
                new ItemLoot("Greater Potion of Mana", 1.0),
                new ItemLoot("Greater Potion of Attack", 1.0),
                new ItemLoot("Greater Potion of Defense", 1.0),
                new TierLoot(12, ItemType.Weapon, 0.14),
                new TierLoot(6, ItemType.Ability, 0.14),
                new TierLoot(13, ItemType.Armor, 0.14),
                new ItemLoot("Ring of Unbound Health", 0.1)
                )
            )
            ;
    }
}