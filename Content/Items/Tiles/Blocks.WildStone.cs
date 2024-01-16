using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class WildStone : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "WildStone";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<WildStoneTile>(), 0);
            Item.Size = new Vector2(16, 16);
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<WildStoneWall>(4).Register();
    }

    class WildStoneTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "WildStoneTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<WildDirtTile>()] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(76, 102, 68));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}