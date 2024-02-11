using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace EndlessContinuum.Content.Items.Weapons;

class ThunderStrike : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "ThunderStrike";
    public override void SetStaticDefaults() => this.SetResearch();
    public override void SetDefaults()
    {
        Item.Size = new Vector2(28, 30);
        Item.rare = ItemRarityID.Pink;
        Item.value = Item.sellPrice(0, 5, 0, 0);
        Item.damage = 60;
        Item.DamageType = DamageClass.Magic;
        Item.knockBack = 5;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.UseSound = SoundID.Item9;
        Item.shootSpeed = 30f;
        Item.shoot = ModContent.ProjectileType<Thunder>();
        Item.autoReuse = true;
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile.NewProjectile(source, Main.MouseWorld.X, Main.MouseWorld.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI, -30, 0f);
        return false;
    }
    public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.SurgestoneBar>(20).AddRecipeGroup(Common.Globals.Items.ECRecipes.AnyAdamantiteBar, 10).AddTile<Tiles.SoulForgeTile>().Register();
}

class Thunder : ModProjectile
{
	public override string Texture => ECAssets.ProjectilesPath + "Thunder";
	public override void SetStaticDefaults()
	{
		ProjectileID.Sets.TrailingMode[Projectile.type] = 3;
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 50;
	}
	public override void SetDefaults()
	{
		Projectile.Size = new Vector2(16, 16);
		Projectile.friendly = true;
		Projectile.tileCollide = true;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 120;
		Projectile.alpha = 255;
	}
	Vector2 vector166 = default;
	public int frameCounter;
	public override void AI()
	{
		frameCounter++;
		Lighting.AddLight(Projectile.Center, 0.3f, 0.45f, 0.5f);
		Vector2 val4;
		if (Projectile.velocity == Vector2.Zero)
		{
			if (frameCounter >= Projectile.extraUpdates * 2)
			{
				frameCounter = 0;
				bool flag29 = true;
				for (int num820 = 1; num820 < Projectile.oldPos.Length; num820++)
				{
					if (Projectile.oldPos[num820] != Projectile.oldPos[0])
					{
						flag29 = false;
					}
				}
				if (flag29)
				{
					Projectile.Kill();
					return;
				}
			}
			if (Main.rand.NextBool(Projectile.extraUpdates))
			{
				for (int num822 = 0; num822 < 2; num822++)
				{
					float num823 = Projectile.rotation + (Main.rand.NextBool(2) ? (-1f) : 1f) * ((float)Math.PI / 2f);
					float num824 = (float)Main.rand.NextDouble() * 0.8f + 1f;
					vector166 = new Vector2((float)Math.Cos(num823) * num824, (float)Math.Sin(num823) * num824);
					int num825 = Dust.NewDust(Projectile.Center, 0, 0, DustID.Electric, vector166.X, vector166.Y);
					Main.dust[num825].noGravity = true;
					Main.dust[num825].scale = 1.2f;
				}
				if (Main.rand.NextBool(5))
				{
					Vector2 spinningpoint60 = Projectile.velocity;
					val4 = default;
					Vector2 vector168 = spinningpoint60.RotatedBy(1.5707963705062866, val4) * ((float)Main.rand.NextDouble() - 0.5f) * Projectile.width;
					int num826 = Dust.NewDust(Projectile.Center + vector168 - Vector2.One * 4f, 8, 8, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
					Dust dust60 = Main.dust[num826];
					Dust dust212 = dust60;
					dust212.velocity *= 0.5f;
					Main.dust[num826].velocity.Y = 0f - Math.Abs(Main.dust[num826].velocity.Y);
				}
			}
		}
		else
		{
			if (frameCounter < Projectile.extraUpdates * 2)
			{
				return;
			}
			frameCounter = 0;
			float num827 = Projectile.velocity.Length();
			UnifiedRandom unifiedRandom = new UnifiedRandom((int)Projectile.ai[1]);
			int num828 = 0;
			Vector2 spinningpoint7 = -Vector2.UnitY;
			while (true)
			{
				int num829 = unifiedRandom.Next();
				Projectile.ai[1] = num829;
				num829 %= 100;
				float f = num829 / 100f * ((float)Math.PI * 2f);
				Vector2 vector169 = f.ToRotationVector2();
				if (vector169.Y > 0f)
				{
					vector169.Y *= -1f;
				}
				bool flag30 = false;
				if (vector169.Y > -0.02f || vector169.X * (Projectile.extraUpdates + 1) * 2f * num827 + Projectile.localAI[0] > 40f || vector169.X * (Projectile.extraUpdates + 1) * 2f * num827 + Projectile.localAI[0] < -40f)
				{
					flag30 = true;
				}
				if (flag30)
				{
					if (num828++ >= 100)
					{
						Projectile.velocity = Vector2.Zero;
						Projectile.localAI[1] = 1f;
						break;
					}
					continue;
				}
				spinningpoint7 = vector169;
				break;
			}
			if (Projectile.velocity != Vector2.Zero)
			{
				Projectile.localAI[0] += spinningpoint7.X * (Projectile.extraUpdates + 1) * 2f * num827;
				Vector2 spinningpoint61 = spinningpoint7;
				double radians47 = Projectile.ai[0] + (float)Math.PI / 2f;
				val4 = default;
				Projectile.velocity = spinningpoint61.RotatedBy(radians47, val4) * num827;
				Projectile.rotation = Projectile.velocity.ToRotation() + (float)Math.PI / 2f;
			}
		}
	}
	public override bool PreDraw(ref Color lightColor)
	{
		default(ThunderTrail).Draw(Projectile);
		return true;
	}
	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) => Projectile.Kill();
	public override void OnKill(int timeLeft)
	{
		Projectile.NewProjectileDirect(Projectile.GetSource_Death(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<ThunderHit>(), Projectile.damage, 0, Main.myPlayer);
		SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);
	}
}

class ThunderHit : ModProjectile
{
	public override string Texture => ECAssets.ProjectilesPath + "ThunderHit";
	public override void SetStaticDefaults() => Main.projFrames[Projectile.type] = 4;
	public override void SetDefaults()
	{
		Projectile.Size = new Vector2(80, 80);
		Projectile.aiStyle = 139;
		Projectile.friendly = true;
		Projectile.tileCollide = false;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 10;
		Projectile.usesLocalNPCImmunity = true;
		Projectile.localNPCHitCooldown = 30;
		Projectile.alpha = 255;
	}
	public override void AI()
	{
		Lighting.AddLight(Projectile.Center, 0.3f, 0.45f, 0.5f);
		Projectile.frameCounter++;
		if (Projectile.frameCounter >= 3)
		{
			Projectile.frame++;
			Projectile.frameCounter = 0;
			if (Projectile.frame >= 4)
				Projectile.frame = 0;
		}
	}
}

public struct ThunderTrail
{
	private static VertexStrip _vertexStrip = new VertexStrip();
	public void Draw(Projectile proj)
	{
		MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
		miscShaderData.UseSaturation(-2.8f);
		miscShaderData.UseOpacity(2f);
		miscShaderData.Apply();
		_vertexStrip.PrepareStripWithProceduralPadding(proj.oldPos, proj.oldRot, StripColors, StripWidth, -Main.screenPosition + proj.Size / 2f);
		_vertexStrip.DrawTrail();
		Main.pixelShader.CurrentTechnique.Passes[0].Apply();
	}
	private Color StripColors(float progressOnStrip)
	{
		Color result = Color.Lerp(Color.White, Color.LimeGreen, Utils.GetLerpValue(0f, 0.7f, progressOnStrip, clamped: true)) * (1f - Utils.GetLerpValue(0f, 0.98f, progressOnStrip));
		result.A = (byte)(result.A / 2);
		return result;
	}
	private float StripWidth(float progressOnStrip)
	{
		float num = 1f;
		float lerpValue = Utils.GetLerpValue(0f, 0.2f, progressOnStrip, clamped: true);
		num *= 1f - (1f - lerpValue) * (1f - lerpValue);
		return MathHelper.Lerp(0f, 32f, num);
	}
}