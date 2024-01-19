using System;
using System.Threading.Tasks;

namespace ConfigUtil
{
    public static class Program
    {
        public static async Task Main()
        {
            await DoSomething(1, async Task (n) => { await Task.Delay(n); });
            //await DoSomething(2, async (n) => { await Task.Delay(n); });
            //await DoSomething(3, async (n) => { await Task.Delay(n); });
        }

        private static async Task DoSomething(int num, Func<int, Task> func)
        {
            Log("Starting", num);
            await func(num);
            Log("Completing", num);
        }

        private static void Log(string action, int num)
        {
            Console.WriteLine($"{action} {num}, threadId {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}