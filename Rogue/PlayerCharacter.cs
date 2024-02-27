using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

        private char image;
        private ConsoleColor color;

        public PlayerCharacter(char image, ConsoleColor color)
        {
            this.image = image;
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
            Console.ForegroundColor = color;
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(image);
        }
    }



}
