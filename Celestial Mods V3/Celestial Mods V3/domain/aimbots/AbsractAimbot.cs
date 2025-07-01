using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LuciferMem;

namespace Celestial_Mods_V3.domain.aimbots
{
    public abstract class AbsractAimbot

    {
        private string aimbotCode;
        private Mem lucifer;
        private long offset1;
        private long offset2;
        private Dictionary<long, int> prevValue1;
        private Dictionary<long, int> prevValue2;
        private Dictionary<long, int> prevValue3;
        private Dictionary<long, int> prevValue4;

        protected virtual void InitializeBase(string code, long off1, long off2, Dictionary<long, int> prevValue4,
            Dictionary<long, int> prevValue3, Dictionary<long, int> prevValue2, Dictionary<long, int> prevValue1)
        {
            aimbotCode = code;
            lucifer = new Mem();
            offset1 = off1;
            offset2 = off2;
            this.prevValue1 = prevValue1;
            this.prevValue2 = prevValue2;
            this.prevValue3 = prevValue3;
            this.prevValue4 = prevValue4;
        }


        public async void isExecutingAimbot()
        {
            var proc = Process.GetProcessesByName("HD-Player")[0].Id;
            lucifer.OpenProcess(proc);


            var readOffset = Convert.ToInt64(offset1);
            var writeOffset = Convert.ToInt64(offset2);

            lucifer.OpenProcess(proc);
            try
            {
                var result = await lucifer.AoBScan(0x0000000000000000, 0x00007fffffffffff, aimbotCode, true, true);

                if (result.Count() != 0)
                    foreach (var CurrentAddress in result)
                    {
                        var addressToSave = CurrentAddress + writeOffset;
                        var currentBytes = lucifer.SunIsKind(addressToSave.ToString("X"), sizeof(int));
                        var currentValue = BitConverter.ToInt32(currentBytes, 0);
                        prevValue1[addressToSave] = currentValue;
                        var addressToSave9 = CurrentAddress + readOffset;

                        var currentBytes9 = lucifer.SunIsKind(addressToSave9.ToString("X"), sizeof(int));
                        var currentValue9 = BitConverter.ToInt32(currentBytes9, 0);
                        prevValue2[addressToSave9] = currentValue9;
                        var headbytes = CurrentAddress + readOffset;
                        var chestbytes = CurrentAddress + writeOffset;

                        var bytes = lucifer.SunIsKind(headbytes.ToString("X"), sizeof(int));
                        var Read = BitConverter.ToInt32(bytes, 0);
                        var bytes2 = lucifer.SunIsKind(chestbytes.ToString("X"), sizeof(int));
                        var Read2 = BitConverter.ToInt32(bytes2, 0);

                        lucifer.WriteMemory(chestbytes.ToString("X"), "int", Read.ToString());
                        lucifer.WriteMemory(headbytes.ToString("X"), "int", Read2.ToString());

                        var addressToSave1 = CurrentAddress + writeOffset;
                        var currentBytes1 = lucifer.SunIsKind(addressToSave1.ToString("X"), sizeof(int));
                        var curentValue1 = BitConverter.ToInt32(currentBytes1, 0);
                        prevValue3[addressToSave1] = curentValue1;

                        var addressToSave19 = CurrentAddress + readOffset;
                        var currentBytes19 = lucifer.SunIsKind(addressToSave19.ToString("X"), sizeof(int));
                        var currentValues19 = BitConverter.ToInt32(currentBytes19, 0);
                        prevValue4[addressToSave19] = currentValues19;
                    }
            }
            catch
            {
                throw new Exception("Failed to execute Aimbot");
            }
        }
    }
}