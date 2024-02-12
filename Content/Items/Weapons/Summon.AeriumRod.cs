using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Weapons;

class AeriumRod : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "AeriumRod";
    public override void SetDefaults()
    {
        Item.Size = new Vector2(16, 34);
        Item.rare = ItemRarityID.Pink;
        Item.value = Item.sellPrice(0, 5, 0, 0);
        Item.damage = 60;
        Item.DamageType = DamageClass.Summon;
        Item.mana = 20;
        Item.knockBack = 5;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.noUseGraphic = true;
        Item.UseSound = SoundID.Item20;
        Item.shootSpeed = 0f;
        Item.shoot = ModContent.ProjectileType<AeriumSigil>();
        Item.autoReuse = true;
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (Vector2.Distance(Main.MouseWorld, position) < 600f)
        {
            Projectile.NewProjectile(source, Main.MouseWorld, velocity, type, damage, knockback, player.whoAmI);
            player.UpdateMaxTurrets();
        }
        return false;
    }
    public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.AeriumBar>(20).AddIngredient<Materials.MyrdenshellShards>(10).AddTile<Tiles.SoulForgeTile>().Register();
}

class AeriumSigil : ModProjectile
{
    public override string Texture => ECAssets.ProjectilesPath + "AeriumSigil";
    public override void SetDefaults()
    {
        Projectile.Size = new Vector2(42, 42);
        Projectile.timeLeft = Projectile.SentryLifeTime;
        Projectile.DamageType = DamageClass.Summon;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.tileCollide = false;
        Projectile.sentry = true;
        Projectile.ignoreWater = true;
    }
    public int AeriumCrystal = 0;
    public override void AI()
    {
        AeriumCrystal++;
        if (AeriumCrystal > 20)
        {
            for (int i = 0; i < 4; i++)
                Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, new Vector2(0, 10f).RotatedBy(i * MathHelper.TwoPi / Main.rand.Next(3, 8)), ModContent.ProjectileType<AeriumSigilCrystal>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
            AeriumCrystal = 0;
        }
    }
}

class AeriumSigilCrystal : ModProjectile
{
    public override string Texture => ECAssets.ProjectilesPath + "AeriumCrystal";
    public override void SetDefaults()
    {
        Projectile.Size = new Vector2(18, 10);
        Projectile.friendly = true;
        Projectile.tileCollide = true;
        Projectile.DamageType = DamageClass.Summon;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 120;
    }
    public override void AI() => Projectile.rotation = Projectile.velocity.ToRotation();
}