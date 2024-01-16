using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class WildDirt : ModItem
	{
        public override string Texture => ECAssets.ItemsPath + "WildDirt";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<WildDirtTile>(), 0);
            Item.Size = new Vector2(16, 16);
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<WildDirtWall>(4).Register();
    }

    class WildDirtTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "WildDirtTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<WildStoneTile>()] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(30, 56, 35));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}