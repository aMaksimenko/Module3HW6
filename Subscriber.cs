using System;
using System.Collections.Generic;

namespace HomeWork
{
    public class Subscriber
    {
        private readonly Queue<int> _queue;

        public Subscriber(Queue<int> queue)
        {
            _queue = queue;
        }

        public void Read()
        {
            if (_queue.Count > 0)
            {
                Console.Write("Current queue -> ");
                foreach (var item in _queue)
                {
                    Console.Write($"{item}, ");
                }

                Console.WriteLine();
                var res = _queue.Dequeue();
                Console.WriteLine($" << Was read out -> {res}");
            }
            else
            {
                Console.WriteLine($"Queue is empty");
            }
        }
    }
}