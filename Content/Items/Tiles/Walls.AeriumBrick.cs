using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AeriumBrickWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "AeriumBrickWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Pink, new Vector2(24, 24), 0, ModContent.WallType<AeriumBrickWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<AeriumBrick>().AddTile(TileID.WorkBenches).Register();
}

class AeriumBrickWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "AeriumBrickWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.GemAmber, SoundID.Tink, true, new Color(156, 130, 17));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}