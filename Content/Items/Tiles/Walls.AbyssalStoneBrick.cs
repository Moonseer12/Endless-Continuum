using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AbyssalStoneBrickWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "AbyssalStoneBrickWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Green, new Vector2(24, 24), 0, ModContent.WallType<AbyssalStoneBrickWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<AbyssalStoneBrick>().AddTile(TileID.WorkBenches).Register();
}

class AbyssalStoneBrickWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "AbyssalStoneBrickWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.Cobalt, SoundID.Tink, true, new Color(209, 40, 43));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}