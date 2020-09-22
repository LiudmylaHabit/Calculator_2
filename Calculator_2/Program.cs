using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculator_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculation calculate = new Calculation();
            int operation;
            bool menu = true;
            decimal result = 0;
            decimal a, b;
            string message = "";
            do
            {
                bool excep = false;
                do
                {
                    Console.WriteLine("Operations: \n1. General operations (+, -, *, /).)");
                    Console.WriteLine("2. Percentage of the number ");
                    Console.WriteLine("3.'1/x'");
                    Console.WriteLine("4. Positive degree of number");
                    Console.WriteLine("5. Sqrt of number");
                    Console.WriteLine("6. Reminder after division");
                    Console.WriteLine("7. Polish dich");
                    Console.WriteLine("8. Exit");
                } while (!int.TryParse(Console.ReadLine(), out operation) || operation < 1 || operation > 8);
                switch (operation)
                {
                    case 1:
                        a = EnterNumber(message);
                        b = EnterNumber(message);
                        result = GeneralOperations(ref excep, a, b, calculate);
                        break;
                    case 2:
                        message = "What percentage? ";
                        a = EnterNumber(message);
                        message = "of what? ";
                        b = EnterNumber(message);
                        result = calculate.Percent(a, b); ;
                        break;
                    case 3:
                        message = "Please write divider\n";
                        a = EnterNumber(message);
                        result = calculate.OneDivision(a);
                        if (a == 0) excep = true;
                        break;
                    case 4:
                        message = "Please write degree\n";
                        a = EnterNumber("");
                        b = EnterNumber(message);
                        result = calculate.PosDegreeOfNumber(a, b);
                        break;
                    case 5:
                        a = EnterNumber(message);
                        if (a < 0) excep = true;
                        result = calculate.SqrtOfNumber(a);
                        break;
                    case 6:
                        message = "Please write divider ";
                        a = EnterNumber("");
                        b = EnterNumber(message);
                        result = calculate.DivisionReminder(a, b);
                        break;
                    case 7:
                        //result = PolishReader();
                        break;
                    case 8:
                        menu = false;
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
                    Console.WriteLine("\nThe result is " + result);
                }
                Console.WriteLine("...press any key\n");
                Console.ReadKey();
            } while (menu);
            Console.ReadKey();//$
        }        

        public static decimal EnterNumber(string message)
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

        public static string EnterSign()
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

        public static decimal GeneralOperations(ref bool excep, decimal num1, decimal num2, Calculation calc)
        {
            decimal res = 0;
            string operation;
            operation = EnterSign();
            switch (operation)
            {
                case "/":
                    res = calc.Divide(num1, num2);
                    try
                    {
                        if (num2 == 0)
                        {
                            excep = true;
                            throw new DivideByZeroException();
                        }
                        else
                        {
                            res = calc.Divide(num1, num2);
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

        public static decimal GeneralOperations(string operation, decimal num2, decimal num1,  Calculation calc)
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

        public static void PolishReader()
        {
            Calculation calculation = new Calculation();
            string expressioon = "3+4*2/(1-5)+2";
            char[] charsMass = expressioon.ToCharArray();
            Stack<char> operationSigns = new Stack<char>();
            List<char> polishMass = new List<char>();
            Stack<char> polishStack = new Stack<char>();
            Dictionary<char, int> prioritets = new Dictionary<char, int>()
            {
                { '(', 0},
                { ')', 1},
                { '+', 2},
                {'-', 2},
                {'*', 3},
                {'/', 3},
                {'^', 4},
            };
        }

            //static decimal PosDegreeOfNumber()
            //{
            //    decimal result;
            //    decimal num1, num2;
            //    Console.WriteLine("Firstly write degree");
            //    num1 = EnterNumber("");
            //    num2 = EnterNumber("");
            //    result = num2;
            //    if (num1 == 0)
            //    {
            //        result = 1;
            //    }
            //    else if (num1 == 1)
            //    {
            //        result = num2;
            //    }
            //    else
            //    {
            //        for (int i = 1; i < num1; i++)
            //        {
            //            result *= num2;
            //        }
            //    }
            //    return result;
            //}
        }
}

