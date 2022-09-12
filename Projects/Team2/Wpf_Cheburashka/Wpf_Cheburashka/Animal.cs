﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Cheburashka
{
    public class Animal : IPerson
    {
        private string name; // Ім'я
        public int strong; // Сила, генерується випадковим чином, так як персонаж втомлюється і набирається сил
        public int count; // кількість будматеріалу, яку може підняти персонаж
        public string work; // робота, яку виконує персонаж

        public static Random random = new Random();

        public Animal(string name, int strong)
        {
            this.name = name;
            this.strong = strong;
            Console.WriteLine($"Привіт я {this.name}");
        }
        public Animal(string name)
        {
            this.name = name;
            Console.WriteLine($"Привіт я {this.name}");
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        // Якщо персонаж достатньо сильний, щоб підняти будматеріал кількістю count,
        // то функція поверне це значення, інакше персонаж не взмозі підняти будматеріал і функція поверне значнення 0
        public int GetWork(string work, int count)
        {
            this.work = work;
            int a;
            if (count <= strong)
            {
                a = count;
            }
            else
            {
                a = 0;
            }
            this.count = a;
            Say();
            return a;
        }

        // Персонаж озвучує свою роботу
        public string Say()
        {
            string s = $"Я { this.name}!";
            if (this.count != 0)
            { s = s + $"Я будую {this.work} і несу, будматеріал кількістю {this.count} "; }
            else { s = s + $"\nЯ не можу підняти стільки, \nнайбільше можу підняти кількістю \n{this.strong} "; }

            Console.WriteLine(s);

            return s;
        }
    }
}