using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Misc;

class AbyssalMinesPylonCrystal : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "AbyssalMinesPylonCrystal";
	public override void SetStaticDefaults() => this.SetResearch();
	public override void SetDefaults()
	{
		Item.Size = new Vector2(20, 30);
		Item.rare = ItemRarityID.Green;
	}
}

public class AbyssalMinesPylonCrystalDrop : GlobalNPC
{
	public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
	{
		if (npc.type == NPCID.EaterofWorldsHead)
		{
			LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<AbyssalMinesPylonCrystal>()));
			npcLoot.Add(notExpertRule);
		}
		if (npc.type == NPCID.BrainofCthulhu)
		{
			LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<AbyssalMinesPylonCrystal>()));
			npcLoot.Add(notExpertRule);
		}
	}
}

public class AbyssalMinesPylonCrystalDropBag : GlobalItem
{
	public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
	{
		if (item.type == ItemID.EaterOfWorldsBossBag)
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AbyssalMinesPylonCrystal>()));
		if (item.type == ItemID.BrainOfCthulhuBossBag)
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<AbyssalMinesPylonCrystal>()));
	}
}