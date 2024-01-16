using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EndlessContinuum.Content.Items.Tiles
{
    class AbyssalStalagmites : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "AbyssalStalagmites";
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.DrawYOffset = -4;
            TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<AbyssalStoneTile>() };
            TileObjectData.addTile(Type);
            DustType = DustID.Ash;
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if ((i % 4) < 5)
                spriteEffects = SpriteEffects.FlipHorizontally;
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) => frameXOffset = i % 5 * 18;
    }
}