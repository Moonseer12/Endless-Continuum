using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class AbyssalDirt : ModItem
	{
        public override string Texture => ECAssets.ItemsPath + "AbyssalDirt";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AbyssalDirtTile>(), 0);
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Orange;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<AbyssalDirtWall>(4).Register();
    }

    class AbyssalDirtTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "AbyssalDirtTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<AbyssalStoneTile>()] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(34, 41, 77));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}