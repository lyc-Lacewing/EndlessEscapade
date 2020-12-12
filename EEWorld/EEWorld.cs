using EEMod.Autoloading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using EEMod.Tiles;
using EEMod.Tiles.Furniture;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;
using EEMod.ID;
using EEMod.Tiles.Furniture.Coral;
using EEMod.Tiles.Ores;
using EEMod.Tiles.Walls;
using Terraria.GameContent.Events;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Terraria.DataStructures;
using EEMod.Tiles.EmptyTileArrays;
using System.Linq;
using EEMod.VerletIntegration;

namespace EEMod.EEWorld
{
    public partial class EEWorld : ModWorld
    {
        public int minionsKilled;
        public static EEWorld instance => ModContent.GetInstance<EEWorld>();
        public static bool downedTalos;
        public static bool downedCoralGolem;
        public static bool downedAkumo;
        public static bool downedHydros;
        public static bool downedOmen;
        public static bool downedKraken;
        public static bool omenPath;
        public static Vector2[] reefMinibiomes = new Vector2[6];

        // private static List<Point> BiomeCenters;
        public static Vector2 yes;

        public static Vector2 ree;

        [FieldInit]
        public static IList<Vector2> EntracesPosses = new List<Vector2>();

        [FieldInit(FieldInitType.ArrayIntialization, 6)]
        public static byte[] LightStates = new byte[6];

        [FieldInit(FieldInitType.ArrayIntialization, 100)]
        public static Vector2[] PylonBegin = new Vector2[100];

        [FieldInit(FieldInitType.ArrayIntialization, 100)]
        public static Vector2[] PylonEnd = new Vector2[100];

        [FieldInit(FieldInitType.ArrayIntialization, 10000)]
        public static Vector2[] sinDis = new Vector2[10000];

        //public Vector2[] sinDis = new Vector2[10000];
        public override void Initialize()
        {
            ModContent.GetInstance<EEMod>().TVH.Clear();
            if (sinDis != null)
            {
                for (int i = 0; i < sinDis.Length; i++)
                {
                    // When an array is created all elements get initialized to the default value, and the default value of structs isn't null
                    sinDis[i].X = WorldGen.genRand.NextFloat(0, 0.03f);
                }
            }
            eocFlag = NPC.downedBoss1;
            if (EntracesPosses != null)
            {
                if (EntracesPosses.Count > 0)
                {
                    yes = EntracesPosses[0];
                }
            }
            Main.LocalPlayer.GetModPlayer<EEPlayer>().isInSubworld = Main.ActiveWorldFileData.Path.Contains($@"{Main.SavePath}\Worlds\{Main.LocalPlayer.GetModPlayer<EEPlayer>().baseWorldName}Subworlds");
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex != -1)
            {
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Endless Escapade Ores", EEModOres));
            }
            int MicroBiomes = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
            /*if (LivingTreesIndex != -1)
            {
                tasks.Insert(LivingTreesIndex + 1, new PassLegacy("Post Terrain", delegate (GenerationProgress progress)
                {
                    progress.Message = "Generating structures";
                    for (int l = 0; l < 30; l++)
                    {
                        int posX = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int posY = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY);
                        PlaceRuins(posX, posY, ruinsShape);
                    }
                }));
            }*/
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteVector2(ree);
            writer.WriteVector2(yes);
            for (int i = 0; i < LightStates.Length; i++)
            {
                writer.Write(LightStates[i]);
            }
        }

        public override void NetReceive(BinaryReader reader)
        {
            ree = reader.ReadVector2();
            yes = reader.ReadVector2();
            for (int i = 0; i < LightStates.Length; i++)
            {
                LightStates[i] = reader.ReadByte();
            }
        }

        public override void PostWorldGen()
        {
            DoAndAssignShrineValues();
            DoAndAssignShipValues();
            for (int i = 0; i < sinDis.Length; i++)
            {
                sinDis[i].X = Main.rand.NextFloat(0, 0.03f);
            }
        }

        public void DrawVines()
        {
            if (EESubWorlds.ChainConnections.Count > 0)
            {
                for (int i = 1; i < EESubWorlds.ChainConnections.Count - 2; i++)
                {
                    sinDis[i].Y += sinDis[i].X;
                    Vector2 addOn = new Vector2(0, 8);
                    Vector2 ChainConneccPos = EESubWorlds.ChainConnections[i] * 16;
                    Vector2 LastChainConneccPos = EESubWorlds.ChainConnections[i - 1] * 16;
                    Tile CurrentTile = Main.tile[(int)EESubWorlds.ChainConnections[i].X, (int)EESubWorlds.ChainConnections[i].Y];
                    Tile LastTile = Main.tile[(int)EESubWorlds.ChainConnections[i - 1].X, (int)EESubWorlds.ChainConnections[i - 1].Y];
                    bool isValid = CurrentTile.active() && LastTile.active() && Main.tileSolid[CurrentTile.type] && Main.tileSolid[LastTile.type];
                    Vector2 MidNorm = (ChainConneccPos + LastChainConneccPos) / 2;
                    Vector2 Mid = (ChainConneccPos + LastChainConneccPos) / 2 + new Vector2(0, 50 + (float)(Math.Sin(sinDis[i].Y) * 30));
                    Vector2 lerp1 = Vector2.Lerp(ChainConneccPos, LastChainConneccPos, 0.2f);
                    Vector2 lerp2 = Vector2.Lerp(ChainConneccPos, LastChainConneccPos, 0.8f);
                    if (MidNorm.Y > 100 * 16 && Vector2.DistanceSquared(ChainConneccPos, LastChainConneccPos) < 40 * 16 * 40 * 16 && Vector2.DistanceSquared(Main.LocalPlayer.Center, MidNorm) < 2000 * 2000 && isValid && Collision.CanHit(lerp1, 1, 1, lerp2, 1, 1))
                    {
                        Helpers.DrawBezier(EEMod.instance.GetTexture("Projectiles/Vine"), Color.White, ChainConneccPos, LastChainConneccPos, Mid, 0.6f, MathHelper.PiOver2, true);
                        Helpers.DrawBezier(EEMod.instance.GetTexture("Projectiles/Light"), Color.White, ChainConneccPos + addOn, LastChainConneccPos + addOn, Mid + addOn, 8f, MathHelper.PiOver2, false, 1, true);
                    }
                }
            }
        }

        public override void PostUpdate()
        {
            if (NPC.downedBoss1)
            {
                if (!eocFlag)
                {
                    eocFlag = true;
                    Main.NewText("You hear a strong wind erupting from the desert...", 228, 171, 72);
                    StartSandstorm();
                }
            }
        }

        public static Vector2 SubWorldSpecificCoralBoatPos;
        public static Vector2 SubWorldSpecificVolcanoInsidePos = new Vector2(198, 189);

        public static int customBiome = 0;
        public static bool eocFlag;

        public static bool shipComplete;

        public static List<Vector2> missingShipTiles = new List<Vector2>();
        public static List<Texture2D> missingShipTilesItems = new List<Texture2D>();
        public static List<Vector2> missingShipTilesRespectedPos = new List<Vector2>();

        public static void ShipComplete()
        {
            /*if (ree == Vector2.Zero)
            {
                ShipTilePosX = 100;
                ShipTilePosY = TileCheckWater(100) - 22;
            }
            for (int i = ShipTilePosX; i < ShipTilePosX + ShipTiles.GetLength(1); i++)
            {
                for (int j = ShipTilePosY; j < ShipTilePosY + ShipTiles.GetLength(0); j++)
                {
                    if (WorldGen.InWorld(i - 3, i - 6, 32))
                    {
                        Tile tile = Framing.GetTileSafely(i - 3, j - 6);
                        int expectedType;
                        switch (ShipTiles[j - ShipTilePosY, i - ShipTilePosX])
                        {
                            case 1:
                                expectedType = TileID.WoodBlock;
                                if (tile.type != expectedType)
                                {
                                    missingShipTilesItems.Add(Main.itemTexture[ItemID.Wood]);
                                    missingShipTilesRespectedPos.Add(new Vector2(i, j));
                                }
                                break;

                            case 2:
                                expectedType = TileID.RichMahogany;
                                if (tile.type != expectedType)
                                {
                                    missingShipTilesItems.Add(Main.itemTexture[ItemID.RichMahogany]);
                                    missingShipTilesRespectedPos.Add(new Vector2(i, j));
                                }
                                break;

                            case 3:
                                expectedType = TileID.GoldCoinPile;
                                if (tile.type != expectedType)
                                {
                                    missingShipTilesItems.Add(Main.itemTexture[ItemID.GoldCoin]);
                                    missingShipTilesRespectedPos.Add(new Vector2(i, j));
                                }
                                break;

                            case 4:
                                expectedType = TileID.Platforms;
                                if (tile.type != expectedType)
                                {
                                    missingShipTilesItems.Add(Main.itemTexture[ItemID.WoodPlatform]);
                                    missingShipTilesRespectedPos.Add(new Vector2(i, j));
                                }
                                break;

                            case 5:
                                expectedType = TileID.WoodenBeam;
                                if (tile.type != expectedType)
                                {
                                    missingShipTilesItems.Add(Main.itemTexture[ItemID.WoodenBeam]);
                                    missingShipTilesRespectedPos.Add(new Vector2(i, j));
                                }
                                break;

                            case 6:
                                expectedType = TileID.SilkRope;
                                if (tile.type != expectedType)
                                {
                                    missingShipTilesItems.Add(Main.itemTexture[ItemID.SilkRope]);
                                    missingShipTilesRespectedPos.Add(new Vector2(i, j));
                                }
                                break;

                            default:
                                expectedType = 0;
                                if (tile.type != expectedType)
                                {
                                    missingShipTilesItems.Add(EEMod.instance.GetTexture("Empty"));
                                    missingShipTilesRespectedPos.Add(new Vector2(i, j));
                                }
                                break;
                        }
                        if (tile.type != expectedType)
                        {
                            missingShipTiles.Add(new Vector2(i, j));
                        }
                    }
                }
            }*/

            int? nullableReeX = (int)ree.X;
            int? nullableReeY = (int)ree.Y;
            int ShipTilePosX = nullableReeX ?? 100;
            int ShipTilePosY = nullableReeY ?? TileCheckWater(100) - 22;

            bool hasSteeringWheel = false;
            int numberOfTiles = 0;
            for (int i = ShipTilePosX; i < ShipTilePosX + ShipTiles.GetLength(1); i++)
            {
                for (int j = ShipTilePosY; j < ShipTilePosY + ShipTiles.GetLength(0); j++)
                {
                    if(Main.tile[i, j].active() == true)
                    {
                        numberOfTiles++;
                    }
                    if(Main.tile[i, j].type == ModContent.TileType<WoodenShipsWheelTile>())
                    {
                        hasSteeringWheel = true;
                    }
                }
            }

            if (hasSteeringWheel && numberOfTiles > 100)
            {
                shipComplete = true;
            }
            else
            {
                shipComplete = false;
            }
        }

        public static bool HydrosCheck()
        {
            if (instance.minionsKilled >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static IList<Vector2> Vines = new List<Vector2>();
        public override void Load(TagCompound tag)
        {
            if (tag.ContainsKey("EntracesPosses"))
            {
                EntracesPosses = tag.GetList<Vector2>("EntracesPosses");
            }
            if (tag.ContainsKey("CoralBoatPos"))
            {
                EESubWorlds.CoralBoatPos = tag.Get<Vector2>("CoralBoatPos");
            }
            if (tag.ContainsKey("SubWorldSpecificVolcanoInsidePos"))
            {
                SubWorldSpecificVolcanoInsidePos = tag.Get<Vector2>("SubWorldSpecificVolcanoInsidePos");
            }
            if (tag.ContainsKey("yes"))
            {
                yes = tag.Get<Vector2>("yes");
            }
            if (tag.ContainsKey("ree"))
            {
                ree = tag.Get<Vector2>("ree");
            }
            if (tag.ContainsKey("SpirePosition"))
            {
                EESubWorlds.SpirePosition = tag.Get<Vector2>("SpirePosition");
            }
            if (tag.ContainsKey("ChainConnections"))
            {
                EESubWorlds.ChainConnections = tag.GetList<Vector2>("ChainConnections");
            }
            if (tag.ContainsKey("OrbPositions"))
            {
                EESubWorlds.OrbPositions = tag.GetList<Vector2>("OrbPositions");
            }
            if (tag.ContainsKey("BulbousTreePosition"))
            {
                EESubWorlds.BulbousTreePosition = tag.GetList<Vector2>("BulbousTreePosition");
            }
            if (tag.ContainsKey("SwingableVines"))
            {
                VerletHelpers.SwingableVines = tag.GetList<Vector2>("SwingableVines");
                if (VerletHelpers.SwingableVines.Count != 0)
                {
                    foreach (Vector2 vec in VerletHelpers.SwingableVines)
                    {
                        VerletHelpers.AddStickChainNoAdd(ref ModContent.GetInstance<EEMod>().verlet, vec, Main.rand.Next(5, 15), 27);
                    }
                }
            }
            if (tag.ContainsKey("EmptyTileVectorMain") && tag.ContainsKey("EmptyTileVectorSub"))
            {
                IList<Vector2> VecMains = tag.GetList<Vector2>("EmptyTileVectorMain");
                IList<Vector2> VecSubs = tag.GetList<Vector2>("EmptyTileVectorSub");
                EmptyTileEntityCache.EmptyTilePairs = VecMains.Zip(VecSubs, (k, v) => new { Key = k, Value = v }).ToDictionary(x => x.Key, x => x.Value);
            }
            if (tag.ContainsKey("EmptyTileVectorEntities") && tag.ContainsKey("EmptyTileEntities"))
            {
                IList<Vector2> VecMains = tag.GetList<Vector2>("EmptyTileVectorEntities");
                IList<EmptyTileDrawEntity> VecSubs = tag.GetList<EmptyTileDrawEntity>("EmptyTileEntities");
                EmptyTileEntityCache.EmptyTileEntityPairs = VecMains.Zip(VecSubs, (k, v) => new { Key = k, Value = v }).ToDictionary(x => x.Key, x => x.Value);
            }
            if (tag.ContainsKey("CoralCrystalPosition"))
            {
                EESubWorlds.CoralCrystalPosition = tag.GetList<Vector2>("CoralCrystalPosition");
                // for (int i = 0; i < EESubWorlds.CoralCrystalPosition.Count; i++)
                //    EmptyTileEntityCache.AddPair(new Crystal(EESubWorlds.CoralCrystalPosition[i]), EESubWorlds.CoralCrystalPosition[i], EmptyTileArrays.CoralCrystal);
            }
            if (tag.ContainsKey("LightStates"))
            {
                LightStates = tag.GetByteArray("LightStates");
            }
            if (tag.ContainsKey("ReefMinibiomesPositions") && tag.ContainsKey("ReefMinibiomeTypes"))
            {
                List<Vector3> tempList = new List<Vector3>();

                for (int i = 0; i < tag.GetList<Vector2>("ReefMinibiomePositions").Count; i++)
                {
                    tempList.Add(new Vector3(tag.GetList<Vector2>("ReefMinibiomePositions")[i].X, tag.GetList<Vector2>("ReefMinibiomePositions")[i].Y, tag.GetIntArray("ReefMinibiomeTypes")[i]));
                }

                EESubWorlds.MinibiomeLocations = tempList;
            }
            var downed = new List<string>();
            if (eocFlag)
            {
                downed.Add("eocFlag");
            }
            IList<string> flags = tag.GetList<string>("boolFlags");

            // Game modes

            // Downed bosses
            downedAkumo = flags.Contains("downedAkumo");
            downedHydros = flags.Contains("downedHydros");
            downedKraken = flags.Contains("downedKraken");
        }

        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();
            if (Main.ActiveWorldFileData.Name == KeyID.CoralReefs)
            {
                tag["CoralBoatPos"] = EESubWorlds.CoralBoatPos;
                tag["ChainConnections"] = EESubWorlds.ChainConnections;
                tag["OrbPositions"] = EESubWorlds.OrbPositions;
                tag["BulbousTreePosition"] = EESubWorlds.BulbousTreePosition;
                tag["SwingableVines"] = VerletHelpers.SwingableVines;
                tag["LightStates"] = LightStates;
                tag["CoralCrystalPosition"] = EESubWorlds.CoralCrystalPosition;
                tag["SpirePosition"] = EESubWorlds.SpirePosition;
                tag["EmptyTileVectorMain"] = EmptyTileEntityCache.EmptyTilePairs.Keys.ToList();
                tag["EmptyTileVectorSub"] = EmptyTileEntityCache.EmptyTilePairs.Values.ToList();
                tag["EmptyTileVectorEntities"] = EmptyTileEntityCache.EmptyTileEntityPairs.Keys.ToList();
                tag["EmptyTileEntities"] = EmptyTileEntityCache.EmptyTileEntityPairs.Values.ToList();



                if (EESubWorlds.MinibiomeLocations.Count > 0)
                {
                    Vector2[] ReefMinibiomePositions = new Vector2[EESubWorlds.MinibiomeLocations.Count];
                    int[] ReefMinibiomeTypes = new int[EESubWorlds.MinibiomeLocations.Count];
                    for (int i = 0; i < EESubWorlds.MinibiomeLocations.Count; i++)
                    {
                        ReefMinibiomePositions[i] = new Vector2(EESubWorlds.MinibiomeLocations[i].X, EESubWorlds.MinibiomeLocations[i].Y);
                        ReefMinibiomeTypes[i] = (int)EESubWorlds.MinibiomeLocations[i].Z;
                    }

                    tag["ReefMinibiomePositions"] = ReefMinibiomePositions;
                    tag["ReefMinibiomeTypes"] = ReefMinibiomeTypes;
                }
            }
            if (Main.ActiveWorldFileData.Name == KeyID.VolcanoInside)
            {
                tag["SubWorldSpecificVolcanoInsidePos"] = SubWorldSpecificVolcanoInsidePos;
            }
            tag["EntracesPosses"] = EntracesPosses;
            tag["yes"] = yes;
            tag["ree"] = ree;
            return tag;
        }
    }
}