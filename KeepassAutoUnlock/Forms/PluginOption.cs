using System;
using System.Windows.Forms;

using KeePass.App;
using KeePass.Resources;
using KeePass.UI;

using KeepassAutoUnlock.Config;
using KeepassAutoUnlock.Constraints;
using KeepassAutoUnlock.Properties;
using KeepassAutoUnlock.Validation;

namespace KeepassAutoUnlock.Forms
{
    public partial class PluginOption : Form
    {
        private readonly PluginConfig _customConfig;

        public PluginOption()
        {
            InitializeComponent();

            _customConfig = PluginConfig.Instance;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            AcceptButton = validateButton;

            enableValue.Checked = _customConfig.IsEnabled.Get();
            databaseLocationValue.Text = _customConfig.DatabaseLocation.Get();
        }

        private void OnEnableTextClick(object sender, EventArgs e)
        {
            enableValue.Checked = !enableValue.Checked;
        }

        private void OnDatabaseBrowse(object sender, EventArgs e)
        {
            string strTitle = "Choose database";
            string strDesc = KPRes.KdbxFiles;
            string strFilterExt = AppDefs.FileExtension.FileExt;
            string strContext = AppDefs.FileDialogContext.Database;

            string strFilter = UIUtil.CreateFileTypeFilter(strFilterExt, strDesc, false);
            OpenFileDialogEx ofd = UIUtil.CreateOpenFileDialog(strTitle, strFilter, 1, null, false, strContext);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                databaseLocationValue.Text = ofd.FileName;
            }
        }

        private void OnHidePassword(object sender, EventArgs e)
        {
            passwordHide.Image = (passwordHide.Checked)
                ? Resources.visibility_off_24px
                : Resources.visibility_24px
            ;

            passwordValue.EnableProtection(!passwordHide.Checked);
            UIUtil.SetFocus(passwordValue, this);
        }

        private void OnOK(object sender, EventArgs e)
        {
            bool isChecked = CheckInput();
            string password = passwordValue.TextEx.ReadString();

            if (!isChecked)
            {
                return;
            }

            _customConfig.IsConfigured.Set(isChecked);
            _customConfig.IsEnabled.Set(enableValue.Checked);
            _customConfig.DatabaseLocation.Set(databaseLocationValue.Text);

            if (password.Length > 0)
            {
                _customConfig.Password.Set(password);
            }
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            Validator v = new Validator(enableValue);
            v.AddConstraint(new NotConfiguredConstraint());

            e.Cancel = !MakeValidation(v);
        }

        private bool CheckInput()
        {
            Validator v = new Validator(enableValue);
            v.AddConstraint(new DatabaseConstraint(databaseLocationValue));

            bool isOK = MakeValidation(v);
            DialogResult = (isOK) ? DialogResult.OK : DialogResult.None;

            return isOK;
        }

        private bool MakeValidation(Validator v)
        {
            ErrorLevel el = v.GetErrorLevel();

            if (el != ErrorLevel.GOOD)
            {
                MessageBox.Show(v.GetFullMessage());
            }

            return (el != ErrorLevel.ERROR);
        }
    }
}
