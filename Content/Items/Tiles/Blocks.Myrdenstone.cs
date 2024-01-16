using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class Myrdenstone : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "Myrdenstone";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<MyrdenstoneTile>(), 0);
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Pink;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<MyrdenstoneWall>(4).Register();
    }

    class MyrdenstoneTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "MyrdenstoneTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<MyrdendirtTile>()] = true;
            Main.tileMerge[Type][ModContent.TileType<MyrdenwoodTile>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AeriumOreTile>()] = true;
            Main.tileMerge[Type][ModContent.TileType<SurgestoneOreTile>()] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(112, 96, 55));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}