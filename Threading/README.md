## OS exam questions:

1. Critical sections. Implementation.

   Parts of the program where the shared resource is accessed are protected. This protected section is the **critical section** or **critical region.** It cannot be executed by more than one process at a time. Typically, the critical section accesses a shared resource, such as a [data structure](https://en.wikipedia.org/wiki/Data_structure), a peripheral device, or a network connection, that would not operate correctly in the context of multiple concurrent accesses.

   The simplest method to prevent any change of processor control inside the critical section is implementing a semaphore.

2. Semaphores. Critical section with semaphore.

   Semaphore is simply a variable. This variable is used to solve critical section problems and to achieve process synchronization in the multi processing environment. 

   Semaphores which allow an arbitrary resource count are called **counting semaphores**, while semaphores which are restricted to the values 0 and 1 (or locked/unlocked, unavailable/available) are called **binary semaphores** and are used to implement [locks](https://en.wikipedia.org/wiki/Lock_(computer_science)). 



# Synchronization:

## 1. Locking constructs:

### Exclusive locking constructs:

#### 1. lock (Monitor.Enter/Monitor.Exit)
``` csharp
public static class IncrementWithLock
    {
        private static readonly int IncrementIterations = 100_000;
        private static object syncObject = new object(); 
        public static int Counter { get; set; }

        public static void Increment()
        {
            for (int i = 0; i < IncrementIterations; i++)
            {
                // The emmited IL is equivalent to the try/finally construct
                //lock(syncObject)
                //{
                //    Counter++;
                //}

                try
                {
                    Monitor.Enter(syncObject);
                    Counter++;
                }
                finally
                {
                    Monitor.Exit(syncObject);
                }
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
```
Lock reentrancy ( Реентерабельность )
``` charp 
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
```
2. Mutex
3. SpinLock

Nonexclusive locking constructs:

1. Semaphore
2. SemaphoreSlim
3. reader/writer locks

#### 3. Signaling constructs

1. event wait handles
2. Monitor's Wait/Pulse
3. CountdownEvent
4. Barrier

#### 4. Nonblocking synchronization constructs

1. Thread.MemoryBarrier
2. Thread.VolatileRead
3. Thread.VolatileWrite
4. `volatile` 
5. Interlocked

