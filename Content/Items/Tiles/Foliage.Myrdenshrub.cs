using EndlessContinuum.Common.Utilities;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class Myrdenshrub : ModTile
{
    public override string Texture => ECAssets.TilesPath + "Myrdenshrub";
    public override void SetStaticDefaults() => QuickTile.QuickFoliageTile(this, DustID.t_Honey, SoundID.Grass, false, 2, 2, new int[] { 16, 16 }, true, 4, ModContent.TileType<MyrdengrassTile>(), new Point16(1, 1));
    public override void NumDust(int i, int j, bool fail, ref int num) => num = 10;
    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        if (Main.rand.NextBool(50))
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<MyrdengrassSeeds>());
    }
    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY) => offsetY = 2;
}