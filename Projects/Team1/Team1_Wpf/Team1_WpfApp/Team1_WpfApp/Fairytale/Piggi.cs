using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Team1_WpfApp.Fairytale
{
    public class Piggi : IAnimal, IPiggi, INotifyPropertyChanged
    {
        //public string Name { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public virtual string GetMesssage()
        {
            return $"Я {this.Name}  \n" +
                   $"Моя хитрість = {this.smart}, швидкість = {this.speed}  сила = {this.power} \n";
        }

        // -------------

        int smart; // рівень розуму поросятка (від 1 до 10)
        int power; // рівень сили поросятка (від 1 до 10)
        public int speed; // рівень швидкості поросятка (від 1 до 10)
        int distrLevel; //рівень стійкості будинку до руйнування

        public Building myHouse;

        bool died = false;
        bool vtik = false;
        int BaseDistance;        

        public Piggi(String name, int smartIndex = 1)
        {
            this._name = name;
            Random r = new Random(smartIndex);
            this.smart = r.Next(1, 10)* smartIndex;
            this.power = r.Next(1, 10);
            this.speed = r.Next(1, 10);
            
            Console.WriteLine("Я " + name);
            Console.WriteLine($"Моя хитрість = {this.smart}, швидкість = {this.speed}  сила = {this.power} \n");
            

        }

        public void buildHouse()
        {
            var _base = new Material("Камінь");
            _base.Strength = power * 10;

            var wall = new Material("Дерево");
            wall.Strength = (power + smart) / 2 * 10;

            var roof = new Material("Солома");
            roof.Strength = speed * 10;

            myHouse = new Building($"Дім {_name}a", _base, wall, roof);
        }

        public bool catched(int rivalspeed)
        {
            if (rivalspeed > speed)
                return true;
            else
                return false;
        }

        public void funny()
        {
            smart++;
            power++;
            speed++;
        }


        public void move(int distance)
        {
            distance += speed;
            Console.WriteLine("Я пройшов ще " + speed + " метрів.");

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
