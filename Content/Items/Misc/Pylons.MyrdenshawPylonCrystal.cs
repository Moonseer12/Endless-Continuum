using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Misc
{
	class MyrdenshawPylonCrystal : ModItem
	{
        public override string Texture => ECAssets.ItemsPath + "MyrdenshawPylonCrystal";
        public override void SetStaticDefaults() => this.SetResearch();
        public override void SetDefaults()
        {
            Item.Size = new Vector2(20, 30);
            Item.rare = ItemRarityID.Pink;
        }
        public override void AddRecipes() => CreateRecipe().AddIngredient(ItemID.HallowedBar, 5).AddTile(TileID.MythrilAnvil).Register();
    }
}