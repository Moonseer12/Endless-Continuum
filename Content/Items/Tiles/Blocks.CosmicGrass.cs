using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class CosmicGrassSeeds : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "CosmicGrassSeeds";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Cyan, new Vector2(22, 22), 0, ModContent.TileType<CosmicGrassTile>());
    public override bool CanUseItem(Player p)
    {
        Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
        if (tile != null && tile.HasTile && tile.TileType == ModContent.TileType<CosmicSoilTile>())
        {
            WorldGen.destroyObject = true;
            TileID.Sets.BreakableWhenPlacing[ModContent.TileType<CosmicSoilTile>()] = true;
            return base.CanUseItem(p);
        }
        return false;
    }
    public override bool? UseItem(Player p)
    {
        WorldGen.destroyObject = false;
        TileID.Sets.BreakableWhenPlacing[ModContent.TileType<CosmicSoilTile>()] = false;
        return base.UseItem(p);
    }
}

class CosmicGrassTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "CosmicGrassTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickGrassTile(this, DustID.Enchanted_Pink, SoundID.Grass, 1f, 0, true, ModContent.TileType<CosmicSoilTile>(), new Color(212, 144, 209));
        QuickTile.QuickTileMerge(this, ModContent.TileType<CosmicSoilTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<CosmicRockTile>());
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 2.12f;
        g = 1.44f;
        b = 2.09f;
    }
    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (!fail)
        {
            fail = true;
            Framing.GetTileSafely(i, j).TileType = (ushort)ModContent.TileType<CosmicSoilTile>();
        }
    }
    public override void RandomUpdate(int i, int j)
    {
        Tile tileAbove = Framing.GetTileSafely(i, j - 1);
        if (!tileAbove.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(15) && Main.tile[i, j - 1].LiquidAmount == 0)
        {
            WorldGen.PlaceObject(i, j - 1, ModContent.TileType<CosmicGrass>(), true, Main.rand.Next(6));
            NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<CosmicGrass>(), Main.rand.Next(6), 0, -1, -1);
        }
        if (Main.rand.NextBool(4))
            WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), ModContent.TileType<CosmicSoilTile>(), Type, false);
    }
    public override IEnumerable<Item> GetItemDrops(int i, int j) { yield return new Item(ModContent.ItemType<CosmicSoil>()); }
}