﻿using System;
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
                        a = EnterNumber(message);
                        b = EnterNumber(message);
                        sign = EnterSign();
                        result = GeneralOperations(ref excep, sign, a, b, calculate);
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
                        message = "Please write divider\n";
                        a = EnterNumber("");
                        b = EnterNumber(message);
                        result = calculate.DivisionReminder(a, b);
                        break;
                    case 7:
                        result = PolishReader();
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
                    Console.WriteLine("\n\nThe result is " + result);
                }
                Console.WriteLine("\n...press any key\n");
                Console.ReadKey();
                Console.WriteLine();
            } while (menu);//$
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

        public static decimal GeneralOperations(ref bool excep, string operation, decimal num2, decimal num1,  Calculation calc)
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

        public static decimal PolishReader()
        {
            Calculation calculation = new Calculation();
            string expression = "3+4*2/(1-5)^2";
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
                // if it is not a numeral check priority and than add it to stack or to polish form
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
                        res = GeneralOperations(ref flag, polishMass[i], nums[i - iter], nums[i - iter - 1], calculation);
                        nums.Remove(nums[i - iter]);
                        nums[i - iter - 1] = res;
                        iter += 2;
                    }
                    else if (polishMass[i] == "^")
                    {
                        res = calculation.PosDegreeOfNumber(nums[i - iter - 1], nums[i - iter]);
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

