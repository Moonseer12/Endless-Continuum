using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class Myrdendirt : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "Myrdendirt";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Pink, new Vector2(16, 16), 0, ModContent.TileType<MyrdendirtTile>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<MyrdendirtWall>(4).Register();
}

class MyrdendirtTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdendirtTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickBlockTile(this, DustID.Hay, SoundID.Dig, 1f, 0, new Color(82, 70, 40));
        QuickTile.QuickTileMerge(this, ModContent.TileType<MyrdenstoneTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<MyrdenwoodTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<AeriumOreTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<SurgestoneOreTile>());
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}