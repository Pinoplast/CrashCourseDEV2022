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
    public class TestPiggi
    {

        [Test] //атрибут тесту - Nunit буде сприймати даний метод як тест
        [Category("Smoke")]//позначаємо, що тест буде виконуватись з Smoke тестами
        [Category("Regression")]//також даний тест буде виконуватись у Reression категорії

        

    

        public void TestcatchedRezTrue()
        {
            //Assert.Pass();

            //Given
            Piggi p = new Piggi("TestPiggi",1);
            p.speed = 3;
            bool ExpectedValue = true;

            //When
           
               

            var ActualValue = p.catched(4);

            //Then

            Assert.IsTrue(ActualValue == ExpectedValue);
        }

        public void TestcatchedRezFalse()
        {
           
            //Given
            Piggi p = new Piggi("TestPiggi", 1);
            p.speed = 3;
            bool ExpectedValue = false;

            //When



            var ActualValue = p.catched(2);

            //Then

            Assert.IsTrue(ActualValue == ExpectedValue);
        }


    }
}
