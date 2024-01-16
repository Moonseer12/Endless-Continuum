using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class AbyssalStoneWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "AbyssalStoneWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<AbyssalStoneWallTile>());
			Item.Size = new Vector2(24, 24);
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Green;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<AbyssalStone>().AddTile(TileID.WorkBenches).Register();
	}

	class AbyssalStoneWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "AbyssalStoneWallTile";
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;
			AddMapEntry(new Color(34, 45, 69));
		}
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}