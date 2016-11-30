namespace CEBL
{
    using System;
    using System.Drawing;

    public class PlainSprite
    {
        public int anInt1442;
        public int anInt1443;
        public int anInt1444;
        public int anInt1445;
        public Bitmap img;
        public int myHeight;
        public int[] myPixels;
        public int myWidth;
        public string spriteName;

        public PlainSprite()
        {
            this.spriteName = "";
            this.myHeight = 0;
        }

        public PlainSprite(StreamLoader streamLoader, string s, int i)
        {
            this.spriteName = "";
            this.myHeight = 0;
            this.spriteName = s;
            this.img = getSpriteImage(streamLoader, s, i, ref this.anInt1442, ref this.anInt1443, ref this.anInt1444, ref this.anInt1445);
        }

        public Bitmap getSpriteImage()
        {
            Bitmap bitmap = new Bitmap(this.myWidth, this.myHeight);
            for (int i = 0; i < this.myHeight; i++)
            {
                for (int j = 0; j < this.myWidth; j++)
                {
                    int index = (i * this.myWidth) + j;
                    int blue = this.myPixels[index] & 0xff;
                    int green = (this.myPixels[index] >> 8) & 0xff;
                    int red = this.myPixels[index] >> 0x10;
                    bitmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
            }
            return bitmap;
        }

        public static Bitmap getSpriteImage(StreamLoader streamLoader, string s, int i, ref int anInt1442, ref int anInt1443, ref int anInt1444, ref int anInt1445)
        {
            Stream stream = new Stream(streamLoader.getDataForName(s + ".dat"));
            Stream stream2 = new Stream(streamLoader.getDataForName("index.dat"));
            if (stream2.buffer == null)
            {
                return null;
            }
            stream2.currentOffset = stream.readUnsignedWord();
            anInt1444 = stream2.readUnsignedWord();
            anInt1445 = stream2.readUnsignedWord();
            int num = stream2.readUnsignedByte();
            int[] numArray = new int[num];
            for (int j = 0; j < (num - 1); j++)
            {
                numArray[j + 1] = stream2.read3Bytes();
                if (numArray[j + 1] == 0)
                {
                    numArray[j + 1] = 1;
                }
            }
            for (int k = 0; k < i; k++)
            {
                stream2.currentOffset += 2;
                stream.currentOffset += stream2.readUnsignedWord() * stream2.readUnsignedWord();
                stream2.currentOffset++;
            }
            anInt1442 = stream2.readUnsignedByte();
            anInt1443 = stream2.readUnsignedByte();
            int width = stream2.readUnsignedWord();
            int height = stream2.readUnsignedWord();
            int num6 = stream2.readUnsignedByte();
            int num7 = width * height;
            int[] numArray2 = new int[num7];
            switch (num6)
            {
                case 0:
                    for (int n = 0; n < num7; n++)
                    {
                        numArray2[n] = numArray[stream.readUnsignedByte()];
                    }
                    return new Bitmap(width, height);

                case 1:
                    for (int num9 = 0; num9 < width; num9++)
                    {
                        for (int num10 = 0; num10 < height; num10++)
                        {
                            numArray2[num9 + (num10 * width)] = numArray[stream.readUnsignedByte()];
                        }
                    }
                    break;
            }
            Bitmap bitmap = new Bitmap(width, height);
            for (int m = 0; m < height; m++)
            {
                for (int num12 = 0; num12 < width; num12++)
                {
                    int index = (m * width) + num12;
                    int blue = numArray2[index] & 0xff;
                    int green = (numArray2[index] >> 8) & 0xff;
                    int red = numArray2[index] >> 0x10;
                    bitmap.SetPixel(num12, m, Color.FromArgb(red, green, blue));
                }
            }
            return bitmap;
        }

        public void method345()
        {
            int[] destinationArray = new int[this.anInt1444 * this.anInt1445];
            for (int i = 0; i < this.myHeight; i++)
            {
                Array.Copy(this.myPixels, i * this.myWidth, destinationArray, (i + (this.anInt1443 * this.anInt1444)) + this.anInt1442, this.myWidth);
            }
            this.myPixels = destinationArray;
            this.myWidth = this.anInt1444;
            this.myHeight = this.anInt1445;
            this.anInt1442 = 0;
            this.anInt1443 = 0;
        }
    }
}

