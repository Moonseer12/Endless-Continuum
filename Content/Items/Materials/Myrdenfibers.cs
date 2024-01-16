using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Materials
{
	class Myrdenfibers : ModItem
	{
        public override string Texture => ECAssets.ItemsPath + "Myrdenfibers";
        public override void SetStaticDefaults() => this.SetResearchMaterial();
        public override void SetDefaults()
        {
            Item.Size = new Vector2(16, 20);
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Pink;
        }
    }
}