using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EndlessContinuum.Content.Items.Tiles
{
    class SoulForge : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "SoulForge";
        public override void SetStaticDefaults() => this.SetResearch();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<SoulForgeTile>(), 0);
            Item.width = 48;
            Item.height = 48;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(0, 25, 0, 0);
        }
    }

    class SoulForgeTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "SoulForgeTile";
        public override void SetStaticDefaults()
        {
            MineResist = 2f;
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(212, 184, 102), name);
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0f;
            b = 1f;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY) => Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<SoulForge>());
    }
}