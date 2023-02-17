using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.networking.svrPackets;
using wServer.realm;
using wServer.realm.entities;
using wServer.realm.entities.player;

namespace wServer.logic.behaviors.PetBehaviors
{
    internal class PetHealMP : Behavior
    {
        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            state = 1000;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            int cool = (int)state;

            if (cool <= 0)
            {
                if (!(host is Pet)) return;
                Pet pet = host as Pet;
                if (pet.PlayerOwner == null) return;
                Player player = host.GetEntity(pet.PlayerOwner.Id) as Player;
                if (player == null) return;

                if (player != null)
                {
                    int maxMp = player.Stats[1] + player.Boost[1];
                    int h = GetMP(pet, ref cool);
                    if (h == -1) return;
                    int newMp = Math.Min(player.MaxMp, player.Mp + h);
                    if (newMp != player.Mp)
                    {
                        int n = newMp - player.Mp;
                        if (player.HasConditionEffect(ConditionEffectIndex.Quiet))
                        {
                            player.Owner.BroadcastPacket(new ShowEffectPacket
                            {
                                EffectType = EffectType.Trail,
                                TargetId = host.Id,
                                PosA = new Position { X = player.X, Y = player.Y },
                                Color = new ARGB(0xffffffff)
                            }, null);
                            player.Owner.BroadcastPacket(new NotificationPacket
                            {
                                ObjectId = player.Id,
                                Text = "{\"key\":\"blank\",\"tokens\":{\"data\":\"No Effect\"}}",
                                Color = new ARGB(0xFF0000)
                            }, null);
                            cool = 1000;
                            state = cool;
                            return;
                        }
                        player.Mp = newMp;
                        player.UpdateCount++;
                        player.Owner.BroadcastPacket(new ShowEffectPacket
                        {
                            EffectType = EffectType.Trail,
                            TargetId = host.Id,
                            PosA = new Position { X = player.X, Y = player.Y },
                            Color = new ARGB(0xffffffff)
                        }, null);
                        player.Owner.BroadcastPacket(new ShowEffectPacket
                        {
                            EffectType = EffectType.Potion,
                            TargetId = player.Id,
                            Color = new ARGB(0x6084e0)
                        }, null);
                        player.Owner.BroadcastPacket(new NotificationPacket
                        {
                            ObjectId = player.Id,
                            Text = "{\"key\":\"blank\",\"tokens\":{\"data\":\"+" + n + "\"}}",
                            Color = new ARGB(0x6084e0)
                        }, null);
                    }
                }
            }
            else
                cool -= time.thisTickTimes;

            state = cool;
        }

        private int GetMP(Pet host, ref int cooldown)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        if (host.FirstPetLevel.Ability == Ability.MagicHeal)
                        {
                            return CalculateMagicHeal(host.FirstPetLevel.Level, ref cooldown);
                        }
                        break;
                    case 1:
                        if (host.SecondPetLevel.Ability == Ability.MagicHeal)
                        {
                            return CalculateMagicHeal(host.SecondPetLevel.Level, ref cooldown);
                        }
                        break;
                    case 2:
                        if (host.ThirdPetLevel.Ability == Ability.MagicHeal)
                        {
                            return CalculateMagicHeal(host.ThirdPetLevel.Level, ref cooldown);
                        }
                        break;
                    default:
                        break;
                }
            }
            return -1;
        }

        private int CalculateMagicHeal(int level, ref int cooldown)
        {
            if (Enumerable.Range(1, 1).Contains(level))
            {
                cooldown = 9950;
                return 5;
            }
            if (Enumerable.Range(2, 1).Contains(level))
            {
                cooldown = 9900;
                return 6;
            }
            if (Enumerable.Range(3, 1).Contains(level))
            {
                cooldown = 9850;
                return 6;
            }
            if (Enumerable.Range(4, 1).Contains(level))
            {
                cooldown = 9800;
                return 6;
            }
            if (Enumerable.Range(5, 1).Contains(level))
            {
                cooldown = 9750;
                return 7;
            }
            if (Enumerable.Range(6, 1).Contains(level))
            {
                cooldown = 9700;
                return 7;
            }
            if (Enumerable.Range(7, 1).Contains(level))
            {
                cooldown = 9650;
                return 7;
            }
            if (Enumerable.Range(8, 1).Contains(level))
            {
                cooldown = 9600;
                return 7;
            }
            if (Enumerable.Range(9, 1).Contains(level))
            {
                cooldown = 9550;
                return 7;
            }
            if (Enumerable.Range(10, 1).Contains(level))
            {
                cooldown = 9500;
                return 8;
            }
            if (Enumerable.Range(11, 1).Contains(level))
            {
                cooldown = 9450;
                return 8;
            }
            if (Enumerable.Range(12, 1).Contains(level))
            {
                cooldown = 9400;
                return 8;
            }
            if (Enumerable.Range(13, 1).Contains(level))
            {
                cooldown = 9350;
                return 8;
            }
            if (Enumerable.Range(14, 1).Contains(level))
            {
                cooldown = 9300;
                return 8;
            }
            if (Enumerable.Range(15, 1).Contains(level))
            {
                cooldown = 9250;
                return 8;
            }
            if (Enumerable.Range(16, 1).Contains(level))
            {
                cooldown = 9200;
                return 9;
            }
            if (Enumerable.Range(17, 1).Contains(level))
            {
                cooldown = 9150;
                return 9;
            }
            if (Enumerable.Range(18, 1).Contains(level))
            {
                cooldown = 9100;
                return 9;
            }
            if (Enumerable.Range(19, 1).Contains(level))
            {
                cooldown = 9050;
                return 9;
            }
            if (Enumerable.Range(20, 1).Contains(level))
            {
                cooldown = 9000;
                return 9;
            }
            if (Enumerable.Range(21, 1).Contains(level))
            {
                cooldown = 8950;
                return 10;
            }
            if (Enumerable.Range(22, 1).Contains(level))
            {
                cooldown = 8900;
                return 10;
            }
            if (Enumerable.Range(23, 1).Contains(level))
            {
                cooldown = 8850;
                return 10;
            }
            if (Enumerable.Range(24, 1).Contains(level))
            {
                cooldown = 8800;
                return 10;
            }
            if (Enumerable.Range(25, 1).Contains(level))
            {
                cooldown = 8750;
                return 10;
            }
            if (Enumerable.Range(26, 1).Contains(level))
            {
                cooldown = 8700;
                return 11;
            }
            if (Enumerable.Range(27, 1).Contains(level))
            {
                cooldown = 8650;
                return 11;
            }
            if (Enumerable.Range(28, 1).Contains(level))
            {
                cooldown = 8600;
                return 11;
            }
            if (Enumerable.Range(29, 1).Contains(level))
            {
                cooldown = 8550;
                return 11;
            }
            if (Enumerable.Range(30, 1).Contains(level))
            {
                cooldown = 8500;
                return 11;
            }
            if (Enumerable.Range(31, 1).Contains(level))
            {
                cooldown = 8450;
                return 11;
            }
            if (Enumerable.Range(32, 1).Contains(level))
            {
                cooldown = 8400;
                return 12;
            }
            if (Enumerable.Range(33, 1).Contains(level))
            {
                cooldown = 8350;
                return 12;
            }
            if (Enumerable.Range(34, 1).Contains(level))
            {
                cooldown = 8300;
                return 12;
            }
            if (Enumerable.Range(35, 1).Contains(level))
            {
                cooldown = 8250;
                return 12;
            }
            if (Enumerable.Range(36, 1).Contains(level))
            {
                cooldown = 8200;
                return 12;
            }
            if (Enumerable.Range(37, 1).Contains(level))
            {
                cooldown = 8150;
                return 13;
            }
            if (Enumerable.Range(38, 1).Contains(level))
            {
                cooldown = 8100;
                return 13;
            }
            if (Enumerable.Range(39, 1).Contains(level))
            {
                cooldown = 8050;
                return 13;
            }
            if (Enumerable.Range(40, 1).Contains(level))
            {
                cooldown = 8000;
                return 13;
            }
            if (Enumerable.Range(41, 1).Contains(level))
            {
                cooldown = 7950;
                return 13;
            }
            if (Enumerable.Range(42, 1).Contains(level))
            {
                cooldown = 7900;
                return 14;
            }
            if (Enumerable.Range(43, 1).Contains(level))
            {
                cooldown = 7850;
                return 14;
            }
            if (Enumerable.Range(44, 1).Contains(level))
            {
                cooldown = 7800;
                return 14;
            }
            if (Enumerable.Range(45, 1).Contains(level))
            {
                cooldown = 7750;
                return 14;
            }
            if (Enumerable.Range(46, 1).Contains(level))
            {
                cooldown = 7700;
                return 14;
            }
            if (Enumerable.Range(47, 1).Contains(level))
            {
                cooldown = 7650;
                return 15;
            }
            if (Enumerable.Range(48, 1).Contains(level))
            {
                cooldown = 7600;
                return 15;
            }
            if (Enumerable.Range(49, 1).Contains(level))
            {
                cooldown = 7550;
                return 15;
            }
            if (Enumerable.Range(50, 1).Contains(level))
            {
                cooldown = 7500;
                return 15;
            }
            if (Enumerable.Range(51, 1).Contains(level))
            {
                cooldown = 7450;
                return 15;
            }
            if (Enumerable.Range(52, 1).Contains(level))
            {
                cooldown = 7400;
                return 16;
            }
            if (Enumerable.Range(53, 1).Contains(level))
            {
                cooldown = 7350;
                return 16;
            }
            if (Enumerable.Range(54, 1).Contains(level))
            {
                cooldown = 7300;
                return 16;
            }
            if (Enumerable.Range(55, 1).Contains(level))
            {
                cooldown = 7250;
                return 16;
            }
            if (Enumerable.Range(56, 1).Contains(level))
            {
                cooldown = 7200;
                return 16;
            }
            if (Enumerable.Range(57, 1).Contains(level))
            {
                cooldown = 7150;
                return 17;
            }
            if (Enumerable.Range(58, 1).Contains(level))
            {
                cooldown = 7100;
                return 17;
            }
            if (Enumerable.Range(59, 1).Contains(level))
            {
                cooldown = 7050;
                return 17;
            }
            if (Enumerable.Range(60, 1).Contains(level))
            {
                cooldown = 7000;
                return 17;
            }
            if (Enumerable.Range(61, 1).Contains(level))
            {
                cooldown = 6950;
                return 17;
            }
            if (Enumerable.Range(62, 1).Contains(level))
            {
                cooldown = 6900;
                return 18;
            }
            if (Enumerable.Range(63, 1).Contains(level))
            {
                cooldown = 6850;
                return 18;
            }
            if (Enumerable.Range(64, 1).Contains(level))
            {
                cooldown = 6800;
                return 18;
            }
            if (Enumerable.Range(65, 1).Contains(level))
            {
                cooldown = 6750;
                return 18;
            }
            if (Enumerable.Range(66, 1).Contains(level))
            {
                cooldown = 6700;
                return 18;
            }
            if (Enumerable.Range(67, 1).Contains(level))
            {
                cooldown = 6650;
                return 19;
            }
            if (Enumerable.Range(68, 1).Contains(level))
            {
                cooldown = 6600;
                return 19;
            }
            if (Enumerable.Range(69, 1).Contains(level))
            {
                cooldown = 6550;
                return 19;
            }
            if (Enumerable.Range(70, 1).Contains(level))
            {
                cooldown = 6500;
                return 19;
            }
            if (Enumerable.Range(71, 1).Contains(level))
            {
                cooldown = 6450;
                return 19;
            }
            if (Enumerable.Range(72, 1).Contains(level))
            {
                cooldown = 6400;
                return 20;
            }
            if (Enumerable.Range(73, 1).Contains(level))
            {
                cooldown = 6350;
                return 20;
            }
            if (Enumerable.Range(74, 1).Contains(level))
            {
                cooldown = 6300;
                return 20;
            }
            if (Enumerable.Range(75, 1).Contains(level))
            {
                cooldown = 6250;
                return 20;
            }
            if (Enumerable.Range(76, 1).Contains(level))
            {
                cooldown = 6200;
                return 20;
            }
            if (Enumerable.Range(77, 1).Contains(level))
            {
                cooldown = 6150;
                return 21;
            }
            if (Enumerable.Range(78, 1).Contains(level))
            {
                cooldown = 6100;
                return 21;
            }
            if (Enumerable.Range(79, 1).Contains(level))
            {
                cooldown = 6050;
                return 21;
            }
            if (Enumerable.Range(80, 1).Contains(level))
            {
                cooldown = 6000;
                return 21;
            }
            if (Enumerable.Range(81, 1).Contains(level))
            {
                cooldown = 5950;
                return 21;
            }
            if (Enumerable.Range(82, 1).Contains(level))
            {
                cooldown = 5900;
                return 21;
            }
            if (Enumerable.Range(83, 1).Contains(level))
            {
                cooldown = 5850;
                return 21;
            }
            if (Enumerable.Range(84, 1).Contains(level))
            {
                cooldown = 5800;
                return 22;
            }
            if (Enumerable.Range(85, 1).Contains(level))
            {
                cooldown = 5750;
                return 22;
            }
            if (Enumerable.Range(86, 1).Contains(level))
            {
                cooldown = 5700;
                return 22;
            }
            if (Enumerable.Range(87, 1).Contains(level))
            {
                cooldown = 5650;
                return 22;
            }
            if (Enumerable.Range(88, 1).Contains(level))
            {
                cooldown = 5600;
                return 22;
            }
            if (Enumerable.Range(89, 1).Contains(level))
            {
                cooldown = 5550;
                return 23;
            }
            if (Enumerable.Range(90, 1).Contains(level))
            {
                cooldown = 5500;
                return 23;
            }
            if (Enumerable.Range(91, 1).Contains(level))
            {
                cooldown = 5450;
                return 23;
            }
            if (Enumerable.Range(92, 1).Contains(level))
            {
                cooldown = 5400;
                return 23;
            }
            if (Enumerable.Range(93, 1).Contains(level))
            {
                cooldown = 5350;
                return 23;
            }
            if (Enumerable.Range(94, 1).Contains(level))
            {
                cooldown = 5300;
                return 24;
            }
            if (Enumerable.Range(95, 1).Contains(level))
            {
                cooldown = 5250;
                return 24;
            }
            if (Enumerable.Range(96, 1).Contains(level))
            {
                cooldown = 5200;
                return 24;
            }
            if (Enumerable.Range(97, 1).Contains(level))
            {
                cooldown = 5150;
                return 24;
            }
            if (Enumerable.Range(98, 1).Contains(level))
            {
                cooldown = 5100;
                return 24;
            }
            if (Enumerable.Range(99, 1).Contains(level))
            {
                cooldown = 5050;
                return 25;
            }
            if (!Enumerable.Range(100, 1).Contains(level)) throw new Exception("Invalid PetLevel");
            cooldown = 5000;
            return 25;
            //switch (level)
            //{
            //    case 1:
            //        cooldown = 10000;
            //        return 10;
            //    case 2:
            //        cooldown = 9200;
            //        return 11;
            //    default:
            //        throw new Exception("Invalid PetLevel");
            //}
        }
    }
}