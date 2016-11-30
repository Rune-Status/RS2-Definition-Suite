namespace RS2_Definition_Suite
{
    using CEBL;
    using System;
    using System.Drawing;

    [Serializable]
    public class Sprite
    {
        public int anInt1442;
        public int anInt1443;
        public int anInt1444;
        public int anInt1445;
        public string fullSpriteName;
        public int gID;
        public Bitmap img;
        public int myHeight;
        public int[] myPixels;
        public int myWidth;
        public string spriteName;

        public Sprite()
        {
            this.spriteName = "";
            this.fullSpriteName = "";
            this.myHeight = 0;
            this.gID = 0;
        }

        public Sprite(StreamLoader streamLoader, string s, int i)
        {
            this.spriteName = "";
            this.fullSpriteName = "";
            this.myHeight = 0;
            this.gID = 0;
            this.gID = i;
            this.spriteName = s;
            this.fullSpriteName = s + "," + i;
            this.getSpriteImage(streamLoader, s, i);
        }

        public void drawSprite(int i, int k)
        {
            i += this.anInt1442;
            k += this.anInt1443;
            int num = i + (k * DrawingArea.width);
            int j = 0;
            int myHeight = this.myHeight;
            int myWidth = this.myWidth;
            int num5 = DrawingArea.width - myWidth;
            int num6 = 0;
            if (k < DrawingArea.topY)
            {
                int num7 = DrawingArea.topY - k;
                myHeight -= num7;
                k = DrawingArea.topY;
                j += num7 * myWidth;
                num += num7 * DrawingArea.width;
            }
            if ((k + myHeight) > DrawingArea.bottomY)
            {
                myHeight -= (k + myHeight) - DrawingArea.bottomY;
            }
            if (i < DrawingArea.topX)
            {
                int num8 = DrawingArea.topX - i;
                myWidth -= num8;
                i = DrawingArea.topX;
                j += num8;
                num += num8;
                num6 += num8;
                num5 += num8;
            }
            if ((i + myWidth) > DrawingArea.bottomX)
            {
                int num9 = (i + myWidth) - DrawingArea.bottomX;
                myWidth -= num9;
                num6 += num9;
                num5 += num9;
            }
            if ((myWidth > 0) && (myHeight > 0))
            {
                this.method349(ref DrawingArea.pixels, ref this.myPixels, j, num, myWidth, myHeight, num5, num6);
            }
        }

        public void drawSprite(int i, int k, int topX, int topY, int bottomX, int bottomY)
        {
            i += this.anInt1442;
            k += this.anInt1443;
            int num = i + (k * DrawingArea.width);
            int j = 0;
            int myHeight = this.myHeight;
            int myWidth = this.myWidth;
            int num5 = DrawingArea.width - myWidth;
            int num6 = 0;
            if (k < topY)
            {
                int num7 = topY - k;
                myHeight -= num7;
                k = topY;
                j += num7 * myWidth;
                num += num7 * DrawingArea.width;
            }
            if ((k + myHeight) > bottomY)
            {
                myHeight -= (k + myHeight) - bottomY;
            }
            if (i < topX)
            {
                int num8 = topX - i;
                myWidth -= num8;
                i = topX;
                j += num8;
                num += num8;
                num6 += num8;
                num5 += num8;
            }
            if ((i + myWidth) > bottomX)
            {
                int num9 = (i + myWidth) - bottomX;
                myWidth -= num9;
                num6 += num9;
                num5 += num9;
            }
            if ((myWidth > 0) && (myHeight > 0))
            {
                this.method349(ref DrawingArea.pixels, ref this.myPixels, j, num, myWidth, myHeight, num5, num6);
            }
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

        public void getSpriteImage(StreamLoader streamLoader, string s, int i)
        {
            Stream stream = new Stream(streamLoader.getDataForName(s + ".dat"));
            Stream stream2 = new Stream(streamLoader.getDataForName("index.dat")) {
                currentOffset = stream.readUnsignedWord()
            };
            this.anInt1444 = stream2.readUnsignedWord();
            this.anInt1445 = stream2.readUnsignedWord();
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
            this.anInt1442 = stream2.readUnsignedByte();
            this.anInt1443 = stream2.readUnsignedByte();
            this.myWidth = stream2.readUnsignedWord();
            this.myHeight = stream2.readUnsignedWord();
            int num4 = stream2.readUnsignedByte();
            int num5 = this.myWidth * this.myHeight;
            this.myPixels = new int[num5];
            switch (num4)
            {
                case 0:
                    for (int m = 0; m < num5; m++)
                    {
                        this.myPixels[m] = numArray[stream.readUnsignedByte()];
                    }
                    break;

                case 1:
                    for (int n = 0; n < this.myWidth; n++)
                    {
                        for (int num8 = 0; num8 < this.myHeight; num8++)
                        {
                            this.myPixels[n + (num8 * this.myWidth)] = numArray[stream.readUnsignedByte()];
                        }
                    }
                    break;
            }
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

        private void method349(ref int[] ai, ref int[] ai1, int j, int k, int l, int i1, int j1, int k1)
        {
            int num2 = -(l >> 2);
            l = -(l & 3);
            for (int i = -i1; i < 0; i++)
            {
                int num;
                for (int m = num2; m < 0; m++)
                {
                    if (k >= 0)
                    {
                        num = ai1[j++];
                        if ((num != 0) && (num != -1))
                        {
                            ai[k++] = num;
                        }
                        else
                        {
                            k++;
                        }
                        num = ai1[j++];
                        if ((num != 0) && (num != -1))
                        {
                            ai[k++] = num;
                        }
                        else
                        {
                            k++;
                        }
                        num = ai1[j++];
                        if ((num != 0) && (num != -1))
                        {
                            ai[k++] = num;
                        }
                        else
                        {
                            k++;
                        }
                        num = ai1[j++];
                        if ((num != 0) && (num != -1))
                        {
                            ai[k++] = num;
                        }
                        else
                        {
                            k++;
                        }
                    }
                }
                for (int n = l; n < 0; n++)
                {
                    if (k >= 0)
                    {
                        num = ai1[j++];
                        if ((num != 0) && (num != -1))
                        {
                            ai[k++] = num;
                        }
                        else
                        {
                            k++;
                        }
                    }
                }
                k += j1;
                j += k1;
            }
        }

        private void method351(int i, int j, int[] ai, int[] ai1, int l, int i1, int j1, int k1, int l1)
        {
            int num2 = 0x100 - k1;
            for (int k = -i1; k < 0; k++)
            {
                for (int m = -j; m < 0; m++)
                {
                    int num = ai1[i++];
                    if (num != 0)
                    {
                        int num5 = ai[l1];
                        ai[l1++] = (int) ((((((num & 0xff00ff) * k1) + ((num5 & 0xff00ff) * num2)) & 0xff00ff00L) + ((((num & 0xff00) * k1) + ((num5 & 0xff00) * num2)) & 0xff0000)) >> 8);
                    }
                    else
                    {
                        l1++;
                    }
                }
                l1 += j1;
                i += l;
            }
        }
    }
}

