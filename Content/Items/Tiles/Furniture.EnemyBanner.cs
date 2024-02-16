using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenfeederBanner : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenfeederBanner";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(12, 28), Item.sellPrice(0, 0, 2, 0), ModContent.TileType<MyrdenfeederBannerTile>());
}

class MyrdenfeederBannerTile : QuickBannerTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenfeederBannerTile";
	protected override int BannerEnemy => ModContent.NPCType<NPCs.Enemies.Myrdenfeeder>();
}

class MyrdenflyerBanner : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenflyerBanner";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(12, 28), Item.sellPrice(0, 0, 2, 0), ModContent.TileType<MyrdenflyerBannerTile>());
}

class MyrdenflyerBannerTile : QuickBannerTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenflyerBannerTile";
	protected override int BannerEnemy => ModContent.NPCType<NPCs.Enemies.Myrdenflyer>();
}