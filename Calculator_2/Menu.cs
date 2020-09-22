using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_2
{
    public class Menu
    {
        public decimal EnterNumber(string message)
        {
            decimal number;
            do
            {
                if (message.Length > 1)
                {
                    Console.Write(message);
                }
                else
                {
                    Console.Write("Please, write number ");
                }
            } while (!decimal.TryParse(Console.ReadLine(), out number) || number.ToString().Trim().Length == 0);
            return number;
        }

        public string EnterSign()
        {
            string sign;
            do
            {
                Console.Write("Please, write sign of operation: ");
                Console.Write("Available operations '*' '+' '-' '/' ");
                sign = Console.ReadLine();
            } while (!(sign == "/" || sign == "+" || sign == "*" || sign == "-"));
            return sign;
        }

        public decimal GeneralOperations(ref bool excep, string operation, decimal num2, decimal num1, Calculation calc)
        {
            decimal res = 0;
            switch (operation)
            {
                case "/":
                    res = calc.Divide(num1, num2);
                    try
                    {
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        else
                        {
                            res = num1 / num2;
                        }
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "*":
                    res = calc.Multiply(num1, num2);
                    break;
                case "-":
                    res = calc.Substract(num1, num2);
                    break;
                case "+":
                    res = calc.Add(num1, num2);
                    break;
                default:
                    Console.WriteLine("You put wrong sign!");
                    res = 0;
                    break;
            }
            return res;
        }

        string EnterExpression()
        {

            bool flag = false;
            string expression;
            do
            {
                flag = false;
                Console.Write("Please, write an expression without any spaces: ");
                Console.Write("Available operations '*' '+' '-' '/' '(' ')' '^' ");
                expression = Console.ReadLine();
                char[] validSigns = new char[] { '+', '-', '*', '/', '(', ')', '^' };
                int sign = 0;
                for (int i = 0; i < expression.Trim().Length; i++)
                {
                    if (!decimal.TryParse(expression[i].ToString(), out decimal operand))
                    {
                        sign++;
                        bool mistake = true;
                        if (i != 0)
                        {
                            foreach (char item in validSigns)
                            {
                                if (item == expression[i])
                                {
                                    mistake = false;
                                    break;
                                }
                            }
                        }
                        if (sign >= 2)
                        {
                            if ((expression[i] != '(' && expression[i - 1] != ')' && sign >= 2))
                            {
                                mistake = true;
                            }
                        }
                        if (mistake || (i == expression.Trim().Length - 1 && expression[i] != ')'))
                        {
                            flag = true;
                            break;
                        }
                    }
                    else
                    {
                        sign = 0;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("You did a mistake in input! Please, try again!");
                }
            } while (expression.Trim().Length < 1 || flag);
            return expression;
        }

        public string AskExpression()
        {
            string choice = "";
            string result = "";
            do
            {
                Console.WriteLine("Please, enter '1' to calculate '3+4*2/(1-5)^2' expression");
                Console.WriteLine("Please, enter '2' to calculate custom expression");
                choice = Console.ReadLine();
            } while (choice != "1" && choice != "2");
            switch (choice)
            {
                case "1":
                    result = "3+4*2/(1-5)^2";
                    break;
                case "2":
                    result = EnterExpression();
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
