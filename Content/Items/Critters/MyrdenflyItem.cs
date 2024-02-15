using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Critters;

class MyrdenflyItem : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenflyItem";
    public override void SetDefaults() => QuickItem.QuickCritterItem(this, ItemRarityID.Pink, new Vector2(28, 12), Item.sellPrice(0, 0, 3, 0), ModContent.NPCType<NPCs.Critters.Myrdenfly>(), 20, 24);
}