using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What’s your name ?");
            var name = Console.ReadLine();
            Console.WriteLine($"Hello {name}");
            string ans;
            int times;
            do
            {
                Console.WriteLine("Enter number 1-10");
                ans = Console.ReadLine();
            } while (!(int.TryParse(ans,out times)));
            for (int i = 0; i < times; i++)
            {
                for (int j = 0; j < i; j++)
                    Console.Write(" ");
                Console.WriteLine(name);
            }

            Console.ReadLine();
        }
    }
}
