using System.Security.Principal;

using KeePass.App.Configuration;

namespace KeepassAutoUnlock.Config
{
    // représente une entrée de la configuration du plugin
    // la configuration du plugin diffère est propre à chaque utilisateur Windows
    internal abstract class AbstractConfigEntry<T>
    {
        protected string _ID;
        protected T _defaultValue;

        protected AceCustomConfig _customConfig;

        public AbstractConfigEntry(string ID, T defaultValue, AceCustomConfig customConfig)
        {
            _ID = MakeUserConfigID(ID);
            _defaultValue = defaultValue;
            _customConfig = customConfig;
        }

        // rajoute le SID de l'utilisateur connecté pour un nom de configuration donnée
        // le SID est plus fiable que le nom d'utilisateur (permet donc d'éviter des bugs et problèmes de sécurités)
        private static string MakeUserConfigID(string ID)
        {
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            return (ID + "-" + wi.User.Value);
        }

        public abstract T Get();
        public abstract void Set(T value);
    }
}
