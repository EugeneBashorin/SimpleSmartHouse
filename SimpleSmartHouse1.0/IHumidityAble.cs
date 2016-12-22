using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
  public  interface IHumidityAble
    {
        int MinHum { get; set; }
        int MaxHum { get; set; }
        int CurHum { get; set; }
        int StepHum { get; set; }
    }
}
