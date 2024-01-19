namespace Iterators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var i in Fib())
            {
                if (i > 100) break;
                Console.WriteLine(i);
            }
        }

        public static IEnumerable<int> Fib()
        {
            Console.WriteLine("Enter");
            int prev = 0, next = 1;
            yield return prev;
            yield return next;

            while (true)
            {
                int sum = prev + next;
                yield return sum;
                prev = next;
                next = sum;
            }
        }
    }
}