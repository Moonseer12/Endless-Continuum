using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class SurgestoneOre : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "SurgestoneOre";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Pink, new Vector2(16, 16), 0, ModContent.TileType<SurgestoneOreTile>());
}

class SurgestoneOreTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "SurgestoneOreTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickOreTile(this, DustID.CursedTorch, SoundID.Tink, 5f, 200, 410, new Color(69, 196, 162));
        //Main.tileLighted[Type] = true;
        QuickTile.QuickTileMerge(this, ModContent.TileType<MyrdendirtTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<MyrdenstoneTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<MyrdenwoodTile>());
        QuickTile.QuickTileMerge(this, ModContent.TileType<AeriumOreTile>());
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    /*public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.50f;
        g = 0.98f;
        b = 0.64f;
    }*/
}