using System;

namespace Threading
{
    //using custom monitor
    static class Program
    {
        private static void Main()
        {            
            object syncRoot = new();
            lock (syncRoot)
            {
                Console.WriteLine("Hello, World!");
            }
        }
    }
}

namespace System.Threading
{
    public static class Monitor
    {
        public static void Enter(object obj, ref bool isTaken)
        { 
            Console.WriteLine("Enter");
            isTaken = true;
        }

        public static void Exit(object obj)
        {
            Console.WriteLine("Exit");
        }
    }
}