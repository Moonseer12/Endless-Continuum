using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.NPCs.Critters;

class Myrdenfly : ModNPC
{
	public override string Texture => ECAssets.NPCsPath + "Myrdenfly";
	public override void SetStaticDefaults()
	{
		Main.npcFrameCount[NPC.type] = 4;
		Main.npcCatchable[NPC.type] = true;
		NPCID.Sets.CountsAsCritter[Type] = true;
	}
	public override void SetDefaults()
	{
		QuickNPC.QuickCritterNPC(this, new Vector2(28, 14), 5, 0, 0, .45f, SoundID.NPCHit1, SoundID.NPCDeath1, 64, 0, true, ModContent.ItemType<Items.Critters.MyrdenflyItem>());
		AIType = NPCID.Firefly;
		SpawnModBiomes = new int[1] { ModContent.GetInstance<Biomes.MyrdenshawBiome>().Type };
	}
	public override void FindFrame(int frameHeight)
	{
		NPC.spriteDirection = NPC.direction;
		NPC.frameCounter += .5;
		NPC.frameCounter %= Main.npcFrameCount[NPC.type];
		NPC.frame.Y = (int)NPC.frameCounter * frameHeight;
	}
	public override void HitEffect(NPC.HitInfo hit)
	{
		if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
			for (int k = 0; k < 22; k++)
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SandstormInABottle, hit.HitDirection, -1f, 0, default, 1f);
	}
	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) => bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] { new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.EndlessContinuum.Bestiary.Myrdenfly")), });
}
