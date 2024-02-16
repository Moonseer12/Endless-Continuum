using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class MyrdenwoodHelmet : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodHelmet";
	public override void SetDefaults() => QuickItem.QuickArmorItem(this, ItemRarityID.Pink, new Vector2(22, 20), 0, 2);
	public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<AeriumBreastplate>() && legs.type == ModContent.ItemType<AeriumLeggings>();
	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = Language.GetTextValue("Mods.EndlessContinuum.ArmorSetBonus." + Name);
		player.statDefense += 1;
	}
	public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.Myrdenwood>(20).AddTile(TileID.WorkBenches).Register();
}

[AutoloadEquip(EquipType.Body)]
class MyrdenwoodBreastplate : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodBreastplate";
	public override void SetDefaults() => QuickItem.QuickArmorItem(this, ItemRarityID.Pink, new Vector2(30, 20), 0, 3);
	public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.Myrdenwood>(30).AddTile(TileID.WorkBenches).Register();
}

[AutoloadEquip(EquipType.Legs)]
class MyrdenwoodGreaves : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodGreaves";
	public override void SetDefaults() => QuickItem.QuickArmorItem(this, ItemRarityID.Pink, new Vector2(22, 18), 0, 2);
	public override void UpdateEquip(Player player)
	{
		player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
		player.maxMinions += 1;
	}
	public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.Myrdenwood>(25).AddTile(TileID.WorkBenches).Register();
}