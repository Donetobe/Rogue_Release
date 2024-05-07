using System.Diagnostics;
using System.Numerics;

namespace Kertaus
{
    internal class Program
    {

        
        static void Main(string[] args)
        {

            int playerHP = 15;
            int enemyHP = 10;
            bool gameIsRunning = true;

            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine("Löydät örkin. KILL IT!");
            Console.WriteLine(" ");

            Random random = new Random();

         while (gameIsRunning) 
            {
                if (enemyHP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Päihitit örkin");
                    gameIsRunning = false;
                    break;
                }

                if (playerHP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sinä kuolit");
                    gameIsRunning = false;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Sinä: {playerHP}/15  Örkki: {enemyHP}/10");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lyö miekalla - 1");
                Console.WriteLine("Käytä kilpeä - 2");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Mitä haluat tehdä?");

                while (true)
                {
                    int enemyDMG = random.Next(1, 6);

                    bool ok = true;


                    string vastaus = Console.ReadLine();

                    foreach (char c in vastaus)
                    {
                        if (!Char.IsDigit(c))
                        {
                            ok = false;

                        }

                    }
                    if (ok == false)
                    {
                        Console.WriteLine("Mitä haluat tehdä?");
                        continue;
                    }
                    int valinta = Convert.ToInt32(vastaus);

                    if (valinta == 1 && ok)
                    {
                        int dMG = random.Next(1, 6);
                        enemyHP -= dMG;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Teit örkkiin {dMG} vahinkoa");
                        Console.ForegroundColor = ConsoleColor.Red;
                        playerHP -= enemyDMG;
                        Console.WriteLine($"Örkki teki sinuun {enemyDMG} vahinkoa");
                        break;
                    }

                    else if (valinta == 2 && ok)
                    {
                        Console.WriteLine($"Käytit kilpeä");
                        Console.ForegroundColor= ConsoleColor.Red;
                        playerHP -= enemyDMG / 2;
                        Console.WriteLine($"Örkki teki sinuun {enemyDMG / 2} vahinkoa");
                        break;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Mitä haluat tehdä?");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Lyö miekalla - 1");
                    Console.WriteLine("Käytä kilpeä - 2");
                }
             
            }
        }
    }
}