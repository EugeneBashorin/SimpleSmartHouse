using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
    class Humidifier : Device, IHumidityAble, IChangeSettingAble
    {
        private Mode mode;
        public int MinHum { get; set; }
        public int MaxHum { get; set; }
        public int CurHum { get; set; }
        public int StepHum { get; set; }

        public Humidifier(string name, bool state, Mode mode, int current) : base(name, state)
        {
            Name = name;
            State = state;
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
            Console.WriteLine("Введите необходимый уровень температуры");
            Console.WriteLine("Важно!!! Устанавливаемая температура может быть в пределах\n от 14 до 30 градусов по шкале Цельсия");
            string str = Console.ReadLine();
            int a = Int32.Parse(str);
            if (a > MinHum && a < MaxHum)
            { CurHum = a; }
            Console.WriteLine("Вы ввели не правильную размерность температуры");
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
            return "Марка: " + Name + ", Состояние: " + State + ", Режим: " + mode + ", Температура: " + CurHum;
        }
    }
}
