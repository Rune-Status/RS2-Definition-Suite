using CEBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Definition_Suite.RS319
{
    class MapIndex
    {
        private int[] areas;
        private int[] mapFiles;
        private int[] landscapes;
        private int[] preload;

        public MapIndex()
        {}

        public void unpack(StreamLoader sl)
        {
            byte[] index = sl.getDataForName("map_index");
            CEBL.Stream stream2 = new CEBL.Stream(index);
            int j1 = index.Length / 7;

            System.Console.WriteLine("Map Index J1: " + j1);
            areas = new int[j1];
            mapFiles = new int[j1];
            landscapes = new int[j1];
            preload = new int[j1];
            for (int i2 = 0; i2 < j1; i2++)
            {
                areas[i2] = stream2.readUnsignedWord();
                mapFiles[i2] = stream2.readUnsignedWord();
                landscapes[i2] = stream2.readUnsignedWord();
                preload[i2] = stream2.readUnsignedByte();
            }
        }
    }
}
