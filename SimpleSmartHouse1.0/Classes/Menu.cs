using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSmartHouse1._0
{
    public class Menu
    {
        public void Show()
        {            
         IDictionary<string, Device> deviceDict = new Dictionary<string, Device>();
         deviceDict.Add("Heater", new Heater("Ufo", false, Mode.Eco, new TemperatureH( 14 , 32 , 1 , 18 )));
         deviceDict.Add("Dehumidifier", new Dehumidifier("BALLU", false, Mode.Low, new TemperatureH( 45 , 95 , 5 , 40 ))); 
         deviceDict.Add("AirCondition", new AirCondition("Yamaha", false, Mode.Low, new TemperatureH( 14 , 30 , 1 , 18 )));
         deviceDict.Add("TV", new TV("Samsung", false, new Channel(0, 100, 3), new Volume(0, 40, 10)));
         deviceDict.Add("Radio", new Radio("Philips", false, new Channel(0, 25, 4), new Volume(0, 40, 15)));

            while (true)
            {
                Console.Clear();
                foreach (KeyValuePair<string, Device> div in deviceDict)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Название: " + div.Key + ", " + div.Value.ToString());
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
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
                    if (commands[1].StartsWith("Heater"))
                    {
                        deviceDict.Add(commands[1], new Heater("Ufo", false, Mode.Eco, new TemperatureH(14, 32, 1, 18)));
                        continue;
                    }
                    else if (commands[1].StartsWith("Dehumidifier"))
                        {
                        deviceDict.Add(commands[1], new Dehumidifier("BALLU", false, Mode.Low, new TemperatureH(45, 95, 5, 40)));
                            continue;
                        }
                    else if (commands[1].StartsWith("AirCondition"))
                        {
                        deviceDict.Add(commands[1], new AirCondition("ЯМаха", false, Mode.Low, new TemperatureH(14, 32, 1, 18)));
                            continue;
                        }
                    else if (commands[1].StartsWith("TV"))
                    {
                        deviceDict.Add(commands[1], new TV("Samsung", false, new Channel(0, 100, 3), new Volume(0, 40, 10)));
                        continue;
                    }
                    else if (commands[1].StartsWith("Radio"))
                    {
                        deviceDict.Add(commands[1], new Radio("Philips", false, new Channel(0, 25, 4), new Volume(0, 40, 15)));
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

                    case "tur":                                            // For Heater  Dehumidifier   AirCondition
                        if (commands[1].StartsWith("Heater"))
                        {
                            ((Heater)deviceDict[commands[1]]).SetTurboMode();
                        }
                        else if (commands[1].StartsWith("Dehumidifier"))
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).SetTurboMode();
                        }
                        else if (commands[1].StartsWith("AirCondition"))
                        {
                            ((AirCondition)deviceDict[commands[1]]).SetTurboMode();
                        }
                        break;

                    case "eco":                                            // For Heater  Dehumidifier   AirCondition
                        if (commands[1].StartsWith("Heater"))
                        {
                            ((Heater)deviceDict[commands[1]]).SetEcoMode();
                        }
                        else if (commands[1].StartsWith("Dehumidifier"))
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).SetEcoMode();
                        }
                        else if (commands[1].StartsWith("AirCondition"))
                        {
                            ((AirCondition)deviceDict[commands[1]]).SetEcoMode();
                        }
                        break;

                    case "low":                                             // For Heater  Dehumidifier   AirCondition
                        if (commands[1].StartsWith("Heater"))
                        {
                            ((Heater)deviceDict[commands[1]]).SetLowMode();
                        }
                        else if (commands[1].StartsWith("Dehumidifier"))
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).SetLowMode();
                        }
                        else if (commands[1].StartsWith("AirCondition"))
                        {
                            ((AirCondition)deviceDict[commands[1]]).SetLowMode();
                        }
                        break;

                    case "aut":                                             // For Heater  Dehumidifier   AirCondition
                        if (commands[1].StartsWith("Heater"))
                        {
                            ((Heater)deviceDict[commands[1]]).SetAutoMode();
                        }
                        else if (commands[1].StartsWith("Dehumidifier"))
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).SetAutoMode();
                        }
                        else if (commands[1].StartsWith("AirCondition"))
                        {
                            ((AirCondition)deviceDict[commands[1]]).SetAutoMode();
                        }
                        break;

                    case "inc":                                              // For Heater  Dehumidifier   AirCondition
                        if (commands[1].StartsWith("Heater"))
                        {
                            ((Heater)deviceDict[commands[1]]).Increase();
                        }
                        else if (commands[1].StartsWith("Dehumidifier"))       
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).Increase();
                        }
                        else if (commands[1].StartsWith("AirCondition"))       
                        {
                            ((AirCondition)deviceDict[commands[1]]).Increase();
                        }
                        break;

                    case "dec":
                        if (commands[1].StartsWith("Heater"))                   
                        {
                            ((Heater)deviceDict[commands[1]]).Decrease();
                        }
                        else if (commands[1].StartsWith("Dehumidifier"))        
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).Decrease();
                        }
                        else if (commands[1].StartsWith("AirCondition"))        
                        {
                            ((AirCondition)deviceDict[commands[1]]).Decrease();
                        }
                        break;

                    case "hse":
                        if (commands[1].StartsWith("Heater"))                   
                        {
                            ((Heater)deviceDict[commands[1]]).HandSet();
                        }
                        else if (commands[1].StartsWith("Dehumidifier"))        
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).HandSet();
                        }
                        else if (commands[1].StartsWith("AirCondition"))        
                        {
                            ((AirCondition)deviceDict[commands[1]]).HandSet();
                        }                  
                        break;

                    case "chs":
                        if (commands[1].StartsWith("Heater"))                   
                        {
                            ((Heater)deviceDict[commands[1]]).ChangeStep();
                        }
                         else if (commands[1].StartsWith("Dehumidifier"))      
                        {
                            ((Dehumidifier)deviceDict[commands[1]]).ChangeStep();
                        }
                        else if (commands[1].StartsWith("AirCondition"))      
                        {
                            ((AirCondition)deviceDict[commands[1]]).ChangeStep();
                        }
                        break;
                                                                               // add some options for TV Radio
                    case "nxt":
                        if (commands[1].StartsWith("TV"))                    
                        {
                            ((TV)deviceDict[commands[1]]).NextCh();
                        }
                        else if (commands[1].StartsWith("Radio"))              
                        {
                            ((Radio)deviceDict[commands[1]]).NextCh();
                        }                       
                        break;

                    case "prv":
                        if (commands[1].StartsWith("TV"))                
                        {
                            ((TV)deviceDict[commands[1]]).PreviousCh();
                        }
                        else if (commands[1].StartsWith("Radio"))      
                        {
                            ((Radio)deviceDict[commands[1]]).PreviousCh();
                        }
                        break;

                    case "hsc":
                        if (commands[1].StartsWith("TV"))            
                        {
                            ((TV)deviceDict[commands[1]]).HandSetCh();
                        }
                        else if (commands[1].StartsWith("Radio"))    
                        {
                            ((Radio)deviceDict[commands[1]]).HandSetCh();
                        }
                        break;

                    case "inv":
                        if (commands[1].StartsWith("TV"))              
                        {
                            ((TV)deviceDict[commands[1]]).IncreaseVol();
                        }
                        else if (commands[1].StartsWith("Radio"))       
                        {
                            ((Radio)deviceDict[commands[1]]).IncreaseVol();
                        }
                        break;

                    case "dev":
                        if (commands[1].StartsWith("TV"))             
                        {
                            ((TV)deviceDict[commands[1]]).DecreaseVol();
                        }
                        else if (commands[1].StartsWith("Radio"))      
                        {
                            ((Radio)deviceDict[commands[1]]).DecreaseVol();
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Доступные команды для:");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nОбогреватель/Увлажнитель/Осушитель/Телевизор/Радио:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\tadd nameDevice - Добавить девайс в список");
            Console.WriteLine("\tdel nameDevice - Удалить девайс из списка");
            Console.WriteLine("\ton nameDevice  - Включить девайс");
            Console.WriteLine("\toff nameDevice - Выключить девайс");
            Console.WriteLine("\tcn nameDevice -  Переименовать Марку девайса");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nОбогреватель/Увлажнитель/Осушитель:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\ttur nameDevice - переводит девайс в режим Турбо");
            Console.WriteLine("\teco nameDevice - переводит девайс в режим Эко");
            Console.WriteLine("\tlow nameDevice - переводит девайс в режим Слабый");
            Console.WriteLine("\taut nameDevice - переводит девайс в режим Авто");
            Console.WriteLine("\tinc nameDevice - повысить температуру девайса");
            Console.WriteLine("\tdec nameDevice - понизить температуру девайса");
            Console.WriteLine("\thse nameDevice - ручная настройка уровня температуры/ влажности девайса");
            Console.WriteLine("\tchs nameDevice - изменить шаг температуры/ влажности девайса");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nТелевизор/Радио:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\tnxt nameDevice - переключить на следующий канал/волну");
            Console.WriteLine("\tprv nameDevice - переключить на предыдущий канал/волну");
            Console.WriteLine("\thsc nameDevice - ручной выбор канала/волны");
            Console.WriteLine("\tinv nameDevice - увеличить громкость звука");
            Console.WriteLine("\tdev nameDevice - уменьшить громкость звука");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\texit  - Выход из меню");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }
    }
}
  