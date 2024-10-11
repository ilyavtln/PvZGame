using System.Configuration;

namespace PvZGame.Helpers
{
    public class SettingsManager
    {
        public bool IsFullScreenMode
        {
            get => ParseBool("IsFullScreenMode");
            set => UpdateSetting("IsFullScreenMode", value.ToString());
        }

        public bool IsMusicEnabled
        {
            get => ParseBool("IsMusicEnabled");
            set => UpdateSetting("IsMusicEnabled", value.ToString());
        }

        public bool IsSoundEnabled
        {
            get => ParseBool("IsSoundEnabled");
            set => UpdateSetting("IsSoundEnabled", value.ToString());
        }

        private bool ParseBool(string key)
        {
            bool.TryParse(ConfigurationManager.AppSettings[key], out bool value);
            return value;
        }

        private void UpdateSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}