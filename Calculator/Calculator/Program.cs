using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string ans;
            double num1, num2;
            string[] tmp;

            do
            {
                Console.WriteLine("Enter two double number");
                ans = Console.ReadLine();
                tmp = ans.Split(' ');

            } while ((tmp.Length != 2) || (!double.TryParse(tmp[0], out num1)) || (!double.TryParse(tmp[1], out num2)));

            MyCalculator mycalc = new MyCalculator(num1, num2);

            do
            {
                Console.WriteLine("Enter only one operator(+,-,*,/)");
                ans = Console.ReadLine();
            } while (ans.Length != 1 || !(ans[0] == '+' || ans[0] == '-' || ans[0] == '*' || ans[0] == '/'));
            double res;
            switch (ans[0])
            {
                case '+':
                    try
                    {
                        res = mycalc.Add();
                        Console.WriteLine(res);
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case '-':
                    try
                    {
                        res = mycalc.Substract();
                        Console.WriteLine(res);
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case '*':
                    try
                    {
                        res = mycalc.Mult();
                        Console.WriteLine(res);
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case '/':
                    try
                    {
                        res = mycalc.Divide();
                        Console.WriteLine(res);
                    }
                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
        }
    }
}
