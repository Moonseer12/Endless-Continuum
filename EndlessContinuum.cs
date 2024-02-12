using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace EndlessContinuum;

class EndlessContinuum : Mod
{
	public static EndlessContinuum Instance { get; private set; }
	public EndlessContinuum() => Instance = this;
	public override void Load()
	{
		SkyManager.Instance["EndlessContinuum:MyrdenshawSky"] = new Content.Biomes.MyrdenshawSky();
		SkyManager.Instance["EndlessContinuum:SeaOfStarsSky"] = new Content.Biomes.SeaOfStarsSky();
	}
}

class ECAssets
{
	public const string Path = "EndlessContinuum/Assets/";

	public const string EffectsPath = "Assets/Effects/";
	public const string SoundsPath = Path + "Sounds/";
	public const string StructuresPath = "Assets/Structures/";
	public const string TexturesPath = Path + "Textures/";

	public const string BackgroundPath = TexturesPath + "Backgrounds/";
	public const string BuffsPath = TexturesPath + "Buffs/";
	public const string DustsPath = TexturesPath + "Dusts/";
	public const string Empty = TexturesPath + "Misc/Empty";
	public const string GoresPath = TexturesPath + "Gores/";
	public const string ItemsPath = TexturesPath + "Items/";
	public const string MiscPath = TexturesPath + "Misc/";
	public const string NPCsPath = TexturesPath + "NPCs/";
	public const string ProjectilesPath = TexturesPath + "Projectiles/";
	public const string TilesPath = TexturesPath + "Tiles/";
}