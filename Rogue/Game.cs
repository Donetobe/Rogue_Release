using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZeroElectric.Vinculum;
using TurboMapReader;
using RayGuiCreator;
using System.Diagnostics;


namespace Rogue
{
    internal class Game
    {
        PlayerCharacter player;

        TextBoxEntry playerNameEntry = new TextBoxEntry(10);

        Map lvl1;

        MultipleChoiceEntry characterClass = new MultipleChoiceEntry(
            new string[] { "A", "B", "C" });

        MultipleChoiceEntry race = new MultipleChoiceEntry(
       new string[] { "A", "B", "C" });
        public enum GameState
        {
            MainMenu,
            CharacterCreation,
            GameLoop,
            PauseMenu,
            OptionsMenu,
            Quit
        }

        //Pino
        Stack<GameState> stateStack = new Stack<GameState>();

        OptionsMenu myOptionsMenu;
        PauseMenu myPauseMenu;

        GameState currentGameState;

        Enemy enemy;

        Sound soundToPlay;

        public static readonly int tileSize = 16;

        const int screen_width = 1280;
        const int screen_height = 720;
        public void Run()
        {
            //currentGameState = GameState.MainMenu;
            stateStack.Push(GameState.MainMenu);

            myOptionsMenu = new OptionsMenu();
            myPauseMenu = new PauseMenu();

            myOptionsMenu = new OptionsMenu();
            // Kytke asetusvalikon tapahtumaan funktio
            myOptionsMenu.BackButtonPressedEvent += this.OnOptionsBackButtonPressed;
            myPauseMenu.BackButtonPressedEvent += this.OnPauseBackButtonPressed;
            // Prepare to show game
            Console.CursorVisible = false;

            // A small window
            Console.WindowWidth = 60;


            Console.WindowHeight = 26;

            // Create player
            player = new PlayerCharacter('@', Raylib.RED, ConsoleColor.Green);


            MapReader reader = new MapReader();






            player.position = new Vector2(3, 3);

           


           

           

            // Init and run game loop until ESC is pressed
            Console.Clear();

            Raylib.InitWindow(screen_width, screen_height, "Raylib");

            Raylib.InitAudioDevice();

            Sound basicSound = Raylib.LoadSound("Sound/Bass Drum.wav");

            Texture imageTexture = Raylib.LoadTexture("Images/tilemap.png");

            lvl1 = reader.ReadMapFromFile("mapfile.json");

            lvl1 = reader.ReadTiledMapFromFile("tilded/Rogue.tmj");

            lvl1.SetImageAndIndex(imageTexture, 12, 109);
            lvl1.LoadEnemiesAndItems();
            player.SetImageAndIndex(imageTexture, 12, 109);

            soundToPlay = basicSound;

           
                GameLoop();
            


            Raylib.CloseWindow();

        }

        private void DrawMainMenu()
        {
            // Tyhjennä ruutu ja aloita piirtäminen
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.BLACK);

            // Laske ylimmän napin paikka ruudulla.
            int button_width = 100;
            int button_height = 20;
            int button_x = Raylib.GetScreenWidth() / 2 - button_width / 2;
            int button_y = Raylib.GetScreenHeight() / 2 - button_height / 2;

            // Piirrä pelin nimi nappien yläpuolelle
            RayGui.GuiLabel(new Rectangle(button_x, button_y - button_height * 2, button_width, button_height), "Rogue");

            if (RayGui.GuiButton(new Rectangle(button_x, button_y
                , button_width, button_height), "Start Game") == 1)
            {
                // Start the game
                //currentGameState = GameState.CharacterCreation;
                stateStack.Push(GameState.CharacterCreation);
            }
            // Piirrä seuraava nappula edellisen alapuolelle
            button_y += button_height * 2;

            if (RayGui.GuiButton(new Rectangle(button_x,
                button_y,
                button_width, button_height), "Options") == 1)
            {
                // Go to options somehow
               // currentGameState = GameState.OptionsMenu;
                stateStack.Push(GameState.OptionsMenu);
            }

            button_y += button_height * 2;

            if (RayGui.GuiButton(new Rectangle(button_x,
                button_y,
                button_width, button_height), "Pause") == 1)
            {
                //currentGameState = GameState.PauseMenu;
                stateStack.Push(GameState.PauseMenu);
            }

            button_y += button_height * 2;

            if (RayGui.GuiButton(new Rectangle(button_x,
                button_y,
                button_width, button_height), "Quit") == 1)
            {
                stateStack.Push(GameState.Quit);
            }
            Raylib.EndDrawing();
        }
        private void DrawRay()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.BLACK);

            // Draw rest of the game here

            Raylib.EndDrawing();
        }

        void OnOptionsBackButtonPressed(object sender, EventArgs args)
        {
            //currentGameState = GameState.MainMenu;
            stateStack.Pop();
        }

        void OnPauseBackButtonPressed(object sender, Game.GameState newState)
        {
            if (newState == Game.GameState.GameLoop)
            {
                stateStack.Pop();
            }
            else
            {
                //currentGameState = GameState.MainMenu;
                stateStack.Push(GameState.MainMenu);
            }
        }

        void GameLoop()
        {
            bool gameIsOn = true;
            while (Raylib.WindowShouldClose() == false && gameIsOn)
            {
                switch (stateStack.Peek())
                {
                    case GameState.MainMenu:
                        // Tämä koodi on uutta
                        DrawMainMenu();
                        break;
                    case GameState.CharacterCreation:
                        int x = 0;
                        int y = 40;
                        int withd = 300;
                        DrawCharacterMenu(x +Raylib.GetScreenWidth()/2 - withd, y, withd);
                        break;
                    case GameState.PauseMenu:
                        myPauseMenu.DrawMenu();
                        break;
                    case GameState.OptionsMenu:
                        myOptionsMenu.DrawMenu();
                        break;
                    case  GameState.GameLoop:
                        // Tämä koodi on se mitä GameLoop() funktiossa oli ennen muutoksia
                        DrawRay();
                        Update();
                        Draw();

                        break;
                    case GameState.Quit:
                        gameIsOn = false;
                        break;
                }

            }

            void Draw()
            {
                Console.Clear();
                lvl1.DrawMap();
                player.Draw();

            }

            void DrawCharacterMenu(int x, int y, int width)
            {
                Raylib.ClearBackground(Raylib.GetColor(((uint)RayGui.GuiGetStyle(((int)GuiControl.DEFAULT), ((int)GuiDefaultProperty.BACKGROUND_COLOR)))));
                MenuCreator c = new MenuCreator(x, y, Raylib.GetScreenHeight() / 20, width);
                c.Label("Create character");
                c.Label("Name Character");

                c.TextBox(playerNameEntry);
                c.Label("Select class");
                c.DropDown(characterClass);
                c.Label("Select race");
                c.DropDown(race);

                if (c.Button("Start Game"))
                {
                    bool nameOk = true;
                    var nimi = playerNameEntry.ToString();
                    if (string.IsNullOrEmpty(nimi))
                    {

                        Console.WriteLine("Ei kelpaa");
                        nameOk = false;
                    }



                    for (int i = 0; i < nimi.Length; i++)
                    {
                        char kirjain = nimi[i];

                        if (char.IsLetter(kirjain))
                        {

                        }

                        else
                        {
                            nameOk = false;
                            break;
                        }
                    }
                    string raceAnswer = race.ToString();
                    string classAnswer = characterClass.ToString();

                    bool raceSelect = false;
                    bool classSelect = false;

                    if (raceAnswer == "A")
                    {
                        raceSelect = true;
                        player.rotu = Race.A;
                    }
                    if (raceAnswer == "B")
                    {
                        raceSelect = true;
                        player.rotu = Race.B;
                    }
                    if (raceAnswer == "C")
                    {
                        player.rotu = Race.C;
                        raceSelect = true;
                    }
                    if (classAnswer == "A")
                    {
                        player.hahmoluokka = Class.A;
                        classSelect = true;
                    }
                    if (classAnswer == "B")
                    {
                        player.hahmoluokka = Class.B;
                        classSelect = true;

                    }
                    if (classAnswer == "C")
                    {
                        player.hahmoluokka = Class.C;
                        classSelect = true;

                    }

                    if (nameOk && raceSelect == true && classSelect == true) { stateStack.Push( currentGameState = GameState.GameLoop); }

                }
                c.EndMenu();
                Raylib.EndDrawing();
            }

         


            void Update()
            {

                Vector2 newPlace = player.position;
                /*
                    ConsoleKeyInfo key = Console.ReadKey();

                    switch (key.Key)
                    {

                        case ConsoleKey.UpArrow:
                            newPlace.Y -= 1;
                            break;
                        case ConsoleKey.DownArrow:
                            newPlace.Y += 1;
                            break;
                        case ConsoleKey.LeftArrow:
                            newPlace.X -= 1;
                            break;
                        case ConsoleKey.RightArrow:
                            newPlace.X += 1;
                            break;

                        case ConsoleKey.Escape:

                            break;

                        default:
                            break;
                    };
                */

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
                {
                    Raylib.PlaySound(soundToPlay);
                    newPlace.Y -= 1;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
                {
                    Raylib.PlaySound(soundToPlay);
                    newPlace.Y += 1;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
                {
                    Raylib.PlaySound(soundToPlay);
                    newPlace.X -= 1;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT))
                {
                    Raylib.PlaySound(soundToPlay);
                    newPlace.X += 1;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
                {
                    stateStack.Push(GameState.PauseMenu);
                    
                }


                if (lvl1.GetTileAtGround((int)newPlace.X, (int)newPlace.Y) == Map.MapTile.Floor)
                {
                    player.position = newPlace;

                    foreach (var item in lvl1.enemies)
                    {
                        if (item.position == player.position)
                        {
                            Console.WriteLine($"You hit enemy {item.name}");
                        }
                    }


                    foreach (var item in lvl1.items)
                    {
                        if (item.position == player.position)
                        {
                            Console.WriteLine($"You hit item {item.name}");
                        }
                    }
                }
            }
        }
    }
}
