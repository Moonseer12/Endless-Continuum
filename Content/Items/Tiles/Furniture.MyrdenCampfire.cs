using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenCampfire : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenCampfire";
    public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(30, 20), Item.sellPrice(0, 0, 30, 0), ModContent.TileType<MyrdenCampfireTile>());
	public override void AddRecipes() => CreateRecipe().AddRecipeGroup(RecipeGroupID.Wood, 10).AddIngredient<MyrdenTorch>(5).AddTile(TileID.WorkBenches).Register();
}

class MyrdenCampfireTile : QuickCampfireTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdenCampfireTile";
}