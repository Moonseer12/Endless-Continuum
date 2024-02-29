using EndlessContinuum.Common.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessContinuum.Content.Items.Tiles;

class MyrdenwoodBathtub : ModItem
{
    public override string Texture => ECAssets.ItemsPath + "MyrdenwoodBathtub";
    public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(32, 22), Item.sellPrice(0, 0, 0, 60), ModContent.TileType<MyrdenwoodBathtubTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(14).AddTile(TileID.Sawmill).Register();
}

class MyrdenwoodBathtubTile : ModTile
{
    public override string Texture => ECAssets.TilesPath + "MyrdenwoodBathtubTile";
	public override void SetStaticDefaults() => QuickTile.QuickBathtubTile(this, DustID.Hay, new Color(112, 96, 55));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}

class MyrdenwoodBed : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodBed";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(34, 18), Item.sellPrice(0, 0, 4, 0), ModContent.TileType<MyrdenwoodBedTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(15).AddIngredient(ItemID.Silk).AddTile(TileID.Sawmill).Register();
}

class MyrdenwoodBedTile : QuickBedTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodBedTile";
	protected override int BedDust => DustID.Hay;
	protected override int BedItem => ModContent.ItemType<MyrdenwoodBed>();
	protected override Color BedMapColor => new(112, 96, 55);
}

class MyrdenwoodBookcase : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodBookcase";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(26, 34), Item.sellPrice(0, 0, 0, 60), ModContent.TileType<MyrdenwoodBookcaseTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(20).AddIngredient(ItemID.Book, 10).AddTile(TileID.Sawmill).Register();
}

class MyrdenwoodBookcaseTile : ModTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodBookcaseTile";
	public override void SetStaticDefaults() => QuickTile.QuickBookcaseTile(this, DustID.Hay, new Color(112, 96, 55));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}

class MyrdenwoodCandelabra : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodCandelabra";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(30, 30), Item.sellPrice(0, 0, 3, 0), ModContent.TileType<MyrdenwoodCandelabraTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(5).AddIngredient(ItemID.Torch, 3).AddTile(TileID.WorkBenches).Register();
}

class MyrdenwoodCandelabraTile : QuickCandelabraTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodCandelabraTile";
	protected override int CandelabraDust => DustID.Hay;
	protected override int CandelabraItem => ModContent.ItemType<MyrdenwoodCandelabra>();
	protected override Color CandelabraMapColor => new(112, 96, 55);
}

class MyrdenwoodCandle : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodCandle";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(16, 16), 0, ModContent.TileType<MyrdenwoodCandleTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(4).AddIngredient(ItemID.Torch).AddTile(TileID.WorkBenches).Register();
}

class MyrdenwoodCandleTile : QuickCandleTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodCandleTile";
	protected override int CandleDust => DustID.Hay;
	protected override int CandleItem => ModContent.ItemType<MyrdenwoodCandle>();
	protected override Color CandleMapColor => new(112, 96, 55);
}

class MyrdenwoodChair : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodChair";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(16, 18), Item.sellPrice(0, 0, 0, 30), ModContent.TileType<MyrdenwoodChairTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(4).AddTile(TileID.WorkBenches).Register();
}

class MyrdenwoodChairTile : QuickChairTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodChairTile";
	protected override int ChairDust => DustID.Hay;
	protected override int ChairItem => ModContent.ItemType<MyrdenwoodChair>();
	protected override Color ChairMapColor => new(112, 96, 55);
}

class MyrdenwoodChandelier : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodChandelier";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(30, 30), Item.sellPrice(0, 0, 1, 0), ModContent.TileType<MyrdenwoodChandelierTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(4).AddIngredient(ItemID.Torch, 4).AddIngredient(ItemID.Chain).AddTile(TileID.Anvils).Register();
}

class MyrdenwoodChandelierTile : QuickChandelierTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodChandelierTile";
	protected override int ChandelierDust => DustID.Hay;
	protected override int ChandelierItem => ModContent.ItemType<MyrdenwoodChandelier>();
	protected override Color ChandelierMapColor => new(112, 96, 55);
}

class MyrdenwoodChest : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodChest";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(32, 26), 0, ModContent.TileType<MyrdenwoodChestTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(8).AddRecipeGroup(RecipeGroupID.IronBar, 2).AddTile(TileID.WorkBenches).Register();
}

class MyrdenwoodChestTile : QuickChestTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodChestTile";
	protected override int ChestDust => DustID.Hay;
	protected override int ChestItem => ModContent.ItemType<MyrdenwoodChest>();
	protected override Color ChestMapColor => new(112, 96, 55);
}

class MyrdenwoodClock : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodClock";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(14, 30), Item.sellPrice(0, 0, 0, 60), ModContent.TileType<MyrdenwoodClockTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(10).AddRecipeGroup(RecipeGroupID.IronBar, 3).AddIngredient(ItemID.Glass, 6).AddTile(TileID.Sawmill).Register();
}

class MyrdenwoodClockTile : QuickClockTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodClockTile";
	protected override int ClockDust => DustID.Hay;
	protected override Color ClockMapColor => new(112, 96, 55);
}

class MyrdenwoodDoor : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodDoor";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(18, 32), Item.sellPrice(0, 0, 0, 40), ModContent.TileType<MyrdenwoodDoorClosed>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(6).AddTile(TileID.WorkBenches).Register();
}

class MyrdenwoodDoorClosed : QuickDoorClosed
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodDoorClosed";
	protected override int DoorDust => DustID.Hay;
	protected override int DoorItem => ModContent.ItemType<MyrdenwoodDoor>();
	protected override Color DoorMapColor => new(112, 96, 55);
	protected override int DoorOpen => ModContent.TileType<MyrdenwoodDoorOpen>();
}

class MyrdenwoodDoorOpen : QuickDoorOpen
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodDoorOpen";
	protected override int DoorClosed => ModContent.TileType<MyrdenwoodDoorClosed>();
	protected override int DoorDust => DustID.Hay;
	protected override int DoorItem => ModContent.ItemType<MyrdenwoodDoor>();
	protected override Color DoorMapColor => new(112, 96, 55);
}

class MyrdenwoodDresser : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodDresser";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(36, 28), Item.sellPrice(0, 0, 1, 0), ModContent.TileType<MyrdenwoodDresserTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(16).AddTile(TileID.Sawmill).Register();
}

class MyrdenwoodDresserTile : QuickDresserTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodDresserTile";
	protected override int DresserDust => DustID.Hay;
	protected override int DresserItem => ModContent.ItemType<MyrdenwoodDresser>();
	protected override Color DresserMapColor => new(112, 96, 55);
}

class MyrdenwoodLamp : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodLamp";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(12, 28), Item.sellPrice(0, 0, 1, 0), ModContent.TileType<MyrdenwoodLampTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient(ItemID.Torch).AddIngredient<Myrdenwood>(3).AddTile(TileID.WorkBenches).Register();
}

class MyrdenwoodLampTile : QuickLampTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodLampTile";
	protected override int LampDust => DustID.Hay;
	protected override int LampItem => ModContent.ItemType<MyrdenwoodLamp>();
	protected override Color LampMapColor => new(112, 96, 55);
}

class MyrdenwoodLantern : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodLantern";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(16, 28), Item.sellPrice(0, 0, 0, 30), ModContent.TileType<MyrdenwoodLanternTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(6).AddIngredient(ItemID.Torch).AddTile(TileID.WorkBenches).Register();
}

class MyrdenwoodLanternTile : QuickLanternTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodLanternTile";
	protected override int LanternDust => DustID.Hay;
	protected override int LanternItem => ModContent.ItemType<MyrdenwoodLantern>();
	protected override Color LanternMapColor => new(112, 96, 55);
}

class MyrdenwoodPiano : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodPiano";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(26, 22), Item.sellPrice(0, 0, 0, 60), ModContent.TileType<MyrdenwoodPianoTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(15).AddIngredient(ItemID.Bone, 4).AddIngredient(ItemID.Book).AddTile(TileID.Sawmill).Register();
}

class MyrdenwoodPianoTile : ModTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodPianoTile";
	public override void SetStaticDefaults() => QuickTile.QuickPianoTile(this, DustID.Hay, new Color(112, 96, 55));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}

class MyrdenwoodSink : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodSink";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(32, 30), Item.sellPrice(0, 0, 0, 60), ModContent.TileType<MyrdenwoodSinkTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(6).AddIngredient(ItemID.WaterBucket).AddTile(TileID.Sawmill).Register();
}

class MyrdenwoodSinkTile : ModTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodSinkTile";
	public override void SetStaticDefaults() => QuickTile.QuickSinkTile(this, DustID.Hay, new Color(112, 96, 55));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}

class MyrdenwoodSofa : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodSofa";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(34, 22), Item.sellPrice(0, 0, 0, 60), ModContent.TileType<MyrdenwoodSofaTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(5).AddIngredient(ItemID.Silk, 2).AddTile(TileID.Sawmill).Register();
}

class MyrdenwoodSofaTile : ModTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodSofaTile";
	public override void SetStaticDefaults() => QuickTile.QuickSofaTile(this, DustID.Hay, new Color(112, 96, 55));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}

class MyrdenwoodTable : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodTable";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(30, 22), Item.sellPrice(0, 0, 0, 60), ModContent.TileType<MyrdenwoodTableTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(8).AddTile(TileID.WorkBenches).Register();
}

class MyrdenwoodTableTile : ModTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodTableTile";
	public override void SetStaticDefaults() => QuickTile.QuickTableTile(this, DustID.Hay, new Color(112, 96, 55));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}

class MyrdenwoodToilet : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodToilet";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(16, 28), Item.sellPrice(0, 0, 0, 30), ModContent.TileType<MyrdenwoodToiletTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(6).AddTile(TileID.Sawmill).Register();
}

class MyrdenwoodToiletTile : QuickToiletTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodToiletTile";
	protected override int ToiletDust => DustID.Hay;
	protected override int ToiletItem => ModContent.ItemType<MyrdenwoodToilet>();
	protected override Color ToiletMapColor => new(112, 96, 55);
}

class MyrdenwoodWorkbench : ModItem
{
	public override string Texture => ECAssets.ItemsPath + "MyrdenwoodWorkbench";
	public override void SetDefaults() => QuickItem.QuickFurnitureItem(this, ItemRarityID.Pink, new Vector2(32, 18), Item.sellPrice(0, 0, 0, 30), ModContent.TileType<MyrdenwoodWorkbenchTile>());
	public override void AddRecipes() => CreateRecipe().AddIngredient<Myrdenwood>(10).Register();
}

class MyrdenwoodWorkbenchTile : ModTile
{
	public override string Texture => ECAssets.TilesPath + "MyrdenwoodWorkbenchTile";
	public override void SetStaticDefaults() => QuickTile.QuickWorkbenchTile(this, DustID.Hay, new Color(112, 96, 55));
	public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
}