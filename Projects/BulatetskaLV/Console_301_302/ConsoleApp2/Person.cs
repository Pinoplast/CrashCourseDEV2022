﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Person
    {
        // Розробити клас Person, який містить відповідні члени для зберігання:
        // імені, віку, статі і телефонного номера.
        //  Напишіть функції-члени, які зможуть змінювати ці члени даних індивідуально.
        //  Напишіть функцію-член Person :: Print ()
       private string name;
       private int age;
       private string gender;
       private int phone;

        public Person(string name, int age, string gender, int phone)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.phone = phone;
        }

        string Info()
        {
            string s = $"Ім'я -> {this.name} \nВік ->  {this.age} \nСтать -> {this.gender} \nНомер телефону ->   {this.phone}";
            return s ;
        }

        public void Print()
        {
            Console.WriteLine(Info());
        }

    }
   
}
