using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
    public interface ITemperatureAble
    {
        int MinTemp { get; set; }
        int MaxTemp { get; set; }
        int CurTemp { get; set; }
        int StepTemp { get; set; }
    }
}
