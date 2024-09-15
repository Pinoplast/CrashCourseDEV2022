using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_WpfApp.Fairytale
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


        public Material(string name)
        {
            this.name = name;
        }     

        public void GenerateStrength(int step)
        {
            this.strength = new Random().Next(1, 100) * step + 1;
        }

        public override string ToString()
        {
            return $"Матеріал {this.name}  має міцність {this.strength}";                   
        }

    }
}
