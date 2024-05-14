namespace Väritetyt_tavarat
{
    internal class Program
    {
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

            public virtual void NaytaTavara()
            {
                Console.WriteLine(tavaranNimi);
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

        public class Miekka : Tavara
        {
            public Miekka() : base(5, 3, "Miekka") { }
        }


        public class VaritettyTavara<T> where T : Tavara
        {
            public T Tavara { get; }
            public ConsoleColor Vari { get; }

            public VaritettyTavara(T tavara, ConsoleColor vari)
            {
                Tavara = tavara;
                Vari = vari;
            }

            public void NaytaTavara()
            {
                Console.ForegroundColor = Vari;
                Tavara.NaytaTavara();
                Console.ResetColor(); // Palauta väri normaaliksi
            }
        }
        static void Main(string[] args)
        {
            // Luodaan väritettyjä tavaroita
            VaritettyTavara<Miekka> punainenMiekka = new VaritettyTavara<Miekka>(new Miekka(), ConsoleColor.Red);
            VaritettyTavara<Köysi> sininenKöysi = new VaritettyTavara<Köysi>(new Köysi(), ConsoleColor.Blue);
            VaritettyTavara<Jousi> vihreaJousi = new VaritettyTavara<Jousi>(new Jousi(), ConsoleColor.Green);

            // Tulostetaan väritetyt tavarat
            punainenMiekka.NaytaTavara();
            sininenKöysi.NaytaTavara();
            vihreaJousi.NaytaTavara();
        }
    }
}