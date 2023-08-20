namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test2()
        {
            var collection = new[] { 1, 2, 3, 4 };
            var contains = new[] { 1, 2, 3, 4};            
            
            Assert.All(collection, x => x.Equals(1));       // wrong usage      
            Assert.All(collection, x => Assert.Contains(x, contains)); // proper usage
        }
    }
}