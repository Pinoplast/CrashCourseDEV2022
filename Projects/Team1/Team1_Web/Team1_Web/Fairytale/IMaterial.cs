using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_Web.Fairytale
{
    public interface IMaterial
    {
        int Strength { get; set; }

        string ToString();
        int Damage(int power);
    }
}