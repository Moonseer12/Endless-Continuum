using Terraria;
using Terraria.ModLoader;

namespace EndlessContinuum.Common.Utilities
{
	class WorldGenUtils : ModSystem
	{
        public static bool TileCanBeGrass(int i, int j)
        {
            if (WorldGen.TileEmpty(i + 1, j) || !Main.tileSolid[Main.tile[i + 1, j].TileType])
                return true;
            else if (WorldGen.TileEmpty(i - 1, j) || !Main.tileSolid[Main.tile[i - 1, j].TileType])
                return true;
            else if (WorldGen.TileEmpty(i, j + 1) || !Main.tileSolid[Main.tile[i, j + 1].TileType])
                return true;
            else if (WorldGen.TileEmpty(i, j - 1) || !Main.tileSolid[Main.tile[i, j - 1].TileType])
                return true;
            else if (WorldGen.TileEmpty(i + 1, j + 1) || !Main.tileSolid[Main.tile[i + 1, j + 1].TileType])
                return true;
            else if (WorldGen.TileEmpty(i + 1, j - 1) || !Main.tileSolid[Main.tile[i + 1, j - 1].TileType])
                return true;
            else if (WorldGen.TileEmpty(i - 1, j + 1) || !Main.tileSolid[Main.tile[i - 1, j + 1].TileType])
                return true;
            else if (WorldGen.TileEmpty(i - 1, j - 1) || !Main.tileSolid[Main.tile[i - 1, j - 1].TileType])
                return true;
            return false;
        }
    }
}