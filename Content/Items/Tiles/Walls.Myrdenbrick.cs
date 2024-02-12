using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenbrickWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenbrickWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Pink, new Vector2(24, 24), 0, ModContent.WallType<MyrdenbrickWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<Myrdenbrick>().AddTile(TileID.WorkBenches).Register();
}

class MyrdenbrickWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "MyrdenbrickWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.t_Honey, SoundID.Tink, true, new Color(112, 41, 15));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}