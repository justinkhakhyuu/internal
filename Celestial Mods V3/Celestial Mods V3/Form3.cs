using Celestial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Celestial_Mods_V3
{


    public partial class Form3 : Form
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

        private const int HOTKEY_ID_HEAD = 1;
        private const int HOTKEY_ID_NECK = 2;
        private const int HOTKEY_ID_SHOULDER = 3;
        private const uint MOD_NONE = 0x0000; // No Ctrl, Alt, Shift



        public Form3()
        {
            InitializeComponent();


           // RegisterHotKey(this.Handle, HOTKEY_ID_HEAD, MOD_NONE, Keys.F3);
           // RegisterHotKey(this.Handle, HOTKEY_ID_NECK, MOD_NONE, Keys.F6);
           //// RegisterHotKey(this.Handle, HOTKEY_ID_SHOULDER, MOD_NONE, Keys.F10);
           // RegisterHotKey(this.Handle, 4, MOD_NONE, Keys.F7); // Wall Hack Toggle
           // RegisterHotKey(this.Handle, 5, MOD_NONE, Keys.F8); // Camera Hack Toggle
          //  RegisterHotKey(this.Handle, 6, MOD_NONE, Keys.F9); // Speed Hack Toggle


        }

        private async void guna2ToggleSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{         "?? ?? ?? 00 00 EB 00 0A B7 EE 10 0A 01 EE 00 0A 31 EE 10 5A 01 EE 00 0A 21 EE 10 0A 10 EE 30 88 BD E8"






};

            List<string> replaceList = new List<string>
{


               "FF 02 44 E3 00 0A B7 EE 10 0A"



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
                //this.Alert("SuccessFully Applied", Notify.enmType.Applied);
                Console.Beep(900, 500);
            }
            else
            {
               // this.Alert("Failed", Notify.enmType.Error);
            }
        }

        private  async void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{         "10 8D E5 00 A0 A0 E3 14 00 8D E5 09 00 A0 E1 18 10 8D E5 1C 10 8D E5 10 17 02 E3 35 FF"

 


                //  "",
                 // "",
                ///  "",
                //  "",
               //   "",


};

            List<string> replaceList = new List<string>
{


               "10 8D E5 00 A0 A0 E3 14 00 8D E5 09 00 A0 E1 18 10 8D E5 1C 10 8D E5 10 17 02 E3 00"



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


        public void Alert(string msg, Notify.enmType type)
        {
            Notify frm = new Notify();
            frm.showAlert(msg, type);
        }
        private  async void guna2ToggleSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{         "3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A"

 


                //  "",
                 // "",
                ///  "",
                //  "",
               //   "",


};

            List<string> replaceList = new List<string>
{


               "BF AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A"



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

        private async void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{         "BF AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A"

 


                //  "",
                 // "",
                ///  "",
                //  "",
               //   "",


};

            List<string> replaceList = new List<string>
{


               "3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A"



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

        private async void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{         "01 00 00 00 02 2B 07 3D"

 


                //  "",
                 // "",
                ///  "",
                //  "",
               //   "",


};

            List<string> replaceList = new List<string>
{


               "01 00 00 00 77 00 61"



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

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hack aa = new Hack();
            aa.Show();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void guna2ToggleSwitch6_CheckedChanged(object sender, EventArgs e)
        {

            List<string> searchList = new List<string>
{         "10 4C 2D E9 08 B0 8D E2 0C 01 9F E5 00 00 8F E0 00 00 D0 E5 00 00 50 E3 06 00 00 1A FC 00 9F E5 00 00 9F E7 00 00 90 E5"

 


                //  "",
                 // "",
                ///  "",
                //  "",
               //   "",


};

            List<string> replaceList = new List<string>
{


               "01 00 A0 E3 1E FF 2F E1"



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

        private void guna2Panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
    

