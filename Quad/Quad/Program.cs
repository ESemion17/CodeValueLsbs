using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 number as coefficient to quadratic equation");
            var ans = Console.ReadLine();
            var tmp = ans.Split(' ');
            var coeff = new double[3];
            while ((tmp.Length != 3) || (!double.TryParse(tmp[0], out coeff[0])) || (!double.TryParse(tmp[1], out coeff[1])) || (!double.TryParse(tmp[2], out coeff[2])))
            {
                Console.WriteLine("wrong input, try again");
                ans = Console.ReadLine();
                tmp = ans.Split(' ');
            }
            MyQuad quad = new MyQuad(coeff);
            var root=quad.Solve();
            if (root.Count == 0)
                Console.WriteLine($"The equation ({quad}) don't have roots");
            else
            if (root.Count == 1)
                Console.WriteLine($"The equation ({quad}) has one root:\t{root[0]}");
            else
                Console.WriteLine($"The equation ({quad}) has two roots:\n1.\t{root[0]}\n2.\t{root[1]}");
            Console.Read();
        }
    }
}
