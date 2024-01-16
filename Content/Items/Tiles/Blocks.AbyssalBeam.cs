using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class AbyssalBeam : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "AbyssalBeam";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AbyssalBeamTile>(), 0);
            Item.Size = new Vector2(16, 18);
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Green;
        }
    }

    class AbyssalBeamTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "AbyssalBeamTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.IsBeam[Type] = true;
            AddMapEntry(new Color(103, 137, 171));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}