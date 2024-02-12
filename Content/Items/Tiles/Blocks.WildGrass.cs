using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class WildGrassSeeds : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "WildGrassSeeds";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Blue, new Vector2(24, 20), 0, ModContent.TileType<WildGrassTile>());
    public override bool CanUseItem(Player p)
    {
        Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
        if (tile != null && tile.HasTile && tile.TileType == ModContent.TileType<WildDirtTile>())
        {
            WorldGen.destroyObject = true;
            TileID.Sets.BreakableWhenPlacing[ModContent.TileType<WildDirtTile>()] = true;
            return base.CanUseItem(p);
        }
        return false;
    }
    public override bool? UseItem(Player p)
    {
        WorldGen.destroyObject = false;
        TileID.Sets.BreakableWhenPlacing[ModContent.TileType<WildDirtTile>()] = false;
        return base.UseItem(p);
    }
}

class WildGrassTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "WildGrassTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickGrassTile(this, DustID.Plantera_Green, SoundID.Grass, 1f, 0, false, ModContent.TileType<WildDirtTile>(), new Color(119, 161, 85));
        QuickTile.QuickTileMerge(this, ModContent.TileType<WildDirtTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<WildStoneTile>());
    }
    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (!fail)
        {
            fail = true;
            Framing.GetTileSafely(i, j).TileType = (ushort)ModContent.TileType<WildDirtTile>();
        }
    }
    public override void RandomUpdate(int i, int j)
    {
        Tile tileAbove = Framing.GetTileSafely(i, j - 1);
        if (!tileAbove.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(15) && Main.tile[i, j - 1].LiquidAmount == 0)
        {
            WorldGen.PlaceObject(i, j - 1, ModContent.TileType<WildGrass>(), true, Main.rand.Next(5));
            NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<WildGrass>(), Main.rand.Next(5), 0, -1, -1);
        }
        if (Main.rand.NextBool(4))
            WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), ModContent.TileType<WildDirtTile>(), Type, false);
    }
    public override IEnumerable<Item> GetItemDrops(int i, int j) { yield return new Item(ModContent.ItemType<WildDirt>()); }
}