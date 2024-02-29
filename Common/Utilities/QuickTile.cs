using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using SubworldLibrary;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.Metadata;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Default;
using Terraria.ObjectData;
using Terraria.Utilities;

namespace EndlessContinuum.Common.Utilities;

abstract class QuickTile
{
	public static void QuickBarTile(ModTile tile)
	{
		tile.AdjTiles = new int[] { TileID.MetalBars };
		tile.HitSound = SoundID.Tink;
		Main.tileSolid[tile.Type] = true;
		Main.tileSolidTop[tile.Type] = true;
		Main.tileFrameImportant[tile.Type] = true;
		TileID.Sets.IgnoredByNpcStepUp[tile.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.addTile(tile.Type);
		tile.AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.MetalBar"));
	}
	public static void QuickBathtubTile(ModTile tile, int dust, Color mapColor)
	{
		tile.AdjTiles = new int[] { TileID.Bathtubs };
		tile.DustType = dust;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
		TileObjectData.newTile.Origin = new Point16(1, 1);
		TileObjectData.newTile.DrawYOffset = 2;
		TileObjectData.addTile(tile.Type);
		LocalizedText name = tile.CreateMapEntryName();
		tile.AddMapEntry(mapColor, name);
	}
	public static void QuickBeamTile(ModTile tile, int dust, SoundStyle hitSound, Color mapColor)
	{
		tile.DustType = dust;
		tile.HitSound = hitSound;
		Main.tileSolid[tile.Type] = false;
		Main.tileBlockLight[tile.Type] = true;
		TileID.Sets.IsBeam[tile.Type] = true;
		tile.AddMapEntry(mapColor);
	}
	public static void QuickBlockTile(ModTile tile, int dust, SoundStyle hitSound, float mineResist, int pick, Color mapColor)
	{
		tile.DustType = dust;
		tile.HitSound = hitSound;
		tile.MineResist = mineResist;
		tile.MinPick = pick;
		Main.tileSolid[tile.Type] = true;
		Main.tileBlockLight[tile.Type] = true;
		tile.AddMapEntry(mapColor);
	}
	public static void QuickBookcaseTile(ModTile tile, int dust, Color mapColor)
	{
		tile.AdjTiles = new int[] { TileID.Bookcases };
		tile.DustType = dust;
		Main.tileSolidTop[tile.Type] = true;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
		TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16 };
		TileObjectData.addTile(tile.Type);
		LocalizedText name = tile.CreateMapEntryName();
		tile.AddMapEntry(mapColor, name);
		tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
	}
	public static void QuickCritterJarTile(ModTile tile)
	{
		tile.AnimationFrameHeight = 36;
		tile.DustType = DustID.Glass;
		Main.tileLighted[tile.Type] = false;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newTile.Width = 2;
		TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table | AnchorType.SolidTile | AnchorType.SolidWithTop, TileObjectData.newTile.Width, 0);
		TileObjectData.newTile.Origin = new Point16(0, 1);
		TileObjectData.addTile(tile.Type);
		LocalizedText name = tile.CreateMapEntryName();
		tile.AddMapEntry(new Color(200, 200, 200), name);
	}
	public static void QuickFoliageTile(ModTile tile, int dust, SoundStyle hitSound, bool lavaDeath, int width, int height, int[] coordinateHeights, bool horizontal, int styleRange, int grass, Point16 origin)
	{
		tile.DustType = dust;
		tile.HitSound = hitSound;
		Main.tileSolid[tile.Type] = false;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = lavaDeath;
		TileID.Sets.DisableSmartCursor[tile.Type] = true;
		TileObjectData.newTile.Width = width;
		TileObjectData.newTile.Height = height;
		TileObjectData.newTile.CoordinateHeights = coordinateHeights;
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newTile.StyleHorizontal = horizontal;
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.RandomStyleRange = styleRange;
		TileObjectData.newTile.AnchorValidTiles = new int[] { grass };
		TileObjectData.newTile.Origin = origin;
		TileObjectData.addTile(tile.Type);
		TileMaterials.SetForTileId(tile.Type, TileMaterials._materialsByName["Plant"]);
	}
	public static void QuickFoliageHangingTile(ModTile tile, int dust, SoundStyle hitSound, bool lavaDeath, int width, int height, int[] coordinateHeights, int styleRange, int grass, Point16 origin)
	{
		tile.DustType = dust;
		tile.HitSound = hitSound;
		Main.tileSolidTop[tile.Type] = false;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = lavaDeath;
		TileObjectData.newTile.Width = width;
		TileObjectData.newTile.Height = height;
		TileObjectData.newTile.CoordinateHeights = coordinateHeights;
		TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
		TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.RandomStyleRange = styleRange;
		TileObjectData.newTile.AnchorValidTiles = new int[] { grass };
		TileObjectData.newTile.Origin = origin;
		TileObjectData.addTile(tile.Type);
	}
	public static void QuickFurnitureTile(ModTile tile, int dust, bool topSolid, bool lavaDeath, TileObjectData tileStyle, int width, int height, int[] coordinateHeights, bool horizontal, bool bothDir, Color mapColor)
	{
		tile.DustType = dust;
		Main.tileSolidTop[tile.Type] = topSolid;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = lavaDeath;
		TileID.Sets.DisableSmartCursor[tile.Type] = true;
		TileObjectData.newTile.CopyFrom(tileStyle);
		TileObjectData.newTile.Width = width;
		TileObjectData.newTile.Height = height;
		TileObjectData.newTile.CoordinateHeights = coordinateHeights;
		TileObjectData.newTile.StyleHorizontal = horizontal;
		if (bothDir)
		{
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);
		}
		TileObjectData.addTile(tile.Type);
		LocalizedText name = tile.CreateMapEntryName();
		tile.AddMapEntry(mapColor, name);
	}
	public static void QuickGrassTile(ModTile tile, int dust, SoundStyle hitSound, float mineResist, int pick, bool light, int dirt, Color mapColor)
	{
		tile.DustType = dust;
		tile.HitSound = hitSound;
		tile.MineResist = mineResist;
		tile.MinPick = pick;
		Main.tileSolid[tile.Type] = true;
		Main.tileBlockLight[tile.Type] = true;
		Main.tileLighted[tile.Type] = light;
		TileID.Sets.Conversion.Grass[tile.Type] = true;
		TileID.Sets.Conversion.MergesWithDirtInASpecialWay[tile.Type] = true;
		TileID.Sets.Grass[tile.Type] = true;
		TileID.Sets.ChecksForMerge[tile.Type] = true;
		TileID.Sets.NeedsGrassFraming[tile.Type] = true;
		TileID.Sets.NeedsGrassFramingDirt[tile.Type] = dirt;
		TileID.Sets.CanBeDugByShovel[tile.Type] = true;
		TileID.Sets.ResetsHalfBrickPlacementAttempt[tile.Type] = true;
		TileID.Sets.DoesntPlaceWithTileReplacement[tile.Type] = true;
		TileID.Sets.SpreadOverground[tile.Type] = true;
		TileID.Sets.SpreadUnderground[tile.Type] = true;
		tile.AddMapEntry(mapColor);
	}
	public static void QuickGrassShortTile(ModTile tile, int dust, int grass, int amount)
	{
		tile.DustType = dust;
		tile.HitSound = SoundID.Grass;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileCut[tile.Type] = true;
		Main.tileSolid[tile.Type] = false;
		Main.tileMergeDirt[tile.Type] = true;
		Main.tileWaterDeath[tile.Type] = true;
		TileID.Sets.SwaysInWindBasic[tile.Type] = true;
		TileID.Sets.IgnoredByGrowingSaplings[tile.Type] = true;
		TileObjectData.newTile.Width = 1;
		TileObjectData.newTile.Height = 1;
		TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newTile.AnchorValidTiles = new int[] { grass };
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.RandomStyleRange = amount;
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.addTile(tile.Type);
		TileMaterials.SetForTileId(tile.Type, TileMaterials._materialsByName["Plant"]);
	}
	public static void QuickGrassTallTile(ModTile tile, int dust, int grass, int amount)
	{
		tile.DustType = dust;
		tile.HitSound = SoundID.Grass;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileCut[tile.Type] = true;
		Main.tileSolid[tile.Type] = false;
		Main.tileMergeDirt[tile.Type] = true;
		Main.tileWaterDeath[tile.Type] = true;
		TileID.Sets.SwaysInWindBasic[tile.Type] = true;
		TileID.Sets.IgnoredByGrowingSaplings[tile.Type] = true;
		TileObjectData.newTile.Width = 1;
		TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newTile.AnchorValidTiles = new int[] { grass };
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.RandomStyleRange = amount;
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.Origin = new Point16(0, 1);
		TileObjectData.addTile(tile.Type);
		TileMaterials.SetForTileId(tile.Type, TileMaterials._materialsByName["Plant"]);
	}
	public static void QuickOreTile(ModTile tile, int dust, SoundStyle hitSound, float mineResist, int pick, short oreFinder, Color mapColor)
    {
		tile.DustType = dust;
		tile.HitSound = hitSound;
		tile.MineResist = mineResist;
		tile.MinPick = pick;
		Main.tileSolid[tile.Type] = true;
		Main.tileBlockLight[tile.Type] = true;
		Main.tileSpelunker[tile.Type] = true;
		Main.tileOreFinderPriority[tile.Type] = oreFinder;
		LocalizedText name = tile.CreateMapEntryName();
		tile.AddMapEntry(mapColor, name);
	}
	public static void QuickPianoTile(ModTile tile, int dust, Color mapColor)
	{
		tile.AdjTiles = new int[] { TileID.Pianos };
		tile.DustType = dust;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
		TileObjectData.newTile.Origin = new Point16(1, 1);
		TileObjectData.newTile.DrawYOffset = 2;
		TileObjectData.addTile(tile.Type);
		LocalizedText name = tile.CreateMapEntryName();
		tile.AddMapEntry(mapColor, name);
	}
	public static void QuickPlatformTile(ModTile tile, int dust, Color mapColor)
	{
		tile.AdjTiles = new int[] { TileID.Platforms };
		tile.DustType = dust;
		Main.tileLighted[tile.Type] = true;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileSolidTop[tile.Type] = true;
		Main.tileSolid[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileTable[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		TileID.Sets.Platforms[tile.Type] = true;
		TileID.Sets.DisableSmartCursor[tile.Type] = true;
		TileObjectData.newTile.CoordinateHeights = new[] { 16 };
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.StyleMultiplier = 27;
		TileObjectData.newTile.StyleWrapLimit = 27;
		TileObjectData.newTile.UsesCustomCanPlace = false;
		TileObjectData.newTile.LavaDeath = true;
		TileObjectData.addTile(tile.Type);
		tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
		tile.AddMapEntry(mapColor);
	}
	public static void QuickSaplingTile(ModTile tile, int dust, int grass, int amount, Color mapColor)
	{
		tile.AdjTiles = new int[] { TileID.Saplings };
		tile.DustType = dust;
		tile.HitSound = SoundID.Grass;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		TileID.Sets.CommonSapling[tile.Type] = true;
		TileID.Sets.TreeSapling[tile.Type] = true;
		TileID.Sets.SwaysInWindBasic[tile.Type] = true;
		TileObjectData.newTile.Width = 1;
		TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.Origin = new Point16(0, 1);
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.AnchorValidTiles = new int[] { grass };
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.DrawFlipHorizontal = true;
		TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
		TileObjectData.newTile.LavaDeath = true;
		TileObjectData.newTile.RandomStyleRange = amount;
		TileObjectData.addTile(tile.Type);
		LocalizedText name = tile.CreateMapEntryName();
		tile.AddMapEntry(mapColor, name);
	}
	public static void QuickSinkTile(ModTile tile, int dust, Color mapColor)
	{
		tile.AdjTiles = new int[] { TileID.Sinks };
		tile.DustType = dust;
		TileID.Sets.CountsAsWaterSource[tile.Type] = true;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
		TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
		TileObjectData.newTile.Origin = new Point16(0, 1);
		TileObjectData.newTile.DrawYOffset = 2;
		TileObjectData.addTile(tile.Type);
		tile.AddMapEntry(mapColor, Language.GetText("MapObject.Sink"));
	}
	public static void QuickSofaTile(ModTile tile, int dust, Color mapColor)
	{
		tile.AdjTiles = new int[] { TileID.Benches };
		tile.DustType = dust;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
		TileObjectData.newTile.Origin = new Point16(1, 1);
		TileObjectData.newTile.DrawYOffset = 2;
		TileObjectData.addTile(tile.Type);
		LocalizedText name = tile.CreateMapEntryName();
		tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
		tile.AddMapEntry(mapColor, name);
	}
	public static void QuickStalagmiteTile(ModTile tile, int dust, int stone)
	{
		tile.DustType = dust;
		Main.tileSolidTop[tile.Type] = false;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = false;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
		TileObjectData.newTile.DrawYOffset = -4;
		TileObjectData.newTile.AnchorValidTiles = new int[] { stone };
		TileObjectData.addTile(tile.Type);
	}
	public static void QuickTableTile(ModTile tile, int dust, Color mapColor)
	{
		tile.AdjTiles = new int[] { TileID.Tables };
		tile.DustType = dust;
		Main.tileTable[tile.Type] = true;
		Main.tileSolidTop[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		Main.tileFrameImportant[tile.Type] = true;
		TileID.Sets.DisableSmartCursor[tile.Type] = true;
		TileID.Sets.IgnoredByNpcStepUp[tile.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
		TileObjectData.newTile.Origin = new Point16(1, 1);
		TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.addTile(tile.Type);
		tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
		tile.AddMapEntry(mapColor, Language.GetText("MapObject.Table"));
	}
	public static void QuickTileMerge(ModTile tile, int mergeTile)
	{
		Main.tileMerge[tile.Type][mergeTile] = true;
		Main.tileMerge[mergeTile][tile.Type] = true;
	}
	public static void QuickTorchTile(ModTile tile, int dust, bool waterTorch)
	{
		tile.AdjTiles = new int[] { TileID.Torches };
		tile.DustType = dust;
		Main.tileLighted[tile.Type] = true;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileSolid[tile.Type] = false;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileNoFail[tile.Type] = true;
		Main.tileWaterDeath[tile.Type] = true;
		TileID.Sets.FramesOnKillWall[tile.Type] = true;
		TileID.Sets.DisableSmartCursor[tile.Type] = true;
		TileID.Sets.DisableSmartInteract[tile.Type] = true;
		TileID.Sets.Torch[tile.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.Torches, 0));
		if (waterTorch)
		{
			TileObjectData.newSubTile.LinkedAlternates = true;
			TileObjectData.newSubTile.WaterDeath = false;
			TileObjectData.newSubTile.LavaDeath = false;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
			TileObjectData.newTile.LavaPlacement = LiquidPlacement.Allowed;
		}
		TileObjectData.addTile(tile.Type);
		tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
		tile.AddMapEntry(new Color(200, 200, 200), Language.GetText("ItemName.Torch"));
	}
	public static void QuickTrophyTile(ModTile tile)
	{
		tile.DustType = DustID.WoodFurniture;
		Main.tileFrameImportant[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		TileID.Sets.FramesOnKillWall[tile.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
		TileObjectData.addTile(tile.Type);
		tile.AddMapEntry(new Color(120, 85, 60), Language.GetText("MapObject.Trophy"));
	}
	public static void QuickVineTile(ModTile tile, int dust, Color mapColor)
	{
		tile.DustType = dust;
		tile.HitSound = SoundID.Grass;
		Main.tileCut[tile.Type] = true;
		Main.tileBlockLight[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		Main.tileNoFail[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLighted[tile.Type] = false;
		tile.AddMapEntry(mapColor);
	}
	public static void QuickWallTile(ModWall tile, int dust, SoundStyle hitSound, bool house, Color mapColor)
	{
		tile.DustType = dust;
		tile.HitSound = hitSound;
		Main.wallHouse[tile.Type] = house;
		tile.AddMapEntry(mapColor);
	}
	public static void QuickWorkbenchTile(ModTile tile, int dust, Color mapColor)
	{
		tile.AdjTiles = new int[] { TileID.WorkBenches };
		tile.DustType = dust;
		Main.tileTable[tile.Type] = true;
		Main.tileSolidTop[tile.Type] = true;
		Main.tileNoAttach[tile.Type] = true;
		Main.tileLavaDeath[tile.Type] = true;
		Main.tileFrameImportant[tile.Type] = true;
		TileID.Sets.DisableSmartCursor[tile.Type] = true;
		TileID.Sets.IgnoredByNpcStepUp[tile.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
		TileObjectData.newTile.CoordinateHeights = new[] { 18 };
		TileObjectData.addTile(tile.Type);
		tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
		tile.AddMapEntry(mapColor, Language.GetText("ItemName.WorkBench"));
	}
}

abstract class QuickBannerTile : ModTile
{
	protected abstract int BannerEnemy { get; }
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
		TileObjectData.newTile.Height = 3;
		TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.StyleWrapLimit = 111;
		TileObjectData.addTile(Type);
		AddMapEntry(Color.LightGray);
	}
	public override void NearbyEffects(int i, int j, bool closer)
	{
		if (closer)
		{
			Main.SceneMetrics.hasBanner = true;
			Main.SceneMetrics.NPCBannerBuff[BannerEnemy] = true;
		}
	}
}

abstract class QuickBedTile : ModTile
{
	protected abstract int BedDust { get; }
	protected abstract int BedItem { get; }
	protected abstract Color BedMapColor { get; }
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.Beds };
		DustType = BedDust;
		Main.tileFrameImportant[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileID.Sets.HasOutlines[Type] = true;
		TileID.Sets.CanBeSleptIn[Type] = true;
		TileID.Sets.InteractibleByNPCs[Type] = true;
		TileID.Sets.IsValidSpawnPoint[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
		TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
		TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, -2);
		TileObjectData.addTile(Type);
		AddMapEntry(BedMapColor, Language.GetText("ItemName.Bed"));
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
	}
	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;
	public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
	{
		width = 2;
		height = 2;
	}
	public override void ModifySleepingTargetInfo(int i, int j, ref TileRestingInfo info)
	{
		info.VisualOffset.Y += 4f;
	}
	public override void NumDust(int i, int j, bool fail, ref int num) => num = 1;
	public override bool RightClick(int i, int j)
	{
		Player player = Main.LocalPlayer;
		Tile tile = Framing.GetTileSafely(i, j);
		int spawnX = i - (tile.TileFrameX / 18) + (tile.TileFrameX >= 72 ? 5 : 2);
		int spawnY = j + 2;
		if (tile.TileFrameY % 38 != 0)
		{
			spawnY--;
		}
		if (!Player.IsHoveringOverABottomSideOfABed(i, j))
		{
			if (player.IsWithinSnappngRangeToTile(i, j, PlayerSleepingHelper.BedSleepingMaxDistance))
			{
				player.GamepadEnableGrappleCooldown();
				player.sleeping.StartSleeping(player, i, j);
			}
		}
		else
		{
			player.FindSpawn();
			if (player.SpawnX == spawnX && player.SpawnY == spawnY)
			{
				player.RemoveSpawn();
				Main.NewText(Language.GetTextValue("Game.SpawnPointRemoved"), byte.MaxValue, 240, 20);
			}
			else if (Player.CheckSpawn(spawnX, spawnY))
			{
				player.ChangeSpawn(spawnX, spawnY);
				Main.NewText(Language.GetTextValue("Game.SpawnPointSet"), byte.MaxValue, 240, 20);
			}
		}
		return true;
	}
	public override void MouseOver(int i, int j)
	{
		Player player = Main.LocalPlayer;
		if (!Player.IsHoveringOverABottomSideOfABed(i, j))
		{
			if (player.IsWithinSnappngRangeToTile(i, j, PlayerSleepingHelper.BedSleepingMaxDistance))
			{
				player.noThrow = 2;
				player.cursorItemIconEnabled = true;
				player.cursorItemIconID = ItemID.SleepingIcon;
			}
		}
		else
		{
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = BedItem;
		}
	}
}

abstract class QuickCampfireTile : ModTile
{
	private Asset<Texture2D> flameTexture;
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.Campfire };
		DustType = -1;
		Main.tileLighted[Type] = true;
		Main.tileFrameImportant[Type] = true;
		Main.tileWaterDeath[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileID.Sets.HasOutlines[Type] = true;
		TileID.Sets.InteractibleByNPCs[Type] = true;
		TileID.Sets.Campfire[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.Campfire, 0));
		TileObjectData.newTile.StyleLineSkip = 9;
		TileObjectData.addTile(Type);
		AddMapEntry(new Color(254, 121, 2), Language.GetText("ItemName.Campfire"));
		if (!Main.dedServ)
			flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
	}
	public override void NearbyEffects(int i, int j, bool closer)
	{
		if (Main.tile[i, j].TileFrameY < 36)
			Main.SceneMetrics.HasCampfire = true;
	}
	public override void MouseOver(int i, int j)
	{
		Main.LocalPlayer.noThrow = 2;
		Main.LocalPlayer.cursorItemIconEnabled = true;
		Main.LocalPlayer.cursorItemIconID = TileLoader.GetItemDropFromTypeAndStyle(Type, TileObjectData.GetTileStyle(Main.tile[i, j]));
	}
	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;
	public override bool RightClick(int i, int j)
	{
		SoundEngine.PlaySound(SoundID.Mech, new Vector2(i * 16, j * 16));
		ToggleTile(i, j);
		return true;
	}
	public override void HitWire(int i, int j) => ToggleTile(i, j);
	public static void ToggleTile(int i, int j)
	{
		Tile tile = Main.tile[i, j];
		int topX = i - tile.TileFrameX % 54 / 18;
		int topY = j - tile.TileFrameY % 36 / 18;
		short frameAdjustment = (short)(tile.TileFrameY >= 36 ? -36 : 36);
		for (int x = topX; x < topX + 3; x++)
		{
			for (int y = topY; y < topY + 2; y++)
			{
				Main.tile[x, y].TileFrameY += frameAdjustment;

				if (Wiring.running)
				{
					Wiring.SkipWire(x, y);
				}
			}
		}
		if (Main.netMode != NetmodeID.SinglePlayer)
		{
			NetMessage.SendTileSquare(-1, topX, topY, 3, 2);
		}
	}
	public override void AnimateTile(ref int frame, ref int frameCounter)
	{
		if (++frameCounter >= 4)
		{
			frameCounter = 0;
			frame = ++frame % 8;
		}
	}
	public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
	{
		var tile = Main.tile[i, j];
		if (tile.TileFrameY < 36)
			frameYOffset = Main.tileFrame[type] * 36;
		else
			frameYOffset = 252;
	}
	public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
	{
		if (Main.gamePaused || !Main.instance.IsActive)
			return;
		if (!Lighting.UpdateEveryFrame || new FastRandom(Main.TileFrameSeed).WithModifier(i, j).Next(4) == 0)
		{
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameY == 0 && Main.rand.NextBool(3) && ((Main.drawToScreen && Main.rand.NextBool(4)) || !Main.drawToScreen))
			{
				Dust dust = Dust.NewDustDirect(new Vector2(i * 16 + 2, j * 16 - 4), 4, 8, DustID.Smoke, 0f, 0f, 100);
				if (tile.TileFrameX == 0)
					dust.position.X += Main.rand.Next(8);
				if (tile.TileFrameX == 36)
					dust.position.X -= Main.rand.Next(8);
				dust.alpha += Main.rand.Next(100);
				dust.velocity *= 0.2f;
				dust.velocity.Y -= 0.5f + Main.rand.Next(10) * 0.1f;
				dust.fadeIn = 0.5f + Main.rand.Next(10) * 0.1f;
			}
		}
	}
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Main.tile[i, j];
		if (tile.TileFrameY < 36)
		{
			float pulse = Main.rand.Next(28, 42) * 0.005f;
			pulse += (270 - Main.mouseTextColor) / 700f;
			r = 0.1f + pulse;
			g = 0.9f + pulse;
			b = 0.3f + pulse;
		}
	}
	public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
	{
		var tile = Main.tile[i, j];
		if (!TileDrawing.IsVisible(tile))
			return;
		if (tile.TileFrameY < 36)
		{
			var color = new Color(255, 255, 255, 0);
			var zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen)
				zero = Vector2.Zero;
			int width = 16;
			int offsetY = 0;
			int height = 16;
			short frameX = tile.TileFrameX;
			short frameY = tile.TileFrameY;
			int addFrX = 0;
			int addFrY = 0;
			TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);
			TileLoader.SetAnimationFrame(Type, i, j, ref addFrX, ref addFrY);
			var drawRectangle = new Rectangle(tile.TileFrameX, tile.TileFrameY + addFrY, 16, 16);
			spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y + offsetY) + zero, drawRectangle, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}
	}
}

abstract class QuickCandelabraTile : ModTile
{
	protected abstract int CandelabraDust { get; }
	protected abstract int CandelabraItem { get; }
	protected abstract Color CandelabraMapColor { get; }
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.Candelabras };
		DustType = CandelabraItem;
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileLighted[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
		TileObjectData.newTile.WaterDeath = true;
		TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
		TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
		TileObjectData.newTile.DrawYOffset = 2;
		TileObjectData.newTile.StyleLineSkip = 2;
		TileObjectData.addTile(Type);
		LocalizedText name = CreateMapEntryName();
		AddMapEntry(CandelabraMapColor, name);
		RegisterItemDrop(CandelabraItem);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
	}
	public override void HitWire(int i, int j)
	{
		int left = i - Main.tile[i, j].TileFrameX / 18 % 2;
		int top = j - Main.tile[i, j].TileFrameY / 18 % 2;
		for (int x = left; x < left + 2; x++)
		{
			for (int y = top; y < top + 2; y++)
			{
				if (Main.tile[x, y].TileFrameX >= 36)
					Main.tile[x, y].TileFrameX -= 36;
				else
					Main.tile[x, y].TileFrameX += 36;
			}
		}
		if (Wiring.running)
		{
			Wiring.SkipWire(left, top);
			Wiring.SkipWire(left, top + 1);
			Wiring.SkipWire(left + 1, top);
			Wiring.SkipWire(left + 1, top + 1);
		}
		NetMessage.SendTileSquare(-1, left, top + 1, 2);
	}
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		if (tile.TileFrameX < 36)
		{
			r = 0.7f;
			g = 0.7f;
			b = 0.7f;
		}
	}
	public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);
		if (Main.drawToScreen)
			zero = Vector2.Zero;
		int height = tile.TileFrameY == 36 ? 18 : 16;
		ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i);
		Color color = new(100, 100, 100, 0);
		for (int k = 0; k < 7; k++)
		{
			float xx = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
			float yy = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
			Main.spriteBatch.Draw(ModContent.Request<Texture2D>(Texture + "_Glow").Value, new Vector2((i * 16) - (int)Main.screenPosition.X + xx, (j * 16) - (int)Main.screenPosition.Y + yy) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}
	}
}

abstract class QuickCandleTile : ModTile
{
	protected abstract int CandleDust { get; }
	protected abstract int CandleItem { get; }
	protected abstract Color CandleMapColor { get; }
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.Candles };
		DustType = CandleDust;
		Main.tileFrameImportant[Type] = true;
		Main.tileLavaDeath[Type] = true;
		Main.tileLighted[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
		TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.WaterDeath = true;
		TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
		TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
		TileObjectData.newTile.StyleLineSkip = 2;
		TileObjectData.addTile(Type);
		LocalizedText name = CreateMapEntryName();
		AddMapEntry(CandleMapColor, name);
		RegisterItemDrop(CandleItem);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
	}
	public override void HitWire(int i, int j)
	{
		if (Main.tile[i, j].TileFrameX >= 18)
			Main.tile[i, j].TileFrameX -= 18;
		else
			Main.tile[i, j].TileFrameX += 18;
	}
	public override bool RightClick(int i, int j)
	{
		if (Main.tile[i, j].TileFrameX >= 18)
			Main.tile[i, j].TileFrameX -= 18;
		else
			Main.tile[i, j].TileFrameX += 18;
		return true;
	}
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	public override void MouseOver(int i, int j)
	{
		Player player = Main.LocalPlayer;
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
		player.cursorItemIconID = CandleItem;
	}
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		if (tile.TileFrameX < 18)
		{
			r = 0.7f;
			g = 0.7f;
			b = 0.7f;
		}
	}
	public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);
		if (Main.drawToScreen)
		{
			zero = Vector2.Zero;
		}
		int height = tile.TileFrameY == 36 ? 18 : 16;
		ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i);
		Color color = new(100, 100, 100, 0);
		for (int k = 0; k < 7; k++)
		{
			float xx = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
			float yy = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
			Main.spriteBatch.Draw(ModContent.Request<Texture2D>(Texture + "_Glow").Value, new Vector2((i * 16) - (int)Main.screenPosition.X + xx, (j * 16) - (int)Main.screenPosition.Y + yy) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}
	}
}

abstract class QuickChairTile : ModTile
{
	protected abstract int ChairDust { get; }
	protected abstract int ChairItem { get; }
	protected abstract Color ChairMapColor { get; }
	public const int NextStyleHeight = 40;
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.Chairs };
		DustType = ChairDust;
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;
		TileID.Sets.HasOutlines[Type] = true;
		TileID.Sets.CanBeSatOnForNPCs[Type] = true;
		TileID.Sets.CanBeSatOnForPlayers[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
		TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
		TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
		TileObjectData.newTile.StyleWrapLimit = 2;
		TileObjectData.newTile.StyleMultiplier = 2;
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.DrawYOffset = 2;
		TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
		TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
		TileObjectData.addAlternate(1);
		TileObjectData.addTile(Type);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
		AddMapEntry(ChairMapColor, Language.GetText("MapObject.Chair"));
	}
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance);
	public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
	{
		info.TargetDirection = -1;
		if (Framing.GetTileSafely(i, j).TileFrameX != 0)
			info.TargetDirection = 1;
		info.AnchorTilePosition.X = i;
		info.AnchorTilePosition.Y = j;
		if (Framing.GetTileSafely(i, j).TileFrameY % NextStyleHeight == 0)
			info.AnchorTilePosition.Y++;
	}
	public override bool RightClick(int i, int j)
	{
		if (Main.LocalPlayer.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
		{
			Main.LocalPlayer.GamepadEnableGrappleCooldown();
			Main.LocalPlayer.sitting.SitDown(Main.LocalPlayer, i, j);
		}
		return true;
	}
	public override void MouseOver(int i, int j)
	{
		if (!Main.LocalPlayer.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
			return;
		Main.LocalPlayer.noThrow = 2;
		Main.LocalPlayer.cursorItemIconEnabled = true;
		Main.LocalPlayer.cursorItemIconID = ChairItem;
		if (Main.tile[i, j].TileFrameX / 18 < 1)
			Main.LocalPlayer.cursorItemIconReversed = true;
	}
}

abstract class QuickChandelierTile : ModTile
{
	protected abstract int ChandelierDust { get; }
	protected abstract int ChandelierItem { get; }
	protected abstract Color ChandelierMapColor { get; }
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.Chandeliers };
		DustType = ChandelierDust;
		Main.tileLighted[Type] = true;
		Main.tileFrameImportant[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
		TileObjectData.newTile.Origin = new Point16(1, 0);
		TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 1, 1);
		TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
		TileObjectData.newTile.WaterDeath = true;
		TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
		TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
		TileObjectData.newTile.StyleLineSkip = 2;
		TileObjectData.newTile.LavaDeath = true;
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.addTile(Type);
		AddMapEntry(ChandelierMapColor, Language.GetText("MapObject.Chandelier"));
		RegisterItemDrop(ChandelierItem);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
	}
	public override void HitWire(int i, int j)
	{
		int left = i - Main.tile[i, j].TileFrameX / 18 % 3;
		int top = j - Main.tile[i, j].TileFrameY / 18 % 3;
		for (int x = left; x < left + 3; x++)
		{
			for (int y = top; y < top + 3; y++)
			{
				if (Main.tile[x, y].TileFrameX >= 54)
					Main.tile[x, y].TileFrameX -= 54;
				else
					Main.tile[x, y].TileFrameX += 54;
			}
		}
		if (Wiring.running)
		{
			Wiring.SkipWire(left, top);
			Wiring.SkipWire(left, top + 1);
			Wiring.SkipWire(left + 1, top);
			Wiring.SkipWire(left + 1, top + 1);
		}
		NetMessage.SendTileSquare(-1, left, top + 1, 2);
	}
	public override void NumDust(int i, int j, bool fail, ref int num)
	{
		num = fail ? 1 : 3;
	}
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		if (tile.TileFrameX < 36)
		{
			r = 0.7f;
			g = 0.7f;
			b = 0.7f;
		}
	}
	public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);
		if (Main.drawToScreen)
		{
			zero = Vector2.Zero;
		}
		int height = tile.TileFrameY == 36 ? 18 : 16;
		ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i);
		Color color = new(100, 100, 100, 0);
		for (int k = 0; k < 7; k++)
		{
			float xx = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
			float yy = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
			Main.spriteBatch.Draw(ModContent.Request<Texture2D>(Texture + "_Glow").Value, new Vector2((i * 16) - (int)Main.screenPosition.X + xx, (j * 16) - (int)Main.screenPosition.Y + yy) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}
	}
}

abstract class QuickChestTile : ModTile
{
	protected abstract int ChestDust { get; }
	protected abstract int ChestItem { get; }
	protected abstract Color ChestMapColor { get; }
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.Containers };
		DustType = ChestDust;
		Main.tileSpelunker[Type] = true;
		Main.tileContainer[Type] = true;
		Main.tileShine2[Type] = true;
		Main.tileShine[Type] = 1200;
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileOreFinderPriority[Type] = 500;
		TileID.Sets.HasOutlines[Type] = true;
		TileID.Sets.BasicChest[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;
		TileID.Sets.AvoidedByNPCs[Type] = true;
		TileID.Sets.InteractibleByNPCs[Type] = true;
		TileID.Sets.IsAContainer[Type] = true;
		TileID.Sets.FriendlyFairyCanLureTo[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
		TileObjectData.newTile.Origin = new Point16(0, 1);
		TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
		TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
		TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
		TileObjectData.newTile.AnchorInvalidTiles = new int[] { TileID.MagicalIceBlock, TileID.Boulder, TileID.BouncyBoulder, TileID.LifeCrystalBoulder, TileID.RollingCactus };
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
		TileObjectData.addTile(Type);
		LocalizedText name = CreateMapEntryName();
		AddMapEntry(ChestMapColor, name, MapChestName);
	}
	public override LocalizedText DefaultContainerName(int frameX, int frameY) => this.GetLocalization("MapEntry");
	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;
	public override bool IsLockedChest(int i, int j) => false;
	public static string MapChestName(string name, int i, int j)
	{
		int left = i;
		int top = j;
		Tile tile = Main.tile[i, j];
		if (tile.TileFrameX % 36 != 0)
			left--;
		if (tile.TileFrameY != 0)
			top--;
		int chest = Chest.FindChest(left, top);
		if (chest < 0)
			return Language.GetTextValue("LegacyChestType.0");

		if (Main.chest[chest].name == "")
			return name;
		return name + ": " + Main.chest[chest].name;
	}
	public override void NumDust(int i, int j, bool fail, ref int num) => num = 1;
	public override void KillMultiTile(int i, int j, int frameX, int frameY) => Chest.DestroyChest(i, j);
	public override bool RightClick(int i, int j)
	{
		Player player = Main.LocalPlayer;
		Tile tile = Main.tile[i, j];
		Main.mouseRightRelease = false;
		int left = i;
		int top = j;
		if (tile.TileFrameX % 36 != 0)
			left--;
		if (tile.TileFrameY != 0)
			top--;
		player.CloseSign();
		player.SetTalkNPC(-1);
		Main.npcChatCornerItem = 0;
		Main.npcChatText = "";
		if (Main.editChest)
		{
			SoundEngine.PlaySound(SoundID.MenuTick);
			Main.editChest = false;
			Main.npcChatText = string.Empty;
		}
		if (player.editedChestName)
		{
			NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
			player.editedChestName = false;
		}
		if (Main.netMode == NetmodeID.MultiplayerClient)
		{
			if (left == player.chestX && top == player.chestY && player.chest != -1)
			{
				player.chest = -1;
				Recipe.FindRecipes();
				SoundEngine.PlaySound(SoundID.MenuClose);
			}
			else
			{
				NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, top);
				Main.stackSplit = 600;
			}
		}
		else
		{
			int chest = Chest.FindChest(left, top);
			if (chest != -1)
			{
				Main.stackSplit = 600;
				if (chest == player.chest)
				{
					player.chest = -1;
					SoundEngine.PlaySound(SoundID.MenuClose);
				}
				else
				{
					SoundEngine.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
					player.OpenChest(left, top, chest);
				}
				Recipe.FindRecipes();
			}
		}
		return true;
	}
	public override void MouseOver(int i, int j)
	{
		Player player = Main.LocalPlayer;
		Tile tile = Main.tile[i, j];
		int left = i;
		int top = j;
		if (tile.TileFrameX % 36 != 0)
			left--;
		if (tile.TileFrameY != 0)
			top--;

		int chest = Chest.FindChest(left, top);
		player.cursorItemIconID = -1;
		if (chest < 0)
			player.cursorItemIconText = Language.GetTextValue("LegacyChestType.0");
		else
		{
			string defaultName = TileLoader.DefaultContainerName(tile.TileType, tile.TileFrameX, tile.TileFrameY);
			player.cursorItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : defaultName;
			if (player.cursorItemIconText == defaultName)
			{
				player.cursorItemIconID = ChestItem;
				player.cursorItemIconText = "";
			}
		}
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
	}
	public override void MouseOverFar(int i, int j)
	{
		MouseOver(i, j);
		Player player = Main.LocalPlayer;
		if (player.cursorItemIconText == "")
		{
			player.cursorItemIconEnabled = false;
			player.cursorItemIconID = 0;
		}
	}
}

abstract class QuickClockTile : ModTile
{
	protected abstract int ClockDust { get; }
	protected abstract Color ClockMapColor { get; }
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.GrandfatherClocks };
		DustType = ClockDust;
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileID.Sets.Clock[Type] = true;
		TileID.Sets.HasOutlines[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
		TileObjectData.newTile.Height = 5;
		TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16, 16 };
		TileObjectData.newTile.Origin = new Point16(0, 4);
		TileObjectData.addTile(Type);
		AddMapEntry(ClockMapColor, Language.GetText("ItemName.GrandfatherClock"));
	}
	public override bool RightClick(int x, int y)
	{
		string text = "AM";
		double time = Main.time;
		if (!Main.dayTime)
		{
			time += 54000.0;
		}
		time = time / 86400.0 * 24.0;
		time = time - 7.5 - 12.0;
		if (time < 0.0)
		{
			time += 24.0;
		}
		if (time >= 12.0)
		{
			text = "PM";
		}
		int intTime = (int)time;
		double deltaTime = time - intTime;
		deltaTime = (int)(deltaTime * 60.0);
		string text2 = string.Concat(deltaTime);
		if (deltaTime < 10.0)
		{
			text2 = "0" + text2;
		}
		if (intTime > 12)
		{
			intTime -= 12;
		}
		if (intTime == 0)
		{
			intTime = 12;
		}
		Main.NewText($"Time: {intTime}:{text2} {text}", 255, 240, 20);
		return true;
	}
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}

abstract class QuickDimensionPylonTile : ModPylon
{
	protected abstract int PylonCrystal { get; }
	protected abstract bool PylonDimension { get; }
	protected abstract bool PylonEnter { get; }
	protected abstract int PylonItem { get; }
	protected abstract Color PylonMapColor { get; }
	public bool IsCrystal = false;
	public const int CrystalVerticalFrameCount = 8;
	public Asset<Texture2D> crystalTexture;
	public Asset<Texture2D> crystalHighlightTexture;
	public override void SetStaticDefaults()
	{
		Main.tileLighted[Type] = true;
		Main.tileFrameImportant[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.newTile.DrawYOffset = 2;
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(ModContent.GetInstance<SimplePylonTileEntity>().PlacementPreviewHook_CheckIfCanPlace, 1, 0, true);
		TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<SimplePylonTileEntity>().Hook_AfterPlacement, -1, 0, false);
		TileObjectData.addTile(Type);
		TileID.Sets.InteractibleByNPCs[Type] = true;
		TileID.Sets.PreventsSandfall[Type] = true;
		TileID.Sets.AvoidedByMeteorLanding[Type] = true;
		AddToArray(ref TileID.Sets.CountsAsPylon);
		LocalizedText pylonName = CreateMapEntryName();
		AddMapEntry(PylonMapColor, pylonName);
	}
	public override void MouseOver(int i, int j)
	{
		Main.LocalPlayer.cursorItemIconEnabled = true;
		if (IsCrystal == true || PylonDimension == true)
			Main.LocalPlayer.cursorItemIconID = PylonItem;
		else
			Main.LocalPlayer.cursorItemIconID = PylonCrystal;
	}
	public override bool RightClick(int i, int j)
	{
		if (IsCrystal == true || PylonDimension == true)
		{
			if (!SubworldSystem.AnyActive<EndlessContinuum>())
			{
				Main.rand = new UnifiedRandom();
				return PylonEnter;
			}
			if (PylonDimension == true)
				SubworldSystem.Exit();
		}
		if (Main.player[Main.myPlayer].HasItem(PylonCrystal))
			IsCrystal = true;
		return false;
	}
	public override bool CanKillTile(int i, int j, ref bool blockDamaged)
	{
		if (IsCrystal == true || PylonDimension == true)
			return true;
		return false;
	}
	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		if (IsCrystal == true || PylonDimension == true)
			ModContent.GetInstance<SimplePylonTileEntity>().Kill(i, j);
	}
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		if (IsCrystal == true || PylonDimension == true)
			r = g = b = 0.75f;
	}
	public override void SpecialDraw(int i, int j, SpriteBatch spriteBatch)
	{
		if (IsCrystal == true || PylonDimension == true)
			DefaultDrawPylonCrystal(spriteBatch, i, j, crystalTexture, crystalHighlightTexture, new Vector2(0f, -12f), Color.White * 0.1f, Color.White, 1, CrystalVerticalFrameCount);
	}
}

public sealed class SimplePylonTileEntity : TEModdedPylon { }

abstract class QuickDoorClosed : ModTile
{
	protected abstract int DoorDust { get; }
	protected abstract int DoorItem { get; }
	protected abstract Color DoorMapColor { get; }
	protected abstract int DoorOpen { get; }
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.ClosedDoor };
		DustType = DoorDust;
		Main.tileFrameImportant[Type] = true;
		Main.tileBlockLight[Type] = true;
		Main.tileSolid[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileID.Sets.NotReallySolid[Type] = true;
		TileID.Sets.DrawsWalls[Type] = true;
		TileID.Sets.HasOutlines[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;
		TileID.Sets.OpenDoorID[Type] = DoorOpen;
		TileObjectData.newTile.Width = 1;
		TileObjectData.newTile.Height = 3;
		TileObjectData.newTile.Origin = new Point16(0, 0);
		TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newTile.LavaDeath = true;
		TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.StyleLineSkip = 3;
		TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
		TileObjectData.newAlternate.Origin = new Point16(0, 1);
		TileObjectData.addAlternate(0);
		TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
		TileObjectData.newAlternate.Origin = new Point16(0, 2);
		TileObjectData.addAlternate(0);
		TileObjectData.addTile(Type);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
		AddMapEntry(DoorMapColor, Language.GetText("MapObject.Door"));
	}
	public override bool Slope(int i, int j) => false;
	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;
	public override void NumDust(int i, int j, bool fail, ref int num) => num = 1;
	public override void MouseOver(int i, int j)
	{
		Player player = Main.LocalPlayer;
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
		player.cursorItemIconID = DoorItem;
	}
}

abstract class QuickDoorOpen : ModTile
{
	protected abstract int DoorClosed { get; }
	protected abstract int DoorDust { get; }
	protected abstract int DoorItem { get; }
	protected abstract Color DoorMapColor { get; }
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.OpenDoor };
		DustType = DoorDust;
		Main.tileFrameImportant[Type] = true;
		Main.tileSolid[Type] = false;
		Main.tileLavaDeath[Type] = true;
		Main.tileNoSunLight[Type] = true;
		TileID.Sets.HousingWalls[Type] = true;
		TileID.Sets.HasOutlines[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;
		TileID.Sets.CloseDoorID[Type] = DoorClosed;
		TileObjectData.newTile.Width = 2;
		TileObjectData.newTile.Height = 3;
		TileObjectData.newTile.Origin = new Point16(0, 0);
		TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 0);
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 0);
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newTile.LavaDeath = true;
		TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.StyleMultiplier = 2;
		TileObjectData.newTile.StyleWrapLimit = 2;
		TileObjectData.newTile.Direction = TileObjectDirection.PlaceRight;
		TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
		TileObjectData.newAlternate.Origin = new Point16(0, 1);
		TileObjectData.addAlternate(0);
		TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
		TileObjectData.newAlternate.Origin = new Point16(0, 2);
		TileObjectData.addAlternate(0);
		TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
		TileObjectData.newAlternate.Origin = new Point16(1, 0);
		TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
		TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
		TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
		TileObjectData.addAlternate(1);
		TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
		TileObjectData.newAlternate.Origin = new Point16(1, 1);
		TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
		TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
		TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
		TileObjectData.addAlternate(1);
		TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
		TileObjectData.newAlternate.Origin = new Point16(1, 2);
		TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
		TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
		TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
		TileObjectData.addAlternate(1);
		TileObjectData.addTile(Type);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
		RegisterItemDrop(DoorItem, 0);
		AddMapEntry(DoorMapColor, Language.GetText("MapObject.Door"));
	}
	public override bool Slope(int i, int j) => false;
	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;
	public override void NumDust(int i, int j, bool fail, ref int num) => num = 1;
	public override void MouseOver(int i, int j)
	{
		Player player = Main.LocalPlayer;
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
		player.cursorItemIconID = DoorItem;
	}
}

abstract class QuickDresserTile : ModTile
{
	protected abstract int DresserDust { get; }
	protected abstract int DresserItem { get; }
	protected abstract Color DresserMapColor { get; }
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.Dressers };
		DustType = DresserDust;
		Main.tileSolidTop[Type] = true;
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileTable[Type] = true;
		Main.tileContainer[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileID.Sets.HasOutlines[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;
		TileID.Sets.BasicDresser[Type] = true;
		TileID.Sets.AvoidedByNPCs[Type] = true;
		TileID.Sets.InteractibleByNPCs[Type] = true;
		TileID.Sets.IsAContainer[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
		TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
		TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
		TileObjectData.newTile.AnchorInvalidTiles = new int[] { TileID.MagicalIceBlock, TileID.Boulder, TileID.BouncyBoulder, TileID.LifeCrystalBoulder, TileID.RollingCactus };
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.addTile(Type);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
		AddMapEntry(DresserMapColor, CreateMapEntryName(), MapChestName);
	}
	public override LocalizedText DefaultContainerName(int frameX, int frameY) => CreateMapEntryName();
	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;
	public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
	{
		width = 3;
		height = 1;
		extraY = 0;
	}
	public override bool RightClick(int i, int j)
	{
		Player player = Main.LocalPlayer;
		int left = Main.tile[i, j].TileFrameX / 18;
		left %= 3;
		left = i - left;
		int top = j - Main.tile[i, j].TileFrameY / 18;
		if (Main.tile[i, j].TileFrameY == 0)
		{
			Main.CancelClothesWindow(true);
			Main.mouseRightRelease = false;
			player.CloseSign();
			player.SetTalkNPC(-1);
			Main.npcChatCornerItem = 0;
			Main.npcChatText = "";
			if (Main.editChest)
			{
				SoundEngine.PlaySound(SoundID.MenuTick);
				Main.editChest = false;
				Main.npcChatText = string.Empty;
			}
			if (player.editedChestName)
			{
				NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
				player.editedChestName = false;
			}
			if (Main.netMode == NetmodeID.MultiplayerClient)
			{
				if (left == player.chestX && top == player.chestY && player.chest != -1)
				{
					player.chest = -1;
					Recipe.FindRecipes();
					SoundEngine.PlaySound(SoundID.MenuClose);
				}
				else
				{
					NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, top);
					Main.stackSplit = 600;
				}
			}
			else
			{
				player.piggyBankProjTracker.Clear();
				player.voidLensChest.Clear();
				int chestIndex = Chest.FindChest(left, top);
				if (chestIndex != -1)
				{
					Main.stackSplit = 600;
					if (chestIndex == player.chest)
					{
						player.chest = -1;
						Recipe.FindRecipes();
						SoundEngine.PlaySound(SoundID.MenuClose);
					}
					else if (chestIndex != player.chest && player.chest == -1)
					{
						player.OpenChest(left, top, chestIndex);
						SoundEngine.PlaySound(SoundID.MenuOpen);
					}
					else
					{
						player.OpenChest(left, top, chestIndex);
						SoundEngine.PlaySound(SoundID.MenuTick);
					}
					Recipe.FindRecipes();
				}
			}
		}
		else
		{
			Main.playerInventory = false;
			player.chest = -1;
			Recipe.FindRecipes();
			player.SetTalkNPC(-1);
			Main.npcChatCornerItem = 0;
			Main.npcChatText = "";
			Main.interactedDresserTopLeftX = left;
			Main.interactedDresserTopLeftY = top;
			Main.OpenClothesWindow();
		}
		return true;
	}
	public void MouseOverNearAndFarSharedLogic(Player player, int i, int j)
	{
		Tile tile = Main.tile[i, j];
		int left = i;
		int top = j;
		left -= tile.TileFrameX % 54 / 18;
		if (tile.TileFrameY % 36 != 0)
		{
			top--;
		}
		int chestIndex = Chest.FindChest(left, top);
		player.cursorItemIconID = -1;
		if (chestIndex < 0)
		{
			player.cursorItemIconText = Language.GetTextValue("LegacyDresserType.0");
		}
		else
		{
			string defaultName = TileLoader.DefaultContainerName(tile.TileType, tile.TileFrameX, tile.TileFrameY);
			if (Main.chest[chestIndex].name != "")
			{
				player.cursorItemIconText = Main.chest[chestIndex].name;
			}
			else
			{
				player.cursorItemIconText = defaultName;
			}
			if (player.cursorItemIconText == defaultName)
			{
				player.cursorItemIconID = DresserItem;
				player.cursorItemIconText = "";
			}
		}
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
	}
	public override void MouseOverFar(int i, int j)
	{
		Player player = Main.LocalPlayer;
		MouseOverNearAndFarSharedLogic(player, i, j);
		if (player.cursorItemIconText == "")
		{
			player.cursorItemIconEnabled = false;
			player.cursorItemIconID = 0;
		}
	}
	public override void MouseOver(int i, int j)
	{
		Player player = Main.LocalPlayer;
		MouseOverNearAndFarSharedLogic(player, i, j);
		if (Main.tile[i, j].TileFrameY > 0)
		{
			player.cursorItemIconID = ItemID.FamiliarShirt;
			player.cursorItemIconText = "";
		}
	}
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	public override void KillMultiTile(int i, int j, int frameX, int frameY) => Chest.DestroyChest(i, j);
	public static string MapChestName(string name, int i, int j)
	{
		int left = i;
		int top = j;
		Tile tile = Main.tile[i, j];
		if (tile.TileFrameX % 36 != 0)
		{
			left--;
		}
		if (tile.TileFrameY != 0)
		{
			top--;
		}
		int chest = Chest.FindChest(left, top);
		if (chest < 0)
		{
			return Language.GetTextValue("LegacyDresserType.0");
		}
		if (Main.chest[chest].name == "")
		{
			return name;
		}
		return name + ": " + Main.chest[chest].name;
	}
}

abstract class QuickHerbTile : ModTile
{
	public enum PlantStage : byte { Planted, Growing, Grown }
	private const int FrameWidth = 18;
	protected abstract int Herb { get; }
	protected abstract int Seeds { get; }
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[Type] = true;
		Main.tileObsidianKill[Type] = true;
		Main.tileCut[Type] = true;
		Main.tileNoFail[Type] = true;
		TileID.Sets.ReplaceTileBreakUp[Type] = true;
		TileID.Sets.IgnoredInHouseScore[Type] = true;
		TileID.Sets.IgnoredByGrowingSaplings[Type] = true;
		TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Plant"]);
		LocalizedText name = CreateMapEntryName();
		AddMapEntry(new Color(128, 128, 128), name);
		TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
		TileObjectData.newTile.AnchorValidTiles = new int[] { TileID.Grass, TileID.HallowedGrass };
		TileObjectData.newTile.AnchorAlternateTiles = new int[] { TileID.ClayPot, TileID.PlanterBox };
		TileObjectData.addTile(Type);
		HitSound = SoundID.Grass;
		DustType = DustID.Ambient_DarkBrown;
	}
	public override bool CanPlace(int i, int j)
	{
		Tile tile = Framing.GetTileSafely(i, j); 
		if (tile.HasTile)
		{
			int tileType = tile.TileType;
			if (tileType == Type)
			{
				PlantStage stage = GetStage(i, j);
				return stage == PlantStage.Grown;
			}
			else
			{
				if (Main.tileCut[tileType] || TileID.Sets.BreakableWhenPlacing[tileType] || tileType == TileID.WaterDrip || tileType == TileID.LavaDrip || tileType == TileID.HoneyDrip || tileType == TileID.SandDrip)
				{
					bool foliageGrass = tileType == TileID.Plants || tileType == TileID.Plants2;
					bool moddedFoliage = tileType >= TileID.Count && (Main.tileCut[tileType] || TileID.Sets.BreakableWhenPlacing[tileType]);
					bool harvestableVanillaHerb = Main.tileAlch[tileType] && WorldGen.IsHarvestableHerbWithSeed(tileType, tile.TileFrameX / 18);

					if (foliageGrass || moddedFoliage || harvestableVanillaHerb)
					{
						WorldGen.KillTile(i, j);
						if (!tile.HasTile && Main.netMode == NetmodeID.MultiplayerClient)
						{
							NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j);
						}

						return true;
					}
				}

				return false;
			}
		}
		return true;
	}
	public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects) { if (i % 2 == 0) { spriteEffects = SpriteEffects.FlipHorizontally; } }
	public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY) => offsetY = -2;
	public override bool CanDrop(int i, int j)
	{
		PlantStage stage = GetStage(i, j);
		if (stage == PlantStage.Planted) { return false; }
		return true;
	}
	public override IEnumerable<Item> GetItemDrops(int i, int j)
	{
		Player nearestPlayer = Main.player[Player.FindClosest(new Vector2(i, j).ToWorldCoordinates(), 16, 16)];
		int herbItemType = Herb;
		int herbItemStack = 1;
		int seedItemType = Seeds;
		int seedItemStack = 1;
		if (nearestPlayer.active && nearestPlayer.HeldItem.type == ItemID.StaffofRegrowth)
		{
			herbItemStack = Main.rand.Next(1, 2);
			seedItemStack = Main.rand.Next(1, 5);
		}
		else if (GetStage(i, j) == PlantStage.Grown)
		{
			herbItemStack = 1;
			seedItemStack = Main.rand.Next(1, 3);
		}
		if (herbItemType > 0 && herbItemStack > 0) { yield return new Item(herbItemType, herbItemStack); }
		if (seedItemType > 0 && seedItemStack > 0) { yield return new Item(seedItemType, seedItemStack); }
	}
	public override bool IsTileSpelunkable(int i, int j)
	{
		PlantStage stage = GetStage(i, j);
		return stage == PlantStage.Grown;
	}
	public override void RandomUpdate(int i, int j)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		PlantStage stage = GetStage(i, j);
		if (stage != PlantStage.Grown)
		{
			tile.TileFrameX += FrameWidth;
			if (Main.netMode != NetmodeID.SinglePlayer) { NetMessage.SendTileSquare(-1, i, j, 1); }
		}
	}
	private static PlantStage GetStage(int i, int j)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		return (PlantStage)(tile.TileFrameX / FrameWidth);
	}
}

abstract class QuickLampTile : ModTile
{
	protected abstract int LampDust { get; }
	protected abstract int LampItem { get; }
	protected abstract Color LampMapColor { get; }
	public override void SetStaticDefaults()
	{
		DustType = LampDust;
		Main.tileLighted[Type] = true;
		Main.tileFrameImportant[Type] = true;
		Main.tileLavaDeath[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileWaterDeath[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
		TileObjectData.newTile.Height = 3;
		TileObjectData.newTile.Origin = new Point16(0, 2);
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newTile.LavaDeath = true;
		TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.WaterDeath = true;
		TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
		TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
		TileObjectData.newTile.StyleLineSkip = 2;
		TileObjectData.addTile(Type);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
		RegisterItemDrop(LampItem);
		AddMapEntry(LampMapColor, Language.GetText("MapObject.FloorLamp"));
	}
	public override void HitWire(int i, int j)
	{
		int left = i - Main.tile[i, j].TileFrameX / 18 % 1;
		int top = j - Main.tile[i, j].TileFrameY / 18 % 3;
		for (int x = left; x < left + 1; x++)
		{
			for (int y = top; y < top + 3; y++)
			{
				if (Main.tile[x, y].TileFrameX >= 18)
					Main.tile[x, y].TileFrameX -= 18;
				else
					Main.tile[x, y].TileFrameX += 18;
			}
		}
		if (Wiring.running)
		{
			Wiring.SkipWire(left, top);
			Wiring.SkipWire(left, top + 1);
			Wiring.SkipWire(left, top + 2);
		}
		NetMessage.SendTileSquare(-1, left, top + 1, 2);
	}
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		if (tile.TileFrameX < 18)
		{
			r = 0.8f;
			g = 0.6f;
			b = 0.4f;
		}
	}
	public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);
		if (Main.drawToScreen)
			zero = Vector2.Zero;
		int height = tile.TileFrameY == 36 ? 18 : 16;
		ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i);
		Color color = new(100, 100, 100, 0);
		for (int k = 0; k < 7; k++)
		{
			float xx = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
			float yy = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
			Main.spriteBatch.Draw(ModContent.Request<Texture2D>(Texture + "_Glow").Value, new Vector2((i * 16) - (int)Main.screenPosition.X + xx, (j * 16) - (int)Main.screenPosition.Y + yy) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}
	}
}

abstract class QuickLanternTile : ModTile
{
	protected abstract int LanternDust { get; }
	protected abstract int LanternItem { get; }
	protected abstract Color LanternMapColor { get; }
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.HangingLanterns };
		DustType = LanternDust;
		Main.tileLighted[Type] = true;
		Main.tileFrameImportant[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
		TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
		TileObjectData.newTile.WaterDeath = true;
		TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
		TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.StyleLineSkip = 2;
		TileObjectData.addTile(Type);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
		RegisterItemDrop(LanternItem);
		AddMapEntry(LanternMapColor, Language.GetText("MapObject.Lantern"));
	}
	public override void HitWire(int i, int j)
	{
		int left = i - Main.tile[i, j].TileFrameX / 18 % 1;
		int top = j - Main.tile[i, j].TileFrameY / 18 % 2;
		for (int x = left; x < left + 1; x++)
		{
			for (int y = top; y < top + 2; y++)
			{
				if (Main.tile[x, y].TileFrameX >= 18)
					Main.tile[x, y].TileFrameX -= 18;
				else
					Main.tile[x, y].TileFrameX += 18;
			}
		}
		if (Wiring.running)
		{
			Wiring.SkipWire(left, top);
			Wiring.SkipWire(left, top + 1);
		}
		NetMessage.SendTileSquare(-1, left, top + 1, 2);
	}
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		if (tile.TileFrameX < 18)
		{
			r = 0.8f;
			g = 0.6f;
			b = 0.4f;
		}
	}
	public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);
		if (Main.drawToScreen)
			zero = Vector2.Zero;
		int height = tile.TileFrameY == 36 ? 18 : 16;
		ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i);
		Color color = new(100, 100, 100, 0);
		for (int k = 0; k < 7; k++)
		{
			float xx = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
			float yy = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
			Main.spriteBatch.Draw(ModContent.Request<Texture2D>(Texture + "_Glow").Value, new Vector2((i * 16) - (int)Main.screenPosition.X + xx, (j * 16) - (int)Main.screenPosition.Y + yy) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}
	}
}

abstract class QuickRelicTile : ModTile
{
	public const int FrameWidth = 18 * 3;
	public const int FrameHeight = 18 * 4;
	public const int HorizontalFrames = 1;
	public const int VerticalFrames = 1;
	public Asset<Texture2D> RelicTexture;
	protected abstract string RelicTextureName { get; }
	public override string Texture { get { return "Terraria/Images/Tiles_617"; } }
	public override void Load()
	{
		if (!Main.dedServ)
		{
			RelicTexture = ModContent.Request<Texture2D>(RelicTextureName);
		}
	}
	public override void Unload()
	{
		RelicTexture = null;
	}
	public override void SetStaticDefaults()
	{
		Main.tileShine[Type] = 400;
		Main.tileFrameImportant[Type] = true;
		TileID.Sets.InteractibleByNPCs[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.newTile.DrawYOffset = 2;
		TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
		TileObjectData.newTile.StyleHorizontal = false;
		TileObjectData.newTile.StyleWrapLimitVisualOverride = 2;
		TileObjectData.newTile.StyleMultiplier = 2;
		TileObjectData.newTile.StyleWrapLimit = 2;
		TileObjectData.newTile.styleLineSkipVisualOverride = 0;
		TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
		TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
		TileObjectData.addAlternate(1);
		TileObjectData.addTile(Type);
		AddMapEntry(new Color(233, 207, 94), Language.GetText("MapObject.Relic"));
	}
	public override bool CreateDust(int i, int j, ref int type) => false;
	public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
	{
		tileFrameX %= FrameWidth;
		tileFrameY %= FrameHeight * 2;
	}
	public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
	{
		if (drawData.tileFrameX % FrameWidth == 0 && drawData.tileFrameY % FrameHeight == 0)
		{
			Main.instance.TilesRenderer.AddSpecialLegacyPoint(i, j);
		}
	}
	public override void SpecialDraw(int i, int j, SpriteBatch spriteBatch)
	{
		var offScreen = new Vector2(Main.offScreenRange);
		if (Main.drawToScreen)
		{
			offScreen = Vector2.Zero;
		}
		var p = new Point(i, j);
		Tile tile = Main.tile[p.X, p.Y];
		if (tile == null || !tile.HasTile)
		{
			return;
		}
		Texture2D texture = RelicTexture.Value;
		int frameY = tile.TileFrameX / FrameWidth;
		Rectangle frame = texture.Frame(HorizontalFrames, VerticalFrames, 0, frameY);
		Vector2 origin = frame.Size() / 2f;
		Vector2 worldPos = p.ToWorldCoordinates(24f, 64f);
		Color color = Lighting.GetColor(p.X, p.Y);
		bool direction = tile.TileFrameY / FrameHeight != 0;
		SpriteEffects effects = direction ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
		const float TwoPi = (float)Math.PI * 2f;
		float offset = (float)Math.Sin(Main.GlobalTimeWrappedHourly * TwoPi / 5f);
		Vector2 drawPos = worldPos + offScreen - Main.screenPosition + new Vector2(0f, -40f) + new Vector2(0f, offset * 4f);
		spriteBatch.Draw(texture, drawPos, frame, color, 0f, origin, 1f, effects, 0f);
		float scale = (float)Math.Sin(Main.GlobalTimeWrappedHourly * TwoPi / 2f) * 0.3f + 0.7f;
		Color effectColor = color;
		effectColor.A = 0;
		effectColor = effectColor * 0.1f * scale;
		for (float num5 = 0f; num5 < 1f; num5 += 355f / (678f * (float)Math.PI))
		{
			spriteBatch.Draw(texture, drawPos + (TwoPi * num5).ToRotationVector2() * (6f + offset * 2f), frame, effectColor, 0f, origin, 1f, effects, 0f);
		}
	}
}

abstract class QuickToiletTile : ModTile
{
	protected abstract int ToiletDust { get; }
	protected abstract int ToiletItem { get; }
	protected abstract Color ToiletMapColor { get; }
	public const int NextStyleHeight = 40;
	public override void SetStaticDefaults()
	{
		AdjTiles = new int[] { TileID.Toilets };
		DustType = ToiletDust;
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		Main.tileLavaDeath[Type] = true;
		TileID.Sets.HasOutlines[Type] = true;
		TileID.Sets.CanBeSatOnForNPCs[Type] = true;
		TileID.Sets.CanBeSatOnForPlayers[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
		TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
		TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
		TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
		TileObjectData.newTile.StyleWrapLimit = 2;
		TileObjectData.newTile.StyleMultiplier = 2;
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
		TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
		TileObjectData.addAlternate(1);
		TileObjectData.addTile(Type);
		AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
		AddMapEntry(ToiletMapColor, Language.GetText("MapObject.Toilet"));
	}
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance);
	public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		info.TargetDirection = -1;
		if (tile.TileFrameX != 0)
		{
			info.TargetDirection = 1;
		}
		info.AnchorTilePosition.X = i;
		info.AnchorTilePosition.Y = j;
		if (tile.TileFrameY % NextStyleHeight == 0)
		{
			info.AnchorTilePosition.Y++;
		}
		if (info.RestingEntity is Player player && player.HasBuff(BuffID.Stinky))
		{
			info.VisualOffset = Main.rand.NextVector2Circular(2, 2);
		}
	}
	public override bool RightClick(int i, int j)
	{
		Player player = Main.LocalPlayer;
		if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
		{
			player.GamepadEnableGrappleCooldown();
			player.sitting.SitDown(player, i, j);
		}
		return true;
	}
	public override void MouseOver(int i, int j)
	{
		Player player = Main.LocalPlayer;
		if (!player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
		{
			return;
		}
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
		player.cursorItemIconID = ToiletItem;
		if (Main.tile[i, j].TileFrameX / 18 < 1)
		{
			player.cursorItemIconReversed = true;
		}
	}
	public override void HitWire(int i, int j)
	{
		Tile tile = Framing.GetTileSafely(i, j);
		int spawnX = i;
		int spawnY = j - tile.TileFrameY % NextStyleHeight / 18;
		Wiring.SkipWire(spawnX, spawnY);
		Wiring.SkipWire(spawnX, spawnY + 1);
		if (Wiring.CheckMech(spawnX, spawnY, 60))
		{
			Projectile.NewProjectile(Wiring.GetProjectileSource(spawnX, spawnY), spawnX * 16 + 8, spawnY * 16 + 12, 0f, 0f, ProjectileID.ToiletEffect, 0, 0f, Main.myPlayer);
		}
	}
}