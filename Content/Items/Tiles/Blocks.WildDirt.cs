using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class WildDirt : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "WildDirt";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Blue, new Vector2(16, 16), 0, ModContent.TileType<WildDirtTile>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<WildDirtWall>(4).Register();
}

class WildDirtTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "WildDirtTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickBlockTile(this, DustID.Poisoned, SoundID.Dig, 1f, 0, new Color(30, 56, 35));
        QuickTile.QuickTileMerge(this, ModContent.TileType<WildStoneTile>());
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}