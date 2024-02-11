using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Materials;

class Lightspores : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "Lightspores";
    public override void SetStaticDefaults() => this.SetResearchMaterial();
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 24;
        Item.maxStack = Item.CommonMaxStack;
        Item.rare = ItemRarityID.Pink;
    }
}