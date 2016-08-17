using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length!=2)
            {
                Console.WriteLine("Wrong length of args, should be 2");
                return;
            }
            string[] dir;
            try
            {
                dir = Directory.GetFiles(args[1]);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong directory path");
                return;
            }
            // var fileList = new List<Tuple<string,long>>();
            //Tuple<string, long> tup;
            var fileDictionary = new Dictionary<string, long>();
            long fileLength;
            foreach (var file in dir)
                if ((fileLength = IsContain(args[0], file)) != -1)
                    fileDictionary.Add(file, fileLength);
            foreach (var item in fileDictionary)
            {
                Console.WriteLine($"File name: {item.Key} \t\t File length: {item.Value}");
            }
        }

        private static long IsContain(string str, string file)
        {
            using (var sr = new StreamReader(file))
            {
                var line="";
                long sum = 0;
                var flag = false;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    sum += line.Length;
                    if (line.IndexOf(str) != -1)
                        flag = true;
                }
                if (flag)
                    return sum;
            }
            return -1;
        }
    }
}
