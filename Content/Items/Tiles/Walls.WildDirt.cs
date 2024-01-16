using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class WildDirtWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "WildDirtWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<WildDirtWallTile>());
			Item.Size = new Vector2(24, 24);
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<WildDirt>().AddTile(TileID.WorkBenches).Register();
	}

	class WildDirtWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "WildDirtWallTile";
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;
			AddMapEntry(new Color(22, 41, 25));
		}
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}