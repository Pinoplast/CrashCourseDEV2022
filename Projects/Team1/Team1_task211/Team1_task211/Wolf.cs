using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_task211
{
    class Wolf
    {
        public int strenght;
        public int speed;
        public string name;

        public Wolf(String name, int strenghtIndex = 1)
        {
            this.name = name;
            Random r = new Random(strenghtIndex);
            this.strenght = r.Next(1, 10) * strenghtIndex;
            this.speed = r.Next(1, 10);

            Console.WriteLine("Я " + name);
            Console.WriteLine($"Моя сила = {this.strenght}, швидкість = {this.speed} \n");

        }

        public bool destructionBuilding(Building house)
        {
            if (strenght > house.buildingSolidity())
            {
                house.buildingStatus = false;
                Console.WriteLine($"Я знищив {house.buildingName} \n");
                return true;
            }
            else
            {
                Console.WriteLine($"Будинок має міцність {house.buildingSolidity()} мені не хватає сили {strenght} \n");
                return false;
            }
        
        }
    }
}
