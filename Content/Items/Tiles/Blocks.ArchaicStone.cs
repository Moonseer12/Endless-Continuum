using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class ArchaicStone : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "ArchaicStone";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Purple, new Vector2(16, 16), 0, ModContent.TileType<ArchaicStoneTile>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<ArchaicStoneWall>(4).Register();
}

class ArchaicStoneTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "ArchaicStoneTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickBlockTile(this, DustID.DynastyWood, SoundID.Tink, 10f, 300, new Color(82, 56, 52));
        QuickTile.QuickTileMerge(this, ModContent.TileType<ArchaicStoneBrickTile>());
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}