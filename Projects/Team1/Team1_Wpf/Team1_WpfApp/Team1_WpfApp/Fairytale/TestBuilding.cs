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
    public class TestBuilding
    {

        [Test] //атрибут тесту - Nunit буде сприймати даний метод як тест
        [Category("Smoke")]//позначаємо, що тест буде виконуватись з Smoke тестами
        [Category("Regression")]//також даний тест буде виконуватись у Reression категорії
        [Repeat(3)]//повторити тест 3 рази і якщо вони успішні, то тест пройдено
        [Order(1)] // порядок виконання тестів

        public void BuildingSolidityTestRez4()
        {

            //Given
            Console.WriteLine("TestDestructionBuilding() execution");
            var wolf = new Wolf("testWolf");
            wolf.strenght = 5;
            Material mat_base = new Material("Base");
            mat_base.Strength = 1;
            Material mat_wall = new Material("Wall");
            mat_wall.Strength = 2;
            Material mat_roof = new Material("Roof");
            mat_roof.Strength = 1;

            Building testBuilding = new Building("Test House", mat_base, mat_wall, mat_roof);


            int ExpectedValue = 4;

            //When
            //  wolf.destructionBuilding(house);

            var ActualValue = testBuilding.buildingSolidity();

            //Then
            Assert.AreEqual(ActualValue, ExpectedValue);
        }

        public void BuildingSolidityTestRez10()
        {

            //Given
            Console.WriteLine("TestDestructionBuilding() execution");
            var wolf = new Wolf("testWolf");
            wolf.strenght = 5;
            Material mat_base = new Material("Base");
            mat_base.Strength = 4;
            Material mat_wall = new Material("Wall");
            mat_wall.Strength = 2;
            Material mat_roof = new Material("Roof");
            mat_roof.Strength = 4;

            Building testBuilding = new Building("Test House", mat_base, mat_wall, mat_roof);


            int ExpectedValue = 10;

            //When
            //  wolf.destructionBuilding(house);

            var ActualValue = testBuilding.buildingSolidity();

            //Then
            Assert.AreEqual(ActualValue, ExpectedValue);
        }
    }
}
