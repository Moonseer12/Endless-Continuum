using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class WildStoneWall : ModItem
	{
		public override string Texture => ECAssets.ItemsPath + "WildStoneWall";
		public override void SetStaticDefaults() => this.SetResearchWall();
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableWall((ushort)ModContent.WallType<WildStoneWallTile>());
			Item.Size = new Vector2(24, 24);
			Item.maxStack = Item.CommonMaxStack;
			Item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes() => CreateRecipe(4).AddIngredient<WildStone>().AddTile(TileID.WorkBenches).Register();
	}

	class WildStoneWallTile : ModWall
	{
		public override string Texture => ECAssets.TilesPath + "WildStoneWallTile";
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;
			AddMapEntry(new Color(59, 79, 53));
		}
		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	}
}