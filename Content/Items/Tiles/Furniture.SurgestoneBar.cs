using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EndlessContinuum.Content.Items.Tiles
{
    class SurgestoneBar : ModItem
    {
        public override string Texture => ECAssets.ItemsPath + "SurgestoneBar";
        public override void SetStaticDefaults() => this.SetResearchBlock();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<SurgestoneBarTile>(), 0);
            Item.Size = new Vector2(30, 24);
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 0, 80, 0);
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<SurgestoneOre>(3).AddTile(TileID.AdamantiteForge).Register();
    }

    class SurgestoneBarTile : ModTile
    {
        public override string Texture => ECAssets.TilesPath + "SurgestoneBarTile";
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