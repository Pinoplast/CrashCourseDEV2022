using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;

namespace Team1_WpfApp.Fairytale
{
    [TestFixture]//визначення тест-класу
    public class TestPunisherPiggi
    {

        [Test] //атрибут тесту - Nunit буде сприймати даний метод як тест
        [Category("Smoke")]//позначаємо, що тест буде виконуватись з Smoke тестами
        [Category("Regression")]//також даний тест буде виконуватись у Reression категорії
        [Repeat(3)]//повторити тест 3 рази і якщо вони успішні, то тест пройдено
        [Order(1)] // порядок виконання тестів

        public void punishTheWolfTest()
        {

            //Given

            var wolf = new Wolf("testWolf");
            wolf.strenght = 5;

            string ExpectedValue = "Я testWolf прийшов покарати вовка за те, що він з'їв всіх поросят!";

            //When
            //  wolf.destructionBuilding(house);
            var pp = new PunisherPiggi("TestPunisherPiggi");
            var ActualValue = pp.punishTheWolf(wolf, 4);

            //Then
            Assert.AreEqual(ActualValue, ExpectedValue);
        }



    }
}
