using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Weapons;

class Myrdenring : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "Myrdenring";
    public override void SetDefaults() => QuickItem.QuickYoyoItem(this, ItemRarityID.Pink, new Vector2(30, 26), Item.sellPrice(0, 10, 0, 0), 50, 3, ModContent.ProjectileType<MyrdenringProj>(), 20, 15);
    public override void AddRecipes() => CreateRecipe().AddIngredient<Materials.MyrdenshellShards>(25).AddIngredient<Materials.Myrdenfibers>(25).AddIngredient<Materials.Lightspores>(5).AddTile<Tiles.SoulForgeTile>().Register();
}

class MyrdenringProj : ModProjectile
{
    public override string Texture => ECAssets.ProjectilesPath + "MyrdenringProj";
	public override void SetStaticDefaults()
	{
		ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 3.5f;
		ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 300f;
		ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13f;
	}
	public override void SetDefaults()
	{
		Projectile.Size = new Vector2(16, 16);
		Projectile.aiStyle = ProjAIStyleID.Yoyo;
		Projectile.friendly = true;
		Projectile.DamageType = DamageClass.MeleeNoSpeed;
		Projectile.penetrate = -1;
	}
    public int Myrdenleaf = 0;
    public override void AI()
    {
        Myrdenleaf++;
        if (Myrdenleaf > 60)
        {
            for (int i = 0; i < 8; i++)
                Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, new Vector2(0, 10f).RotatedBy(i * MathHelper.TwoPi / 8), ModContent.ProjectileType<Myrdenleaf>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
            Myrdenleaf = 0;
        }
    }
}