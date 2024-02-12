using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AbyssalStoneWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "AbyssalStoneWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Green, new Vector2(24, 24), 0, ModContent.WallType<AbyssalStoneWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<AbyssalStone>().AddTile(TileID.WorkBenches).Register();
}

class AbyssalStoneWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "AbyssalStoneWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.Cobalt, SoundID.Tink, false, new Color(34, 45, 69));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}