using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.NPCs.Enemies
{
    class Myrdenflyer : ModNPC
    {
        public override string Texture => ECAssets.NPCsPath + "Myrdenflyer";
		public override void SetStaticDefaults() => Main.npcFrameCount[NPC.type] = 6;
		public override void SetDefaults()
		{
			NPC.width = 66;
			NPC.height = 30;
			NPC.npcSlots = 1;
			NPC.aiStyle = 14;
			NPC.lifeMax = 550;
			NPC.damage = 70;
			NPC.defense = 6;
			NPC.knockBackResist = 0.65f;
			NPC.value = Item.sellPrice(0, 0, 5, 0);
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath4;
			AnimationType = -1;
			//Banner = NPC.type;
			//BannerItem = ModContent.ItemType<Items.Tiles.MyrdenflyerBanner>();
			SpawnModBiomes = new int[1] { ModContent.GetInstance<Biomes.MyrdenshawBiome>().Type };
		}
		//public override float SpawnChance(NPCSpawnInfo spawnInfo) => spawnInfo.Player.GetModPlayer<Biomes.MyrdenshawPlayer>().ZoneMyrdenshaw ? 0.2f : 0f;
		/*public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
		{
			NPC.lifeMax = Main.masterMode ? 850 : 700;
			NPC.damage = Main.masterMode ? 130 : 100;
		}*/
		public override void FindFrame(int frameHeight)
		{
			NPC.spriteDirection = NPC.direction;
			NPC.frameCounter++;
			if (NPC.frameCounter >= 4)
			{
				NPC.frame.Y += frameHeight;
				NPC.frameCounter = 0;
				if (NPC.frame.Y > frameHeight * 5)
				{
					NPC.frame.Y = 0;
				}
			}
		}
		public override void HitEffect(NPC.HitInfo hit)
		{
			for (int k = 0; k < 6; k++)
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SandstormInABottle, hit.HitDirection, -1f, 0, default, 1f);
			if (NPC.life <= 0)
			{
				for (int k = 0; k < 22; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SandstormInABottle, hit.HitDirection, -1f, 0, default, 1f);
			}
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Myrdenfibers>(), 1, 1, 3));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Lightspores>(), 5));
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) => bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] { new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.EndlessContinuum.Bestiary.Myrdenflyer")), });
	}
}