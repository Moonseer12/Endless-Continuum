using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SubworldLibrary;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenshawPylon : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenshawPylon";
	public override void SetDefaults() => QuickItem.QuickBlockItem(this, ItemRarityID.Pink, new Vector2(32, 42), 0, ModContent.TileType<MyrdenshawPylonTile>());
}

class MyrdenshawPylonTile : QuickDimensionPylonTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenshawPylonTile";
	protected override int PylonCrystal => ModContent.ItemType<Misc.MyrdenshawPylonCrystal>();
	protected override bool PylonDimension => SubworldSystem.IsActive<Subworlds.Myrdenshaw>();
	protected override bool PylonEnter => SubworldSystem.Enter<Subworlds.Myrdenshaw>();
	protected override int PylonItem => ModContent.ItemType<MyrdenshawPylon>();
	protected override Color PylonMapColor => new Color(82, 70, 40);
	public override void Load()
	{
		crystalTexture = ModContent.Request<Texture2D>("EndlessContinuum/Assets/Textures/Tiles/MyrdenshawPylonTile_Crystal");
		crystalHighlightTexture = ModContent.Request<Texture2D>("EndlessContinuum/Assets/Textures/Tiles/PylonTile_CrystalHighlight");
	}
}