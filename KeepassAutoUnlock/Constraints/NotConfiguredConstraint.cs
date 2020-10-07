using KeePassAutoUnlock.Config;
using KeePassAutoUnlock.Validation;

namespace KeePassAutoUnlock.Constraints
{
    // vérifie si le plugin est bien configuré
    class NotConfiguredConstraint : AbstractConstraint
    {
        public NotConfiguredConstraint()
        {
            Message = "The plugin isn't configured";
        }

        protected override ErrorLevel Validation()
        {
            PluginConfig customConfig = PluginConfig.Instance;
            return (customConfig.IsConfigured.Get())
                ? ErrorLevel.GOOD
                : ErrorLevel.ERROR
            ;
        }
    }
}
