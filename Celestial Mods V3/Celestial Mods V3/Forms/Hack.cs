using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Celestial_Mods_V3.domain.aimbots;
using Celestial;
using LuciferMem;

namespace Celestial_Mods_V3
{
    public partial class Hack : Form
    {
        private const int HOTKEY_ID_HEAD = 1;
        private const int HOTKEY_ID_NECK = 2;
        private const int HOTKEY_ID_SHOULDER = 3;

        private const uint MOD_NONE = 0x0000; // No Ctrl, Alt, Shift
        private const uint PROCESS_CREATE_THREAD = 0x2;
        private const uint PROCESS_QUERY_INFORMATION = 0x400;
        private const uint PROCESS_VM_OPERATION = 0x8;
        private const uint PROCESS_VM_WRITE = 0x20;
        private const uint PROCESS_VM_READ = 0x10;
        private const uint MEM_COMMIT = 0x1000;
        private const uint PAGE_READWRITE = 4;
        public static readonly Cosmic Memory = new Cosmic();
        public static bool Streaming;


        private static readonly Mem Lucifer = new Mem();


        private readonly long Offset30 = 0x60;
        private readonly long offset40 = 0x06;
        private readonly long offset60 = 0x2C;

        private readonly long Offset8 = 170;
        private readonly long offset9 = 168;


        private readonly long Offset90 = 0x16;

        private readonly Dictionary<long, int> orginalValues = new Dictionary<long, int>();
        private readonly Dictionary<long, int> orginalValues1 = new Dictionary<long, int>();


        private readonly Dictionary<long, int> orginalValues13 = new Dictionary<long, int>();
        private readonly Dictionary<long, int> orginalValues14 = new Dictionary<long, int>();
        private readonly Dictionary<long, int> orginalValues15 = new Dictionary<long, int>();
        private readonly Dictionary<long, int> orginalValues16 = new Dictionary<long, int>();
        private readonly Dictionary<long, int> orginalValues2 = new Dictionary<long, int>();
        private readonly Dictionary<long, int> orginalValues3 = new Dictionary<long, int>();
        private string expiry;

        //private ParticleSystem particleSystem = new ParticleSystem();
        //private Timer particleTimer;
        private IEnumerable<long> speedResult;

        private string username;

        private string version;
        private IEnumerable<long> wallResult;

        public Hack()
        {
            InitializeComponent();

            //   labelUsername.Text = $"Username : {username}";
            //    tsekk.Text = $"Expiry : {expiry}";
            //   labelVersion.Text = $"Version : {version}";
            RegisterHotKey(Handle, HOTKEY_ID_HEAD, MOD_NONE, Keys.F6);
            RegisterHotKey(Handle, HOTKEY_ID_NECK, MOD_NONE, Keys.F9);
            RegisterHotKey(Handle, HOTKEY_ID_SHOULDER, MOD_NONE, Keys.F10);
            //    RegisterHotKey(this.Handle, 4, MOD_NONE, Keys.F7); // Wall Hack Toggle
            //   RegisterHotKey(this.Handle, 5, MOD_NONE, Keys.F8); // Camera Hack Toggle
            //   RegisterHotKey(this.Handle, 6, MOD_NONE, Keys.F9); // Speed Hack Toggle
            Load += Hack_Load;
        }

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);


        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        private async void visualpanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ParticleTimer_Tick(object sender, EventArgs e)
        {
        }

        private async void TransChams_CheckedChanged(object sender, EventArgs e)
        {
        }

        private async void Hack_Load(object sender, EventArgs e)
        {
        }

        private async void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            settingpanel.BringToFront();
        }

        private async void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            brutalpanel.BringToFront();
        }

        private async void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        public void Alert(string msg, Notify.enmType type)
        {
            var frm = new Notify();
            frm.showAlert(msg, type);
        }

        private async void settingpanel_Paint(object sender, PaintEventArgs e)
        {
            //
        }


        private async void aimbotbody_CheckedChanged(object sender, EventArgs e)
        {
            AbsractAimbot aimbot = new AimbotHead();
            try
            {
                aimbot.isExecutingAimbot();
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(600, 900);
            }
            catch (Exception ex)
            {
                Alert("error", Notify.enmType.Applied);
            }
        }


        private async void guna2ToggleSwitch8_CheckedChanged(object sender, EventArgs e)

        {
            {
                var searchList = new List<string>
                {
                    ""
                };

                var replaceList = new List<string>
                {
                    ""
                };

                var k = false;


                Memory.SetProcess(new[] { "HD-Player" });

                var i2 = 22000000;

                for (var j = 0; j < searchList.Count; j++)
                {
                    var cu = await Memory.AoBScan(searchList[j]);
                    var u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (var i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            Memory.AobReplace(cu.ElementAt(i), replaceList[j]);
                        }

                        k = true;
                    }
                }

                if (k)
                {
                    Alert("SuccessFully Applied", Notify.enmType.Applied);
                    Console.Beep(900, 500);
                }
                else
                {
                    Alert("Failed", Notify.enmType.Error);
                }
            }
        }


        private async void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            AbsractAimbot aimbot = new AimbotNeck();
            try
            {
                aimbot.isExecutingAimbot();
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(600, 900);
            }
            catch (Exception ex)
            {
                Alert("error", Notify.enmType.Applied);
            }
        }

        private async void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            /*
            orginalValues13.Clear();
            orginalValues14.Clear();
            orginalValues15.Clear();
            orginalValues16.Clear();


            var readOffset = Convert.ToInt64(Offset8);
            var writeOffset = Convert.ToInt64(offset9);

            var proc = Process.GetProcessesByName("HD-Player")[0].Id;
            Lucifer.OpenProcess(proc);
            Alert("Applying", Notify.enmType.Applying);

            var result = await Lucifer.AoBScan(0x0000000000000000, 0x00007fffffffffff,
                "FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 A5 43",
                true, true);

            if (result.Count() != 0)
            {
                foreach (var CurrentAddress in result)
                {
                    var addressToSave = CurrentAddress + writeOffset;
                    var currentBytes = Lucifer.SunIsKind(addressToSave.ToString("X"), sizeof(int));
                    var currentValue = BitConverter.ToInt32(currentBytes, 0);
                    orginalValues13[addressToSave] = currentValue;
                    var addressToSave9 = CurrentAddress + readOffset;

                    var currentBytes9 = Lucifer.SunIsKind(addressToSave9.ToString("X"), sizeof(int));
                    var currentValue9 = BitConverter.ToInt32(currentBytes9, 0);
                    orginalValues14[addressToSave9] = currentValue9;
                    var headbytes = CurrentAddress + readOffset;
                    var chestbytes = CurrentAddress + writeOffset;

                    var bytes = Lucifer.SunIsKind(headbytes.ToString("X"), sizeof(int));
                    var Read = BitConverter.ToInt32(bytes, 0);
                    var bytes2 = Lucifer.SunIsKind(chestbytes.ToString("X"), sizeof(int));
                    var Read2 = BitConverter.ToInt32(bytes2, 0);

                    Lucifer.WriteMemory(chestbytes.ToString("X"), "int", Read.ToString());
                    Lucifer.WriteMemory(headbytes.ToString("X"), "int", Read2.ToString());

                    var addressToSave1 = CurrentAddress + writeOffset;
                    var currentBytes1 = Lucifer.SunIsKind(addressToSave1.ToString("X"), sizeof(int));
                    var curentValue1 = BitConverter.ToInt32(currentBytes1, 0);
                    orginalValues15[addressToSave1] = curentValue1;

                    var addressToSave19 = CurrentAddress + readOffset;
                    var currentBytes19 = Lucifer.SunIsKind(addressToSave19.ToString("X"), sizeof(int));
                    var currentValues19 = BitConverter.ToInt32(currentBytes19, 0);
                    orginalValues16[addressToSave19] = currentValues19;
                }

                orginalValues13.Clear();
                orginalValues14.Clear();
                orginalValues15.Clear();
                orginalValues16.Clear();
                //  sta.Text = "applied";
                Alert("SuccessFully Applied", Notify.enmType.Applied);

                Console.Beep(900, 600);
            }
                */
        }


        private async void guna2ToggleSwitch3_CheckedChanged_1(object sender, EventArgs e)
        {
            var searchList = new List<string>
            {
                "dc 52 39 bd 27 c1 8b 3c c0 d0 f8 b9",
                "63 71 b0 bd 90 98 74 bb",
                "7b f9 6c bd 58 34 09 bb b0 60 be ba",
                "54 1b 87 bd 90 c6 d7 ba 80 54 99 b9",
                "71 02 87 bd 90 fd d7 ba 40 18 98 39",
                "cc f8 6c bd 40 d2 ce b9 58 64 be 3a",
                "76 fc db bc 7c 5e 8b 3a 50 8b bb 3a",
                "80 13 95 bc 30 ff 37 bb 00 fd 78 3b",
                "1f 93 db bc 90 bf 84 3a 20 a6 bb ba",
                "ef a3 00 be 40 b9 92 39 20 4e 07 ba",
                "bc 19 fd bd b0 e3 a9 3a 80 42 23 b9",
                "7d 1a 89 bd 50 26 9f 3b",
                "0e e4 f2 bd cd 99 04 bc"
            };

            var replaceList = new List<string>
            {
                "db 42 32 3e 33 c1 18 3c c2 d0 f7 b3",
                "cd dc 79 44 90 98 74 bb",
                "cd dc 79 44 58 34 09 bb b0 60 be ba",
                "cd dc 79 44 90 c6 d7 ba 80 54 99 b9",
                "cd dc 79 44 90 fd d7 ba 40 18 98 39",
                "cd dc 79 44 40 d2 ce b9 58 64 be 3a",
                "cd dc 79 44 7c 5e 8b 3a 50 8b bb 3a",
                "cd dc 79 44 30 ff 37 bb 00 fd 78 3b",
                "cd dc 79 44 90 bf 84 3a 20 a6 bb ba",
                "cd dc 79 44 40 b9 92 39 20 4e 07 ba",
                "42 e0 56 43 b0 e3 a9 3a 80 42 23 b9",
                "00 00 70 41 00 00 70 41",
                "00 00 70 41 00 00 70 41"
            };

            var k = false;


            Memory.SetProcess(new[] { "HD-Player" });

            var i2 = 22000000;

            for (var j = 0; j < searchList.Count; j++)
            {
                var cu = await Memory.AoBScan(searchList[j]);
                var u = "0x" + cu.FirstOrDefault().ToString("X");

                if (cu.Count() != 0)
                {
                    for (var i = 0; i < cu.Count(); i++)
                    {
                        i2++;
                        Memory.AobReplace(cu.ElementAt(i), replaceList[j]);
                    }

                    k = true;
                }
            }

            if (k)
            {
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 500);
            }
            else
            {
                Alert("Failed", Notify.enmType.Error);
            }
        }

        private async void guna2ToggleSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            var searchList = new List<string>
            {
                "DC 52 39 BD 27 C1 8B 3C C0 D0 F8 B9",
                "63 71 B0 BD 90 98 74 BB",
                "7B F9 6C BD 58 34 09 BB B0 60 BE BA",
                "54 1B 87 BD 90 C6 D7 BA 80 54 99 B9",
                "71 02 87 BD 90 FD D7 BA 40 18 98 39",
                "CC F8 6C BD 40 D2 CE B9 58 64 BE 3A",
                "76 FC DB BC 7C 5E 8B 3A 50 8B BB 3A",
                "80 13 95 BC 30 FF 37 BB 00 FD 78 3B",
                "1F 93 DB BC 90 BF 84 3A 20 A6 BB BA",
                "EF A3 00 BE 40 B9 92 39 20 4E 07 BA",
                "BC 19 FD BD B0 E3 A9 3A 80 42 23 B9",
                "7D 1A 89 BD 50 26 9F 3B",
                "0E E4 F2 BD CD 99 04 BC",
                "63 71 B0 BD 90 98 74 BB",
                "A8 E7 71 3D E4 8C 02 3E 00 00 00 00 DC 52 39 BD 27 C1 8B 3C C0 D0 F8 B9",
                "71 58 54 39 54 51 3D 00 2B 42 77 3D"
            };

            var replaceList = new List<string>
            {
                "DB 42 32 3E 33 C1 18 3C C2 D0 F7 B3",
                "CD DC 79 44 90 98 74 BB",
                "CD DC 79 44 58 34 09 BB B0 60 BE BA",
                "CD DC 79 44 90 C6 D7 BA 80 54 99 B9",
                "CD DC 79 44 90 FD D7 BA 40 18 98 39",
                "CD DC 79 44 40 D2 CE B9 58 64 BE 3A",
                "CD DC 79 44 7C 5E 8B 3A 50 8B BB 3A",
                "CD DC 79 44 30 FF 37 BB 00 FD 78 3B",
                "CD DC 79 44 90 BF 84 3A 20 A6 BB BA",
                "CD DC 79 44 40 B9 92 39 20 4E 07 BA",
                "42 E0 56 43 B0 E3 A9 3A 80 42 23 B9",
                "00 00 70 41 00 00 70 41",
                "00 00 70 41 00 00 70 41",
                "00 00 70 41 00 00 70 41",
                "59 DF CA 3D E4 8C 02 3E 00 00 00 00 00 00 00 3E 0A D7 23 3D D2 A5 F9 BC",
                "CD DC 79 44 40 D2 CE B9 58 64 BE 3A"
            };

            var k = false;


            Memory.SetProcess(new[] { "HD-Player" });

            var i2 = 22000000;

            for (var j = 0; j < searchList.Count; j++)
            {
                var cu = await Memory.AoBScan(searchList[j]);
                var u = "0x" + cu.FirstOrDefault().ToString("X");

                if (cu.Count() != 0)
                {
                    for (var i = 0; i < cu.Count(); i++)
                    {
                        i2++;
                        Memory.AobReplace(cu.ElementAt(i), replaceList[j]);
                    }

                    k = true;
                }
            }

            if (k)
            {
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 500);
            }
            else
            {
                Alert("Failed", Notify.enmType.Error);
            }
        }

        private static void LuciferFallenAngel(string resourceName, string outputPath)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            using (var resourceStream = executingAssembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null) throw new ArgumentException($"Resource '{resourceName}' not found.");
                using (var fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    var buffer = new byte[resourceStream.Length];
                    resourceStream.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize,
            uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer,
            uint nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize,
            IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        private async void guna2ToggleSwitch16_CheckedChanged(object sender, EventArgs e)
        {
            AbsractAimbot aimbot = new AimbotDrag();
            try
            {
                aimbot.isExecutingAimbot();
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(600, 900);
            }
            catch (Exception ex)
            {
                Alert("error", Notify.enmType.Applied);
            }
        }

        private async void guna2ToggleSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            var searchList = new List<string>
            {
                "33 33 93 3F 8F C2 F5 3C CD CC CC 3D 02 00 00 00 EC 51 B8 3D CD CC 4C 3F 00 00 00 00 00 00 A0 42 00 00 C0 3F 33 33 13 40 00 00 F0 3F 00 00 80 3F 01 00",
                "20 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D ?? 00 00 00 29 5C 8F 3D 00 00 00 3F 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 D0 3F 00 00 80 3F 01"


                //  "",
                // "",
                ///  "",
                //  "",
                //   "",
            };

            var replaceList = new List<string>
            {
                "33 33 93 3F 8F C2 F5 3C CD CC CC 3D 02 00 00 00 EC 51 B8 3D CD CC 4C 3F 00 00 00 00 00 00 A0 42 00 00 C0 3F 33 33 13 40 00 00 F0 3F 00 00 29 5C 01 00",
                "20 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D ?? 00 00 00 29 5C 8F 3D 00 00 00 3F 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 D0 3F 00 00 80 5C 01"
            };

            var k = false;


            Memory.SetProcess(new[] { "HD-Player" });

            var i2 = 22000000;

            for (var j = 0; j < searchList.Count; j++)
            {
                var cu = await Memory.AoBScan(searchList[j]);
                var u = "0x" + cu.FirstOrDefault().ToString("X");

                if (cu.Count() != 0)
                {
                    for (var i = 0; i < cu.Count(); i++)
                    {
                        i2++;
                        Memory.AobReplace(cu.ElementAt(i), replaceList[j]);
                    }

                    k = true;
                }
            }

            if (k)
            {
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 500);
            }
            else
            {
                Alert("Failed", Notify.enmType.Error);
            }
        }


        private async void guna2ToggleSwitch6_CheckedChanged(object sender, EventArgs e)
        {
            var search4 = "C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70";
            var replace4 = "C0 3F 01 00 01 00 01 00 01 00 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70";

            var anySuccess = false;

            if (Process.GetProcessesByName("HD-Player").Length > 0)
            {
                Memory.SetProcess(new[] { "HD-Player" });

                var patches = new List<(string search, string replace)>
                {
                    //
                    //  (search1, replace1),
                    //  (search2, replace2),
                    // (search3, replace3),
                    (search4, replace4)
                    // (search5, replace5),
                    // (search6, replace6),
                };

                for (var i = 0; i < patches.Count; i++)
                {
                    var (search, replace) = patches[i];

                    if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(replace))
                    {
                        var matches = await Memory.AoBScan(search);

                        if (matches.Any())
                        {
                            foreach (var address in matches)
                            {
                                Memory.AobReplace(address, replace);


                                Console.Beep(1000, 200);
                            }

                            anySuccess = true;


                            Alert("SuccessFully Applied", Notify.enmType.Applied);
                        }
                    }
                }

                if (anySuccess)
                    Alert("SuccessFully Applied", Notify.enmType.Applied);
                else
                    Alert("Failed", Notify.enmType.Applied);
            }
            else
            {
                Alert("Hd Player not foud", Notify.enmType.Applied);
            }
        }

        private void AIMBOT5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Hide();
            var aa = new Log();
            aa.Show();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            sniperpanel.BringToFront();
        }

        private async void guna2ToggleSwitch9_CheckedChanged(object sender, EventArgs e)
        {
            var orginalValues17 = new Dictionary<long, int>();
            var orginalValues18 = new Dictionary<long, int>();
            var orginalValues19 = new Dictionary<long, int>();
            var orginalValues20 = new Dictionary<long, int>();


            var readOffset = Convert.ToInt64(Offset90);
            var writeOffset = Convert.ToInt64(offset40);

            var proc = Process.GetProcessesByName("HD-Player")[0].Id;
            Lucifer.OpenProcess(proc);

            var result = await Lucifer.AoBScan(0x0000000000000000, 0x00007fffffffffff,
                "CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F",
                true, true);

            if (result.Count() != 0)
            {
                foreach (var CurrentAddress in result)
                {
                    var addressToSave = CurrentAddress + writeOffset;
                    var currentBytes = Lucifer.SunIsKind(addressToSave.ToString("X"), sizeof(int));
                    var currentValue = BitConverter.ToInt32(currentBytes, 0);
                    orginalValues17[addressToSave] = currentValue;
                    var addressToSave9 = CurrentAddress + readOffset;

                    var currentBytes9 = Lucifer.SunIsKind(addressToSave9.ToString("X"), sizeof(int));
                    var currentValue9 = BitConverter.ToInt32(currentBytes9, 0);
                    orginalValues18[addressToSave9] = currentValue9;
                    var headbytes = CurrentAddress + readOffset;
                    var chestbytes = CurrentAddress + writeOffset;

                    var bytes = Lucifer.SunIsKind(headbytes.ToString("X"), sizeof(int));
                    var Read = BitConverter.ToInt32(bytes, 0);
                    var bytes2 = Lucifer.SunIsKind(chestbytes.ToString("X"), sizeof(int));
                    var Read2 = BitConverter.ToInt32(bytes2, 0);

                    Lucifer.WriteMemory(chestbytes.ToString("X"), "int", Read.ToString());
                    Lucifer.WriteMemory(headbytes.ToString("X"), "int", Read2.ToString());

                    var addressToSave1 = CurrentAddress + writeOffset;
                    var currentBytes1 = Lucifer.SunIsKind(addressToSave1.ToString("X"), sizeof(int));
                    var curentValue1 = BitConverter.ToInt32(currentBytes1, 0);
                    orginalValues19[addressToSave1] = curentValue1;

                    var addressToSave19 = CurrentAddress + readOffset;
                    var currentBytes19 = Lucifer.SunIsKind(addressToSave19.ToString("X"), sizeof(int));
                    var currentValues19 = BitConverter.ToInt32(currentBytes19, 0);
                    orginalValues20[addressToSave19] = currentValues19;
                }

                orginalValues17.Clear();
                orginalValues18.Clear();
                orginalValues19.Clear();
                orginalValues20.Clear();
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 600);
            }
        }


        //     private Dictionary<long, int> orginalValues50 = new Dictionary<long, int>();
        //  private Dictionary<long, int> orginalValues60 = new Dictionary<long, int>();
        //  private Dictionary<long, int> orginalValues70 = new Dictionary<long, int>();
        //  private Dictionary<long, int> orginalValues80 = new Dictionary<long, int>();

        //  long Offset30 = 0x2B;
        //  long offset60 = 0x2F;
        private async void guna2ToggleSwitch8_CheckedChanged_1(object sender, EventArgs e)
        {
            var search4 = "19 3E CD CC 4C 3E A4 70 FD 3E AE 47 01 3F";
            var replace4 = "19 3E CD CC 4C 3E A4 70 FD 3E AE 47 E1 FF";

            var anySuccess = false;

            if (Process.GetProcessesByName("HD-Player").Length > 0)
            {
                Memory.SetProcess(new[] { "HD-Player" });

                var patches = new List<(string search, string replace)>
                {
                    //
                    //  (search1, replace1),
                    //  (search2, replace2),
                    // (search3, replace3),
                    (search4, replace4)
                    // (search5, replace5),
                    // (search6, replace6),
                };

                for (var i = 0; i < patches.Count; i++)
                {
                    var (search, replace) = patches[i];

                    if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(replace))
                    {
                        var matches = await Memory.AoBScan(search);

                        if (matches.Any())
                        {
                            foreach (var address in matches)
                            {
                                Memory.AobReplace(address, replace);


                                Console.Beep(1000, 200);
                            }

                            anySuccess = true;


                            Alert("SuccessFully Applied", Notify.enmType.Applied);
                        }
                    }
                }

                if (anySuccess)
                    Alert("SuccessFully Applied", Notify.enmType.Applied);
                else
                    Alert("Failed", Notify.enmType.Applied);
            }
            else
            {
                Alert("Hd Player not foud", Notify.enmType.Applied);
            }
        }

        private async void guna2ToggleSwitch11_CheckedChanged(object sender, EventArgs e)
        {
            var searchList = new List<string>
            {
                "01 10 9F E7 00 10 91 E5 0C 10 0B E5 A8 00 8D E5",
                "30 48 2D E9 08 B0 8D E2 2F DE 4D E2 0C 1E 9F E5",
                "F0 B5 03 AF 2D E9 00 0F 91 B0 4D F2 B8 36 44 F6"


                //  "",
                // "",
                ///  "",
                //  "",
                //   "",
            };

            var replaceList = new List<string>
            {
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1"
                // "F0 BD FF E7 04 46 09 A8 DE F7 FF FD 00 E0 04 46",
                //"FD F7 51 BF 00 00 F0 B5 03 AF 2D E9 00 0B 84 B0"
            };

            var k = false;


            Memory.SetProcess(new[] { "HD-Player" });

            var i2 = 22000000;

            for (var j = 0; j < searchList.Count; j++)
            {
                var cu = await Memory.AoBScan(searchList[j]);
                var u = "0x" + cu.FirstOrDefault().ToString("X");

                if (cu.Count() != 0)
                {
                    for (var i = 0; i < cu.Count(); i++)
                    {
                        i2++;
                        Memory.AobReplace(cu.ElementAt(i), replaceList[j]);
                    }

                    k = true;
                }
            }

            if (k)
            {
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 500);
            }
            else
            {
                Alert("Failed", Notify.enmType.Error);
            }
        }

        private async void guna2ToggleSwitch10_CheckedChanged(object sender, EventArgs e)
        {
            var searchList = new List<string>
            {
                "00 48 2D E9 0D B0 A0 E1 58 D0 4D E2 D0 21 9F E5", //
                "10 4C 2D E9 08 B0 8D E2 90 D0 4D E2 D0 14 9F E5", //
                "30 48 2D E9 08 B0 8D E2 F6 DF 4D E2 08 C0 9B E5", //
                "10 4C 2D E9 08 B0 8D E2 C8 D0 4D E2 01 DB 4D E2", //
                "00 48 2D E9 0D B0 A0 E1 30 D0 4D E2 E0 C0 9F E5", //
                "00 48 2D E9 0D B0 A0 E1 38 D0 4D E2 10 3A 00 EE", //
                "10 4C 2D E9 08 B0 8D E2 70 D0 4D E2 01 DA 4D E2", //
                "00 48 2D E9 0D B0 A0 E1 58 D0 4D E2 C8 33 9F E5", //
                "30 48 2D E9 08 B0 8D E2 6E DF 4D E2 5C 21 9F E5", //
                "00 48 2D E9 0D B0 A0 E1 10 D0 4D E2 6C 20 9F E5", //
                "B0 B5 02 AF 88 B0 0C 4C 7C 44 24 68 25 68 07 95" //
            };

            var replaceList = new List<string>
            {
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1"
            };

            var k = false;


            Memory.SetProcess(new[] { "HD-Player" });

            var i2 = 22000000;

            for (var j = 0; j < searchList.Count; j++)
            {
                var cu = await Memory.AoBScan(searchList[j]);
                var u = "0x" + cu.FirstOrDefault().ToString("X");

                if (cu.Count() != 0)
                {
                    for (var i = 0; i < cu.Count(); i++)
                    {
                        i2++;
                        Memory.AobReplace(cu.ElementAt(i), replaceList[j]);
                    }

                    k = true;
                }
            }

            if (k)
            {
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 500);
            }
            else
            {
                Alert("Failed", Notify.enmType.Error);
            }
        }

        private async void guna2ToggleSwitch7_CheckedChanged(object sender, EventArgs e)
        {
            var search4 = "19 3E CD CC 4C 3E A4 70 FD 3E AE 47 E1 FF";
            var replace4 = "19 3E CD CC 4C 3E A4 70 FD 3E AE 47 01 3F";

            var anySuccess = false;

            if (Process.GetProcessesByName("HD-Player").Length > 0)
            {
                Memory.SetProcess(new[] { "HD-Player" });

                var patches = new List<(string search, string replace)>
                {
                    //
                    //  (search1, replace1),
                    //  (search2, replace2),
                    // (search3, replace3),
                    (search4, replace4)
                    // (search5, replace5),
                    // (search6, replace6),
                };

                for (var i = 0; i < patches.Count; i++)
                {
                    var (search, replace) = patches[i];

                    if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(replace))
                    {
                        var matches = await Memory.AoBScan(search);

                        if (matches.Any())
                        {
                            foreach (var address in matches)
                            {
                                Memory.AobReplace(address, replace);


                                Console.Beep(1000, 200);
                            }

                            anySuccess = true;


                            Alert("SuccessFully Applied", Notify.enmType.Applied);
                        }
                    }
                }

                if (anySuccess)
                    Alert("SuccessFully Applied", Notify.enmType.Applied);
                else
                    Alert("Failed", Notify.enmType.Applied);
            }
            else
            {
                Alert("Hd Player not foud", Notify.enmType.Applied);
            }
        }

        private async void guna2ToggleSwitch12_CheckedChanged(object sender, EventArgs e)
        {
            var searchList = new List<string>
            {
                "30 48 2D E9 08 B0 8D E2 17 DE 4D E2 08 C0 9B E5",
                "30 48 2D E9 08 B0 8D E2 42 DF 4D E2 6C 16 9F E5",
                "00 48 2D E9 0D B0 A0 E1 58 D0 4D E2 00 12 9F E5",
                "00 48 2D E9 0D B0 A0 E1 48 D0 4D E2 94 31 9F E5",
                "00 48 2D E9 0D B0 A0 E1 98 D0 4D E2 2C C2 9F E5",
                "00 48 2D E9 0D B0 A0 E1 C8 D0 4D E2 C8 C6 9F E5",
                "30 48 2D E9 08 B0 8D E2 20 D0 4D E2 10 C0 9B E5"


                //  "",
                // "",
                ///  "",
                //  "",
                //   "",
            };

            var replaceList = new List<string>
            {
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1",
                "00 00 A0 E3 1E FF 2F E1"
            };

            var k = false;


            Memory.SetProcess(new[] { "HD-Player" });

            var i2 = 22000000;

            for (var j = 0; j < searchList.Count; j++)
            {
                var cu = await Memory.AoBScan(searchList[j]);
                var u = "0x" + cu.FirstOrDefault().ToString("X");

                if (cu.Count() != 0)
                {
                    for (var i = 0; i < cu.Count(); i++)
                    {
                        i2++;
                        Memory.AobReplace(cu.ElementAt(i), replaceList[j]);
                    }

                    k = true;
                }
            }

            if (k)
            {
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 500);
            }
            else
            {
                Alert("Failed", Notify.enmType.Error);
            }
        }

        private async void guna2ToggleSwitch13_CheckedChanged(object sender, EventArgs e)
        {
            var search4 =
                "01 00 A0 E3 1C 00 85 E5 00 70 94 E5 C0 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 6F A0 D5 EB FC 50 87 E5 00 70 94 E5 C4 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 68 A0 D5 EB 00 51 87 E5 00 70 94 E5 C8 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 61 A0 D5 EB 98 03 9F E5 30 51 87 E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 06 00 00 0A 70 10 90 E5 00 00 51 E3 03 00 00 1A 8A 45 D5 EB 70 03 9F E5 00 00 9F E7 00 00 90 E5 5C 00 90 E5 35 10 01 E3 01 00 D0 E7 00 00 50 E3 49 00 00 0A 54 03 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 78 45 D5 EB 00 00 A0 E3 5C D3 03 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 3D A0 D5 EB 05 00 A0 E1 00 10 A0 E3 AE D3 03 EB 00 50 94 E5 00 70 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 34 A0 D5 EB 58 50 95 E5 00 00 55 E3 01 00 00 1A 00 00 A0 E3 2F A0 D5 EB 00 00 95 E5 BA 10 D0 E5 00 00 51 E3 BF 10 D0 15 40 00 11 13 01 00 00 0A F1 B8 D4 EB 00 00 95 E5 D8 20 90 E5 DC 10 90 E5 05 00 A0 E1 32 FF 2F E1 00 50 A0 E1 A8 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 4C 45 D5 EB 07 00 A0 E1 05 10 A0 E1 00 20 A0 E3 99 B6 03 EB 00 50 A0 E1 70 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 3D 45 D5 EB 05 00 A0 E1 00 10 A0 E3 E0 D3 03 EB 00 70 94 E5 13 00 00 EA 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 FF 9F D5 EB 38 00 87 E2 00 10 A0 E3 B6 BA 03 EB 00 50 A0 E1 14 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 25 45 D5 EB 05 00 A0 E1 00 10 A0 E3 CB D3 03 EB 00 00 57 E3 5D 00 00 0A DC 11 9F E5 54 01 87 E5 00 70 94 E5 01 10 9F E7 00 00 91 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 14 45 D5 EB 00 00 A0 E3 22 D3 03 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 D9 9F D5 EB 05 00 A0 E1 00 10 A0 E3 2C D3 03 EB 00 50 A0 E1 00 00 57 E3 01 00 00 1A 00 00 A0 E3 D1 9F D5 EB 24 51 87 E5 00 70 94 E5 20 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 CA 9F D5 EB 28 51 87 E5 00 70 94 E5 24 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 C3 9F D5 EB 08 00 A0 E1 2C 51 87 E5 91 60 00 EB 00 50 A0 E1 00 00 55 E3 0E 00 00 1A 24 01 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A E7 44 D5 EB 00 00 A0 E3 91 D3 03 EB 00 50 A0 E1 00 00 55 E3 05 00 00 0A 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A9 9F D5 EB 38 51 87 E5 00 70 94 E5 CC 50 96 E5 00 00 57 E3";
            var replace4 =
                "00 00 A0 E1 1C 00 85 E5 00 70 94 E5 C0 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 6F A0 D5 EB FC 50 87 E5 00 70 94 E5 C4 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 68 A0 D5 EB 00 51 87 E5 00 70 94 E5 C8 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 61 A0 D5 EB 98 03 9F E5 30 51 87 E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 06 00 00 0A 70 10 90 E5 00 00 51 E3 03 00 00 1A 8A 45 D5 EB 70 03 9F E5 00 00 9F E7 00 00 90 E5 5C 00 90 E5 35 10 01 E3 01 00 D0 E7 00 00 50 E3 49 00 00 0A 54 03 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 78 45 D5 EB 00 00 A0 E3 5C D3 03 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 3D A0 D5 EB 05 00 A0 E1 00 10 A0 E3 AE D3 03 EB 00 50 94 E5 00 70 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 34 A0 D5 EB 58 50 95 E5 00 00 55 E3 01 00 00 1A 00 00 A0 E3 2F A0 D5 EB 00 00 95 E5 BA 10 D0 E5 00 00 51 E3 BF 10 D0 15 40 00 11 13 01 00 00 0A F1 B8 D4 EB 00 00 95 E5 D8 20 90 E5 DC 10 90 E5 05 00 A0 E1 32 FF 2F E1 00 50 A0 E1 A8 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 4C 45 D5 EB 07 00 A0 E1 05 10 A0 E1 00 20 A0 E3 99 B6 03 EB 00 50 A0 E1 70 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 3D 45 D5 EB 05 00 A0 E1 00 10 A0 E3 E0 D3 03 EB 00 70 94 E5 13 00 00 EA 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 FF 9F D5 EB 38 00 87 E2 00 10 A0 E3 B6 BA 03 EB 00 50 A0 E1 14 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 25 45 D5 EB 05 00 A0 E1 00 10 A0 E3 CB D3 03 EB 00 00 57 E3 5D 00 00 0A DC 11 9F E5 25 01 87 E5 00 70 94 E5 01 10 9F E7 00 00 91 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 14 45 D5 EB 00 00 A0 E3 22 D3 03 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 D9 9F D5 EB 05 00 A0 E1 00 10 A0 E3 2C D3 03 EB 00 50 A0 E1 00 00 57 E3 01 00 00 1A 00 00 A0 E3 D1 9F D5 EB 24 51 87 E5 00 70 94 E5 20 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 CA 9F D5 EB 28 51 87 E5 00 70 94 E5 24 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 C3 9F D5 EB 08 00 A0 E1 2C 51 87 E5 91 60 00 EB 00 50 A0 E1 00 00 55 E3 0E 00 00 1A 24 01 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A E7 44 D5 EB 00 00 A0 E3 91 D3 03 EB 00 50 A0 E1 00 00 55 E3 05 00 00 0A 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A9 9F D5 EB 38 51 87 05 00 70 94 E5 CC 50 96 E5 00 00 57 E3";

            var anySuccess = false;

            if (Process.GetProcessesByName("HD-Player").Length > 0)
            {
                Memory.SetProcess(new[] { "HD-Player" });

                var patches = new List<(string search, string replace)>
                {
                    //
                    //  (search1, replace1),
                    //  (search2, replace2),
                    // (search3, replace3),
                    (search4, replace4)
                    // (search5, replace5),
                    // (search6, replace6),
                };

                for (var i = 0; i < patches.Count; i++)
                {
                    var (search, replace) = patches[i];

                    if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(replace))
                    {
                        var matches = await Memory.AoBScan(search);

                        if (matches.Any())
                        {
                            foreach (var address in matches)
                            {
                                Memory.AobReplace(address, replace);


                                Console.Beep(1000, 200);
                            }

                            anySuccess = true;


                            Alert("SuccessFully Applied", Notify.enmType.Applied);
                        }
                    }
                }

                if (anySuccess)
                    Alert("SuccessFully Applied", Notify.enmType.Applied);
                else
                    Alert("Failed", Notify.enmType.Applied);
            }
            else
            {
                Alert("Hd Player not foud", Notify.enmType.Applied);
            }
        }

        private async void guna2ToggleSwitch14_CheckedChanged(object sender, EventArgs e)
        {
            var search4 =
                "00 00 A0 E1 1C 00 85 E5 00 70 94 E5 C0 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 6F A0 D5 EB FC 50 87 E5 00 70 94 E5 C4 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 68 A0 D5 EB 00 51 87 E5 00 70 94 E5 C8 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 61 A0 D5 EB 98 03 9F E5 30 51 87 E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 06 00 00 0A 70 10 90 E5 00 00 51 E3 03 00 00 1A 8A 45 D5 EB 70 03 9F E5 00 00 9F E7 00 00 90 E5 5C 00 90 E5 35 10 01 E3 01 00 D0 E7 00 00 50 E3 49 00 00 0A 54 03 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 78 45 D5 EB 00 00 A0 E3 5C D3 03 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 3D A0 D5 EB 05 00 A0 E1 00 10 A0 E3 AE D3 03 EB 00 50 94 E5 00 70 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 34 A0 D5 EB 58 50 95 E5 00 00 55 E3 01 00 00 1A 00 00 A0 E3 2F A0 D5 EB 00 00 95 E5 BA 10 D0 E5 00 00 51 E3 BF 10 D0 15 40 00 11 13 01 00 00 0A F1 B8 D4 EB 00 00 95 E5 D8 20 90 E5 DC 10 90 E5 05 00 A0 E1 32 FF 2F E1 00 50 A0 E1 A8 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 4C 45 D5 EB 07 00 A0 E1 05 10 A0 E1 00 20 A0 E3 99 B6 03 EB 00 50 A0 E1 70 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 3D 45 D5 EB 05 00 A0 E1 00 10 A0 E3 E0 D3 03 EB 00 70 94 E5 13 00 00 EA 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 FF 9F D5 EB 38 00 87 E2 00 10 A0 E3 B6 BA 03 EB 00 50 A0 E1 14 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 25 45 D5 EB 05 00 A0 E1 00 10 A0 E3 CB D3 03 EB 00 00 57 E3 5D 00 00 0A DC 11 9F E5 25 01 87 E5 00 70 94 E5 01 10 9F E7 00 00 91 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 14 45 D5 EB 00 00 A0 E3 22 D3 03 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 D9 9F D5 EB 05 00 A0 E1 00 10 A0 E3 2C D3 03 EB 00 50 A0 E1 00 00 57 E3 01 00 00 1A 00 00 A0 E3 D1 9F D5 EB 24 51 87 E5 00 70 94 E5 20 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 CA 9F D5 EB 28 51 87 E5 00 70 94 E5 24 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 C3 9F D5 EB 08 00 A0 E1 2C 51 87 E5 91 60 00 EB 00 50 A0 E1 00 00 55 E3 0E 00 00 1A 24 01 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A E7 44 D5 EB 00 00 A0 E3 91 D3 03 EB 00 50 A0 E1 00 00 55 E3 05 00 00 0A 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A9 9F D5 EB 38 51 87 05 00 70 94 E5 CC 50 96 E5 00 00 57 E3";
            var replace4 =
                "01 00 A0 E3 1C 00 85 E5 00 70 94 E5 C0 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 6F A0 D5 EB FC 50 87 E5 00 70 94 E5 C4 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 68 A0 D5 EB 00 51 87 E5 00 70 94 E5 C8 50 96 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 61 A0 D5 EB 98 03 9F E5 30 51 87 E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 06 00 00 0A 70 10 90 E5 00 00 51 E3 03 00 00 1A 8A 45 D5 EB 70 03 9F E5 00 00 9F E7 00 00 90 E5 5C 00 90 E5 35 10 01 E3 01 00 D0 E7 00 00 50 E3 49 00 00 0A 54 03 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 78 45 D5 EB 00 00 A0 E3 5C D3 03 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 3D A0 D5 EB 05 00 A0 E1 00 10 A0 E3 AE D3 03 EB 00 50 94 E5 00 70 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 34 A0 D5 EB 58 50 95 E5 00 00 55 E3 01 00 00 1A 00 00 A0 E3 2F A0 D5 EB 00 00 95 E5 BA 10 D0 E5 00 00 51 E3 BF 10 D0 15 40 00 11 13 01 00 00 0A F1 B8 D4 EB 00 00 95 E5 D8 20 90 E5 DC 10 90 E5 05 00 A0 E1 32 FF 2F E1 00 50 A0 E1 A8 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 4C 45 D5 EB 07 00 A0 E1 05 10 A0 E1 00 20 A0 E3 99 B6 03 EB 00 50 A0 E1 70 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 3D 45 D5 EB 05 00 A0 E1 00 10 A0 E3 E0 D3 03 EB 00 70 94 E5 13 00 00 EA 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 FF 9F D5 EB 38 00 87 E2 00 10 A0 E3 B6 BA 03 EB 00 50 A0 E1 14 02 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 25 45 D5 EB 05 00 A0 E1 00 10 A0 E3 CB D3 03 EB 00 00 57 E3 5D 00 00 0A DC 11 9F E5 54 01 87 E5 00 70 94 E5 01 10 9F E7 00 00 91 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A 14 45 D5 EB 00 00 A0 E3 22 D3 03 EB 00 50 A0 E1 00 00 55 E3 01 00 00 1A 00 00 A0 E3 D9 9F D5 EB 05 00 A0 E1 00 10 A0 E3 2C D3 03 EB 00 50 A0 E1 00 00 57 E3 01 00 00 1A 00 00 A0 E3 D1 9F D5 EB 24 51 87 E5 00 70 94 E5 20 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 CA 9F D5 EB 28 51 87 E5 00 70 94 E5 24 50 98 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 C3 9F D5 EB 08 00 A0 E1 2C 51 87 E5 91 60 00 EB 00 50 A0 E1 00 00 55 E3 0E 00 00 1A 24 01 9F E5 00 00 9F E7 00 00 90 E5 BF 10 D0 E5 02 00 11 E3 03 00 00 0A 70 10 90 E5 00 00 51 E3 00 00 00 1A E7 44 D5 EB 00 00 A0 E3 91 D3 03 EB 00 50 A0 E1 00 00 55 E3 05 00 00 0A 00 70 94 E5 00 00 57 E3 01 00 00 1A 00 00 A0 E3 A9 9F D5 EB 38 51 87 E5 00 70 94 E5 CC 50 96 E5 00 00 57 E3";

            var anySuccess = false;

            if (Process.GetProcessesByName("HD-Player").Length > 0)
            {
                Memory.SetProcess(new[] { "HD-Player" });

                var patches = new List<(string search, string replace)>
                {
                    //
                    //  (search1, replace1),
                    //  (search2, replace2),
                    // (search3, replace3),
                    (search4, replace4)
                    // (search5, replace5),
                    // (search6, replace6),
                };

                for (var i = 0; i < patches.Count; i++)
                {
                    var (search, replace) = patches[i];

                    if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(replace))
                    {
                        var matches = await Memory.AoBScan(search);

                        if (matches.Any())
                        {
                            foreach (var address in matches)
                            {
                                Memory.AobReplace(address, replace);


                                Console.Beep(1000, 200);
                            }

                            anySuccess = true;


                            Alert("SuccessFully Applied", Notify.enmType.Applied);
                        }
                    }
                }

                if (anySuccess)
                    Alert("SuccessFully Applied", Notify.enmType.Applied);
                else
                    Alert("Failed", Notify.enmType.Applied);
            }
            else
            {
                Alert("Hd Player not foud", Notify.enmType.Applied);
            }
        }

        private async void guna2ToggleSwitch15_CheckedChanged(object sender, EventArgs e)
        {
            var searchList = new List<string>
            {
                "71 23 05 06 72 23 05 06 B3 65 14 06 46 23 05 06 4F 23 05 06 85 65 14 06 9B 65 14 06 4B 23 05 06 57 23 05 06 8C 65 14 06 94 65 14 06 8F 65 14 06 AB 65 14 06 90 65 14 06 AA 65 14 06",
                "41 23 05 06 45 23 05 06 47 23 05 06 48 23 05 06 49 23 05 06 4A 23 05 06 4C 23 05 06 4D 23 05 06 4E 23 05 06 50 23 05 06 51 23 05 06 52 23 05 06 53 23 05 06 54 23 05 06 55 23 05 06 56 23 05 06 58 23 05 06 59 23 05 06 5A 23 05 06 5B 23 05 06 5C 23 05 06 84 65 14 06 86 65 14 06 87 65 14 06 88 65 14 06 89 65 14 06 8A 65 14 06 8B 65 14 06 8D 65 14 06 8E 65 14 06 91 65 14 06 92 65 14 06 93 65 14 06 95 65 14 06 96 65 14 06 97 65 14 06 98 65 14 06 99 65 14 06 9A 65 14 06 9C 65 14 06 9D 65 14 06 9E 65 14 06 9F 65 14 06 A0 65 14 06 A1 65 14 06 A2 65 14 06 A3 65 14 06 A4 65 14 06 A5 65 14 06 A6 65 14 06 A7 65 14 06 A8 65 14 06 C2"


                //  "",
                // "",
                ///  "",
                //  "",
                //   "",
            };

            var replaceList = new List<string>
            {
                "85 65 14 06 85 65 14 06 B3 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 9B 65 14 06 85 65 14 06 85 65 14 06 8C 65 14 06 94 65 14 06 8F 65 14 06 AB 65 14 06 90 65 14 06 AA 65 14 06",
                "85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 84 65 14 06 86 65 14 06 87 65 14 06 88 65 14 06 89 65 14 06 8A 65 14 06 8B 65 14 06 8D 65 14 06 8E 65 14 06 91 65 14 06 92 65 14 06 93 65 14 06 95 65 14 06 96 65 14 06 97 65 14 06 98 65 14 06 99 65 14 06 9A 65 14 06 9C 65 14 06 9D 65 14 06 9E 65 14 06 9F 65 14 06 A0 65 14 06 A1 65 14 06 A2 65 14 06 A3 65 14 06 A4 65 14 06 A5 65 14 06 A6 65 14 06 A7 65 14 06 A8 65 14 06 C2"
            };

            var k = false;


            Memory.SetProcess(new[] { "HD-Player" });

            var i2 = 22000000;

            for (var j = 0; j < searchList.Count; j++)
            {
                var cu = await Memory.AoBScan(searchList[j]);
                var u = "0x" + cu.FirstOrDefault().ToString("X");

                if (cu.Count() != 0)
                {
                    for (var i = 0; i < cu.Count(); i++)
                    {
                        i2++;
                        Memory.AobReplace(cu.ElementAt(i), replaceList[j]);
                    }

                    k = true;
                }
            }

            if (k)
            {
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 500);
            }
            else
            {
                Alert("Failed", Notify.enmType.Error);
            }
        }

        private async void guna2ToggleSwitch17_CheckedChanged(object sender, EventArgs e)
        {
            var searchList = new List<string>
            {
                "6D 00 00 00 F2 A9 06 06 D3 72 17 06 41 23 05 06 45 23 05 06 47 23 05 06 48 23 05 06 49 23 05 06 4A 23 05 06 4C 23 05 06 4D 23 05 06 4E 23 05 06 50 23 05 06 51 23 05 06 52 23 05 06 53 23 05 06 54 23 05 06 55 23 05 06 56 23 05 06 58 23 05 06 59 23 05 06 5A 23 05 06 5B 23 05 06 5C 23 05 06 84 65 14 06 86 65 14 06 87 65 14 06 88 65 14 06 89 65 14 06 8A 65 14 06 8B 65 14 06 8D 65 14 06 8E 65 14 06 91 65 14 06 92 65 14 06 93 65 14 06 95 65 14 06 96 65 14 06 97 65 14 06 98 65 14 06 99 65 14 06 9A 65 14 06 9C 65 14 06 9D 65 14 06 9E 65 14 06 9F 65 14 06 A0 65 14 06 A1 65 14 06 A2 65 14 06 A3 65 14 06 A4 65 14 06 A5 65 14 06 A6 65 14 06 A7 65 14 06 A8 65 14 06 C2 A7 23 06 C3 A7 23 06 C4 A7 23 06 A9 65 14 06 AC 65 14 06 AD 65 14 06 AE 65 14 06 78 B3 12 06 7F 65 14 06 71 23 05 06 72 23 05 06 B3 65 14 06 46 23 05 06 4F 23 05 06 85 65 14 06 9B 65 14 06 4B 23 05 06 57 23 05 06 8C 65 14 06 94 65 14 06 8F 65 14 06 AB 65 14 06 90 65 14 06",

                "45 23 05 06 46 23 05 06 47 23 05 06 48 23 05 06 87 65 14 06 88 65 14 06 49 23 05 06 89 65 14 06 4A 23 05 06 8A 65 14 06 8B 65 14 06 4B 23 05 06 8C 65 14 06 4C 23 05 06 8D 65 14 06 4D 23 05 06 8E 65 14 06 4E 23 05 06 8F 65 14 06 50 23 05 06 90 65 14 06 4F 23 05 06 51 23 05 06 91 65 14 06 52 23 05 06 92 65 14 06 53 23 05 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 54 23 05 06 97 65 14 06 98 65 14 06 55 23 05 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 56 23 05 06 9D 65 14 06 57 23 05 06"


                //  "",
                // "",
                ///  "",
                //  "",
                //   "",
            };

            var replaceList = new List<string>
            {
                "6D 00 00 00 F2 A9 06 06 D3 72 17 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 84 65 14 06 86 65 14 06 87 65 14 06 88 65 14 06 89 65 14 06 8A 65 14 06 8B 65 14 06 8D 65 14 06 8E 65 14 06 91 65 14 06 92 65 14 06 93 65 14 06 95 65 14 06 96 65 14 06 97 65 14 06 98 65 14 06 99 65 14 06 9A 65 14 06 9C 65 14 06 9D 65 14 06 9E 65 14 06 9F 65 14 06 A0 65 14 06 A1 65 14 06 A2 65 14 06 A3 65 14 06 A4 65 14 06 A5 65 14 06 A6 65 14 06 A7 65 14 06 A8 65 14 06 C2 A7 23 06 C3 A7 23 06 C4 A7 23 06 A9 65 14 06 AC 65 14 06 AD 65 14 06 AE 65 14 06 78 B3 12 06 85 65 14 06 85 65 14 06 72 23 05 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 57 65 14 06 8C 65 14 06 8F 65 14 06 8F 65 14 06 AB 65 14 06 AA 65 14 06",
                "85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 8E 65 14 06 85 65 14 06 8F 65 14 06 85 65 14 06 90 65 14 06 85 65 14 06 85 65 14 06 91 65 14 06 85 65 14 06 92 65 14 06 85 65 14 06 93 65 14 06 94 65 14 06 95 65 14 06 96 65 14 06 85 65 14 06 97 65 14 06 98 65 14 06 85 65 14 06 99 65 14 06 9A 65 14 06 9B 65 14 06 9C 65 14 06 85 65 14 06 9D 65 14 06 85 65 14 06"
            };

            var k = false;


            Memory.SetProcess(new[] { "HD-Player" });

            var i2 = 22000000;

            for (var j = 0; j < searchList.Count; j++)
            {
                var cu = await Memory.AoBScan(searchList[j]);
                var u = "0x" + cu.FirstOrDefault().ToString("X");

                if (cu.Count() != 0)
                {
                    for (var i = 0; i < cu.Count(); i++)
                    {
                        i2++;
                        Memory.AobReplace(cu.ElementAt(i), replaceList[j]);
                    }

                    k = true;
                }
            }

            if (k)
            {
                Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 500);
            }
            else
            {
                Alert("Failed", Notify.enmType.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hide();
            var PP = new Form3();
            PP.Show();
        }

        private void sniperpanel_Paint(object sender, PaintEventArgs e)
        {
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnregisterHotKey(Handle, HOTKEY_ID_HEAD);
            UnregisterHotKey(Handle, HOTKEY_ID_NECK);
            UnregisterHotKey(Handle, HOTKEY_ID_SHOULDER);
            base.OnFormClosing(e);
        }


        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            if (m.Msg == WM_HOTKEY)
            {
                var id = m.WParam.ToInt32();

                if (id == HOTKEY_ID_HEAD)
                {
                    aimbotbody.Checked = !aimbotbody.Checked;
                    Alert("Head Aimbot Toggled (Global)", Notify.enmType.Info);
                    // Console.Beep(900, 500);
                }
                else if (id == HOTKEY_ID_NECK)
                {
                    guna2ToggleSwitch3.Checked = !guna2ToggleSwitch3.Checked;
                    Alert("Aimbot Body Toggled (Global)", Notify.enmType.Info);
                    // Console.Beep(1000, 500);
                }
            }

            base.WndProc(ref m);
        }

        private void guna2ToggleSwitch9_CheckedChanged_1(object sender, EventArgs e)
        {
            var processName = "HD-Player";
            var dllResourceName = "Celestial_Mods_V3.Properties.Sun.dll";
            var tempDllPath = Path.Combine(Path.GetTempPath(), "Sun.dll");
            LuciferFallenAngel(dllResourceName, tempDllPath);
            var targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0) Console.WriteLine($"Waiting for {processName}.exe...");
            if (targetProcesses.Length == 0)
            {
                MessageBox.Show("Fuck", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var targetProcess = targetProcesses[0];
                var hProcess =
                    OpenProcess(
                        PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE |
                        PROCESS_VM_READ, false, targetProcess.Id);
                var loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                var allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)tempDllPath.Length, MEM_COMMIT,
                    PAGE_READWRITE);
                IntPtr bytesWritten;
                WriteProcessMemory(hProcess, allocMemAddress, Encoding.ASCII.GetBytes(tempDllPath),
                    (uint)tempDllPath.Length, out bytesWritten);
                CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0,
                    IntPtr.Zero);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void guna2Panel21_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}