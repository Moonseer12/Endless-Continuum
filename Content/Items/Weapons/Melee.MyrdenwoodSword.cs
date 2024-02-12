using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Weapons;

class MyrdenwoodSword : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenwoodSword";
    public override void SetDefaults() => QuickItem.QuickSwordItem(this, ItemRarityID.Pink, new Vector2(32, 32), Item.sellPrice(0, 0, 0, 20), 45, 12, 7);
    public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.Myrdenwood>(7).AddTile(TileID.WorkBenches).Register();
}