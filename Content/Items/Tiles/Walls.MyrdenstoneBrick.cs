using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenstoneBrickWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenstoneBrickWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Pink, new Vector2(24, 24), 0, ModContent.WallType<MyrdenstoneBrickWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<MyrdenstoneBrick>().AddTile(TileID.WorkBenches).Register();
}

class MyrdenstoneBrickWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "MyrdenstoneBrickWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.DynastyWood, SoundID.Tink, true, new Color(51, 43, 25));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}