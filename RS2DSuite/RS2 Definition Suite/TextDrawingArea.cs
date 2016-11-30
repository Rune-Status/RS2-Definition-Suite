namespace RS2_Definition_Suite
{
    using CEBL;
    using System;

    [Serializable]
    public class TextDrawingArea : DrawingArea
    {
        public bool aBoolean1499 = false;
        public byte[][] aByteArrayArray1491 = new byte[0x100][];
        public int anInt1497;
        public int[] anIntArray1492 = new int[0x100];
        public int[] anIntArray1493 = new int[0x100];
        public int[] anIntArray1494 = new int[0x100];
        public int[] anIntArray1495 = new int[0x100];
        public int[] anIntArray1496 = new int[0x100];
        public Random aRandom1498 = new Random();

        public TextDrawingArea(bool flag, string s, StreamLoader streamLoader)
        {
            Stream stream = new Stream(streamLoader.getDataForName(s + ".dat"));
            Stream stream2 = new Stream(streamLoader.getDataForName("index.dat")) {
                currentOffset = stream.readUnsignedWord() + 4
            };
            int num = stream2.readUnsignedByte();
            if (num > 0)
            {
                stream2.currentOffset += 3 * (num - 1);
            }
            for (int i = 0; i < 0x100; i++)
            {
                this.anIntArray1494[i] = stream2.readUnsignedByte();
                this.anIntArray1495[i] = stream2.readUnsignedByte();
                int num3 = this.anIntArray1492[i] = stream2.readUnsignedWord();
                int num4 = this.anIntArray1493[i] = stream2.readUnsignedWord();
                int num5 = stream2.readUnsignedByte();
                int num6 = num3 * num4;
                this.aByteArrayArray1491[i] = new byte[num6];
                switch (num5)
                {
                    case 0:
                        for (int m = 0; m < num6; m++)
                        {
                            this.aByteArrayArray1491[i][m] = stream.readSignedByte();
                        }
                        break;

                    case 1:
                        for (int n = 0; n < num3; n++)
                        {
                            for (int num9 = 0; num9 < num4; num9++)
                            {
                                this.aByteArrayArray1491[i][n + (num9 * num3)] = stream.readSignedByte();
                            }
                        }
                        break;
                }
                if ((num4 > this.anInt1497) && (i < 0x80))
                {
                    this.anInt1497 = num4;
                }
                this.anIntArray1494[i] = 1;
                this.anIntArray1496[i] = num3 + 2;
                int num10 = 0;
                for (int j = num4 / 7; j < num4; j++)
                {
                    num10 += this.aByteArrayArray1491[i][j * num3];
                }
                if (num10 <= (num4 / 7))
                {
                    this.anIntArray1496[i]--;
                    this.anIntArray1494[i] = 0;
                }
                num10 = 0;
                for (int k = num4 / 7; k < num4; k++)
                {
                    num10 += this.aByteArrayArray1491[i][(num3 - 1) + (k * num3)];
                }
                if (num10 <= (num4 / 7))
                {
                    this.anIntArray1496[i]--;
                }
            }
            if (flag)
            {
                this.anIntArray1496[0x20] = this.anIntArray1496[0x49];
            }
            else
            {
                this.anIntArray1496[0x20] = this.anIntArray1496[0x69];
            }
        }

        public void drawChatInput(int i, int j, string s, int l, bool flag)
        {
            this.drawText(flag, j, i, s, l);
        }

        private void drawPixels(byte[] abyte0, int i, int j, int k, int l, int i1)
        {
            int num = i + (j * DrawingArea.width);
            int num2 = DrawingArea.width - k;
            int num3 = 0;
            int num4 = 0;
            if (j < DrawingArea.newTopY)
            {
                int num5 = DrawingArea.newTopY - j;
                l -= num5;
                j = DrawingArea.newTopY;
                num4 += num5 * k;
                num += num5 * DrawingArea.width;
            }
            if ((j + l) >= DrawingArea.newBottomY)
            {
                l -= ((j + l) - DrawingArea.newBottomY) + 1;
            }
            if (i < DrawingArea.newTopX)
            {
                int num6 = DrawingArea.newTopX - i;
                k -= num6;
                i = DrawingArea.newTopX;
                num4 += num6;
                num += num6;
                num3 += num6;
                num2 += num6;
            }
            if ((i + k) >= DrawingArea.newBottomX)
            {
                int num7 = ((i + k) - DrawingArea.newBottomX) + 1;
                k -= num7;
                num3 += num7;
                num2 += num7;
            }
            if ((k > 0) && (l > 0))
            {
                this.method393(DrawingArea.pixels, abyte0, i1, num4, num, k, l, num2, num3);
            }
        }

        private void drawPixels(int i, int j, byte[] abyte0, int k, int l, int i1, int j1)
        {
            int num = j + (l * DrawingArea.width);
            int num2 = DrawingArea.width - k;
            int num3 = 0;
            int num4 = 0;
            if (l < DrawingArea.topY)
            {
                int num5 = DrawingArea.topY - l;
                i1 -= num5;
                l = DrawingArea.topY;
                num4 += num5 * k;
                num += num5 * DrawingArea.width;
            }
            if ((l + i1) >= DrawingArea.bottomY)
            {
                i1 -= ((l + i1) - DrawingArea.bottomY) + 1;
            }
            if (j < DrawingArea.topX)
            {
                int num6 = DrawingArea.topX - j;
                k -= num6;
                j = DrawingArea.topX;
                num4 += num6;
                num += num6;
                num3 += num6;
                num2 += num6;
            }
            if ((j + k) >= DrawingArea.bottomX)
            {
                int num7 = ((j + k) - DrawingArea.bottomX) + 1;
                k -= num7;
                num3 += num7;
                num2 += num7;
            }
            if ((k > 0) && (i1 > 0))
            {
                this.method395(abyte0, i1, num, DrawingArea.pixels, num4, k, num3, num2, j1, i);
            }
        }

        public void drawText(int i, string s, int k, int l)
        {
            this.method385(i, s, k, l - (this.getStrictTextWidth(s) / 2));
        }

        public void drawText(bool shaded, int x, int j, string s, int y)
        {
            this.aBoolean1499 = false;
            int l = x;
            if (s != null)
            {
                y -= this.anInt1497;
                for (int i = 0; i < s.Length; i++)
                {
                    if (((s[i] == '@') && ((i + 4) < s.Length)) && (s[i + 4] == '@'))
                    {
                        int num3 = this.getColorByName(s.Substring(i + 1, 3));
                        if (num3 != -1)
                        {
                            j = num3;
                        }
                        i += 4;
                    }
                    else
                    {
                        char index = s[i];
                        if (index != ' ')
                        {
                            if (shaded)
                            {
                                this.drawPixels(this.aByteArrayArray1491[index], (x + this.anIntArray1494[index]) + 1, (y + this.anIntArray1495[index]) + 1, this.anIntArray1492[index], this.anIntArray1493[index], 0);
                            }
                            this.drawPixels(this.aByteArrayArray1491[index], x + this.anIntArray1494[index], y + this.anIntArray1495[index], this.anIntArray1492[index], this.anIntArray1493[index], j);
                        }
                        x += this.anIntArray1496[index];
                    }
                }
                if (this.aBoolean1499)
                {
                    DrawingArea.method339(y + ((int) (this.anInt1497 * 0.7)), 0x800000, x - l, l);
                }
            }
        }

        private int getColorByName(string s)
        {
            if (s.Equals("369"))
            {
                return 0x336699;
            }
            if (s.Equals("mon"))
            {
                return 0xff80;
            }
            if (s.Equals("red"))
            {
                return 0xff0000;
            }
            if (s.Equals("gre"))
            {
                return 0xff00;
            }
            if (s.Equals("blu"))
            {
                return 0xff;
            }
            if (s.Equals("yel"))
            {
                return 0xffff00;
            }
            if (s.Equals("cya"))
            {
                return 0xffff;
            }
            if (s.Equals("mag"))
            {
                return 0xff00ff;
            }
            if (s.Equals("whi"))
            {
                return 0xffffff;
            }
            if (s.Equals("bla"))
            {
                return 0;
            }
            if (s.Equals("lre"))
            {
                return 0xff9040;
            }
            if (s.Equals("dre"))
            {
                return 0x800000;
            }
            if (s.Equals("dbl"))
            {
                return 0x80;
            }
            if (s.Equals("or1"))
            {
                return 0xffb000;
            }
            if (s.Equals("or2"))
            {
                return 0xff7000;
            }
            if (s.Equals("or3"))
            {
                return 0xff3000;
            }
            if (s.Equals("gr1"))
            {
                return 0xc0ff00;
            }
            if (s.Equals("gr2"))
            {
                return 0x80ff00;
            }
            if (s.Equals("gr3"))
            {
                return 0x40ff00;
            }
            if (s.Equals("str"))
            {
                this.aBoolean1499 = true;
            }
            if (s.Equals("end"))
            {
                this.aBoolean1499 = false;
            }
            return -1;
        }

        public int getStrictTextWidth(string s)
        {
            if (s == null)
            {
                return 0;
            }
            int num = 0;
            for (int i = 0; i < s.Length; i++)
            {
                num += this.anIntArray1496[s[i]];
            }
            return num;
        }

        public int getTextWidth(string s)
        {
            if (s == null)
            {
                return 0;
            }
            int num = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (((s[i] == '@') && ((i + 4) < s.Length)) && (s[i + 4] == '@'))
                {
                    i += 4;
                }
                else
                {
                    num += this.anIntArray1496[s[i]];
                }
            }
            return num;
        }

        public void method380(string s, int i, int j, int k)
        {
            this.method385(j, s, k, i - this.getStrictTextWidth(s));
        }

        public void method382(int i, int j, string s, int l, bool flag)
        {
            this.drawText(flag, j - (this.getTextWidth(s) / 2), i, s, l);
        }

        public void method385(int i, string s, int j, int l)
        {
            if (s != null)
            {
                j -= this.anInt1497;
                for (int k = 0; k < s.Length; k++)
                {
                    char index = s[k];
                    if (index != ' ')
                    {
                        this.drawPixels(this.aByteArrayArray1491[index], l + this.anIntArray1494[index], j + this.anIntArray1495[index], this.anIntArray1492[index], this.anIntArray1493[index], i);
                    }
                    l += this.anIntArray1496[index];
                }
            }
        }

        public void method386(int i, string s, int j, int k, int l)
        {
            if (s != null)
            {
                j -= this.getStrictTextWidth(s) / 2;
                l -= this.anInt1497;
                for (int m = 0; m < s.Length; m++)
                {
                    char index = s[m];
                    if (index != ' ')
                    {
                        this.drawPixels(this.aByteArrayArray1491[index], j + this.anIntArray1494[index], (l + this.anIntArray1495[index]) + ((int) (Math.Sin((((double) m) / 2.0) + (((double) k) / 5.0)) * 5.0)), this.anIntArray1492[index], this.anIntArray1493[index], i);
                    }
                    j += this.anIntArray1496[index];
                }
            }
        }

        public void method387(int i, string s, int j, int k, int l)
        {
            if (s != null)
            {
                i -= this.getStrictTextWidth(s) / 2;
                k -= this.anInt1497;
                for (int m = 0; m < s.Length; m++)
                {
                    char index = s[m];
                    if (index != ' ')
                    {
                        this.drawPixels(this.aByteArrayArray1491[index], (i + this.anIntArray1494[index]) + ((int) (Math.Sin((((double) m) / 5.0) + (((double) j) / 5.0)) * 5.0)), (k + this.anIntArray1495[index]) + ((int) (Math.Sin((((double) m) / 3.0) + (((double) j) / 5.0)) * 5.0)), this.anIntArray1492[index], this.anIntArray1493[index], l);
                    }
                    i += this.anIntArray1496[index];
                }
            }
        }

        public void method388(int i, string s, int j, int k, int l, int i1)
        {
            if (s != null)
            {
                double num = 7.0 - (((double) i) / 8.0);
                if (num < 0.0)
                {
                    num = 0.0;
                }
                l -= this.getStrictTextWidth(s) / 2;
                k -= this.anInt1497;
                for (int m = 0; m < s.Length; m++)
                {
                    char index = s[m];
                    if (index != ' ')
                    {
                        this.drawPixels(this.aByteArrayArray1491[index], l + this.anIntArray1494[index], (k + this.anIntArray1495[index]) + ((int) (Math.Sin((((double) m) / 1.5) + j) * num)), this.anIntArray1492[index], this.anIntArray1493[index], i1);
                    }
                    l += this.anIntArray1496[index];
                }
            }
        }

        public void method390(int i, int j, string s, int k, int i1)
        {
            if (s != null)
            {
                this.aRandom1498 = new Random(k);
                int num = 0xc0 + (this.aRandom1498.Next() & 0x1f);
                i1 -= this.anInt1497;
                for (int m = 0; m < s.Length; m++)
                {
                    if (((s[m] == '@') && ((m + 4) < s.Length)) && (s[m + 4] == '@'))
                    {
                        int num3 = this.getColorByName(s.Substring(m + 1, m + 4));
                        if (num3 != -1)
                        {
                            j = num3;
                        }
                        m += 4;
                    }
                    else
                    {
                        char index = s[m];
                        if (index != ' ')
                        {
                            this.drawPixels(0xc0, (i + this.anIntArray1494[index]) + 1, this.aByteArrayArray1491[index], this.anIntArray1492[index], (i1 + this.anIntArray1495[index]) + 1, this.anIntArray1493[index], 0);
                            this.drawPixels(num, i + this.anIntArray1494[index], this.aByteArrayArray1491[index], this.anIntArray1492[index], i1 + this.anIntArray1495[index], this.anIntArray1493[index], j);
                        }
                        i += this.anIntArray1496[index];
                        if ((this.aRandom1498.Next() & 3) == 0)
                        {
                            i++;
                        }
                    }
                }
            }
        }

        private void method393(int[] ai, byte[] abyte0, int i, int j, int k, int l, int i1, int j1, int k1)
        {
            int num = -(l >> 2);
            l = -(l & 3);
            for (int m = -i1; m < 0; m++)
            {
                for (int n = num; n < 0; n++)
                {
                    if (abyte0[j++] != 0)
                    {
                        ai[k++] = i;
                    }
                    else
                    {
                        k++;
                    }
                    if (abyte0[j++] != 0)
                    {
                        ai[k++] = i;
                    }
                    else
                    {
                        k++;
                    }
                    if (abyte0[j++] != 0)
                    {
                        ai[k++] = i;
                    }
                    else
                    {
                        k++;
                    }
                    if (abyte0[j++] != 0)
                    {
                        ai[k++] = i;
                    }
                    else
                    {
                        k++;
                    }
                }
                for (int num4 = l; num4 < 0; num4++)
                {
                    if (abyte0[j++] != 0)
                    {
                        ai[k++] = i;
                    }
                    else
                    {
                        k++;
                    }
                }
                k += j1;
                j += k1;
            }
        }

        private void method395(byte[] abyte0, int i, int j, int[] ai, int l, int i1, int j1, int k1, int l1, int i2)
        {
            l1 = (((int) (((l1 & 0xff00ff) * i2) & 0xff00ff00L)) + (((l1 & 0xff00) * i2) & 0xff0000)) >> 8;
            i2 = 0x100 - i2;
            for (int k = -i; k < 0; k++)
            {
                for (int m = -i1; m < 0; m++)
                {
                    if (abyte0[l++] != 0)
                    {
                        int num3 = ai[j];
                        ai[j++] = ((int) (((((num3 & 0xff00ff) * i2) & 0xff00ff00L) + (((num3 & 0xff00) * i2) & 0xff0000)) >> 8)) + l1;
                    }
                    else
                    {
                        j++;
                    }
                }
                j += k1;
                l += j1;
            }
        }
    }
}

