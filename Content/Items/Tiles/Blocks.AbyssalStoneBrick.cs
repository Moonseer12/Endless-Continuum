using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AbyssalStoneBrick : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "AbyssalStoneBrick";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Green, new Vector2(16, 16), 0, ModContent.TileType<AbyssalStoneBrickTile>());
    public override void AddRecipes()
    {
        CreateRecipe().AddIngredient<AbyssalStone>(2).AddTile(TileID.Furnaces).Register();
        CreateRecipe().AddIngredient<AbyssalStoneBrickWall>(4).Register();
    }
}

class AbyssalStoneBrickTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "AbyssalStoneBrickTile";
    public override void SetStaticDefaults() => QuickTile.QuickBlockTile(this, DustID.Cobalt, SoundID.Tink, 1f, 0, new Color(103, 137, 171));
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}