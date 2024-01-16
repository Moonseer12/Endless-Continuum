using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class CosmicSoil : ModItem
	{
        public override string Texture => ECAssets.ItemsPath + "CosmicSoil";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<CosmicSoilTile>(), 0);
            Item.Size = new Vector2(16, 16);
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Cyan;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<CosmicSoilWall>(4).Register();
    }

    class CosmicSoilTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "CosmicSoilTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<CosmicRockTile>()] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(74, 56, 102));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}