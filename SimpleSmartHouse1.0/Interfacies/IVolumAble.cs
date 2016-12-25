using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSmartHouse1._0
{
    public interface IVolumAble
    {
        int Min { get; set; }
        int Max { get; set; }
        int Current { get; set; }

        void IncreaseVol();
        void DecreaseVol();
    }
}