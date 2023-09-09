using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Derived.Services;

internal abstract class BaseClass<T>
{
    protected string ParamName { get; init; } = typeof(T).Name;

    public void Handle(T param)
    {
        Console.WriteLine(param);
    }
}
