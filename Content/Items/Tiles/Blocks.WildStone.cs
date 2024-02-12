using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class WildStone : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "WildStone";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Blue, new Vector2(16, 16), 0, ModContent.TileType<WildStoneTile>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<WildStoneWall>(4).Register();
}

class WildStoneTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "WildStoneTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickBlockTile(this, DustID.Poisoned, SoundID.Tink, 3f, 55, new Color(76, 102, 68));
        QuickTile.QuickTileMerge(this, ModContent.TileType<WildDirtTile>());
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}