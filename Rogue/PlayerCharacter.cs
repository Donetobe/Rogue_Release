using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroElectric.Vinculum;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;

namespace Rogue
{
    
  
    enum Race
    {
        A, B, C
    }

    enum Class
    {
        A, B, C
    }

    internal class PlayerCharacter
    {
        public string nimi;
        public Race rotu;
        public Class hahmoluokka;

        public Point2D position;


        Texture image1;
        int imagePixelX;
        int imagePixelY;


        private char image;
        ZeroElectric.Vinculum.Color color;
        ConsoleColor color1;

        public void SetImageAndIndex(Texture atlasImage, int imagesPerRow, int index)
        {
            image1 = atlasImage;
            imagePixelX = (index % imagesPerRow) * Game.tileSize;
            imagePixelY = (int)(index / imagesPerRow) * Game.tileSize;
        }


        public PlayerCharacter(char image, ZeroElectric.Vinculum.Color color, ConsoleColor color1)
        {
            this.image = image;
            this.color1 = color1;
            this.color = color;
        }

        public void Move(int x_move, int y_move)
        {
            position.x += x_move;
            position.y += y_move;
            // This keeps the unit inside Console window
            position.x = Math.Clamp(position.x, 0, Console.WindowWidth - 1);
            position.y = Math.Clamp(position.y, 0, Console.WindowHeight - 1);

        }

        public void Draw()
        {
            int pixelX = (int)(position.x * Game.tileSize);
            int pixelY = (int)(position.y * Game.tileSize);

            Console.ForegroundColor = color1;
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(image);

            Rectangle imageRect = new Rectangle(imagePixelX, imagePixelY, Game.tileSize, Game.tileSize);
           // Raylib.DrawRectangle(pixelX, pixelY, Game.tileSize, Game.tileSize, color);
            Raylib.DrawTextureRec(image1, imageRect, new Vector2(pixelX, pixelY), Raylib.WHITE);
            

        }
    }

    

}
