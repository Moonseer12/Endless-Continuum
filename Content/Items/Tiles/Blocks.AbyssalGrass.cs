using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class AbyssalGrassSeeds : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "AbyssalGrassSeeds";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AbyssalGrassTile>(), 0);
            Item.width = 24;
            Item.height = 20;
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Orange;
        }
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
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<AbyssalDirtTile>()] = true;
            Main.tileMerge[ModContent.TileType<AbyssalDirtTile>()][Type] = true;
            Main.tileMerge[Type][ModContent.TileType<AbyssalStoneTile>()] = true;
            Main.tileMerge[ModContent.TileType<AbyssalStoneTile>()][Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;
            TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
            TileID.Sets.Grass[Type] = true;
            TileID.Sets.ChecksForMerge[Type] = true;
            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.NeedsGrassFramingDirt[Type] = ModContent.TileType<AbyssalDirtTile>();
            TileID.Sets.CanBeDugByShovel[Type] = true;
            TileID.Sets.ResetsHalfBrickPlacementAttempt[Type] = true;
            TileID.Sets.DoesntPlaceWithTileReplacement[Type] = true;
            TileID.Sets.SpreadOverground[Type] = true;
            TileID.Sets.SpreadUnderground[Type] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(88, 191, 214));
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
            Tile tileBelow = Framing.GetTileSafely(i, j + 1);
            Tile tileAbove = Framing.GetTileSafely(i, j - 1);
            Tile tile = Framing.GetTileSafely(i, j);
            if (!tileAbove.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(15) && Main.tile[i, j - 1].LiquidAmount == 0)
            {
                WorldGen.PlaceObject(i, j - 1, ModContent.TileType<AbyssalGrass>(), true, Main.rand.Next(11));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<AbyssalGrass>(), Main.rand.Next(11), 0, -1, -1);
            }
            if (Main.rand.NextBool(4))
                WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), ModContent.TileType<AbyssalDirtTile>(), Type, false);
        }
        public override IEnumerable<Item> GetItemDrops(int i, int j) { yield return new Item(ModContent.ItemType<AbyssalDirt>()); }
    }
}