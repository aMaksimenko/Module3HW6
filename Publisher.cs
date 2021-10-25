using System;
using System.Collections.Generic;
using System.Threading;

namespace HomeWork
{
    public class Publisher
    {
        private readonly int _id;
        private readonly Random _random;
        private readonly Mutex _mutex;
        private readonly Queue<int> _queue;

        public Publisher(int id, Queue<int> queue, Mutex mutex)
        {
            _id = id;
            _random = new Random();
            _mutex = mutex;
            _queue = queue;
        }

        public void Write()
        {
            _mutex.WaitOne();
            var nextVal = _random.Next(999);

            _queue.Enqueue(nextVal);
            Console.WriteLine($" >> Was added -> {nextVal} by ID #{_id}");
            _mutex.ReleaseMutex();
        }
    }
}