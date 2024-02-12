using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AeriumOre : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "AeriumOre";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Pink, new Vector2(16, 16), 0, ModContent.TileType<AeriumOreTile>());
}

class AeriumOreTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "AeriumOreTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickOreTile(this, DustID.GemAmber, SoundID.Tink, 5f, 200, 410, new Color(204, 159, 22));
        QuickTile.QuickTileMerge(this, ModContent.TileType<MyrdendirtTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<MyrdenstoneTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<MyrdenwoodTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<SurgestoneOreTile>());
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}