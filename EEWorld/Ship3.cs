using static EEMod.EEWorld.EEWorld. Ship3Vals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EEMod.Tiles;
using Terraria.ModLoader;
using System.Threading.Tasks;
using Terraria.ID;
using EEMod.Tiles.Walls;
using EEMod.Tiles.Furniture.Chests;
namespace EEMod.EEWorld
{
public partial class EEWorld
{
internal static class Ship3Vals
{
internal const ushort A = 0;
internal static int B = ModContent.TileType<CoralSandTile>();
internal const ushort C = TileID.LivingMahoganyLeaves;
internal static int D = ModContent.TileType<CoralSandTile>();
internal const ushort E = TileID.PalmWood;
internal const ushort F = TileID.Ebonwood;
internal const ushort G = TileID.RichMahogany;
internal const ushort H = TileID.WoodBlock;
internal const ushort I = TileID.Chain;
internal const ushort J = TileID.Rope;
internal const ushort K = TileID.DyePlants;
internal const ushort L = TileID.Platforms;
internal static int M = ModContent.TileType<CoralChestTile>();
internal const ushort A0 = 0;
internal static int B1 = ModContent.WallType<CoralSandWallTile>();
internal const ushort C2 = WallID.LivingLeaf;
internal const ushort D3 = WallID.Ebonwood;
internal const ushort E4 = WallID.EbonwoodFence;
internal const ushort F5 = WallID.Wood;
internal const ushort G6 = WallID.Planked;
internal const ushort H7 = WallID.PalmWoodFence;
internal const ushort I8 = WallID.RichMaogany;
internal const ushort J9 = WallID.PalmWood;
internal const ushort K10 = WallID.ShadewoodFence;
}
public static int[,,] Ship3 = new int[,,]
{
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{I,K10,28,0,0,0,0,0,162,54,252,0},{J,-1,0,0,0,0,0,0,162,18,0,0},{J,-1,0,0,0,0,0,0,126,72,0,0},{J,-1,0,0,0,0,0,0,126,72,0,0},{J,-1,0,0,0,0,0,0,108,72,0,0},{J,-1,0,0,0,0,0,0,54,54,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,H7,0,0,0,0,0,0,0,0,252,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,E4,0,0,28,0,0,0,0,0,288,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,H7,0,0,0,0,0,0,0,0,288,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,K10,0,0,28,0,0,0,0,0,180,36},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,H7,0,0,0,0,0,0,0,0,288,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{J,H7,0,0,0,0,0,0,90,18,252,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,H7,0,0,28,0,0,0,0,0,180,72},{-1,-1,0,0,0,0,0,0,0,0,0,0},{I,K10,28,0,0,0,0,0,180,54,216,0},{J,-1,0,0,0,0,0,0,162,18,0,0},{J,-1,0,0,0,0,0,0,108,72,0,0},{J,-1,0,0,0,0,0,0,144,72,0,0},{J,-1,0,0,0,0,0,0,54,54,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{C,-1,20,0,0,0,0,0,36,54,0,0},{C,-1,20,1,0,0,0,0,90,54,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,E4,0,0,28,0,0,0,0,0,0,36},{-1,E4,0,0,28,0,0,0,0,0,288,144},{-1,H7,0,0,28,0,0,0,0,0,72,72},{-1,H7,0,0,28,0,0,0,0,0,288,144},{-1,K10,0,0,28,0,0,0,0,0,72,72},{B,B1,0,0,0,0,0,0,36,54,252,144},{B,H7,0,0,0,0,0,0,126,72,144,72},{B,-1,0,0,0,0,0,0,18,54,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{J,H7,0,0,28,0,0,0,108,54,0,36},{-1,H7,0,0,28,0,0,0,0,0,36,0},{-1,H7,0,0,28,0,0,0,0,0,36,36},{-1,E4,0,0,28,0,0,0,0,0,288,144},{-1,K10,0,0,28,0,0,0,0,0,108,72},{-1,E4,0,0,28,0,0,0,0,0,288,144},{-1,E4,0,0,28,0,0,0,0,0,36,108},{-1,-1,0,0,0,0,0,0,0,0,0,0},{J,K10,0,0,28,0,0,0,108,54,216,0},{C,-1,20,0,0,0,0,0,36,54,0,0},{C,-1,20,0,0,0,0,0,18,18,0,0},{C,-1,20,0,0,0,0,0,72,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{I,-1,28,0,0,0,0,0,108,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,E4,0,0,28,0,0,0,0,0,324,0},{F,H7,28,0,28,0,0,0,36,54,108,144},{E,-1,28,0,0,0,0,0,36,0,0,0},{G,-1,28,0,0,0,0,0,18,0,0,0},{E,-1,28,0,0,0,0,0,36,0,0,0},{H,-1,0,0,0,0,0,0,54,0,0,0},{E,-1,28,0,0,0,0,0,54,18,0,0},{E,B1,28,1,0,0,0,0,90,54,0,72},{B,B1,0,0,0,0,0,0,0,0,288,144},{B,B1,0,0,0,0,0,0,54,0,288,144},{B,E4,0,0,28,0,0,0,18,54,360,0},{H,H7,0,0,0,0,0,0,0,54,36,72},{E,H7,28,0,0,0,0,0,18,0,108,144},{H,-1,28,0,0,0,0,0,54,0,0,0},{F,-1,28,0,0,0,0,0,36,0,0,0},{E,-1,28,0,0,0,0,0,18,0,0,0},{E,E4,28,1,28,0,0,0,90,54,144,144},{C,H7,20,0,28,0,0,0,162,54,288,144},{C,K10,20,2,28,0,0,0,0,54,252,36},{C,H7,20,0,0,0,0,0,180,0,180,108},{C,-1,20,0,0,0,0,0,18,18,0,0},{C,-1,20,0,0,0,0,0,18,18,0,0},{C,H7,20,0,0,0,0,0,18,54,0,108},{I,K10,28,0,28,0,0,0,108,54,108,108},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{E,-1,28,2,0,0,0,0,162,18,0,0},{G,-1,28,0,0,0,0,0,108,72,0,0},{E,-1,28,0,0,0,0,0,54,36,0,0},{H,-1,0,0,0,0,0,0,54,18,0,0},{E,-1,28,0,0,0,0,0,36,18,0,0},{F,-1,28,0,0,0,0,0,36,18,0,0},{H,-1,28,0,0,0,0,0,36,36,0,0},{E,B1,28,3,0,0,0,0,54,72,0,108},{H,B1,28,0,0,0,0,0,0,0,144,36},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{H,B1,0,0,0,0,0,0,18,18,180,36},{E,-1,28,0,0,0,0,0,18,18,0,0},{F,-1,28,0,0,0,0,0,54,36,0,0},{G,-1,28,0,0,0,0,0,36,36,0,0},{E,-1,28,0,0,0,0,0,54,18,0,0},{F,-1,28,0,0,0,0,0,18,18,0,0},{G,-1,28,0,0,0,0,0,18,18,0,0},{H,-1,28,0,0,0,0,0,36,18,0,0},{E,H7,28,0,0,0,0,0,72,36,0,144},{C,H7,20,0,0,0,0,0,36,72,72,72},{C,H7,20,0,0,0,0,0,54,36,252,144},{C,H7,20,0,0,0,0,0,36,36,216,144},{C,H7,20,0,0,0,0,0,54,72,36,72},{G,H7,28,0,0,0,0,0,144,0,144,72},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,F5,0,0,28,0,0,0,0,0,324,36},{-1,G6,0,0,0,0,0,0,0,0,216,144},{E,G6,28,4,0,0,0,0,36,72,180,108},{F,-1,28,0,0,0,0,0,18,36,0,0},{E,-1,28,0,0,0,0,0,72,18,0,0},{-1,G6,0,0,0,0,0,0,0,0,72,108},{-1,G6,0,0,0,0,0,0,0,0,108,36},{B,B1,0,0,0,0,0,0,72,72,36,144},{D,-1,8,0,0,0,0,0,36,18,0,0},{B,B1,0,0,0,0,0,0,72,0,72,108},{E,B1,28,4,0,0,0,0,0,72,144,0},{F,-1,28,0,0,0,0,0,54,72,0,0},{-1,F5,0,0,28,0,0,0,0,0,0,108},{H,G6,28,0,0,0,0,0,162,18,288,144},{H,G6,28,0,0,0,0,0,36,36,36,108},{H,-1,0,0,0,0,0,0,18,18,0,0},{G,-1,28,0,0,0,0,0,36,18,0,0},{E,-1,28,0,0,0,0,0,36,18,0,0},{G,-1,28,0,0,0,0,0,54,18,0,0},{H,-1,28,0,0,0,0,0,54,0,0,0},{F,-1,28,0,0,0,0,0,54,0,0,0},{E,-1,28,0,0,0,0,0,18,0,0,0},{H,-1,28,0,0,0,0,0,18,0,0,0},{E,K10,28,0,28,0,0,0,18,36,180,72},{F,-1,28,0,0,0,0,0,126,72,0,0},{F,-1,28,0,0,0,0,0,216,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,J9,0,0,28,0,0,0,0,0,144,144},{-1,D3,0,0,28,0,0,0,0,0,108,0},{H,I8,28,3,28,0,0,0,144,54,216,144},{-1,I8,0,0,28,0,0,0,0,0,108,72},{-1,D3,0,0,28,0,0,0,0,0,144,36},{-1,-1,0,0,0,0,0,0,0,0,0,0},{B,B1,0,4,0,0,0,0,72,72,72,108},{B,B1,0,3,0,0,0,0,54,72,252,36},{-1,B1,0,0,0,0,0,0,0,0,360,72},{-1,B1,0,0,0,0,0,0,0,0,36,0},{-1,I8,0,0,28,0,0,0,0,0,144,36},{M,-1,28,0,0,0,0,0,0,0,0,0},{M,B1,28,0,0,0,0,0,18,0,0,36},{E,B1,28,0,0,0,0,0,0,36,432,72},{H,-1,28,0,0,0,0,0,54,18,0,0},{H,-1,28,0,0,0,0,0,54,18,0,0},{E,K10,28,0,28,0,0,0,54,18,216,0},{E,-1,28,0,0,0,0,0,36,36,0,0},{G,-1,28,0,0,0,0,0,108,36,0,0},{E,-1,28,0,0,0,0,0,36,36,0,0},{E,-1,28,3,0,0,0,0,18,72,0,0},{I,K10,28,0,28,0,0,0,144,0,252,108},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,F5,0,0,28,0,0,0,0,0,180,72},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,B1,0,0,0,0,0,0,0,0,0,0},{-1,B1,0,0,0,0,0,0,0,0,72,0},{-1,B1,0,0,0,0,0,0,0,0,36,36},{-1,I8,0,0,28,0,0,0,0,0,396,36},{-1,B1,0,0,0,0,0,0,0,0,72,36},{-1,J9,0,0,28,0,0,0,0,0,36,36},{-1,I8,0,0,28,0,0,0,0,0,144,36},{M,-1,28,0,0,0,0,0,0,18,0,0},{M,B1,28,0,0,0,0,0,18,18,288,108},{F,-1,28,0,0,0,0,0,0,36,0,0},{E,-1,28,0,0,0,0,0,54,18,0,0},{F,-1,28,0,0,0,0,0,54,18,0,0},{E,K10,0,3,28,0,0,0,90,72,180,36},{-1,-1,0,0,0,0,0,0,0,0,0,0},{G,-1,28,4,0,0,0,0,144,54,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{I,-1,28,0,0,0,0,0,90,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,I8,0,0,28,0,0,0,0,0,0,36},{-1,B1,0,0,0,0,0,0,0,0,72,0},{-1,J9,0,0,28,0,0,0,0,0,108,0},{-1,B1,0,0,0,0,0,0,0,0,36,72},{-1,B1,0,0,0,0,0,0,0,0,72,36},{-1,B1,0,0,0,0,0,0,0,0,216,72},{-1,B1,0,0,0,0,0,0,0,0,36,36},{-1,F5,0,0,28,0,0,0,0,0,108,36},{-1,B1,0,0,0,0,0,0,0,0,252,72},{L,B1,28,0,0,0,0,0,36,180,144,36},{L,-1,28,0,0,0,0,0,72,180,0,0},{H,-1,0,0,0,0,0,0,36,54,0,0},{E,-1,28,0,0,0,0,0,36,36,0,0},{H,-1,28,0,0,0,0,0,18,18,0,0},{E,-1,28,0,0,0,0,0,18,72,0,0},{I,K10,28,0,28,0,0,0,108,0,216,108},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{I,-1,28,0,0,0,0,0,90,36,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,I8,0,0,28,0,0,0,0,0,216,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,F5,0,0,28,0,0,0,0,0,0,36},{-1,G6,0,0,0,0,0,0,0,0,360,0},{-1,B1,0,0,0,0,0,0,0,0,144,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,J9,0,0,28,0,0,0,0,0,0,144},{-1,B1,0,0,0,0,0,0,0,0,72,36},{K,F5,8,0,28,0,0,0,272,0,252,36},{-1,B1,0,0,0,0,0,0,0,0,360,36},{-1,B1,0,0,0,0,0,0,0,0,72,36},{-1,B1,0,0,0,0,0,0,0,0,216,36},{E,D3,28,2,28,0,0,0,0,54,432,72},{H,-1,0,0,0,0,0,0,18,18,0,0},{E,-1,28,1,0,0,0,0,216,18,0,0},{E,-1,0,3,0,0,0,0,126,54,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{I,-1,28,0,0,0,0,0,90,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{I,-1,28,0,0,0,0,0,90,36,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,G6,0,0,0,0,0,0,0,0,324,36},{-1,G6,0,0,0,0,0,0,0,0,36,36},{-1,I8,0,0,28,0,0,0,0,0,72,0},{-1,C2,0,0,20,0,0,0,0,0,396,36},{C,C2,20,0,20,0,0,0,0,54,36,36},{C,C2,20,0,20,0,0,0,54,0,72,36},{C,C2,20,1,20,0,0,0,90,54,36,108},{-1,-1,0,0,0,0,0,0,0,0,0,0},{B,B1,0,0,0,0,0,0,0,54,0,36},{B,B1,0,0,0,0,0,0,36,0,396,72},{B,B1,0,0,0,0,0,0,126,72,36,36},{B,B1,0,0,0,0,0,0,54,54,36,36},{F,B1,28,2,0,0,0,0,0,54,36,144},{F,-1,28,0,0,0,0,0,54,18,0,0},{E,-1,0,3,0,0,0,0,54,72,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{I,-1,28,0,0,0,0,0,90,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{I,-1,28,0,0,0,0,0,90,18,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{C,-1,20,0,0,0,0,0,126,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{E,-1,28,4,0,0,0,0,162,18,0,0},{F,D3,28,0,28,0,0,0,126,72,288,0},{G,-1,28,0,0,0,0,0,36,0,0,0},{E,G6,28,1,0,0,0,0,90,54,0,144},{C,C2,20,0,20,0,0,0,162,0,108,72},{C,C2,20,0,20,0,0,0,108,72,72,72},{C,C2,20,0,20,0,0,0,180,0,36,36},{C,C2,20,0,20,0,0,0,18,18,288,72},{C,C2,20,0,20,0,0,0,18,36,36,36},{B,B1,0,0,0,0,0,0,54,0,252,144},{B,B1,0,0,0,0,0,0,36,18,288,72},{B,B1,0,0,0,0,0,0,72,0,36,36},{B,B1,0,2,0,0,0,0,72,54,72,36},{B,B1,0,0,0,0,0,0,54,36,144,0},{H,-1,0,0,0,0,0,0,18,18,0,0},{G,-1,28,0,0,0,0,0,54,72,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{-1,B1,0,0,0,0,0,0,0,0,288,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{I,-1,28,0,0,0,0,0,90,0,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{B,-1,0,2,0,0,0,0,36,54,0,0},{B,-1,0,0,0,0,0,0,18,0,0,0},{B,-1,0,0,0,0,0,0,54,0,0,0},{B,-1,0,0,0,0,0,0,18,0,0,0},{B,-1,0,0,0,0,0,0,90,54,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0}},
{{-1,-1,0,0,0,0,0,0,0,0,0,0},{C,-1,20,0,0,0,0,0,108,0,0,0},{C,-1,20,2,0,0,0,0,72,54,0,0},{C,-1,20,0,0,0,0,0,144,18,0,0},{C,-1,20,0,0,0,0,0,54,54,0,0},{-1,-1,0,0,0,0,0,0,0,0,0,0},{E,D3,28,0,28,0,0,0,36,54,216,108},{H,-1,0,0,0,0,0,0,0,18,0,0},{E,-1,28,0,0,0,0,0,54,36,0,0},{H,-1,0,0,0,0,0,0,54,18,0,0},{E,-1,28,0,0,0,0,0,72,36,0,0},{C,C2,20,0,20,0,0,0,36,72,72,144},{C,C2,20,0,20,0,0,0,18,18,108,72},{C,C2,20,1,20,0,0,0,18,54,180,144},{B,-1,0,0,0,0,0,0,0,36,0,0},{B,B1,0,0,0,0,0,0,54,36,0,0},{D,B1,8,0,0,0,0,0,36,18,72,72},{B,B1,0,3,0,0,0,0,18,72,72,72},{G,B1,28,0,0,0,0,0,72,54,180,144},{H,-1,0,0,0,0,0,0,0,36,0,0},{H,B1,0,0,0,0,0,0,18,54,324,0},{-1,B1,0,0,0,0,0,0,0,0,216,144},{-1,B1,0,0,0,0,0,0,0,0,288,144},{-1,B1,0,0,0,0,0,0,0,0,360,72},{B,B1,0,0,0,0,0,0,72,54,180,108},{B,-1,0,0,0,0,0,0,54,0,0,0},{B,B1,0,0,0,0,0,0,18,0,396,108},{B,-1,0,0,0,0,0,0,18,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{D,-1,8,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,54,54,0,0}},
{{B,-1,0,0,0,0,0,0,36,54,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{D,-1,8,0,0,0,0,0,72,18,0,0},{C,B1,20,0,0,0,0,0,0,72,252,0},{C,-1,20,0,0,0,0,0,18,18,0,0},{B,C2,0,0,20,0,0,0,18,0,324,108},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,18,18,0,0},{B,-1,0,0,0,0,0,0,18,54,0,0},{E,-1,28,0,0,0,0,0,0,18,0,0},{F,-1,28,0,0,0,0,0,36,18,0,0},{E,-1,28,0,0,0,0,0,36,0,0,0},{B,-1,0,0,0,0,0,0,18,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,B1,0,0,0,0,0,0,54,18,324,72},{B,B1,0,1,0,0,0,0,90,54,108,144},{H,-1,0,0,0,0,0,0,0,0,0,0},{E,-1,28,0,0,0,0,0,54,0,0,0},{H,-1,0,0,0,0,0,0,18,18,0,0},{E,-1,28,0,0,0,0,0,18,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,18,0,0,0},{B,-1,0,0,0,0,0,0,36,0,0,0},{B,B1,0,0,0,0,0,0,18,0,0,144},{B,B1,0,0,0,0,0,0,54,18,36,144},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{D,-1,8,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,72,0,0,0}},
{{B,-1,0,0,0,0,0,0,0,36,0,0},{B,-1,0,0,0,0,0,0,18,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{D,B1,8,0,0,0,0,0,54,54,252,108},{C,-1,20,0,0,0,0,0,0,36,0,0},{B,-1,0,0,0,0,0,0,18,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,18,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,18,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,18,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,18,18,0,0},{B,-1,0,0,0,0,0,0,54,18,0,0},{B,-1,0,0,0,0,0,0,36,18,0,0},{B,-1,0,0,0,0,0,0,18,18,0,0},{B,-1,0,0,0,0,0,0,72,18,0,0}},
};
}
}
