using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZeroElectric.Vinculum;


namespace Rogue
{
    internal class Game
    {
        PlayerCharacter player;
        
        Map lvl1;

        Enemy enemy;

        public static readonly int tileSize = 16;

        const int screen_width = 1280;
        const int screen_height = 720;
        public void Run()
        {





            // Prepare to show game
            Console.CursorVisible = false;

            // A small window
            Console.WindowWidth = 60;
            
            
            Console.WindowHeight = 26;

            // Create player
            player = new PlayerCharacter('@', Raylib.RED, ConsoleColor.Green);


            MapReader reader = new MapReader();


            
           
            

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

            Raylib.InitWindow(screen_width, screen_height, "Raylib");


            Texture imageTexture = Raylib.LoadTexture("Images/tilemap.png");

            lvl1 = reader.ReadMapFromFile("mapfile.json");

            lvl1.SetImageAndIndex(imageTexture, 12, 109);
            lvl1.LoadEnemiesAndItems();
            player.SetImageAndIndex(imageTexture, 12, 109);



            while (Raylib.WindowShouldClose() == false)
            {
                GameLoop();
            }


            Raylib.CloseWindow();

        }

        private void DrawRay()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.BLACK);

            // Draw rest of the game here

            Raylib.EndDrawing();
        }

        void GameLoop()
        {
            while (true)
            {
                DrawRay();
                Update();
                Draw();
                
            }
        }
        
        void Draw()
        {
            Console.Clear();
            lvl1.DrawMap();
            player.Draw();
            
        }


        void Update()
        {

            Point2D newPlace = player.position;
            /*
                ConsoleKeyInfo key = Console.ReadKey();
               
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
                        
                        break;

                    default:
                        break;
                };
            */

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
            {
                newPlace.y -= 1;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
            {
                newPlace.y += 1;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
            {
                newPlace.x -= 1;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT))
            {
                newPlace.x += 1;
            }

            if (lvl1.GetTileAt(newPlace.x, newPlace.y) == Map.MapTile.Floor)
                {
                    player.position = newPlace;
                }

            
 
        }
    }
}
