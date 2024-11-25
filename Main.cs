using DDSS_AltStyle.Utils;
using HarmonyLib;
using MelonLoader;
using System;
using System.Reflection;

namespace DDSS_AltStyle
{
    internal class MelonMain : MelonMod
    {
        internal static MelonLogger.Instance _logger;
        internal static bool _hasMelonSettings;
        internal static bool _hasLobbyGuard;

        public override void OnInitializeMelon()
        {
            // Static Cache Logger
            _logger = LoggerInstance;

            // Check for Collaborative Melons
            CheckForCollaborativeMelons();

            // Create Preferences
            ConfigHandler.Setup();

            // Apply Patches
            ApplyPatches();
            MakeModHelperAware();

            // Log Success
            _logger.Msg("Initialized!");
        }

        private void ApplyPatches()
        {
            Assembly melonAssembly = typeof(MelonMain).Assembly;
            foreach (Type type in melonAssembly.GetValidTypes())
            {
                // Check Type for any Harmony Attribute
                if (type.GetCustomAttribute<HarmonyPatch>() == null)
                    continue;

                // Apply
                try
                {
                    if (MelonDebug.IsEnabled())
                        LoggerInstance.Msg($"Applying {type.Name}");

                    HarmonyInstance.PatchAll(type);
                }
                catch (Exception e)
                {
                    LoggerInstance.Error($"Exception while attempting to apply {type.Name}: {e}");
                }
            }
        }

        private void CheckForCollaborativeMelons()
        {
            foreach (var mod in RegisteredMelons)
            {
                if (mod.Info.Name == "MelonSettings")
                    _hasMelonSettings = true;

                if (mod.Info.Name == "LobbyGuard")
                    _hasLobbyGuard = true;
            }
        }

        private void MakeModHelperAware()
        {
            MelonMod modHelper = null;
            foreach (var mod in RegisteredMelons)
                if (mod.Info.Name == "ModHelper")
                {
                    modHelper = mod;
                    break;
                }
            if (modHelper == null)
                return;

            Type modFilterType = modHelper.MelonAssembly.Assembly.GetType("DDSS_ModHelper.Utils.RequirementFilterHandler");
            if (modFilterType == null)
                return;

            MethodInfo method = modFilterType.GetMethod("AddOptionalMelon", BindingFlags.Public | BindingFlags.Static);
            if (method == null)
                return;

            method.Invoke(null, [this]);
        }
    }   
}
