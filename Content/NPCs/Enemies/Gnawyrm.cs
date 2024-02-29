using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.NPCs.Enemies;

internal class GnawyrmHead : WormHead
{
	public override string Texture => ECAssets.NPCsPath + "GnawyrmHead";
	public override int BodyType => ModContent.NPCType<GnawyrmBody>();
	public override int TailType => ModContent.NPCType<GnawyrmTail>();
	public override void SetStaticDefaults()
	{
		var drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
		{
			CustomTexturePath = ECAssets.MiscPath + "GnawyrmBestiary",
			PortraitScale = 1f,
			PortraitPositionYOverride = 0f,
		};
		NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifiers);
	}
	public override void SetDefaults()
	{
		QuickNPC.QuickEnemyNPC(this, new Vector2(46, 58), 550, 70, 6, .65f, SoundID.NPCHit1, SoundID.NPCDeath4, -1, 1, true, false, Item.sellPrice(0, 0, 5, 0));
		Banner = NPC.type;
		BannerItem = ModContent.ItemType<Items.Tiles.GnawyrmBanner>();
		SpawnModBiomes = new int[1] { ModContent.GetInstance<Biomes.MyrdenshawBiome>().Type };
	}
	/*public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
	{
		NPC.lifeMax = Main.masterMode ? 850 : 700;
		NPC.damage = Main.masterMode ? 130 : 100;
	}*/
	public override void Init()
	{
		MinSegmentLength = 20;
		MaxSegmentLength = 20;
		CanFly = true;
		CommonWormInit(this);
	}
	internal static void CommonWormInit(Worm worm)
	{
		worm.MoveSpeed = 5.5f;
		worm.Acceleration = 0.045f;
	}
	private int attackCounter;
	public override void SendExtraAI(BinaryWriter writer) => writer.Write(attackCounter);
	public override void ReceiveExtraAI(BinaryReader reader) => attackCounter = reader.ReadInt32();
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
		npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.MyrdenshellShards>(), 1, 1, 3));
		npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Lightspores>(), 5));
	}
	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) => bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] { new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.EndlessContinuum.Bestiary.GnawyrmHead")), });
}

internal class GnawyrmBody : WormBody
{
	public override string Texture => ECAssets.NPCsPath + "GnawyrmBody";
	public override void SetStaticDefaults()
	{
		var value = new NPCID.Sets.NPCBestiaryDrawModifiers() { Hide = true };
		NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
	}
	public override void SetDefaults() => QuickNPC.QuickEnemyNPC(this, new Vector2(32, 58), 550, 70, 6, .65f, SoundID.NPCHit1, SoundID.NPCDeath4, -1, 1, true, false, Item.sellPrice(0, 0, 5, 0));
	public override void Init() => GnawyrmHead.CommonWormInit(this);
	public override void HitEffect(NPC.HitInfo hit)
	{
		for (int k = 0; k < 6; k++)
			Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SandstormInABottle, hit.HitDirection, -1f, 0, default, 1f);
		if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
			for (int k = 0; k < 22; k++)
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SandstormInABottle, hit.HitDirection, -1f, 0, default, 1f);
	}
}

internal class GnawyrmTail : WormTail
{
	public override string Texture => ECAssets.NPCsPath + "GnawyrmTail";
	public override void SetStaticDefaults()
	{
		var value = new NPCID.Sets.NPCBestiaryDrawModifiers() { Hide = true };
		NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
	}
	public override void SetDefaults() => QuickNPC.QuickEnemyNPC(this, new Vector2(42, 58), 550, 70, 6, .65f, SoundID.NPCHit1, SoundID.NPCDeath4, -1, 1, true, false, Item.sellPrice(0, 0, 5, 0));
	public override void Init() => GnawyrmHead.CommonWormInit(this);
	public override void HitEffect(NPC.HitInfo hit)
	{
		for (int k = 0; k < 6; k++)
			Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SandstormInABottle, hit.HitDirection, -1f, 0, default, 1f);
		if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
			for (int k = 0; k < 22; k++)
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SandstormInABottle, hit.HitDirection, -1f, 0, default, 1f);
	}
}