using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class MyrdenstoneBrickWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "MyrdenstoneBrickWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<MyrdenstoneBrickWallTile>());
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Pink;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<MyrdenstoneBrick>().AddTile(TileID.WorkBenches).Register();
	}

	class MyrdenstoneBrickWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "MyrdenstoneBrickWallTile";
		public override void SetStaticDefaults() => AddMapEntry(new Color(51, 43, 25));
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}