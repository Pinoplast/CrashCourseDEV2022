using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_task211
{
    class PunisherPiggi: Piggi //супер-порося, яке карає вовка, коли він зїдає порося
    {
        String name;
        public PunisherPiggi(String name):base(name)
        {
            this.name = name;

        }

        public void punishTheWolf(Wolf wolf, int countDeadPiggi = 0)
        {
            if (countDeadPiggi >= 3)
            {
                Console.WriteLine($"Я {wolf.name} прийшов покарати вовка за те, що він з'їв всіх поросят!");
            }
            else
                Console.WriteLine($"{wolf.name} втік у ліс");

            //            WolflevelOfHungry -= 20;
            //Console.WriteLine("Тепер у тебе життів "+ WolflevelOfHungry);
            //return WolflevelOfHungry;   

        }

    }
}
