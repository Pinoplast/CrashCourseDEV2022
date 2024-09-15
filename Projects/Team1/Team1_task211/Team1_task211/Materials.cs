using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_task211
{

    public class Materials
    {
        private string name;
        private int strength; 

        public Materials(string name)
        {
            this.name = name;
           // Console.WriteLine($"Create new materials name:{name}");

        } 
        public void SetStrength(int strength)
        {
            this.strength = strength;
        }

        public int getStrength()
        {
           return this.strength;
        }

        public void GenerateStrength(int step)
        {
            this.strength = new Random().Next(1, 100)*step+1;
        }

    }
}
