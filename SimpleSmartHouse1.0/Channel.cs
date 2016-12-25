using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSmartHouse1._0
{
    public class Channel : IChannelAble
    {
         public int Min { get; set; }
         public int Max { get; set; }
         public int Current { get; set; }

         public Channel(int min, int max, int current)
        {
            Current = current;
            Min = min;
            Max = max; 
        }
 
        public void NextCh()
        {
            if (Current < Max || (Current ++) < Max)
            { Current++; }
            if (Current >= Max)
            { Current = Max; }
        }

        public void PreviousCh()
        {
            if (Current > Min || (Current --) > Min)
            { Current --; }
            if (Current <= Min)
            { Current = Min; }
        }
        public int HandSetCh()
        {
            Console.WriteLine("Введите номер канала.\nВажно!!! Номер канала/волны может находится в пределах (0 до 100)");
            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                if (a > Min && a < Max)
                { Current = a; }
                return Current;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Message - " + e.Message);
                Console.WriteLine("Введите число в указанных выше пределах");
                Console.ReadLine();
                return Current;
            }
        }
    }
}