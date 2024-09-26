using SmartHouse_MAU.Commands;
using SmartHouseModels; // from other project  (dll)
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//usi

namespace SmartHouse_MAU.ViewModel
{
    internal class HouseViewModel : INotifyPropertyChanged
    {
        private House _house;
       // public ICommand ChangeTemper { get; set; }
        public ICommand MonitorIndicators { get; set; }
        public ICommand Run { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public HouseViewModel()
        {
            _house = new House();
           // ChangeTemper = new ChangeTemperatureCommand(this); // create command
           // ChangeTemper = new Command(ChangeTemperature); // create command
             MonitorIndicators = new Command(MonitoringIndicators); // create command
Run = new Command(RunHouse);// create command
        }
        public int Temperature
        {
            get => _house.Temperature;
            set
            {
                if (_house.Temperature != value)
                {
                    _house.Temperature = value;
                    OnPropertyChanged(nameof(Temperature));
                }
            }
        }
        public string Info
        {
            get => _house.AirConditioner.Info;
            set
            {
                if (_house.AirConditioner.Info != value)
                {
                    _house.AirConditioner.Info = value;
                    OnPropertyChanged(nameof(Info));
                }
            }
        }
        public int OuterTemperature
        {
            get => _house.OuterTemperature;
            set
            {
                if (_house.OuterTemperature != value)
                {
                    _house.OuterTemperature = value;
                    OnPropertyChanged(nameof(OuterTemperature));
                }
            }
        }
        public string TestInfo // &&&&& NEED ????
        {
            get => _house.TestInfo;
            set
            {
                if (_house.TestInfo != value)
                {
                    _house.TestInfo = value;
                    OnPropertyChanged(nameof(TestInfo));
                }
            }
        }
        public AirCondMode AirConditionerMode
        {
            get => _house.AirConditioner.Mode;
            set
            {
                if (_house.AirConditioner.Mode != value)
                {
                    _house.AirConditioner.Mode = value;
                    OnPropertyChanged(nameof(AirConditionerMode));
                }
            }
        }
        #region Properties  MotionSensor an LAMP
        
        public int Lux
        {
            get => _house.Lux;
            set
            {
               _house.Lux = value;
                OnPropertyChanged(nameof(Lux));
               
            }
        }

        public bool IsMoving
        {
            get => _house.IsMoving;
            set
            {
               _house.IsMoving = value;
               OnPropertyChanged(nameof(IsMoving));
           
            }
        }

        public string InfoWorkingLamp
        {
            get => _house.Lamp.InfoWorkingLamp;
            set
            {
                if (_house.Lamp.InfoWorkingLamp != value)
                {
                    _house.Lamp.InfoWorkingLamp = value;
                    OnPropertyChanged(nameof(InfoWorkingLamp));
            }
        }
        }

        public bool OnLamp
        {
            get => _house.Lamp.On;
            set
            {
                if (_house.Lamp.On != value)
                {
                    _house.Lamp.Power();
                    OnPropertyChanged(nameof(OnLamp));

                }
            }
        }
        #endregion

        Random rnd = new Random();
        public void MonitoringIndicators() // will call by  command
        {
            int randTemp = rnd.Next(-40, 40);
            Debug.WriteLine($"\n\n>>>>>>>>>>>>>>>> In method MonitoringIndicators:\n OuteTemp is {randTemp}");
            OuterTemperature = randTemp;

            // Info = ""; 
            Info += $"___OuteTemp is {randTemp}__\n\r";
            Temperature = randTemp; // -15;

            //testing lamp and motionsensor!
            if (_house.Lamp.On) 
                _house.Lamp.Power();
            //change ragen
            int lux = rnd.Next(0, 70);
            bool  moving = Convert.ToBoolean(rnd.Next(0, 2));

            Debug.WriteLine($"House LUX: {lux}. Is moving: {moving}");
            IsMoving = moving;
            Lux = lux;
            if (moving && Lux<50) {
                InfoWorkingLamp = $"Somebody come in house.\n\rWelcome HOME! :) \n\rLamp ON, because a little dark! \n\rLux: {Lux}.\n\r";
            }
            else if (moving && Lux > 50)
            {
                InfoWorkingLamp = $"Somebody come in house.\n\rWelcome HOME! :) \n\rLamp OFF, because lighting is enough! \n\rLux: {Lux}.\n\r";
            }
            else if (!moving && Lux > 50)
            {
                InfoWorkingLamp = $"There is no one at home... \n\rLamp OFF, because lighting is enough! \n\rLux: {Lux}.\n\r";
            }
            else 
            {
                InfoWorkingLamp = $"There is no one at home... \n\rLamp OFF.\n\r";
            }
        


        }
        public void RunHouse()
        {
            OuterTemperature = 20;
            Temperature = OuterTemperature;
            Info = "OPENED ";
            // !!!!!! add some code Lamp
        }
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
