using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_Web.Fairytale
{

    public class Material : IMaterial
    {
        private string name;
        private int strength;

        public int Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                this.strength = value;
            }
        }


        public Material(string name, int strength = 0)
        {
            this.name = name;
            this.strength= strength;
        }     

        public void GenerateStrength(int step)
        {
            this.strength = new Random().Next(1, 100) * step + 1;
        }

        public int Damage(int power)
        {
            if (strength >= power)
            {
                strength -= power;
                power = 0;
            }
            else
            {
                power -= strength;
                strength = 0;
            }
            return power;
        }

        public override string ToString()
        {
            return $"Матеріал {this.name}  має міцність {this.strength}";                   
        }

    }
}
