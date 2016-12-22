using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
  abstract  class Device
    {
        public bool State { get; set; }
        public string Name { get; set; }
        public Device(string name, bool state)
        {
            Name = name;
            State = state;
        }
        public void SwtchOn()
        { }
        public void SwtchOff()
        { }
        public void ChangeName()
        { }
    }
}
