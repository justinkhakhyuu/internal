using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Celestial;
using Guna.UI2.WinForms;
using LuciferMem;

namespace Celestial_Mods_V3
{
    public partial class Main : Form
    {



        Cosmic memoryfast = new Cosmic();
        private IEnumerable<long> speedResult;
        private IEnumerable<long> wallResult;
        public static readonly Cosmic Memory = new Cosmic();
        public static bool Streaming;
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);


        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //private const int HOTKEY_ID_HEAD = 1;
       /// private const int HOTKEY_ID_NECK = 2;
       // private const int HOTKEY_ID_SHOULDER = 3;
        //private const uint MOD_NONE = 0x0000; // No Ctrl, Alt, Shift

        private string username;
        private string expiry;
        private string version;


        public Main()
        {
            InitializeComponent();
            labelUsername.Text = $"Username : {username}";
            tsekk.Text = $"Expiry : {expiry}";
            labelVersion.Text = $"Version : {version}";
         ////////   RegisterHotKey(this.Handle, HOTKEY_ID_HEAD, MOD_NONE, Keys.F3);
            ///RegisterHotKey(this.Handle, HOTKEY_ID_NECK, MOD_NONE, Keys.F6);
          ////  RegisterHotKey(this.Handle, HOTKEY_ID_SHOULDER, MOD_NONE, Keys.F10);
          //  RegisterHotKey(this.Handle, 4, MOD_NONE, Keys.F7); // Wall Hack Toggle
          //  RegisterHotKey(this.Handle, 5, MOD_NONE, Keys.F8); // Camera Hack Toggle
          //  RegisterHotKey(this.Handle, 6, MOD_NONE, Keys.F9); // Speed Hack Toggle
            this.Load += Main_Load;

        }

        public void Alert(string msg, Notify.enmType type)
        {
            Notify frm = new Notify();
            frm.showAlert(msg, type);
        }



      /*  protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();

                if (id == `HOTKEY_ID_HEAD)
                {
                    HeadSwitch.Checked = !HeadSwitch.Checked;
                    this.Alert("Head Aimbot Toggled (Global)", Notify.enmType.Info);
                    Console.Beep(900, 500);
                }
                else if (id == HOTKEY_ID_NECK)
                {
                    NeckSwitch.Checked = !NeckSwitch.Checked;
                    this.Alert("Neck Aimbot Toggled (Global)", Notify.enmType.Info);
                    Console.Beep(1000, 500);
                }
                else if (id == HOTKEY_ID_SHOULDER)
                {
                    ShoulderSwitch.Checked = !ShoulderSwitch.Checked;
                    this.Alert("Neckv2 Aimbot Toggled (Global)", Notify.enmType.Info);
                    Console.Beep(1000, 500);
                }
            


            }

            base.WndProc(ref m);
        }*/


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
           // UnregisterHotKey(this.Handle, HOTKEY_ID_HEAD);
          /// UnregisterHotKey(this.Handle, HOTKEY_ID_SHOULDER);
          //  base.OnFormClosing(e);
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            aimbotpanel.BringToFront();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            sniperpanel.BringToFront();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            visualpanel.BringToFront();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
           // brutalpanel.BringToFront();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            settingpanel.BringToFront();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            infopanel.BringToFront();
        }


        public void ExecuteCommand(string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (Process process = new Process()
            {
                StartInfo = processStartInfo
            })
            {
                process.Start();
                process.StandardInput.WriteLine(command);
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.WaitForExit();
            }
        }
        private void guna2ToggleSwitch16_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch16.Checked)
            {
                this.ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=in action=block profile=any program=\"C:\\Program Files\\BlueStacks\\HD-Player.exe\"");
                this.ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=out action=block profile=any program=\"C:\\Program Files\\BlueStacks\\HD-Player.exe\"");
                this.ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=in action=block profile=any program=\"C:\\Program Files\\BlueStacks_nxt\\HD-Player.exe\"");
                this.ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=out action=block profile=any program=\"C:\\Program Files\\BlueStacks_nxt\\HD-Player.exe\"");
                this.ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=in action=block profile=any program=\"C:\\Program Files\\BlueStacks_msi5\\HD-Player.exe\"");
                this.ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=out action=block profile=any program=\"C:\\Program Files\\BlueStacks_msi5\\HD-Player.exe\"");

            }
            else
            {
                this.ExecuteCommand("netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files\\BlueStacks\\HD-Player.exe\"");
                this.ExecuteCommand("netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files\\BlueStacks_nxt\\HD-Player.exe\"");
                this.ExecuteCommand("netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files\\BlueStacks_msi5\\HD-Player.exe\"");

            }
        }

        private void guna2ToggleSwitch14_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch14.Checked)
            {
                base.ShowInTaskbar = false;
                Main.Streaming = true;
                Main.SetWindowDisplayAffinity(base.Handle, 17U);

            }
            else
            {
                base.ShowInTaskbar = true;
                Main.Streaming = false;
                Main.SetWindowDisplayAffinity(base.Handle, 0U);

            }
        }

        private async void guna2ToggleSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }

        private void guna2ToggleSwitch6_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }
        public string PID;
        private List<long> lastWalladdress = new List<long>();
        private string wallsearch;
        private string wallreplace;
        private async void guna2ToggleSwitch7_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }

        private void guna2ToggleSwitch8_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }
        private IEnumerable<long> cameraresult;
        private async void guna2ToggleSwitch9_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }

        private void guna2ToggleSwitch10_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            HeadSwitch.Visible = false;
            NeckSwitch.Visible = false;
            ShoulderSwitch.Visible = false;

            HeadSwitch.Location = new Point(568, 19);
            NeckSwitch.Location = new Point(568, 19);
            ShoulderSwitch.Location = new Point(568, 19);


            switch (guna2ComboBox3.SelectedIndex)
            {
                case 0:
                    HeadSwitch.Visible = true;
                    break;
                case 1:
                    NeckSwitch.Visible = true;
                    break;
                case 2:
                    ShoulderSwitch.Visible = true;
                    break;

            }
        }
        private static Mem Lucifer = new Mem();

        private Dictionary<long, int> orginalValues = new Dictionary<long, int>();
        private Dictionary<long, int> orginalValues1 = new Dictionary<long, int>();
        private Dictionary<long, int> orginalValues2 = new Dictionary<long, int>();
        private Dictionary<long, int> orginalValues3 = new Dictionary<long, int>();

        long Offset1 = 0x80;
        long offset2 = 0x7C;
        private async void HeadSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (HeadSwitch.Checked)
            {
                orginalValues1.Clear();
                orginalValues.Clear();
                orginalValues2.Clear();
                orginalValues3.Clear();

                Int64 readOffset = Convert.ToInt64(Offset1);
                Int64 writeOffset = Convert.ToInt64(offset2);

                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                Lucifer.OpenProcess(proc);

                var result = await Lucifer.AoBScan(0x0000000000000000, 0x00007fffffffffff, "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 A5 43", true, true);

                if (result.Count() != 0)
                {
                    foreach (var CurrentAddress in result)
                    {
                        Int64 addressToSave = CurrentAddress + writeOffset;
                        var currentBytes = Lucifer.SunIsKind(addressToSave.ToString("X"), sizeof(int));
                        int currentValue = BitConverter.ToInt32(currentBytes, 0); orginalValues[addressToSave] = currentValue;
                        Int64 addressToSave9 = CurrentAddress + readOffset;
                        var currentBytes9 = Lucifer.SunIsKind(addressToSave9.ToString("X"), sizeof(int));
                        int currentValue9 = BitConverter.ToInt32(currentBytes9, 0); orginalValues1[addressToSave9] = currentValue9;
                        Int64 headbytes = CurrentAddress + readOffset;
                        Int64 chestbytes = CurrentAddress + writeOffset;
                        var bytes = Lucifer.SunIsKind(headbytes.ToString("X"), sizeof(int));
                        int Read = BitConverter.ToInt32(bytes, 0);
                        var bytes2 = Lucifer.SunIsKind(chestbytes.ToString("X"), sizeof(int));
                        int Read2 = BitConverter.ToInt32(bytes2, 0);
                        Lucifer.WriteMemory(chestbytes.ToString("X"), "int", Read.ToString());
                        Lucifer.WriteMemory(headbytes.ToString("X"), "int", Read2.ToString());
                        Int64 addressToSave1 = CurrentAddress + writeOffset;
                        var currentBytes1 = Lucifer.SunIsKind(addressToSave1.ToString("X"), sizeof(int));
                        int curentValue1 = BitConverter.ToInt32(currentBytes1, 0); orginalValues2[addressToSave1] = curentValue1;
                        Int64 addressToSave19 = CurrentAddress + readOffset;
                        var currentBytes19 = Lucifer.SunIsKind(addressToSave19.ToString("X"), sizeof(int));
                        int currentValues19 = BitConverter.ToInt32(currentBytes19, 0); orginalValues3[addressToSave19] = currentValues19;
                    }
                    orginalValues1.Clear();
                    orginalValues.Clear();
                    orginalValues2.Clear();
                    orginalValues3.Clear();
                    this.Alert("SuccessFully Applied", Notify.enmType.Applied);
                    Console.Beep(900, 600);
                }
            }
        }

        private Dictionary<long, int> orginalValues5 = new Dictionary<long, int>();
        private Dictionary<long, int> orginalValues6 = new Dictionary<long, int>();
        private Dictionary<long, int> orginalValues7 = new Dictionary<long, int>();
        private Dictionary<long, int> orginalValues8 = new Dictionary<long, int>();

        long Offset3 = 0xEE;
        long offset4 = 0x29A;
        private async void NeckSwitch_CheckedChanged(object sender, EventArgs e)
        {
            orginalValues5.Clear();
            orginalValues6.Clear();
            orginalValues7.Clear();
            orginalValues8.Clear();


            Int64 readOffset = Convert.ToInt64(Offset3);
            Int64 writeOffset = Convert.ToInt64(offset4);

            Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
            Lucifer.OpenProcess(proc);

            var result = await Lucifer.AoBScan(0x0000000000000000, 0x00007fffffffffff, "FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 A5 43", true, true);

            if (result.Count() != 0)
            {
                foreach (var CurrentAddress in result)
                {
                    Int64 addressToSave = CurrentAddress + writeOffset;
                    var currentBytes = Lucifer.SunIsKind(addressToSave.ToString("X"), sizeof(int));
                    int currentValue = BitConverter.ToInt32(currentBytes, 0); orginalValues5[addressToSave] = currentValue;
                    Int64 addressToSave9 = CurrentAddress + readOffset;

                    var currentBytes9 = Lucifer.SunIsKind(addressToSave9.ToString("X"), sizeof(int));
                    int currentValue9 = BitConverter.ToInt32(currentBytes9, 0); orginalValues6[addressToSave9] = currentValue9;
                    Int64 headbytes = CurrentAddress + readOffset;
                    Int64 chestbytes = CurrentAddress + writeOffset;

                    var bytes = Lucifer.SunIsKind(headbytes.ToString("X"), sizeof(int));
                    int Read = BitConverter.ToInt32(bytes, 0);
                    var bytes2 = Lucifer.SunIsKind(chestbytes.ToString("X"), sizeof(int));
                    int Read2 = BitConverter.ToInt32(bytes2, 0);

                    Lucifer.WriteMemory(chestbytes.ToString("X"), "int", Read.ToString());
                    Lucifer.WriteMemory(headbytes.ToString("X"), "int", Read2.ToString());

                    Int64 addressToSave1 = CurrentAddress + writeOffset;
                    var currentBytes1 = Lucifer.SunIsKind(addressToSave1.ToString("X"), sizeof(int));
                    int curentValue1 = BitConverter.ToInt32(currentBytes1, 0); orginalValues7[addressToSave1] = curentValue1;

                    Int64 addressToSave19 = CurrentAddress + readOffset;
                    var currentBytes19 = Lucifer.SunIsKind(addressToSave19.ToString("X"), sizeof(int));
                    int currentValues19 = BitConverter.ToInt32(currentBytes19, 0); orginalValues8[addressToSave19] = currentValues19;
                }
                orginalValues5.Clear();
                orginalValues6.Clear();
                orginalValues7.Clear();
                orginalValues8.Clear();
                this.Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 600);
            }
        }

        private Dictionary<long, int> orginalValues9 = new Dictionary<long, int>();
        private Dictionary<long, int> orginalValues10 = new Dictionary<long, int>();
        private Dictionary<long, int> orginalValues11 = new Dictionary<long, int>();
        private Dictionary<long, int> orginalValues12 = new Dictionary<long, int>();

        long Offset5 = 0xA2;
        long offset6 = 0x9E;
        private async void ShoulderSwitch_CheckedChanged(object sender, EventArgs e)
        {
            orginalValues9.Clear();
            orginalValues10.Clear();
            orginalValues11.Clear();
            orginalValues12.Clear();



            Int64 readOffset = Convert.ToInt64(Offset5);
            Int64 writeOffset = Convert.ToInt64(offset6);

            Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
            Lucifer.OpenProcess(proc);

            var result = await Lucifer.AoBScan(0x0000000000000000, 0x00007fffffffffff, "FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 F8 49 16 82 00 00 00 00 F8 94 FC 7F C8 94 FC 7F B8 95 FC 7F E0 94 FC 7F 80 94 FC 7F D0 95 FC 7F E8 95 FC 7F 38 97 FC 7F 98 94 FC 7F 68 94 FC 7F 80 94 FC 7F 50 94 FC 7F 58 95 FC 7F 00 00 00 00 A0 95 FC 7F 40 95 FC 7F 10 95 FC 7F 70 95 FC 7F 28 95 FC 7F 88 95 FC 7F 00 00 00 00 20 8D 3D 80 88 68 88 7F 00 00 00 00 20 77 4C 80 00 00 00 00 80 AA FC 7F 70 B1 AB 81 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF 18 26 FC 82 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00", true, true);

            if (result.Count() != 0)
            {
                foreach (var CurrentAddress in result)
                {
                    Int64 addressToSave = CurrentAddress + writeOffset;
                    var currentBytes = Lucifer.SunIsKind(addressToSave.ToString("X"), sizeof(int));
                    int currentValue = BitConverter.ToInt32(currentBytes, 0); orginalValues9[addressToSave] = currentValue;
                    Int64 addressToSave9 = CurrentAddress + readOffset;

                    var currentBytes9 = Lucifer.SunIsKind(addressToSave9.ToString("X"), sizeof(int));
                    int currentValue9 = BitConverter.ToInt32(currentBytes9, 0); orginalValues10[addressToSave9] = currentValue9;
                    Int64 headbytes = CurrentAddress + readOffset;
                    Int64 chestbytes = CurrentAddress + writeOffset;

                    var bytes = Lucifer.SunIsKind(headbytes.ToString("X"), sizeof(int));
                    int Read = BitConverter.ToInt32(bytes, 0);
                    var bytes2 = Lucifer.SunIsKind(chestbytes.ToString("X"), sizeof(int));
                    int Read2 = BitConverter.ToInt32(bytes2, 0);

                    Lucifer.WriteMemory(chestbytes.ToString("X"), "int", Read.ToString());
                    Lucifer.WriteMemory(headbytes.ToString("X"), "int", Read2.ToString());

                    Int64 addressToSave1 = CurrentAddress + writeOffset;
                    var currentBytes1 = Lucifer.SunIsKind(addressToSave1.ToString("X"), sizeof(int));
                    int curentValue1 = BitConverter.ToInt32(currentBytes1, 0); orginalValues11[addressToSave1] = curentValue1;

                    Int64 addressToSave19 = CurrentAddress + readOffset;
                    var currentBytes19 = Lucifer.SunIsKind(addressToSave19.ToString("X"), sizeof(int));
                    int currentValues19 = BitConverter.ToInt32(currentBytes19, 0); orginalValues12[addressToSave19] = currentValues19;
                }
                orginalValues9.Clear();
                orginalValues10.Clear();
                orginalValues11.Clear();
                orginalValues12.Clear();
                this.Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 600);

            }
        }


        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }

        private async void Switch2x_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }


        private async void Switch4x_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }
        private async void guna2ToggleSwitch12_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }

        private async void guna2ToggleSwitch13_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }



        private async void guna2ToggleSwitch17_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RedChams.Location = new Point(568, 19);
            BlueChams.Location = new Point(568, 19);
            TransChams.Location = new Point(568, 19);

            switch (guna2ComboBox3.SelectedIndex)
            {
                case 0:
                    RedChams.Visible = true;
                    break;
                case 1:
                    BlueChams.Visible = true;
                    break;
                case 2:
                    TransChams.Visible = true;
                    break;
            }
        }

        private static void LuciferFallenAngel(string resourceName, string outputPath)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            using (Stream resourceStream = executingAssembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    throw new ArgumentException($"Resource '{resourceName}' not found.");
                }
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] buffer = new byte[resourceStream.Length];
                    resourceStream.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                }
            }
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        const uint PROCESS_CREATE_THREAD = 0x2;
        const uint PROCESS_QUERY_INFORMATION = 0x400;
        const uint PROCESS_VM_OPERATION = 0x8;
        const uint PROCESS_VM_WRITE = 0x20;
        const uint PROCESS_VM_READ = 0x10;
        const uint MEM_COMMIT = 0x1000;
        const uint PAGE_READWRITE = 4;

        private void RedChams_CheckedChanged(object sender, EventArgs e)
        {
            if (RedChams.Checked)
            {
                string processName = "HD-Player";
                string dllResourceName = "Celestial_Mods_V3.Properties.Red.dll";
                string tempDllPath = Path.Combine(Path.GetTempPath(), "Red.dll");
                LuciferFallenAngel(dllResourceName, tempDllPath);
                Process[] targetProcesses = Process.GetProcessesByName(processName);
                if (targetProcesses.Length == 0)
                {
                    Console.WriteLine($"Waiting for {processName}.exe...");
                }
                if (targetProcesses.Length == 0)
                {
                    MessageBox.Show("Fuck", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Process targetProcess = targetProcesses[0];
                    IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)tempDllPath.Length, MEM_COMMIT, PAGE_READWRITE);
                    IntPtr bytesWritten;
                    WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(tempDllPath), (uint)tempDllPath.Length, out bytesWritten);
                    CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
                }
            }
        }

        private void BlueChams_CheckedChanged(object sender, EventArgs e)
        {
            if (BlueChams.Checked)
            {
                string processName = "HD-Player";
                string dllResourceName = "Celestial_Mods_V3.Properties.blue.dll";
                string tempDllPath = Path.Combine(Path.GetTempPath(), "blue.dll");
                LuciferFallenAngel(dllResourceName, tempDllPath);
                Process[] targetProcesses = Process.GetProcessesByName(processName);
                if (targetProcesses.Length == 0)
                {
                    Console.WriteLine($"Waiting for {processName}.exe...");
                }
                if (targetProcesses.Length == 0)
                {
                    MessageBox.Show("Fuck", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Process targetProcess = targetProcesses[0];
                    IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)tempDllPath.Length, MEM_COMMIT, PAGE_READWRITE);
                    IntPtr bytesWritten;
                    WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(tempDllPath), (uint)tempDllPath.Length, out bytesWritten);
                    CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
                }
            }
        }

        private void TransChams_CheckedChanged(object sender, EventArgs e)
        {
            if (TransChams.Checked)
            {
                string processName = "HD-Player";
                string dllResourceName = "Celestial_Mods_V3.Properties.OxcyShop - SKIN 2D.dll";
                string tempDllPath = Path.Combine(Path.GetTempPath(), "OxcyShop - SKIN 2D.dll");
                LuciferFallenAngel(dllResourceName, tempDllPath);
                Process[] targetProcesses = Process.GetProcessesByName(processName);
                if (targetProcesses.Length == 0)
                {
                    Console.WriteLine($"Waiting for {processName}.exe...");
                }
                if (targetProcesses.Length == 0)
                {
                    MessageBox.Show("Fuck", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Process targetProcess = targetProcesses[0];
                    IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)tempDllPath.Length, MEM_COMMIT, PAGE_READWRITE);
                    IntPtr bytesWritten;
                    WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(tempDllPath), (uint)tempDllPath.Length, out bytesWritten);
                    CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
                }
            }
        }

        private void guna2ToggleSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch4.Checked)
            {
                string processName = "HD-Player";
                string dllResourceName = "Celestial_Mods_V3.Properties.Sun.dll";
                string tempDllPath = Path.Combine(Path.GetTempPath(), "Sun.dll");
                LuciferFallenAngel(dllResourceName, tempDllPath);
                Process[] targetProcesses = Process.GetProcessesByName(processName);
                if (targetProcesses.Length == 0)
                {
                    Console.WriteLine($"Waiting for {processName}.exe...");
                }
                if (targetProcesses.Length == 0)
                {
                    MessageBox.Show("Fuck", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Process targetProcess = targetProcesses[0];
                    IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)tempDllPath.Length, MEM_COMMIT, PAGE_READWRITE);
                    IntPtr bytesWritten;
                    WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(tempDllPath), (uint)tempDllPath.Length, out bytesWritten);
                    CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
                }
            }
        }


        private async void guna2ToggleSwitch19_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }

        private async void guna2ToggleSwitch20_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ToggleSwitch15_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = guna2ToggleSwitch15.Checked;
        }

        private async void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }

        private async void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }

        private async void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }

        public enum enmType
        {
            Success,
            Error,
            Info,
            Applied,
            Warning // ← Add this
        }

        private async void guna2ToggleSwitch11_CheckedChanged(object sender, EventArgs e)
        {
            this.Alert("BRUTAL MENU!!!", Notify.enmType.Applied);
        }
        private async void guna2ToggleSwitch18_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch18.Checked)
            {


                string search = "10 4C 2D E9 08 B0 8D E2 0C 01 9F E5 00 00 8F E0 00 00 D0 E5 00 00 50 E3 06 00 00 1A FC 00 9F E5 00 00 9F E7 00 00 90 E5";
                string replace = "01 00 A0 E3 1E FF 2F E1";

                bool k = false;

                if (Process.GetProcessesByName("HD-Player").Length > 0)
                {
                    Memory.SetProcess(new string[] { "HD-Player" });

                    IEnumerable<long> wl = await Memory.AoBScan(search);

                    if (wl.Any())
                    {
                        foreach (var address in wl)
                        {
                            Memory.AobReplace(address, replace);
                        }
                        k = true;
                    }
                    if (k)
                    {
                        this.Alert("SuccessFully Applied", Notify.enmType.Applied);
                        Console.Beep(900, 500);
                    }
                    else
                    {

                    }
                }
            }
        }



        private async void guna2ToggleSwitch21_CheckedChanged(object sender, EventArgs e)
        {

            { 
                    List<string> searchList = new List<string>
{
               "DC 52 39 BD 27 C1 8B 3C C0 D0 F8 B9",
                "63 71 B0 BD 90 98 74 BB 00 00 80 B3",
                 "5D C1 AB 2C 09 04 FF 18 EF E5 11 59",
                 "7B F9 6C BD 58 34 09 BB B0 60 BE BA",
                  "21 60 29 1C 80 A2 F4 00 C8 D1 85 DE",
                  "13 66 CF 2C 2C 79 F9 7E 6C E1 D5 13",
                  "7B F9 6C BD 58 34 09 BB B0 60 BE BA",
                  "54 1B 87 BD 90 C6 D7 BA 80 54 99 B9",
                  "71 02 87 BD 90 FD D7 BA 40 18 98 39",
                  "CC F8 6C BD 40 D2 CE B9 58 64 BE 3A",

                  "00 00 00 00 40 D2 CE B9 58 64 BE 3A",
                  "CC F8 6C BD 40 D2 CE B9 58 64 BE 3A",
                  "76 FC DB BC 7C 5E 8B 3A 50 8B BB 3A",
                  "80 13 95 BC 30 FF 37 BB 00 FD 78 3B",
                  "1F 93 DB BC 90 BF 84 3A 20 A6 BB BA",
                  "EF A3 00 BE 40 B9 92 39 20 4E 07 BA",
                  "BC 19 FD BD B0 E3 A9 3A 80 42 23 B9"
                //  "",
                 // "",
                ///  "",
                //  "",
               //   "",


};

                    List<string> replaceList = new List<string>
{
                          "00 00 00 3E 0A D7 23 3D D2 A5 F9 BC",
                            "CD DC 79 44 90 98 74 BB 00 00 80 B3",
                           "CD DC 79 44 58 34 09 BB B0 60 BE BA",
                           "CD DC 79 44 58 34 09 BB B0 60 BE BA",
                           "CD DC 79 44 58 34 09 BB B0 60 BE BA",
                           "CD DC 79 44 58 34 09 BB B0 60 BE BA",
                           "CD DC 79 44 58 34 09 BB B0 60 BE BA",
                           "CD DC 79 44 90 C6 D7 BA 80 54 99 B9 ",
                           "CD DC 79 44 90 FD D7 BA 40 18 98 39",
                           "CD DC 79 44 40 D2 CE B9 58 64 BE 3A",
                        "CD DC 79 44 40 D2 CE B9 58 64 BE 3A",
                         "CD DC 79 44 40 D2 CE B9 58 64 BE 3A",
                         "CD DC 79 44 7C 5E 8B 3A 50 8B BB 3A",
                         "CD DC 79 44 30 FF 37 BB 00 FD 78 3B",
                         "CD DC 79 44 90 BF 84 3A 20 A6 BB BA",
                        "CD DC 79 44 40 B9 92 39 20 4E 07 BA",
                        "CD DC 79 44 B0 E3 A9 3A 80 42 23 B9"
};

                    bool k = false;


                    Memory.SetProcess(new string[] { "HD-Player" });

                    int i2 = 22000000;

                    for (int j = 0; j < searchList.Count; j++)
                    {
                        IEnumerable<long> cu = await Memory.AoBScan(searchList[j]);
                        string u = "0x" + cu.FirstOrDefault().ToString("X");

                        if (cu.Count() != 0)
                        {
                            for (int i = 0; i < cu.Count(); i++)
                            {
                                i2++;
                                Memory.AobReplace(cu.ElementAt(i), replaceList[j]);
                            }
                            k = true;
                        }
                    }

                    if (k == true)
                    {
                        this.Alert("SuccessFully Applied", Notify.enmType.Applied);
                        Console.Beep(900, 500);
                    }
                    else
                    {
                        this.Alert("Failed", Notify.enmType.Error);
                    }

                }
            }
        


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login1 aa = new Login1();
           aa.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {



            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void guna2Panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void settingpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void infopanel_Paint(object sender, PaintEventArgs e)
        {
            userrr.Text = $"Username : {username}";
            expiryyyy.Text = $"Expiry : {expiry}";
            versionnn.Text = $"Version : {version}";
        }
        public Main(string username, string expiry, string version) : this()
        {
            this.username = username;
            this.expiry = expiry;
            this.version = version;
        }
        private void Main_Load_1(object sender, EventArgs e)
        {
            // Set values to the labels
            userrr.Text = $"Username : {username}";
            expiryyyy.Text = $"Expiry : {expiry}";
            versionnn.Text = $"Version : {version}";
        }

        private void guna2Panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Log BB = new Log();
            BB.Show();
        }
    }
}

