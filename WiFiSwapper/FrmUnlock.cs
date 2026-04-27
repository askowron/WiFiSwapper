using System;
using System.Windows.Forms;
using WiFiSwapper.Core;
using WiFiSwapper.Core.Extensions;

namespace WiFiSwapper
{
    public partial class FrmUnlock : Form
    {
        public enum UnlockKind 
        {
            Verify, Remove
        }

        private UnlockKind unlockKind;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrmUnlock()
        {
            InitializeComponent();

            unlockKind = UnlockKind.Verify;
        }

        public FrmUnlock(UnlockKind kind)
        {
            InitializeComponent();

            unlockKind = kind;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = unlockKind == UnlockKind.Remove ? 
                DialogResult.Cancel : 
                DialogResult.Abort;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Verify password
            if (CheckCurrentPassword())
            {
                if (unlockKind == UnlockKind.Remove)
                    WinReg.RemovePath(Constants.REGISTRY_PATH_ROOT);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect password!", "Unlock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Check if provided password match storred password
        /// </summary>
        /// <returns></returns>
        private bool CheckCurrentPassword()
        {
            // Read current password
            var currentPassword = WinReg.ReadByteArray(Constants.REGISTRY_PATH_LOCK, "Value");
            if ((currentPassword == null || currentPassword.Length == 0) && string.IsNullOrEmpty(tbPassword.Text))
                return true;

            // Get seed from registry
            var seedBytes = WinReg.ReadByteArray(Constants.REGISTRY_PATH_LOCK, "Encryption");
            if (seedBytes == null && seedBytes.Length == 0)
                return false;

            // Decode current password
            string currentPasswordDec = Password.Decrypt(currentPassword, seedBytes.AsString());

            // Check if passwords match
            return (tbPassword.Text == currentPasswordDec);
        }
    }
}
