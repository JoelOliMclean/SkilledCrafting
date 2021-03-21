using HarmonyLib;
using System.Collections.Generic;

namespace SkilledCrafting
{
    [HarmonyPatch(typeof(InventoryGui))]
    internal class PatchInventoryGui
    {
        [HarmonyPatch("AddRecipeToList")]
        [HarmonyPrefix]
        internal static bool AddRecipeToList_Pre(ref InventoryGui __instance, Player player, Recipe recipe, ItemDrop.ItemData item, bool canCraft)
        {
            if (SkillRequirement.skillRequirements.ContainsKey(recipe.name))
            {
                SkillRequirement skillRecipe = SkillRequirement.skillRequirements[recipe.name];
                Skills skills = player.GetSkills();
                Dictionary<Skills.SkillType, Skills.Skill> m_skillData = AccessTools.Field(typeof(Skills), "m_skillData").GetValue(skills) as Dictionary<Skills.SkillType, Skills.Skill>;
                if (m_skillData.ContainsKey(skillRecipe.m_skill))
                {
                    Skills.Skill requiredSkill = m_skillData[skillRecipe.m_skill];
                    return requiredSkill.m_level >= skillRecipe.m_requiredLevel;
                }
            }
            return true;
        }
    }
}
