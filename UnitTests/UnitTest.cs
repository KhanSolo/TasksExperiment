using FluentAssertions;
using Xunit.Abstractions;

namespace UnitTests;

public class UnitTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void TestContains()
    {
        var collection = new[] { 1, 2, 3, 4 };
        var contains = new[] { 1, 2, 3, 4};            
        
        Assert.All(collection, x => x.Equals(1));       // wrong usage - not throwing an exception
        Assert.All(collection, x => Assert.Contains(x, contains)); // proper usage
    }

    [Fact]
    public void TestNulls_NewMethod()
    {
        var request = new SignableEntity(Guid.NewGuid(), "non null");
        NewMethod(request);
    }

    private void NewMethod(SignableEntity request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));
        DoProcessing(request, request.Payload);
    }

    [Fact]
    public void TestNulls_EnhancedMethod()
    {
        var request = new SignableEntity(Guid.NewGuid(), "non null");
        EnhancedMethod(request);

        var ex = Assert.Throws<ArgumentNullException>(() => EnhancedMethod(default));
        ex.Message.Should().Be("Value cannot be null. (Parameter 'request')");
    }

    private void EnhancedMethod(SignableEntity request)
        =>
            DoProcessing(Validate(request), request.Payload);    

    private static SignableEntity Validate(SignableEntity request)
    {
        return request is not null ? request : throw new ArgumentNullException(nameof(request));
    }

    private void DoProcessing(SignableEntity request, string payload)
    {
        _testOutputHelper.WriteLine($"{request} was processed. Payload is {payload}");
    }
}

record SignableEntity(Guid Id, string Payload);