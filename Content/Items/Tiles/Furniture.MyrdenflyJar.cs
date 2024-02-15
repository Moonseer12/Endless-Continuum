using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenflyJar : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenflyJar";
    public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(32, 32), Item.sellPrice(0, 0, 6, 0), ModContent.TileType<MyrdenflyJarTile>());
    public override void AddRecipes() => CreateRecipe().AddIngredient<Critters.MyrdenflyItem>().AddIngredient(ItemID.Bottle).AddTile(TileID.WorkBenches).Register();
}

class MyrdenflyJarTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdenflyJarTile";
    public override void SetStaticDefaults() => QuickTile.QuickCritterJarTile(this);
    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter >= 6)
        {
            frameCounter = 0;
            frame++;
            frame %= 4;
        }
    }
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}