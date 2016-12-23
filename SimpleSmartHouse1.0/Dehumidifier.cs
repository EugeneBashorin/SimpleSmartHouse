using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
    class Dehumidifier : Device, IHumidityAble, IChangeSettingAble
    {
        private Mode mode;
        public int MinHum { get; set; }
        public int MaxHum { get; set; }
        public int CurHum { get; set; }
        public int StepHum { get; set; }

        public Dehumidifier(string name, bool state, Mode mode, int current) : base(name, state)
        {
            Name = name;
            State = false;
            this.mode = mode;
            StepHum = current;
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
            Console.WriteLine("Введите значение шага изменения влажности в пределах (1...5)");
            string v = Console.ReadLine();
            int a = Convert.ToInt32(v);
            if (a >= 1 && a <= 5)
            { StepHum = a; }
            return StepHum;
        }
        public void Increase()
        {
            if (CurHum < MaxHum || (CurHum + StepHum) < MaxHum)
            { CurHum += StepHum; }
            if (CurHum >= MaxHum)
            { CurHum = MaxHum; }
        }
        public void Decrease()
        {
            if (CurHum > MinHum || (CurHum - StepHum) > MinHum)
            { CurHum -= StepHum; }
            if (CurHum <= MinHum)
            { CurHum = MinHum; }
        }
        public int HandSet()
        {
            Console.WriteLine("Введите необходимый уровень влажности");
            Console.WriteLine("Важно!!! Устанавливаемая влажности может быть в пределах\n от 30 до 60 единиц");
            string str = Console.ReadLine();
            int a = Int32.Parse(str);
            if (a > MinHum && a < MaxHum)
            { CurHum = a; }
            Console.WriteLine("Вы ввели не правильную размерность влажности");
            return CurHum;
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
            return "Марка: " + Name + ", Состояние: " + State + ", Режим: " + mode + ", Сухость воздуха: " + CurHum;
        }
    }
}
