using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Weapons
{
	class AeriumWarhammer : ModItem
	{
        public override string Texture => ECAssets.ItemsPath + "AeriumWarhammer";
        public override void SetStaticDefaults() => this.SetResearch();
        public override void SetDefaults()
        {
            Item.Size = new Vector2(80, 80);
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.damage = 80;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 5;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) => target.AddBuff(ModContent.BuffType<AeriumShatter>(), 300);
        public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.AeriumBar>(20).AddTile<Tiles.SoulForgeTile>().Register();
    }

    class AeriumShatter : ModBuff
    {
        public override string Texture => ECAssets.BuffsPath + "AeriumShatter";
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
    }

    class AeriumShatterNPC : GlobalNPC
    {
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            if (modifiers.DamageType.CountsAsClass(DamageClass.Melee) && npc.HasBuff<AeriumShatter>())
                modifiers.SourceDamage *= 1.5f;
        }
    }
}