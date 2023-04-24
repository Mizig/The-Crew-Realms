using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ SpiderDen = () => Behav()
            .Init("Arachna the Spider Queen",
                 new State(
                     new State("idle",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new PlayerWithinTransition(12, "WEB!")
                         ),
                     new State("WEB!",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new TimedTransition(2000, "attack")
                         ),
                     new State("attack",
                         new Wander(1.0),
                         new Shoot(3000, count: 12, projectileIndex: 0, fixedAngle: fixedAngle_RingAttack2),
                         new Shoot(10, 1, 0, defaultAngle: 0, angleOffset: 0, projectileIndex: 0, predictive: 1,
                         coolDown: 1000, coolDownOffset: 0),
                         new Shoot(10, 1, 0, defaultAngle: 0, angleOffset: 0, projectileIndex: 1, predictive: 1,
                         coolDown: 2000, coolDownOffset: 0)
                         )
                         ),
                new Threshold(0.001,
                new ItemLoot("The One True Ring", 0.00001),
                new ItemLoot("Reaper's Bow", 0.004),
                new ItemLoot("Face of Arachna", 0.01),
                new ItemLoot("Predator Necklace", 0.01),
                new ItemLoot("Harlequin Armor", 0.05),
                new ItemLoot("Sword of the Fallen", 0.04),
                new ItemLoot("Doku No Ken", 0.05),
                new ItemLoot("Poison Fang Dagger", 0.10),
                new ItemLoot("Spider's Eye Ring", 0.10),
                new ItemLoot("Path of Loot Key", 0.000125),
                new ItemLoot("Transformation Shard", 0.001),
                new ItemLoot("Gold Cache", 0.05),
                new ItemLoot("Potion of Vitality", 0.4),
                new ItemLoot("Potion of Wisdom", 0.4),
                new ItemLoot("Healing Ichor", 0.50),
                new ItemLoot("Healing Ichor", 0.50),
                new ItemLoot("Healing Ichor", 0.50),
                new TierLoot(5, ItemType.Weapon, 0.15),
                new TierLoot(6, ItemType.Weapon, 0.15),
                new TierLoot(2, ItemType.Ability, 0.17),
                new TierLoot(3, ItemType.Ability, 0.17),
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
        .Init("Arachna Web Spoke 1",
            new State(
                new State(":D",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 120, fixedAngle: 120, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 180, fixedAngle: 180, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 240, fixedAngle: 240, coolDown: 5)
                    )
                )
            )
       .Init("Arachna Web Spoke 2",
            new State(
                new State(":D",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 240, fixedAngle: 240, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 180, fixedAngle: 180, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 300, fixedAngle: 300, coolDown: 5)
                    )
                )
                )
      .Init("Arachna Web Spoke 3",
            new State(
                new State(":D",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 300, fixedAngle: 300, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 240, fixedAngle: 240, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 0, fixedAngle: 0, coolDown: 5)
                    )
                )
                )
       .Init("Arachna Web Spoke 4",
            new State(
                new State(":D",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 0, fixedAngle: 0, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 60, fixedAngle: 60, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 300, fixedAngle: 300, coolDown: 5)
                    )
                )
                )
      .Init("Arachna Web Spoke 5",
            new State(
                new State(":D",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 60, fixedAngle: 60, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 0, fixedAngle: 0, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 120, fixedAngle: 120, coolDown: 5)
                    )
                )
                )
       .Init("Arachna Web Spoke 6",
            new State(
                new State(":D",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 120, fixedAngle: 120, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 60, fixedAngle: 60, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 180, fixedAngle: 180, coolDown: 5)
                    )
                )
                )
        .Init("Arachna Web Spoke 7",
            new State(
                new State(":D",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 180, fixedAngle: 180, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 120, fixedAngle: 120, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 240, fixedAngle: 240, coolDown: 5)
                    )
                )
                )
        .Init("Arachna Web Spoke 8",
            new State(
                new State(":D",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 360, fixedAngle: 360, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 240, fixedAngle: 240, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 300, fixedAngle: 300, coolDown: 5)
                    )
                )
                )
        .Init("Arachna Web Spoke 9",
            new State(
                new State(":D",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 0, fixedAngle: 0, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 60, fixedAngle: 60, coolDown: 5),
                         new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 120, fixedAngle: 120, coolDown: 5)
                    )
                )
             )
        .Init("Black Den Spider",
            new State(
                new State("idle",
                    new Wander(0.8),
                    new Charge(0.9, 20f, 2000),
                    new Shoot(10, 1, 0, defaultAngle: 0, angleOffset: 0, projectileIndex: 0, predictive: 1,
                    coolDown: 500, coolDownOffset: 0)
                         )
                     ),
                    new ItemLoot("Healing Ichor", 0.2)
            )
        .Init("Black Spotted Den Spider",
            new State(
                new State("idle",
                    new Wander(0.8),
                    new Charge(0.9, 40f, 2000),
                    new Shoot(10, 1, 0, defaultAngle: 0, angleOffset: 0, projectileIndex: 0, predictive: 1,
                    coolDown: 500, coolDownOffset: 0)
                         )
                     ),
                    new ItemLoot("Healing Ichor", 0.2)
            )
       .Init("Brown Den Spider",
            new State(
                new State("idle",
                    new Wander(0.8),
                    new Follow(0.8, 0.3, 0),
                    new Shoot(10, 3, 20, angleOffset: 0 / 3, projectileIndex: 0, coolDown: 500)
                    )
                ),
                new ItemLoot("Healing Ichor", 0.2)
           )
       .Init("Green Den Spider Hatchling",
            new State(
                new State("idle",
                    new Wander(0),
                    new Follow(0.8, 0.8, 0),
                    new Shoot(10, 1, 0, defaultAngle: 0, angleOffset: 0, projectileIndex: 0, predictive: 1,
                    coolDown: 1000, coolDownOffset: 0)
                    )
                )
             )
       .Init("Spider Egg Sac",
            new State(
                new TransformOnDeath("Green Den Spider Hatchling", 2, 7),
                new State("idle",
                    new PlayerWithinTransition(0.5, "suicide")
                    ),
                new State("suicide",
                    new Suicide()
                    )
                )
            )
       .Init("Red Spotted Den Spider",
            new State(
                new State("idle",
                    new Wander(0),
                    new Follow(1.0, 0.8, 0),
                    new Shoot(10, 1, 0, defaultAngle: 0, angleOffset: 0, projectileIndex: 0, predictive: 1,
                    coolDown: 500, coolDownOffset: 0)
                    )
                ),
                new ItemLoot("Healing Ichor", 0.2)
            )
       .Init("Arachna Summoner",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                new RealmPortalDrop(),
                new State("idle",
                     new EntitiesNotExistsTransition(300, "Death", "Arachna the Spider Queen")
                    ),
                new State("Death",
                    new Suicide()
                    )
                )
            );
     }
}
