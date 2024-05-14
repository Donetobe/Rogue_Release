namespace Ruudukko
{
    internal class Program
    {
        public struct Cordinated
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            public Cordinated(int x, int y)
            {
                X = x;
                Y = y;
            }



            public void Check(int x, int y)
            {
                if (x == 0 && y == 0)
                {
                    Console.WriteLine($"{x}, {y} on 0, 0");
                }
                else if (MathF.Abs(x) <= 1 && MathF.Abs(y) <= 1)
                {
                    Console.WriteLine($"{x}, {y} on vieressä 0, 0");
                }
                else { Console.WriteLine($"{x}, {y} ei ole vieressä 0, 0"); }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Cordinated[] cords =
       {
            new Cordinated(-1, -1),
            new Cordinated(-1, 0),
            new Cordinated(-1, 1),
            new Cordinated(0, -1),
            new Cordinated(0, 0),
            new Cordinated(0, 1),
            new Cordinated(1, -1),
            new Cordinated(1, 0),
            new Cordinated(1, 1)
        };

            foreach (var c in cords)
            {
                c.Check(c.X, c.Y);
            }
        }
    }
}