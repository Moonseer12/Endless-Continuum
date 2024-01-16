using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum
{
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
	static class ECDuplication
	{
		public static void SetResearch(this ModItem modItem) => SetResearch(modItem.Type, 1);
		public static void SetResearchAmmo(this ModItem modItem) => SetResearch(modItem.Type, 99);
		public static void SetResearchBeam(this ModItem modItem) => SetResearch(modItem.Type, 50);
		public static void SetResearchBlock(this ModItem modItem) => SetResearch(modItem.Type, 100);
		public static void SetResearchCritter(this ModItem modItem) => SetResearch(modItem.Type, 5);
		public static void SetResearchFish(this ModItem modItem) => SetResearch(modItem.Type, 3);
		public static void SetResearchFood(this ModItem modItem) => SetResearch(modItem.Type, 10);
		public static void SetResearchGem(this ModItem modItem) => SetResearch(modItem.Type, 15);
		public static void SetResearchMaterial(this ModItem modItem) => SetResearch(modItem.Type, 25);
		public static void SetResearchMiscBag(this ModItem modItem) => SetResearch(modItem.Type, 2);
		public static void SetResearchPlatform(this ModItem modItem) => SetResearch(modItem.Type, 200);
		public static void SetResearchPotion(this ModItem modItem) => SetResearch(modItem.Type, 20);
		public static void SetResearchRestorationPotion(this ModItem modItem) => SetResearch(modItem.Type, 30);
		public static void SetResearchWall(this ModItem modItem) => SetResearch(modItem.Type, 400);
		public static void SetResearch(int type, int amt) => CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[type] = amt;
	}
}