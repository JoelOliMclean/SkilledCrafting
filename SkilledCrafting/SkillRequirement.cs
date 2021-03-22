using System.Collections.Generic;

namespace SkilledCrafting
{
    internal class SkillRequirement
    {
        internal static Dictionary<string, SkillRequirement> skillRequirements = new Dictionary<string, SkillRequirement>();

        internal Skills.SkillType m_skill;
        internal Skills.SkillType m_additionalSkill;
        internal int m_requiredLevel;
        internal bool hasAdditionalSkillRequirement;

        internal SkillRequirement(Skills.SkillType skill, int requiredLevel)
        {
            m_skill = skill;
            m_requiredLevel = requiredLevel;
            hasAdditionalSkillRequirement = false;
        }

        internal SkillRequirement(Skills.SkillType skill, Skills.SkillType additionSkill, int requiredLevel)
        {
            m_skill = skill;
            m_additionalSkill = additionSkill;
            m_requiredLevel = requiredLevel;
            hasAdditionalSkillRequirement = true;
        }

        internal static void InitAll()
        {
            skillRequirements.Add("Recipe_HelmetBronze", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_HelmetDrake", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.silverLevel.Value));
            skillRequirements.Add("Recipe_HelmetIron", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_HelmetLeather", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.leatherLevel.Value));
            skillRequirements.Add("Recipe_HelmetPadded", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_HelmetTrollLeather", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.leatherLevel.Value));

            skillRequirements.Add("Recipe_ArmorBronzeChest", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_ArmorBronzeLegs", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_ArmorIronChest", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ArmorIronLegs", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ArmorLeatherChest", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.leatherLevel.Value));
            skillRequirements.Add("Recipe_ArmorLeatherLegs", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.leatherLevel.Value));
            skillRequirements.Add("Recipe_ArmorPaddedCuirass", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ArmorPaddedGreaves", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ArmorTrollLeatherChest", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.leatherLevel.Value));
            skillRequirements.Add("Recipe_ArmorTrollLeatherLegs", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.leatherLevel.Value));
            skillRequirements.Add("Recipe_ArmorWolfChest", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.silverLevel.Value));
            skillRequirements.Add("Recipe_ArmorWolfLegs", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.silverLevel.Value));

            skillRequirements.Add("Recipe_ShieldBanded", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ShieldBlackmetal", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.blackMetalLevel.Value));
            skillRequirements.Add("Recipe_ShieldBlackmetalTower", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.blackMetalLevel.Value));
            skillRequirements.Add("Recipe_ShieldBronzeBuckler", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_ShieldIronTower", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ShieldSerpentscale", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ShieldSilver", new SkillRequirement(Skills.SkillType.Blocking, SkilledCraftingConfig.silverLevel.Value));

            skillRequirements.Add("Recipe_ArrowBronze", new SkillRequirement(Skills.SkillType.Bows, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_ArrowIron", new SkillRequirement(Skills.SkillType.Bows, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_ArrowSilver", new SkillRequirement(Skills.SkillType.Bows, SkilledCraftingConfig.silverLevel.Value));

            skillRequirements.Add("Recipe_BowDraugrFang", new SkillRequirement(Skills.SkillType.Bows, SkilledCraftingConfig.silverLevel.Value));
            skillRequirements.Add("Recipe_BowHuntsman", new SkillRequirement(Skills.SkillType.Bows, SkilledCraftingConfig.ironLevel.Value));

            skillRequirements.Add("Recipe_AtgeirBlackmetal", new SkillRequirement(Skills.SkillType.Polearms, SkilledCraftingConfig.blackMetalLevel.Value));
            skillRequirements.Add("Recipe_AtgeirBronze", new SkillRequirement(Skills.SkillType.Polearms, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_AtgeirIron", new SkillRequirement(Skills.SkillType.Polearms, SkilledCraftingConfig.ironLevel.Value));

            switch(SkilledCraftingConfig.axeSkillType.Value)
            {
                case SkilledCraftingConfig.AxeSkillType.Both:
                    skillRequirements.Add("Recipe_AxeBlackMetal", new SkillRequirement(Skills.SkillType.Axes, Skills.SkillType.WoodCutting, SkilledCraftingConfig.blackMetalLevel.Value));
                    skillRequirements.Add("Recipe_AxeIron", new SkillRequirement(Skills.SkillType.Axes, Skills.SkillType.WoodCutting, SkilledCraftingConfig.ironLevel.Value));
                    skillRequirements.Add("Recipe_AxeBronze", new SkillRequirement(Skills.SkillType.Axes, Skills.SkillType.WoodCutting, SkilledCraftingConfig.bronzeLevel.Value));
                    skillRequirements.Add("Recipe_Battleaxe", new SkillRequirement(Skills.SkillType.Axes, Skills.SkillType.WoodCutting, SkilledCraftingConfig.ironLevel.Value));
                    break;
                case SkilledCraftingConfig.AxeSkillType.Axes:
                    skillRequirements.Add("Recipe_AxeBlackMetal", new SkillRequirement(Skills.SkillType.Axes, SkilledCraftingConfig.blackMetalLevel.Value));
                    skillRequirements.Add("Recipe_AxeIron", new SkillRequirement(Skills.SkillType.Axes, SkilledCraftingConfig.ironLevel.Value));
                    skillRequirements.Add("Recipe_AxeBronze", new SkillRequirement(Skills.SkillType.Axes, SkilledCraftingConfig.bronzeLevel.Value));
                    skillRequirements.Add("Recipe_Battleaxe", new SkillRequirement(Skills.SkillType.Axes, SkilledCraftingConfig.ironLevel.Value));
                    break;
                case SkilledCraftingConfig.AxeSkillType.WoodCutting:
                default:
                    skillRequirements.Add("Recipe_AxeBlackMetal", new SkillRequirement(Skills.SkillType.WoodCutting, SkilledCraftingConfig.blackMetalLevel.Value));
                    skillRequirements.Add("Recipe_AxeIron", new SkillRequirement(Skills.SkillType.WoodCutting, SkilledCraftingConfig.ironLevel.Value));
                    skillRequirements.Add("Recipe_AxeBronze", new SkillRequirement(Skills.SkillType.WoodCutting, SkilledCraftingConfig.bronzeLevel.Value));
                    skillRequirements.Add("Recipe_Battleaxe", new SkillRequirement(Skills.SkillType.WoodCutting, SkilledCraftingConfig.ironLevel.Value));
                    break;

            }

            skillRequirements.Add("Recipe_KnifeBlackmetal", new SkillRequirement(Skills.SkillType.Knives, SkilledCraftingConfig.blackMetalLevel.Value));

            skillRequirements.Add("Recipe_MaceBronze", new SkillRequirement(Skills.SkillType.Clubs, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_MaceIron", new SkillRequirement(Skills.SkillType.Clubs, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_MaceNeedle", new SkillRequirement(Skills.SkillType.Clubs, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_MaceSilver", new SkillRequirement(Skills.SkillType.Clubs, SkilledCraftingConfig.silverLevel.Value));
            skillRequirements.Add("Recipe_SledgeIron", new SkillRequirement(Skills.SkillType.Clubs, SkilledCraftingConfig.silverLevel.Value));

            skillRequirements.Add("Recipe_PickaxeBronze", new SkillRequirement(Skills.SkillType.Pickaxes, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_PickaxeIron", new SkillRequirement(Skills.SkillType.Pickaxes, SkilledCraftingConfig.ironLevel.Value));

            skillRequirements.Add("Recipe_SpearBronze", new SkillRequirement(Skills.SkillType.Spears, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_SpearElderbark", new SkillRequirement(Skills.SkillType.Spears, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_SpearWolfFang", new SkillRequirement(Skills.SkillType.Spears, SkilledCraftingConfig.silverLevel.Value));

            skillRequirements.Add("Recipe_SwordBlackmetal", new SkillRequirement(Skills.SkillType.Swords, SkilledCraftingConfig.blackMetalLevel.Value));
            skillRequirements.Add("Recipe_SwordBronze", new SkillRequirement(Skills.SkillType.Swords, SkilledCraftingConfig.bronzeLevel.Value));
            skillRequirements.Add("Recipe_SwordIron", new SkillRequirement(Skills.SkillType.Swords, SkilledCraftingConfig.ironLevel.Value));
            skillRequirements.Add("Recipe_SwordSilver", new SkillRequirement(Skills.SkillType.Swords, SkilledCraftingConfig.silverLevel.Value));
        }
    }
}
