using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            var limitedQueue = new LimitedQueue<int>(3);
            var taskList = new List<Task>();
            for (int i = 0; i < 20; i++)
            {
                var task = Task.Run(() => TestingLimitedQueue(limitedQueue));
                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray());
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }

        public static void TestingLimitedQueue(LimitedQueue<int> queue)
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Thread No. {id} is going to do enque");
            queue.Enque(id);
            Console.WriteLine($"Thread No. {id} was enqueed");
            var timeToSleep = new Random((new Guid()).GetHashCode()).Next(3, 7);
            Thread.Sleep(1000 * (timeToSleep + 2));
            Console.WriteLine($"Thread No. {queue.Deque()} was Dequed");
        }
    }
}
