using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class ArchaicStone : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "ArchaicStone";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<ArchaicStoneTile>(), 0);
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
        }
        //public override void AddRecipes() => CreateRecipe().AddIngredient<ArchaicStoneWall>(4).Register();
    }

    class ArchaicStoneTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "ArchaicStoneTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<ArchaicStoneBrickTile>()] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(82, 56, 52));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}