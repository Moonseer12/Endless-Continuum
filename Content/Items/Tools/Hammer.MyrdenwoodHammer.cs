using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tools;

class MyrdenwoodHammer : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenwoodHammer";
    public override void SetDefaults() => QuickItem.QuickHammerItem(this, ItemRarityID.Pink, new Vector2(40, 40), Item.sellPrice(0, 0, 0, 10), 12, 60, 29, 5.5f);
    public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.Myrdenwood>(8).AddTile(TileID.WorkBenches).Register();
}