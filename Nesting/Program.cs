using System.Runtime.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var creatures = new Creatures(10);
        var creature = creatures[0];
        creature.X = 10;

        //var boxed = FormatterServices.GetUninitializedObject(typeof(void));
        //Console.WriteLine(boxed.GetType().FullName);
        string d = "";

        d = d + @"\";
        Console.Write(d);
    }
}

public class Creatures
{
    private readonly int size;
    private byte[] age;
    private int[] x, y;

    public Creatures(int size)
    {
        this.size = size;
        this.age = new byte[size];
        this.x = new int[size];
        this.y = new int[size];
    }

    public Creature this[int index] => new(this, index);

    public readonly struct Creature
    {
        private readonly Creatures creatures;
        private readonly int index;

        public Creature(Creatures creatures, int index)
        {
            this.creatures = creatures;
            this.index = index;
        }

        public ref byte Age => ref creatures.age[index];
        public ref int X => ref creatures.x[index];
        public ref int Y => ref creatures.y[index];
    }
}