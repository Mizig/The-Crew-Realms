#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using db;
using db.JsonObjects;
using wServer.networking.cliPackets;
using wServer.networking.svrPackets;
using wServer.realm.entities;
using wServer.realm.entities.player;

#endregion

namespace wServer.realm.commands
{
    internal class ShowGiftCode : Command
    {
        public ShowGiftCode()
            : base("giftcode")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            var giftCode = player.Client.Account.NextGiftCode();
            if (giftCode == null)
            {
                player.SendError("No new giftcode found.");
                return false;
            }

            var data = AccountDataHelper.GenerateAccountGiftCodeData(player.AccountId, giftCode).Write();
            var qrGenerator = new QrCodeGenerator();
            var qrCode = qrGenerator.CreateQrCode($"{Program.Settings.GetValue<string>("serverDomain")}/account/redeemGiftCode?data={data}", QrCodeGenerator.EccLevel.H);
            var bmp = qrCode.GetGraphic(5);
            var rgbValues = bmp.GetPixels();

            player.Client.SendPacket(new PicPacket
            {
                BitmapData = new BitmapData
                {
                    Bytes = rgbValues,
                    Height = bmp.Height,
                    Width = bmp.Width
                }
            });
            return true;
        }
    }

    internal class TutorialCommand : Command
    {
        public TutorialCommand()
            : base("tutorial")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            player.Client.Reconnect(new ReconnectPacket
            {
                Host = "",
                Port = Program.Settings.GetValue<int>("port"),
                GameId = World.TUT_ID,
                Name = "Tutorial",
                Key = Empty<byte>.Array,
            });
            return true;
        }
    }

    internal class RealmCommand : Command
    {
        public RealmCommand()
            : base("realm")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            World world = player.Client.Manager.Monitor.GetRandomRealm();

            player.Client.Reconnect(new ReconnectPacket
            {
                Host = "",
                Port = Program.Settings.GetValue<int>("port"),
                GameId = world.Id,
                Name = world.Name,
                Key = world.PortalKey,
            });
            return true;
        }
    }

    internal class GHallCommand : Command
    {
        public GHallCommand()
            : base("ghall")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            try
            {
                World world = player.Guild.GuildHall;
                player.Client.Reconnect(new ReconnectPacket
                {
                    Host = "",
                    Port = Program.Settings.GetValue<int>("port"),
                    GameId = world.Id,
                    Name = world.Name,
                    Key = world.PortalKey,
                });
                return true;
            }
            catch
            {
                player.SendError("You are not a member of a guild!");
                return false;
            }
        }
    }

    internal class OnlineCommand : Command //get all players from all worlds (this may become too large!)
    {
        public OnlineCommand()
            : base("online")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            StringBuilder sb = new StringBuilder("Online players: ");

            foreach (KeyValuePair<int, World> w in player.Manager.Worlds)
            {
                World world = w.Value;
                if (w.Key != 0)
                {
                    Player[] copy = world.Players.Values.ToArray();
                    if (copy.Length != 0)
                    {
                        for (int i = 0; i < copy.Length; i++)
                        {
                            sb.Append(copy[i].Name);
                            sb.Append(", ");
                        }
                    }
                }
            }
            string fixedString = sb.ToString().TrimEnd(',', ' '); //clean up trailing ", "s

            player.SendInfo(fixedString);
            return true;
        }
    }

    internal class VaultCommand : Command
    {
        public VaultCommand()
            : base("vault")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            player.Client.Reconnect(new ReconnectPacket
            {
                Host = "",
                Port = Program.Settings.GetValue<int>("port"),
                GameId = player.Manager.PlayerVault(player.Client).Id,
                Name = player.Manager.PlayerVault(player.Client).Name,
                Key = player.Manager.PlayerVault(player.Client).PortalKey,
            });
            return true;
        }
    }

    internal class LeftToMax : Command
    {
        public LeftToMax() : base("lefttomax") { }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            int Hp = player.ObjectDesc.MaxHitPoints - player.Stats[0];
            int Mp = player.ObjectDesc.MaxMagicPoints - player.Stats[1];
            int Atk = player.ObjectDesc.MaxAttack - player.Stats[2];
            int Def = player.ObjectDesc.MaxDefense - player.Stats[3];
            int Spd = player.ObjectDesc.MaxSpeed - player.Stats[4];
            int Vit = player.ObjectDesc.MaxHpRegen - player.Stats[5];
            int Wis = player.ObjectDesc.MaxMpRegen - player.Stats[6];
            int Dex = player.ObjectDesc.MaxDexterity - player.Stats[7];
            player.SendInfo(Hp + "HP from max");
            player.SendInfo(Mp + "MP from max");
            player.SendInfo(Atk + "Attack from max");
            player.SendInfo(Def + "Defense from max");
            player.SendInfo(Spd + "Speed from max");
            player.SendInfo(Dex + "Dexterity from max");
            player.SendInfo(Vit + "Vitality from max");
            player.SendInfo(Wis + "Wisdom from max");
            return true;
        }
    }

    internal class NexusCommand : Command
    {
        public NexusCommand()
            : base("nexus")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            player.Client.Reconnect(new ReconnectPacket
            {
                Host = "",
                Port = Program.Settings.GetValue<int>("port"),
                GameId = World.NEXUS_ID,
                Name = "Nexus",
                Key = Empty<byte>.Array,
            });
            return true;
        }


        internal class TradeCommand : Command
        {
            public TradeCommand()
                : base("trade")
            {
            }

            protected override bool Process(Player player, RealmTime time, string[] args)
            {
                if (String.IsNullOrWhiteSpace(args[0]))
                {
                    player.SendInfo("Usage: /trade <player name>");
                    return false;
                }
                player.RequestTrade(time, new RequestTradePacket
                {
                    Name = args[0]
                });
                return true;
            }
        }


        internal class WhoCommand : Command
        {
            public WhoCommand()
                : base("who")
            {
            }

            protected override bool Process(Player player, RealmTime time, string[] args)
            {
                StringBuilder sb = new StringBuilder("Players online: ");
                Player[] copy = player.Owner.Players.Values.ToArray();
                for (int i = 0; i < copy.Length; i++)
                {
                    if (i != 0) sb.Append(", ");
                    sb.Append(copy[i].Name);
                }

                player.SendInfo(sb.ToString());
                return true;
            }
        }

        internal class ServerCommand : Command
        {
            public ServerCommand()
                : base("server")
            {
            }

            protected override bool Process(Player player, RealmTime time, string[] args)
            {
                player.SendInfo(player.Owner.Name);
                return true;
            }
        }

        internal class PauseCommand : Command
        {
            public PauseCommand()
                : base("pause")
            {
            }

            protected override bool Process(Player player, RealmTime time, string[] args)
            {
                if (player.HasConditionEffect(ConditionEffectIndex.Paused))
                {
                    player.ApplyConditionEffect(new ConditionEffect
                    {
                        Effect = ConditionEffectIndex.Paused,
                        DurationMS = 0
                    });
                    player.SendInfo("Game resumed.");
                }
                else
                {
                    foreach (Enemy i in player.Owner.EnemiesCollision.HitTest(player.X, player.Y, 8).OfType<Enemy>())
                    {
                        if (i.ObjectDesc.Enemy)
                        {
                            player.SendInfo("Not safe to pause.");
                            return false;
                        }
                    }
                    player.ApplyConditionEffect(new ConditionEffect
                    {
                        Effect = ConditionEffectIndex.Paused,
                        DurationMS = -1
                    });
                    player.SendInfo("Game paused.");
                }
                return true;
            }
        }

        internal class TeleporttCommand : Command
        {
            public TeleporttCommand()
                : base("tp")
            {
            }

            protected override bool Process(Player player, RealmTime time, string[] args)
            {
                try
                {
                    if (String.Equals(player.Name.ToLower(), args[0].ToLower()))
                    {
                        player.SendInfo("You are already at yourself, and always will be!");
                        return false;
                    }

                    foreach (KeyValuePair<int, Player> i in player.Owner.Players)
                    {
                        if (i.Value.Name.ToLower() == args[0].ToLower().Trim())
                        {
                            player.Teleport(time, new TeleportPacket
                            {
                                ObjectId = i.Value.Id
                            });
                            return true;
                        }
                    }
                    player.SendInfo(string.Format("Cannot teleport, {0} not found!", args[0].Trim()));
                }
                catch
                {
                    player.SendHelp("Usage: /tp <player name>");
                }
                return false;
            }
        }

        internal class TeleportCommand : Command
        {
            public TeleportCommand()
                : base("teleport")
            {
            }

            protected override bool Process(Player player, RealmTime time, string[] args)
            {
                try
                {
                    if (String.Equals(player.Name.ToLower(), args[0].ToLower()))
                    {
                        player.SendInfo("You are already at yourself, and always will be!");
                        return false;
                    }

                    foreach (KeyValuePair<int, Player> i in player.Owner.Players)
                    {
                        if (i.Value.Name.ToLower() == args[0].ToLower().Trim())
                        {
                            player.Teleport(time, new TeleportPacket
                            {
                                ObjectId = i.Value.Id
                            });
                            return true;
                        }
                    }
                    player.SendInfo(string.Format("Cannot teleport, {0} not found!", args[0].Trim()));
                }
                catch
                {
                    player.SendHelp("Usage: /teleport <player name>");
                }
                return false;
            }
        }

        class TellCommand : Command
        {
            public TellCommand() : base("tell") { }

            protected override bool Process(Player player, RealmTime time, string[] args)
            {
                if (!player.NameChosen)
                {
                    player.SendError("Choose a name!");
                    return false;
                }
                if (args.Length < 2)
                {
                    player.SendError("Usage: /tell <player name> <text>");
                    return false;
                }

                string playername = args[0].Trim();
                string msg = string.Join(" ", args, 1, args.Length - 1);

                if (String.Equals(player.Name.ToLower(), playername.ToLower()))
                {
                    player.SendInfo("Quit telling yourself!");
                    return false;
                }

                if (playername.ToLower() == "muledump")
                {
                    if (msg.ToLower() == "private muledump")
                    {
                        player.Client.SendPacket(new TextPacket() //echo to self
                        {
                            ObjectId = player.Id,
                            BubbleTime = 10,
                            Stars = player.Stars,
                            Name = player.Name,
                            Recipient = "Muledump",
                            Text = msg.ToSafeText(),
                            CleanText = ""
                        });

                        player.Manager.Database.DoActionAsync(db =>
                        {
                            var cmd = db.CreateQuery();
                            cmd.CommandText = "UPDATE accounts SET publicMuledump=0 WHERE id=@accId;";
                            cmd.Parameters.AddWithValue("@accId", player.AccountId);
                            cmd.ExecuteNonQuery();
                            player.Client.SendPacket(new TextPacket()
                            {
                                ObjectId = -1,
                                BubbleTime = 10,
                                Stars = 70,
                                Name = "Muledump",
                                Recipient = player.Name,
                                Text = "Your muledump is now hidden, only you can view it now.",
                                CleanText = ""
                            });
                        });
                    }
                    else if (msg.ToLower() == "public muledump")
                    {
                        player.Client.SendPacket(new TextPacket() //echo to self
                        {
                            ObjectId = player.Id,
                            BubbleTime = 10,
                            Stars = player.Stars,
                            Name = player.Name,
                            Recipient = "Muledump",
                            Text = msg.ToSafeText(),
                            CleanText = ""
                        });
                        player.Manager.Database.DoActionAsync(db =>
                        {
                            var cmd = db.CreateQuery();
                            cmd.CommandText = "UPDATE accounts SET publicMuledump=1 WHERE id=@accId;";
                            cmd.Parameters.AddWithValue("@accId", player.AccountId);
                            cmd.ExecuteNonQuery();

                            player.Client.SendPacket(new TextPacket()
                            {
                                ObjectId = -1,
                                BubbleTime = 10,
                                Stars = 70,
                                Name = "Muledump",
                                Recipient = player.Name,
                                Text = "Your muledump is now public, anyone can view it now.",
                                CleanText = ""
                            });
                        });
                    }
                    else
                    {
                        player.Client.SendPacket(new TextPacket() //echo to self
                        {
                            ObjectId = player.Id,
                            BubbleTime = 10,
                            Stars = player.Stars,
                            Name = player.Name,
                            Recipient = "Muledump",
                            Text = msg.ToSafeText(),
                            CleanText = ""
                        });

                        player.Client.SendPacket(new TextPacket()
                        {
                            ObjectId = -1,
                            BubbleTime = 10,
                            Stars = 70,
                            Name = "Muledump",
                            Recipient = player.Name,
                            Text = "U WOT M8, 1v1 IN THE GARAGE!!!!111111oneoneoneeleven",
                            CleanText = ""
                        });
                    }
                    return true;
                }

                foreach (var i in player.Manager.Clients.Values)
                {
                    if (i.Account.NameChosen && i.Account.Name.EqualsIgnoreCase(playername))
                    {
                        player.Client.SendPacket(new TextPacket() //echo to self
                        {
                            ObjectId = player.Id,
                            BubbleTime = 10,
                            Stars = player.Stars,
                            Name = player.Name,
                            Recipient = i.Account.Name,
                            Text = msg.ToSafeText(),
                            CleanText = ""
                        });

                        i.SendPacket(new TextPacket() //echo to /tell player
                        {
                            ObjectId = i.Player.Owner.Id == player.Owner.Id ? player.Id : -1,
                            BubbleTime = 10,
                            Stars = player.Stars,
                            Name = player.Name,
                            Recipient = i.Account.Name,
                            Text = msg.ToSafeText(),
                            CleanText = ""
                        });
                        return true;
                    }
                }
                player.SendError(string.Format("{0} not found.", playername));
                return false;
            }
        }
    }
}