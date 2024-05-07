using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static nuolikauppa.Arrow;

namespace nuolikauppa
{


    public class Arrow
    {

        public enum Kärki
        {
            puu, teräs, timantti
        }

        public enum Sulat
        {
            lehti, kanansulka, kotkansulka
        }

        float pituus;
        Kärki nuolenKärki;
        Sulat sulat;
        float hinta;

        public float Pituus
        {
            get { return pituus; } 
            set { pituus = value; }
        }

        public Kärki NuolenKärki
        {
            get { return nuolenKärki; }
            set { nuolenKärki = value; }
        }

        public Sulat Sulaat
        {
            get { return sulat; }
            set { sulat = value; }
        }

        public float Hinta
        {
            get { return hinta; }
            set { hinta = value; }
        }


        public Arrow(Arrow.Kärki k, Arrow.Sulat s, float p)
        {
            nuolenKärki = k;
            sulat = s;
            pituus = p;
        }

        public float PalautaHinta()
        {


            switch (this.nuolenKärki)
            {
                case Arrow.Kärki.puu:
                    hinta += 3;
                    break;
                case Arrow.Kärki.teräs:
                    hinta += 5;
                    break;
                case Arrow.Kärki.timantti:
                    hinta += 50;
                    break;
                default:
                    break;
            }

            switch (this.sulat)
            {
                case Arrow.Sulat.lehti:
                    break;
                case Arrow.Sulat.kanansulka:
                    hinta += 1;
                    break;
                case Arrow.Sulat.kotkansulka:
                    hinta += 5;
                    break;
                default:
                    break;
            }

            hinta += pituus * 0.05f;

            Console.WriteLine($"Nuolen hinta on {hinta} kultaa");
            return hinta;
        }


        public static Arrow LuoEliittiNuoli()
        {
            Kärki nuolenKärki = Kärki.timantti;
            Sulat sulat = Sulat.kotkansulka;
            int pituus = 100;
            return new Arrow(nuolenKärki, sulat, pituus);
        }

        public static Arrow LuoAloittelijaNuoli()
        {
            Kärki nuolenKärki = Kärki.puu;
            Sulat sulat = Sulat.kanansulka;
            int pituus = 70;
            return new Arrow(nuolenKärki, sulat, pituus);
        }

        public static Arrow LuoPerusnuoliNuoli()
        {
            Kärki nuolenKärki = Kärki.teräs;
            Sulat sulat = Sulat.kanansulka;
            int pituus = 85;
            return new Arrow(nuolenKärki, sulat, pituus);
        }
    }
    internal class Nuoli
    {
   
        public void Run()
        {
            Arrow nuoli;
            Arrow.Kärki nuolenKärki;
            Arrow.Sulat sulat;
            int pituus;
            bool madepreset = true;

            while (madepreset)
            {
                Console.WriteLine("Haluatko rakentaa oman nuolen vai valita valmiin (rakenna vai valitse)? ");
                string vastaus = Console.ReadLine();
                switch (vastaus)
                {
                    case "rakenna":
                        madepreset = false; 
                        break;
                    case "valitse":
                        madepreset = true;
                        break;
                    default:
                        continue;
                }

                while (madepreset)
                {
                    Console.WriteLine("Millaisen nuolen haluat (​​​​​​eliittinuoli, aloittelijanuoli tai perusnuoli)?");
                    string vastaus1 = Console.ReadLine();
                    switch (vastaus1)
                    {
                        case "eliittinuoli":
                            nuoli = Arrow.LuoEliittiNuoli();;
                            nuoli.PalautaHinta();
                            break;
                        case "perusnuoli":
                            nuoli = Arrow.LuoPerusnuoliNuoli();
                            nuoli.PalautaHinta();
                            break;
                        case "aloittelijanuoli":
                            nuoli = Arrow.LuoAloittelijaNuoli();
                            nuoli.PalautaHinta();
                            break;
                        default:
                            continue;
                    }
                    break;
                }
 
            }

            if (!madepreset)
            {
                Console.WriteLine("Minkä lainen kärki (puu, teräs tai timantti)? ");

                while (true)
                {
                    string vastaus = Console.ReadLine();

                    switch (vastaus)
                    {
                        case "puu":
                            nuolenKärki = Arrow.Kärki.puu;
                            break;
                        case "teräs":
                            nuolenKärki = Arrow.Kärki.teräs;
                            break;
                        case "timantti":
                            nuolenKärki = Arrow.Kärki.timantti;
                            break;
                        default:
                            continue;
                    }
                    break;
                }

                Console.WriteLine("Minkälaiset sulat (lehti, kanansulka tai kotkansulka)? ");

                while (true)
                {
                    string vastaus = Console.ReadLine();

                    switch (vastaus)
                    {
                        case "lehti":
                            sulat = Arrow.Sulat.lehti;
                            break;
                        case "kanansulka":
                            sulat = Arrow.Sulat.kanansulka;
                            break;
                        case "kotkansulka":
                            sulat = Arrow.Sulat.kotkansulka;
                            break;
                        default:
                            continue;
                    }
                    break;
                }

                Console.WriteLine("Nuolen pituus (60 - 100cm)?");

                while (true)
                {
                    string vastaus = Console.ReadLine();

                    if (checkIfNumber(vastaus))
                    {
                        pituus = Convert.ToInt32(vastaus);
                        if (pituus > 59 && pituus < 101)
                        {
                            break;
                        }
                    }
                    continue;
                }
                    nuoli = new Arrow(nuolenKärki, sulat, pituus);
                
                    nuoli.PalautaHinta();
                
            }

            
           
     
            
        }

        bool checkIfNumber(string vastaus)
        {
            foreach (char c in vastaus)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

       
    }
}
