using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class AbyssalStone : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "AbyssalStone";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AbyssalStoneTile>(), 0);
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Orange;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<AbyssalStoneWall>(4).Register();
    }

    class AbyssalStoneTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "AbyssalStoneTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<AbyssalDirtTile>()] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(50, 66, 102));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}