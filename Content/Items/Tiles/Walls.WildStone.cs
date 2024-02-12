using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class WildStoneWall : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "WildStoneWall";
	public override void SetDefaults() => QuickItem.QuickWallItem(this, ItemRarityID.Blue, new Vector2(24, 24), 0, ModContent.WallType<WildStoneWallTile>());
	public override void AddRecipes() => CreateRecipe(4).AddIngredient<WildStone>().AddTile(TileID.WorkBenches).Register();
}

class WildStoneWallTile : ModWall
{
	public override string Texture => ECAssets.TilesPath + "WildStoneWallTile";
	public override void SetStaticDefaults() => QuickTile.QuickWallTile(this, DustID.Poisoned, SoundID.Tink, false, new Color(59, 79, 53));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}