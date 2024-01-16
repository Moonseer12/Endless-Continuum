using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class CosmicSoilWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "CosmicSoilWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<CosmicSoilWallTile>());
			Item.Size = new Vector2(24, 24);
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<CosmicSoil>().AddTile(TileID.WorkBenches).Register();
	}

	class CosmicSoilWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "CosmicSoilWallTile";
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;
			AddMapEntry(new Color(52, 39, 71));
		}
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}