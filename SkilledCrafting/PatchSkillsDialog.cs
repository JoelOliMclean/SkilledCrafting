using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SkilledCrafting
{
    [HarmonyPatch(typeof(SkillsDialog))]
    class PatchSkillsDialog
    {
        [HarmonyPatch("Setup")]
        [HarmonyPostfix]
        [HarmonyAfter(new string[] { "MK_BetterUI" })]
        internal static void Setup_Post(ref SkillsDialog __instance, Player player)
        {
            List<GameObject> elements = AccessTools.Field(typeof(SkillsDialog), "m_elements").GetValue(__instance) as List<GameObject>;
            foreach(GameObject gameObject in elements)
            {
                Dictionary<Skills.SkillType, Skills.Skill> skillData = AccessTools.Field(typeof(Skills), "m_skillData").GetValue(player.GetSkills()) as Dictionary<Skills.SkillType, Skills.Skill>;
                Skills.Skill skill = skillData
                    .Where(sd => Utils.FindChild(gameObject.transform, "name").GetComponent<Text>().text.ToLower().Contains(SkillRequirement.GetSkillName(sd.Key).ToLower()))
                    .Select(sd => sd.Value).FirstOrDefault();
                if (skill != null)
                {
                    string message = GetMessage(__instance, player, skill, gameObject);
                    var tooltip = gameObject.GetComponentInChildren<UITooltip>();
                    tooltip.m_text += $"\n{message}";
                    Image img = tooltip.m_tooltipPrefab.GetComponentInChildren<Image>(true);
                    if (img && !string.IsNullOrEmpty(message))
                    {
                        img.gameObject.transform.localScale = new Vector3(1f, 2.1f, 1f);
                        img.gameObject.transform.localPosition += new Vector3(0f, 15f);
                        Text text = tooltip.m_tooltipPrefab.GetComponentInChildren<Text>(true);
                        if (text)
                        {
                            text.gameObject.transform.localPosition += new Vector3(0f, 15f);
                        }
                    }
                }
            }
            AccessTools.Field(typeof(SkillsDialog), "m_elements").SetValue(__instance, elements);
        }

        private static string GetMessage(SkillsDialog __instance, Player player, Skills.Skill skill, GameObject gameObject)
        {
            Dictionary<Skills.SkillType, Skills.Skill> m_skillData = (Dictionary<Skills.SkillType, Skills.Skill>)AccessTools.Field(typeof(Skills), "m_skillData").GetValue(player.GetSkills());
            Skills.SkillType skillType = m_skillData.Where(x => x.Value.Equals(skill)).Select(x => x.Key).FirstOrDefault();
            var currentLevel = skill.m_level;
            if (m_skillData.ContainsValue(skill))
            {
                KeyValuePair<string, SkillRequirement> skillRequirement = SkillRequirement.skillRequirements
                    .Where(x => x.Value.m_skill.ToString().ToLower().Equals(skillType.ToString().ToLower()))
                    .Where(x => x.Value.m_requiredLevel > currentLevel)
                    .OrderBy(x => x.Value.m_requiredLevel)
                    .FirstOrDefault();
                if (!string.IsNullOrEmpty(skillRequirement.Key))
                {
                    Recipe recipe = ObjectDB.instance.m_recipes.Find(x => x.name.Equals(skillRequirement.Key));
                    string localisedItemName = Localization.instance.Localize(recipe.m_item.m_itemData.m_shared.m_name);
                    return $"Next unlock at level {skillRequirement.Value.m_requiredLevel}:\n{localisedItemName}";
                }
            }
            return "";
        }
    }
}
