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
		tile.AdjTiles = new int[] { TileID.Bookcases };
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
		TileObjectData.newTile.Width = 3;
		TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
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
	public void ToggleTile(int i, int j)
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
			Color color = new Color(255, 255, 255, 0);
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
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
			Rectangle drawRectangle = new Rectangle(tile.TileFrameX, tile.TileFrameY + addFrY, 16, 16);
			spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y + offsetY) + zero, drawRectangle, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
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
		DustType = ChairDust;
		AdjTiles = new int[] { TileID.Chairs };
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
		Vector2 offScreen = new Vector2(Main.offScreenRange);
		if (Main.drawToScreen)
		{
			offScreen = Vector2.Zero;
		}

		Point p = new Point(i, j);
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