using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AeriumBar : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "AeriumBar";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Pink, new Vector2(30, 24), Item.sellPrice(0, 0, 80, 0), ModContent.TileType<AeriumBarTile>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<AeriumOre>(3).AddTile(TileID.AdamantiteForge).Register();
}

class AeriumBarTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "AeriumBarTile";
    public override void SetStaticDefaults() => QuickTile.QuickBarTile(this);
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}