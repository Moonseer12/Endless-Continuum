using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Potions;

class Myrdereen : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "Myrdereen";
	public override void SetStaticDefaults()
	{
		Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
		ItemID.Sets.FoodParticleColors[Item.type] = new Color[1] { new Color(209, 89, 25) };
		ItemID.Sets.IsFood[Type] = true;
	}
	public override void SetDefaults() => QuickItem.QuickFoodItem(this, 22, 25, BuffID.WellFed2, 3600 * 5, ItemRarityID.Pink, Item.sellPrice(0, 0, 20, 0));
}