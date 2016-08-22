using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            exexercise1a();
            var processes = Process.GetProcesses().Where(p => p.Threads.Count < 5).OrderBy(p => p.Id);
            exexercise1b(processes);
            exexercise1c(processes);
            exexercise1d();


            Console.ReadKey();
        }

        private static void exexercise1a()
        {
            Console.WriteLine("All public interface in 'mscorlib':");
            var types = Assembly.Load("mscorlib").GetTypes().Where(t => t.IsInterface).Where(t => t.IsPublic)
                .OrderBy(t => t.Name).Select(t => new { Name = t.Name, NumberOfMethods = t.GetMethods().Length });
            foreach (var item in types)
                Console.WriteLine("Number Of Methods: {0,-4} Interface name:{1}", item.NumberOfMethods,item.Name);
        }
        private static void exexercise1b(IOrderedEnumerable<Process> process)
        {
            Console.WriteLine("All processes that running whose thread count is less than 5 ");
            var processes = process.Select(p => new { Name = p.ProcessName, Id = p.Id, StartTime = GetStartTimeFromProcess(p) });
            foreach (var item in processes)
                Console.WriteLine($"Id: {item.Id,-6} Process Name: {item.Name,-30} Start Date: {item.StartTime.ToString()}");
        }
        private static string GetStartTimeFromProcess(Process process)
        {
            try
            {
                return process.StartTime.ToString();
            }
            catch (Exception)
            {
                return "Can't get start time";
            }
        }
        private static void exexercise1c(IOrderedEnumerable<Process> process)
        {
            Console.WriteLine("All processes that running whose thread count is less than 5 and grouping by base priority");
            var processes = process.GroupBy(p => p.BasePriority).
                Select(p => new { Key = p.Key, Amount = p.Count() });
            foreach (var item in processes)
                Console.WriteLine($"Key: {item.Key,-15} Number of Processes {item.Amount}");
        }
        private static void exexercise1d()
        {
            Console.WriteLine($"Total number of thread in the system: {Process.GetProcesses().Aggregate<Process, int>(0, (sum, p) => sum + p.Threads.Count)}");
        }
    }
    public static class Utility
    {
        public static void CopyTo (this object obj1, object obj2)
        {
            foreach (var property in obj1.GetType().GetProperties().Where(p => p.CanRead))
                if (obj2.GetType().GetProperty(property.Name).CanWrite)
                    obj2.GetType().GetProperty(property.Name).SetValue(obj2, obj1.GetType().GetProperty(property.Name).GetValue(obj1));
        }
    }
}
