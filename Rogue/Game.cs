using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
    internal class Game
    {

        public void Run()
        {
           

            
             

            // Prepare to show game
            Console.CursorVisible = false;

            // A small window
            Console.WindowWidth = 60;
            Console.WindowHeight = 26;

            // Create player
            PlayerCharacter player = new PlayerCharacter('@', ConsoleColor.Green);

            MapReader reader = new MapReader();

            Map lvl1 = reader.ReadMapFromFile("mapfile.json");
         
            player.position = new Point2D(3, 3);

            while (true)
            {

                Console.WriteLine("Anna nimi:");
                string nimi = Console.ReadLine();
                bool ok = true;
                foreach (char c in nimi)
                {
                    if (Char.IsDigit(c))
                    {
                        ok = false;

                    }

                }
                if (ok == false)
                {
                    Console.WriteLine("Nimessä ei saa olla numeroita");

                }
                else
                {
                    nimi = player.nimi;
                    break;
                }
            }


            while (true)
            {
                bool ok = true;
                Console.WriteLine("Valitse rotu:");
                Console.WriteLine("1: Rotu1");
                Console.WriteLine("2: Rotu2");
                Console.WriteLine("3: Rotu3");

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
                    Console.WriteLine("Sinun täytyy valita rodun numero 1-3");
                    continue;
                }
                int rotunumero = Convert.ToInt32(vastaus);

                if (rotunumero == 1 && ok)
                {
                    player.rotu = Race.A;
                    break;
                }

                else if (rotunumero == 1 && ok)
                {
                    player.rotu = Race.B;
                    break;
                }

                else if (rotunumero == 3 && ok)
                {
                    player.rotu = Race.C;
                    break;
                }
                Console.WriteLine("Sinun täytyy valita rodun numero 1-3");
            }

            while (true)
            {
                bool ok = true;
                Console.WriteLine("Valitse luokka:");
                Console.WriteLine("1: LuokkaA");
                Console.WriteLine("2: LuokkaB");
                Console.WriteLine("3: LuokkaC");

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
                    Console.WriteLine("Sinun täytyy valita luokan numero 1-3");
                    continue;
                }

                int luokanumero = Convert.ToInt32(vastaus);
                if (luokanumero == 1 && ok)
                {
                    player.hahmoluokka = Class.A;
                    break;
                }

                else if (luokanumero == 2 && ok)
                {
                    player.hahmoluokka = Class.B;
                    break;
                }

                else if (luokanumero == 3 && ok)
                {
                    player.hahmoluokka = Class.C;
                    break;
                }
                Console.WriteLine("Sinun täytyy valita luokan numero 1-3");
            }

            // Init and run game loop until ESC is pressed
            Console.Clear();



            lvl1.DrawMap();

            player.Draw();
            
            bool game_running = true;
            while (game_running)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Point2D newPlace = player.position;
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        newPlace.y -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        newPlace.y += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        newPlace.x -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                       newPlace.x += 1;
                        break;

                    case ConsoleKey.Escape:
                        game_running = false;
                        break;

                    default:
                        break;
                };

                if (lvl1.mapTiles[newPlace.x + newPlace.y * lvl1.mapWidth] != 2)
                {
                   player.position = newPlace;
                }
                Console.Clear();
                lvl1.DrawMap();
                player.Draw();
                
            }

           
            
           
        }
    }
}
