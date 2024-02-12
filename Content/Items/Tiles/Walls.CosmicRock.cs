using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class CosmicRockWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "CosmicRockWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Cyan, new Vector2(24, 24), 0, ModContent.WallType<CosmicRockWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<CosmicRock>().AddTile(TileID.WorkBenches).Register();
}

class CosmicRockWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "CosmicRockWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.Ice_Purple, SoundID.Tink, false, new Color(68, 47, 84));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}