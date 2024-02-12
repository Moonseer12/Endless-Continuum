using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class SurgestonePlatingWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "SurgestonePlatingWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Pink, new Vector2(24, 24), 0, ModContent.WallType<SurgestonePlatingWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<SurgestonePlating>().AddTile(TileID.WorkBenches).Register();
}

class SurgestonePlatingWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "SurgestonePlatingWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.CursedTorch, SoundID.Tink, true, new Color(96, 168, 61));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}