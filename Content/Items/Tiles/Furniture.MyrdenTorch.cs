using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenTorch : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenTorch";
    public override void SetStaticDefaults()
    {
        ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.ShimmerTorch;
        ItemID.Sets.SingleUseInGamepad[Type] = true;
        ItemID.Sets.Torches[Type] = true;
    }
    public override void SetDefaults() => QuickItem.QuickTorchItem(this, ItemRarityID.Pink, new Vector2(14, 16), Item.sellPrice(0, 0, 30, 0), ModContent.TileType<MyrdenTorchTile>(), false);
	public override void HoldItem(Player player)
	{
		if (player.wet)
			return;
		if (Main.rand.NextBool(player.itemAnimation > 0 ? 7 : 30))
		{
			Dust dust = Dust.NewDustDirect(new Vector2(player.itemLocation.X + (player.direction == -1 ? -16f : 6f), player.itemLocation.Y - 14f * player.gravDir), 4, 4, DustID.SandstormInABottle, 0f, 0f, 100);
			if (!Main.rand.NextBool(3))
				dust.noGravity = true;
			dust.velocity *= 0.3f;
			dust.velocity.Y -= 1.5f;
			dust.position = player.RotatedRelativePoint(dust.position);
		}
		Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
		Lighting.AddLight(position, 1f, 1f, 1f);
	}
	public override void PostUpdate()
	{
		if (!Item.wet)
			Lighting.AddLight(Item.Center, 1f, 1f, 1f);
	}
	public override void AddRecipes() => CreateRecipe().AddIngredient(ItemID.Torch, 3).AddIngredient<Myrdenstone>().AddTile(TileID.WorkBenches).Register();
}

class MyrdenTorchTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdenTorchTile";
	private Asset<Texture2D> flameTexture;
	public override void SetStaticDefaults()
	{
		QuickTile.QuickTorchTile(this, DustID.SandstormInABottle, false);
		if (!Main.dedServ)
			flameTexture = ModContent.Request<Texture2D>(ECAssets.TilesPath + "MyrdenTorchTile_Flame");
	}
	public override void MouseOver(int i, int j)
	{
		Player player = Main.LocalPlayer;
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
		int style = TileObjectData.GetTileStyle(Main.tile[i, j]);
		player.cursorItemIconID = TileLoader.GetItemDropFromTypeAndStyle(Type, style);
	}
	public override float GetTorchLuck(Player player) => player.InModBiome<Biomes.MyrdenshawBiome>() ? 1f : -0.1f;
	public override void NumDust(int i, int j, bool fail, ref int num) => num = Main.rand.Next(1, 3);
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Main.tile[i, j];
		if (tile.TileFrameX < 66)
		{
			r = 0.9f;
			g = 0.9f;
			b = 0.9f;
		}
	}
	public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
	{
		offsetY = 0;
		if (WorldGen.SolidTile(i, j - 1))
			offsetY = 4;
	}
	public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
	{
		if (!TileDrawing.IsVisible(Main.tile[i, j]))
			return;
		int offsetY = 0;
		if (WorldGen.SolidTile(i, j - 1))
			offsetY = 4;
		Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
		if (Main.drawToScreen)
			zero = Vector2.Zero;
		ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i);
		for (int k = 0; k < 7; k++)
		{
			float xx = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
			float yy = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
			spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (20 - 16f) / 2f + xx, j * 16 - (int)Main.screenPosition.Y + offsetY + yy) + zero, new Rectangle(Main.tile[i, j].TileFrameX, Main.tile[i, j].TileFrameY, 20, 20), new Color(100, 100, 100, 0), 0f, default, 1f, SpriteEffects.None, 0f);
		}
	}
}