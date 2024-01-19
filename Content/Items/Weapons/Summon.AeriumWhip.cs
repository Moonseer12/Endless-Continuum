using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Weapons
{
	class AeriumWhip : ModItem
	{
        public override string Texture => ECAssets.ItemsPath + "AeriumWhip";
        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<AeriumWhipProjectile>(), 70, 2, 5);
            Item.Size = new Vector2(16, 34);
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 5, 0, 0);
        }
        public override bool MeleePrefix() => true;
        public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.AeriumBar>(20).AddTile<Tiles.SoulForgeTile>().Register();
    }

	class AeriumWhipProjectile : ModProjectile
	{
		public override string Texture => ECAssets.ProjectilesPath + "AeriumWhipProjectile";
		public override void SetStaticDefaults() => ProjectileID.Sets.IsAWhip[Type] = true;
		public override void SetDefaults() => Projectile.DefaultToWhip();
		private float Timer
		{
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.GetGlobalNPC<AeriumWhipDebuffNPC>().AeriumWhipDebuff = 240;
			Main.player[Projectile.owner].AddBuff(ModContent.BuffType<AeriumWhipBuff>(), 240);
			Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
			Projectile.damage = (int)(Projectile.damage * 0.5f);
		}
		private static void DrawLine(List<Vector2> list)
		{
			Texture2D texture = TextureAssets.FishingLine.Value;
			Rectangle frame = texture.Frame();
			Vector2 origin = new Vector2(frame.Width / 2, 2);
			Vector2 pos = list[0];
			for (int i = 0; i < list.Count - 1; i++)
			{
				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;
				float rotation = diff.ToRotation() - MathHelper.PiOver2;
				Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.White);
				Vector2 scale = new Vector2(1, (diff.Length() + 2) / frame.Height);
				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0);
				pos += diff;
			}
		}
		public override bool PreDraw(ref Color lightColor)
		{
			List<Vector2> list = new List<Vector2>();
			Projectile.FillWhipControlPoints(Projectile, list);
			DrawLine(list);
			SpriteEffects flip = Projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			Main.instance.LoadProjectile(Type);
			Texture2D texture = TextureAssets.Projectile[Type].Value;
			Vector2 pos = list[0];
			for (int i = 0; i < list.Count - 1; i++)
			{
				Rectangle frame = new Rectangle(0, 0, 14, 26);
				Vector2 origin = new Vector2(5, 8);
				float scale = 1;
				if (i == list.Count - 2)
				{
					frame.Y = 74;
					frame.Height = 20;
					Projectile.GetWhipSettings(Projectile, out float timeToFlyOut, out int _, out float _);
					float t = Timer / timeToFlyOut;
					scale = MathHelper.Lerp(0.5f, 1.5f, Utils.GetLerpValue(0.1f, 0.7f, t, true) * Utils.GetLerpValue(0.9f, 0.7f, t, true));
				}
				else if (i > 10)
				{
					frame.Y = 58;
					frame.Height = 16;
				}
				else if (i > 5)
				{
					frame.Y = 42;
					frame.Height = 16;
				}
				else if (i > 0)
				{
					frame.Y = 26;
					frame.Height = 16;
				}
				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;
				float rotation = diff.ToRotation() - MathHelper.PiOver2;
				Color color = Lighting.GetColor(element.ToTileCoordinates());
				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, flip, 0);
				pos += diff;
			}
			return false;
		}
	}

	class AeriumWhipDebuffNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public int AeriumWhipDebuff = 0;
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
		{
			if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
				return;
			if (AeriumWhipDebuff > 0)
				modifiers.FlatBonusDamage += 10 * ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
		}
		public override void PostAI(NPC npc)
		{
			if (AeriumWhipDebuff > 0)
				AeriumWhipDebuff--;
		}
	}

	class AeriumWhipBuff : ModBuff
    {
		public override string Texture => ECAssets.BuffsPath + "AeriumWhipBuff";
	}

	class AeriumWhipGlobalProjectile : GlobalProjectile
    {
		public override bool InstancePerEntity => true;
		public float distanceFromTarget = 900f;
		public int AeriumCrystal = 0;
		public override void PostAI(Projectile projectile)
		{
			if (projectile.minion == true && Main.player[projectile.owner].HasBuff<AeriumWhipBuff>())
			{
				Vector2 targetCenter = projectile.position;
				bool foundTarget = false;
				AeriumCrystal++;
				if (Main.player[projectile.owner].HasMinionAttackTargetNPC)
				{
					NPC npc = Main.npc[Main.player[projectile.owner].MinionAttackTargetNPC];
					float between = Vector2.Distance(npc.Center, projectile.Center);
					if (between < 2000f)
					{
						distanceFromTarget = between;
						targetCenter = npc.Center;
						foundTarget = true;
					}
				}
				if (foundTarget && AeriumCrystal > 20)
				{
					Vector2 direction = targetCenter - projectile.Center;
					var EntitySource = projectile.GetSource_Death();
					if (Main.netMode != NetmodeID.MultiplayerClient)
						Projectile.NewProjectile(EntitySource, projectile.Center.X, projectile.Center.Y, direction.X * 25, direction.Y * 25, ModContent.ProjectileType<AeriumCrystal>(), projectile.damage, 1, Main.myPlayer, 0, 0);
					AeriumCrystal = 0;
				}
			}
		}
	}

	public class AeriumCrystal : ModProjectile
	{
		public override string Texture => ECAssets.ProjectilesPath + "AeriumCrystal";
		public override void SetStaticDefaults() => ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		public override void SetDefaults()
		{
			Projectile.Size = new Vector2(18, 10);
			Projectile.aiStyle = 0;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.light = 1f;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 120;
		}
		public override void AI()
		{
			float maxDetectRadius = 400f;
			float projSpeed = 10f;
			NPC closestNPC = FindClosestNPC(maxDetectRadius);
			if (closestNPC == null)
				return;
			Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
			Projectile.rotation = Projectile.velocity.ToRotation();
		}
		public NPC FindClosestNPC(float maxDetectDistance)
		{
			NPC closestNPC = null;
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;
			for (int k = 0; k < Main.maxNPCs; k++)
			{
				NPC target = Main.npc[k];
				if (target.CanBeChasedBy() && target.GetGlobalNPC<AeriumWhipDebuffNPC>().AeriumWhipDebuff > 0)
				{
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);
					if (sqrDistanceToTarget < sqrMaxDetectDistance)
					{
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}
			return closestNPC;
		}
	}
}