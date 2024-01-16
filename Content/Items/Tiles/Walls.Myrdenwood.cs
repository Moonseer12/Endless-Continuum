using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class MyrdenwoodWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "MyrdenwoodWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<MyrdenwoodWallTile>());
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Pink;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<Myrdenwood>().AddTile(TileID.WorkBenches).Register();
	}

	class MyrdenwoodWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "MyrdenwoodWallTile";
		public override void SetStaticDefaults() => AddMapEntry(new Color(51, 43, 25));
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}