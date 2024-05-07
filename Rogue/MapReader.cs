using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.PortableExecutable;
using Newtonsoft.Json;

namespace Rogue
{
    internal class MapReader
    {
        public Map LoadTestMap()
        {
            Map testi = new Map();
            testi.mapWidth = 8;
            testi.layers = new MapLayer[3];
            testi.layers[0].mapTiles = new int[] {
            2, 2, 2, 2, 2, 2, 2, 2,
            2, 1, 1, 2, 1, 1, 1, 2,
            2, 1, 1, 2, 1, 1, 1, 2,
            2, 1, 1, 1, 1, 1, 2, 2,
            2, 2, 2, 2, 1, 1, 1, 2,
            2, 1, 1, 1, 1, 1, 1, 2,
            2, 2, 2, 2, 2, 2, 2, 2
            };
         
            return testi;
        }
        public Map ReadMapFromFile(string fileName)
        {
            bool exists = File.Exists(fileName);

            if (exists == false)
            {
                Console.WriteLine($"File {fileName} not found");
                return LoadTestMap();
            }

            string fileContents;

            using (StreamReader reader = File.OpenText(fileName))
            {
                fileContents = reader.ReadToEnd();
            }

            Map loadedMap = JsonConvert.DeserializeObject<Map>(fileContents);


           
            return loadedMap;
        }
    }
}
