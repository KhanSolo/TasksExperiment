using System.Linq;

namespace LinqExamples;

static class Program
{
    static void Main()
    {
        var data = ReadData();

        var grouped = data.GroupBy(x => x % 7)
            //.ToList()
            ;

        var first = grouped.First();
        var last = grouped.Last();
        Console.WriteLine($"{first.Key} {last.Key}");

        Console.WriteLine($"{first} {last}");
        var firstStr = GetStr();
        var lastStr = GetStr();
        Console.WriteLine($"{firstStr} {lastStr}");

        static string GetStr() => new Random().Next().ToString();
    }

    static IEnumerable<int> ReadData()
    {
        Random r = new(42);
        

        for (var i = 0; i < 10; i++)
        {
            var val = r.Next(30);
            Console.WriteLine("Loading val:" + val);
            yield return val;
        }
        Console.WriteLine("End of output" + Environment.NewLine);
    }
}