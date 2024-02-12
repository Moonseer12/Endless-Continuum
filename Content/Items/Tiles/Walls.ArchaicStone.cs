using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class ArchaicStoneWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "ArchaicStoneBrickWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Purple, new Vector2(24, 24), 0, ModContent.WallType<ArchaicStoneWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<ArchaicStone>().AddTile(TileID.WorkBenches).Register();
}

class ArchaicStoneWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "ArchaicStoneBrickWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.DynastyWood, SoundID.Tink, false, new Color(54, 37, 34));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}