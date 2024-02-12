using EndlessContinuum.Common.Utilities;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class WildGrass : ModTile
{
    public override string Texture => ECAssets.TilesPath + "WildGrass";
    public override void SetStaticDefaults() => QuickTile.QuickGrassShortTile(this, DustID.Plantera_Green, ModContent.TileType<WildGrassTile>(), 5);
    public override void NumDust(int i, int j, bool fail, ref int num) => num = 10;
    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        if (Main.rand.NextBool(100))
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<WildGrassSeeds>());
    }
    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY) => offsetY = 2;
}