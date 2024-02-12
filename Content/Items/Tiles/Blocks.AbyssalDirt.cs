using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AbyssalDirt : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "AbyssalDirt";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Green, new Vector2(16, 16), 0, ModContent.TileType<AbyssalDirtTile>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<AbyssalDirtWall>(4).Register();
}

class AbyssalDirtTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "AbyssalDirtTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickBlockTile(this, DustID.Cobalt, SoundID.Dig, 1f, 0, new Color(34, 41, 77));
        QuickTile.QuickTileMerge(this, ModContent.TileType<AbyssalStoneTile>());
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}