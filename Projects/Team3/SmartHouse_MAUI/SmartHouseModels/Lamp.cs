using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseModels
{
   public class Lamp : Device
    {
        private int _lux;

        public Lamp(int lux)
        {
            _lux = lux;
        }
        string _infoWorkingLamp = "";
        public string InfoWorkingLamp
        {
            get => _infoWorkingLamp;
            set => _infoWorkingLamp = value;
        }
        public void Handler(object o, EventArgs e)
        {
            if (!On)
            {
                House h = o as House;
                h.Lamp.Power();
                Debug.WriteLine("Lamp ON!");
                _infoWorkingLamp = "Lamp ON!\n";

            }
            else {
                House h = o as House;
                h.Lamp.Power();
                _infoWorkingLamp = "Lamp OFF!";
                Debug.WriteLine("Lamp OFF!");
            }


        }



    }
}
