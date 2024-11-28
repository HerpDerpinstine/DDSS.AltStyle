using Il2CppPlayer.Scripts;
using Il2CppUMUI;
using MelonLoader;
using UnityEngine;

namespace DDSS_AltStyle.Utils
{
    internal static class AlternateStyleHandler
    {
        internal enum eBackground
        {
            Gradient = 0,
            Flat = 1
        }

        internal enum eLogo
        {
            Transparent = 0,
            Opaque = 1
        }

        private static string _lastTab = "Menu";

        internal static void Apply(string tab = null)
        {
            if (string.IsNullOrEmpty(tab)
                || string.IsNullOrWhiteSpace(tab))
                tab = _lastTab;

            switch (tab)
            {
                case "Menu":
                    _lastTab = tab;
                    Apply_Menu_Logo();
                    Apply_Background(false, ConfigHandler._prefs_MenuBackground.Value);
                    break;

                case "Lobby":
                    _lastTab = tab;
                    Apply_Background(true, ConfigHandler._prefs_LobbyBackground.Value);
                    break;

                case "Customize":
                    _lastTab = tab;
                    Apply_Background(false, eBackground.Gradient);
                    break;

                case "Settings":
                    _lastTab = tab;
                    Apply_Background(false, ConfigHandler._prefs_GameSettingsBackground.Value);
                    break;

                case "MelonSettings":
                case "ModSettings":
                    if (MelonMain._hasMelonSettings)
                    {
                        _lastTab = tab;
                        Apply_Background(false, ConfigHandler._prefs_MelonSettingsBackground.Value);
                    }
                    break;

                case "LobbyGuardSettings":
                    if (MelonMain._hasLobbyGuard)
                    {
                        _lastTab = tab;
                        Apply_Background(false, ConfigHandler._prefs_LobbyGuardSettingsBackground.Value);
                    }
                    break;

                default:
                    //MelonMain._logger.Msg($"Unknown Tab: {tab}");
                    break;
            }
        }

        private static void Apply_Background(bool isLobby, eBackground type)
        {
            Transform backgroundFlat = UIManager.instance.transform.Find($"Background{(isLobby ? " (1)" : string.Empty)}");
            if (backgroundFlat == null)
                return;

            backgroundFlat.gameObject.SetActive(type == eBackground.Flat);
        }

        private static void Apply_Menu_Logo()
        {
            eLogo menuLogoStyle = ConfigHandler._prefs_MenuLogo.Value;

            Transform logoOpaque = UIManager.instance.transform.Find("MenuTab/Tab/Tasks/TopBar/Logo (1)");
            if (logoOpaque != null)
                logoOpaque.gameObject.SetActive(menuLogoStyle == eLogo.Opaque);

            Transform logoTransparent = UIManager.instance.transform.Find("MenuTab/Tab/Tasks/TopBar/Logo");
            if (logoTransparent != null)
                logoTransparent.gameObject.SetActive(menuLogoStyle == eLogo.Transparent);
        }
    }
}
