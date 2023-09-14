using System.Diagnostics;
using Xunit.Abstractions;

namespace UnitTests;

public class EnumerableUnitTests
{
    private ITestOutputHelper _output;

    public EnumerableUnitTests(ITestOutputHelper output) => _output = output;

    [Fact]
    public async Task TestAsyncEnumerator()
    {
        var inputs = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        {
            var sw = Stopwatch.StartNew();
            var ids = new List<string>();
            foreach (var input in inputs)
            {
                var s = await DoWorkAsync(input);
                ids.Add(s);
            }
            _output.WriteLine(ids.Count.ToString() + " " + sw.ElapsedMilliseconds.ToString());
        }
        _output.WriteLine("-----");
        {
            var sw = Stopwatch.StartNew();
            var tasks = inputs.Select(input => DoWorkAsync(input)).ToList();
            await Task.WhenAll(tasks);
            var ids = tasks.Select(t => t.Result).ToList();
            _output.WriteLine(ids.Count.ToString() + " " + sw.ElapsedMilliseconds.ToString());
        }
    }

    private async Task<string> DoWorkAsync(int w)
    {
        await Task.Delay(100);
        var result = w.ToString();
        _output.WriteLine($"{nameof(DoWorkAsync)} : {result}");
        return result;
    }
}