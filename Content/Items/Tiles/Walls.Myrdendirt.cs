using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdendirtWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdendirtWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Pink, new Vector2(24, 24), 0, ModContent.WallType<MyrdendirtWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<Myrdendirt>().AddTile(TileID.WorkBenches).Register();
}

class MyrdendirtWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "MyrdendirtWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.Hay, SoundID.Dig, false, new Color(51, 43, 25));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}