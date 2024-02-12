using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Armor;

[AutoloadEquip(EquipType.Head)]
class AeriumMask : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "AeriumMask";
	public override void SetDefaults() => QuickItem.QuickArmorItem(this, ItemRarityID.Pink, new Vector2(20, 20), Item.sellPrice(0, 3, 0, 0), 13);
	public override void UpdateEquip(Player player)
	{
		player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
		player.maxMinions += 1;
	}
	public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<AeriumBreastplate>() && legs.type == ModContent.ItemType<AeriumLeggings>();
	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = Language.GetTextValue("Mods.EndlessContinuum.ArmorSetBonus." + Name);
		if (!player.GetModPlayer<AeriumArmorPlayer>().HasAeriumBuff)
			player.AddBuff(ModContent.BuffType<AeriumArmorMelee>(), 3600);
	}
	public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.AeriumBar>(15).AddIngredient<Materials.MyrdenshellShards>(10).AddTile<Tiles.SoulForgeTile>().Register();
}

[AutoloadEquip(EquipType.Body)]
class AeriumBreastplate : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "AeriumBreastplate";
	public override void SetDefaults() => QuickItem.QuickArmorItem(this, ItemRarityID.Pink, new Vector2(26, 18), Item.sellPrice(0, 5, 0, 0), 16);
	public override void UpdateEquip(Player player)
	{
		player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
		player.maxMinions += 1;
	}
	public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.AeriumBar>(20).AddIngredient<Materials.MyrdenshellShards>(10).AddTile<Tiles.SoulForgeTile>().Register();
}

[AutoloadEquip(EquipType.Legs)]
class AeriumLeggings : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "AeriumLeggings";
	public override void SetDefaults() => QuickItem.QuickArmorItem(this, ItemRarityID.Pink, new Vector2(22, 16), Item.sellPrice(0, 2, 0, 0), 12);
	public override void UpdateEquip(Player player)
	{
		player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
		player.maxMinions += 1;
	}
	public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.AeriumBar>(15).AddIngredient<Materials.MyrdenshellShards>(10).AddTile<Tiles.SoulForgeTile>().Register();
}

class AeriumArmorMelee : ModBuff
{
	public override string Texture => ECAssets.BuffsPath + "AeriumArmorMelee";
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
		BuffID.Sets.LongerExpertDebuff[Type] = false;
		BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
	}
	public override void Update(Player player, ref int buffIndex)
	{
		player.GetModPlayer<AeriumArmorPlayer>().HasAeriumBuff = true;
		player.GetDamage(DamageClass.Melee) += 0.20f;
		player.GetDamage(DamageClass.Summon) -= 20f;
		if (player.buffTime[buffIndex] == 0)
			player.AddBuff(ModContent.BuffType<AeriumArmorSummon>(), 3600);
	}
}

class AeriumArmorSummon : ModBuff
{
	public override string Texture => ECAssets.BuffsPath + "AeriumArmorSummon";
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
		BuffID.Sets.LongerExpertDebuff[Type] = false;
		BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
	}
	public override void Update(Player player, ref int buffIndex)
	{
		player.GetModPlayer<AeriumArmorPlayer>().HasAeriumBuff = true;
		player.GetDamage(DamageClass.Melee) -= 20f;
		player.GetDamage(DamageClass.Summon) += 0.20f;
		if (player.buffTime[buffIndex] == 0)
			player.AddBuff(ModContent.BuffType<AeriumArmorMelee>(), 3600);
	}
}

class AeriumArmorPlayer : ModPlayer
{
	public bool HasAeriumBuff;
	public override void ResetEffects() => HasAeriumBuff = false;
}