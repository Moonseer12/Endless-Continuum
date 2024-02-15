using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Potions;

class Lightberry : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "Lightberry";
	public override void SetStaticDefaults()
	{
		Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
		ItemID.Sets.FoodParticleColors[Item.type] = new Color[2] { new Color(209, 89, 25), new Color(212, 184, 102) };
		ItemID.Sets.IsFood[Type] = true;
	}
	public override void SetDefaults() => QuickItem.QuickFoodItem(this, 22, 27, BuffID.WellFed2, 3600 * 5, ItemRarityID.Pink, Item.sellPrice(0, 0, 20, 0));
}