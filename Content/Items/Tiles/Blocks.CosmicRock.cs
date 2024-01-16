using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class CosmicRock : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "CosmicRock";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<CosmicRockTile>(), 0);
            Item.Size = new Vector2(16, 16);
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Cyan;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<CosmicRockWall>(4).Register();
    }

    class CosmicRockTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "CosmicRockTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<CosmicSoilTile>()] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(95, 65, 117));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}