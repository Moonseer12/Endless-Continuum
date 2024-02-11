using Microsoft.Xna.Framework;
using SubworldLibrary;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Biomes;

class AbyssalMinesBiome : ModBiome
{
	public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("EndlessContinuum/AbyssalMinesBackgroundStyle");
	public override int Music => MusicID.Underground;
	public override string BestiaryIcon => ECAssets.MiscPath + "AbyssalMines_Icon";
	public override string BackgroundPath => MapBackground;
	public override Color? BackgroundColor => base.BackgroundColor;
	public override string MapBackground => ECAssets.MiscPath + "AbyssalMinesMapBackground";
	public override bool IsBiomeActive(Player player) => SubworldSystem.IsActive<Subworlds.AbyssalMines>();
	public override void OnEnter(Player player) => player.GetModPlayer<AbyssalMinesPlayer>().ZoneAbyssalMines = true;
	public override void OnLeave(Player player) => player.GetModPlayer<AbyssalMinesPlayer>().ZoneAbyssalMines = false;
}

class AbyssalMinesPlayer : ModPlayer { public bool ZoneAbyssalMines = false; }

class AbyssalMinesBackgroundStyle : ModUndergroundBackgroundStyle
{
	public override void FillTextureArray(int[] textureSlots)
	{
		textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/AbyssalMinesBackground");
		textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/AbyssalMinesBackground");
	}
}