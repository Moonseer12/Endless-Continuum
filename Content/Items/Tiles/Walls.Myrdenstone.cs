using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenstoneWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenstoneWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Pink, new Vector2(24, 24), 0, ModContent.WallType<MyrdenstoneWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<Myrdenstone>().AddTile(TileID.WorkBenches).Register();
}

class MyrdenstoneWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "MyrdenstoneWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.Hay, SoundID.Tink, false, new Color(74, 63, 37));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}