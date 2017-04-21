using System;

namespace GarbageCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CreateJunior("IDontUseGC");
            //System.GC.Collect(); // Without this we dont collect our Junior

            for (int i = 0; i < 99999; i++) { // GC has came here!!!
                new Junior(i.ToString());
            }

            Console.ReadKey();
        }

        static void CreateJunior(string name)
        {
            new Junior(name);           
        }
    }

    class Junior : System.Object
    {
        public string Name { get; set; }
        public Junior(string name)
        {
            Name = name;
            Console.WriteLine("I am hired!, {0}", Name);
        }
        ~Junior()
        {
            Console.WriteLine("I am fired =(, {0}", Name);
        }
    }
}