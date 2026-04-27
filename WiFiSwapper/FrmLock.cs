using System;
using System.Windows.Forms;
using WiFiSwapper.Code.Extensions;
using WiFiSwapper.Core;
using WiFiSwapper.Core.Extensions;

namespace WiFiSwapper
{
    public partial class FrmLock : Form
    {

        protected ToolTip ToolTip;

        public FrmLock()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if(ToolTip != null && ToolTip.Active)
            {
                ToolTip.Active = false;
                ToolTip.Dispose();
            }

            if (CheckCurrentPassword())
            {
                if (CheckRetypePassword())
                    SetCurrentPassword();
                else
                {
                    ToolTip = new ToolTip();
                    ToolTip.Show("Password retyped incorrectly!", tbPasswordNew2);
                    return;
                }
            }
            else 
            {
                ToolTip = new ToolTip();
                ToolTip.Show("Invalid password!", tbPasswordCurrent);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Check if provided password match storred password
        /// </summary>
        /// <returns></returns>
        private bool CheckCurrentPassword()
        {
            // Read current password
            var currentPassword = WinReg.ReadByteArray(Constants.REGISTRY_PATH_LOCK, "Value");
            if ((currentPassword == null || currentPassword.Length == 0) && string.IsNullOrEmpty(tbPasswordCurrent.Text))
                return true;

            // Get seed from registry
            var seedBytes = WinReg.ReadByteArray(Constants.REGISTRY_PATH_LOCK, "Encryption");
            if (seedBytes == null && seedBytes.Length == 0)
                return false;

            // Decode current password
            string currentPasswordDec = Password.Decrypt(currentPassword, seedBytes.AsString());

            // Check if passwords match
            return (tbPasswordCurrent.Text == currentPasswordDec);
        }

        /// <summary>
        /// Check if user typed same passwords 
        /// </summary>
        /// <returns></returns>
        private bool CheckRetypePassword()
        {
            return tbPasswordNew.Text.Equals(tbPasswordNew2.Text);
        }

        /// <summary>
        /// Set new password
        /// </summary>
        private void SetCurrentPassword()
        {
            // Get seed from registry
            var seedBytes = WinReg.ReadByteArray(Constants.REGISTRY_PATH_LOCK, "Encryption");
            if (seedBytes == null || seedBytes.Length == 0)
            {
                seedBytes = Password.GenerateSeed(20).ToByteArray();
                WinReg.WriteByteArray(Constants.REGISTRY_PATH_LOCK, "Encryption", seedBytes);
            }

            // Encrypt provided password text
            var encryptedPassword = Password.Encrypt(tbPasswordNew.Text, seedBytes.AsString());
            WinReg.WriteByteArray(Constants.REGISTRY_PATH_LOCK, "Value", encryptedPassword);


        }

        private void FrmLock_Load(object sender, EventArgs e)
        {
            tbPasswordCurrent.Enabled = FrmMain.IsLockActive();
        }
    }
}
