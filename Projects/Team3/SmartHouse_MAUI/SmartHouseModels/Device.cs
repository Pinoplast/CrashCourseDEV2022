using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseModels
{
   public abstract class Device : IDevice
    {
        int _id = ++lastId; //id
        static int lastId = 0;//count devices in house
        bool _on = false;
         // public bool IsOn() => _on;
        public bool On {
            get => _on;
            set => _on = value;

        }

        public void Power()
        {
            _on = !_on;
        }
    }
}
