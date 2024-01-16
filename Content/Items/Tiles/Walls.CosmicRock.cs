using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class CosmicRockWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "CosmicRockWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<CosmicRockWallTile>());
			Item.Size = new Vector2(24, 24);
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Cyan;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<CosmicRock>().AddTile(TileID.WorkBenches).Register();
	}

	class CosmicRockWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "CosmicRockWallTile";
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;
			AddMapEntry(new Color(68, 47, 84));
		}
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}