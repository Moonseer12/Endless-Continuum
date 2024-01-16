using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class AbyssalDirtWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "AbyssalDirtWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<AbyssalDirtWallTile>());
			Item.Size = new Vector2(24, 24);
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Green;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<AbyssalDirt>().AddTile(TileID.WorkBenches).Register();
	}

	class AbyssalDirtWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "AbyssalDirtWallTile";
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;
			AddMapEntry(new Color(23, 28, 51));
		}
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}