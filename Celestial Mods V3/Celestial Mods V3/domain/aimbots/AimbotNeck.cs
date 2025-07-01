using System.Collections.Generic;

namespace Celestial_Mods_V3.domain.aimbots
{
    public class AimbotNeck : AbsractAimbot
    {
        public AimbotNeck()
        {
            var aimbotCode =
                "FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 A5 43";

            long offset1 = 172; // Replace with actual offset
            long offset2 = 168; // Replace with actual offset
            var prevValue1 = new Dictionary<long, int>();
            var prevValue2 = new Dictionary<long, int>();
            var prevValue3 = new Dictionary<long, int>();
            var prevValue4 = new Dictionary<long, int>();
            base.InitializeBase(
                aimbotCode,
                offset1,
                offset2,
                prevValue4,
                prevValue3,
                prevValue2,
                prevValue1
            );
        }
    }
}