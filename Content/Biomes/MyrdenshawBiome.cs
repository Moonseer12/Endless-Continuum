using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SubworldLibrary;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Biomes
{
	class MyrdenshawBiome : ModBiome
	{
		//public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("pinkymod/VoidBackgroundStyle");
		public override int Music => MusicID.SpaceDay;
		public override string BestiaryIcon => ECAssets.MiscPath + "Myrdenshaw_Icon";
		public override string MapBackground => BackgroundPath;
		//public override Color? BackgroundColor => base.BackgroundColor;
		public override string BackgroundPath => ECAssets.MiscPath + "MyrdenshawMapBackground";
		public override bool IsBiomeActive(Player player) => SubworldSystem.IsActive<Subworlds.Myrdenshaw>();
		public override void OnEnter(Player player) => player.GetModPlayer<MyrdenshawPlayer>().ZoneMyrdenshaw = true;
		public override void OnLeave(Player player)
		{
			player.GetModPlayer<MyrdenshawPlayer>().ZoneMyrdenshaw = false;
			SkyManager.Instance.Deactivate("EndlessContinuum:MyrdenshawSky");
		}
		public override void SpecialVisuals(Player player, bool isActive)
		{
			if (isActive)
				SkyManager.Instance.Activate("EndlessContinuum:MyrdenshawSky");
		}
	}

	class MyrdenshawPlayer : ModPlayer { public bool ZoneMyrdenshaw = false; }

	class MyrdenshawSky : CustomSky
	{
		//private readonly Random _random = new Random();
		private bool _isActive;
		public override void OnLoad() { }
		public override void Update(GameTime gameTime) { }
		private static float GetIntensity() => 1f - Utils.SmoothStep(3000f, 6000f, 200f);
		public override Color OnTileColor(Color inColor)
		{
			float intensity = GetIntensity();
			return new Color(Vector4.Lerp(inColor.ToVector4(), Vector4.One, intensity * 0.5f));
		}
		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= 0f && minDepth < 0f)
			{
				float intensity = GetIntensity();
				spriteBatch.Draw(ModContent.Request<Texture2D>("EndlessContinuum/Assets/Textures/Backgrounds/SkyTexture").Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(212, 197, 157) * intensity);
			}
		}
		public override float GetCloudAlpha() => 0f;
		public override void Activate(Vector2 position, params object[] args) => _isActive = true;
		public override void Deactivate(params object[] args) => _isActive = false;
		public override void Reset() => _isActive = false;
		public override bool IsActive() => _isActive;
	}

	class MyrdenshawNPC : GlobalNPC
	{
		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.InModBiome<MyrdenshawBiome>())
			{
				pool.Clear();
				pool.Add(ModContent.NPCType<NPCs.Enemies.Myrdenflyer>(), 0.2f);
			}
		}
	}
}