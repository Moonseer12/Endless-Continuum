using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Weapons;

class Myrdenblade : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "Myrdenblade";
    public override void SetDefaults() => QuickItem.QuickProjectileSwordItem(this, ItemRarityID.Pink, new Vector2(64, 64), Item.sellPrice(0, 0, 0, 20), 65, 25, 3, ModContent.ProjectileType<Myrdenleaf>(), 20);
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int i = 0; i < Main.rand.Next(3, 5); i++)
            Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(15)), type, damage, knockback, player.whoAmI);
        return false;
    }
    public override void AddRecipes() => CreateRecipe().AddIngredient<Materials.MyrdenshellShards>(25).AddIngredient<Materials.Myrdenfibers>(25).AddIngredient<Materials.Lightspores>(5).AddTile<Tiles.SoulForgeTile>().Register();
}

class Myrdenleaf : ModProjectile
{
    public override string Texture => ECAssets.ProjectilesPath + "Myrdenleaf";
    public override void SetDefaults()
    {
        Projectile.Size = new Vector2(22, 14);
        Projectile.friendly = true;
        Projectile.tileCollide = true;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 120;
    }
    public override void AI() => Projectile.rotation = Projectile.velocity.ToRotation();
}