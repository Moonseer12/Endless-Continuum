using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AbyssalBeam : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "AbyssalBeam";
    public override void SetDefaults() => QuickItem.QuickBeamItem(this, ItemRarityID.Green, new Vector2(16, 18), 0, ModContent.TileType<AbyssalBeamTile>());
    public override void AddRecipes() => CreateRecipe(2).AddIngredient<AbyssalStoneBrick>().AddTile(TileID.Sawmill).Register();
}

class AbyssalBeamTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "AbyssalBeamTile";
    public override void SetStaticDefaults() => QuickTile.QuickBeamTile(this, DustID.Cobalt, SoundID.Dig, new Color(103, 137, 171));
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}