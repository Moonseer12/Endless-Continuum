using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class Myrdenbrick : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "Myrdenbrick";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Pink, new Vector2(16, 16), 0, ModContent.TileType<MyrdenbrickTile>());
    public override void AddRecipes()
    {
        CreateRecipe(5).AddIngredient<Myrdenstone>(5).AddIngredient<Materials.Myrdenfibers>().AddTile(TileID.Furnaces).Register();
        CreateRecipe().AddIngredient<MyrdenbrickWall>(4).Register();
    }
}

class MyrdenbrickTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdenbrickTile";
    public override void SetStaticDefaults() => QuickTile.QuickBlockTile(this, DustID.t_Honey, SoundID.Tink, 1f, 0, new Color(166, 61, 20));
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}