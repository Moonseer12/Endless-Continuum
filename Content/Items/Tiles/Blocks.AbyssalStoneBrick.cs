using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class AbyssalStoneBrick : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "AbyssalStoneBrick";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AbyssalStoneBrickTile>(), 0);
            Item.Size = new Vector2(16, 16);
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Green;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<AbyssalStoneBrickWall>(4).Register();
    }

    class AbyssalStoneBrickTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "AbyssalStoneBrickTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(103, 137, 171));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}