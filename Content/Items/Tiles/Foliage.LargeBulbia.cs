using EndlessContinuum.Common.Utilities;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class LargeBulbia : ModTile
{
    public override string Texture => ECAssets.TilesPath + "LargeBulbia";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickFoliageTile(this, DustID.IceTorch, SoundID.Grass, false, 3, 4, new int[] { 16, 16, 16, 16 }, true, 1, ModContent.TileType<AbyssalGrassTile>(), new Point16(1, 3));
        Main.tileLighted[Type] = true;
    }
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = .57f;
        g = .98f;
        b = 1.73f;
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = 10;
    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        if (Main.rand.NextBool(50))
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<AbyssalGrassSeeds>());
    }
    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY) => offsetY = 2;
}