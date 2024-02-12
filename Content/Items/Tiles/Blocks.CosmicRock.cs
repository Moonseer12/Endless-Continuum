using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class CosmicRock : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "CosmicRock";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Cyan, new Vector2(16, 16), 0, ModContent.TileType<CosmicRockTile>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<CosmicRockWall>(4).Register();
}

class CosmicRockTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "CosmicRockTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickBlockTile(this, DustID.Ice_Purple, SoundID.Tink, 7f, 210, new Color(95, 65, 117));
        QuickTile.QuickTileMerge(this, ModContent.TileType<CosmicSoilTile>());
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}