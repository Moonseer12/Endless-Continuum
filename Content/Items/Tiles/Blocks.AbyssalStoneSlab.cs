using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AbyssalStoneSlab : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "AbyssalStoneSlab";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Green, new Vector2(16, 16), 0, ModContent.TileType<AbyssalStoneSlabTile>());
    public override void AddRecipes()
    {
        CreateRecipe().AddIngredient<AbyssalStone>().AddTile(TileID.HeavyWorkBench).Register();
        CreateRecipe().AddIngredient<AbyssalStoneSlabWall>(4).Register();
    }
}

class AbyssalStoneSlabTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "AbyssalStoneSlabTile";
    public override void SetStaticDefaults() => QuickTile.QuickBlockTile(this, DustID.Cobalt, SoundID.Tink, 1f, 0, new Color(34, 41, 77));
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}