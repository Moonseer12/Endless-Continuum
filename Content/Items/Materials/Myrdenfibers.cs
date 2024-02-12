using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Materials;

class Myrdenfibers : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "Myrdenfibers";
    public override void SetDefaults() => QuickItem.QuickDefaultItem(this, ItemRarityID.Pink, new Vector2(16, 20), Item.sellPrice(0, 0, 5, 0));
}