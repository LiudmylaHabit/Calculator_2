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
            Menu menu = new Menu();
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
                        firstOperand = menu.EnterNumber(message);
                        secondOperand = menu.EnterNumber(message);
                        sign = menu.EnterSign();
                        result = menu.GeneralOperations(ref excep, sign, firstOperand, secondOperand, calculate);
                        break;
                    case 2:
                        message = "What percentage? ";
                        firstOperand = menu.EnterNumber(message);
                        message = "of what? ";
                        secondOperand = menu.EnterNumber(message);
                        result = calculate.Percent(firstOperand, secondOperand); ;
                        break;
                    case 3:
                        message = "Please write divider\n";
                        firstOperand = menu.EnterNumber(message);
                        result = calculate.OneDivision(firstOperand);
                        if (firstOperand == 0) excep = true;
                        break;
                    case 4:
                        message = "Please write degree\n";
                        firstOperand = menu.EnterNumber("");
                        secondOperand = menu.EnterNumber(message);
                        result = calculate.PosDegreeOfNumber(firstOperand, secondOperand);
                        break;
                    case 5:
                        firstOperand = menu.EnterNumber(message);
                        if (firstOperand < 0) excep = true;
                        result = calculate.SqrtOfNumber(firstOperand);
                        break;
                    case 6:
                        message = "Please write divider\n";
                        firstOperand = menu.EnterNumber("");
                        secondOperand = menu.EnterNumber(message);
                        result = calculate.DivisionReminder(firstOperand, secondOperand);
                        break;
                    case 7:
                        string expr = menu.AskExpression();
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
            } while (options);//$
        }                
    }
}

