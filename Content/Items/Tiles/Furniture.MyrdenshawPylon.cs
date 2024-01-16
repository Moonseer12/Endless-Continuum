using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using SubworldLibrary;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Default;
using Terraria.ObjectData;
using Terraria.Utilities;

namespace EndlessContinuum.Content.Items.Tiles
{
	class MyrdenshawPylon : ModItem
	{
        public override string Texture => ECAssets.ItemsPath + "MyrdenshawPylon";
        public override void SetStaticDefaults() => this.SetResearch();
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<MyrdenshawPylonTile>(), 0);
            Item.width = 32;
            Item.height = 42;
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Pink;
        }
    }

    class MyrdenshawPylonTile : ModPylon
	{
        public override string Texture => ECAssets.TilesPath + "MyrdenshawPylonTile";
		public bool IsCrystal = false;
		public const int CrystalVerticalFrameCount = 8;
		public Asset<Texture2D> crystalTexture;
		public Asset<Texture2D> crystalHighlightTexture;
		public override void Load()
		{
			crystalTexture = ModContent.Request<Texture2D>("EndlessContinuum/Assets/Textures/Tiles/MyrdenshawPylonTile_Crystal");
			crystalHighlightTexture = ModContent.Request<Texture2D>("EndlessContinuum/Assets/Textures/Tiles/PylonTile_CrystalHighlight");
		}
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
			AddMapEntry(new Color(82, 70, 40), pylonName);
		}
		public override void MouseOver(int i, int j)
		{
			Main.LocalPlayer.cursorItemIconEnabled = true;
			if (IsCrystal == true || SubworldSystem.IsActive<Subworlds.Myrdenshaw>()) 
				Main.LocalPlayer.cursorItemIconID = ModContent.ItemType<MyrdenshawPylon>();
			else
				Main.LocalPlayer.cursorItemIconID = ModContent.ItemType<Misc.MyrdenshawPylonCrystal>();
		}
		public override bool RightClick(int i, int j)
		{
			if (IsCrystal == true || SubworldSystem.IsActive<Subworlds.Myrdenshaw>())
			{
				if (!SubworldSystem.AnyActive<EndlessContinuum>())
				{
					Main.rand = new UnifiedRandom();
					SubworldSystem.Enter<Subworlds.Myrdenshaw>();
				}
				if (SubworldSystem.IsActive<Subworlds.Myrdenshaw>())
					SubworldSystem.Exit();
			}
			if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Misc.MyrdenshawPylonCrystal>()))
				IsCrystal = true;
			return false;
		}
		public override bool CanKillTile(int i, int j, ref bool blockDamaged)
		{
			if (IsCrystal == true || SubworldSystem.IsActive<Subworlds.Myrdenshaw>())
				return true;
			return false;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			if (IsCrystal == true || SubworldSystem.IsActive<Subworlds.Myrdenshaw>())
				ModContent.GetInstance<SimplePylonTileEntity>().Kill(i, j);
		}
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			if (IsCrystal == true || SubworldSystem.IsActive<Subworlds.Myrdenshaw>())
				r = g = b = 0.75f;
		}
		public override void SpecialDraw(int i, int j, SpriteBatch spriteBatch)
		{
			if (IsCrystal == true || SubworldSystem.IsActive<Subworlds.Myrdenshaw>())
				DefaultDrawPylonCrystal(spriteBatch, i, j, crystalTexture, crystalHighlightTexture, new Vector2(0f, -12f), Color.White * 0.1f, Color.White, 1, CrystalVerticalFrameCount);
		}
	}

	public sealed class SimplePylonTileEntity : TEModdedPylon { }
}