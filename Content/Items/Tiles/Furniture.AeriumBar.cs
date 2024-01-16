using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EndlessContinuum.Content.Items.Tiles
{
    class AeriumBar : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "AeriumBar";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AeriumBarTile>(), 0);
            Item.width = 46;
            Item.height = 42;
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 0, 80, 0);
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<AeriumOre>(3).AddTile(TileID.AdamantiteForge).Register();
    }

    class AeriumBarTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "AeriumBarTile";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.IgnoredByNpcStepUp[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { TileID.MetalBars };
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.MetalBar"));
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}