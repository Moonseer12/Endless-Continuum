using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenwoodFence : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodFence";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Pink, new Vector2(34, 32), 0, ModContent.WallType<MyrdenwoodFenceTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<Myrdenwood>().AddTile(TileID.WorkBenches).Register();
}

class MyrdenwoodFenceTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodFenceTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.DynastyWood, SoundID.Dig, true, new Color(82, 70, 40));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}