using Calculator_2;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class CalculationTests
    {
        Calculation _calc = new Calculation();

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(-1, -1)]
        [TestCase(1.25, 0.8)]
        [TestCase(3, 0.3333)]
        public void DivisionOnOneChecking(decimal a, decimal expectedResult)
        {
            decimal result = _calc.OneDivision(a);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0, 10, 10)]
        [TestCase(0, -10, -10)]
        [TestCase(3.4, 2.265, 5.665)]
        public void AddChecking(decimal a, decimal b, decimal expectedResult)
        {
            decimal result = _calc.Add(a, b);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0, 10, -10)]
        [TestCase(0, -10, 10)]
        [TestCase(3.4002, 2.265, 1.1352)]
        public void SubstractChecking(decimal a, decimal b, decimal expectedResult)
        {
            decimal result = _calc.Substract(a, b);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0, 10, 0)]
        [TestCase(0, -10, 0)]
        [TestCase(3, -10, -30)]
        [TestCase(145, 0.5, 72.5)]
        public void MultiplyChecking(decimal a, decimal b, decimal expectedResult)
        {
            decimal result = _calc.Multiply(a, b);
            Assert.AreEqual(expectedResult, result);
        }


        [TestCase(5, 10, 0.5)]
        [TestCase(0, 10, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(3.4, 0, 0)]
        public void DivisionChecking(decimal a, decimal b, decimal expectedResult)
        {
            decimal result = _calc.Divide(a, b);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(100, 3, 1)]
        [TestCase(100, 1, 0)]
        public void ReminderAfterDivisionChecking(decimal a, decimal b, decimal expectedResult)
        {
            decimal result = _calc.DivisionReminder(a, b);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
