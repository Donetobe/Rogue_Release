using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZeroElectric.Vinculum;
using static System.Net.Mime.MediaTypeNames;

namespace Rogue
{
    public class Enemy
    {
      /// <summary>
      /// This class in used to set up and draw the enemies for the main gameloop
      /// It is also used in the enemyeditor to create the enemies before the game starts
      /// </summary>

        public string name;
        public Vector2 position;
        private Color color;
        int imagesPerRow;
        Texture image1;
        int imagePixelX;
        int imagePixelY;


        public int tileId;
        public int hp;
        public Enemy() { }


        public Enemy(Enemy copyFrom)
        {
            //Copies enemy variables for the editor
            this.name = copyFrom.name;
            this.position = copyFrom.position;
            this.color = copyFrom.color;
            this.imagesPerRow = copyFrom.imagesPerRow;
            this.image1 = copyFrom.image1;
            this.hp = copyFrom.hp;
            this.tileId = copyFrom.tileId;
           

        }
        /// <summary>
        /// This function is used to set up the graphics for the enemies
        /// </summary>
        /// <param name="atlasImage">Is the image where the enemy graphics are taken from </param>
        /// <param name="imagesPerRow">Is used to calculate the position of the correct location of the
        /// specific graphic </param>
        /// <param name="index"> Is the location of the correct enemy graphic </param>
        /// <returns> The function will return a small part of the atlasImage that shoul contain the enemy image</returns>
        public void SetImageAndIndex(Texture atlasImage, int imagesPerRow, int index)
        {
            //Sets up the tilemap for the enemy layer
            image1 = atlasImage;
            imagePixelX = (index % imagesPerRow) * Game.tileSize;
            imagePixelY = (int)(index / imagesPerRow) * Game.tileSize;
        }
        /// <summary>
        /// This function is used to create the variables needed for the enemies for the gameloop
        /// The enemies can be created in the enemy editor before the game starts
        /// </summary>
        /// <param name="name">Is the name of the enemy</param>
        /// <param name="tileID">Is the enemy sprite</param>
        /// <param name="hitPoints">Is the HP of the enemy</param>
        public Enemy(string name, int tileID, int hitPoints)
        {
            //Adds a new enemy
            this.name = name;
            this.tileId = tileID;
            this.hp = hitPoints;
        }

        public void DrawEnemy()
        {
            //Drawn an enemy once called
            int pixelX = (int)(position.X * Game.tileSize);
            int pixelY = (int)(position.Y * Game.tileSize);

            Rectangle imageRect = new Rectangle(imagePixelX, imagePixelY, Game.tileSize, Game.tileSize);

            Raylib.DrawTextureRec(image1, imageRect, new Vector2(pixelX, pixelY), Raylib.WHITE);
        }
    }
}
