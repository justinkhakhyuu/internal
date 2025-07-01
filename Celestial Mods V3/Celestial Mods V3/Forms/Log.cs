using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reborn;


namespace Celestial_Mods_V3
{
    public partial class Log : Form
    {

        public static api KeyAuthApp = new api(
 name: "Bindrdx1's Application", // Application Name
 ownerid: "WfJnjaPcTT", // Owner ID
 secret: "caa4f6b589cb54764b581c36ea000d1fcb60df094782c10829d1598b256cbb47", // Application Secret
 version: "1.0");
        public Log()
        {
            InitializeComponent();
            LoadInfo();
        }

    
        public void Alert(string msg, Notify.enmType type)
        {
            Notify frm = new Notify();
            frm.showAlert(msg, type);
        }
        private void LoadInfo()
        {
            user.Text = Properties.Settings.Default.Username;
            pass.Text = Properties.Settings.Default.Password;
            Properties.Settings.Default.Save();
        }

        private void SaveInfo()
        {
            user.Text = Properties.Settings.Default.Username = user.Text;
            pass.Text = Properties.Settings.Default.Password = pass.Text;
            Properties.Settings.Default.Save();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(user.Text, pass.Text);
            SaveInfo();

            if (KeyAuthApp.response.success)
            {
                string username = KeyAuthApp.user_data.username;
                string expiry = KeyAuthApp.user_data.expiry;
                string version = KeyAuthApp.app_data.version;

                this.Hide();
                Hack aa = new Hack();
                aa.Show();
                this.Alert("Logged In !", Notify.enmType.Applied);


            }
            else
            {
                this.Alert(KeyAuthApp.response.message, Notify.enmType.Error);
            }
        }


        private void CheckAdminRights()
        {
            // Get the current Windows identity
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            // Check if the user is an administrator
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                MessageBox.Show("This application needs to be run as an administrator. Please restart the app as an administrator.",
                                "Administrator Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                // Exit the application
                Application.Exit();
                Environment.Exit(0);
            }
        }

        private void CheckBlueStacksRunning()
        {
            // Define the process name for BlueStacks
            string processName = "HD-Player"; // Common process name for BlueStacks

            // Check if any process with the specified name is running
            bool isBlueStacksRunning = Process.GetProcessesByName(processName).Any();

            if (!isBlueStacksRunning)
            {
                MessageBox.Show("BlueStacks is not running. This application will now exit.",
                                "BlueStacks Not Detected",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                // Exit the application
                Application.Exit();
                Environment.Exit(0);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if the Delete key is pressed
            if (keyData == Keys.Delete)
            {

                Application.Exit();
                return true;
            }

            // Let the base class handle other keys
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Log_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main CC = new Main();
            CC.Show();
        }
    }
}

