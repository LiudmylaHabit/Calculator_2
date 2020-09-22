using System;

namespace Calculator_2
{
    public class Calculation
    {
        public decimal Add(decimal firstNum, decimal secondNum)
        {
            return Math.Round(firstNum + secondNum, 4);
        }

        public decimal Substract(decimal firstNum, decimal secondNum)
        {
            return firstNum - secondNum;
        }

        public decimal Multiply(decimal firstNum, decimal secondNum)
        {
            return Math.Round(firstNum * secondNum, 4);
        }

        public decimal Divide(decimal firstNum, decimal secondNum)
        {
            decimal res = 0;
            try
            {
                if (secondNum == 0)
                {
                    throw new DivideByZeroException();
                }
                else
                {
                    res = firstNum / secondNum;
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Math.Round(res, 4);
        }

        public decimal OneDivision(decimal firstNum)
        {
            decimal res = 0;
            try
            {
                if (firstNum == 0)
                {
                    throw new DivideByZeroException();
                }
                else
                {
                    res = 1 / firstNum;
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Math.Round(res, 4);
        }

        public decimal SqrtOfNumber(decimal firstNum)
        {
            double result = 0;
            try
            {
                if (firstNum < 0)
                {
                    throw new Exception();
                }
                else
                {
                    result = Math.Sqrt(Convert.ToDouble(firstNum));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Number for sqrt should be a ppositive one!");
            }
            return Convert.ToDecimal(result);
        }

        public decimal DivisionReminder(decimal firstNum, decimal secondNum)
        {
            decimal result = firstNum % secondNum;
            return Convert.ToDecimal(Math.Round(result, 4));
        }

        public decimal PosDegreeOfNumber(decimal firstNum, decimal secondNum)
        {
            decimal result = 0;   
            if (secondNum == 0)
            {
                result = 1;
            }
            else if (secondNum == 1)
            {
                result = firstNum;
            }
            else
            {
                result = firstNum;
                for (int i = 1; i < secondNum; i++)
                {
                    result *= firstNum;
                }
            }
            return result;
        }

        public decimal Percent(decimal firstNum, decimal secondNum)
        {
            decimal result; 
            result = (firstNum / 100) * secondNum;
            return result;
        }
    }
}
