using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    public class LimitedQueue<T>
    {
        private Queue<T> _queue;
        private SemaphoreSlim _semaphoreSlim;
        private object _lockObj;
        public LimitedQueue(int maxSize)
        {
            _queue = new Queue<T>();
            _semaphoreSlim = new SemaphoreSlim(maxSize, maxSize);
            _lockObj = new object();

        }
        public void Enque(T item)
        {
            _semaphoreSlim.Wait();
            lock (_lockObj)
                _queue.Enqueue(item);
        }
        public T Deque()
        {
            _semaphoreSlim.Release();
            lock (_lockObj)
                return _queue.Dequeue();
        }
    }
}
