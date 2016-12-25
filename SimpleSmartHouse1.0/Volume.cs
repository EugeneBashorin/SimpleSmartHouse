using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSmartHouse1._0
{
    public class Volume: IVolumAble
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Current { get; set; }

        public Volume(int min, int max, int current)
        {
            Current = current;
            Min = min;
            Max = max;
        }

        public void IncreaseVol()
        {
            if (Current < Max || (Current++) < Max)
            { Current++; }
            if (Current >= Max)
            { Current = Max; }
        }

        public void DecreaseVol()
        {
            if (Current > Min || (Current--) > Min)
            { Current--; }
            if (Current <= Min)
            { Current = Min; }
        }
    }
}