using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseModels
{
   public interface ISensor
    {
        int Value { get; set; }
        event EventHandler ValueOutOfRange;// ----> list methods
                                           // event EventHandler DangerousValue; // danger  of fire etc
    }
}
