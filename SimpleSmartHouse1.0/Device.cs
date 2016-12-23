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
         {
            State = true;
         }

        public void SwtchOff()
        {
            State = true;
        }

        public string ChangeName()
        {
            Console.WriteLine("Введите марку дивайса");
            Name = Console.ReadLine();
            return Name;
        }
    }
}
