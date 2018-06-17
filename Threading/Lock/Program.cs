using System;

namespace Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            IncrementWithoutLock.Go();
            IncrementWithLock.Go();

            Go();
        }


        static readonly object _locker = new object();

        static void Go()
        {
            lock (_locker)
            {
                AnotherMethod();
                // We still have the lock - because locks are reentrant.
            }
        }

        static void AnotherMethod()
        {
            lock (_locker) { Console.WriteLine("Another method"); }
        }
    }

}
