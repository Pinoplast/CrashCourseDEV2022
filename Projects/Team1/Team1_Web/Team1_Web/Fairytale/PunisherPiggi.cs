using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Team1_Web.Fairytale
{
    class PunisherPiggi : Piggi //супер-порося, яке карає вовка, коли він зїдає порося
    {
        public PunisherPiggi(string name):base(1, name)
        {           
        }

        public string punishTheWolf(Wolf wolf, int countDeadPiggi = 0)
        {
            if (countDeadPiggi >= 3)
            {
                return $"Я {wolf.Name} прийшов покарати вовка за те, що він з'їв всіх поросят!";
            }
            else
                return $"{wolf.Name} втік у ліс";

            //            WolflevelOfHungry -= 20;
            //Console.WriteLine("Тепер у тебе життів "+ WolflevelOfHungry);
            //return WolflevelOfHungry;   

        }

        public override string GetMesssage()
        {
            return $"Я {this.Name}  \n";
        }

    }
}
