using System;
using System.Collections.Generic;

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

        public decimal PolishReader(string expression)
        {
            Menu menu = new Menu();
            Console.WriteLine("\nMath expression: \n" + expression);
            char[] charsMass = expression.ToCharArray();
            List<string> stringMass = new List<string>();
            // Creating array af strings to convinience use of expression
            foreach (char item in charsMass)
            {
                stringMass.Add(Char.ToString(item));
            }
            Stack<string> operationSigns = new Stack<string>();
            List<string> polishMass = new List<string>();
            List<decimal> nums = new List<decimal>();
            Dictionary<string, int> prioritets = new Dictionary<string, int>()
            {
                { "(", 0},
                { ")", 1},
                { "+", 2},
                {"-", 2},
                {"*", 3},
                {"/", 3},
                {"^", 4},
            };
            for (int i = 0; i < stringMass.Count; i++)
            {
                // if it is numeral add it to polish form
                if (decimal.TryParse(stringMass[i].ToString(), out decimal num))
                {
                    polishMass.Add(num.ToString());
                    nums.Add(num);
                }
                // if it is not firstOperand numeral check priority and than add it to stack or to polish form
                else
                {
                    if (prioritets.ContainsKey(stringMass[i]))
                    {
                        int prior = prioritets[stringMass[i]];
                        if (operationSigns.Count == 0 || stringMass[i] == "(")
                        {
                            operationSigns.Push(stringMass[i]);
                        }
                        else
                        {
                            int priorInStack = prioritets[operationSigns.Peek()];
                            if (prior == 1)
                            {
                                while (operationSigns.Peek() != "(")
                                {
                                    polishMass.Add(operationSigns.Pop());
                                }
                                operationSigns.Pop();
                            }
                            else if (prior <= priorInStack)
                            {
                                polishMass.Add(operationSigns.Pop());
                                operationSigns.Push(stringMass[i]);
                            }
                            else if (prior > priorInStack)
                            {
                                operationSigns.Push(stringMass[i]);
                            }
                            else if (prior < priorInStack)
                            {
                                operationSigns.Push(stringMass[i]);
                            }
                        }
                    }
                }
                // if expression end but stack still have some operands - add them to polish form
                if (i == stringMass.Count - 1)
                {
                    while (operationSigns.Count > 0)
                    {
                        polishMass.Add(operationSigns.Pop());
                    }
                }
            }
            Console.WriteLine("\nPolish form of expression:");
            foreach (var item in polishMass)
            {
                Console.Write(item + " ");
            }
            int iter = 1;
            bool flag = false;
            for (int i = 0; i < polishMass.Count; i++)
            {
                if (int.TryParse(polishMass[i], out int num))
                {
                    continue;
                }
                else
                {
                    decimal res = 0;
                    if (polishMass[i] != "^")
                    {
                        res = menu.GeneralOperations(ref flag, polishMass[i], nums[i - iter], nums[i - iter - 1], new Calculation());
                        nums.Remove(nums[i - iter]);
                        nums[i - iter - 1] = res;
                        iter += 2;
                    }
                    else if (polishMass[i] == "^")
                    {
                        res = PosDegreeOfNumber(nums[i - iter - 1], nums[i - iter]);
                        nums.Remove(nums[i - iter]);
                        nums[i - iter - 1] = res;
                        iter += 2;
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("Your expression has mistake!");
            }
            return nums[0];
        }
    }
}
