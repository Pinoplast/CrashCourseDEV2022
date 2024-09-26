using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace SmartHouseModels
{
    public class House
    {

        private int _temperature;
        private int _lux;
        private bool _isMoving;
        public int OuterTemperature { get; set; }
        
        public TemperatureSensor TemperatureSensor { get; set; }
        public AirConditioner AirConditioner = new AirConditioner();

        public MotionSensor MotionSensor;
        public Lamp Lamp = new Lamp(100);
        public string TestInfo { get; set; }

        public int Temperature
        {
            get => _temperature;
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    TestInfo += $"{value} ";
                    TemperatureSensor.Value = value;
                   
                }
            }
        }
      
        public int Lux
        {
            get => _lux;
            set
            {
                _lux = value;
                MotionSensor.Value = value;

            }
        }

        public bool IsMoving
        {
            get => _isMoving;
            set
            {
                _isMoving = value;
                MotionSensor.IsMoving = value;
            }
        }

        public House(int startTemp = 20, int startLUX = 50)
        {
            //temperature
            _temperature = startTemp;
            TemperatureSensor = new TemperatureSensor(this); // прив`язали сенсор до цього будинку 
            TemperatureSensor.ValueOutOfRange += AirConditioner.Handler;
            AirConditioner.Power();

            //movement
            MotionSensor = new MotionSensor(this);
            _lux = startLUX;
            MotionSensor.ValueOutOfRange += Lamp.Handler;
            if (Lamp.On) Lamp.Power();
        }
        //public void Run()
        //{

        // Random rnd = new Random();

            //int interval = 1000;

            //int temp;
            //int lux;
            //bool moving=false;
            //ConsoleKeyInfo key;
            //do
            //{

            //    lux = rnd.Next(0, 45);
            //    moving = Convert.ToBoolean(rnd.Next(0, 2));
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //    Console.WriteLine($"House LUX: {lux}. Is moving: {moving}");
            //    IsMoving = moving;
            //    Lux = lux;


            //    Console.WriteLine("Enter temperature : ");
            //    temp = int.Parse(Console.ReadLine());
            //    Temperature = temp;
            //    //int randFactor =  rnd.Next(-10, 11);
            //    //Temperature += randFactor;
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine($"House temperature NOW : {Temperature}");
            //    // System.Threading.Thread.Sleep(interval);
            //    Console.ForegroundColor = ConsoleColor.Gray;
            //    Console.WriteLine("\t\tPress any  key");
            //    key = Console.ReadKey();
            //    if (Lamp.IsOn()) Lamp.Power();

            //}
            //while (key.Key!= ConsoleKey.Escape);// !Console.KeyAvailable);

            //Console.WriteLine("\n\n_______Smart House_____CLOSED");
        //}
    }
}
