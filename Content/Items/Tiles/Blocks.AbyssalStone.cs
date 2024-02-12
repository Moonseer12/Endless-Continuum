using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AbyssalStone : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "AbyssalStone";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Green, new Vector2(16, 16), 0, ModContent.TileType<AbyssalStoneTile>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<AbyssalStoneWall>(4).Register();
}

class AbyssalStoneTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "AbyssalStoneTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickBlockTile(this, DustID.Cobalt, SoundID.Tink, 3f, 65, new Color(50, 66, 102));
        QuickTile.QuickTileMerge(this, ModContent.TileType<AbyssalDirtTile>());
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}