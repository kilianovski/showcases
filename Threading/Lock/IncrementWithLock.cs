using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lock
{
    public static class IncrementWithLock
    {
        private static readonly int IncrementIterations = 100_000;
        private static object syncObject = new object();
        public static string Counter = "0";

        public static void Increment()
        {
            for (int i = 0; i < IncrementIterations; i++)
            {
                // The emmited IL is equivalent to the try/finally construct
                lock (syncObject)
                {
                    int counter = Int32.Parse(Counter);
                    counter++;
                    Counter = counter.ToString();
                }

                //try
                //{
                //    Monitor.Enter(syncObject);
                //    Counter++;
                //}
                //finally
                //{
                //    Monitor.Exit(syncObject);
                //}
            }
        }

        public static void Go()
        {
            System.Console.WriteLine("IncrementWithLock");
            var task1 = Task.Factory.StartNew(Increment);
            var task2 = Task.Factory.StartNew(Increment);

            Task.WaitAll(task1, task2);

            System.Console.WriteLine($"Expected Counter={IncrementIterations*2}");
            System.Console.WriteLine($"Actual Counter={Counter}");
            System.Console.WriteLine();
        }
    }
}
