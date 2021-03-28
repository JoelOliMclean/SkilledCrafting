using BepInEx;
using HarmonyLib;

namespace SkilledCrafting
{
    [BepInPlugin(GUID, MOD_NAME, VERSION)]
    public class SkilledCrafting : BaseUnityPlugin
    {
        internal const string GUID = "uk.co.jowelth.valheim.skilledcrafting";
        internal const string MOD_NAME = "SkilledCrafting";
        internal const string VERSION = "1.6.0";

        public void Awake()
        {
            SkilledCraftingConfig.Init(Config);
            if (SkilledCraftingConfig.modEnabled.Value)
            {
                SkillRequirement.InitAll();
                Harmony.CreateAndPatchAll(typeof(PatchInventoryGui), null);
                Harmony.CreateAndPatchAll(typeof(PatchSkillsDialog), null);
                if (SkilledCraftingConfig.overrideRecipeDiscovery.Value)
                {
                    Harmony.CreateAndPatchAll(typeof(PatchPlayerRecipeDiscovery), null);
                }
                if (SkilledCraftingConfig.restrictItemUsage.Value)
                {
                    Harmony.CreateAndPatchAll(typeof(PatchPlayerItemUsageRestriction), null);
                }
            }
        }

        internal static void Log(string message, int instanceID) => Log($"({instanceID}) {message}");
        internal static void Log(string message) => ZLog.Log($"[{MOD_NAME}] {message}");
    }
}
