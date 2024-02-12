using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class SurgestonePlating : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "SurgestonePlating";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Pink, new Vector2(16, 16), 0, ModContent.TileType<SurgestonePlatingTile>());
    public override void AddRecipes()
    {
        CreateRecipe().AddIngredient<Myrdenstone>(5).AddIngredient<SurgestoneOre>().Register();
        CreateRecipe().AddIngredient<SurgestonePlatingWall>(4).Register();
    }
}

class SurgestonePlatingTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "SurgestonePlatingTile";
    public override void SetStaticDefaults() => QuickTile.QuickBlockTile(this, DustID.CursedTorch, SoundID.Tink, 1f, 0, new Color(132, 235, 84));
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}