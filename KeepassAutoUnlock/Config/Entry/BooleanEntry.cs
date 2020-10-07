using KeePass.App.Configuration;

namespace KeePassAutoUnlock.Config.Entry
{
    internal class BooleanEntry : AbstractConfigEntry<bool>
    {
        public BooleanEntry(string strID, bool defaultValue, AceCustomConfig customConfig) :
            base(strID, defaultValue, customConfig)
        {
        }
        
        public override bool Get()
        {
            return _customConfig.GetBool(_ID, _defaultValue);
        }

        public override void Set(bool value)
        {
            _customConfig.SetBool(_ID, value);
        }
    }
}
