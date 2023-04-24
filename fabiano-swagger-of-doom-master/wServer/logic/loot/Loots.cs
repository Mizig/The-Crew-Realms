#region

using System;
using System.Collections.Generic;
using System.Linq;
using wServer.realm;
using wServer.realm.entities;
using wServer.realm.entities.player;

#endregion

namespace wServer.logic.loot
{
    public struct LootDef
    {
        public readonly Item Item;
        public readonly double Probabilty;
        public readonly string LootState;

        public LootDef(Item item, double probabilty, string lootState)
        {
            Item = item;
            Probabilty = probabilty;
            LootState = lootState;
        }
    }

    public class Loot : List<ILootDef>
    {
        private static readonly Random rand = new Random();

        private static string[] notifOMNIVERSALItem = {
            //weapons
            "Radiant Vanity", //wand, crystal prisoner
            "Boshy's Minigun", //bow, boshy
            "Staff of Drannol's Aura", //staff, grand sphinx
            "Retro Clarent", //sword, red demon
            "The Dirk of Chickenslaying", //dagger, chicken
            //abilities
            "The Realmdex", //tome, septavius
            "Cherry Jello", //poison, cube god
            "maiuash's Blessing", //scepter, ugajuajn
            //armors
            "Mari's Vest", //light - marble brick colossus
            "True Shielding of Oryx", //heavy - oryx 1 & 2
            "Robe of Oddish", //robe - light lord
            //rings
            "Admin Crown", //wisdom - shatters third
            "The One True Ring", //general - all bosses
            "Giant Asian Hornet", //damage - killer bee queen
            //admin items
            "The Crusher",
            "Grape Jello"
};

        private static string[] notifCOSMICItem = {
            "Z Saber", //ingame cosmics
            "Ultimate Crown",
            "Ultimate Gemstone",
            "Ultimate Bracer",
            "Purity",
            "Handcannon",
            "Staff of Annihilation",
            "Soulfester",
            "Amulet of Ascension",
            "Lucky Slasher",
            "Raven's Personal Bow",
            "Karen Jacket",
            "Ji Robe",
            "Elicia Blanket",
            "Boshy Gun",
            "Butcher's Plate",
            "Breastplate of the Plague",
            "Top Hat",
            "The Oddishclaw",
            "Crown of the Universe",
            "Blondie's Claws",
            "Eternal Love",
            "Wand of the Galaxy",
            "Snare of the Lurking Titan",
            "Quasar Piercer",
            "Old Farmer's Leather Book",
            "Poseidon's Trident",
            "Whisper of the Seven Seas",
            "Defender's Last Stand",
            "Ceasar's Armor",
            "The Realm Eye",
            "Yukari Sakuragi's Umbrella",
            "Mari's Spirit",
            "Tsar Bomba",
            "Cleopatra's Sheath",
            "Mask of Thunders",
            "Dice of the Royals",
            "Deep Blue Anchor",
            "Orange Juice Robe", //volcano cosmics
            "Cinderflame",
            "True Dragon Imbued Seal",
            "Volcano Fragment",
            "A Following Phoenix",
            "Vengeance Helm", //haunted castle cosmics
            "Mantle of the Departed",
            "Reality Shift",
            "Cape of the Observant"
};

        private static string[] notifANGELICItem = {
            "Skystriker",
            "Trap Above the Clouds",
            "Wear of Angels",
            "Trinket of the Air"
};

        private static string[] notifLIGHTItem = {
            "Plasma Bee Wand",
            "Laser Gun",
            "Lightsaber",
            "Lightshow",
            "Skull of the Light Lord",
            "Hide of Light",
            "Light Core",
            "Light's Orbit",
            "Plasmastone",
            "Plasma Sprout",
            "Star of Light",
            "Beacon of Light",
            "Mark of Loot",
            "Lightspeed Travel Cloak",
            "Spaceship's Anchor"
};

        private static string[] notifARItem = {
            "Atonement",
            "Larry Gun",
            "Clarent",
            "Cursed Wand of the Corrupted",
            "Oblivion",
            "Phantom Cleaver",
            "Poniard of Ghastly Retribution",
            "Cloak of the King",
            "Dreadcull",
            "Dreadcool",
            "Gileon's Spirit",
            "Page of Catatonia",
            "Vinelocker",
            "Harbinger of Fury",
            "Gravachrome",
            "Gravachrome Grass",
            "Greatcloak of Twilight",
            "Helldom Shell",
            "Saturn's Orbit",
            "Sor Reactor",
            "Blades of the Bridge",
            "A Gruesome Concept",
            "The Eye",
            "Sebafra's Soulcatcher",
            "Arcanuo's Zol Lance",
            "Philosopher's Stone",
            "Garugen",
            "Beastly Dice",
            "Protagonite Chassis",
            "Sor Nucleus",
            "Poseidon's Gauntlet",
            "Amulet of Oryx",
            "Flaming Horizons Anchor"
};

        private static string[] notifDEMONICItem = {
            "Flame of Misery",
            "Death's Mantle",
            "Blazing Machete",
            "Bloodlord's Cranium",
            "Nightmare Gem",
            "Essence of Death",
            "Favor of Fortune",
            "Vest of Doomed Souls",
            "Soul Warden",
            "Rigormortis",
            "Tablet of Doom",
            "Harbinger",
            "Unstable Jewel",
            "Oryx's Decapitator",
            "Seal of Oryx",
            "Vanguard of Oryx",
            "Amulet of Pure Madness",
            "Face of Hades",
            "Elytra",
            "Nightmare Gem Gem's Gem",
            "Blade of the Sprites",
            "Pyrus Draconia",
            "Crest of Ruin",
            "Rhongomyniad",
            "Primal Flame",
            "Drakenguard",
            "Reinforced Ribcage",
            "The Eternal Kinstone",
            "Battleaxe of the Ent",
            "Executioner's Guillotine"
};

        private static string[] notifPRIMALItem = {
            "Ring of the Cosmos",
            "Thusala's Slasher",
            "Lucky Potion",
            "Sword of Oryx",
            "Malevolent Armor",
            "Helm of Oryx",
            "Yeti Walkers",
            "Armor of Oryx",
            "Ring of Oryx",
            "Reaper's Bow",
            "Omnipotence Ring",
            "A Yeti's Horn",
            "The Forsaken Ring",
            "Ghost Robe",
            "Scythe of Death",
            "Tome of Fleshly Desires",
            "Seal of the Necropolis",
            "Lycaon's Hide",
            "Necrotic Boneplate",
            "Bonemail of the Fallen",
            "Titan's Breastplate",
            "Orb of Destiny",
            "Ring of Fleshly Desires",
            "Wall of Gore",
            "Flesh Trap",
            "Cloak of Vampirism",
            "Skull of Vampirism",
            "Hela's Essence",
            "Bonesplinter Robe",
            "Wand of Bone",
            "Bel's Decapitator",
            "Claw of the Beast",
            "Necklace of Fangs",
            "Limbsplit Quiver",
            "The Apex Bulwark",
            "The Twilight Grimoire",
            "Morningstar of Honey",
            "Elithor's Soul Bottle",
            "Star of Bones",
            "Scepter of the Ancients",
            "Lycaon's Heart",
            "Boneshatter",
            "Helm of the Necropolis",
            "Paladin's Waraxe",
            "Soul of Havoc",
            "General's Greatsword",
            "Magic-Infused Dice",
            "Slime Staff"
};

        private static string[] notifICAItem = {
            "Cyber Soldier Helm",
            "Blessed Ring of the Tomb",
            "Frozen Time",
            "Cosmic Cortex",
            "Snowstorm Armor",
            "Shadowsteel Plate",
            "Robe of the Draconic Overlord",
            "Ectoplasm Blade",
            "Demon Lord's Wrath",
            "Kid's Cape",
            "Elemental Obliterator",
            "Unholy Wand",
            "Wavebreaker",
            "Snakebound Slasher",
            "Sanic Head",
            "Mega Blaster",
            "Firestorm",
            "The Flamarang"
};

        private static string[] notifLGItem = {
            "Axolotl Friend",
            "Loremaker's Staff",
            "Hell's Inferno",
            "Crown of the Ice",
            "Shattered Caliburn",
            "Legendary Stone Sword",
            "Gargoyle Crusher",
            "Overgrown Skull",
            "Oathsworn's Garments",
            "Oathsworn's Staff",
            "Oath of Cinder",
            "The Gilded Blade",
            "Spiritclaw",
            "Medusa's Trap",
            "Waraxe of Judgement",
            "Hunter's Chestplate",
            "Hunter's Robe",
            "Hunter's Garbs",
            "Hunter's Suit",
            "Hunter's Hide",
            "Hunter's Ring",
            "Hunter's Amulet",
            "Hunter's Armor",
            "Hunter's Staff",
            "Hunter's Katana",
            "Hunter's Blade",
            "Hunter's Rod",
            "Hunter's Crossbow",
            "Hunter's Bow",
            "Hunter's Wand",
            "Hunter's Cane",
            "Hunter's Dagger",
            "Hunter's Throwing Knife",
            "Hunter's Spear",
            "Hunter's Sword",
            "Helm of Duality",
            "Knight's Warhammer",
            "Enforcer Armor-2000",
            "Bow of the Ugajuajn",
            "Rip of Soul",
            "Trap of Dark Magic",
            "Colossal Skull",
            "Gem Sword",
            "Oracle's Nightmare",
            "Jon's Handcannon",
            "Legendary Forgotten Crown",
            "Treasure of the Universe",
            "Blade of the Underworld",
            "Sun and Moon Expansion",
            "Soul Buster",
            "The King's Tablet",
            "Aben's Stoneplate",
            "Magician's Hide",
            "Garments of Goblin Monarch",
            "Elimination",
            "Elemental Pendant",
            "Petrified Dragonroot",
            "Pretty Flower Amulet",
            "Pretty Flower Wand",
            "Sor Giant Slayer",
            "Sky Piercer Wand",
            "Dranbiel Garbs",
            "Devil Dice",
            "Righteous Dice",
            "Twisted Earth Dice",
            "Duck Floatie",
            "Teh Duck Quiver",
            "Duckie Staff",
            "Greeni",
            "Staff of Holy Terror",
            "Zol Elixir",
            "Ring of the New Sun",
            "The Great Lightsword",
            "Butterfly Dagger",
            "Covering of Winter Goddess",
            "Covering of Mermaid Goddess",
            "Santa's Battlesuit",
            "Santa Hat",
            "Santa's Mitten",
            "Garbs of the Sun God",
            "Santa's Battle Attire",
            "Cloak of Terradius",
            "Holiday Ring",
            "Dagger of Tindailius",
            "King's Crossbow",
            "Kurisumasu no Uwagi",
            "Heart of Boshy",
            "North Pole's Orb",
            "Queen's Crown",
            "An Astonishing Happening",
            "Skull of Ravagers",
            "Bow of Warped Coral",
            "Forgotten Robe",
            "Words of Wisdom",
            "Robe of Treasure",
            "Face of Arachna",
            "King's Visard",
            "Mask of the Mad God",
            "Ring of the Unstable Mind",
            "Drannol's Judgement",
            "Crown of War",
            "Garbs of the Frozen Queen",
            "Shadow Suit",
            "Ring of Immortality",
            "Katana of the Sun",
            "The Odyssey",
            "Kokorowatari",
            "Crystal Trap",
            "Core of Corruption",
            "Venom Cage",
            "Contagion Bracelet",
            "Songstress Attire",
            "Musician's Hat",
            "Mad King's Crook",
            "Aegis of the Citadel",
            "Glazed Edge",
            "Robe of Split Worlds",
            "Faithless Execution",
            "Scorching Scepter",
            "Pernicious Fate-36",
            "V-L Spark Armor",
            "Ruby Plated Armor",
            "Hide of the Feral",
            "Amulet of the Underworld",
            "Ancient Pendant",
            "Attire of Chaos",
            "Gemstone of Divinity",
            "Amulet of the Ancients",
            "The Crimson Anchor",
            "Anchor of the Chosen",
            "Winds of Change",
            "Starcrash Ring",
            "Ancient Longbow",
            "Necklace of Fallen Grace",
            "Blade of the Titan",
            "Buckler of the Ancients",
            "Forest Parry Technique",
            "Hellfire Orb",
            "Death's Gem",
            "Chocolate Cookie",
            "North Pole's Slasher",
            "Wand of Ornaments",
            "Christmas Garments",
            "Robe of Bloodbath",
            "Samurai's Belt",
            "Sensei's Hat",
            "Path of Loot Key",
            "Star of the North Pole",
            "Robe of Majesty",
            "Abaddon's Bracelet",
            "Petrified Lophop",
            "Demon Summoning Tome",
            "The Nuruaj",
            "Star Ring",
            "Red Bagston",
            "Grey Belt",
            "Rabbit's Foot",
            "Sword of the Colossus",
            "Staff of Nature",
            "Head of the Firebreather",
            "Odin's Attire",
            "Hela's Horns",
            "Robe of Celebration",
            "Hela's Robe",
            "Mysterious Totem",
            "Magical Incantation",
            "Shattered War Axe",
            "Bow of the Void",
            "Staff of Demonic Power",
            "Quiver of the Shadows",
            "Armor of Nil",
            "Sourcestone",
            "Staff of Unholy Sacrifice",
            "Skull of Corrupted Souls",
            "Ritual Robe",
            "Gemstone Attire",
            "Bloodshed Ring",
            "Bloodstone of Enmity",
            "Marble Seal",
            "Purification Crystal",
            "Forgotten Zol Gem",
            "Speedier Sprout",
            "Breastplate of New Life",
            "Magical Lodestone",
            "The Rainstorm",
            "Peppermint Candy Bow",
            "The Tormented Spirit",
            "Crown of the Elements",
            "Festive Quiver",
            "Elf Suit",
            "Merrystone",
            "Burning Sun Scepter",
            "Radiant Wand of Royalism",
            "Odin's Ravens",
            "Enchanted Uru Sword",
            "Gungnir",
            "Bee Wand",
            "Vulcanstriker",
            "Octopussy",
            "Gargoyle Stoneplate",
            "Force Between Avex",
            "Harlequin's Crossbow",
            "Wand of the Ascended Creation",
            "Burning Tome",
            "Cytoplasmic Induced Leather",
            "Opus Salutem",
            "Kiskiorab",
            "Staff of Royal Revenge",
            "Insurgency Amulet",
            "Helm of Erebus",
            "Malignant Slasher",
            "Master of the House",
            "Dirk of Notorious Agents",
            "Drannol's Spirit",
            "Scorching Refraction",
            "Thunderfall's Storm",
            "Katana of Mythical Alliance",
            "Jackpot",
            "Bracelet of the Demolished",
            "March of the Army",
            "Robes of Aldragine",
            "Mercy of Yazanahar",
            "Deception",
            "Flames of Purity",
            "Predator Necklace",
            "Necklace of Undead Support",
            "Ring of Solar Focus",
            "Sincryer's Demise",
            "Seal of Glowing Honor",
            "The Darkin Skull",
            "Wheel of Flames",
            "Throwing Spear",
            "The Soul Ring",
            "The Gravedigger's Shovel",
            "The Gravedigger's Disguise",
            "The Soul Collector",
            "The Executioner",
            "Platinum Argarius",
            "Dagger of the Endless Void",
            "The Infernus",
            "The Forgotten Conduit",
            "Undead's Gross Bow",
            "Carrier's Suit",
            "Soulkeeper",
            "Shiny Diver's Breastplate",
            "Gauntlet of Mortality",
            "Santa's Coat",
            "Bubble Discharger Staff",
            "Hellstone",
            "Zol Wraps",
            "Heart of the Mountains",
            "Cremation"
};

        public Loot(params ILootDef[] lootDefs) //For independent loots(e.g. chests)
        {
            AddRange(lootDefs);
        }

        public IEnumerable<Item> GetLoots(RealmManager manager, int min, int max) //For independent loots(e.g. chests)
        {
            List<LootDef> consideration = new List<LootDef>();
            foreach (ILootDef i in this)
                i.Populate(manager, null, null, rand, "", consideration);

            int retCount = rand.Next(min, max);
            foreach (LootDef i in consideration)
            {
                if (rand.NextDouble() < i.Probabilty)
                {
                    yield return i.Item;
                    retCount--;
                }
                if (retCount == 0)
                    yield break;
            }
        }

        public void Handle(Enemy enemy, RealmTime time)
        {
            if (enemy.Owner.Name == "ArenaNotNot") return;
            List<LootDef> consideration = new List<LootDef>();

            List<Item> sharedLoots = new List<Item>();
            foreach (ILootDef i in this)
                i.Populate(enemy.Manager, enemy, null, rand, i.Lootstate, consideration);
            foreach (LootDef i in consideration)
            {
                if (i.LootState == enemy.LootState || i.LootState == null)
                {
                    if (rand.NextDouble() < i.Probabilty)
                        sharedLoots.Add(i.Item);
                }
            }

            Tuple<Player, int>[] dats = enemy.DamageCounter.GetPlayerData();
            Dictionary<Player, IList<Item>> loots = enemy.DamageCounter.GetPlayerData().ToDictionary(
                d => d.Item1, d => (IList<Item>)new List<Item>());

            foreach (Item loot in sharedLoots.Where(item => item.Soulbound))
                loots[dats[rand.Next(dats.Length)].Item1].Add(loot);

            foreach (Tuple<Player, int> dat in dats)
            {
                consideration.Clear();
                foreach (ILootDef i in this)
                    i.Populate(enemy.Manager, enemy, dat, rand, i.Lootstate, consideration);

                IList<Item> playerLoot = loots[dat.Item1];
                foreach (LootDef i in consideration)
                {
                    if (i.LootState == enemy.LootState || i.LootState == null)
                    {
                        double prob = dat.Item1.LootDropBoost ? i.Probabilty * 1.25 : i.Probabilty; //mark of loot boost 1.25
                        if (rand.NextDouble() < prob)
                        {
                            if (dat.Item1.LootTierBoost)
                                playerLoot.Add(IncreaseTier(enemy.Manager, i.Item, consideration));
                            else
                                playerLoot.Add(i.Item);
                        }
                    }
                }
            }

            AddBagsToWorld(enemy, sharedLoots, loots);
        }

        private Item IncreaseTier(RealmManager manager, Item item, List<LootDef> consideration)
        {
            if (item.SlotType == 10) return item;
            Item[] tier = manager.GameData.Items
                 .Where(i => item.SlotType == i.Value.SlotType)
                 .Where(i => i.Value.Tier >= item.Tier + 3)
                 .Where(i => consideration.Select(_ => _.Item).Contains(i.Value))
                 .Select(i => i.Value).ToArray();

            return tier.Length > 0 ? tier[rand.Next(1, tier.Length)] : item;
        }

        private void AddBagsToWorld(Enemy enemy, IList<Item> shared, IDictionary<Player, IList<Item>> soulbound)
        {
            List<Player> pub = new List<Player>(); //only people not getting soulbound
            foreach (KeyValuePair<Player, IList<Item>> i in soulbound)
            {
                if (i.Value.Count > 0)
                    ShowBags(enemy, i.Value, i.Key);
                else
                    pub.Add(i.Key);
            }
            if (pub.Count > 0 && shared.Count > 0)
                ShowBags(enemy, shared, null);
        }

        private void ShowBags(Enemy enemy, IEnumerable<Item> loots, params Player[] owners)
        {
            string[] ownerIds = owners?.Select(x => x.AccountId).ToArray();
            int bagType = 0;
            Item[] items = new Item[8];
            int idx = 0;

            foreach (Item i in loots)
            {
                if (notifOMNIVERSALItem.Contains(i.ObjectId))
                    foreach (var p in enemy.Owner.Players.Values)
                        p.SendNotif(owners[0].Name + " obtained the OMNIVERSAL item '" + i.ObjectId + "'.");

                if (notifCOSMICItem.Contains(i.ObjectId))
                    foreach (var p in enemy.Owner.Players.Values)
                        p.SendNotif(owners[0].Name + " got the COSMIC item '" + i.ObjectId + "'!");

                if (notifANGELICItem.Contains(i.ObjectId))
                    foreach (var p in enemy.Owner.Players.Values)
                        p.SendNotif(owners[0].Name + " got the Angelic item '" + i.ObjectId + "'!");

                if (notifLIGHTItem.Contains(i.ObjectId))
                    foreach (var p in enemy.Owner.Players.Values)
                        p.SendNotif(owners[0].Name + " got the Light item '" + i.ObjectId + "'!");

                if (notifARItem.Contains(i.ObjectId))
                    foreach (var p in enemy.Owner.Players.Values)
                        p.SendNotif(owners[0].Name + " got the Ancient Relic item '" + i.ObjectId + "'!");

                if (notifPRIMALItem.Contains(i.ObjectId))
                    foreach (var p in enemy.Owner.Players.Values)
                        p.SendNotif(owners[0].Name + " got the Primal item '" + i.ObjectId + "'!");

                if (notifDEMONICItem.Contains(i.ObjectId))
                    foreach (var p in enemy.Owner.Players.Values)
                        p.SendNotif(owners[0].Name + " got the Demonic item '" + i.ObjectId + "'!");

                if (notifICAItem.Contains(i.ObjectId))
                    foreach (var p in enemy.Owner.Players.Values)
                        p.SendNotif(owners[0].Name + " got the Super Rare item '" + i.ObjectId + "'!");

                if (notifLGItem.Contains(i.ObjectId))
                    foreach (var p in enemy.Owner.Players.Values)
                        p.SendNotif(owners[0].Name + " got the Legendary item '" + i.ObjectId + "'!");

                if (i.BagType > bagType) bagType = i.BagType;
                items[idx] = i;
                idx++;

                if (idx == 8)
                {
                    ShowBag(enemy, ownerIds, bagType, items);

                    bagType = 0;
                    items = new Item[8];
                    idx = 0;
                }
            }

            if (idx > 0)
                ShowBag(enemy, ownerIds, bagType, items);
        }

        private static void ShowBag(Enemy enemy, string[] owners, int bagType, Item[] items)
        {
            ushort bag = 0x500;
            switch (bagType)
            {
                case 0:
                    bag = 0x500;
                    break;
                case 1:
                    bag = 0x506;
                    break;
                case 2:
                    bag = 0x503;
                    break;
                case 3:
                    bag = 0x508;
                    break;
                case 4:
                    bag = 0x509;
                    break;
                case 5:
                    bag = 0x050B;
                    break;
                case 6: //st bag
                    bag = 0x2000;
                    break;
                case 7: //white bag
                    bag = 0x050C;
                    break;
                case 8:
                    bag = 0xfff;
                    break;
                case 9: //valor lg bag
                    bag = 0x3018;
                    break;
                case 10: //dom lg bag
                    bag = 0x316d;
                    break;
                case 11: //ica super bag
                    bag = 0x324d;
                    break;
                case 12: //rotf boosted bag
                    bag = 0x3065;
                    break;
                case 13: //dom demonic bag
                    bag = 0x3184;
                    break;
                case 14: //ancient relic bag
                    bag = 0x3032;
                    break;
                case 17: //light tier bag
                    bag = 0x3055;
                    break;
                case 18: //angelic tier bag
                    bag = 0x339d;
                    break;
                case 20: //cosmic tier bag
                    bag = 0x315e;
                    break;
                case 21: //omniversal bag
                    bag = 0x3299;
                    break;
            }

            Container container = new Container(enemy.Manager, bag, 1000 * 120, true);
            for (int j = 0; j < 8; j++)
                container.Inventory[j] = items[j];
            container.BagOwners = owners;
            container.Move(
                enemy.X + (float)((rand.NextDouble() * 2 - 1) * 0.5),
                enemy.Y + (float)((rand.NextDouble() * 2 - 1) * 0.5));
            container.Size = 80;
            if (bagType == 9) container.Size = 100;
            if (bagType == 10) container.Size = 100;
            if (bagType == 11) container.Size = 115;
            if (bagType == 12) container.Size = 100;
            if (bagType == 13) container.Size = 100;
            if (bagType == 14) container.Size = 100;
            if (bagType == 17) container.Size = 115;
            if (bagType == 18) container.Size = 115;
            if (bagType == 20) container.Size = 130;
            if (bagType == 21) container.Size = 140;
            enemy.Owner.EnterWorld(container);
        }
    }
}