﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    class House
    {
        private int _temperature;
        private int _lux;
        private bool _isMoving;
        public TemperatureSensor temperatureSensor;
        public AirConditioner AirConditioner = new AirConditioner();
        public MotionSensor MotionSensor;
        public Lamp Lamp = new Lamp(100);


        public int Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                temperatureSensor.Value = value;
            }
        }

        public int Lux {
            get => _lux;
            set {
                _lux = value;
                MotionSensor.Value = value;

            }
        }

        public bool IsMoving {
            get => _isMoving;
            set {
                _isMoving = value;
                MotionSensor.IsMoving=value;
            }
        }
        
        public House(int startTemp = 20)
        {
            _temperature = startTemp;
            temperatureSensor = new TemperatureSensor(this); // прив`язали сенсор до цього будинку 
            temperatureSensor.ValueOutOfRange += AirConditioner.Handler;
            AirConditioner.Power();
        }
        public void Run()
        {
            Console.WriteLine("_______Smart House_____OPENED\n\n");
            Console.WriteLine("House is running....");
            
            Random rnd = new Random();
            int interval = 1000;

            int temp;
            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("Enter temperature : ");
                temp = int.Parse(Console.ReadLine());
                Temperature = temp;
                //int randFactor =  rnd.Next(-10, 11);
                //Temperature += randFactor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"House temperature NOW : {Temperature}");
                // System.Threading.Thread.Sleep(interval);
                Console.WriteLine("\t\tPress any  key");
                key = Console.ReadKey();
            }
            while (key.Key!= ConsoleKey.Escape);// !Console.KeyAvailable);

            Console.WriteLine("\n\n_______Smart House_____CLOSED");
        }
    }
}
