using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_WpfApp.Fairytale
{
    public class Wolf : IAnimal
    {
        public string Name { get; set; }

        public string GetMesssage()
        {
            return $"Моя сила = {this.strenght}, швидкість = {this.speed} \n";
        }

        // -------------------


        public int strenght;
        public int speed;
      

        public Wolf(String name, int strenghtIndex = 1)
        {
            this.Name = name;
            Random r = new Random(strenghtIndex);
            this.strenght = r.Next(1, 10) * strenghtIndex;
            this.speed = r.Next(1, 10);

            //Console.WriteLine("Я " + Name);
            //Console.WriteLine($"Моя сила = {this.strenght}, швидкість = {this.speed} \n");

        }        

        public string destructionBuilding(Building house)
        {
            if (strenght > house.buildingSolidity())
            {
                house.buildingStatus = false;
                return $"Я знищив {house.Name} \n";
            }
            else
            {
                return $"{house.Name} має міцність {house.buildingSolidity()}, мені не хватає сили {strenght} \n";                
            }
        
        }

        public void move(int distance)
        {
            throw new NotImplementedException();
        }        
    }
}
