using Calculator_2_;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSum10_and_105_exepted115()
        {
            //arange
            int x = 10;
            char z = '+';
            int y = 105;
            int exepted = 115;
            //act
            Calculate c = new Calculate(x, y, z);
            int actual = c.ResOfSum();
            //assert
            Assert.AreEqual(exepted, actual);
        }
        [TestMethod]
        public void TestMethodSub66_and_6_exepted60()
        {
            //arange
            int x = 66;
            char z = '-';
            int y = 6;
            int exepted = 60;
            //act
            Calculate c = new Calculate(x, y, z);
            int actual = c.ResOfSub();
            //assert
            Assert.AreEqual(exepted, actual);
        }
        [TestMethod]
        public void TestMethodMul12_and_5_exepted60()
        {
            //arange
            int x = 12;
            char z = '*';
            int y = 5;
            int exepted = 60;
            //act
            Calculate c = new Calculate(x, y, z);
            int actual = c.ResOfMul();
            //assert
            Assert.AreEqual(exepted, actual);
        }
        [TestMethod]
        public void TestMethodDiv80_and_5_exepted16()
        {
            //arange
            int x = 80;
            char z = '/';
            int y = 5;
            int exepted = 16;
            //act
            Calculate c = new Calculate(x, y, z);
            int actual = c.ResOfDiv();
            //assert
            Assert.AreEqual(exepted, actual);
        }
        [TestMethod]
        public void TestMethodOperation80_sum_5_exepted85()
        {
            //arange
            int x = 80;
            char z = '+';
            int y = 5;
            int exepted = 85;
            //act
            Calculate c = new Calculate(x, y, z);
            int actual = c.Operation();
            //assert
            Assert.AreEqual(exepted, actual);
        }
    }
}
