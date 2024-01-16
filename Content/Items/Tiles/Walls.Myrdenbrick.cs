using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class MyrdenbrickWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "MyrdenbrickWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<MyrdenbrickWallTile>());
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Pink;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<Myrdenbrick>().AddTile(TileID.WorkBenches).Register();
	}

	class MyrdenbrickWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "MyrdenbrickWallTile";
		public override void SetStaticDefaults() => AddMapEntry(new Color(112, 41, 15));
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}