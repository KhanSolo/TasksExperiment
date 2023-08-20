using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Slices
{
    //[MemoryDiagnoser]
    public class Program
    {
        static async Task Main(string[] args)
        {
            var productName = "Marginalen Bankkort";
            const string pattern = "^(?!hygg|marflx).*";

            var isCardAccount = productName.IsCardAccount(pattern);

            Console.WriteLine(isCardAccount);
            //BenchmarkRunner.Run<Program>();
        }

        //[Benchmark]
        public DateTime Substring()
        {
            string ssn = "199103151234";

            var date = new DateTime(
                year: int.Parse(ssn.Substring(0, 4)),
                month: int.Parse(ssn.Substring(4, 2)),
                day: int.Parse(ssn.Substring(6, 2))
                );
            return date;
        }

        //[Benchmark]
        public DateTime Slices()
        {
            string ssn = "199103151234";
            ReadOnlySpan<char> span = ssn.AsSpan();
            var date = new DateTime(
                year: int.Parse(span.Slice(0, 4)),
                month: int.Parse(span.Slice(4, 2)),
                day: int.Parse(span.Slice(6, 2))
                );
            return date;
        }
    }

    public static class CommitmentExtensions
    {
        private const RegexOptions RegexpOptions = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;

        public static bool IsCardAccount(this string productName, string productIdFilter)
        {
            var lower = productName.ToLower();
            bool isCardAccount = Regex.IsMatch(lower, productIdFilter, RegexpOptions);
            return isCardAccount;
        }
    }
}
