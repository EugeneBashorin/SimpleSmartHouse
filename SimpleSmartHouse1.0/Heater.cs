using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
    class Heater : Device, IChangeSettingAble
    {
        private Mode mode;
        public int Min { get; set; }
        public int Max { get; set; }
        public int Current { get; set; }
        public int Step { get; set; }

        public Heater(string name, bool state, Mode mode, int current) : base(name, state)
        {
            Name = name;
            State = state;
            this.mode = mode;
            Current = current;
        }
        public void SetTurboMode()
        {
            mode = Mode.Turbo;
        }
        public void SetEcoMode()
        {
            mode = Mode.Eco;
        }
        public void SetLowMode()
        {
            mode = Mode.Low;
        }
        public void SetAutoMode()
        {
            mode = Mode.Auto;
        }
        public int ChangeStep()
        {
            Console.WriteLine("Введите значение шага изменения температуры для обогревателя.\nШаг температуры может находится в пределах (1..5).Шаг по умолчанию равен 1");
            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                if (a >= 1 && a <= 5)
                { Step = a; }
                return Step;
            }
             catch (FormatException e)
            {
                Console.WriteLine("Message - " + e.Message);
                Console.WriteLine("Введите цифру");
                Console.ReadLine();
                return Step;
            }
        }
        public void Increase()
        {
            if (Current < Max || (Current + Step) < Max)
            { Current += Step; }
            if (Current >= Max)
            { Current = Max; }
        }
        public void Decrease()
        {
            if (Current > Min || (Current - Step) > Min)
            { Current -= Step; }
            if (Current <= Min)
            { Current = Min; }
        }
        public int HandSet()
        {
            Console.WriteLine("Введите необходимый уровень температуры.\nВажно!!! Устанавливаемая температура может находится в пределах (14 до 30)");
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
        public override string ToString()
        {
            string State;
            if (this.State)
            {
                State = "включен";
            }
            else
            {
                State = "выключен";
            }
            string mode;
            if (this.mode == Mode.Turbo)
            {
                mode = "Турбо";
            }
            else if (this.mode == Mode.Eco)
            {
                mode = "Эко";
            }
            else if (this.mode == Mode.Low)
            {
                mode = "Слабый";
            }
            else
            {
                mode = "Авто";
            }
            return "Марка: " + Name + ", Состояние: " + State + ", Режим: " + mode + ", Температура: " + Current;
        }
    }
}
