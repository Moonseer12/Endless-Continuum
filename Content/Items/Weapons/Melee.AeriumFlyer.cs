using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Weapons
{
	class AeriumFlyer : ModItem
	{
        public override string Texture => ECAssets.ItemsPath + "AeriumFlyer";
        public override void SetStaticDefaults() => this.SetResearch();
        public override void SetDefaults()
        {
            Item.Size = new Vector2(32, 54);
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.damage = 70;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 5;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;
            Item.shootSpeed = 10f;
            Item.shoot = ModContent.ProjectileType<AeriumFlyerProj>();
            Item.autoReuse = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI, 0f, 0f);
            return true;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.AeriumBar>(20).AddTile<Tiles.SoulForgeTile>().Register();
    }

	class AeriumFlyerProj : ModProjectile
	{
		public override string Texture => ECAssets.ItemsPath + "AeriumFlyer";
		public override void SetDefaults()
		{
			Projectile.Size = new Vector2(32, 32);
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = 3;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 700;
		}
		public override void AI() => Projectile.rotation += 0.1f;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3))
            {
                for (int i = 0; i < 4; i++)
                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, new Vector2(0, 10f).RotatedBy(i * MathHelper.TwoPi / Main.rand.Next(0, 4)), ModContent.ProjectileType<AeriumFlyerLight>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
            }
        }
    }

    class AeriumFlyerLight : ModProjectile
    {
        public override string Texture => ECAssets.ProjectilesPath + "AeriumFlyerLight";
        public override void SetDefaults()
        {
            Projectile.Size = new Vector2(32, 32);
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 700;
        }
        public int AeriumFlyerHome = 0;
        public override void AI()
        {
            Projectile.rotation += 0.2f;
            //Projectile.velocity = 10f;
            AeriumFlyerHome++;
            if (AeriumFlyerHome > 20)
            {
                Vector2 unitVectorTowardsPlayer = Projectile.DirectionTo(Main.player[Projectile.owner].MountedCenter).SafeNormalize(Vector2.Zero);
                Projectile.velocity = Projectile.velocity.MoveTowards(unitVectorTowardsPlayer * 10f, 1f);
                if (Projectile.Distance(Main.player[Projectile.owner].MountedCenter) <= 10f)
                {
                    Projectile.Kill();
                    return;
                }
            }
        }
    }
}