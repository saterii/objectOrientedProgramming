using Exercise_34;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestArrayCalculator
{
    [TestClass]
    public class ArrayCalculatorTests
    {
        public double[] emptyArray = { };
        [TestMethod]
        public void TestSum()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double expected = 25.6;
            double actual = ArrayCalculator.CalcSum(array);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAvg()
        {
            double[] array = { 1.0, 2.0, 3.0, 4.0, 5.0  };
            double expected = 3.0;
            double actual = ArrayCalculator.CalcAverage(array);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMin()
        {
            double[] array = { 92.1, 110.2, 1.42, 0.12 };
            double expected = 0.12;
            double actual = ArrayCalculator.CalcMin(array);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMax()
        {
            double[] array = { 92.1, 110.2, 1.42, 0.12, -234.1 };
            double expected = 110.2;
            double actual = ArrayCalculator.CalcMax(array);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PassEmptySum() // This method just returns 0 as expected
        {
            ArrayCalculator.CalcSum(emptyArray);
        }
        [TestMethod]
        public void PassEmptyAverage() // This test works, because the method returns NaN (0 divided by 0)
        {
            ArrayCalculator.CalcAverage(emptyArray);
        }
        [TestMethod]
        public void PassEmptyMin() // This test fails, because the method has no values to compare
        {
            ArrayCalculator.CalcMin(emptyArray);
        }
        [TestMethod]
        public void PassEmptyMax() // This test fails, because the method has no values to compare
        {
            ArrayCalculator.CalcMax(emptyArray);
        }
    }
}
