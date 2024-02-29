using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SubworldLibrary;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class AbyssalMinesPylon : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "AbyssalMinesPylon";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Green, new Vector2(32, 42), 0, ModContent.TileType<AbyssalMinesPylonTile>());
}

class AbyssalMinesPylonTile : QuickDimensionPylonTile
{
	public override string Texture => ECAssets.TilesPath + "AbyssalMinesPylonTile";
	protected override int PylonCrystal => ModContent.ItemType<Misc.AbyssalMinesPylonCrystal>();
	protected override bool PylonDimension => SubworldSystem.IsActive<Subworlds.AbyssalMines>();
	protected override bool PylonEnter => SubworldSystem.Enter<Subworlds.AbyssalMines>();
	protected override int PylonItem => ModContent.ItemType<AbyssalMinesPylon>();
	protected override Color PylonMapColor => new(50, 66, 102);
	public override void Load()
	{
		crystalTexture = ModContent.Request<Texture2D>("EndlessContinuum/Assets/Textures/Tiles/AbyssalMinesPylonTile_Crystal");
		crystalHighlightTexture = ModContent.Request<Texture2D>("EndlessContinuum/Assets/Textures/Tiles/PylonTile_CrystalHighlight");
	}
}