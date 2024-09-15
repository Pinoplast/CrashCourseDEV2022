using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_WpfApp.Fairytale
{
    interface IAnimal : IEntity, IInformatible
    {
        void move(int distance);
    }
}
