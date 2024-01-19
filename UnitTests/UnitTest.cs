using FluentAssertions;
using Xunit.Abstractions;

namespace UnitTests;

public class UnitTest
{
    private readonly ITestOutputHelper _output;

    public UnitTest(ITestOutputHelper testOutputHelper) => _output = testOutputHelper;

    enum SignableEntityType
    {
        None,
        Active,
        SuperActive,
        Passive,
        Aggressive,
    }

    [Fact]
    public void TestEnumHashSet()
    {
        var set = new HashSet<SignableEntityType>();

        if (DateTime.Now.Year > 2000)
        {
            set.Add(SignableEntityType.None);
            set.Add(SignableEntityType.None);
            set.Add(SignableEntityType.Active);
        }
        set.Add(SignableEntityType.None);
        set.Add(SignableEntityType.Aggressive);
        set.Add(SignableEntityType.Aggressive);

        set.Count.Should().Be(3);
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

    [Fact]
    public void EnumerateJaggedArray()
    {
        var jagged = new int[][]
        {
            new[] { 1, 2, },
            new[] { 3, 4, },
            new[] { 5, 6, 7, },
        };

        Array.ForEach(jagged, nested => Array.ForEach(nested, entry => _output.WriteLine(entry.ToString())));
    }

    [Fact]
    public void ClearArray()
    {
        var jagged = new int[][]
        {
            new[] { 1, 2, },
            new[] { 3, 4, },
            new[] { 5, 6, 7, },
        };

        Array.Clear(jagged, 1, 1);
        Array.ForEach(jagged, nested => { if (nested != null) Array.ForEach(nested, entry => _output.WriteLine(entry.ToString())); });
    }

    [Fact]
    public void TestHashSet()
    {
        var uniqArr = new[] { 1, 2, 3 };
        foreach (var item in uniqArr.ToHashSet())
        {
            _output.WriteLine(item.ToString());
        }
        _output.WriteLine(string.Empty);
        var repeatable = new[] { 1, 2, 2, 2, 3, 3, 4 };
        foreach (var item in repeatable.ToHashSet())
        {
            _output.WriteLine(item.ToString());
        }
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
        _output.WriteLine($"{request} was processed. Payload is {payload}");
    }
}

record SignableEntity(Guid Id, string Payload);