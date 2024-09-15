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
    public class TestWolf
    {

        [Test] //атрибут тесту - Nunit буде сприймати даний метод як тест
        [Category("Smoke")]//позначаємо, що тест буде виконуватись з Smoke тестами
        [Category("Regression")]//також даний тест буде виконуватись у Reression категорії
        [Repeat(3)]//повторити тест 3 рази і якщо вони успішні, то тест пройдено
        [Order(1)] // порядок виконання тестів

        public void TestDestructionBuilding()
        {
            //Assert.Pass();

            //Given
            Console.WriteLine("TestDestructionBuilding() execution");
            var wolf = new Wolf("testWolf");
            wolf.strenght = 5;
            Material mat1 = new Material("test1");
            mat1.Strength = 1;
            Material mat2 = new Material("test2");
            mat2.Strength = 1;
            Material mat3 = new Material("test3");
            mat3.Strength = 1;
            var house = new Building("testHouse", mat1, mat2, mat3);            
            bool ExpectedValue = false;

            //When
            wolf.destructionBuilding(house);

            var ActualValue = house.buildingStatus;

            //Then
            Assert.IsTrue(ActualValue == ExpectedValue);
            Assert.AreEqual(ActualValue, ExpectedValue);
        }


    }
}
