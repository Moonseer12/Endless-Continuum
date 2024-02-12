using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AbyssalGrassSeeds : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "AbyssalGrassSeeds";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Green, new Vector2(24, 20), 0, ModContent.TileType<AbyssalGrassTile>());
    public override bool CanUseItem(Player p)
    {
        Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
        if (tile != null && tile.HasTile && tile.TileType == ModContent.TileType<AbyssalDirtTile>())
        {
            WorldGen.destroyObject = true;
            TileID.Sets.BreakableWhenPlacing[ModContent.TileType<AbyssalDirtTile>()] = true;
            return base.CanUseItem(p);
        }
        return false;
    }
    public override bool? UseItem(Player p)
    {
        WorldGen.destroyObject = false;
        TileID.Sets.BreakableWhenPlacing[ModContent.TileType<AbyssalDirtTile>()] = false;
        return base.UseItem(p);
    }
}

class AbyssalGrassTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "AbyssalGrassTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickGrassTile(this, DustID.IceTorch, SoundID.Grass, 1f, 0, true, ModContent.TileType<AbyssalDirtTile>(), new Color(88, 191, 214));
        QuickTile.QuickTileMerge(this, ModContent.TileType<AbyssalDirtTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<AbyssalStoneTile>());
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = .57f;
        g = .98f;
        b = 1.73f;
    }
    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (!fail)
        {
            fail = true;
            Framing.GetTileSafely(i, j).TileType = (ushort)ModContent.TileType<AbyssalDirtTile>();
        }
    }
    public override void RandomUpdate(int i, int j)
    {
        Tile tileAbove = Framing.GetTileSafely(i, j - 1);
        if (!tileAbove.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(3) && Main.tile[i, j - 1].LiquidAmount == 0)
        {
            WorldGen.PlaceObject(i, j - 1, ModContent.TileType<AbyssalGrass>(), true, Main.rand.Next(7));
            NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<AbyssalGrass>(), Main.rand.Next(7), 0, -1, -1);
        }
        if (!tileAbove.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(10) && Main.tile[i, j - 1].LiquidAmount == 0)
        {
            WorldGen.PlaceObject(i - 1, j - 3, ModContent.TileType<LargeBulbia>(), true);
            NetMessage.SendObjectPlacement(-1, i - 1, j - 3, ModContent.TileType<LargeBulbia>(), 1, 0, -1, -1);
        }
        if (!tileAbove.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(8) && Main.tile[i, j - 1].LiquidAmount == 0)
        {
            WorldGen.PlaceObject(i - 1, j - 2, ModContent.TileType<BulbiaTree>(), true);
            NetMessage.SendObjectPlacement(-1, i - 1, j - 2, ModContent.TileType<BulbiaTree>(), 1, 0, -1, -1);
        }
        if (!tileAbove.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(7) && Main.tile[i, j - 1].LiquidAmount == 0)
        {
            WorldGen.PlaceObject(i, j - 2, ModContent.TileType<BulbiaStem>(), true);
            NetMessage.SendObjectPlacement(-1, i, j - 2, ModContent.TileType<BulbiaStem>(), 1, 0, -1, -1);
        }
        if (Main.rand.NextBool(4))
            WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), ModContent.TileType<AbyssalDirtTile>(), Type, false);
    }
    public override IEnumerable<Item> GetItemDrops(int i, int j) { yield return new Item(ModContent.ItemType<AbyssalDirt>()); }
}