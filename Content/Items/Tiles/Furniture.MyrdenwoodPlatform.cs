using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenwoodPlatform : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenwoodPlatform";
    public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(24, 14), 0, ModContent.TileType<MyrdenwoodPlatformTile>());
	public override void AddRecipes() => CreateRecipe(2).AddIngredient<Myrdenwood>().AddTile(TileID.WorkBenches).Register();
}

class MyrdenwoodPlatformTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdenwoodPlatformTile";
	public override void SetStaticDefaults() => QuickTile.QuickPlatformTile(this, DustID.Hay, new Color(143, 123, 74));
	public override void PostSetDefaults() => Main.tileNoSunLight[Type] = false;
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}