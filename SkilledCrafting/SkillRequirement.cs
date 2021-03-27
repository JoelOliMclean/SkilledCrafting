using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkilledCrafting
{
    internal class SkillRequirement
    {
        internal static Dictionary<string, SkillRequirement> skillRequirements = new Dictionary<string, SkillRequirement>();

        internal Skills.SkillType m_skill;
        internal int m_requiredLevel;

        internal SkillRequirement(Skills.SkillType skill, int requiredLevel)
        {
            m_skill = skill;
            m_requiredLevel = requiredLevel;
        }

        internal static void InitAll()
        {
            skillRequirements.Add("Recipe_HelmetBronze", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_HelmetDrake", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.silverLevel.Value));
            skillRequirements.Add("Recipe_HelmetIron", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_HelmetLeather", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.leatherLevel.Value));
            skillRequirements.Add("Recipe_HelmetPadded", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_HelmetTrollLeather", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.leatherLevel.Value));

            skillRequirements.Add("Recipe_ArmorBronzeChest", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_ArmorBronzeLegs", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_ArmorIronChest", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ArmorIronLegs", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ArmorLeatherChest", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.leatherLevel.Value));
            skillRequirements.Add("Recipe_ArmorLeatherLegs", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.leatherLevel.Value));
            skillRequirements.Add("Recipe_ArmorPaddedCuirass", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ArmorPaddedGreaves", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ArmorTrollLeatherChest", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.leatherLevel.Value));
            skillRequirements.Add("Recipe_ArmorTrollLeatherLegs", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.leatherLevel.Value));
            skillRequirements.Add("Recipe_ArmorWolfChest", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.silverLevel.Value));
            skillRequirements.Add("Recipe_ArmorWolfLegs", new SkillRequirement(SkilledCraftingConfig.armorSkill.Value, SkilledCraftingConfig.silverLevel.Value));

            skillRequirements.Add("Recipe_ShieldBanded", new SkillRequirement(SkilledCraftingConfig.shieldSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ShieldBlackmetal", new SkillRequirement(SkilledCraftingConfig.shieldSkill.Value, SkilledCraftingConfig.blackMetalLevel.Value));
            skillRequirements.Add("Recipe_ShieldBlackmetalTower", new SkillRequirement(SkilledCraftingConfig.shieldSkill.Value, SkilledCraftingConfig.blackMetalLevel.Value));
            skillRequirements.Add("Recipe_ShieldBronzeBuckler", new SkillRequirement(SkilledCraftingConfig.shieldSkill.Value, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_ShieldIronTower", new SkillRequirement(SkilledCraftingConfig.shieldSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ShieldSerpentscale", new SkillRequirement(SkilledCraftingConfig.shieldSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ShieldSilver", new SkillRequirement(SkilledCraftingConfig.shieldSkill.Value, SkilledCraftingConfig.silverLevel.Value));

            skillRequirements.Add("Recipe_ArrowBronze", new SkillRequirement(SkilledCraftingConfig.arrowSkill.Value, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_ArrowIron", new SkillRequirement(SkilledCraftingConfig.arrowSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ArrowSilver", new SkillRequirement(SkilledCraftingConfig.arrowSkill.Value, SkilledCraftingConfig.silverLevel.Value));

            skillRequirements.Add("Recipe_BowDraugrFang", new SkillRequirement(SkilledCraftingConfig.bowSkill.Value, SkilledCraftingConfig.silverLevel.Value));
            skillRequirements.Add("Recipe_BowHuntsman", new SkillRequirement(SkilledCraftingConfig.bowSkill.Value, SkilledCraftingConfig.ironLevel.Value));

            if (SkilledCraftingConfig.overrideBronzeAtgeirSkill.Value)
            {
                skillRequirements.Add("Recipe_AtgeirBronze", new SkillRequirement(SkilledCraftingConfig.atgeirSkill.Value, SkilledCraftingConfig.bronzeLevel.Value));
            } 
            else
            {
                skillRequirements.Add("Recipe_AtgeirBronze", new SkillRequirement(Skills.SkillType.Spears, SkilledCraftingConfig.bronzeLevel.Value));
            }
            skillRequirements.Add("Recipe_AtgeirIron", new SkillRequirement(SkilledCraftingConfig.atgeirSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_AtgeirBlackmetal", new SkillRequirement(SkilledCraftingConfig.atgeirSkill.Value, SkilledCraftingConfig.blackMetalLevel.Value));

            skillRequirements.Add("Recipe_AxeBlackMetal", new SkillRequirement(SkilledCraftingConfig.axeSkill.Value, SkilledCraftingConfig.blackMetalLevel.Value));
            skillRequirements.Add("Recipe_AxeIron", new SkillRequirement(SkilledCraftingConfig.axeSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_AxeBronze", new SkillRequirement(SkilledCraftingConfig.axeSkill.Value, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_Battleaxe", new SkillRequirement(SkilledCraftingConfig.axeSkill.Value, SkilledCraftingConfig.ironLevel.Value));

            skillRequirements.Add("Recipe_KnifeBlackmetal", new SkillRequirement(SkilledCraftingConfig.knifeSkill.Value, SkilledCraftingConfig.blackMetalLevel.Value));

            skillRequirements.Add("Recipe_MaceBronze", new SkillRequirement(SkilledCraftingConfig.maceSkill.Value, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_MaceIron", new SkillRequirement(SkilledCraftingConfig.maceSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_MaceNeedle", new SkillRequirement(SkilledCraftingConfig.maceSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_MaceSilver", new SkillRequirement(SkilledCraftingConfig.maceSkill.Value, SkilledCraftingConfig.silverLevel.Value));
            skillRequirements.Add("Recipe_SledgeIron", new SkillRequirement(SkilledCraftingConfig.maceSkill.Value, SkilledCraftingConfig.silverLevel.Value));

            skillRequirements.Add("Recipe_PickaxeBronze", new SkillRequirement(SkilledCraftingConfig.pickaxeSkill.Value, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_PickaxeIron", new SkillRequirement(SkilledCraftingConfig.pickaxeSkill.Value, SkilledCraftingConfig.ironLevel.Value));

            skillRequirements.Add("Recipe_SpearBronze", new SkillRequirement(SkilledCraftingConfig.spearSkill.Value, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_SpearElderbark", new SkillRequirement(SkilledCraftingConfig.spearSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_SpearWolfFang", new SkillRequirement(SkilledCraftingConfig.spearSkill.Value, SkilledCraftingConfig.silverLevel.Value));

            if (SkilledCraftingConfig.overrideBronzeAtgeirSkill.Value)
            {
                skillRequirements.Add("Recipe_SwordBronze", new SkillRequirement(SkilledCraftingConfig.swordSkill.Value, SkilledCraftingConfig.bronzeLevel.Value));
            }
            else
            {
                skillRequirements.Add("Recipe_SwordBronze", new SkillRequirement(Skills.SkillType.Clubs, SkilledCraftingConfig.bronzeLevel.Value));
            }
            skillRequirements.Add("Recipe_SwordIron", new SkillRequirement(SkilledCraftingConfig.swordSkill.Value, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_SwordSilver", new SkillRequirement(SkilledCraftingConfig.swordSkill.Value, SkilledCraftingConfig.silverLevel.Value));
            skillRequirements.Add("Recipe_SwordBlackmetal", new SkillRequirement(SkilledCraftingConfig.swordSkill.Value, SkilledCraftingConfig.blackMetalLevel.Value));
        }

        internal static bool GoodEnough(Player player, Recipe recipe)
        {
            if (!skillRequirements.ContainsKey(recipe.name)) 
                return true;
            SkillRequirement skillRecipe = skillRequirements[recipe.name];
            Skills skills = player.GetSkills();
            Dictionary<Skills.SkillType, Skills.Skill> m_skillData = AccessTools.Field(typeof(Skills), "m_skillData").GetValue(skills) as Dictionary<Skills.SkillType, Skills.Skill>;
            if (m_skillData.ContainsKey(skillRecipe.m_skill))
            {
                Skills.Skill requiredSkill = m_skillData[skillRecipe.m_skill];
                return requiredSkill.m_level >= skillRecipe.m_requiredLevel;
            }
            return false;
        }

        internal static string GetSkillName(Skills.SkillType skill)
        {
            switch (skill)
            {
                case Skills.SkillType.WoodCutting:
                    return "Wood cutting";
                case Skills.SkillType.FireMagic:
                    return "Fire magic";
                case Skills.SkillType.FrostMagic:
                    return "Frost magic";
                default:
                    return skill.ToString();
            }
        }

        internal static List<Recipe> GetRecipesToLearnForSkillAndLevel(Skills.SkillType skill, float level)
        {
            List<string> unlockedRecipeNames = skillRequirements.Where(x => x.Value.m_skill.Equals(skill)).Where(x => x.Value.m_requiredLevel <= level).Select(x => x.Key).ToList();
            return ObjectDB.instance.m_recipes.Where(x => unlockedRecipeNames.Contains(x.name)).ToList();
        }
    }
}
