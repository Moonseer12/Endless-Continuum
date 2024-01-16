using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class ArchaicStoneBrick : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "ArchaicStoneBrick";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<ArchaicStoneBrickTile>(), 0);
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<ArchaicStoneBrickWall>(4).Register();
    }

    class ArchaicStoneBrickTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "ArchaicStoneBrickTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<ArchaicStoneTile>()] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(112, 86, 75));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}