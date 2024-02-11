using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EndlessContinuum.Common.Globals.Items;

class ECRecipes : ModSystem
{
    public static RecipeGroup AnyAdamantiteBar;
    public override void Unload()
    {
        AnyAdamantiteBar = null;
    }
    public override void AddRecipeGroups()
    {
        AnyAdamantiteBar = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.AdamantiteBar)}", ItemID.AdamantiteBar, ItemID.TitaniumBar);
        RecipeGroup.RegisterGroup("EndlessContinuum:AnyAdamantiteBar", AnyAdamantiteBar);
    }
}