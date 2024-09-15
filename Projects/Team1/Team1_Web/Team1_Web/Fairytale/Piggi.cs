using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Team1_Web.Fairytale
{
    public class Piggi : IAnimal, IPiggi
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //public string Name { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string GetMesssage()
        {
            return $"Я {this.Name}  \n" +
                   $"Моя хитрість = {this.smart}, швидкість = {this.speed}  сила = {this.power} \n";
        }

        // -------------

        int smart; // рівень розуму поросятка (від 1 до 10)
        int power; // рівень сили поросятка (від 1 до 10)
        int speed; // рівень швидкості поросятка (від 1 до 10)
        //int distrLevel; //рівень стійкості будинку до руйнування

        public int Smart
        {
            get { return smart; }
            set { smart = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Building MyHouse { get; set; }

        public enum Status
        {
            Alive = 1,
            Dead = 2,
            Escape = 3
        }

        public Status status = Status.Alive;

        public Piggi(int id, String name, int smartIndex = 1)
        {
            this.id = id;
            this._name = name;
            Random r = new Random(smartIndex);
            this.smart = r.Next(1, 10) * smartIndex;
            this.power = r.Next(1, 10);
            this.speed = r.Next(1, 10);
            MyHouse = new Building($"", new Material(""), new Material(""), new Material(""));
        }

        public void buildHouse()
        {
            var _base = new Material("Камінь");
            _base.Strength = power * 10;

            var wall = new Material("Дерево");
            wall.Strength = (power + smart) / 2 * 10;

            var roof = new Material("Солома");
            roof.Strength = speed * 10;

            MyHouse = new Building($"Дім {_name}a", _base, wall, roof);
        }

        public bool catched(int rivalspeed)
        {
            if (rivalspeed > speed)
            {
                status = Status.Dead;
                return true;
            }
            else
            {
                status = Status.Escape;
                return false;
            }
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

    }
}
