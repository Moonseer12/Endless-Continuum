using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles
{
	class Myrdencore : ModItem
	{
        public override string Texture => ECAssets.ItemsPath + "Myrdencore";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<MyrdencoreTile>(), 0);
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Pink;
        }
    }

    class MyrdencoreTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "MyrdencoreTile";
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileSolid[Type] = true;
            TileID.Sets.GemsparkFramingTypes[Type] = Type;
            AddMapEntry(new Color(227, 223, 202));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0;
            g = 0;
            b = 0;
        }
    }
}