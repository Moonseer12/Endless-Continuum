using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AbyssalDirtWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "AbyssalDirtWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Green, new Vector2(24, 24), 0, ModContent.WallType<AbyssalDirtWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<AbyssalDirt>().AddTile(TileID.WorkBenches).Register();
}

class AbyssalDirtWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "AbyssalDirtWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.Cobalt, SoundID.Dig, false, new Color(23, 28, 51));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}