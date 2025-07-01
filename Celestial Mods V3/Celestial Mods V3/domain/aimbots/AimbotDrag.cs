using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LuciferMem;

namespace Celestial_Mods_V3.domain.aimbots
{
    public class AimbotDrag
    {
        public static async void isExecutingAimbot(long offset1, long offset2, Mem lucifer,
            string aimbotCode, Dictionary<long, int> prevValue1, Dictionary<long, int> prevValue2,
            Dictionary<long, int> prevValue3, Dictionary<long, int> prevValue4)
        {
            Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
            lucifer.OpenProcess(proc);
            

            Int64 readOffset = Convert.ToInt64(offset1);
            Int64 writeOffset = Convert.ToInt64(offset2);

            lucifer.OpenProcess(proc);
            try
            {
                var result = await lucifer.AoBScan(0x0000000000000000, 0x00007fffffffffff, aimbotCode, true, true);

                if (result.Count() != 0)
                {
                    foreach (var CurrentAddress in result)
                    {
                        Int64 addressToSave = CurrentAddress + writeOffset;
                        var currentBytes = lucifer.SunIsKind(addressToSave.ToString("X"), sizeof(int));
                        int currentValue = BitConverter.ToInt32(currentBytes, 0);
                        prevValue1[addressToSave] = currentValue;
                        Int64 addressToSave9 = CurrentAddress + readOffset;

                        var currentBytes9 = lucifer.SunIsKind(addressToSave9.ToString("X"), sizeof(int));
                        int currentValue9 = BitConverter.ToInt32(currentBytes9, 0);
                        prevValue2[addressToSave9] = currentValue9;
                        Int64 headbytes = CurrentAddress + readOffset;
                        Int64 chestbytes = CurrentAddress + writeOffset;

                        var bytes = lucifer.SunIsKind(headbytes.ToString("X"), sizeof(int));
                        int Read = BitConverter.ToInt32(bytes, 0);
                        var bytes2 = lucifer.SunIsKind(chestbytes.ToString("X"), sizeof(int));
                        int Read2 = BitConverter.ToInt32(bytes2, 0);

                        lucifer.WriteMemory(chestbytes.ToString("X"), "int", Read.ToString());
                        lucifer.WriteMemory(headbytes.ToString("X"), "int", Read2.ToString());

                        Int64 addressToSave1 = CurrentAddress + writeOffset;
                        var currentBytes1 = lucifer.SunIsKind(addressToSave1.ToString("X"), sizeof(int));
                        int curentValue1 = BitConverter.ToInt32(currentBytes1, 0);
                        prevValue3[addressToSave1] = curentValue1;

                        Int64 addressToSave19 = CurrentAddress + readOffset;
                        var currentBytes19 = lucifer.SunIsKind(addressToSave19.ToString("X"), sizeof(int));
                        int currentValues19 = BitConverter.ToInt32(currentBytes19, 0);
                        prevValue4[addressToSave19] = currentValues19;
                    }

                }


            }
            catch
            {
                throw new Exception("Failed to execute Aimbot");
            }



        }
    }

}