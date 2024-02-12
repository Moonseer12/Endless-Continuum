using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenstoneBrick : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenstoneBrick";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Pink, new Vector2(16, 16), 0, ModContent.TileType<MyrdenstoneBrickTile>());
    public override void AddRecipes()
    {
        CreateRecipe().AddIngredient<Myrdenstone>(2).AddTile(TileID.Furnaces).Register();
        CreateRecipe().AddIngredient<MyrdenstoneBrickWall>(4).Register();
    }
}

class MyrdenstoneBrickTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdenstoneBrickTile";
    public override void SetStaticDefaults() => QuickTile.QuickBlockTile(this, DustID.Hay, SoundID.Tink, 1f, 0, new Color(82, 70, 40));
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}