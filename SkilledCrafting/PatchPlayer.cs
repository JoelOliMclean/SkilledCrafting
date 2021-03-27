﻿using HarmonyLib;
using System;
using System.Collections.Generic;

namespace SkilledCrafting
{
    [HarmonyPatch(typeof(Player))]
    internal class PatchPlayer
    {
        [HarmonyPatch("OnSkillLevelup")]
        [HarmonyPostfix]
        internal static void OnSkillLevelup_Post(ref Player __instance, Skills.SkillType skill, float level)
        {
            SkilledCrafting.Log($"Leveling up {skill} - {level}");
            foreach (var recipe in SkillRequirement.GetRecipesToLearnForSkillAndLevel(skill, level))
            {
                SkilledCrafting.Log($"Trying to learn {recipe.name}");
                if (DoesPlayerKnowsAllMaterials(__instance, recipe) && !__instance.IsRecipeKnown(recipe.name))
                {
                    __instance.AddKnownRecipe(recipe);
                    SkilledCrafting.Log($"Learning {recipe.name} after level up");
                }
            }
        }

        private static bool DoesPlayerKnowsAllMaterials(Player instance, Recipe recipe)
        {
            HashSet<string> knownMaterials = AccessTools.Field(typeof(Player), "m_knownMaterial").GetValue(instance) as HashSet<string>;
            foreach (var knownMaterial in knownMaterials)
            {
                SkilledCrafting.Log($"Player knows {knownMaterial}");
            }
            foreach (var material in recipe.m_resources)
            {
                if (!knownMaterials.Contains(material.m_resItem.m_itemData.m_shared.m_name))
                {
                    SkilledCrafting.Log($"Cannot learn {recipe.name}, player doesn't know {material.m_resItem.name}");
                    return false;
                }
            }
            return true;
        }

        [HarmonyPatch("AddKnownRecipe")]
        [HarmonyPrefix]
        internal static bool AddKnownRecipe_Pre(ref Player __instance, Recipe recipe)
        {
            if (!SkillRequirement.skillRequirements.ContainsKey(recipe.name) || SkillRequirement.GoodEnough(__instance, recipe))
                return true;
            SkilledCrafting.Log($"Skipping recipe {recipe.name}, skill not high enough");
            return false;
        }
    }
}