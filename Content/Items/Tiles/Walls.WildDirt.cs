using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class WildDirtWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "WildDirtWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Blue, new Vector2(24, 24), 0, ModContent.WallType<WildDirtWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<WildDirt>().AddTile(TileID.WorkBenches).Register();
}

class WildDirtWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "WildDirtWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.Poisoned, SoundID.Dig, false, new Color(22, 41, 25));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}