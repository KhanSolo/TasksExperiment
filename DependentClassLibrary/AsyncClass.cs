using System;
using System.Threading.Tasks;

namespace DependentClassLibrary
{
    // Checking Lindhart.Analyser.MissingAwaitWarning work
    public class AsyncClass
    {
        public void Method()
        {
            SomeMethod();
        }

        private Task SomeMethod()
        {
            return Task.CompletedTask;
        }
    }
}
