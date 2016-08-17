using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of $ signs");
            var ans = Console.ReadLine();
            int num;
            while (!int.TryParse(ans, out num))
            {
                Console.WriteLine("It's wrong number format, try again");
                ans = Console.ReadLine();
            }
            for (int i = 0; i <= num; i++)
            {
                for (int j = 0; j != i; j++)
                    Console.Write("$");
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
