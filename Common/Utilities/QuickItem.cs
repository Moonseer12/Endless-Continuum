using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Common.Utilities;

abstract class QuickItem
{
    public static void QuickDefaultItem(ModItem item, int rare, Vector2 size, int sell)
    {
        item.Item.rare = rare;
        item.Item.maxStack = Item.CommonMaxStack;
        item.Item.Size = size;
        item.Item.value = sell;
        item.Item.ResearchUnlockCount = 25;
    }
    public static void QuickAccessoryItem(ModItem item, int rare, Vector2 size, int sell)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.maxStack = 1;
        item.Item.accessory = true;
        item.Item.ResearchUnlockCount = 1;
    }
    public static void QuickArmorItem(ModItem item, int rare, Vector2 size, int sell, int defense)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.maxStack = 1;
        item.Item.defense = defense;
        item.Item.ResearchUnlockCount = 1;
    }
    public static void QuickBaitItem(ModItem item, int rare, Vector2 size, int sell, int bait)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.bait = bait;
        item.Item.ResearchUnlockCount = 5;
    }
    public static void QuickBeamItem(ModItem item, int rare, Vector2 size, int sell, int tile)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.DefaultToPlaceableTile(tile);
        item.Item.ResearchUnlockCount = 50;
    }
    public static void QuickBlockItem(ModItem item, int rare, Vector2 size, int sell, int tile)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.DefaultToPlaceableTile(tile);
        item.Item.ResearchUnlockCount = 100;
    }
    public static void QuickBowItem(ModItem item, int rare, Vector2 size, int sell, int damage, int use, float knockback, float velocity)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.maxStack = 1;
        item.Item.damage = damage;
        item.Item.autoReuse = true;
        item.Item.useTurn = true;
        item.Item.useTime = use;
        item.Item.knockBack = knockback;
        item.Item.DamageType = DamageClass.Ranged;
        item.Item.useStyle = ItemUseStyleID.Shoot;
        item.Item.useAnimation = use;
        item.Item.UseSound = SoundID.Item5;
        item.Item.shoot = ProjectileID.WoodenArrowFriendly;
        item.Item.useAmmo = AmmoID.Arrow;
        item.Item.shootSpeed = velocity;
        item.Item.ResearchUnlockCount = 1;
    }
    public static void QuickCritterItem(ModItem item, int rare, Vector2 size, int sell, int npc, int use, int bait)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.makeNPC = npc;
        item.Item.noMelee = true;
        item.Item.consumable = true;
        item.Item.autoReuse = true;
        item.Item.noUseGraphic = true;
        item.Item.useTime = use;
        item.Item.useAnimation = use;
        item.Item.useStyle = ItemUseStyleID.Swing;
        item.Item.bait = bait;
        item.Item.ResearchUnlockCount = 5;
    }
    public static void QuickFoodItem(ModItem item, int width, int height, int buff, int duration, int rare, int sell)
    {
        item.Item.DefaultToFood(width, height, buff, duration);
        item.Item.rare = rare;
        item.Item.value = sell;
        item.Item.ResearchUnlockCount = 5;
    }
    public static void QuickFurnitureItem(ModItem item, int rare, Vector2 size, int sell, int tile)
    {
        QuickBlockItem(item, rare, size, sell, tile);
        item.Item.ResearchUnlockCount = 1;
    }
    public static void QuickHammerItem(ModItem item, int rare, Vector2 size, int sell, int damage, int hammer, int use, float knockback)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.maxStack = 1;
        item.Item.damage = damage;
        item.Item.autoReuse = true;
        item.Item.hammer = hammer;
        item.Item.useTurn = true;
        item.Item.useTime = use;
        item.Item.knockBack = knockback;
        item.Item.DamageType = DamageClass.Melee;
        item.Item.useStyle = ItemUseStyleID.Swing;
        item.Item.useAnimation = use;
        item.Item.UseSound = SoundID.Item1;
        item.Item.ResearchUnlockCount = 1;
    }
    public static void QuickHerbSeedItem(ModItem item, int rare, Vector2 size, int sell, int tile)
    {
        QuickBlockItem(item, rare, size, sell, tile);
        item.Item.ResearchUnlockCount = 25;
        ItemID.Sets.DisableAutomaticPlaceableDrop[item.Type] = true;
    }
    public static void QuickMiscItem(ModItem item, int rare, Vector2 size, int sell)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.maxStack = 1;
        item.Item.ResearchUnlockCount = 1;
    }
    public static void QuickMountItem(ModItem item, int rare, Vector2 size, int sell, int mount)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.useAnimation = 20;
        item.Item.useTime = 20;
        item.Item.useStyle = ItemUseStyleID.Swing;
        item.Item.UseSound = SoundID.Item1;
        item.Item.maxStack = 1;
        item.Item.ResearchUnlockCount = 1;
        item.Item.noMelee = true;
        item.Item.mountType = mount;
    }
    public static void QuickPotionItem(ModItem item, int rare, Vector2 size, int sell, int use, SoundStyle useSound, int itemUse, int buff, int buffTime)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.UseSound = useSound;
        item.Item.useStyle = itemUse;
        item.Item.useTime = use;
        item.Item.useAnimation = use;
        item.Item.consumable = true;
        item.Item.buffType = buff;
        item.Item.buffTime = buffTime;
        item.Item.ResearchUnlockCount = 20;
    }
    public static void QuickProjectileSwordItem(ModItem item, int rare, Vector2 size, int sell, int damage, int use, float knockback, int projectile, int velocity)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.maxStack = 1;
        item.Item.damage = damage;
        item.Item.autoReuse = true;
        item.Item.useTurn = true;
        item.Item.useTime = use;
        item.Item.knockBack = knockback;
        item.Item.DamageType = DamageClass.Melee;
        item.Item.useStyle = ItemUseStyleID.Swing;
        item.Item.useAnimation = use;
        item.Item.UseSound = SoundID.Item1;
        item.Item.shoot = projectile;
        item.Item.shootSpeed = velocity;
        item.Item.ResearchUnlockCount = 1;
    }
    public static void QuickRelicItem(ModItem item, Vector2 size, int tile)
    {
        item.Item.rare = ItemRarityID.Master;
        item.Item.maxStack = Item.CommonMaxStack;
        item.Item.Size = size;
        item.Item.value = Item.sellPrice(0, 1, 0, 0);
        item.Item.ResearchUnlockCount = 1;
		item.Item.master = true;
        item.Item.DefaultToPlaceableTile(tile);
    }
    public static void QuickSwordItem(ModItem item, int rare, Vector2 size, int sell, int damage, int use, float knockback)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.maxStack = 1;
        item.Item.damage = damage;
        item.Item.autoReuse = true;
        item.Item.useTurn = true;
        item.Item.useTime = use;
        item.Item.knockBack = knockback;
        item.Item.DamageType = DamageClass.Melee;
        item.Item.useStyle = ItemUseStyleID.Swing;
        item.Item.useAnimation = use;
        item.Item.UseSound = SoundID.Item1;
        item.Item.ResearchUnlockCount = 1;
    }
    public static void QuickVanityItem(ModItem item, int rare, Vector2 size, int sell)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.maxStack = 1;
        item.Item.vanity = true;
        item.Item.ResearchUnlockCount = 1;
    }
    public static void QuickWallItem(ModItem item, int rare, Vector2 size, int sell, int wall)
    {
        QuickDefaultItem(item, rare, size, sell);
        item.Item.DefaultToPlaceableWall((ushort)wall);
        item.Item.ResearchUnlockCount = 400;
    }
}