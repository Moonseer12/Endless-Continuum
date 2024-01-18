using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
    class AeriumOre : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "AeriumOre";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AeriumOreTile>(), 0);
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Pink;
        }
    }

    class AeriumOreTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "AeriumOreTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 410;
            //Main.tileLighted[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<MyrdendirtTile>()] = true;
            Main.tileMerge[Type][ModContent.TileType<MyrdenstoneTile>()] = true;
            Main.tileMerge[Type][ModContent.TileType<MyrdenwoodTile>()] = true;
            Main.tileMerge[Type][ModContent.TileType<SurgestoneOreTile>()] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.Ore[Type] = true;
            HitSound = SoundID.Tink;
            MinPick = 200;
            MineResist = 3f;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(204, 159, 22), name);
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
        /*public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 1.82f;
            g = 1.17f;
            b = 0.10f;
        }*/
    }
}