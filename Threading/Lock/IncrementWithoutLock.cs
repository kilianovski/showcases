using System.Threading.Tasks;

namespace Lock
{
    public static class IncrementWithoutLock
    {
        private static readonly int IncrementIterations = 100_000;
        public static int Counter { get; set; }

        public static void Increment()
        {
            for (int i = 0; i < IncrementIterations; i++)
            {
                Counter++;
            }
        }

        public static void Go()
        {
            System.Console.WriteLine("IncrementWithoutLock");
            var task1 = Task.Factory.StartNew(Increment);
            var task2 = Task.Factory.StartNew(Increment);

            Task.WaitAll(task1, task2);

            System.Console.WriteLine($"Expected Counter={IncrementIterations*2}");
            System.Console.WriteLine($"Actual Counter={Counter}");
            System.Console.WriteLine();
        }
    }
}
