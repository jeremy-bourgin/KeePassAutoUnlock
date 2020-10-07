using KeePass.App.Configuration;

using KeepassAutoUnlock.Config.Entry;

namespace KeepassAutoUnlock.Config
{
    internal sealed class PluginConfig
    {

        private PluginConfig(AceCustomConfig customConfig)
        {
            IsConfigured = new BooleanEntry(Constantes.OptionIsConfigured, false, customConfig);
            IsEnabled = new BooleanEntry(Constantes.OptionIsEnabled, true, customConfig);
            DatabaseLocation = new ProtectedStringEntry(Constantes.OptionDatabse, "", customConfig);
            Password = new ProtectedStringEntry(Constantes.OptionPassword, "", customConfig);
        }

        public static PluginConfig Init(AceCustomConfig customConfig)
        {
            Instance = new PluginConfig(customConfig);
            return Instance;
        }

        public static PluginConfig Instance { get; private set; }

        public BooleanEntry IsConfigured { get; }
        public BooleanEntry IsEnabled { get; }
        public ProtectedStringEntry DatabaseLocation { get; }
        public ProtectedStringEntry Password { get; }
    }
}
