using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdengrassSeeds : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdengrassSeeds";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Pink, new Vector2(22, 18), 0, ModContent.TileType<MyrdengrassTile>());
    public override bool CanUseItem(Player p)
    {
        Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
        if (tile != null && tile.HasTile && tile.TileType == ModContent.TileType<MyrdendirtTile>())
        {
            WorldGen.destroyObject = true;
            TileID.Sets.BreakableWhenPlacing[ModContent.TileType<MyrdendirtTile>()] = true;
            return base.CanUseItem(p);
        }
        return false;
    }
    public override bool? UseItem(Player p)
    {
        WorldGen.destroyObject = false;
        TileID.Sets.BreakableWhenPlacing[ModContent.TileType<MyrdendirtTile>()] = false;
        return base.UseItem(p);
    }
}

class MyrdengrassTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdengrassTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickGrassTile(this, DustID.t_Honey, SoundID.Grass, 1f, 0, false, ModContent.TileType<MyrdendirtTile>(), new Color(166, 61, 20));
        QuickTile.QuickTileMerge(this, ModContent.TileType<MyrdendirtTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<MyrdenstoneTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<MyrdenwoodTile>());
    }
    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (!fail)
        {
            fail = true;
            Framing.GetTileSafely(i, j).TileType = (ushort)ModContent.TileType<MyrdendirtTile>();
        }
    }
    public override void RandomUpdate(int i, int j)
    {
        Tile tileBelow = Framing.GetTileSafely(i, j + 1);
        Tile tileAbove = Framing.GetTileSafely(i, j - 1);
        Tile tile = Framing.GetTileSafely(i, j);
        if (WorldGen.genRand.NextBool(15) && !tileBelow.HasTile && tileBelow.LiquidType != LiquidID.Lava)
        {
            if (tile.Slope != SlopeType.SlopeUpLeft && tile.Slope != SlopeType.SlopeUpRight)
            {
                tileBelow.TileType = (ushort)ModContent.TileType<MyrdengrassVines>();
                tileBelow.HasTile = true;
                WorldGen.SquareTileFrame(i, j + 1, true);
                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendTileSquare(-1, i, j + 1, 3, TileChangeType.None);
            }
        }
        if (!tileAbove.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(15) && Main.tile[i, j - 1].LiquidAmount == 0)
        {
            WorldGen.PlaceObject(i, j - 1, ModContent.TileType<Myrdengrass>(), true, Main.rand.Next(10));
            NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<Myrdengrass>(), Main.rand.Next(10), 0, -1, -1);
        }
        if (!tileAbove.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(15) && Main.tile[i, j - 1].LiquidAmount == 0)
        {
            WorldGen.PlaceObject(i, j - 1, ModContent.TileType<MyrdenTallGrass>(), true, Main.rand.Next(4));
            NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<MyrdenTallGrass>(), Main.rand.Next(4), 0, -1, -1);
        }
        if (!tileAbove.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(20) && Main.tile[i, j - 1].LiquidAmount == 0)
        {
            WorldGen.PlaceObject(i, j - 1, ModContent.TileType<Myrdenshrub>(), true, Main.rand.Next(4));
            NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<Myrdenshrub>(), Main.rand.Next(4), 0, -1, -1);
        }
        if (Main.rand.NextBool(4))
            WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), ModContent.TileType<MyrdendirtTile>(), Type, false);
    }
    public override IEnumerable<Item> GetItemDrops(int i, int j) { yield return new Item(ModContent.ItemType<Myrdendirt>()); }
}