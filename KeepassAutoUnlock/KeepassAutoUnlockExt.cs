using System;
using System.Windows.Forms;

using KeePass.Plugins;

using KeePassLib.Keys;
using KeePassLib.Serialization;

using KeePassAutoUnlock.Forms;
using KeePassAutoUnlock.Config;

namespace KeePassAutoUnlock
{
    public sealed class KeePassAutoUnlockExt : Plugin
    {
        private IPluginHost _host;
        private PluginConfig _customConfig;

        public override string UpdateUrl
        {
            get
            {
                return "https://raw.githubusercontent.com/jeremy-bourgin/KeePassAutoUnlock/master/versionInfo.txt";
            }
        }

        public override bool Initialize(IPluginHost host)
        {
            if (host == null)
            {
                return false;
            }

            _host = host;
            _customConfig = PluginConfig.Init(_host.CustomConfig);

            KeePass.Util.UpdateCheckEx.SetFileSigKey(UpdateUrl, "<RSAKeyValue><Modulus>0qk0X8E7nOAvNUd3qQoUUpRh2JKIn4k3x95F30ToHEXasJXphNSfCwIa7Ci8Ij0rPU2sycuJVM9k6F5D4Nx2w/h/Eg8/sPEKeRJFuIVIDnGZMV15ven08Ya1LrV3/UeUh6TZ58VulyHssHiNy9U4h+STohbVueShgvfKq7HmOS1Jbaz0atr5mewqUzyyXZTx/U2DN2vwsksQYQJCJWre5hy2nPHmCukEuPthiWj8DlU2PRbAisEWc6JYj3O/64h3X8qVaPjZbSUwz/liFwfRv+1W6TNjAgqYBGhq5JV4wx9PohD4a34xZJOYLN1TwjtMDoD+ILaKA5tjPahj7lb3VYubcegt+hmR18GEceEJwCC4pa1yyP+GYz0/aeKkfP+1h3bItcJrdrALDSYNqF9+Ux+8hm7NrGt6LkJFK5iJhcp/W/Vm7EwySaUBlf7/zI7jfgO98jLUv3lxunwffWVWlZn2YFIeZMqXahGG6CpfYkU7nmbVRDecWNk5EJkhZDZHf0S2Y8eM5Spw7SJI45nhHNNRsXkUxGVLyB4yMm3M8DpTKi8Gv2vHBfQCFWktRZ9HeGsZUNatffMgh8K1HxBUfVu2XVcB7BbB5Xp/9Ela3rRUK6ByG7RJMYjefaPxt6MLQzQVVBw7HFTaYOBKbZI2cU0CyDNBVLAuDC4ETf6EhKE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");

            do
            {
                // deux cas possibles :
                // lorsque Keepass charge le plugin pour la première fois
                // lorsque le mot de passe ne permet pas d'ouvrir le base de données
                if (!_customConfig.IsConfigured.Get())
                {
                    OpenOptions();
                }

                if (!_customConfig.IsEnabled.Get())
                {
                    return true;
                }

                // récupération de la base de données
                IOConnectionInfo db = new IOConnectionInfo();
                db.Path = _customConfig.DatabaseLocation.Get();

                // master password
                string password = _customConfig.Password.Get();
                CompositeKey cp = new CompositeKey();
                cp.AddUserKey(new KcpPassword(password));

                // tentative de connexion à la base de données
                // si la connexion échoue alors on considère que le plugin est mal configuré et l'utilisateur devra donc le reconfiguré
                try
                {
                    _host.Database.Open(db, cp, null);
                    // permet d'afficher la base de données dans l'interface de Keepass
                    _host.MainWindow.UpdateUI(true, null, true, null, true, null, false); 
                }
                catch (System.Exception)
                {
                    MessageBox.Show("KeePassAutoUnlock : Impossible to open the database");
                    _customConfig.IsConfigured.Set(false);
                }
            } while (!_customConfig.IsConfigured.Get());

            return true;
        }

        // Keepass > Tools > KeePassAutoUnlock Options
        public override ToolStripMenuItem GetMenuItem(PluginMenuType t)
        {
            if (t != PluginMenuType.Main)
            {
                return null;
            }

            ToolStripMenuItem tsmi = new ToolStripMenuItem();
            tsmi.Text = "KeePassAutoUnlock Options";
            tsmi.Click += (object sender, EventArgs e) => {
                OpenOptions();
            };

            return tsmi;
        }

        private void OpenOptions()
        {
            Form p = new PluginOption();
            p.ShowDialog();
        }
    }
}
