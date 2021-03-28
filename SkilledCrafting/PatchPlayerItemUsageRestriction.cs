using HarmonyLib;
using System.Collections.Generic;
using System.Linq;

namespace SkilledCrafting
{
    [HarmonyPatch(typeof(Player))]
    class PatchPlayerItemUsageRestriction
    {
        internal static string lastCurrentWeapon = "";

        [HarmonyPatch("PlayerAttackInput")]
        [HarmonyPrefix]
        internal static bool PlayerAttackInput_Pre(ref Player __instance, float dt)
        {
            if (__instance)
            {
                ItemDrop.ItemData currentWeapon = __instance.GetCurrentWeapon();
                if (currentWeapon != null)
                {
                    if (ObjectDB.instance)
                    {
                        List<Recipe> recipes = ObjectDB.instance.m_recipes;
                        if (recipes != null)
                        {
                            Recipe recipe = recipes
                                .Where(r => r.m_item != null &&
                                            r.m_item.m_itemData != null &&
                                            r.m_item.m_itemData.m_shared != null &&
                                            r.m_item.m_itemData.m_shared.m_name.Equals(currentWeapon.m_shared.m_name))
                                .FirstOrDefault();
                            if (recipe && !SkillRequirement.GoodEnough(__instance, recipe))
                            {
                                SkillRequirement skillRequirement = SkillRequirement.skillRequirements[recipe.name];
                                string message = $"Need level {skillRequirement.m_requiredLevel} in {SkillRequirement.GetSkillName(skillRequirement.m_skill)} to use {currentWeapon.m_shared.m_name}";
                                MessageHud.instance.ShowMessage(MessageHud.MessageType.TopLeft, message);
                                if (!lastCurrentWeapon.Equals(currentWeapon.m_shared.m_name))
                                {
                                    MessageHud.instance.ShowMessage(MessageHud.MessageType.Center, message);
                                    lastCurrentWeapon = currentWeapon.m_shared.m_name;
                                }
                                return false;
                            }
                        }
                    }
                    lastCurrentWeapon = currentWeapon.m_shared.m_name;
                }
            }
            return true;
        }
    }
}
