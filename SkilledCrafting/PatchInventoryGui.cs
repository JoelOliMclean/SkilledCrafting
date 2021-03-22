using HarmonyLib;
using System;
using System.Collections.Generic;

namespace SkilledCrafting
{
    [HarmonyPatch(typeof(InventoryGui))]
    internal class PatchInventoryGui
    {
        [HarmonyPatch("AddRecipeToList")]
        [HarmonyPrefix]
        internal static bool AddRecipeToList_Pre(ref InventoryGui __instance, Player player, Recipe recipe, ItemDrop.ItemData item, ref bool canCraft)
        {
            if (!player.NoCostCheat() && SkillRequirement.skillRequirements.ContainsKey(recipe.name))
            {
                SkillRequirement skillRecipe = SkillRequirement.skillRequirements[recipe.name];
                Skills skills = player.GetSkills();
                Dictionary<Skills.SkillType, Skills.Skill> m_skillData = AccessTools.Field(typeof(Skills), "m_skillData").GetValue(skills) as Dictionary<Skills.SkillType, Skills.Skill>;
                if (m_skillData.ContainsKey(skillRecipe.m_skill))
                {
                    Skills.Skill requiredSkill = m_skillData[skillRecipe.m_skill];
                    bool meetsAdditionalSkillRequirement = true;
                    if (skillRecipe.hasAdditionalSkillRequirement)
                    {
                        Skills.Skill additionalRequiredSkill = m_skillData[skillRecipe.m_additionalSkill];
                        meetsAdditionalSkillRequirement = additionalRequiredSkill.m_level >= skillRecipe.m_requiredLevel;
                    }
                    canCraft = requiredSkill.m_level >= skillRecipe.m_requiredLevel && meetsAdditionalSkillRequirement;
                }
            }
            return true;
        }

        [HarmonyPatch("UpdateRecipe")]
        [HarmonyPostfix]
        internal static void UpdateRecipe_Post(ref InventoryGui __instance, Player player)
        {
            KeyValuePair<Recipe, ItemDrop.ItemData> selectedRecipe = (KeyValuePair<Recipe, ItemDrop.ItemData>)AccessTools.Field(typeof(InventoryGui), "m_selectedRecipe").GetValue(__instance);
            if ((bool)(UnityEngine.Object)selectedRecipe.Key && SkillRequirement.skillRequirements.ContainsKey(selectedRecipe.Key.name))
            {
                SkillRequirement skillRecipe = SkillRequirement.skillRequirements[selectedRecipe.Key.name];
                Skills skills = player.GetSkills();
                Dictionary<Skills.SkillType, Skills.Skill> m_skillData = AccessTools.Field(typeof(Skills), "m_skillData").GetValue(skills) as Dictionary<Skills.SkillType, Skills.Skill>;
                if (m_skillData.ContainsKey(skillRecipe.m_skill))
                {
                    Skills.Skill requiredSkill = m_skillData[skillRecipe.m_skill];
                    bool meetsAdditionalSkillRequirement = true;
                    if (skillRecipe.hasAdditionalSkillRequirement)
                    {
                        Skills.Skill additionalRequiredSkill = m_skillData[skillRecipe.m_additionalSkill];
                        meetsAdditionalSkillRequirement = additionalRequiredSkill.m_level >= skillRecipe.m_requiredLevel;
                    }
                    string skill = skillRecipe.m_skill == Skills.SkillType.WoodCutting ? "Wood cutting" : skillRecipe.m_skill.ToString();
                    string additionalSkill = skillRecipe.m_additionalSkill == Skills.SkillType.WoodCutting ? "Wood cutting" : skillRecipe.m_additionalSkill.ToString();
                    string message = $"Requires Lvl {skillRecipe.m_requiredLevel} in {skill}";
                    if (skillRecipe.hasAdditionalSkillRequirement)
                    {
                        message += $" and {additionalSkill}";
                    }
                    message = Localization.instance.Localize(message);
                    __instance.m_recipeDecription.text += Localization.instance.Localize($"\n\n{message}\n");
                    if (__instance.m_craftButton.interactable)
                    {
                        __instance.m_craftButton.GetComponent<UITooltip>().m_text = message;
                        __instance.m_craftButton.interactable = requiredSkill.m_level >= skillRecipe.m_requiredLevel && meetsAdditionalSkillRequirement;
                    }
                }
            }
        }
    }
}
