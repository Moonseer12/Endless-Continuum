using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class AbyssalStoneSlabWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "AbyssalStoneSlabWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<AbyssalStoneSlabWallTile>());
			Item.Size = new Vector2(24, 24);
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Green;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<AbyssalStoneSlab>().AddTile(TileID.WorkBenches).Register();
	}

	class AbyssalStoneSlabWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "AbyssalStoneSlabWallTile";
		public override void SetStaticDefaults() => AddMapEntry(new Color(23, 28, 51));
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}