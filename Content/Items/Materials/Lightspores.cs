using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Materials;

class Lightspores : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "Lightspores";
    public override void SetDefaults() => QuickItem.QuickDefaultItem(this, ItemRarityID.Pink, new Vector2(24, 24), Item.sellPrice(0, 0, 10, 0));
}