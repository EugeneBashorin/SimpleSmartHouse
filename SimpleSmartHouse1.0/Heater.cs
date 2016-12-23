using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
    class Heater : Device, ITemperatureAble, IChangeSettingAble
    {
        private Mode mode;
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
        public int CurTemp { get; set; }
        public int StepTemp { get; set; }

        public Heater(string name, bool state, Mode mode, int current) : base(name, state)
        {
            Name = name;
            State = state;
            this.mode = mode;
            CurTemp = current;
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
            Console.WriteLine("Введите значение шага изменения температуры");
            string v = Console.ReadLine();
            int a = Convert.ToInt32(v);
            if (a >= 1 && a <= 5)
            { StepTemp = a; }
            return StepTemp;
        }
        public void Increase()
        {
            if (CurTemp < MaxTemp || (CurTemp + StepTemp) < MaxTemp)
            { CurTemp += StepTemp; }
            if (CurTemp >= MaxTemp)
            { CurTemp = MaxTemp; }
        }
        public void Decrease()
        {
            if (CurTemp > MinTemp || (CurTemp - StepTemp) > MinTemp)
            { CurTemp -= StepTemp; }
            if (CurTemp <= MinTemp)
            { CurTemp = MinTemp; }
        }
        public int HandSet()
        {
            Console.WriteLine("Введите необходимый уровень температуры");
            Console.WriteLine("Важно!!! Устанавливаемая температура может быть в пределах\n от 14 до 30 градусов по шкале Цельсия");
            string str = Console.ReadLine();
            int a = Int32.Parse(str);
            if (a > MinTemp && a < MaxTemp)
            { CurTemp = a; }
            Console.WriteLine("Вы ввели не правильную размерность температуры");
            return CurTemp;
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
            return "Марка: " + Name + ", Состояние: " + State + ", Режим: " + mode + ", Температура: " + CurTemp;
        }
    }
}
