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

        internal static ConfigEntry<Skills.SkillType> axeSkill;
        internal static ConfigEntry<Skills.SkillType> armorSkill;
        internal static ConfigEntry<Skills.SkillType> shieldSkill;
        internal static ConfigEntry<Skills.SkillType> bowSkill;
        internal static ConfigEntry<Skills.SkillType> arrowSkill;
        internal static ConfigEntry<Skills.SkillType> atgeirSkill;
        internal static ConfigEntry<Skills.SkillType> maceSkill;
        internal static ConfigEntry<Skills.SkillType> pickaxeSkill;
        internal static ConfigEntry<Skills.SkillType> spearSkill;
        internal static ConfigEntry<Skills.SkillType> swordSkill;
        internal static ConfigEntry<Skills.SkillType> knifeSkill;

        internal static void Init(ConfigFile config)
        {
            modEnabled = config.Bind("General", "Mod Enabled", true, "Sets whether this mod is enabled");

            leatherLevel = config.Bind("Skill Levels", "Leather Requirement", 5, "Minimum level required for crafting leather!");
            bronzeLevel = config.Bind("Skill Levels", "Bronze Requirement", 10, "Minimum level required for crafting bronze!");
            ironLevel = config.Bind("Skill Levels", "Iron Requirement", 20, "Minimum level required for crafting iron!");
            silverLevel = config.Bind("Skill Levels", "Silver Requirement", 30, "Minimum level required for crafting silver!");
            blackMetalLevel = config.Bind("Skill Levels", "Black Metal Requirement", 40, "Minimum level required for crafting black metal!");

            axeSkill = config.Bind("Required Skills", "Axes", Skills.SkillType.WoodCutting, "Skill required to level in order to craft axes");
            armorSkill = config.Bind("Required Skills", "Armor", Skills.SkillType.Blocking, "Skill required to level in order to craft armor");
            shieldSkill = config.Bind("Required Skills", "Shields", Skills.SkillType.Blocking, "Skill required to level in order to craft shields");
            bowSkill = config.Bind("Required Skills", "Bows", Skills.SkillType.Bows, "Skill required to level in order to craft bows");
            arrowSkill = config.Bind("Required Skills", "Arrows", Skills.SkillType.Bows, "Skill required to level in order to craft arrows");
            atgeirSkill = config.Bind("Required Skills", "Atgeirs", Skills.SkillType.Polearms, "Skill required to level in order to craft atgeirs");
            maceSkill = config.Bind("Required Skills", "Maces", Skills.SkillType.Clubs, "Skill required to level in order to craft maces");
            pickaxeSkill = config.Bind("Required Skills", "Pickaxes", Skills.SkillType.Pickaxes, "Skill required to level in order to craft pickaxes");
            spearSkill = config.Bind("Required Skills", "Spears", Skills.SkillType.Spears, "Skill required to level in order to craft spears");
            swordSkill = config.Bind("Required Skills", "Swords", Skills.SkillType.Swords, "Skill required to level in order to craft swords");
            knifeSkill = config.Bind("Required Skills", "Knives", Skills.SkillType.Knives, "Skill required to level in order to craft knives");

            config.Save();
        }
    }
}
