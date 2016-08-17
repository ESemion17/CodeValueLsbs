using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = @"Names.txt";
            var names = new List<string>();
            using (var sr = new StreamReader(@"../" + filename))
            {
                string line;
                while ((line=sr.ReadLine())!=null)
                    names.Add(line);
            }
            Console.WriteLine("Names from given file");
            foreach (var name in names)
                Console.WriteLine(name);
        }
    }
}
