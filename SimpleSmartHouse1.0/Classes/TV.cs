using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSmartHouse1._0
{
    class TV : Device
    {
        public IVolumAble Volume { get; set; }
        public IChannelAble Channel { get; set; }

        public TV(string name, bool state , IChannelAble channel , IVolumAble volume) : base (name, state)
        {
            Name = name;
            State = state;
            Channel = channel;
            Volume = volume;          
        }
        //Channel
        public void NextCh()
        {
            Channel.NextCh();
        }
        public void PreviousCh()
        {
            Channel.PreviousCh();
        }
        public void HandSetCh()
        {
            Channel.HandSetCh();
        }
        //Volume
        public void IncreaseVol()
        {
            Volume.IncreaseVol();
        }
        public void DecreaseVol()
        {
            Volume.DecreaseVol();
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
            return "Марка: " + Name + ", Состояние: " + State + ", Номер канала: " + Channel.Current + ", Уровень звука: " + Volume.Current;
        }
    }
}