using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number to convert to Binary format");
            var ans = Console.ReadLine();
            int num;
            while (!int.TryParse(ans, out num))
            {
                Console.WriteLine("It's wrong number format, try again");
                ans = Console.ReadLine();
            }
            MyBinaryDisplay binDisp = new MyBinaryDisplay(num);
            Console.WriteLine($"Binary fortam for {num} is {binDisp.ConvertToBinary()}");
            Console.WriteLine($"Number of \"1\"s is {num} is {binDisp.CountOnes()}");
            Console.Read();
        }
    }
}
