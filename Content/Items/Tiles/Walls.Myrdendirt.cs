using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class MyrdendirtWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "MyrdendirtWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<MyrdendirtWallTile>());
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Pink;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<Myrdendirt>().AddTile(TileID.WorkBenches).Register();
	}

	class MyrdendirtWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "MyrdendirtWallTile";
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;
			AddMapEntry(new Color(51, 43, 25));
		}
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}