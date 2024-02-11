using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Materials;

class MyrdenshellShards : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenshellShards";
    public override void SetStaticDefaults() => this.SetResearchMaterial();
    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 26;
        Item.maxStack = Item.CommonMaxStack;
        Item.rare = ItemRarityID.Pink;
    }
}