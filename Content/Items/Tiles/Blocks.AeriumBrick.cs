using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AeriumBrick : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "AeriumBrick";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Pink, new Vector2(16, 16), 0, ModContent.TileType<AeriumBrickTile>());
    public override void AddRecipes()
    {
        CreateRecipe().AddIngredient<Myrdenstone>(5).AddIngredient<AeriumOre>().Register();
        CreateRecipe().AddIngredient<AeriumBrickWall>(4).Register();
    }
}

class AeriumBrickTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "AeriumBrickTile";
    public override void SetStaticDefaults() => QuickTile.QuickBlockTile(this, DustID.GemAmber, SoundID.Tink, 1f, 0, new Color(222, 186, 24));
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}