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
    class EnterMyrdenshaw : ModItem
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
                SubworldSystem.Enter<Myrdenshaw>();
            if (SubworldSystem.IsActive<Myrdenshaw>())
                SubworldSystem.Exit();
            return true;
        }
    }

    class Myrdenshaw : Subworld
    {
        public override int Width => 2000;
        public override int Height => 2000;
        public override bool NormalUpdates => true;
        public override bool ShouldSave => false;
        public override bool NoPlayerSaving => false;
        public override List<GenPass> Tasks => new()
        {
            new MyrdenshawPass1("Loading", 1),
            new MyrdenshawPass2("Loading", 2),
            new MyrdenshawPass3("Loading", 3),
            new MyrdenshawPass4("Loading", 4),
            new MyrdenshawPass5("Loading", 5)
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
    class MyrdenshawPass1 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating islands";
            Main.spawnTileY = 1000;
            Main.spawnTileX = 1000;
            Main.worldSurface = 2000;
            Main.rockLayer = 2000;
            Common.Utilities.FastNoiseLite noise = new();
            noise.SetSeed(WorldGen.genRand.Next());
            noise.SetNoiseType(Common.Utilities.FastNoiseLite.NoiseType.Perlin);
            noise.SetFractalType(Common.Utilities.FastNoiseLite.FractalType.DomainWarpProgressive);
            noise.SetDomainWarpType(Common.Utilities.FastNoiseLite.DomainWarpType.BasicGrid);
            noise.SetFrequency(0.01f);
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
                    if (noiseMap[x, y] > .3f)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            if (x + i < Main.maxTilesX && y - 10 + i < Main.maxTilesY)
                            {
                                if (WorldGen.InWorld(x + i, y - 10 + i))
                                    WorldGen.PlaceTile(x + i, y - 10 + i, ModContent.TileType<Items.Tiles.MyrdendirtTile>(), true);
                            }
                        }
                    }
                }
            }
        }
        public MyrdenshawPass1(string name, float loadWeight) : base(name, loadWeight) { }
    }

    class MyrdenshawPass2 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Adding stone clusters";
            for (int n = 0; n < (int)(Main.maxTilesX * Main.maxTilesY * 0.0010 * 0.75); n++)
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, Main.maxTilesY), WorldGen.genRand.Next(4, 15), WorldGen.genRand.Next(20, 40), ModContent.TileType<Items.Tiles.MyrdenstoneTile>());
        }
        public MyrdenshawPass2(string name, float loadWeight) : base(name, loadWeight) { }
    }

    class MyrdenshawPass3 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating ores";
            for (int n = 0; n < (int)(Main.maxTilesX * Main.maxTilesY * 0.0005); n++)
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, Main.maxTilesY), WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(5, 8), (ushort)ModContent.TileType<Items.Tiles.AeriumOreTile>());
            for (int n = 0; n < (int)(Main.maxTilesX * Main.maxTilesY * 0.0005); n++)
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, Main.maxTilesY), WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(5, 8), (ushort)ModContent.TileType<Items.Tiles.SurgestoneOreTile>());
        }
        public MyrdenshawPass3(string name, float loadWeight) : base(name, loadWeight) { }
    }

    class MyrdenshawPass4 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Adding the pylon";
            Generator.GenerateStructure(ECAssets.StructuresPath + "MyrdenshawPylonStand", new(994, 1000), EndlessContinuum.Instance);
        }
        public MyrdenshawPass4(string name, float loadWeight) : base(name, loadWeight) { }
    }

    class MyrdenshawPass5 : GenPass
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Adding foliage";
            for (int i = 10; i < Main.maxTilesX; i++)
            {
                for (int j = 10; j < Main.maxTilesY; j++)
                {
                    Tile tile = Main.tile[i, j];
                    if (tile.TileType == ModContent.TileType<Items.Tiles.MyrdendirtTile>() && Common.Utilities.WorldGenUtils.TileCanBeGrass(i, j))
                    {
                        tile.TileType = (ushort)ModContent.TileType<Items.Tiles.MyrdengrassTile>();
                        if (Main.rand.Next(5) < 3)
                            WorldGen.GrowTree(i, j);
                        if (Main.rand.NextBool(15))
                            WorldGen.PlaceObject(i, j - 2, ModContent.TileType<Items.Tiles.Myrdenshrub>(), true, Main.rand.Next(4));
                        if (Main.rand.NextBool(3))
                            WorldGen.PlaceObject(i, j - 1, ModContent.TileType<Items.Tiles.Myrdengrass>(), true, Main.rand.Next(10));
                        if (Main.rand.NextBool(7))
                            WorldGen.PlaceObject(i, j - 1, ModContent.TileType<Items.Tiles.MyrdenTallGrass>(), true, Main.rand.Next(4));
                    }
                }
            }
        }
        public MyrdenshawPass5(string name, float loadWeight) : base(name, loadWeight) { }
    }
}