namespace Derived.Services;

internal sealed class DerivedClass : BaseClass<string>
{
    public void Show()
    {
        var interpolated = $"We got {ParamName} ";
        Log(interpolated);
    }

    private static void Log<T>(T msg)
    {
        Console.WriteLine(msg);
    }
}
