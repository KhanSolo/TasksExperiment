using FluentAssertions;
using Xunit.Abstractions;

namespace UnitTests;

public sealed class StringUnitTests
{
    private ITestOutputHelper _output;

    public StringUnitTests(ITestOutputHelper output) => _output = output;

    [Fact]
    public void TestJoin()
    {
        var signableEntities = Enumerable.Range(0,10)
            .Select(i => new SignableEntity(new(), default))
            .ToList();

        var exists = signableEntities.Select(e => e.Payload).ToList();

        var str = string.Join(", ", exists);

        _output.WriteLine("Result:" + str);
    }
    
    [Fact]
    public void TestJoinEmptyList()
    {
        var signableEntities = Enumerable.Range(0,10)
            .Select(i => new SignableEntity(new(), default))
            .ToList();

        var exists = signableEntities.Select(e => e.Payload).Where(p=>p != null).ToList();

        var str = string.Join(", ", exists);

        _output.WriteLine("Result:(" + str + ')');
    }

    [Fact]
    public void TestRoundInt()
    {
        var r = 5 / 10;
        _output.WriteLine(r.ToString());

        decimal gradePointAverage = 3.99872831m;
        _output.WriteLine(((int)gradePointAverage).ToString());
    }

}
