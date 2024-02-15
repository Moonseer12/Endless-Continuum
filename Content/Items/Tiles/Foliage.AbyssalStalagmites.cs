using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class AbyssalStalagmites : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "AbyssalStalagmites";
        public override void SetStaticDefaults() => QuickTile.QuickStalagmiteTile(this, DustID.Cobalt, ModContent.TileType<AbyssalStoneTile>());
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if ((i % 4) < 5)
                spriteEffects = SpriteEffects.FlipHorizontally;
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) => frameXOffset = i % 5 * 18;
    }
}