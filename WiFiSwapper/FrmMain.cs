using Microsoft.Win32;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using WiFiSwapper.Code.Extensions;
using WiFiSwapper.Core;
using WiFiSwapper.Core.Extensions;
using WiFiSwapper.Models;

namespace WiFiSwapper
{
    public partial class FrmMain : Form
    {
        private FileVersionInfo m_VersionInfo;

        public FrmMain()
        {
            InitializeComponent();

            m_VersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            this.Text += $" by {GetCompany()} / {GetCopyright()}";
            this.tsslVersion.Text = "Version: " + m_VersionInfo.ProductVersion;
        }

        private string GetCompany() => m_VersionInfo.CompanyName;

        private string GetCopyright() => m_VersionInfo.LegalCopyright;


        /// <summary>
        /// Load Active WiFi Profiles
        /// </summary>
        private async void LoadWiFiProfilesAsync()
        {
            Cursor = Cursors.WaitCursor;

            lvActive.Items.Clear();

            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = "netsh.exe",
                Arguments = "wlan show profiles",
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            try
            {
                Process process = Process.Start(psInfo);
                process?.WaitForExit();

                string line;
                while ((line = await process?.StandardOutput.ReadLineAsync()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (Regex.Match(line, "^.*All User Profile.*$").Success)
                        {
                            string[] parts = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length == 2)
                                lvActive.Items.Add(new ListViewItem { Text = parts[1].Trim() });
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Load inactive profiles from registry
        /// </summary>
        private async void LoadInactiveProfilesAsync()
        {
            Cursor = Cursors.WaitCursor;

            lvInactive.Items.Clear();

            RegistryKey key = Registry.CurrentUser.OpenSubKey(Constants.REGISTRY_PATH_PROFILES, true);
            if (key != null)
            {
                foreach (string profileName in key.GetValueNames())
                {
                    lvInactive.Items.Add(new ListViewItem { Text = profileName });
                    //RestoreProfile(profileName);
                }
            }

            Cursor= Cursors.Default;
        }

        /// <summary>
        /// After form load action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmMain_Load(object sender, EventArgs e)
        {
            LoadWiFiProfilesAsync();
            LoadInactiveProfilesAsync();
        }

        /// <summary>
        /// Resize first column after list view resize event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvProfiles_Resize(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            lv.Columns[0].Width = lv.Width - 30;
        }

        /// <summary>
        /// Resize form action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            btnSwapProfiles.Location = new Point(
                ((pMiddle.Width - btnSwapProfiles.Width) / 2).NotLessThan(0),
                ((pMiddle.Height - btnSwapProfiles.Height) / 2).NotLessThan(28)
            );

            tssSeparator.Width = statusStrip1.Width - tsslVersion.Width - tsslBuyCoffeTo.Width - 40;
        }

        /// <summary>
        /// Click on add new WiFi profile button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActiveAdd_Click(object sender, EventArgs e)
        {
            using (FrmProfileEdit newProfile = new FrmProfileEdit())
            {
                if (newProfile.ShowDialog() == DialogResult.OK)
                {
                    Profile profile = newProfile.GetProfile();

                    if (lvActive.Items.Cast<ListViewItem>().Where(i => i.Text.Equals(profile.Name)).Any())
                    {
                        MessageBox.Show($"Active profile: {profile.Name} already exists!");
                        return;
                    }

                    // Import new profile
                    AddActiveProfile(
                        new WLANProfile(
                            profile.Name,
                            profile.Kind.Code,
                            profile.Password
                        ));

                    // Reload profiles
                    LoadWiFiProfilesAsync();
                }
            }
        }

        /// <summary>
        /// Click on add new inactive WiFi profile button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInactiveAdd_Click(object sender, EventArgs e)
        {
            using (FrmProfileEdit newProfile = new FrmProfileEdit())
            {
                if (newProfile.ShowDialog() == DialogResult.OK)
                {
                    Profile profile = newProfile.GetProfile();

                    if (lvInactive.Items.Cast<ListViewItem>().Where(i => i.Text.Equals(profile.Name)).Any())
                    {
                        MessageBox.Show($"Alternate profile: {profile.Name} already exists!");
                        return;
                    }

                    AddInactiveProfile(
                        new WLANProfile(
                            profile.Name,
                            profile.Kind.Code,
                            profile.Password
                        ));
                    LoadInactiveProfilesAsync();
                }
            }
        }

        /// <summary>
        /// Add active profile
        /// </summary>
        /// <param name="profile"></param>
        private void AddActiveProfile(WLANProfile profile)
        {
            string fileName = $"{Environment.CurrentDirectory}\\Wi-Fi-{profile.Name}.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(WLANProfile));
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t"
            };

            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                serializer.Serialize(writer, profile);
                writer.Close();
            }

            ImportActiveProfile(fileName);
            File.Delete(fileName);
        }

        /// <summary>
        /// Add inactive profile
        /// </summary>
        /// <param name="profile"></param>
        private void AddInactiveProfile(WLANProfile profile)
        {
            string fileName = $"{Environment.CurrentDirectory}\\Wi-Fi-{profile.Name}.xml";

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(WLANProfile));
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t"
                };

                using (XmlWriter writer = XmlWriter.Create(fileName, settings))
                {
                    serializer.Serialize(writer, profile);
                    writer.Close();
                }

                string profileContent = File.ReadAllText(fileName);
                File.Delete(fileName);

                RegistryWriteProfile(profile.Name, profileContent.Base64());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export WiFi profile to file
        /// </summary>
        /// <param name="path">Destination path to export</param>
        /// <param name="profileName">WiFi profile name to export</param>
        private void ExportActiveProfile(string path, string profileName)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = "netsh.exe",
                Arguments = $"wlan export profile name={profileName} folder={path}",
                UseShellExecute = false
            };

            Process process = Process.Start(psInfo);

            process.WaitForExit();
        }

        /// <summary>
        /// Import WiFi profile from file
        /// </summary>
        /// <param name="fileName">File name to import</param>
        private void ImportActiveProfile(string fileName)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = "netsh.exe",
                Arguments = $"wlan add profile filename={fileName}",
                UseShellExecute = false
            };

            Process process = Process.Start(psInfo);
            process.WaitForExit();
        }

        /// <summary>
        /// Delete active profile
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void DeleteActiveProfile(string profileName)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = "netsh.exe",
                Arguments = $"wlan delete profile name={profileName} i=*",
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            Process process = Process.Start(psInfo);
            process.WaitForExit();
        }

        /// <summary>
        /// Delete inactive profile from Registry
        /// </summary>
        /// <param name="profileName"></param>
        private void DeleteInactiveProfile(string profileName)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(Constants.REGISTRY_PATH_PROFILES, true);
            if (key != null)
            {
                key.DeleteValue(profileName);
            }
        }

        /// <summary>
        /// Remove active profile button click action 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActiveRemove_Click(object sender, EventArgs e)
        {
            if (lvActive.SelectedItems.Count != 1) return;

            if (MessageBox.Show(
                "Are you sure you want to remove active profile?",
                "Active profile",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string profileName = (string)(lvActive.SelectedItems[0].Text ?? string.Empty);
                if (!string.IsNullOrEmpty(profileName))
                {
                    DeleteActiveProfile(profileName);
                    LoadWiFiProfilesAsync();
                }
            }
        }

        /// <summary>
        /// Remove inactive profile button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInactiveRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to remove alternate profile?",
                "Alternate profile",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string profileName = (string)((lvInactive.SelectedItems[0]).Text ?? string.Empty);
                if (!string.IsNullOrEmpty(profileName))
                {
                    DeleteInactiveProfile(profileName);
                    LoadInactiveProfilesAsync();
                }
            }
        }

        /// <summary>
        /// Active profile list selection changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnActiveRemove.Enabled = lvActive.SelectedItems.Count == 1;
        }

        /// <summary>
        /// Inactive profile list selection changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvInactive_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnInactiveRemove.Enabled = lvInactive.SelectedItems.Count == 1;
        }

        /// <summary>
        /// Write inactive profile to registry
        /// </summary>
        /// <param name="profileName"></param>
        /// <param name="data"></param>
        private void RegistryWriteProfile(string profileName, byte[] data)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Constants.REGISTRY_PATH_PROFILES, true);
                if (key == null)
                    key = Registry.CurrentUser.CreateSubKey(Constants.REGISTRY_PATH_PROFILES, true);

                if (key == null)
                    throw new Exception("Couldn't create Registry Key!");

                key.SetValue(profileName, data, RegistryValueKind.Binary);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Read inactive profile from registry
        /// </summary>
        /// <param name="profileName"></param>
        /// <returns></returns>
        private byte[] RegistryReadProfile(string profileName)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(Constants.REGISTRY_PATH_PROFILES, true);
            if (key != null)
            {
                object data = key.GetValue(profileName);
                if (data != null)
                    return (byte[])data;
            }

            return new byte[0];
        }

        /// <summary>
        /// Click on lock menu item action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmLock lockForm = new FrmLock())
            {
                lockForm.ShowDialog();
            }
        }

        /// <summary>
        /// Click on unlock menu item action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmUnlock lockForm = new FrmUnlock(FrmUnlock.UnlockKind.Remove))
            {
                lockForm.ShowDialog();
            }
        }

        /// <summary>
        /// Swap profiles button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwapProfiles_Click(object sender, EventArgs e)
        {
            if (IsLockActive())
            {
                using (FrmUnlock unlockForm = new FrmUnlock(FrmUnlock.UnlockKind.Verify))
                {
                    if (unlockForm.ShowDialog() == DialogResult.Abort)
                        return;
                }
            }

            SwapProfiels();
        }

        /// <summary>
        /// Swap active with inactive profiles
        /// </summary>
        private void SwapProfiels()
        {
            Cursor = Cursors.WaitCursor;
            btnSwapProfiles.Enabled = false;

            // Create new active profiles based on inactive profiles
            foreach (ListViewItem inactiveProfile in lvInactive.Items)
            {
                WLANProfile profile = GetInactiveProfile(inactiveProfile.Text);
                if (profile != null)
                {
                    AddActiveProfile(profile);
                    DeleteInactiveProfile(inactiveProfile.Text);
                }
            }

            foreach (ListViewItem activeProfile in lvActive.Items)
            {
                WLANProfile profile = GetActiveProfile(activeProfile.Text);
                if (profile != null)
                {
                    AddInactiveProfile(profile);
                    DeleteActiveProfile(activeProfile.Text);
                }
            }

            Cursor = Cursors.Default;

            // Reload profiles view
            LoadWiFiProfilesAsync();
            LoadInactiveProfilesAsync();

            btnSwapProfiles.Enabled = true;
        }

        /// <summary>
        /// Get active profile
        /// </summary>
        /// <param name="profileName"></param>
        /// <returns></returns>
        private WLANProfile GetActiveProfile(string profileName)
        {
            WLANProfile profile = null;

            string tempPath = Path.GetTempPath();
            string fileName = $"Wi-Fi-{profileName}.xml";
            try
            {
                ExportActiveProfile(tempPath, profileName);
                string profileContent = File.ReadAllText(tempPath + fileName);
                File.Delete(tempPath + fileName);

                XmlSerializer serializer = new XmlSerializer(typeof(WLANProfile));

                // Deserialize profile
                using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(profileContent)))
                using (XmlReader reader = XmlReader.Create(memoryStream))
                {
                    profile = (WLANProfile)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return profile;
        }

        /// <summary>
        /// Get inactive profile
        /// </summary>
        /// <param name="profileName"></param>
        /// <returns></returns>
        private WLANProfile GetInactiveProfile(string profileName)
        {
            WLANProfile profile = null;

            try
            {
                // Read profile from registry to file
                byte[] profileData = RegistryReadProfile(profileName);
                XmlSerializer serializer = new XmlSerializer(typeof(WLANProfile));
                
                // Deserialize profile
                using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(profileData.Base64())))
                using (XmlReader reader = XmlReader.Create(memoryStream))
                {
                    profile = (WLANProfile)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return profile;
        }

        /// <summary>
        /// Check if program has active lock
        /// </summary>
        /// <returns></returns>
        public static bool IsLockActive()
        {
            return WinReg.KeyExists(Constants.REGISTRY_PATH_LOCK);
        }

        /// <summary>
        /// Enable disable menu items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accessToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            unlockToolStripMenuItem.Enabled = IsLockActive();
        }

        private void tsslBuyCoffeTo_Click(object sender, EventArgs e)
        {
            buyMeACoffeeAction();
        }

        private void buyMeCoffeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buyMeACoffeeAction();
        }

        private void buyMeACoffeeAction()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://buycoffee.to/rico",
                UseShellExecute = true
            });
        }

        private void aboutWiFiSwapperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmAbout aboutForm = new FrmAbout())
            {
                aboutForm.ShowDialog();
            }
        }
    }
}
