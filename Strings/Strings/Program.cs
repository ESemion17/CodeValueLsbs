using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plase enter any sentence, or empty to exit");
            var sentence = Console.ReadLine();
            if (sentence.Length == 0)
                return;
            while (sentence.Length != 0)
            {
                var words = sentence.Split(' ');
                Console.WriteLine($"Number of words {words.Length}");
                Array.Reverse(words);
                Console.WriteLine("Reverse order of your words is:");
                foreach (var word in words)
                    Console.Write(word + " ");
                Console.WriteLine("\nSorted order is:");
                Array.Sort(words);
                foreach (var word in words)
                    Console.Write(word + " ");
                Console.WriteLine("\nPlase enter any sentence, or empty to exit");
                sentence = Console.ReadLine();
            }
        }
    }
}
