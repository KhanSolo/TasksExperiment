using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace TasksExperiment
{
    //[MemoryDiagnoser]
    public class Program
    {
        static async Task Main(string[] args)
        {
            //BenchmarkRunner.Run<Program>();
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));
            var tasks = new List<Task>();

            for (var i = 0; i < 10; i++)
            {
                var num = i.ToString();
                var task = Task.Run(() => DoWaitAsync(num, cts.Token), cts.Token);
                //var task = DoWaitAsync(num, cts.Token);
                tasks.Add(task);
            }            
            
            await Task.WhenAll(tasks);

            Console.WriteLine("Completed");

            Console.WriteLine(string.Join("; ", tasks.Select(t => t.Status)));
        }

        static async Task DoWaitAsync(string num, CancellationToken token)
        {
            try
            {
                Console.WriteLine($"Start {num}");
                await Task.Delay(3000, token);                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
            }
            finally
            {
                Console.WriteLine($"Stop {num}");
            }
        }
    }

    class Stngs
    {
        public string Name { get; set; } = null!;
    }
}
