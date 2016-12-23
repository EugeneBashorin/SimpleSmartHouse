using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
   public interface IChangeSettingAble
    {
        int Min { get; set; }
        int Max { get; set; }
        int Current { get; set; }
        int Step { get; set; }

        int ChangeStep();
        void Increase();
        void Decrease();
        int HandSet();
    }
}
