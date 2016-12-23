﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SimpleSmartHouse1._0
{
    class Program
    {
     static void Main(string[] args)
     {
      IDictionary<string, Device> deviceDict = new Dictionary<string, Device>();
      deviceDict.Add("Heater", new Heater("Ufo", false, Mode.Eco, 18) { Min = 14, Max = 30, Step = 1, Current = 18 });
      deviceDict.Add("Humidifier", new Humidifier("Cooper & Hunter", false, Mode.Low, 50) { Min = 45, Max = 95, Step = 5, Current = 50 });
      deviceDict.Add("Dehumidifier", new Dehumidifier("BALLU", false, Mode.Low, 40) { Min = 45, Max = 95, Step = 5, Current = 40 });
      deviceDict.Add("AirCondition", new AirCondition("Yamaha", false, Mode.Low, 22) { Min = 14, Max = 30, Step = 1, Current = 22 });
               
      while (true)
      {
       Console.Clear();
       foreach (KeyValuePair<string, Device> div in deviceDict)
         {
         Console.WriteLine("Название: " + div.Key + ", " + div.Value.ToString());
                }
           Console.WriteLine();
           Console.Write("Введите команду: ");
           string[] commands = Console.ReadLine().Split(' ');
           if (commands[0].ToLower() == "exit" & commands.Length == 1)
             {
              return;
                     }
           if (commands.Length != 2)
             {
              Help();
              continue;
                     }
            if (commands[0].ToLower() == "add" && !deviceDict.ContainsKey(commands[1]))
              {
                    if (commands[1] == "Heater")
                    {
                        deviceDict.Add(commands[1], new Heater("Ufo", false, Mode.Eco, 18) { Min = 14, Max = 30, Step = 1, Current = 18 });
                        continue;
                    }
                    else if (commands[1] == "Humidifier")
                    {
                        deviceDict.Add(commands[1], new Humidifier("Cooper & Hunter", false, Mode.Low, 50) { Min = 45, Max = 95, Step = 5, Current = 50 });
                        continue;
                    }
                    else if (commands[1] == "Dehumidifier")
                    {
                        deviceDict.Add(commands[1], new Dehumidifier("BALLU", false, Mode.Low, 40) { Min = 45, Max = 95, Step = 5, Current = 40 });
                        continue;
                    }
                    else if (commands[1] == "AirCondition")
                    {
                        deviceDict.Add(commands[1], new AirCondition("ЯМаха", false, Mode.Low, 22) { Min = 14, Max = 30, Step = 1, Current = 22 });
                        continue;
                    }
                    else { }
                     }               
               if (commands[0].ToLower() == "add" && deviceDict.ContainsKey(commands[1]))
                  {
                   Console.WriteLine("Устройство с таким именем уже существует");
                   Console.WriteLine("Нажмите любую клавишу для продолжения");
                   Console.ReadLine();
                   continue;
                       }
                if (!deviceDict.ContainsKey(commands[1]))
                   {
                    Help();
                    continue;
                       }
           
                   switch (commands[0].ToLower())
                     {
                    case "del":
                        deviceDict.Remove(commands[1]);
                        break;
                    case "on":
                        deviceDict[commands[1]].SwtchOn();
                        break;
                    case "off":
                        deviceDict[commands[1]].SwtchOff();
                        break;
                    case "cn":
                        deviceDict[commands[1]].ChangeName();
                        break;
                    case "tur":
                        if (commands[1] == "Heater")
                        {
                            ((Heater)deviceDict[commands[1]]).SetTurboMode();
                        }
                        else if (commands[1] == "Humidifier")
                        {
                            ((Humidifier)deviceDict[commands[1]]).SetTurboMode();
                        }
                        else if (commands[1] == "Dehumidifier")
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).SetTurboMode();
                        }
                        else
                        {
                            ((AirCondition)deviceDict[commands[1]]).SetTurboMode();
                        }
                        break;
                    case "eco":
                        if (commands[1] == "Heater")
                        {
                            ((Heater)deviceDict[commands[1]]).SetEcoMode();
                        }
                        else if (commands[1] == "Humidifier")
                        {
                            ((Humidifier)deviceDict[commands[1]]).SetEcoMode();
                        }
                        else if (commands[1] == "Dehumidifier")
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).SetEcoMode();
                        }
                        else
                        {
                            ((AirCondition)deviceDict[commands[1]]).SetEcoMode();
                        }          
                        break;
                    case "low":
                        if (commands[1] == "Heater")
                        {
                            ((Heater)deviceDict[commands[1]]).SetLowMode();
                        }
                        else if (commands[1] == "Humidifier")
                        {
                            ((Humidifier)deviceDict[commands[1]]).SetLowMode();
                        }
                        else if (commands[1] == "Dehumidifier")
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).SetLowMode();
                        }
                        else
                        {
                            ((AirCondition)deviceDict[commands[1]]).SetLowMode();
                        }
                        break;
                    case "aut":
                        if (commands[1] == "Heater")
                        {
                            ((Heater)deviceDict[commands[1]]).SetAutoMode();
                        }
                        else if (commands[1] == "Humidifier")
                        {
                            ((Humidifier)deviceDict[commands[1]]).SetAutoMode();
                        }
                        else if (commands[1] == "Dehumidifier")
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).SetAutoMode();
                        }
                        else
                        {
                            ((AirCondition)deviceDict[commands[1]]).SetAutoMode();
                        }
                         break;
                    case "inc":
                        if (commands[1] == "Heater")
                        {
                            ((Heater)deviceDict[commands[1]]).Increase();
                        }
                        else if (commands[1] == "Humidifier")
                        {
                            ((Humidifier)deviceDict[commands[1]]).Increase();
                        }
                        else if (commands[1] == "Dehumidifier")
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).Increase();
                        }
                        else
                        {
                            ((AirCondition)deviceDict[commands[1]]).Increase();
                        }
                        break;
                    case "dec":
                        if (commands[1] == "Heater")
                        {
                            ((Heater)deviceDict[commands[1]]).Decrease();
                        }
                        else if (commands[1] == "Humidifier")
                        {
                            ((Humidifier)deviceDict[commands[1]]).Decrease();
                        }
                        else if (commands[1] == "Dehumidifier")
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).Decrease();
                        }
                        else
                        {
                            ((AirCondition)deviceDict[commands[1]]).Decrease();
                        }
                        break;
                    case "hse":
                        if (commands[1] == "Heater")
                        {
                            ((Heater)deviceDict[commands[1]]).HandSet();
                        }
                        else if (commands[1] == "Humidifier")
                        {
                            ((Humidifier)deviceDict[commands[1]]).HandSet();
                        }
                        else if (commands[1] == "Dehumidifier")
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).HandSet();
                        }
                        else
                        {
                            ((AirCondition)deviceDict[commands[1]]).HandSet();
                        }
                        break;
                    case "chs":
                        if (commands[1] == "Heater")
                        {
                            ((Heater)deviceDict[commands[1]]).ChangeStep();
                        }
                        else if (commands[1] == "Humidifier")
                        {
                            ((Humidifier)deviceDict[commands[1]]).ChangeStep();
                        }
                        else if (commands[1] == "Dehumidifier")
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).ChangeStep();
                        }
                        else
                        {
                            ((AirCondition)deviceDict[commands[1]]).ChangeStep();
                        }
                        break;                      
                    default:
                        Help();
                        break; 
                }
            }
        }
        private static void Help()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tadd nameDevice - Добавить прибор в список");
            Console.WriteLine("\tdel nameDevice - Удалить прибор из списка");
            Console.WriteLine("\tcn nameDevice - Переименовать Марку дивайса");
            Console.WriteLine("\ton nameDevice  - Включить прибор");
            Console.WriteLine("\toff nameDevice - Выключить прибор");
            Console.WriteLine("\ttur nameDevice - переводит прибор в режим Турбо");
            Console.WriteLine("\teco nameDevice - переводит прибор в режим Эко");
            Console.WriteLine("\tlow nameDevice - переводит прибор в режим Слабый");
            Console.WriteLine("\taut nameDevice - переводит прибор в режим Авто");
            Console.WriteLine("\tinc nameDevice - повысить температуру прибора");
            Console.WriteLine("\tdec nameDevice - понизить температуру прибора");
            Console.WriteLine("\thse nameDevice - ручная настройка температуры прибора");
            Console.WriteLine("\tchs nameDevice - изменить шаг температуры прибора");
            Console.WriteLine("\texit  - Выход из меню");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
    }
 }  
}