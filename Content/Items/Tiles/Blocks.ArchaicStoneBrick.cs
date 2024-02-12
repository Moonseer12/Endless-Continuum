using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class ArchaicStoneBrick : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "ArchaicStoneBrick";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Purple, new Vector2(16, 16), 0, ModContent.TileType<ArchaicStoneBrickTile>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<ArchaicStoneBrickWall>(4).Register();
}

class ArchaicStoneBrickTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "ArchaicStoneBrickTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickBlockTile(this, DustID.DynastyWood, SoundID.Tink, 10f, 300, new Color(112, 86, 75));
        QuickTile.QuickTileMerge(this, ModContent.TileType<ArchaicStoneTile>());
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}