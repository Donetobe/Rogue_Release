namespace Robotti
{
    internal class Program
    {
        public class Robotti
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool OnKäynnissä { get; set; }
            public IRobottiKäsky?[] Käskyt { get; } = new IRobottiKäsky?[3];

            public void Suorita()
            {
                foreach (IRobottiKäsky? käsky in Käskyt)
                {
                    käsky?.Suorita(this);
                    Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
                }
            }
        }

        public interface IRobottiKäsky
        {
            public abstract void Suorita(Robotti robotti);
        }

        public class Sammuta : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                robotti.OnKäynnissä = false;
            }
        }

        public class Käynnistä : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                robotti.OnKäynnissä = true;
            }
        }

        public class Alas : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                robotti.Y -= 1;
            }
        }

        public class Ylös : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                robotti.Y += 1;
            }
        }

        public class Oikealle : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                robotti.X += 1;
            }
        }

        public class Vasemmalle : IRobottiKäsky
        {
            public void Suorita(Robotti robotti)
            {
                robotti.X -= 1;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Robotti robotti = new Robotti();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Anna robotille käsky (sammuta, käynnistä, ylös, alas, oikealle, vasemmalle)");
                string vastaus = Console.ReadLine();

                switch (vastaus)
                {
                    case "sammuta":
                        robotti.Käskyt[i] = new Sammuta();
                        break;
                    case "käynnistä":
                        robotti.Käskyt[i] = new Käynnistä();
                        break;
                    case "ylös":
                        robotti.Käskyt[i] = new Ylös();
                        break;
                    case "alas":
                        robotti.Käskyt[i] = new Alas();
                        break;
                    case "oikealle":
                        robotti.Käskyt[i] = new Oikealle();
                        break;
                    case "vasemmalle":
                        robotti.Käskyt[i] = new Vasemmalle();
                        break;
                    default:
                        i--;
                        break;
                }
            }

            robotti.Suorita();
        }

    }
}