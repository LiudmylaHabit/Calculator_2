using System;

namespace Calculator_2
{
    public class Menu
    {
        public void CalculatorMenu()
        {
            Calculation calculate = new Calculation();
            int operation;
            bool options = true;
            decimal result = 0;
            decimal firstOperand, secondOperand;
            string sign;
            string message = "";
            do
            {
                bool excep = false;
                do
                {
                    Console.WriteLine("Operations:");
                    Console.WriteLine("1. General operations (+, -, *, /).)");
                    Console.WriteLine("2. Percentage of the number ");
                    Console.WriteLine("3.'1/x'");
                    Console.WriteLine("4. Positive degree of number");
                    Console.WriteLine("5. Sqrt of number");
                    Console.WriteLine("6. Reminder after division");
                    Console.WriteLine("7. Polish reader");
                    Console.WriteLine("8. Exit");
                } while (!int.TryParse(Console.ReadLine(), out operation) || operation < 1 || operation > 8);
                switch (operation)
                {
                    case 1:
                        result = GeneralOperations(ref excep, EnterSign(), EnterNumber(message), EnterNumber(message), calculate);
                        break;
                    case 2:
                        firstOperand = EnterNumber("What percentage? ");
                        secondOperand = EnterNumber("of what? ");
                        result = calculate.Percent(firstOperand, secondOperand); ;
                        break;
                    case 3:
                        firstOperand = EnterNumber("Please write divider\n");
                        result = calculate.OneDivision(firstOperand);
                        if (firstOperand == 0) excep = true;
                        break;
                    case 4:
                        firstOperand = EnterNumber("");
                        secondOperand = EnterNumber("Please write degree\n");
                        result = calculate.PosDegreeOfNumber(firstOperand, secondOperand);
                        break;
                    case 5:
                        firstOperand = EnterNumber(message);
                        if (firstOperand < 0) excep = true;
                        result = calculate.SqrtOfNumber(firstOperand);
                        break;
                    case 6:
                        firstOperand = EnterNumber("");
                        secondOperand = EnterNumber("Please write divider\n");
                        result = calculate.DivisionReminder(firstOperand, secondOperand);
                        break;
                    case 7:
                        string expr = AskExpression();
                        result = calculate.PolishReader(expr);
                        break;
                    case 8:
                        options = false;
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                if (excep)
                {
                    Console.WriteLine("\nTry again!");
                }
                else
                {
                    Console.WriteLine("\n\nThe result is " + result);
                }
                Console.WriteLine("\n...press any key\n");
                Console.ReadKey();
                Console.WriteLine();
            } while (options);
        }

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
