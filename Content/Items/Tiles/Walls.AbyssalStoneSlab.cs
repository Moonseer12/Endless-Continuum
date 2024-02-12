using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AbyssalStoneSlabWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "AbyssalStoneSlabWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Green, new Vector2(24, 24), 0, ModContent.WallType<AbyssalStoneSlabWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<AbyssalStoneSlab>().AddTile(TileID.WorkBenches).Register();
}

class AbyssalStoneSlabWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "AbyssalStoneSlabWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.Cobalt, SoundID.Tink, true, new Color(23, 28, 51));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}