namespace RS2_Definition_Suite
{
    using CEBL;
    using System;

    [Serializable]
    public class Background : DrawingArea
    {
        public byte[] aByteArray1450;
        public int anInt1452;
        public int anInt1453;
        public int anInt1454;
        public int anInt1455;
        public int anInt1456;
        private int anInt1457;
        public int[] anIntArray1451;

        public Background(StreamLoader streamLoader, string s, int i)
        {
            Stream stream = new Stream(streamLoader.getDataForName(s + ".dat"));
            Stream stream2 = new Stream(streamLoader.getDataForName("index.dat")) {
                currentOffset = stream.readUnsignedWord()
            };
            this.anInt1456 = stream2.readUnsignedWord();
            this.anInt1457 = stream2.readUnsignedWord();
            int num = stream2.readUnsignedByte();
            this.anIntArray1451 = new int[num];
            for (int j = 0; j < (num - 1); j++)
            {
                this.anIntArray1451[j + 1] = stream2.read3Bytes();
            }
            for (int k = 0; k < i; k++)
            {
                stream2.currentOffset += 2;
                stream.currentOffset += stream2.readUnsignedWord() * stream2.readUnsignedWord();
                stream2.currentOffset++;
            }
            this.anInt1454 = stream2.readUnsignedByte();
            this.anInt1455 = stream2.readUnsignedByte();
            this.anInt1452 = stream2.readUnsignedWord();
            this.anInt1453 = stream2.readUnsignedWord();
            int num4 = stream2.readUnsignedByte();
            int num5 = this.anInt1452 * this.anInt1453;
            this.aByteArray1450 = new byte[num5];
            switch (num4)
            {
                case 0:
                    for (int m = 0; m < num5; m++)
                    {
                        this.aByteArray1450[m] = stream.readSignedByte();
                    }
                    break;

                case 1:
                    for (int n = 0; n < this.anInt1452; n++)
                    {
                        for (int num8 = 0; num8 < this.anInt1453; num8++)
                        {
                            this.aByteArray1450[n + (num8 * this.anInt1452)] = stream.readSignedByte();
                        }
                    }
                    break;
            }
        }

        public void method356()
        {
            this.anInt1456 /= 2;
            this.anInt1457 /= 2;
            byte[] buffer = new byte[this.anInt1456 * this.anInt1457];
            int num = 0;
            for (int i = 0; i < this.anInt1453; i++)
            {
                for (int j = 0; j < this.anInt1452; j++)
                {
                    buffer[((j + this.anInt1454) >> 1) + (((i + this.anInt1455) >> 1) * this.anInt1456)] = this.aByteArray1450[num++];
                }
            }
            this.aByteArray1450 = buffer;
            this.anInt1452 = this.anInt1456;
            this.anInt1453 = this.anInt1457;
            this.anInt1454 = 0;
            this.anInt1455 = 0;
        }

        public void method357()
        {
            if ((this.anInt1452 != this.anInt1456) || (this.anInt1453 != this.anInt1457))
            {
                byte[] buffer = new byte[this.anInt1456 * this.anInt1457];
                int num = 0;
                for (int i = 0; i < this.anInt1453; i++)
                {
                    for (int j = 0; j < this.anInt1452; j++)
                    {
                        buffer[(j + this.anInt1454) + ((i + this.anInt1455) * this.anInt1456)] = this.aByteArray1450[num++];
                    }
                }
                this.aByteArray1450 = buffer;
                this.anInt1452 = this.anInt1456;
                this.anInt1453 = this.anInt1457;
                this.anInt1454 = 0;
                this.anInt1455 = 0;
            }
        }

        public void method358()
        {
            byte[] buffer = new byte[this.anInt1452 * this.anInt1453];
            int num = 0;
            for (int i = 0; i < this.anInt1453; i++)
            {
                for (int j = this.anInt1452 - 1; j >= 0; j--)
                {
                    buffer[num++] = this.aByteArray1450[j + (i * this.anInt1452)];
                }
            }
            this.aByteArray1450 = buffer;
            this.anInt1454 = (this.anInt1456 - this.anInt1452) - this.anInt1454;
        }

        public void method359()
        {
            byte[] buffer = new byte[this.anInt1452 * this.anInt1453];
            int num = 0;
            for (int i = this.anInt1453 - 1; i >= 0; i--)
            {
                for (int j = 0; j < this.anInt1452; j++)
                {
                    buffer[num++] = this.aByteArray1450[j + (i * this.anInt1452)];
                }
            }
            this.aByteArray1450 = buffer;
            this.anInt1455 = (this.anInt1457 - this.anInt1453) - this.anInt1455;
        }

        public void method360(int i, int j, int k)
        {
            for (int m = 0; m < this.anIntArray1451.Length; m++)
            {
                int num2 = (this.anIntArray1451[m] >> 0x10) & 0xff;
                num2 += i;
                if (num2 < 0)
                {
                    num2 = 0;
                }
                else if (num2 > 0xff)
                {
                    num2 = 0xff;
                }
                int num3 = (this.anIntArray1451[m] >> 8) & 0xff;
                num3 += j;
                if (num3 < 0)
                {
                    num3 = 0;
                }
                else if (num3 > 0xff)
                {
                    num3 = 0xff;
                }
                int num4 = this.anIntArray1451[m] & 0xff;
                num4 += k;
                if (num4 < 0)
                {
                    num4 = 0;
                }
                else if (num4 > 0xff)
                {
                    num4 = 0xff;
                }
                this.anIntArray1451[m] = ((num2 << 0x10) + (num3 << 8)) + num4;
            }
        }

        public void method361(int i, int k)
        {
            i += this.anInt1454;
            k += this.anInt1455;
            int num = i + (k * DrawingArea.width);
            int num2 = 0;
            int num3 = this.anInt1453;
            int l = this.anInt1452;
            int j = DrawingArea.width - l;
            int num6 = 0;
            if (k < DrawingArea.topY)
            {
                int num7 = DrawingArea.topY - k;
                num3 -= num7;
                k = DrawingArea.topY;
                num2 += num7 * l;
                num += num7 * DrawingArea.width;
            }
            if ((k + num3) > DrawingArea.bottomY)
            {
                num3 -= (k + num3) - DrawingArea.bottomY;
            }
            if (i < DrawingArea.topX)
            {
                int num8 = DrawingArea.topX - i;
                l -= num8;
                i = DrawingArea.topX;
                num2 += num8;
                num += num8;
                num6 += num8;
                j += num8;
            }
            if ((i + l) > DrawingArea.bottomX)
            {
                int num9 = (i + l) - DrawingArea.bottomX;
                l -= num9;
                num6 += num9;
                j += num9;
            }
            if ((l > 0) && (num3 > 0))
            {
                this.method362(num3, DrawingArea.pixels, this.aByteArray1450, j, num, l, num2, this.anIntArray1451, num6);
            }
        }

        private void method362(int i, int[] ai, byte[] abyte0, int j, int k, int l, int i1, int[] ai1, int j1)
        {
            int num = -(l >> 2);
            l = -(l & 3);
            for (int m = -i; m < 0; m++)
            {
                for (int n = num; n < 0; n++)
                {
                    byte num4 = abyte0[i1++];
                    if (num4 != 0)
                    {
                        ai[k++] = ai1[num4 & 0xff];
                    }
                    else
                    {
                        k++;
                    }
                    num4 = abyte0[i1++];
                    if (num4 != 0)
                    {
                        ai[k++] = ai1[num4 & 0xff];
                    }
                    else
                    {
                        k++;
                    }
                    num4 = abyte0[i1++];
                    if (num4 != 0)
                    {
                        ai[k++] = ai1[num4 & 0xff];
                    }
                    else
                    {
                        k++;
                    }
                    num4 = abyte0[i1++];
                    if (num4 != 0)
                    {
                        ai[k++] = ai1[num4 & 0xff];
                    }
                    else
                    {
                        k++;
                    }
                }
                for (int num5 = l; num5 < 0; num5++)
                {
                    byte num6 = abyte0[i1++];
                    if (num6 != 0)
                    {
                        ai[k++] = ai1[num6 & 0xff];
                    }
                    else
                    {
                        k++;
                    }
                }
                k += j;
                i1 += j1;
            }
        }
    }
}

