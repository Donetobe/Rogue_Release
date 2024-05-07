using ZeroElectric.Vinculum;
using static System.Net.Mime.MediaTypeNames;

namespace raylib_pohja
{
    class WindowTest
    {
        const int screen_width = 1500;
        const int screen_height = 1000;

        private float X = 0;
        private float Y = 0;

        private float speedX = 100;
        private float speedY = 100;
        public WindowTest()
        {

        }
   
        public void Run()
        {
            Raylib.InitWindow(screen_width, screen_height, "Raylib");
            Raylib.SetTargetFPS(60);

            while (Raylib.WindowShouldClose() == false)
            {
                Update();
                Draw();
            }

            Raylib.CloseWindow();
        }

        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.GREEN);
            // Draws a maroon circle in the middle
            Raylib.DrawCircle((int)X, (int)Y, 40, Raylib.RED);

            // Draw rest of the game here

            Raylib.EndDrawing();
        }

        private void Update()
        {
            Y += speedY * Raylib.GetFrameTime();

            X += speedX * Raylib.GetFrameTime();

            if (X >= screen_width)
            {
                speedX = -100;
            }

            if (Y >= screen_height)
            {
                speedY = -100;
            }

            if (X < 0)
            {
                speedX = 100;
            }

            if (Y < 0) 
            { 
                speedY = 100;
            }
        }
    }
}