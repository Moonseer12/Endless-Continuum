using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace EndlessContinuum.Common.Utilities;

abstract class QuickProjectile
{
    public static void QuickDefaultProjectile(ModProjectile projectile, Vector2 size, bool friendly, bool hostile, bool collide, DamageClass damageClass, int penetrate, int time)
    {
		projectile.Projectile.Size = size;
		projectile.Projectile.friendly = friendly;
		projectile.Projectile.hostile = hostile;
		projectile.Projectile.tileCollide = collide;
		projectile.Projectile.DamageType = damageClass;
		projectile.Projectile.penetrate = penetrate;
		projectile.Projectile.timeLeft = time;
	}
}