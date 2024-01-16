using Microsoft.Xna.Framework;
using StructureHelper;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace EndlessContinuum.Common.Globals.World
{
    class WorldGeneration : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            /*if (tasks.FindIndex(genpass => genpass.Name.Equals("Shinies")) != -1)
            {
                tasks.Insert(tasks.FindIndex(genpass => genpass.Name.Equals("Shinies")) + 2, new PassLegacy("Cloud", delegate (GenerationProgress progress, GameConfiguration configuration)
                {
                    progress.Message = "Generating clouds";
                        Utilities.FastNoiseLite noise = new();
                        noise.SetSeed(WorldGen.genRand.Next());
                        noise.SetNoiseType(Utilities.FastNoiseLite.NoiseType.Perlin);
                        noise.SetFractalType(Utilities.FastNoiseLite.FractalType.DomainWarpProgressive);
                        noise.SetFrequency(0.03f);
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
                                        if (x + i < Main.maxTilesX && y - 10 + i < 150)
                                        {
                                            if (WorldGen.InWorld(x + i, y - 10 + i))
                                                WorldGen.PlaceTile(x + i, y - 10 + i, TileID.Cloud, true);
                                        }
                                    }
                                }
                            }
                        }
                }));
            }*/

            tasks.Add(new PassLegacy("Pylons", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = "Adding pylons";
                bool AbyssalMinesPlaced = false;
                bool MyrdenshawPlaced = false;
                while (!AbyssalMinesPlaced)
                {
                    int placeX = WorldGen.genRand.Next((int)(Main.maxTilesX * .40f), (int)(Main.maxTilesX * .60f));
                    int placeY = WorldGen.genRand.Next((int)(Main.maxTilesY * .5f), (int)(Main.maxTilesY * .6));
                    if (!WorldGen.InWorld(placeX, placeY))
                        continue;
                    Tile tile = Framing.GetTileSafely(placeX, placeY);
                    if (tile.TileType != TileID.Stone)
                        continue;
                    Vector2 origin = new(placeX - 51, placeY - 23);
                    bool whitelist = false;
                    for (int i = 0; i <= 98; i++)
                    {
                        for (int j = 0; j <= 47; j++)
                        {
                            int type = Framing.GetTileSafely((int)origin.X + i, (int)origin.Y + j).TileType;
                            if (!WorldGen.InWorld((int)origin.X + i, (int)origin.Y + j) || type == TileID.SnowBlock || type == TileID.WoodBlock || type == TileID.Sandstone)
                            {
                                whitelist = true;
                                break;
                            }
                        }
                    }
                    if (whitelist)
                        continue;
                    WorldUtils.Gen(origin.ToPoint(), new Shapes.Rectangle(98, 47), Actions.Chain(new GenAction[] { new Actions.SetLiquid(0, 0) }));
                    Generator.GenerateStructure(ECAssets.StructuresPath + "AbyssalMinesPylonStand", new(placeX, placeY), EndlessContinuum.Instance);
                    AbyssalMinesPlaced = true;
                }
                while (!MyrdenshawPlaced)
                {
                    int placeX = WorldGen.genRand.Next(500, Main.maxTilesX - 500);
                    int placeY = WorldGen.genRand.Next(50, 80);
                    if (!WorldGen.InWorld(placeX, placeY))
                        continue;
                    bool whitelist = false;
                    for (int i = 0; i <= 144; i++)
                    {
                        for (int j = 0; j <= 80; j++)
                        {
                            if (Main.tile[placeX + i, placeY + j].HasTile)
                            {
                                whitelist = true;
                                break;
                            }
                        }
                    }
                    if (whitelist)
                        continue;
                    Generator.GenerateStructure(ECAssets.StructuresPath + "MyrdenshawPylonStand", new(placeX, placeY), EndlessContinuum.Instance);
                    MyrdenshawPlaced = true;
                }
            }));
        }
    }
}