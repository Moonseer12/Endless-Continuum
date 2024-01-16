using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class ArchaicStoneBrickWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "ArchaicStoneBrickWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<ArchaicStoneBrickWallTile>());
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = Item.CommonMaxStack;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<ArchaicStoneBrick>().AddTile(TileID.WorkBenches).Register();
	}

	class ArchaicStoneBrickWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "ArchaicStoneBrickWallTile";
		public override void SetStaticDefaults() => AddMapEntry(new Color(54, 37, 34));
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}