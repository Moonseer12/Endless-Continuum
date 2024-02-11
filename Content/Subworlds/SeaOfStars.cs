using Microsoft.Xna.Framework;
using StructureHelper;
using SubworldLibrary;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace EndlessContinuum.Content.Subworlds
{
    class EnterSeaOfStars : ModItem
    {
        public override string Texture => "EndlessContinuum/Assets/Textures/Test";
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = 30;
            Item.noUseGraphic = true;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.UseSound = SoundID.NPCDeath62;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
        }
        public override bool? UseItem(Player player)
        {
            if (!SubworldSystem.AnyActive<EndlessContinuum>())
                SubworldSystem.Enter<SeaOfStars>();
            if (SubworldSystem.IsActive<SeaOfStars>())
                SubworldSystem.Exit();
            return true;
        }
    }

    class SeaOfStars : Subworld
    {
        public override int Width => 2000;
        public override int Height => 2000;
        public override bool NormalUpdates => true;
        public override bool ShouldSave => false;
        public override bool NoPlayerSaving => false;
        public override List<GenPass> Tasks => new()
        {
            new SeaOfStarsPass1("Loading", 1),
            new SeaOfStarsPass2("Loading", 1),
            new SeaOfStarsPass3("Loading", 1),
        };
        public override void Load()
        {
            Main.cloudAlpha = 0;
            Main.numClouds = 0;
            Main.dayTime = false;
            Main.time = 0;
            Main.rainTime = 0;
            Main.raining = false;
            Main.maxRaining = 0f;
        }
    }
    class SeaOfStarsPass1 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating";
            Main.spawnTileY = 1000;
            Main.spawnTileX = 1000;
            Main.worldSurface = 2000;
            Main.rockLayer = 2000;
            Common.Utilities.FastNoiseLite noise = new();
            noise.SetSeed(WorldGen.genRand.Next());
            noise.SetNoiseType(Common.Utilities.FastNoiseLite.NoiseType.Perlin);
            noise.SetFractalType(Common.Utilities.FastNoiseLite.FractalType.DomainWarpProgressive);
            noise.SetFrequency(0.05f);
            noise.SetFractalOctaves(1);
            float[,] noiseMap = new float[Main.maxTilesX, Main.maxTilesY];
            for (int x = 0; x < Main.maxTilesX; x++)
            {
                for (int y = 0; y < Main.maxTilesY; y++)
                    noiseMap[x, y] = noise.GetNoise(x, y);
            }
            for (int x = 0; x < Main.maxTilesX; x++)
            {
                for (int y = 0; y < Main.maxTilesY; y++)
                {
                    if (noiseMap[x, y] > .6f)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (x + i < Main.maxTilesX && y - 10 + i < Main.maxTilesY)
                            {
                                if (WorldGen.InWorld(x + i, y - 10 + i))
                                    WorldGen.PlaceTile(x + i, y - 10 + i, ModContent.TileType<Items.Tiles.CosmicSoilTile>(), true);
                            }
                        }
                    }
                }
            }
        }
        public SeaOfStarsPass1(string name, float loadWeight) : base(name, loadWeight) { }
    }

    class SeaOfStarsPass2 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating";
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    if (Main.tile[i, j].TileType == ModContent.TileType<Items.Tiles.CosmicSoilTile>() && TileCanBeDirt(i, j))
                        Main.tile[i, j].TileType = (ushort)ModContent.TileType<Items.Tiles.CosmicRockTile>();
                }
            }
        }
        public static bool TileCanBeDirt(int i, int j)
        {
            if (WorldGen.TileEmpty(i, j + 4) || !Main.tileSolid[Main.tile[i, j + 4].TileType])
                return true;
            return false;
        }
        public SeaOfStarsPass2(string name, float loadWeight) : base(name, loadWeight) { }
    }

    class SeaOfStarsPass3 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating";
            for (int i = 10; i < Main.maxTilesX; i++)
            {
                for (int j = 10; j < Main.maxTilesY; j++)
                {
                    Tile tile = Main.tile[i, j];
                    if (tile.TileType == ModContent.TileType<Items.Tiles.CosmicSoilTile>() && Common.Utilities.WorldGenUtils.TileCanBeGrass(i, j))
                    {
                        tile.TileType = (ushort)ModContent.TileType<Items.Tiles.CosmicGrassTile>();
                        if (Main.rand.Next(5) < 3)
                            WorldGen.GrowTree(i, j);
                        if (Main.rand.NextBool(3))
                            WorldGen.PlaceObject(i, j - 1, ModContent.TileType<Items.Tiles.CosmicGrass>(), true, Main.rand.Next(6));
                    }
                }
            }
        }
        public SeaOfStarsPass3(string name, float loadWeight) : base(name, loadWeight) { }
    }
}