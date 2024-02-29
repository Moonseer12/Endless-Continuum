using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.NPCs.Enemies;

class Myrdenfeeder : ModNPC
{
	public override string Texture => ECAssets.NPCsPath + "Myrdenfeeder";
	public override void SetStaticDefaults()
	{
		var drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
		{
			CustomTexturePath = ECAssets.MiscPath + "MyrdenfeederBestiary",
			PortraitScale = 1f,
			PortraitPositionYOverride = 0f,
		};
		NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifiers);
	}
	public override void SetDefaults()
	{
		QuickNPC.QuickEnemyNPC(this, new Vector2(60, 34), 550, 70, 6, .65f, SoundID.NPCHit1, SoundID.NPCDeath1, -1, 1, true, true, Item.sellPrice(0, 0, 5, 0));
		Banner = NPC.type;
		BannerItem = ModContent.ItemType<Items.Tiles.MyrdenfeederBanner>();
		SpawnModBiomes = new int[1] { ModContent.GetInstance<Biomes.MyrdenshawBiome>().Type };
	}
	/*public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
	{
		NPC.lifeMax = Main.masterMode ? 850 : 700;
		NPC.damage = Main.masterMode ? 130 : 100;
	}*/
	public override bool PreDraw(SpriteBatch spriteBatch, Vector2 v, Color drawColor)
	{
		if (!NPC.IsABestiaryIconDummy)
		{
			Vector2 end1 = NPC.Center;
			var end2 = new Vector2(NPC.ai[0] * 16 + 8, NPC.ai[1] * 16 + 8);
			var vector = new Vector2(NPC.position.X + (NPC.width / 2), NPC.position.Y + (NPC.height / 2));
			float rotationX = NPC.ai[0] * 16f + 8f - vector.X;
			float rotationY = NPC.ai[1] * 16f + 8f - vector.Y;
			float rotation = (float)Math.Atan2(rotationY, rotationX) - 1.57f;
			Texture2D texture;
			if (end1 != end2)
			{
				float length = Vector2.Distance(end1, end2);
				Vector2 direction = end2 - end1;
				direction.Normalize();
				texture = Mod.Assets.Request<Texture2D>("Assets/Textures/NPCs/MyrdenfeederChain").Value;
				for (float k = 0; k <= length; k += 22f)
				{
					Vector2 drawlight = end1 + k * direction + new Vector2(8, 8);
					Main.EntitySpriteDraw(texture, end1 + k * direction - Main.screenPosition, null, Lighting.GetColor((int)(drawlight.X / 16), (int)(drawlight.Y / 16)), rotation, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0);
				}
			}
			var drawOrigin = new Vector2(21, 25);
			for (int k = 0; k < NPC.oldPos.Length; k++)
			{
				Vector2 drawPos = NPC.oldPos[k] - Main.screenPosition + new Vector2(21, 21) + new Vector2(0f, NPC.gfxOffY);
				Color color = NPC.GetAlpha(drawColor) * ((float)(NPC.oldPos.Length - k) / NPC.oldPos.Length);
				Main.EntitySpriteDraw(ModContent.Request<Texture2D>(Texture).Value,
					drawPos, new Rectangle(0, 0, 42, 50), color, NPC.rotation, drawOrigin, NPC.scale, SpriteEffects.None, 0);
			}
		}
		return true;
    }
	public int Lightspore = 0;
    public override void AI()
	{
		NPC.netUpdate = true;
		if (NPC.ai[3] == 0)
		{
			NPC.position.Y += 48;
			NPC.ai[0] = (int)(NPC.Center.X / 16);
			NPC.ai[1] = (int)(NPC.Center.Y / 16);
			if (!Main.tile[(int)NPC.ai[0], (int)NPC.ai[1]].HasTile)
			{
				NPC.active = false;
				return;
			}
			NPC.ai[3]++;
		}
		if (!Main.tile[(int)NPC.ai[0], (int)NPC.ai[1]].HasTile)
		{
			SoundEngine.PlaySound(NPC.DeathSound.Value, NPC.position);
			NPC.life = 0;
			NPC.HitEffect();
			NPC.active = false;
		}
		if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
		{
			NPC.TargetClosest();
		}
		Vector2 trueAimingPosition = NPC.GetTargetData(false).Center;
		NPC.rotation = NPC.Center.DirectionTo(Main.player[NPC.target].Center).ToRotation() + MathHelper.Pi;
		Vector2 targetPos = new Vector2(NPC.ai[0] * 16 + 8, NPC.ai[1] * 16 + 8) + Vector2.Normalize(trueAimingPosition - NPC.Center) * 300;
		Vector2 targetVel = Vector2.Normalize(targetPos - NPC.Center) * 6;
		NPC.velocity.X += Math.Sign(targetVel.X - NPC.velocity.X) * 0.03f;
		NPC.velocity.Y += Math.Sign(targetVel.Y - NPC.velocity.Y) * 0.03f;
		Lightspore++;
		if (Lightspore > 120)
        {
			SoundEngine.PlaySound(SoundID.NPCHit8, NPC.position);
			Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center + Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center), Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center) * 5, ModContent.ProjectileType<Lightspore>(), NPC.damage, 5, Main.myPlayer, 0);
			Lightspore = 0;
		}
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
	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) => bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] { new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.EndlessContinuum.Bestiary.Myrdenfeeder")), });
}

class Lightspore : ModProjectile
{
	public override string Texture => ECAssets.ProjectilesPath + "Lightspore";
	public override void SetDefaults() => QuickProjectile.QuickDefaultProjectile(this, new Vector2(10, 10), false, true, true, DamageClass.Default, -1, 120);
	public override void AI()
	{
		Projectile.rotation = Projectile.velocity.ToRotation();
		Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.SandstormInABottle, 0, 0);
	}
	public override void OnKill(int timeLeft)
	{
		SoundEngine.PlaySound(SoundID.NPCDeath1, Projectile.position);
		for (int k = 0; k < 22; k++)
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SandstormInABottle, Projectile.direction, -1f, 0, default, 1f);
	}
}