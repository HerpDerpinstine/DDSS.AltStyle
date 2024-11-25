using DDSS_AltStyle.Utils;
using HarmonyLib;
using Il2Cpp;

namespace DDSS_AltStyle.Patches
{
    [HarmonyPatch]
    internal class Patch_SettingsTab
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(SettingsTab), nameof(SettingsTab.ApplyAllSettings))]
        private static void ApplyAllSettings_Postfix()
        {
            // Apply Style
            AlternateStyleHandler.Apply();
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(SettingsTab), nameof(SettingsTab.ResetAllSettings))]
        private static void ResetAllSettings_Postfix()
        {
            // Apply Style
            AlternateStyleHandler.Apply();
        }
    }
}