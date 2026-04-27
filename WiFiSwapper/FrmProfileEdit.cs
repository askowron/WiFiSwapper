using System.Windows.Forms;
using WiFiSwapper.Models;

namespace WiFiSwapper
{
    public partial class FrmProfileEdit : Form
    {
        private ToolTip toolTip;

        public FrmProfileEdit()
        {
            InitializeComponent();

            toolTip = new ToolTip()
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true,
                ToolTipIcon = ToolTipIcon.Info,
                IsBalloon = true
            };
            InitLists();
        }

        private void InitLists()
        {
            cbKind.Items.AddRange(
                new Models.ProfileKind[] {
                    new Models.ProfileKind { Code = "OPEN", Name = "Open" },
                    new Models.ProfileKind { Code = "WEP", Name = "WEP" },
                    new Models.ProfileKind { Code = "WPA2", Name = "WPA2 Personal" }
                }
            );
        }

        public Models.Profile GetProfile()
        {
            return new Models.Profile 
            {
                 Name = tbName.Text,
                 Password = tbPassword.Text,
                 Kind = (Models.ProfileKind)cbKind.SelectedItem
            };
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (((ProfileKind)cbKind.SelectedItem).Code == "WPA2")
            {
                if (tbPassword.Text.Length < 8)
                {
                    toolTip.Show("Password must be at lease 8 characters length!", tbPassword);
                    return;
                }
            }

            DialogResult = DialogResult.OK; Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult= DialogResult.Cancel; Close();
        }
    }
}
