using EndlessContinuum.Common.Utilities;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenTallGrass : ModTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdenTallGrass";
    public override void SetStaticDefaults() => QuickTile.QuickGrassTallTile(this, DustID.t_Honey, ModContent.TileType<MyrdengrassTile>(), 4);
    public override void NumDust(int i, int j, bool fail, ref int num) => num = 10;
    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        if (Main.rand.NextBool(50))
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<MyrdengrassSeeds>());
    }
    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY) => offsetY = 2;
}