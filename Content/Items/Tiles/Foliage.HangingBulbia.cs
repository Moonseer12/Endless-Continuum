using EndlessContinuum.Common.Utilities;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class HangingBulbia : ModTile
{
    public override string Texture => ECAssets.TilesPath + "HangingBulbia";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickFoliageHangingTile(this, DustID.IceTorch, SoundID.Grass, false, 2, 2, new int[] { 16, 16 }, 1, ModContent.TileType<AbyssalStoneTile>(), new Point16(1, 1));
        Main.tileLighted[Type] = true;
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = .57f;
        g = .98f;
        b = 1.73f;
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}