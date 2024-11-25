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
                    Apply_Menu_Background(ConfigHandler._prefs_MenuBackground);
                    break;

                case "Lobby":
                    _lastTab = tab;
                    Apply_Lobby_Background();
                    break;

                case "Customize":
                    _lastTab = tab;
                    Apply_Menu_Background(ConfigHandler._prefs_CustomizeBackground);
                    FixCustomizePlayerRender();
                    break;

                case "Settings":
                    _lastTab = tab;
                    Apply_Menu_Background(ConfigHandler._prefs_GameSettingsBackground);
                    break;

                case "MelonSettings":
                case "ModSettings":
                    if (MelonMain._hasMelonSettings)
                    {
                        _lastTab = tab;
                        Apply_Menu_Background(ConfigHandler._prefs_MelonSettingsBackground);
                    }
                    break;

                case "LobbyGuard":
                    if (MelonMain._hasLobbyGuard)
                    {
                        _lastTab = tab;
                        Apply_Menu_Background(ConfigHandler._prefs_LobbyGuardSettingsBackground);
                    }
                    break;

                default:
                    //MelonMain._logger.Msg($"Unknown Tab: {tab}");
                    break;
            }
        }

        private static void FixCustomizePlayerRender()
        {
            PlayerCustomizer customizer = UnityEngine.Object.FindObjectOfType<PlayerCustomizer>();
            if ((customizer == null)
                || customizer.WasCollected)
                return;

            customizer.transform.parent.SetAsLastSibling();
        }

        private static void Apply_Lobby_Background()
        {
            Transform backgroundFlatLobby = UIManager.instance.transform.Find("Background (1)");
            if (backgroundFlatLobby == null)
                return;
            
            eBackground lobbyBackgroundStyle = ConfigHandler._prefs_LobbyBackground.Value;
            backgroundFlatLobby.gameObject.SetActive(lobbyBackgroundStyle == eBackground.Flat);
        }

        private static void Apply_Menu_Background(MelonPreferences_Entry<eBackground> pref)
        {
            Transform backgroundFlatMenu = UIManager.instance.transform.Find("Background");
            if (backgroundFlatMenu == null)
                return;

            eBackground menuBackgroundStyle = pref.Value;
            backgroundFlatMenu.gameObject.SetActive(menuBackgroundStyle == eBackground.Flat);
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
