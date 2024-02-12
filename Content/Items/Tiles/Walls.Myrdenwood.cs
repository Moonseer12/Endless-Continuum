using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenwoodWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Pink, new Vector2(24, 24), 0, ModContent.WallType<MyrdenwoodWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<Myrdenwood>().AddTile(TileID.WorkBenches).Register();
}

class MyrdenwoodWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.DynastyWood, SoundID.Dig, true, new Color(51, 43, 25));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}