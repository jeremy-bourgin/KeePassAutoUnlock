using System;
using System.Windows.Forms;

using KeePass;
using KeePass.Plugins;

using KeePassLib.Keys;
using KeePassLib.Serialization;

using KeepassAutoUnlock.Forms;
using KeepassAutoUnlock.Config;

namespace KeepassAutoUnlock
{
    public sealed class KeepassAutoUnlockExt : Plugin
    {
        private IPluginHost _host;
        private PluginConfig _customConfig;

        public override bool Initialize(IPluginHost host)
        {
            if (host == null)
            {
                return false;
            }

            _host = host;
            _customConfig = PluginConfig.Init(_host.CustomConfig);

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
                    MessageBox.Show("KeepassAutoUnlock : Impossible to open the database");
                    _customConfig.IsConfigured.Set(false);
                }
            } while (!_customConfig.IsConfigured.Get());

            return true;
        }

        // Keepass > Tools > KeepassAutoUnlock Options
        public override ToolStripMenuItem GetMenuItem(PluginMenuType t)
        {
            if (t != PluginMenuType.Main)
            {
                return null;
            }

            ToolStripMenuItem tsmi = new ToolStripMenuItem();
            tsmi.Text = "KeepassAutoUnlock Options";
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
