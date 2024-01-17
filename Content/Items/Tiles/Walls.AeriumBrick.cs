using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class AeriumBrickWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "AeriumBrickWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<AeriumBrickWallTile>());
			Item.Size = new Vector2(24, 24);
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Pink;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<AeriumBrick>().AddTile(TileID.WorkBenches).Register();
	}

	class AeriumBrickWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "AeriumBrickWallTile";
		public override void SetStaticDefaults() => AddMapEntry(new Color(156, 130, 17));
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}