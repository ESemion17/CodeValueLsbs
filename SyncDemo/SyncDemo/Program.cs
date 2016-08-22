using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var mutex = new Mutex(false))
            {
                for (int i = 0; i < 10000; i++)
                {
                    mutex.WaitOne();
                    Console.WriteLine("Locking mutex");
                    try
                    {
                        using (var sw = new StreamWriter(@"c:\temp\data.txt", true))
                            sw.WriteLine($"Process No. {Process.GetCurrentProcess().Id} is Writing");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                        Console.WriteLine("Unlocking mutex");
                    }

                }
            }
        }
    }
}
