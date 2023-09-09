// See https://aka.ms/new-console-template for more information


using Derived.Services;

Console.WriteLine("Hello, World!");

//var d = new DerivedClass();

//d.Handle("1");

//d.Show();
//d.Show();
//d.Show();

var aex = new AggregateException("level 1", new InvalidOperationException("level 2"));

var a = aex.Flatten();

Console.WriteLine(a);