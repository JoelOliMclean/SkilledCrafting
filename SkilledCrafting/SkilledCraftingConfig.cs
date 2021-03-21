using BepInEx.Configuration;

namespace SkilledCrafting
{
    internal class SkilledCraftingConfig
    {
        internal static ConfigEntry<bool> modEnabled;
        internal static ConfigEntry<int> leatherLevel;
        internal static ConfigEntry<int> bronzeLevel;
        internal static ConfigEntry<int> ironLevel;
        internal static ConfigEntry<int> silverLevel;
        internal static ConfigEntry<int> blackMetalLevel;

        internal static void Init(ConfigFile config)
        {
            modEnabled = config.Bind("General", "Mod Enabled", true, "Sets whether this mod is enabled");
            leatherLevel = config.Bind("Skill Levels", "Leather Requirement", 5, "Minimum level required for crafting leather!");
            bronzeLevel = config.Bind("Skill Levels", "Bronze Requirement", 10, "Minimum level required for crafting bronze!");
            ironLevel = config.Bind("Skill Levels", "Iron Requirement", 20, "Minimum level required for crafting iron!");
            silverLevel = config.Bind("Skill Levels", "Silver Requirement", 30, "Minimum level required for crafting silver!");
            blackMetalLevel = config.Bind("Skill Levels", "Black Metal Requirement", 40, "Minimum level required for crafting black metal!");
            config.Save();
        }
    }
}
