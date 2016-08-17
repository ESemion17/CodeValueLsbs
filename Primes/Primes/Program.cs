using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        public static int[] CalcPrimes(int first, int last)
        {
            var prime = new List<int>();
            for (int i = first > 1 ? first : 2; i < last; i++)
                if (isPrime(i))
                    prime.Add(i);
            return prime.ToArray();
        }
        public static bool isPrime(int num)
        {
            var last = (int)Math.Sqrt(num)+1;
            for (int i = 2; i < last; i++)
                if (num % i == 0)
                    return false;
            return true;
        }
        static void Main(string[] args)
        {
            var listPrimes = CalcPrimes(1, 30);
            Console.WriteLine("All prime numbers " + 1 + " to " + 30);
            foreach (var item in listPrimes)
                Console.WriteLine(item);
        }
    }
}
