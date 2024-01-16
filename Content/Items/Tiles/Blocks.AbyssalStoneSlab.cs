using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class AbyssalStoneSlab : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "AbyssalStoneSlab";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AbyssalStoneSlabTile>(), 0);
            Item.Size = new Vector2(16, 16);
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Green;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<AbyssalStoneSlabWall>(4).Register();
    }

    class AbyssalStoneSlabTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "AbyssalStoneSlabTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(34, 41, 77));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}