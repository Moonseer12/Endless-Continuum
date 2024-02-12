using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Weapons;

class AeriumWarhammer : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "AeriumWarhammer";
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
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) => target.GetGlobalNPC<AeriumShatterNPC>().AeriumShatter = 600;
    public override void AddRecipes() => CreateRecipe().AddIngredient<Tiles.AeriumBar>(20).AddIngredient<Materials.MyrdenshellShards>(10).AddTile<Tiles.SoulForgeTile>().Register();
}

class AeriumShatterNPC : GlobalNPC
{
    public override bool InstancePerEntity => true;
    public int AeriumShatter = 0;
    public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
    {
        if (modifiers.DamageType.CountsAsClass(DamageClass.Melee) && AeriumShatter > 0)
            modifiers.SourceDamage *= 1.5f;
    }
    public override void PostAI(NPC npc)
    {
        if (AeriumShatter > 0)
            AeriumShatter--;
    }
}