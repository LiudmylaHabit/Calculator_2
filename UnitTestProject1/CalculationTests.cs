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
        public void DivisionOnOneChecking(decimal operand, decimal expectedResult)
        {
            decimal result = _calc.OneDivision(operand);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0, 10, 10)]
        [TestCase(0, -10, -10)]
        [TestCase(3.4, 2.265, 5.665)]
        public void AddChecking(decimal firstOperand, decimal secondOperand, decimal expectedResult)
        {
            decimal result = _calc.Add(firstOperand, secondOperand);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0, 10, -10)]
        [TestCase(0, -10, 10)]
        [TestCase(3.4002, 2.265, 1.1352)]
        public void SubstractChecking(decimal firstOperand, decimal secondOperand, decimal expectedResult)
        {
            decimal result = _calc.Substract(firstOperand, secondOperand);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0, 10, 0)]
        [TestCase(0, -10, 0)]
        [TestCase(3, -10, -30)]
        [TestCase(145, 0.5, 72.5)]
        public void MultiplyChecking(decimal firstOperand, decimal secondOperand, decimal expectedResult)
        {
            decimal result = _calc.Multiply(firstOperand, secondOperand);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(5, 10, 0.5)]
        [TestCase(0, 10, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(3.4, 0, 0)]
        public void DivisionChecking(decimal firstOperand, decimal secondOperand, decimal expectedResult)
        {
            decimal result = _calc.Divide(firstOperand, secondOperand);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(100, 3, 1)]
        [TestCase(100, 1, 0)]
        public void ReminderAfterDivisionChecking(decimal firstOperand, decimal secondOperand, decimal expectedResult)
        {
            decimal result = _calc.DivisionReminder(firstOperand, secondOperand);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(2, 0, 1)]
        [TestCase(15, 1, 15)]
        [TestCase(4, 3, 64)]
        [TestCase(1, 19, 1)]
        public void PosDegreeOfNumberChecking(decimal firstOperand, decimal secondOperand, decimal expectedResult)
        {
            decimal result = _calc.PosDegreeOfNumber(firstOperand, secondOperand);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(5, 100, 5)]
        [TestCase(20, 15, 3)]
        [TestCase(0.1, 1000, 1)]
        [TestCase(33, 100, 33)]
        public void PercentChecking(decimal firstOperand, decimal secondOperand, decimal expectedResult)
        {
            decimal result = _calc.Percent(firstOperand, secondOperand);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("2+6", 8, Description = "Check correctness of Polish Reader method")]
        [TestCase("0-2", -2)]
        [TestCase("5*0", 0)]
        [TestCase("6/2", 3)]
        [TestCase("1+(3-4)", 0)]
        [TestCase("2*(2+5)-3^2", 5)]
        [TestCase("3+4*2/(1-5)^2", 3.5)]
        public void PolishReaderCustomChecking(string expression, decimal expectedResult)
        {
            decimal result = _calc.PolishReader(expression);
            Assert.AreEqual(expectedResult, result);
        }

    }
}
