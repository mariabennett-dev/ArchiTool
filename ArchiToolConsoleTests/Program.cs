using System;
using ArchiTool.ArchiToolLogic.Models;

namespace ArchiToolConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Calculator calc = new Calculator();
            Number number1 = new Number(6);
            Number number2 = new Number(6, 6);
            Number number3 = new Number(6, 2.125m);
            Number number4 = new Number(6.1770833m);
            Number number1a = new Number(5, 12);
            Number number2a = new Number(6.5m);
            Number number3a = new Number(6, 2, .125m);
            Number number4a = new Number(6, 2, 1, 8);

            calc.NumberButton("1");
            calc.NumberButton("4");
            calc.Add();
            calc.NumberButton("2");
            calc.Equals();

            Console.WriteLine( $"{calc.Number1.Value} + {calc.Number2.Value} = {calc.Answer.Value}");
            Console.WriteLine($"{calc.NumberString}");
            Console.WriteLine($"{calc.DisplayEquation}");

            /*calc.Clear();
            calc.NumberButton(5);
            calc.Subtract();
            calc.NumberButton(6);
            calc.Equals();

            Console.WriteLine($"{calc.Number1.Value} - {calc.Number2.Value} = {calc.Answer.Value}");

            calc.Clear();
            calc.NumberButton(1);
            calc.NumberButton(0);
            calc.Multiply();
            calc.NumberButton(2);
            calc.Equals();

            Console.WriteLine($"{calc.Number1.Value} * {calc.Number2.Value} = {calc.Answer.Value}");

            calc.Clear();
            calc.NumberButton(5);
            calc.NumberButton(0);
            calc.Divide();
            calc.NumberButton(1);
            calc.NumberButton(2);
            calc.Decimal();
            calc.NumberButton(5);
            calc.Equals();

            Console.WriteLine($"{calc.Number1.Value} / {calc.Number2.Value} = {calc.Answer.Value}");

            calc.Clear();
            calc.NumberButton(10);
            calc.Decimal();
            calc.NumberButton(5);
            calc.Add();
            calc.NumberButton(1);
            calc.NumberButton(2);
            calc.Decimal();
            calc.NumberButton(5);
            calc.Equals();

            Console.WriteLine($"{calc.Number1.Value} + {calc.Number2.Value} = {calc.Answer.Value}");

            calc.Clear();
            calc.NumberButton(5);
            calc.Equals();

            Console.WriteLine($"{calc.Number1.Value} + {calc.Number2.Value} = {calc.Answer.Value}");
            
            calc.Clear();
            calc.NumberButton(9);
            calc.MixedNumber();
            calc.NumberButton(3);
            calc.Fraction();    
            calc.NumberButton(4);
            calc.Add();
            calc.NumberButton(1);
            calc.Fraction();
            calc.NumberButton(4);
            calc.Equals();
            

            Console.WriteLine($"{calc.Number1.Value} + {calc.Number2.Value} = {calc.Answer.Value}");
            Console.WriteLine($"{calc.Answer.ToFeetInchesString()}");

            calc.Clear();
            calc.NumberButton(9);
            calc.Ft();
            calc.NumberButton(8);
            calc.MixedNumber();
            calc.NumberButton(3);
            calc.Fraction();
            calc.NumberButton(4);
            calc.In();
            calc.Add();
            calc.NumberButton(1);
            calc.NumberButton(0);
            calc.Decimal();
            calc.NumberButton(5);
            calc.Ft();
            calc.NumberButton(8);
            calc.MixedNumber();
            calc.NumberButton(1);
            calc.Fraction();
            calc.NumberButton(4);
            calc.In();
            calc.Equals();

            Console.WriteLine($"{calc.Number1.Value} + {calc.Number2.Value} = {calc.Answer.Value}");
            Console.WriteLine($"{calc.Answer.ToFeetInchesString()}");

            calc.Clear();
            calc.NumberButton(9);
            calc.MixedNumber();
            calc.NumberButton(1);
            calc.Fraction();
            calc.NumberButton(5);
            calc.In();
            calc.Add();
            calc.NumberButton(1);
            calc.NumberButton(0);
            calc.Decimal();
            calc.NumberButton(5);
            calc.Ft();
            calc.NumberButton(8);
            calc.MixedNumber();
            calc.NumberButton(1);
            calc.Fraction();
            calc.NumberButton(4);
            calc.In();
            calc.Equals();

            Console.WriteLine($"{calc.Number1.Value} + {calc.Number2.Value} = {calc.Answer.Value}");
            Console.WriteLine($"{calc.Answer.ToFeetInchesString()}");

            /*Console.WriteLine($"Number 1 is {number1.ToFeetInchesString()}");
            Console.WriteLine($"Number 2 is {number2.ToFeetInchesString()}");
            Console.WriteLine($"Number 3 is {number3.ToFeetInchesString()}");
            Console.WriteLine($"Number 4 is {number4.ToFeetInchesString()}");
            Console.WriteLine($"Number 1a is {number1a.ToFeetInchesString()}");
            Console.WriteLine($"Number 2a is {number2a.ToFeetInchesString()}");
            Console.WriteLine($"Number 3a is {number3a.ToFeetInchesString()}");
            Console.WriteLine($"Number 4a is {number4a.ToFeetInchesString()}");

            Console.WriteLine($"Number 1 is {number1.ToDecimalFeetString()}");
            Console.WriteLine($"Number 2 is {number2.ToDecimalFeetString()}");
            Console.WriteLine($"Number 3 is {number3.ToDecimalFeetString()}");
            Console.WriteLine($"Number 4 is {number4.ToDecimalFeetString()}");
            Console.WriteLine($"Number 1a is {number1a.ToDecimalFeetString()}");
            Console.WriteLine($"Number 2a is {number2a.ToDecimalFeetString()}");
            Console.WriteLine($"Number 3a is {number3a.ToDecimalFeetString()}");
            Console.WriteLine($"Number 4a is {number4a.ToDecimalFeetString()}");

            Console.WriteLine($"Number 1 is {number1.ToDecimalInchesString()}");
            Console.WriteLine($"Number 2 is {number2.ToDecimalInchesString()}");
            Console.WriteLine($"Number 3 is {number3.ToDecimalInchesString()}");
            Console.WriteLine($"Number 4 is {number4.ToDecimalInchesString()}");
            Console.WriteLine($"Number 1a is {number1a.ToDecimalInchesString()}");
            Console.WriteLine($"Number 2a is {number2a.ToDecimalInchesString()}");
            Console.WriteLine($"Number 3a is {number3a.ToDecimalInchesString()}");
            Console.WriteLine($"Number 4a is {number4a.ToDecimalInchesString()}");

            Console.WriteLine($"Number 1 is {number1.ToInchesString()}");
            Console.WriteLine($"Number 2 is {number2.ToInchesString()}");
            Console.WriteLine($"Number 3 is {number3.ToInchesString()}");
            Console.WriteLine($"Number 4 is {number4.ToInchesString()}");
            Console.WriteLine($"Number 1a is {number1a.ToInchesString()}");
            Console.WriteLine($"Number 2a is {number2a.ToInchesString()}");
            Console.WriteLine($"Number 3a is {number3a.ToInchesString()}");
            Console.WriteLine($"Number 4a is {number4a.ToInchesString()}");*/
        }
    }
}
