using Microsoft.Xna.Framework;
using StructureHelper;
using SubworldLibrary;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace EndlessContinuum.Content.Subworlds
{
    class EnterAbyssalMines : ModItem
    {
        public override string Texture => "EndlessContinuum/Assets/Textures/Items/Test";
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
                SubworldSystem.Enter<AbyssalMines>();
            if (SubworldSystem.IsActive<AbyssalMines>())
                SubworldSystem.Exit();
            return true;
        }
    }

    class AbyssalMines : Subworld
    {
        public override int Width => 2000;
        public override int Height => 2000;
        public override bool NormalUpdates => true;
        public override bool ShouldSave => false;
        public override bool NoPlayerSaving => false;
        public override List<GenPass> Tasks => new()
        {
            new AbyssalMinesPass1("Loading", 1),
            new AbyssalMinesPass2("Loading", 2),
            new AbyssalMinesPass3("Loading", 3),
            new AbyssalMinesPass4("Loading", 4),
            new AbyssalMinesPass5("Loading", 4),
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
    class AbyssalMinesPass1 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating";
            Main.spawnTileY = 1000;
            Main.spawnTileX = 1000;
            Main.worldSurface = 0;
            Main.rockLayer = 0;
            for (int x = 0; x < Main.maxTilesX; x++)
            {
                for (int y = 0; y < Main.maxTilesY; y++)
                    WorldGen.PlaceTile(x, y, ModContent.TileType<Items.Tiles.AbyssalDirtTile>(), true);
            }
        }
        public AbyssalMinesPass1(string name, float loadWeight) : base(name, loadWeight) { }
    }
    class AbyssalMinesPass2 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating caves";
            Common.Utilities.FastNoiseLite noise = new();
            noise.SetSeed(WorldGen.genRand.Next());
            noise.SetNoiseType(Common.Utilities.FastNoiseLite.NoiseType.Perlin);
            noise.SetFractalType(Common.Utilities.FastNoiseLite.FractalType.Ridged);
            noise.SetFrequency(0.06f);
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
                        for (int i = 0; i < 5; i++)
                        {
                            if (x + i < Main.maxTilesX && y - 10 + i < Main.maxTilesY)
                            {
                                if (WorldGen.InWorld(x + i, y - 10 + i))
                                    WorldGen.KillTile(x + i, y - 10 + i, false, false, true);
                            }
                        }
                    }
                }
            }
        }
        public AbyssalMinesPass2(string name, float loadWeight) : base(name, loadWeight) { }
    }
    class AbyssalMinesPass3 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Placing stone";
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    Tile tile = Main.tile[i, j];
                    if (tile.TileType == ModContent.TileType<Items.Tiles.AbyssalDirtTile>() && TileCanBeStone(i, j))
                        tile.TileType = (ushort)ModContent.TileType<Items.Tiles.AbyssalStoneTile>();
                        if (Main.rand.NextBool(10))
                            WorldGen.PlaceObject(i, j + 2, ModContent.TileType<Items.Tiles.HangingBulbia>(), true);
                        if (Main.rand.NextBool(3))
                            WorldGen.PlaceObject(i, j + 1, ModContent.TileType<Items.Tiles.AbyssalStalagmites>(), true, Main.rand.Next(5));
                }
            }
        }
        public static bool TileCanBeStone(int i, int j)
        {
            if (WorldGen.TileEmpty(i, j + 2) || !Main.tileSolid[Main.tile[i, j + 2].TileType])
                return true;
            return false;
        }
        public AbyssalMinesPass3(string name, float loadWeight) : base(name, loadWeight) { }
    }
    class AbyssalMinesPass4 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Adding the pylon";
            Generator.GenerateStructure(ECAssets.StructuresPath + "AbyssalMinesPylonStand", new(1000, 1000), EndlessContinuum.Instance);
        }
        public AbyssalMinesPass4(string name, float loadWeight) : base(name, loadWeight) { }
    }
    class AbyssalMinesPass5 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Adding foliage";
            for (int i = 10; i < Main.maxTilesX; i++)
            {
                for (int j = 10; j < Main.maxTilesY; j++)
                {
                    Tile tile = Main.tile[i, j];
                    if (tile.TileType == ModContent.TileType<Items.Tiles.AbyssalDirtTile>() && Common.Utilities.WorldGenUtils.TileCanBeGrass(i, j))
                        tile.TileType = (ushort)ModContent.TileType<Items.Tiles.AbyssalGrassTile>();
                        if (Main.rand.NextBool(10))
                            WorldGen.PlaceObject(i - 1, j - 3, ModContent.TileType<Items.Tiles.LargeBulbia>(), true);
                        if (Main.rand.NextBool(8))
                            WorldGen.PlaceObject(i - 1, j - 2, ModContent.TileType<Items.Tiles.BulbiaTree>(), true);
                        if (Main.rand.NextBool(7))
                            WorldGen.PlaceObject(i, j - 2, ModContent.TileType<Items.Tiles.BulbiaStem>(), true);
                        if (Main.rand.NextBool(3))
                            WorldGen.PlaceObject(i, j - 1, ModContent.TileType<Items.Tiles.AbyssalGrass>(), true, Main.rand.Next(7));
                }
            }
        }
        public AbyssalMinesPass5(string name, float loadWeight) : base(name, loadWeight) { }
    }
}