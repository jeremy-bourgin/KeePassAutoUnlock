using System;
using System.Security.Cryptography;
using System.Text;

using KeePass.App.Configuration;

namespace KeePassAutoUnlock.Config.Entry
{
    // les configurations sous forme de chaîne de caractères sont chiffrés
    // puisque la configuration du plugin est propre à chaque utilisateur Windows
    // alors chaque entrée chiffrée pourra être déchiffrée uniquement par l'utilisateur associé
    // cela permet d'éviter que l'on puisse récupérer le mot de passe qui a été entré dans la configuration du plugin
    // voir :
    // https://docs.microsoft.com/fr-fr/dotnet/api/system.security.cryptography.protecteddata.protect?view=dotnet-plat-ext-3.1
    // https://docs.microsoft.com/fr-fr/dotnet/api/system.security.cryptography.dataprotectionscope?view=dotnet-plat-ext-3.1/
    internal class ProtectedStringEntry : AbstractConfigEntry<string>
    {
        // Constant initialization vector (unique for KeePassAutoUnlock)
        private static readonly byte[] _entropy = new byte[] {
            0xD6, 0x96, 0x97, 0x10, 0x97, 0xF9, 0x07, 0x2C,
            0x71, 0x4F, 0xDF, 0x07, 0x09, 0x68, 0x1A, 0x89
        };

        private static readonly DataProtectionScope _protectionScope = DataProtectionScope.CurrentUser;

        public ProtectedStringEntry(string strID, string defaultValue, AceCustomConfig customConfig) :
            base(strID, defaultValue, customConfig)
        {
        }

        public override string Get()
        {
            string value = _customConfig.GetString(_ID, _defaultValue);

            if (value.Equals(_defaultValue))
            {
                return value;
            }

            byte[] protectedValue = HexStringToByte(value);

            try
            {
                byte[] unprotectedValue = ProtectedData.Unprotect(protectedValue, _entropy, _protectionScope);
                return ByteToString(unprotectedValue);
            }
            catch (System.Exception)
            {
                return _defaultValue;
            }            
        }

        public override void Set(string value)
        {
            byte[] unprotectedValue = StringToByte(value);
            byte[] protectedValue = ProtectedData.Protect(unprotectedValue, _entropy, _protectionScope);

            _customConfig.SetString(_ID, ByteToHexString(protectedValue));
        }

        private static byte[] StringToByte(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        private static byte[] HexStringToByte(string value)
        {
            string[] array = value.Split('-');
            byte[] result = new byte[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                string e = array[i];
                result[i] = Convert.ToByte(e, 16);
            }

            return result;
        }

        private static string ByteToString(byte[] value)
        {
            return Encoding.UTF8.GetString(value);
        }

        private static string ByteToHexString(byte[] value)
        {
            return BitConverter.ToString(value);
        }
    }
}
