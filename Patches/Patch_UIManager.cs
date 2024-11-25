﻿using DDSS_AltStyle.Utils;
using HarmonyLib;
using Il2CppUMUI;

namespace DDSS_AltStyle.Patches
{
    [HarmonyPatch]
    internal class Patch_UIManager
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(UIManager), nameof(UIManager.Awake))]
        private static void Awake_Postfix()
        {
            // Apply Style
            AlternateStyleHandler.Apply();
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UIManager), nameof(UIManager.OpenTab))]
        private static void OpenTab_Postfix(string __0)
        {
            // Apply Style
            AlternateStyleHandler.Apply(__0);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UIManager), nameof(UIManager.CloseTab))]
        private static void CloseTab_Postfix()
        {
            // Apply Style
            AlternateStyleHandler.Apply();
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UIManager), nameof(UIManager.CloseAllTabs))]
        private static void CloseAllTabs_Postfix()
        {
            // Apply Style
            AlternateStyleHandler.Apply();
        }
    }
}