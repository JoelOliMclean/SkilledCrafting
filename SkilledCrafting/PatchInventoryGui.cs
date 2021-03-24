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
        internal static bool AddRecipeToList_Pre(Player player, Recipe recipe, ItemDrop.ItemData item, ref bool canCraft)
        {
            if (!player.NoCostCheat() && SkillRequirement.skillRequirements.ContainsKey(recipe.name))
            {
                canCraft = SkillRequirement.GoodEnough(player, recipe);
            }
            return true;
        }

        [HarmonyPatch("UpdateRecipe")]
        [HarmonyPostfix]
        internal static void UpdateRecipe_Post(ref InventoryGui __instance, Player player)
        {
            Recipe selectedRecipe = ((KeyValuePair<Recipe, ItemDrop.ItemData>)AccessTools.Field(typeof(InventoryGui), "m_selectedRecipe").GetValue(__instance)).Key;
            if (selectedRecipe && SkillRequirement.skillRequirements.ContainsKey(selectedRecipe.name))
            {
                SkillRequirement skillRecipe = SkillRequirement.skillRequirements[selectedRecipe.name];
                Dictionary<Skills.SkillType, Skills.Skill> m_skillData = AccessTools.Field(typeof(Skills), "m_skillData").GetValue(player.GetSkills()) as Dictionary<Skills.SkillType, Skills.Skill>;
                if (m_skillData.ContainsKey(skillRecipe.m_skill))
                {
                    string message = $"Requires Lvl {skillRecipe.m_requiredLevel} in {SkillRequirement.GetSkillName(skillRecipe.m_skill)}";
                    __instance.m_recipeDecription.text += Localization.instance.Localize($"\n\n{message}\n");
                    if (__instance.m_craftButton.interactable && !SkillRequirement.GoodEnough(player, selectedRecipe))
                    {
                        __instance.m_craftButton.GetComponent<UITooltip>().m_text = message;
                        __instance.m_craftButton.interactable = false;
                    }
                }
            }
        }
    }
}
