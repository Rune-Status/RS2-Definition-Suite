namespace CEBL
{
    using System;
    using System.IO;
    using System.Text;

    public class CacheUnpacker
    {
        public static Class21[] class21Collections = new Class21[0x9c40];
        public Decompressor[] decompressors = new Decompressor[5];
        public int[] expectedCRCs = new int[9];

        public void LoadCache(string path)
        {
            Main.cache = new CacheStore(path);
            this.SetDecompressors();
        }

        public static void method460(byte[] abyte0, int j)
        {
            CEBL.Stream stream = new CEBL.Stream(abyte0) {
                currentOffset = abyte0.Length - 0x12
            };
            Class21 class2 = class21Collections[j] = new Class21();
            class2.aByteArray368 = abyte0;
            class2.anInt369 = stream.readUnsignedWord();
            class2.anInt370 = stream.readUnsignedWord();
            class2.anInt371 = stream.readUnsignedByte();
            int num = stream.readUnsignedByte();
            int num2 = stream.readUnsignedByte();
            int num3 = stream.readUnsignedByte();
            int num4 = stream.readUnsignedByte();
            int num5 = stream.readUnsignedByte();
            int num6 = stream.readUnsignedWord();
            int num7 = stream.readUnsignedWord();
            int num8 = stream.readUnsignedWord();
            int num9 = stream.readUnsignedWord();
            int num10 = 0;
            class2.anInt372 = num10;
            num10 += class2.anInt369;
            class2.anInt378 = num10;
            num10 += class2.anInt370;
            class2.anInt381 = num10;
            if (num2 == 0xff)
            {
                num10 += class2.anInt370;
            }
            else
            {
                class2.anInt381 = -num2 - 1;
            }
            class2.anInt383 = num10;
            if (num4 == 1)
            {
                num10 += class2.anInt370;
            }
            else
            {
                class2.anInt383 = -1;
            }
            class2.anInt380 = num10;
            if (num == 1)
            {
                num10 += class2.anInt370;
            }
            else
            {
                class2.anInt380 = -1;
            }
            class2.anInt376 = num10;
            if (num5 == 1)
            {
                num10 += class2.anInt369;
            }
            else
            {
                class2.anInt376 = -1;
            }
            class2.anInt382 = num10;
            if (num3 == 1)
            {
                num10 += class2.anInt370;
            }
            else
            {
                class2.anInt382 = -1;
            }
            class2.anInt377 = num10;
            num10 += num9;
            class2.anInt379 = num10;
            num10 += class2.anInt370 * 2;
            class2.anInt384 = num10;
            num10 += class2.anInt371 * 6;
            class2.anInt373 = num10;
            num10 += num6;
            class2.anInt374 = num10;
            num10 += num7;
            class2.anInt375 = num10;
            num10 += num8;
        }

        public MemoryStream openJagGrabInputStream(string s)
        {
            return new MemoryStream(Encoding.ASCII.GetBytes("JAGGRAB /" + s + "\n\n"));
        }

        public void SetDecompressors()
        {
            for (int i = 0; i < 5; i++)
            {
                this.decompressors[i] = new Decompressor(Main.cache.cache_dat, Main.cache.cache_idx[i], i + 1);
            }
        }

        public StreamLoader streamLoaderForName(int i, string s, string s1, int j, int k)
        {
            byte[] buffer = null;
            try
            {
                if (this.decompressors[0] != null)
                {
                    buffer = this.decompressors[0].decompress(i);
                }
            }
            catch (Exception)
            {
            }
            if (buffer != null)
            {
                return new StreamLoader(buffer);
            }
            return null;
        }
    }
}

