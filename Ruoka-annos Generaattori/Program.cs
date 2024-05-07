namespace Ruoka_annos_Generaattori
{
    internal class Program
    {

        enum pääraakaAine
        {
            nautaa, kanaa, kasviksia
        }

        enum lisuke
        {
            perunaa, riisiä, pastaa
        }

        enum kastike
        {
            curry, hapanimelä, pippuri, chili
        }

        
        static void Main(string[] args)
        {
            (pääraakaAine, lisuke, kastike) ruoka;

            while (true)
            {
                Console.WriteLine("Pääraaka-aine: (nautaa, kanaa, kasviksia): ");
                string vastaus = Console.ReadLine();
                if (vastaus == "nautaa")
                {
                    ruoka.Item1 = pääraakaAine.nautaa;
                    break;
                }
                if (vastaus == "kanaa")
                {
                    ruoka.Item1 = pääraakaAine.kanaa;
                    break;
                }
                if (vastaus == "kasviksia")
                {
                    ruoka.Item1 = pääraakaAine.kasviksia;
                    break;
                }
                else
                {
                    continue;
                }
            }

            while (true)
            {
                Console.WriteLine("Lisuke: (perunaa, riisiä, pastaa): ");
                string vastaus = Console.ReadLine();
                if (vastaus == "perunaa")
                {
                    ruoka.Item2 = lisuke.perunaa;
                    break;
                }
                if (vastaus == "riisiä")
                {
                    ruoka.Item2 = lisuke.riisiä;
                    break;
                }
                if (vastaus == "pastaa")
                {
                    ruoka.Item2 = lisuke.pastaa;
                    break;
                }
                else
                {
                    continue;
                }
            }
           
            while (true)
            {
                Console.WriteLine("Kastike: (curry, hapanimelä, pippuri, chili): ");
                string vastaus = Console.ReadLine();
                if (vastaus == "curry")
                {
                    ruoka.Item3 = kastike.curry;
                    break;
                }
                if (vastaus == "hapanimelä")
                {
                    ruoka.Item3 = kastike.hapanimelä;
                    break;
                }
                if (vastaus == "pippuri")
                {
                    ruoka.Item3 = kastike.pippuri;
                    break;
                }
                if (vastaus == "chili")
                {
                    ruoka.Item3 = kastike.chili;

                    break;
                }
                else
                {
                    continue;
                }
                
            }



            Console.WriteLine($"{ruoka.Item1} ja {ruoka.Item2} {ruoka.Item3}-kastikkeella");

        }
    }
} 