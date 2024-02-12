using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Materials;

class MyrdenshellShards : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenshellShards";
    public override void SetDefaults() => QuickItem.QuickDefaultItem(this, ItemRarityID.Pink, new Vector2(28, 26), Item.sellPrice(0, 0, 5, 0));
}