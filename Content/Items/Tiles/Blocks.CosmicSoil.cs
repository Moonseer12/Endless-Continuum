using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class CosmicSoil : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "CosmicSoil";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Cyan, new Vector2(16, 16), 0, ModContent.TileType<CosmicSoilTile>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<CosmicSoilWall>(4).Register();
}

class CosmicSoilTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "CosmicSoilTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickBlockTile(this, DustID.Ice_Purple, SoundID.Dig, 1f, 0, new Color(74, 56, 102));
        QuickTile.QuickTileMerge(this, ModContent.TileType<CosmicRockTile>());
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}