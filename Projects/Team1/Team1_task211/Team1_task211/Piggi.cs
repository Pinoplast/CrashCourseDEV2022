using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_task211
{
    class Piggi : IAnimal,IPiggi
    {
        public string name;
        int smart; // рівень розуму поросятка (від 1 до 10)
        int power; // рівень сили поросятка (від 1 до 10)
        int speed; // рівень швидкості поросятка (від 1 до 10)
        int distrLevel; //рівень стійкості будинку до руйнування

        public Building myHouse;

        bool died = false;
        bool vtik = false;
        int BaseDistance;

        public Piggi(String name, int smartIndex = 1)
        {
            this.name = name;
            Random r = new Random(smartIndex);
            this.smart = r.Next(1, 10)* smartIndex;
            this.power = r.Next(1, 10);
            this.speed = r.Next(1, 10);
            
            Console.WriteLine("Я " + name);
            Console.WriteLine($"Моя хитрість = {this.smart}, швидкість = {this.speed}  сила = {this.power} \n");
            

        }

        public void buildHouse()
        {
            myHouse = new Building($"Дім {name}a");

            var mat1 = new Materials("Камінь");
            mat1.SetStrength(power * 10);
            myHouse.setBase(mat1);

            var mat2 = new Materials("Дерево");
            mat1.SetStrength((power + smart) / 2 * 10);
            myHouse.setWall(mat2);

            var mat3 = new Materials("Солома");
            mat1.SetStrength(speed * 10);
            myHouse.setRoof(mat3);

            Console.WriteLine($"Я побудував будинок з оцінкою стійкості {myHouse.buildingSolidity()}");
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
    }
}
