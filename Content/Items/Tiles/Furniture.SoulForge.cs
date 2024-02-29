using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EndlessContinuum.Content.Items.Tiles;

class SoulForge : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "SoulForge";
    public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(30, 32), Item.sellPrice(0, 25, 0, 0), ModContent.TileType<SoulForgeTile>());
}

class SoulForgeTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "SoulForgeTile";
    public override void SetStaticDefaults() => QuickTile.QuickFurnitureTile(this, DustID.Hay, false, false, TileObjectData.Style3x3, 3, 3, new int[] { 16, 16, 16 }, false, false, new Color(212, 184, 102));
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    public override void KillMultiTile(int i, int j, int frameX, int frameY) => Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<SoulForge>());
}