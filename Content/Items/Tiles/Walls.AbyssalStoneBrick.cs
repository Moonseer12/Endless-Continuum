using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class AbyssalStoneBrickWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "AbyssalStoneBrickWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<AbyssalStoneBrickWallTile>());
			Item.Size = new Vector2(24, 24);
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Green;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<AbyssalStoneBrick>().AddTile(TileID.WorkBenches).Register();
	}

	class AbyssalStoneBrickWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "AbyssalStoneBrickWallTile";
		public override void SetStaticDefaults() => AddMapEntry(new Color(209, 40, 43));
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}