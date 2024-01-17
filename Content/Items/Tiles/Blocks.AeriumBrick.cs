using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class AeriumBrick : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "AeriumBrick";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AeriumBrickTile>(), 0);
            Item.Size = new Vector2(16, 16);
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Pink;
        }
        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient<Myrdenstone>(5).AddIngredient<AeriumOre>().Register();
            CreateRecipe().AddIngredient<AeriumBrickWall>(4).Register();
        }
    }

    class AeriumBrickTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "AeriumBrickTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(222, 186, 24));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}