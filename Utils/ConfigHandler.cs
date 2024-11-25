using MelonLoader;

namespace DDSS_AltStyle.Utils
{
    internal static class ConfigHandler
    {
        private static MelonPreferences_Category _prefs_Category;
        internal static MelonPreferences_Entry<AlternateStyleHandler.eLogo> _prefs_MenuLogo;
        internal static MelonPreferences_Entry<AlternateStyleHandler.eBackground> _prefs_MenuBackground;
        internal static MelonPreferences_Entry<AlternateStyleHandler.eBackground> _prefs_LobbyBackground;
        internal static MelonPreferences_Entry<AlternateStyleHandler.eBackground> _prefs_CustomizeBackground;
        internal static MelonPreferences_Entry<AlternateStyleHandler.eBackground> _prefs_GameSettingsBackground;
        internal static MelonPreferences_Entry<AlternateStyleHandler.eBackground> _prefs_MelonSettingsBackground;
        internal static MelonPreferences_Entry<AlternateStyleHandler.eBackground> _prefs_LobbyGuardSettingsBackground;

        internal static void Setup()
        {
            // Create Preferences Category
            _prefs_Category = MelonPreferences.CreateCategory("AltStyle", "Alternative Style");

            // Create Preferences Entries
            _prefs_MenuLogo = CreatePref("MenuLogo",
                "Menu Logo",
                "Sets the Style of the Game Logo on the Main Menu",
                AlternateStyleHandler.eLogo.Transparent);

            _prefs_MenuBackground = CreatePref("MenuBackground",
                "Menu Background",
                "Sets the Style of the Game Background on the Main Menu",
                AlternateStyleHandler.eBackground.Gradient);

            _prefs_LobbyBackground = CreatePref("LobbyBackground",
                "Lobby Background",
                "Sets the Style of the Game Background for the Lobby menu",
                AlternateStyleHandler.eBackground.Flat);

            _prefs_CustomizeBackground = CreatePref("CustomizeBackground",
                "Customize Background",
                "Sets the Style of the Game Background for the Customize menu",
                AlternateStyleHandler.eBackground.Gradient);

            _prefs_GameSettingsBackground = CreatePref("GameSettingsBackground",
                "Game Settings Background ",
                "Sets the Style of the Game Background for the Game Settings menu",
                AlternateStyleHandler.eBackground.Gradient);

            _prefs_MelonSettingsBackground = CreatePref("MelonSettingsBackground",
                "Melon Settings Background ",
                "Sets the Style of the Game Background for the Mod Settings menu",
                AlternateStyleHandler.eBackground.Gradient,
                !MelonMain._hasMelonSettings);

            _prefs_LobbyGuardSettingsBackground = CreatePref("LobbyGuardSettingsBackground",
                "LobbyGuard Settings Background ",
                "Sets the Style of the Game Background for the LobbyGuard Settings menu",
                AlternateStyleHandler.eBackground.Gradient,
                !MelonMain._hasLobbyGuard);
        }

        private static MelonPreferences_Entry<T> CreatePref<T>(
            string id,
            string displayName,
            string description,
            T defaultValue,
            bool isHidden = false)
            => _prefs_Category.CreateEntry(id,
                defaultValue,
                displayName,
                description,
                isHidden,
                false,
                null);
    }
}
