using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
    class AirCondition : Device
    {
        public IChangeSettingAble Temper { get; set; }
        private Mode mode;
       
        public AirCondition(string name, bool state, Mode mode, IChangeSettingAble Temper) : base(name, state)
        {
            Name = name;
            State = state;
            this.mode = mode;
            this.Temper = Temper;
        }
        public void Increase()
        {
            Temper.Increase();
        }
        public void Decrease()
        {
            Temper.Decrease();
        }
        public void HandSet()
        {
            Temper.ChangeStep();
        }
        public void ChangeStep()
        {
            Temper.ChangeStep();
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
            return "Марка: " + Name + ", Состояние: " + State + ", Режим: " + mode + ", Температура: " + Temper.Current;
        }
    }
}
