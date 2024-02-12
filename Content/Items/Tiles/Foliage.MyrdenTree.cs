using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenSapling : ModTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdenSapling";
    public override void SetStaticDefaults() => QuickTile.QuickSaplingTile(this, DustID.t_Honey, ModContent.TileType<MyrdengrassTile>(), 3, new Color(166, 61, 20));
    public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    public override void RandomUpdate(int i, int j)
    {
        if (!WorldGen.genRand.NextBool(20))
            return;
        bool growSucess;
        growSucess = WorldGen.GrowTree(i, j);
        bool isPlayerNear = WorldGen.PlayerLOS(i, j);
        if (growSucess && isPlayerNear)
            WorldGen.TreeGrowFXCheck(i, j);
    }
    public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
    {
        if (i % 2 == 1)
            effects = SpriteEffects.FlipHorizontally;
    }
}

class MyrdenTree : ModTree
{
    public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
    {
        UseSpecialGroups = true,
        SpecialGroupMinimalHueValue = 11f / 72f,
        SpecialGroupMaximumHueValue = 0.25f,
        SpecialGroupMinimumSaturationValue = 0.88f,
        SpecialGroupMaximumSaturationValue = 1f
    };
    public override void SetStaticDefaults() => GrowsOnTileId = new int[1] { ModContent.TileType<MyrdengrassTile>() };
    public override bool Shake(int x, int y, ref bool createLeaves) => false;
    public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
    {
        topTextureFrameWidth = 112;
        topTextureFrameHeight = 60;
    }
    public override Asset<Texture2D> GetTexture() => ModContent.Request<Texture2D>("EndlessContinuum/Assets/Textures/Tiles/MyrdenTree");
    public override int SaplingGrowthType(ref int style)
    {
        style = 0;
        return ModContent.TileType<MyrdenSapling>();
    }
    public override Asset<Texture2D> GetBranchTextures() => ModContent.Request<Texture2D>("EndlessContinuum/Assets/Textures/Tiles/MyrdenTree_Branches");
    public override Asset<Texture2D> GetTopTextures() => ModContent.Request<Texture2D>("EndlessContinuum/Assets/Textures/Tiles/MyrdenTree_Top");
    public override int DropWood() => ModContent.ItemType<Myrdenwood>();
    public override int CreateDust() => DustID.t_BorealWood;
    public override int TreeLeaf() => ModContent.GoreType<MyrdenLeaf>();
}

class MyrdenLeaf : ModGore
{
    public override string Texture => ECAssets.GoresPath + "MyrdenLeaf";
    public override void SetStaticDefaults() => GoreID.Sets.SpecialAI[Type] = 3;
}