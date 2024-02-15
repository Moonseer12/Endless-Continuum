using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.NPCs.Enemies;

class Myrdenflyer : ModNPC
{
	public override string Texture => ECAssets.NPCsPath + "Myrdenflyer";
	public override void SetStaticDefaults() => Main.npcFrameCount[NPC.type] = 6;
	public override void SetDefaults()
	{
		QuickNPC.QuickEnemyNPC(this, new Vector2(66, 30), 550, 70, 6, .65f, SoundID.NPCHit1, SoundID.NPCDeath4, 14, 1, true, Item.sellPrice(0, 0, 5, 0));
		Banner = NPC.type;
		BannerItem = ModContent.ItemType<Items.Tiles.MyrdenflyerBanner>();
		SpawnModBiomes = new int[1] { ModContent.GetInstance<Biomes.MyrdenshawBiome>().Type };
	}
	/*public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
	{
		NPC.lifeMax = Main.masterMode ? 850 : 700;
		NPC.damage = Main.masterMode ? 130 : 100;
	}*/
	public override void FindFrame(int frameHeight)
	{
		NPC.spriteDirection = NPC.direction;
		NPC.frameCounter += .5;
		NPC.frameCounter %= Main.npcFrameCount[NPC.type];
		NPC.frame.Y = (int)NPC.frameCounter * frameHeight;
	}
	public override void HitEffect(NPC.HitInfo hit)
	{
		for (int k = 0; k < 6; k++)
			Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SandstormInABottle, hit.HitDirection, -1f, 0, default, 1f);
		if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
			for (int k = 0; k < 22; k++)
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SandstormInABottle, hit.HitDirection, -1f, 0, default, 1f);
	}
	public override void ModifyNPCLoot(NPCLoot npcLoot)
	{
		npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Myrdenfibers>(), 1, 1, 3));
		npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Lightspores>(), 5));
	}
	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) => bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] { new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.EndlessContinuum.Bestiary.Myrdenflyer")), });
}