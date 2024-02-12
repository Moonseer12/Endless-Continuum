using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Weapons;

class MyrdenwoodBow : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenwoodBow";
    public override void SetDefaults() => QuickItem.QuickBowItem(this, ItemRarityID.Pink, new Vector2(16, 36), Item.sellPrice(0, 0, 0, 20), 30, 15, 0, 7);
    public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.Myrdenwood>(10).AddTile(TileID.WorkBenches).Register();
}