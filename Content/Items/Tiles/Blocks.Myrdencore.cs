using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class Myrdencore : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "Myrdencore";
    public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Pink, new Vector2(16, 16), 0, ModContent.TileType<MyrdencoreTile>());
    public override void AddRecipes() => CreateRecipe(10).AddIngredient<Materials.Lightspores>().AddTile(TileID.HeavyWorkBench).Register();
}

class MyrdencoreTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdencoreTile";
    public override void SetStaticDefaults()
    {
        QuickTile.QuickBlockTile(this, DustID.SandstormInABottle, SoundID.Dig, 1f, 0, new Color(227, 223, 202));
        Main.tileLighted[Type] = true;
        Main.tileShine2[Type] = true;
        TileID.Sets.GemsparkFramingTypes[Type] = Type;
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0;
        g = 0;
        b = 0;
    }
}