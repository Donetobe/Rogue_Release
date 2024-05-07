using System.Numerics;
using System.Security.Claims;

namespace Enum
{
    internal class Program
    {
        enum ovenTila
        {
            auki,
            kiinni,
            lukossa
        }

        

        static void Main(string[] args)
        {
            ovenTila nyt = ovenTila.lukossa;


            Console.WriteLine("Ovi on lukossa mitä haluat tehdä?");


            bool running;
            while (running = true)
            {

                while (true)
                {

    

                    string vastaus = Console.ReadLine();


                    if (nyt == ovenTila.lukossa && vastaus == "poista lukko")
                    {
                        nyt = ovenTila.kiinni;
                        Console.WriteLine("Ovi on kiinni mitä haluat tehdä?");
                        continue;
                    }

                    if (nyt == ovenTila.kiinni && vastaus == "avaa ovi")
                    {
                        nyt = ovenTila.auki;
                        Console.WriteLine("Ovi on auki mitä haluat tehdä?");
                        continue;
                    }

                    if (nyt == ovenTila.kiinni && vastaus == "lukitse ovi")
                    {
                        nyt = ovenTila.lukossa;
                        Console.WriteLine("Ovi on lukossa mitä haluat tehdä?");
                        continue;
                    }

                    if (nyt == ovenTila.auki && vastaus == "sulje ovi")
                    {
                        nyt = ovenTila.kiinni;
                        Console.WriteLine("Ovi on kiinni mitä haluat tehdä?");
                        continue;
                    }

                    if (vastaus == "riko ovi")
                    {
                        Environment.Exit(0);
                    }

                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Selvästi et tiedä miten ovet toimii, katso tämä video ennen kun yrität uudestaan: ");
                        Console.WriteLine("https://www.youtube.com/watch?v=Wof0xPUmW38");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                }
            }
        }
    }
}