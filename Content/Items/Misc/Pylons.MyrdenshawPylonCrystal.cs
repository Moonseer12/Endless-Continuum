using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Misc;

class MyrdenshawPylonCrystal : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenshawPylonCrystal";
    public override void SetDefaults() => QuickItem.QuickMiscItem(this, ItemRarityID.Pink, new Vector2(20, 30), Item.sellPrice(0, 1, 0, 0));
    public override void AddRecipes() => CreateRecipe().AddIngredient(ItemID.HallowedBar, 5).AddTile(TileID.MythrilAnvil).Register();
}