using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SubworldLibrary;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Biomes
{
	class SeaOfStarsBiome : ModBiome
	{
		//public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("pinkymod/VoidBackgroundStyle");
		public override int Music => MusicID.OtherworldlySpace;
		public override string BestiaryIcon => ECAssets.MiscPath + "SeaOfStars_Icon";
		public override string MapBackground => BackgroundPath;
		//public override Color? BackgroundColor => base.BackgroundColor;
		public override string BackgroundPath => ECAssets.MiscPath + "SeaOfStarsMapBackground";
		public override bool IsBiomeActive(Player player) => SubworldSystem.IsActive<Subworlds.SeaOfStars>();
		public override void OnEnter(Player player) => player.GetModPlayer<SeaOfStarsPlayer>().ZoneSeaOfStars = true;
		public override void OnLeave(Player player)
		{
			player.GetModPlayer<SeaOfStarsPlayer>().ZoneSeaOfStars = false;
			SkyManager.Instance.Deactivate("EndlessContinuum:SeaOfStarsSky");
		}
		public override void SpecialVisuals(Player player, bool isActive)
		{
			if (isActive)
				SkyManager.Instance.Activate("EndlessContinuum:SeaOfStarsSky");
		}
	}

	class SeaOfStarsPlayer : ModPlayer { public bool ZoneSeaOfStars = false; }

	class SeaOfStarsSky : CustomSky
	{
		//private readonly Random _random = new Random();
		private bool _isActive;
		public override void OnLoad() { }
		public override void Update(GameTime gameTime) { }
		private static float GetIntensity() => 1f - Utils.SmoothStep(3000f, 6000f, 200f);
		public override Color OnTileColor(Color inColor)
		{
			float intensity = GetIntensity();
			return new Color(Vector4.Lerp(new Vector4(0.15f, 0.18f, 0.33f, 1f), inColor.ToVector4(), 1f - intensity));
		}
		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= 0f && minDepth < 0f)
			{
				float intensity = GetIntensity();
				spriteBatch.Draw(ModContent.Request<Texture2D>("EndlessContinuum/Assets/Textures/Backgrounds/SkyTexture").Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(0, 0, 0) * intensity);
			}
		}
		public override float GetCloudAlpha() => 0f;
		public override void Activate(Vector2 position, params object[] args) => _isActive = true;
		public override void Deactivate(params object[] args) => _isActive = false;
		public override void Reset() => _isActive = false;
		public override bool IsActive() => _isActive;
	}

	class SeaOfStarsNPC : GlobalNPC
	{
		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.InModBiome<SeaOfStarsBiome>())
			{
				pool.Clear();
				//pool.Add(ModContent.NPCType<NPCs.Enemies.Myrdenflyer>(), 0.2f);
			}
		}
	}
}