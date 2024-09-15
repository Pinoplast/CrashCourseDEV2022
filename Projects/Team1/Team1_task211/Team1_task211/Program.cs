using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_task211
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //встановлюємо кодування для виводу кирилиці в консоль
            // Казка "Троє поросят"

            #region 1. Поросята та вовк

            //a) потрібен абстрактний клас Animals
            // поля - ім'я
            //методи -?

            //б) потрібен клас Piggy, що наслідує Animals
            // поросята вміють веселитись та прокачували скіли, будувати будинок - два методи
            // поля - розум, працьовитість, швидкість
            // Породжуємо трьох поросят: Ніф-Ніф, Наф-Наф і Нуф-Нуф

            //в) потрібен клас Wolf, що наслідує Animals
            // вовк вміє полювати та істи - два методи (коли дуже голодний, то йде шукати поросят)
            // поля - хитрість, сила подиху, голод

            // Породжуємо вовка
            // вміє знижувати міцніть будинків та ламати їх силою подиху - метод 
            // вміє обдурювати поросят - метод
            #endregion

            #region 2. Будинок

            //a) потрібен клас Building
            // поля - назва, міцність, статус
            // має фундамент, стіни, криша, методи -?

            //породжуємо три об'єкти будинків, що будують поросята
            //в залежності від характеристик поросят генеруються різні будинки, де його міцність = сумі міцності матеріалів
            #endregion

            #region 3. Матеріали для будинку

            //a) потрібен клас Material, породжує об'єкти Солома, Дерево, Камень 
            // поля - назва, міцність
            // метод - випадкова генерація характеристики міцності в заданих межах

            #endregion

            #region 4. Сценарій

            // 1. Поросята відпочивають, їм генеруються скіли.

            List<Piggi> piglets = new List<Piggi>() { 
                    new Piggi("Ніф-Ніф", 1), 
                    new Piggi("Наф-Наф", 2), 
                    new Piggi("Нуф-Нуф", 3)
            };


            // 2. Будуємо будинки - вибір матеріалів випадковий, в залежності від скілів поросят

            foreach (var piggi in piglets)
            {
                piggi.buildHouse();
            }

            // 3. Вовка чекає поки не зголодніє і приходить до першого поросята

            var wolf = new Wolf("Вовк", 10);
            Console.ReadKey();

            //      - дихає на будинок скільки є сил, якщо розвалив, то їсть та йде до наступного поросяти
            int deadPiggiCount = 0;
            foreach (var piggi in piglets)
            {
                wolf.destructionBuilding(piggi.myHouse);
                if (!piggi.myHouse.buildingStatus)
                    if (piggi.catched(wolf.speed))
                    {
                        deadPiggiCount++;
                        Console.WriteLine($"Я з'їв {piggi.name} \n");
                    }
                    else
                        Console.WriteLine($"{piggi.name} втік\n");
                Console.ReadKey();
            }
            //      - намагається обдурити, якщо так, то їсть та йде до наступного поросяти
            //      - не вийшло розвалити та обдурити - порося вижило, йде до наступного поросяти
            //      - пройшов всіх, або втік в ліс, або когось зжер(

            PunisherPiggi superPiggi = new PunisherPiggi("Cупер порося");
            superPiggi.punishTheWolf(wolf, deadPiggiCount);
         



            #endregion

            Console.ReadKey();


        }
    }
}
