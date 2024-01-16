using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class Myrdenwood : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "Myrdenwood";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<MyrdenwoodTile>(), 0);
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Pink;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<MyrdenwoodWall>(4).Register();
    }

    class MyrdenwoodTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "MyrdenwoodTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<MyrdendirtTile>()] = true;
            Main.tileMerge[Type][ModContent.TileType<MyrdenstoneTile>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AeriumOreTile>()] = true;
            Main.tileMerge[Type][ModContent.TileType<SurgestoneOreTile>()] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(82, 70, 40));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}