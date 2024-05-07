using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reppu
{
    internal class Reppu
    {
        public class RP
        {
            public List<string> sisältö;

            public float määrä;
            public float paino;
            public float tilavuus;

            public RP(float tilavuus, float paino, float määrä)
            {
                this.paino = paino;
                this.tilavuus = tilavuus;
                this.määrä = määrä;
                sisältö= new List<string>();
            }

            public bool laitaReppuun(Tavara t) 
            {

                if (paino < 30 && määrä < 10 && tilavuus < 20)
                {
                    sisältö.Add(t.tavaranNimi);
                    paino += t.tavaranPaino;
                    tilavuus += t.tavaranTilavuus;
                    määrä += 1;
                }

                Console.Write("Repun sisältö: ");
                foreach (var item in sisältö)
                {
                    Console.Write(item + ", ");
                }
                Console.WriteLine(" ");
                return false;
            }
        }

        public class Tavara
        {
            public float tavaranPaino;
            public float tavaranTilavuus;
            public string tavaranNimi;
            public Tavara(float paino, float tilavuus, string nimi) 
            { 
               tavaranPaino = paino;
               tavaranTilavuus = tilavuus;
               tavaranNimi = nimi;
            }
        }

        public class Nuoli : Tavara
        {
            public Nuoli() : base(0.1f, 0.05f, "Nuoli") { }
        }

        public class Jousi : Tavara
        {
            public Jousi() : base(1, 4, "Jousi") { }
        }

        public class Köysi : Tavara
        {
            public Köysi() : base(1, 1.5f, "Köysi") { }
        }

        public class Vesi : Tavara
        {
            public Vesi() : base(2, 2, "Vesi") { }
        }

        public class RuokaAnnos : Tavara
        {
            public RuokaAnnos() : base(1, 0.5f, "Ruoka-annos") { }
        }

        public class Miekka: Tavara
        {
            public Miekka(): base(5, 3, "Miekka") { }
        }


        public void Run()
        {

            RP reppu = new RP(0, 0, 0);
            while (true)
            {
                Console.WriteLine($"Repussa on tällä hetkellä {reppu.määrä}/10 tavaraa, {reppu.paino}/30 painoa ja {reppu.tilavuus}/20 tilavuus");
                Console.WriteLine("Mitä haluat lisätä? ");
                Console.WriteLine("Nuoli - 1 ");
                Console.WriteLine("Jousi - 2 ");
                Console.WriteLine("Köysi - 3 ");
                Console.WriteLine("Vettä - 4 ");
                Console.WriteLine("Ruokaa - 5 ");
                Console.WriteLine("Miekka - 6 ");

                string vastaus = Console.ReadLine();
                switch (vastaus)
                {
                    case "1":
                        Nuoli n = new Nuoli();
                        reppu.laitaReppuun(n);
                        break;
                    case "2":
                        Jousi j = new Jousi();
                        reppu.laitaReppuun(j);
                        break;
                    case "3":
                        Köysi k = new Köysi();
                        reppu.laitaReppuun(k);
                        break;
                    case "4":
                        Vesi v = new Vesi();
                        reppu.laitaReppuun(v);
                        break;
                    case "5":
                        RuokaAnnos r = new RuokaAnnos();
                        reppu.laitaReppuun(r);
                        break;
                    case "6":
                        Miekka m = new Miekka();
                        reppu.laitaReppuun(m);
                        break;
                    default:
                        continue;
                }
                
            }

            void CheckIfCanFit()
            {
                if (reppu.paino < 30 && reppu.määrä < 10 && reppu.tilavuus < 20)
                {
                    
                }
            }
        }

       
    }
}
