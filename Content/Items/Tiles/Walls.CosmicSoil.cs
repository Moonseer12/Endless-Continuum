using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class CosmicSoilWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "CosmicSoilWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Cyan, new Vector2(24, 24), 0, ModContent.WallType<CosmicSoilWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<CosmicSoil>().AddTile(TileID.WorkBenches).Register();
}

class CosmicSoilWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "CosmicSoilWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.Ice_Purple, SoundID.Dig, false, new Color(52, 39, 71));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}