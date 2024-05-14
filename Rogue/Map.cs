using System.Numerics;
using System.Text.RegularExpressions;
using ZeroElectric.Vinculum;

namespace Rogue
{

internal class Map
    {
        public int mapWidth;
        public MapLayer[] layers;

        Texture image1;
        int imagePixelX;
        int imagePixelY;

        int imagesPerRow;

        public List<Enemy> enemies;
        public List<Item> items;


        public enum MapTile : int
        {
            Floor = 0,
            Wall = 14,
            Enemy = 96
        }

        

    public int getTileAt(Vector2 newPlace)
        {
            MapLayer ground = layers[0];
            return (ground.mapTiles[(int)newPlace.X + (int)newPlace.Y * mapWidth]);
            
               
            
        }

        public MapTile GetTileAtGround(int x, int y)
        {
            MapLayer ground = layers[0];
            return (MapTile)(ground.mapTiles[x + y * mapWidth]);
        }

        public MapTile GetTileAtEnemy(int x, int y)
        {
            MapLayer ground = layers[2];
            return (MapTile)(ground.mapTiles[x + y * mapWidth]);
        }

        public void SetImageAndIndex(Texture atlasImage, int imagesPerRow, int index)
        {
            this.imagesPerRow = imagesPerRow;
            image1 = atlasImage;
         
          
        }
        public void DrawMap()
        {
            MapLayer ground = layers[0];
            Console.ForegroundColor = ConsoleColor.Gray;
        
            for (int row = 0; row < ground.mapTiles.Length / mapWidth; row++)
            {
                for (int col = 0; col < mapWidth; col++)
                {
                    int tileId = ground.mapTiles[row * mapWidth + col];
                    tileId--;
                    Console.SetCursorPosition(col, row);

                   
                       imagePixelX = (tileId % imagesPerRow) * Game.tileSize;
                            imagePixelY = (int)(tileId / imagesPerRow) * Game.tileSize;
                            int pixelX = (int)(col * Game.tileSize);
                            int pixelY = (int)(row * Game.tileSize);

                            Console.Write(".");
                            Rectangle imageRect = new Rectangle(imagePixelX, imagePixelY, Game.tileSize, Game.tileSize);
                            // Raylib.DrawRectangle(pixelX, pixelY, Game.tileSize, Game.tileSize, color);
                            Raylib.DrawTextureRec(image1, imageRect, new Vector2(pixelX, pixelY), Raylib.WHITE);
            
                }

            }

            foreach (var item in enemies)
            {
                item.DrawEnemy();

            }

            foreach (var item in items)
            {
                item.DrawItem();

            }
        }


        
        public void LoadEnemiesAndItems()
        {
            enemies = new List<Enemy>();


            MapLayer enemyLayer = layers[2];

            int[] enemyTiles = enemyLayer.mapTiles;
            int mapHeight = enemyTiles.Length / mapWidth;
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Vector2 position = new Vector2(x, y);
                    int index = x + y * mapWidth;
                    int tileId = enemyTiles[index];
                    switch (tileId)
                    {
                        case 0:
                            // ei mitään tässä kohtaa
                            break;
                        case 96:
                            Enemy o = new Enemy("Orc", position, Raylib.WHITE);
                            o.SetImageAndIndex(image1, imagesPerRow, tileId);
                            enemies.Add(o);
                            break;
                        case 2:
                            // jne...
                            break;
                    }
                }
            }

            // sama esineille...
            items = new List<Item>();

            MapLayer itemLayers = layers[1];

            int[] itemTiles = itemLayers.mapTiles;
            int mapHeight1 = itemTiles.Length / mapWidth;
            for (int y = 0; y < mapHeight1; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Vector2 position = new Vector2(x, y);
                    int index = x + y * mapWidth;
                    int tileId = itemTiles[index];
                    switch (tileId)
                    {
                        case 0:
                            // ei mitään tässä kohtaa
                            break;
                        case 89:
                            Item i = new Item("chest", position, Raylib.WHITE);
                            i.SetImageAndIndex(image1, imagesPerRow, tileId);
                            items.Add(i);
                            break;
                        case 2:
                            // jne...
                            break;
                    }
                }
            }
        }
        
      
    }

 
}