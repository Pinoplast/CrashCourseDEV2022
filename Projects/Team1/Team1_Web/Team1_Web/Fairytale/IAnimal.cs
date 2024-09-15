using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_Web.Fairytale
{
    interface IAnimal : IEntity, IInformatible
    {
        void move(int distance);
    }
}
