using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork
{
    public class Starter
    {
        public void Run()
        {
            var mutex = new Mutex();
            var queue = new Queue<int>();
            var publisherOne = new Publisher(11, queue, mutex);
            var publisherTwo = new Publisher(22, queue, mutex);
            var subscriber = new Subscriber(queue);

            var writeTaskOne = Task.Run(() =>
            {
                while (true)
                {
                    publisherOne.Write();
                    Thread.Sleep(1000);
                }
            });
            var writeTaskTwo = Task.Run(() =>
            {
                while (true)
                {
                    publisherTwo.Write();
                    Thread.Sleep(1000);
                }
            });
            var readTask = Task.Run(() =>
            {
                while (true)
                {
                    subscriber.Read();
                    Thread.Sleep(200);
                }
            });

            var tasksList = new List<Task>();

            tasksList.Add(writeTaskOne);
            tasksList.Add(writeTaskTwo);
            tasksList.Add(readTask);

            Task.WaitAll(tasksList.ToArray());
        }
    }
}