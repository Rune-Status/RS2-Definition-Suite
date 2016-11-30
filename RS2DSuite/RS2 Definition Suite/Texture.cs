namespace RS2_Definition_Suite
{
    using CEBL;
    using System;

    public class Texture : DrawingArea
    {
        public static Background[] aBackgroundArray1474s = new Background[50];
        private static bool aBoolean1462 = false;
        private static bool aBoolean1463;
        public static bool aBoolean1464 = true;
        private static bool[] aBooleanArray1475 = new bool[50];
        public static int anInt1459 = -477;
        public static int anInt1465;
        private static int anInt1473;
        private static int anInt1477;
        public static int anInt1481;
        private static int[] anIntArray1468;
        public static int[] anIntArray1469;
        public static int[] anIntArray1470;
        public static int[] anIntArray1471;
        public static int[] anIntArray1472;
        private static int[] anIntArray1476 = new int[50];
        public static int[] anIntArray1480 = new int[50];
        public static int[] anIntArray1482 = new int[0x10000];
        private static int[][] anIntArrayArray1478;
        private static int[][] anIntArrayArray1479 = new int[50][];
        private static int[][] anIntArrayArray1483 = new int[50][];
        public static bool lowMem = true;
        public static int textureInt1;
        public static int textureInt2;

        public static void code()
        {
            anIntArray1468 = new int[0x200];
            anIntArray1469 = new int[0x800];
            anIntArray1470 = new int[0x800];
            anIntArray1471 = new int[0x800];
            for (int i = 1; i < 0x200; i++)
            {
                anIntArray1468[i] = 0x8000 / i;
            }
            for (int j = 1; j < 0x800; j++)
            {
                anIntArray1469[j] = 0x10000 / j;
            }
            for (int k = 0; k < 0x800; k++)
            {
                anIntArray1470[k] = (int) (65536.0 * Math.Sin(k * 0.0030679615));
                anIntArray1471[k] = (int) (65536.0 * Math.Cos(k * 0.0030679615));
            }
        }

        public static void method364()
        {
            anIntArray1472 = new int[DrawingArea.height];
            for (int i = 0; i < DrawingArea.height; i++)
            {
                anIntArray1472[i] = DrawingArea.width * i;
            }
            textureInt1 = DrawingArea.width / 2;
            textureInt2 = DrawingArea.height / 2;
        }

        public static void method365(int j, int k)
        {
            anIntArray1472 = new int[k];
            for (int i = 0; i < k; i++)
            {
                anIntArray1472[i] = j * i;
            }
            textureInt1 = j / 2;
            textureInt2 = k / 2;
        }

        public static void method366()
        {
            anIntArrayArray1478 = null;
            for (int i = 0; i < 50; i++)
            {
                anIntArrayArray1479[i] = null;
            }
        }

        public static void method367()
        {
            if (anIntArrayArray1478 == null)
            {
                int num;
                anInt1477 = 20;
                if (lowMem)
                {
                    anIntArrayArray1478 = new int[anInt1477][];
                    for (num = 0; num < anInt1477; num++)
                    {
                        anIntArrayArray1478[num] = new int[0x4000];
                    }
                }
                else
                {
                    anIntArrayArray1478 = new int[anInt1477][];
                }
                for (num = 0; num < anInt1477; num++)
                {
                    anIntArrayArray1478[num] = new int[0x10000];
                }
                for (int i = 0; i < 50; i++)
                {
                    anIntArrayArray1479[i] = null;
                }
            }
        }

        public static void method368(StreamLoader streamLoader)
        {
            anInt1473 = 0;
            for (int i = 0; i < 50; i++)
            {
                try
                {
                    aBackgroundArray1474s[i] = new Background(streamLoader, i.ToString(), 0);
                    if (lowMem && (aBackgroundArray1474s[i].anInt1456 == 0x80))
                    {
                        aBackgroundArray1474s[i].method356();
                    }
                    else
                    {
                        aBackgroundArray1474s[i].method357();
                    }
                    anInt1473++;
                }
                catch (Exception)
                {
                }
            }
        }

        public static int method369(int i)
        {
            if (anIntArray1476[i] != 0)
            {
                return anIntArray1476[i];
            }
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int length = anIntArrayArray1483[i].Length;
            for (int j = 0; j < length; j++)
            {
                num += (anIntArrayArray1483[i][j] >> 0x10) & 0xff;
                num2 += (anIntArrayArray1483[i][j] >> 8) & 0xff;
                num3 += anIntArrayArray1483[i][j] & 0xff;
            }
            int num6 = (((num / length) << 0x10) + ((num2 / length) << 8)) + (num3 / length);
            num6 = method373(num6, 1.4);
            if (num6 == 0)
            {
                num6 = 1;
            }
            anIntArray1476[i] = num6;
            return num6;
        }

        public static void method370(int i)
        {
            if (anIntArrayArray1479[i] != null)
            {
                anIntArrayArray1478[anInt1477++] = anIntArrayArray1479[i];
                anIntArrayArray1479[i] = null;
            }
        }

        private static int[] method371(int i)
        {
            int[] numArray;
            anIntArray1480[i] = anInt1481++;
            if (anIntArrayArray1479[i] != null)
            {
                return anIntArrayArray1479[i];
            }
            if (anInt1477 > 0)
            {
                numArray = anIntArrayArray1478[--anInt1477];
                anIntArrayArray1478[anInt1477] = null;
            }
            else
            {
                int num = 0;
                int index = -1;
                for (int k = 0; k < anInt1473; k++)
                {
                    if ((anIntArrayArray1479[k] != null) && ((anIntArray1480[k] < num) || (index == -1)))
                    {
                        num = anIntArray1480[k];
                        index = k;
                    }
                }
                numArray = anIntArrayArray1479[index];
                anIntArrayArray1479[index] = null;
            }
            anIntArrayArray1479[i] = numArray;
            Background background = aBackgroundArray1474s[i];
            int[] numArray2 = anIntArrayArray1483[i];
            if (lowMem)
            {
                aBooleanArray1475[i] = false;
                for (int m = 0; m < 0x1000; m++)
                {
                    int num5 = numArray[m] = numArray2[background.aByteArray1450[m]] & 0xf8f8ff;
                    if (num5 == 0)
                    {
                        aBooleanArray1475[i] = true;
                    }
                    numArray[0x1000 + m] = (num5 - (num5 >> 3)) & 0xf8f8ff;
                    numArray[0x2000 + m] = (num5 - (num5 >> 2)) & 0xf8f8ff;
                    numArray[0x3000 + m] = ((num5 - (num5 >> 2)) - (num5 >> 3)) & 0xf8f8ff;
                }
                return numArray;
            }
            if (background.anInt1452 == 0x40)
            {
                for (int n = 0; n < 0x80; n++)
                {
                    for (int num7 = 0; num7 < 0x80; num7++)
                    {
                        numArray[num7 + (n << 7)] = numArray2[background.aByteArray1450[(num7 >> 1) + ((n >> 1) << 6)]];
                    }
                }
            }
            else
            {
                for (int num8 = 0; num8 < 0x4000; num8++)
                {
                    numArray[num8] = numArray2[background.aByteArray1450[num8]];
                }
            }
            aBooleanArray1475[i] = false;
            for (int j = 0; j < 0x4000; j++)
            {
                numArray[j] &= 0xf8f8ff;
                int num10 = numArray[j];
                if (num10 == 0)
                {
                    aBooleanArray1475[i] = true;
                }
                numArray[0x4000 + j] = (num10 - (num10 >> 3)) & 0xf8f8ff;
                numArray[0x8000 + j] = (num10 - (num10 >> 2)) & 0xf8f8ff;
                numArray[0xc000 + j] = ((num10 - (num10 >> 2)) - (num10 >> 3)) & 0xf8f8ff;
            }
            return numArray;
        }

        public static void method372(double d)
        {
            d += (new Random().Next() * 0.03) - 0.015;
            int num = 0;
            for (int i = 0; i < 0x200; i++)
            {
                double num3 = (((double) (i / 8)) / 64.0) + 0.0078125;
                double num4 = (((double) (i & 7)) / 8.0) + 0.0625;
                for (int m = 0; m < 0x80; m++)
                {
                    double num6 = ((double) m) / 128.0;
                    double num7 = num6;
                    double num8 = num6;
                    double num9 = num6;
                    if (num4 != 0.0)
                    {
                        double num10;
                        if (num6 < 0.5)
                        {
                            num10 = num6 * (1.0 + num4);
                        }
                        else
                        {
                            num10 = (num6 + num4) - (num6 * num4);
                        }
                        double num11 = (2.0 * num6) - num10;
                        double num12 = num3 + 0.33333333333333331;
                        if (num12 > 1.0)
                        {
                            num12--;
                        }
                        double num13 = num3;
                        double num14 = num3 - 0.33333333333333331;
                        if (num14 < 0.0)
                        {
                            num14++;
                        }
                        if ((6.0 * num12) < 1.0)
                        {
                            num7 = num11 + (((num10 - num11) * 6.0) * num12);
                        }
                        else if ((2.0 * num12) < 1.0)
                        {
                            num7 = num10;
                        }
                        else if ((3.0 * num12) < 2.0)
                        {
                            num7 = num11 + (((num10 - num11) * (0.66666666666666663 - num12)) * 6.0);
                        }
                        else
                        {
                            num7 = num11;
                        }
                        if ((6.0 * num13) < 1.0)
                        {
                            num8 = num11 + (((num10 - num11) * 6.0) * num13);
                        }
                        else if ((2.0 * num13) < 1.0)
                        {
                            num8 = num10;
                        }
                        else if ((3.0 * num13) < 2.0)
                        {
                            num8 = num11 + (((num10 - num11) * (0.66666666666666663 - num13)) * 6.0);
                        }
                        else
                        {
                            num8 = num11;
                        }
                        if ((6.0 * num14) < 1.0)
                        {
                            num9 = num11 + (((num10 - num11) * 6.0) * num14);
                        }
                        else if ((2.0 * num14) < 1.0)
                        {
                            num9 = num10;
                        }
                        else if ((3.0 * num14) < 2.0)
                        {
                            num9 = num11 + (((num10 - num11) * (0.66666666666666663 - num14)) * 6.0);
                        }
                        else
                        {
                            num9 = num11;
                        }
                    }
                    int num15 = (int) (num7 * 256.0);
                    int num16 = (int) (num8 * 256.0);
                    int num17 = (int) (num9 * 256.0);
                    int num18 = ((num15 << 0x10) + (num16 << 8)) + num17;
                    num18 = method373(num18, d);
                    if (num18 == 0)
                    {
                        num18 = 1;
                    }
                    anIntArray1482[num++] = num18;
                }
            }
            for (int j = 0; j < 50; j++)
            {
                if (aBackgroundArray1474s[j] != null)
                {
                    int[] numArray = aBackgroundArray1474s[j].anIntArray1451;
                    anIntArrayArray1483[j] = new int[numArray.Length];
                    for (int n = 0; n < numArray.Length; n++)
                    {
                        anIntArrayArray1483[j][n] = method373(numArray[n], d);
                        if (((anIntArrayArray1483[j][n] & 0xf8f8ff) == 0) && (n != 0))
                        {
                            anIntArrayArray1483[j][n] = 1;
                        }
                    }
                }
            }
            for (int k = 0; k < 50; k++)
            {
                method370(k);
            }
        }

        private static int method373(int i, double d)
        {
            double x = ((double) (i >> 0x10)) / 256.0;
            double num2 = ((double) ((i >> 8) & 0xff)) / 256.0;
            double num3 = ((double) (i & 0xff)) / 256.0;
            x = Math.Pow(x, d);
            num2 = Math.Pow(num2, d);
            num3 = Math.Pow(num3, d);
            int num4 = (int) (x * 256.0);
            int num5 = (int) (num2 * 256.0);
            int num6 = (int) (num3 * 256.0);
            return (((num4 << 0x10) + (num5 << 8)) + num6);
        }

        public static void method374(int i, int j, int k, int l, int i1, int j1, int k1, int l1, int i2)
        {
            int num = 0;
            int num2 = 0;
            if (j != i)
            {
                num = ((i1 - l) << 0x10) / (j - i);
                num2 = ((l1 - k1) << 15) / (j - i);
            }
            int num3 = 0;
            int num4 = 0;
            if (k != j)
            {
                num3 = ((j1 - i1) << 0x10) / (k - j);
                num4 = ((i2 - l1) << 15) / (k - j);
            }
            int num5 = 0;
            int num6 = 0;
            if (k != i)
            {
                num5 = ((l - j1) << 0x10) / (i - k);
                num6 = ((k1 - i2) << 15) / (i - k);
            }
            if ((i <= j) && (i <= k))
            {
                if (i < DrawingArea.bottomY)
                {
                    if (j > DrawingArea.bottomY)
                    {
                        j = DrawingArea.bottomY;
                    }
                    if (k > DrawingArea.bottomY)
                    {
                        k = DrawingArea.bottomY;
                    }
                    if (j < k)
                    {
                        j1 = l = l << 0x10;
                        i2 = k1 = k1 << 15;
                        if (i < 0)
                        {
                            j1 -= num5 * i;
                            l -= num * i;
                            i2 -= num6 * i;
                            k1 -= num2 * i;
                            i = 0;
                        }
                        i1 = i1 << 0x10;
                        l1 = l1 << 15;
                        if (j < 0)
                        {
                            i1 -= num3 * j;
                            l1 -= num4 * j;
                            j = 0;
                        }
                        if (((i != j) && (num5 < num)) || ((i == j) && (num5 > num3)))
                        {
                            k -= j;
                            j -= i;
                            i = anIntArray1472[i];
                            while (--j >= 0)
                            {
                                method375(DrawingArea.pixels, i, j1 >> 0x10, l >> 0x10, i2 >> 7, k1 >> 7);
                                j1 += num5;
                                l += num;
                                i2 += num6;
                                k1 += num2;
                                i += DrawingArea.width;
                            }
                            while (--k >= 0)
                            {
                                method375(DrawingArea.pixels, i, j1 >> 0x10, i1 >> 0x10, i2 >> 7, l1 >> 7);
                                j1 += num5;
                                i1 += num3;
                                i2 += num6;
                                l1 += num4;
                                i += DrawingArea.width;
                            }
                        }
                        else
                        {
                            k -= j;
                            j -= i;
                            i = anIntArray1472[i];
                            while (--j >= 0)
                            {
                                method375(DrawingArea.pixels, i, l >> 0x10, j1 >> 0x10, k1 >> 7, i2 >> 7);
                                j1 += num5;
                                l += num;
                                i2 += num6;
                                k1 += num2;
                                i += DrawingArea.width;
                            }
                            while (--k >= 0)
                            {
                                method375(DrawingArea.pixels, i, i1 >> 0x10, j1 >> 0x10, l1 >> 7, i2 >> 7);
                                j1 += num5;
                                i1 += num3;
                                i2 += num6;
                                l1 += num4;
                                i += DrawingArea.width;
                            }
                        }
                    }
                    else
                    {
                        i1 = l = l << 0x10;
                        l1 = k1 = k1 << 15;
                        if (i < 0)
                        {
                            i1 -= num5 * i;
                            l -= num * i;
                            l1 -= num6 * i;
                            k1 -= num2 * i;
                            i = 0;
                        }
                        j1 = j1 << 0x10;
                        i2 = i2 << 15;
                        if (k < 0)
                        {
                            j1 -= num3 * k;
                            i2 -= num4 * k;
                            k = 0;
                        }
                        if (((i != k) && (num5 < num)) || ((i == k) && (num3 > num)))
                        {
                            j -= k;
                            k -= i;
                            i = anIntArray1472[i];
                            while (--k >= 0)
                            {
                                method375(DrawingArea.pixels, i, i1 >> 0x10, l >> 0x10, l1 >> 7, k1 >> 7);
                                i1 += num5;
                                l += num;
                                l1 += num6;
                                k1 += num2;
                                i += DrawingArea.width;
                            }
                            while (--j >= 0)
                            {
                                method375(DrawingArea.pixels, i, j1 >> 0x10, l >> 0x10, i2 >> 7, k1 >> 7);
                                j1 += num3;
                                l += num;
                                i2 += num4;
                                k1 += num2;
                                i += DrawingArea.width;
                            }
                        }
                        else
                        {
                            j -= k;
                            k -= i;
                            i = anIntArray1472[i];
                            while (--k >= 0)
                            {
                                method375(DrawingArea.pixels, i, l >> 0x10, i1 >> 0x10, k1 >> 7, l1 >> 7);
                                i1 += num5;
                                l += num;
                                l1 += num6;
                                k1 += num2;
                                i += DrawingArea.width;
                            }
                            while (--j >= 0)
                            {
                                method375(DrawingArea.pixels, i, l >> 0x10, j1 >> 0x10, k1 >> 7, i2 >> 7);
                                j1 += num3;
                                l += num;
                                i2 += num4;
                                k1 += num2;
                                i += DrawingArea.width;
                            }
                        }
                    }
                }
            }
            else if (j <= k)
            {
                if (j < DrawingArea.bottomY)
                {
                    if (k > DrawingArea.bottomY)
                    {
                        k = DrawingArea.bottomY;
                    }
                    if (i > DrawingArea.bottomY)
                    {
                        i = DrawingArea.bottomY;
                    }
                    if (k < i)
                    {
                        l = i1 = i1 << 0x10;
                        k1 = l1 = l1 << 15;
                        if (j < 0)
                        {
                            l -= num * j;
                            i1 -= num3 * j;
                            k1 -= num2 * j;
                            l1 -= num4 * j;
                            j = 0;
                        }
                        j1 = j1 << 0x10;
                        i2 = i2 << 15;
                        if (k < 0)
                        {
                            j1 -= num5 * k;
                            i2 -= num6 * k;
                            k = 0;
                        }
                        if (((j != k) && (num < num3)) || ((j == k) && (num > num5)))
                        {
                            i -= k;
                            k -= j;
                            j = anIntArray1472[j];
                            while (--k >= 0)
                            {
                                method375(DrawingArea.pixels, j, l >> 0x10, i1 >> 0x10, k1 >> 7, l1 >> 7);
                                l += num;
                                i1 += num3;
                                k1 += num2;
                                l1 += num4;
                                j += DrawingArea.width;
                            }
                            while (--i >= 0)
                            {
                                method375(DrawingArea.pixels, j, l >> 0x10, j1 >> 0x10, k1 >> 7, i2 >> 7);
                                l += num;
                                j1 += num5;
                                k1 += num2;
                                i2 += num6;
                                j += DrawingArea.width;
                            }
                        }
                        else
                        {
                            i -= k;
                            k -= j;
                            j = anIntArray1472[j];
                            while (--k >= 0)
                            {
                                method375(DrawingArea.pixels, j, i1 >> 0x10, l >> 0x10, l1 >> 7, k1 >> 7);
                                l += num;
                                i1 += num3;
                                k1 += num2;
                                l1 += num4;
                                j += DrawingArea.width;
                            }
                            while (--i >= 0)
                            {
                                method375(DrawingArea.pixels, j, j1 >> 0x10, l >> 0x10, i2 >> 7, k1 >> 7);
                                l += num;
                                j1 += num5;
                                k1 += num2;
                                i2 += num6;
                                j += DrawingArea.width;
                            }
                        }
                    }
                    else
                    {
                        j1 = i1 = i1 << 0x10;
                        i2 = l1 = l1 << 15;
                        if (j < 0)
                        {
                            j1 -= num * j;
                            i1 -= num3 * j;
                            i2 -= num2 * j;
                            l1 -= num4 * j;
                            j = 0;
                        }
                        l = l << 0x10;
                        k1 = k1 << 15;
                        if (i < 0)
                        {
                            l -= num5 * i;
                            k1 -= num6 * i;
                            i = 0;
                        }
                        if (num < num3)
                        {
                            k -= i;
                            i -= j;
                            j = anIntArray1472[j];
                            while (--i >= 0)
                            {
                                method375(DrawingArea.pixels, j, j1 >> 0x10, i1 >> 0x10, i2 >> 7, l1 >> 7);
                                j1 += num;
                                i1 += num3;
                                i2 += num2;
                                l1 += num4;
                                j += DrawingArea.width;
                            }
                            while (--k >= 0)
                            {
                                method375(DrawingArea.pixels, j, l >> 0x10, i1 >> 0x10, k1 >> 7, l1 >> 7);
                                l += num5;
                                i1 += num3;
                                k1 += num6;
                                l1 += num4;
                                j += DrawingArea.width;
                            }
                        }
                        else
                        {
                            k -= i;
                            i -= j;
                            j = anIntArray1472[j];
                            while (--i >= 0)
                            {
                                method375(DrawingArea.pixels, j, i1 >> 0x10, j1 >> 0x10, l1 >> 7, i2 >> 7);
                                j1 += num;
                                i1 += num3;
                                i2 += num2;
                                l1 += num4;
                                j += DrawingArea.width;
                            }
                            while (--k >= 0)
                            {
                                method375(DrawingArea.pixels, j, i1 >> 0x10, l >> 0x10, l1 >> 7, k1 >> 7);
                                l += num5;
                                i1 += num3;
                                k1 += num6;
                                l1 += num4;
                                j += DrawingArea.width;
                            }
                        }
                    }
                }
            }
            else if (k < DrawingArea.bottomY)
            {
                if (i > DrawingArea.bottomY)
                {
                    i = DrawingArea.bottomY;
                }
                if (j > DrawingArea.bottomY)
                {
                    j = DrawingArea.bottomY;
                }
                if (i < j)
                {
                    i1 = j1 = j1 << 0x10;
                    l1 = i2 = i2 << 15;
                    if (k < 0)
                    {
                        i1 -= num3 * k;
                        j1 -= num5 * k;
                        l1 -= num4 * k;
                        i2 -= num6 * k;
                        k = 0;
                    }
                    l = l << 0x10;
                    k1 = k1 << 15;
                    if (i < 0)
                    {
                        l -= num * i;
                        k1 -= num2 * i;
                        i = 0;
                    }
                    if (num3 < num5)
                    {
                        j -= i;
                        i -= k;
                        k = anIntArray1472[k];
                        while (--i >= 0)
                        {
                            method375(DrawingArea.pixels, k, i1 >> 0x10, j1 >> 0x10, l1 >> 7, i2 >> 7);
                            i1 += num3;
                            j1 += num5;
                            l1 += num4;
                            i2 += num6;
                            k += DrawingArea.width;
                        }
                        while (--j >= 0)
                        {
                            method375(DrawingArea.pixels, k, i1 >> 0x10, l >> 0x10, l1 >> 7, k1 >> 7);
                            i1 += num3;
                            l += num;
                            l1 += num4;
                            k1 += num2;
                            k += DrawingArea.width;
                        }
                    }
                    else
                    {
                        j -= i;
                        i -= k;
                        k = anIntArray1472[k];
                        while (--i >= 0)
                        {
                            method375(DrawingArea.pixels, k, j1 >> 0x10, i1 >> 0x10, i2 >> 7, l1 >> 7);
                            i1 += num3;
                            j1 += num5;
                            l1 += num4;
                            i2 += num6;
                            k += DrawingArea.width;
                        }
                        while (--j >= 0)
                        {
                            method375(DrawingArea.pixels, k, l >> 0x10, i1 >> 0x10, k1 >> 7, l1 >> 7);
                            i1 += num3;
                            l += num;
                            l1 += num4;
                            k1 += num2;
                            k += DrawingArea.width;
                        }
                    }
                }
                else
                {
                    l = j1 = j1 << 0x10;
                    k1 = i2 = i2 << 15;
                    if (k < 0)
                    {
                        l -= num3 * k;
                        j1 -= num5 * k;
                        k1 -= num4 * k;
                        i2 -= num6 * k;
                        k = 0;
                    }
                    i1 = i1 << 0x10;
                    l1 = l1 << 15;
                    if (j < 0)
                    {
                        i1 -= num * j;
                        l1 -= num2 * j;
                        j = 0;
                    }
                    if (num3 < num5)
                    {
                        i -= j;
                        j -= k;
                        k = anIntArray1472[k];
                        while (--j >= 0)
                        {
                            method375(DrawingArea.pixels, k, l >> 0x10, j1 >> 0x10, k1 >> 7, i2 >> 7);
                            l += num3;
                            j1 += num5;
                            k1 += num4;
                            i2 += num6;
                            k += DrawingArea.width;
                        }
                        while (--i >= 0)
                        {
                            method375(DrawingArea.pixels, k, i1 >> 0x10, j1 >> 0x10, l1 >> 7, i2 >> 7);
                            i1 += num;
                            j1 += num5;
                            l1 += num2;
                            i2 += num6;
                            k += DrawingArea.width;
                        }
                    }
                    else
                    {
                        i -= j;
                        j -= k;
                        k = anIntArray1472[k];
                        while (--j >= 0)
                        {
                            method375(DrawingArea.pixels, k, j1 >> 0x10, l >> 0x10, i2 >> 7, k1 >> 7);
                            l += num3;
                            j1 += num5;
                            k1 += num4;
                            i2 += num6;
                            k += DrawingArea.width;
                        }
                        while (--i >= 0)
                        {
                            method375(DrawingArea.pixels, k, j1 >> 0x10, i1 >> 0x10, i2 >> 7, l1 >> 7);
                            i1 += num;
                            j1 += num5;
                            l1 += num2;
                            i2 += num6;
                            k += DrawingArea.width;
                        }
                    }
                }
            }
        }

        private static void method375(int[] ai, int i, int l, int i1, int j1, int k1)
        {
            int num;
            int num2;
            if (aBoolean1464)
            {
                int num3;
                if (aBoolean1462)
                {
                    if ((i1 - l) > 3)
                    {
                        num3 = (k1 - j1) / (i1 - l);
                    }
                    else
                    {
                        num3 = 0;
                    }
                    if (i1 > DrawingArea.centerX)
                    {
                        i1 = DrawingArea.centerX;
                    }
                    if (l < 0)
                    {
                        j1 -= l * num3;
                        l = 0;
                    }
                    if (l >= i1)
                    {
                        return;
                    }
                    i += l;
                    num2 = (i1 - l) >> 2;
                    num3 = num3 << 2;
                }
                else
                {
                    if (l >= i1)
                    {
                        return;
                    }
                    i += l;
                    num2 = (i1 - l) >> 2;
                    if (num2 > 0)
                    {
                        num3 = ((k1 - j1) * anIntArray1468[num2]) >> 15;
                    }
                    else
                    {
                        num3 = 0;
                    }
                }
                if (anInt1465 == 0)
                {
                    while (--num2 >= 0)
                    {
                        num = anIntArray1482[j1 >> 8];
                        j1 += num3;
                        ai[i++] = num;
                        ai[i++] = num;
                        ai[i++] = num;
                        ai[i++] = num;
                    }
                    num2 = (i1 - l) & 3;
                    if (num2 > 0)
                    {
                        num = anIntArray1482[j1 >> 8];
                        do
                        {
                            ai[i++] = num;
                        }
                        while (--num2 > 0);
                    }
                }
                else
                {
                    int num4 = anInt1465;
                    int num5 = 0x100 - anInt1465;
                    while (--num2 >= 0)
                    {
                        num = anIntArray1482[j1 >> 8];
                        j1 += num3;
                        num = ((((num & 0xff00ff) * num5) >> 8) & 0xff00ff) + ((((num & 0xff00) * num5) >> 8) & 0xff00);
                        ai[i++] = (num + ((((ai[i] & 0xff00ff) * num4) >> 8) & 0xff00ff)) + ((((ai[i] & 0xff00) * num4) >> 8) & 0xff00);
                        ai[i++] = (num + ((((ai[i] & 0xff00ff) * num4) >> 8) & 0xff00ff)) + ((((ai[i] & 0xff00) * num4) >> 8) & 0xff00);
                        ai[i++] = (num + ((((ai[i] & 0xff00ff) * num4) >> 8) & 0xff00ff)) + ((((ai[i] & 0xff00) * num4) >> 8) & 0xff00);
                        ai[i++] = (num + ((((ai[i] & 0xff00ff) * num4) >> 8) & 0xff00ff)) + ((((ai[i] & 0xff00) * num4) >> 8) & 0xff00);
                    }
                    num2 = (i1 - l) & 3;
                    if (num2 > 0)
                    {
                        num = anIntArray1482[j1 >> 8];
                        num = ((((num & 0xff00ff) * num5) >> 8) & 0xff00ff) + ((((num & 0xff00) * num5) >> 8) & 0xff00);
                        do
                        {
                            ai[i++] = (num + ((((ai[i] & 0xff00ff) * num4) >> 8) & 0xff00ff)) + ((((ai[i] & 0xff00) * num4) >> 8) & 0xff00);
                        }
                        while (--num2 > 0);
                    }
                }
            }
            else if (l < i1)
            {
                int num6 = (k1 - j1) / (i1 - l);
                /*if (aBoolean1462)
                {
                    if (i1 > DrawingArea.centerX)
                    {
                        i1 = DrawingArea.centerX;
                    }
                    if (l < 0)
                    {
                        j1 -= l * num6;
                        l = 0;
                    }
                    if (l >= i1)
                    {
                        return;
                    }
                }*/
                i += l;
                num2 = i1 - l;
                if (anInt1465 == 0)
                {
                    do
                    {
                        ai[i++] = anIntArray1482[j1 >> 8];
                        j1 += num6;
                    }
                    while (--num2 > 0);
                }
                else
                {
                    int num7 = anInt1465;
                    int num8 = 0x100 - anInt1465;
                    do
                    {
                        num = anIntArray1482[j1 >> 8];
                        j1 += num6;
                        num = ((((num & 0xff00ff) * num8) >> 8) & 0xff00ff) + ((((num & 0xff00) * num8) >> 8) & 0xff00);
                        ai[i++] = (num + ((((ai[i] & 0xff00ff) * num7) >> 8) & 0xff00ff)) + ((((ai[i] & 0xff00) * num7) >> 8) & 0xff00);
                    }
                    while (--num2 > 0);
                }
            }
        }

        public static void method376(int i, int j, int k, int l, int i1, int j1, int k1)
        {
            int num = 0;
            if (j != i)
            {
                num = ((i1 - l) << 0x10) / (j - i);
            }
            int num2 = 0;
            if (k != j)
            {
                num2 = ((j1 - i1) << 0x10) / (k - j);
            }
            int num3 = 0;
            if (k != i)
            {
                num3 = ((l - j1) << 0x10) / (i - k);
            }
            if ((i <= j) && (i <= k))
            {
                if (i < DrawingArea.bottomY)
                {
                    if (j > DrawingArea.bottomY)
                    {
                        j = DrawingArea.bottomY;
                    }
                    if (k > DrawingArea.bottomY)
                    {
                        k = DrawingArea.bottomY;
                    }
                    if (j < k)
                    {
                        j1 = l = l << 0x10;
                        if (i < 0)
                        {
                            j1 -= num3 * i;
                            l -= num * i;
                            i = 0;
                        }
                        i1 = i1 << 0x10;
                        if (j < 0)
                        {
                            i1 -= num2 * j;
                            j = 0;
                        }
                        if (((i != j) && (num3 < num)) || ((i == j) && (num3 > num2)))
                        {
                            k -= j;
                            j -= i;
                            i = anIntArray1472[i];
                            while (--j >= 0)
                            {
                                method377(DrawingArea.pixels, i, k1, j1 >> 0x10, l >> 0x10);
                                j1 += num3;
                                l += num;
                                i += DrawingArea.width;
                            }
                            while (--k >= 0)
                            {
                                method377(DrawingArea.pixels, i, k1, j1 >> 0x10, i1 >> 0x10);
                                j1 += num3;
                                i1 += num2;
                                i += DrawingArea.width;
                            }
                        }
                        else
                        {
                            k -= j;
                            j -= i;
                            i = anIntArray1472[i];
                            while (--j >= 0)
                            {
                                method377(DrawingArea.pixels, i, k1, l >> 0x10, j1 >> 0x10);
                                j1 += num3;
                                l += num;
                                i += DrawingArea.width;
                            }
                            while (--k >= 0)
                            {
                                method377(DrawingArea.pixels, i, k1, i1 >> 0x10, j1 >> 0x10);
                                j1 += num3;
                                i1 += num2;
                                i += DrawingArea.width;
                            }
                        }
                    }
                    else
                    {
                        i1 = l = l << 0x10;
                        if (i < 0)
                        {
                            i1 -= num3 * i;
                            l -= num * i;
                            i = 0;
                        }
                        j1 = j1 << 0x10;
                        if (k < 0)
                        {
                            j1 -= num2 * k;
                            k = 0;
                        }
                        if (((i != k) && (num3 < num)) || ((i == k) && (num2 > num)))
                        {
                            j -= k;
                            k -= i;
                            i = anIntArray1472[i];
                            while (--k >= 0)
                            {
                                method377(DrawingArea.pixels, i, k1, i1 >> 0x10, l >> 0x10);
                                i1 += num3;
                                l += num;
                                i += DrawingArea.width;
                            }
                            while (--j >= 0)
                            {
                                method377(DrawingArea.pixels, i, k1, j1 >> 0x10, l >> 0x10);
                                j1 += num2;
                                l += num;
                                i += DrawingArea.width;
                            }
                        }
                        else
                        {
                            j -= k;
                            k -= i;
                            i = anIntArray1472[i];
                            while (--k >= 0)
                            {
                                method377(DrawingArea.pixels, i, k1, l >> 0x10, i1 >> 0x10);
                                i1 += num3;
                                l += num;
                                i += DrawingArea.width;
                            }
                            while (--j >= 0)
                            {
                                method377(DrawingArea.pixels, i, k1, l >> 0x10, j1 >> 0x10);
                                j1 += num2;
                                l += num;
                                i += DrawingArea.width;
                            }
                        }
                    }
                }
            }
            else if (j <= k)
            {
                if (j < DrawingArea.bottomY)
                {
                    if (k > DrawingArea.bottomY)
                    {
                        k = DrawingArea.bottomY;
                    }
                    if (i > DrawingArea.bottomY)
                    {
                        i = DrawingArea.bottomY;
                    }
                    if (k < i)
                    {
                        l = i1 = i1 << 0x10;
                        if (j < 0)
                        {
                            l -= num * j;
                            i1 -= num2 * j;
                            j = 0;
                        }
                        j1 = j1 << 0x10;
                        if (k < 0)
                        {
                            j1 -= num3 * k;
                            k = 0;
                        }
                        if (((j != k) && (num < num2)) || ((j == k) && (num > num3)))
                        {
                            i -= k;
                            k -= j;
                            j = anIntArray1472[j];
                            while (--k >= 0)
                            {
                                method377(DrawingArea.pixels, j, k1, l >> 0x10, i1 >> 0x10);
                                l += num;
                                i1 += num2;
                                j += DrawingArea.width;
                            }
                            while (--i >= 0)
                            {
                                method377(DrawingArea.pixels, j, k1, l >> 0x10, j1 >> 0x10);
                                l += num;
                                j1 += num3;
                                j += DrawingArea.width;
                            }
                        }
                        else
                        {
                            i -= k;
                            k -= j;
                            j = anIntArray1472[j];
                            while (--k >= 0)
                            {
                                method377(DrawingArea.pixels, j, k1, i1 >> 0x10, l >> 0x10);
                                l += num;
                                i1 += num2;
                                j += DrawingArea.width;
                            }
                            while (--i >= 0)
                            {
                                method377(DrawingArea.pixels, j, k1, j1 >> 0x10, l >> 0x10);
                                l += num;
                                j1 += num3;
                                j += DrawingArea.width;
                            }
                        }
                    }
                    else
                    {
                        j1 = i1 = i1 << 0x10;
                        if (j < 0)
                        {
                            j1 -= num * j;
                            i1 -= num2 * j;
                            j = 0;
                        }
                        l = l << 0x10;
                        if (i < 0)
                        {
                            l -= num3 * i;
                            i = 0;
                        }
                        if (num < num2)
                        {
                            k -= i;
                            i -= j;
                            j = anIntArray1472[j];
                            while (--i >= 0)
                            {
                                method377(DrawingArea.pixels, j, k1, j1 >> 0x10, i1 >> 0x10);
                                j1 += num;
                                i1 += num2;
                                j += DrawingArea.width;
                            }
                            while (--k >= 0)
                            {
                                method377(DrawingArea.pixels, j, k1, l >> 0x10, i1 >> 0x10);
                                l += num3;
                                i1 += num2;
                                j += DrawingArea.width;
                            }
                        }
                        else
                        {
                            k -= i;
                            i -= j;
                            j = anIntArray1472[j];
                            while (--i >= 0)
                            {
                                method377(DrawingArea.pixels, j, k1, i1 >> 0x10, j1 >> 0x10);
                                j1 += num;
                                i1 += num2;
                                j += DrawingArea.width;
                            }
                            while (--k >= 0)
                            {
                                method377(DrawingArea.pixels, j, k1, i1 >> 0x10, l >> 0x10);
                                l += num3;
                                i1 += num2;
                                j += DrawingArea.width;
                            }
                        }
                    }
                }
            }
            else if (k < DrawingArea.bottomY)
            {
                if (i > DrawingArea.bottomY)
                {
                    i = DrawingArea.bottomY;
                }
                if (j > DrawingArea.bottomY)
                {
                    j = DrawingArea.bottomY;
                }
                if (i < j)
                {
                    i1 = j1 = j1 << 0x10;
                    if (k < 0)
                    {
                        i1 -= num2 * k;
                        j1 -= num3 * k;
                        k = 0;
                    }
                    l = l << 0x10;
                    if (i < 0)
                    {
                        l -= num * i;
                        i = 0;
                    }
                    if (num2 < num3)
                    {
                        j -= i;
                        i -= k;
                        k = anIntArray1472[k];
                        while (--i >= 0)
                        {
                            method377(DrawingArea.pixels, k, k1, i1 >> 0x10, j1 >> 0x10);
                            i1 += num2;
                            j1 += num3;
                            k += DrawingArea.width;
                        }
                        while (--j >= 0)
                        {
                            method377(DrawingArea.pixels, k, k1, i1 >> 0x10, l >> 0x10);
                            i1 += num2;
                            l += num;
                            k += DrawingArea.width;
                        }
                    }
                    else
                    {
                        j -= i;
                        i -= k;
                        k = anIntArray1472[k];
                        while (--i >= 0)
                        {
                            method377(DrawingArea.pixels, k, k1, j1 >> 0x10, i1 >> 0x10);
                            i1 += num2;
                            j1 += num3;
                            k += DrawingArea.width;
                        }
                        while (--j >= 0)
                        {
                            method377(DrawingArea.pixels, k, k1, l >> 0x10, i1 >> 0x10);
                            i1 += num2;
                            l += num;
                            k += DrawingArea.width;
                        }
                    }
                }
                else
                {
                    l = j1 = j1 << 0x10;
                    if (k < 0)
                    {
                        l -= num2 * k;
                        j1 -= num3 * k;
                        k = 0;
                    }
                    i1 = i1 << 0x10;
                    if (j < 0)
                    {
                        i1 -= num * j;
                        j = 0;
                    }
                    if (num2 < num3)
                    {
                        i -= j;
                        j -= k;
                        k = anIntArray1472[k];
                        while (--j >= 0)
                        {
                            method377(DrawingArea.pixels, k, k1, l >> 0x10, j1 >> 0x10);
                            l += num2;
                            j1 += num3;
                            k += DrawingArea.width;
                        }
                        while (--i >= 0)
                        {
                            method377(DrawingArea.pixels, k, k1, i1 >> 0x10, j1 >> 0x10);
                            i1 += num;
                            j1 += num3;
                            k += DrawingArea.width;
                        }
                    }
                    else
                    {
                        i -= j;
                        j -= k;
                        k = anIntArray1472[k];
                        while (--j >= 0)
                        {
                            method377(DrawingArea.pixels, k, k1, j1 >> 0x10, l >> 0x10);
                            l += num2;
                            j1 += num3;
                            k += DrawingArea.width;
                        }
                        while (--i >= 0)
                        {
                            method377(DrawingArea.pixels, k, k1, j1 >> 0x10, i1 >> 0x10);
                            i1 += num;
                            j1 += num3;
                            k += DrawingArea.width;
                        }
                    }
                }
            }
        }

        private static void method377(int[] ai, int i, int j, int l, int i1)
        {
            /*if (aBoolean1462)
            {
                if (i1 > DrawingArea.centerX)
                {
                    i1 = DrawingArea.centerX;
                }
                if (l < 0)
                {
                    l = 0;
                }
            }*/
            if (l < i1)
            {
                i += l;
                int num = (i1 - l) >> 2;
                if (anInt1465 == 0)
                {
                    while (--num >= 0)
                    {
                        ai[i++] = j;
                        ai[i++] = j;
                        ai[i++] = j;
                        ai[i++] = j;
                    }
                    num = (i1 - l) & 3;
                    while (--num >= 0)
                    {
                        ai[i++] = j;
                    }
                }
                else
                {
                    int num2 = anInt1465;
                    int num3 = 0x100 - anInt1465;
                    j = ((((j & 0xff00ff) * num3) >> 8) & 0xff00ff) + ((((j & 0xff00) * num3) >> 8) & 0xff00);
                    while (--num >= 0)
                    {
                        ai[i++] = (j + ((((ai[i] & 0xff00ff) * num2) >> 8) & 0xff00ff)) + ((((ai[i] & 0xff00) * num2) >> 8) & 0xff00);
                        ai[i++] = (j + ((((ai[i] & 0xff00ff) * num2) >> 8) & 0xff00ff)) + ((((ai[i] & 0xff00) * num2) >> 8) & 0xff00);
                        ai[i++] = (j + ((((ai[i] & 0xff00ff) * num2) >> 8) & 0xff00ff)) + ((((ai[i] & 0xff00) * num2) >> 8) & 0xff00);
                        ai[i++] = (j + ((((ai[i] & 0xff00ff) * num2) >> 8) & 0xff00ff)) + ((((ai[i] & 0xff00) * num2) >> 8) & 0xff00);
                    }
                    num = (i1 - l) & 3;
                    while (--num >= 0)
                    {
                        ai[i++] = (j + ((((ai[i] & 0xff00ff) * num2) >> 8) & 0xff00ff)) + ((((ai[i] & 0xff00) * num2) >> 8) & 0xff00);
                    }
                }
            }
        }

        public static void method378(int i, int j, int k, int l, int i1, int j1, int k1, int l1, int i2, int j2, int k2, int l2, int i3, int j3, int k3, int l3, int i4, int j4, int k4)
        {
            int[] numArray = method371(k4);
            aBoolean1463 = !aBooleanArray1475[k4];
            k2 = j2 - k2;
            j3 = i3 - j3;
            i4 = l3 - i4;
            l2 -= j2;
            k3 -= i3;
            j4 -= l3;
            int num = ((l2 * i3) - (k3 * j2)) << 14;
            int num2 = ((k3 * l3) - (j4 * i3)) << 8;
            int num3 = ((j4 * j2) - (l2 * l3)) << 5;
            int num4 = ((k2 * i3) - (j3 * j2)) << 14;
            int num5 = ((j3 * l3) - (i4 * i3)) << 8;
            int num6 = ((i4 * j2) - (k2 * l3)) << 5;
            int num7 = ((j3 * l2) - (k2 * k3)) << 14;
            int num8 = ((i4 * k3) - (j3 * j4)) << 8;
            int num9 = ((k2 * j4) - (i4 * l2)) << 5;
            int num10 = 0;
            int num11 = 0;
            if (j != i)
            {
                num10 = ((i1 - l) << 0x10) / (j - i);
                num11 = ((l1 - k1) << 0x10) / (j - i);
            }
            int num12 = 0;
            int num13 = 0;
            if (k != j)
            {
                num12 = ((j1 - i1) << 0x10) / (k - j);
                num13 = ((i2 - l1) << 0x10) / (k - j);
            }
            int num14 = 0;
            int num15 = 0;
            if (k != i)
            {
                num14 = ((l - j1) << 0x10) / (i - k);
                num15 = ((k1 - i2) << 0x10) / (i - k);
            }
            if ((i <= j) && (i <= k))
            {
                if (i < DrawingArea.bottomY)
                {
                    if (j > DrawingArea.bottomY)
                    {
                        j = DrawingArea.bottomY;
                    }
                    if (k > DrawingArea.bottomY)
                    {
                        k = DrawingArea.bottomY;
                    }
                    if (j < k)
                    {
                        j1 = l = l << 0x10;
                        i2 = k1 = k1 << 0x10;
                        if (i < 0)
                        {
                            j1 -= num14 * i;
                            l -= num10 * i;
                            i2 -= num15 * i;
                            k1 -= num11 * i;
                            i = 0;
                        }
                        i1 = i1 << 0x10;
                        l1 = l1 << 0x10;
                        if (j < 0)
                        {
                            i1 -= num12 * j;
                            l1 -= num13 * j;
                            j = 0;
                        }
                        int num16 = i - textureInt2;
                        num += num3 * num16;
                        num4 += num6 * num16;
                        num7 += num9 * num16;
                        if (((i != j) && (num14 < num10)) || ((i == j) && (num14 > num12)))
                        {
                            k -= j;
                            j -= i;
                            i = anIntArray1472[i];
                            while (--j >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, i, j1 >> 0x10, l >> 0x10, i2 >> 8, k1 >> 8, num, num4, num7, num2, num5, num8);
                                j1 += num14;
                                l += num10;
                                i2 += num15;
                                k1 += num11;
                                i += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                            while (--k >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, i, j1 >> 0x10, i1 >> 0x10, i2 >> 8, l1 >> 8, num, num4, num7, num2, num5, num8);
                                j1 += num14;
                                i1 += num12;
                                i2 += num15;
                                l1 += num13;
                                i += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                        }
                        else
                        {
                            k -= j;
                            j -= i;
                            i = anIntArray1472[i];
                            while (--j >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, i, l >> 0x10, j1 >> 0x10, k1 >> 8, i2 >> 8, num, num4, num7, num2, num5, num8);
                                j1 += num14;
                                l += num10;
                                i2 += num15;
                                k1 += num11;
                                i += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                            while (--k >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, i, i1 >> 0x10, j1 >> 0x10, l1 >> 8, i2 >> 8, num, num4, num7, num2, num5, num8);
                                j1 += num14;
                                i1 += num12;
                                i2 += num15;
                                l1 += num13;
                                i += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                        }
                    }
                    else
                    {
                        i1 = l = l << 0x10;
                        l1 = k1 = k1 << 0x10;
                        if (i < 0)
                        {
                            i1 -= num14 * i;
                            l -= num10 * i;
                            l1 -= num15 * i;
                            k1 -= num11 * i;
                            i = 0;
                        }
                        j1 = j1 << 0x10;
                        i2 = i2 << 0x10;
                        if (k < 0)
                        {
                            j1 -= num12 * k;
                            i2 -= num13 * k;
                            k = 0;
                        }
                        int num17 = i - textureInt2;
                        num += num3 * num17;
                        num4 += num6 * num17;
                        num7 += num9 * num17;
                        if (((i != k) && (num14 < num10)) || ((i == k) && (num12 > num10)))
                        {
                            j -= k;
                            k -= i;
                            i = anIntArray1472[i];
                            while (--k >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, i, i1 >> 0x10, l >> 0x10, l1 >> 8, k1 >> 8, num, num4, num7, num2, num5, num8);
                                i1 += num14;
                                l += num10;
                                l1 += num15;
                                k1 += num11;
                                i += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                            while (--j >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, i, j1 >> 0x10, l >> 0x10, i2 >> 8, k1 >> 8, num, num4, num7, num2, num5, num8);
                                j1 += num12;
                                l += num10;
                                i2 += num13;
                                k1 += num11;
                                i += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                        }
                        else
                        {
                            j -= k;
                            k -= i;
                            i = anIntArray1472[i];
                            while (--k >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, i, l >> 0x10, i1 >> 0x10, k1 >> 8, l1 >> 8, num, num4, num7, num2, num5, num8);
                                i1 += num14;
                                l += num10;
                                l1 += num15;
                                k1 += num11;
                                i += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                            while (--j >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, i, l >> 0x10, j1 >> 0x10, k1 >> 8, i2 >> 8, num, num4, num7, num2, num5, num8);
                                j1 += num12;
                                l += num10;
                                i2 += num13;
                                k1 += num11;
                                i += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                        }
                    }
                }
            }
            else if (j <= k)
            {
                if (j < DrawingArea.bottomY)
                {
                    if (k > DrawingArea.bottomY)
                    {
                        k = DrawingArea.bottomY;
                    }
                    if (i > DrawingArea.bottomY)
                    {
                        i = DrawingArea.bottomY;
                    }
                    if (k < i)
                    {
                        l = i1 = i1 << 0x10;
                        k1 = l1 = l1 << 0x10;
                        if (j < 0)
                        {
                            l -= num10 * j;
                            i1 -= num12 * j;
                            k1 -= num11 * j;
                            l1 -= num13 * j;
                            j = 0;
                        }
                        j1 = j1 << 0x10;
                        i2 = i2 << 0x10;
                        if (k < 0)
                        {
                            j1 -= num14 * k;
                            i2 -= num15 * k;
                            k = 0;
                        }
                        int num18 = j - textureInt2;
                        num += num3 * num18;
                        num4 += num6 * num18;
                        num7 += num9 * num18;
                        if (((j != k) && (num10 < num12)) || ((j == k) && (num10 > num14)))
                        {
                            i -= k;
                            k -= j;
                            j = anIntArray1472[j];
                            while (--k >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, j, l >> 0x10, i1 >> 0x10, k1 >> 8, l1 >> 8, num, num4, num7, num2, num5, num8);
                                l += num10;
                                i1 += num12;
                                k1 += num11;
                                l1 += num13;
                                j += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                            while (--i >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, j, l >> 0x10, j1 >> 0x10, k1 >> 8, i2 >> 8, num, num4, num7, num2, num5, num8);
                                l += num10;
                                j1 += num14;
                                k1 += num11;
                                i2 += num15;
                                j += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                        }
                        else
                        {
                            i -= k;
                            k -= j;
                            j = anIntArray1472[j];
                            while (--k >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, j, i1 >> 0x10, l >> 0x10, l1 >> 8, k1 >> 8, num, num4, num7, num2, num5, num8);
                                l += num10;
                                i1 += num12;
                                k1 += num11;
                                l1 += num13;
                                j += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                            while (--i >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, j, j1 >> 0x10, l >> 0x10, i2 >> 8, k1 >> 8, num, num4, num7, num2, num5, num8);
                                l += num10;
                                j1 += num14;
                                k1 += num11;
                                i2 += num15;
                                j += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                        }
                    }
                    else
                    {
                        j1 = i1 = i1 << 0x10;
                        i2 = l1 = l1 << 0x10;
                        if (j < 0)
                        {
                            j1 -= num10 * j;
                            i1 -= num12 * j;
                            i2 -= num11 * j;
                            l1 -= num13 * j;
                            j = 0;
                        }
                        l = l << 0x10;
                        k1 = k1 << 0x10;
                        if (i < 0)
                        {
                            l -= num14 * i;
                            k1 -= num15 * i;
                            i = 0;
                        }
                        int num19 = j - textureInt2;
                        num += num3 * num19;
                        num4 += num6 * num19;
                        num7 += num9 * num19;
                        if (num10 < num12)
                        {
                            k -= i;
                            i -= j;
                            j = anIntArray1472[j];
                            while (--i >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, j, j1 >> 0x10, i1 >> 0x10, i2 >> 8, l1 >> 8, num, num4, num7, num2, num5, num8);
                                j1 += num10;
                                i1 += num12;
                                i2 += num11;
                                l1 += num13;
                                j += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                            while (--k >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, j, l >> 0x10, i1 >> 0x10, k1 >> 8, l1 >> 8, num, num4, num7, num2, num5, num8);
                                l += num14;
                                i1 += num12;
                                k1 += num15;
                                l1 += num13;
                                j += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                        }
                        else
                        {
                            k -= i;
                            i -= j;
                            j = anIntArray1472[j];
                            while (--i >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, j, i1 >> 0x10, j1 >> 0x10, l1 >> 8, i2 >> 8, num, num4, num7, num2, num5, num8);
                                j1 += num10;
                                i1 += num12;
                                i2 += num11;
                                l1 += num13;
                                j += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                            while (--k >= 0)
                            {
                                method379(DrawingArea.pixels, numArray, j, i1 >> 0x10, l >> 0x10, l1 >> 8, k1 >> 8, num, num4, num7, num2, num5, num8);
                                l += num14;
                                i1 += num12;
                                k1 += num15;
                                l1 += num13;
                                j += DrawingArea.width;
                                num += num3;
                                num4 += num6;
                                num7 += num9;
                            }
                        }
                    }
                }
            }
            else if (k < DrawingArea.bottomY)
            {
                if (i > DrawingArea.bottomY)
                {
                    i = DrawingArea.bottomY;
                }
                if (j > DrawingArea.bottomY)
                {
                    j = DrawingArea.bottomY;
                }
                if (i < j)
                {
                    i1 = j1 = j1 << 0x10;
                    l1 = i2 = i2 << 0x10;
                    if (k < 0)
                    {
                        i1 -= num12 * k;
                        j1 -= num14 * k;
                        l1 -= num13 * k;
                        i2 -= num15 * k;
                        k = 0;
                    }
                    l = l << 0x10;
                    k1 = k1 << 0x10;
                    if (i < 0)
                    {
                        l -= num10 * i;
                        k1 -= num11 * i;
                        i = 0;
                    }
                    int num20 = k - textureInt2;
                    num += num3 * num20;
                    num4 += num6 * num20;
                    num7 += num9 * num20;
                    if (num12 < num14)
                    {
                        j -= i;
                        i -= k;
                        k = anIntArray1472[k];
                        while (--i >= 0)
                        {
                            method379(DrawingArea.pixels, numArray, k, i1 >> 0x10, j1 >> 0x10, l1 >> 8, i2 >> 8, num, num4, num7, num2, num5, num8);
                            i1 += num12;
                            j1 += num14;
                            l1 += num13;
                            i2 += num15;
                            k += DrawingArea.width;
                            num += num3;
                            num4 += num6;
                            num7 += num9;
                        }
                        while (--j >= 0)
                        {
                            method379(DrawingArea.pixels, numArray, k, i1 >> 0x10, l >> 0x10, l1 >> 8, k1 >> 8, num, num4, num7, num2, num5, num8);
                            i1 += num12;
                            l += num10;
                            l1 += num13;
                            k1 += num11;
                            k += DrawingArea.width;
                            num += num3;
                            num4 += num6;
                            num7 += num9;
                        }
                    }
                    else
                    {
                        j -= i;
                        i -= k;
                        k = anIntArray1472[k];
                        while (--i >= 0)
                        {
                            method379(DrawingArea.pixels, numArray, k, j1 >> 0x10, i1 >> 0x10, i2 >> 8, l1 >> 8, num, num4, num7, num2, num5, num8);
                            i1 += num12;
                            j1 += num14;
                            l1 += num13;
                            i2 += num15;
                            k += DrawingArea.width;
                            num += num3;
                            num4 += num6;
                            num7 += num9;
                        }
                        while (--j >= 0)
                        {
                            method379(DrawingArea.pixels, numArray, k, l >> 0x10, i1 >> 0x10, k1 >> 8, l1 >> 8, num, num4, num7, num2, num5, num8);
                            i1 += num12;
                            l += num10;
                            l1 += num13;
                            k1 += num11;
                            k += DrawingArea.width;
                            num += num3;
                            num4 += num6;
                            num7 += num9;
                        }
                    }
                }
                else
                {
                    l = j1 = j1 << 0x10;
                    k1 = i2 = i2 << 0x10;
                    if (k < 0)
                    {
                        l -= num12 * k;
                        j1 -= num14 * k;
                        k1 -= num13 * k;
                        i2 -= num15 * k;
                        k = 0;
                    }
                    i1 = i1 << 0x10;
                    l1 = l1 << 0x10;
                    if (j < 0)
                    {
                        i1 -= num10 * j;
                        l1 -= num11 * j;
                        j = 0;
                    }
                    int num21 = k - textureInt2;
                    num += num3 * num21;
                    num4 += num6 * num21;
                    num7 += num9 * num21;
                    if (num12 < num14)
                    {
                        i -= j;
                        j -= k;
                        k = anIntArray1472[k];
                        while (--j >= 0)
                        {
                            method379(DrawingArea.pixels, numArray, k, l >> 0x10, j1 >> 0x10, k1 >> 8, i2 >> 8, num, num4, num7, num2, num5, num8);
                            l += num12;
                            j1 += num14;
                            k1 += num13;
                            i2 += num15;
                            k += DrawingArea.width;
                            num += num3;
                            num4 += num6;
                            num7 += num9;
                        }
                        while (--i >= 0)
                        {
                            method379(DrawingArea.pixels, numArray, k, i1 >> 0x10, j1 >> 0x10, l1 >> 8, i2 >> 8, num, num4, num7, num2, num5, num8);
                            i1 += num10;
                            j1 += num14;
                            l1 += num11;
                            i2 += num15;
                            k += DrawingArea.width;
                            num += num3;
                            num4 += num6;
                            num7 += num9;
                        }
                    }
                    else
                    {
                        i -= j;
                        j -= k;
                        k = anIntArray1472[k];
                        while (--j >= 0)
                        {
                            method379(DrawingArea.pixels, numArray, k, j1 >> 0x10, l >> 0x10, i2 >> 8, k1 >> 8, num, num4, num7, num2, num5, num8);
                            l += num12;
                            j1 += num14;
                            k1 += num13;
                            i2 += num15;
                            k += DrawingArea.width;
                            num += num3;
                            num4 += num6;
                            num7 += num9;
                        }
                        while (--i >= 0)
                        {
                            method379(DrawingArea.pixels, numArray, k, j1 >> 0x10, i1 >> 0x10, i2 >> 8, l1 >> 8, num, num4, num7, num2, num5, num8);
                            i1 += num10;
                            j1 += num14;
                            l1 += num11;
                            i2 += num15;
                            k += DrawingArea.width;
                            num += num3;
                            num4 += num6;
                            num7 += num9;
                        }
                    }
                }
            }
        }

        private static void method379(int[] ai, int[] ai1, int k, int l, int i1, int j1, int k1, int l1, int i2, int j2, int k2, int l2, int i3)
        {
            int num = 0;
            int num2 = 0;
            if (l < i1)
            {
                int num3;
                int num4;
                if (aBoolean1462)
                {
                    num3 = (k1 - j1) / (i1 - l);
                    if (i1 > DrawingArea.centerX)
                    {
                        i1 = DrawingArea.centerX;
                    }
                    if (l < 0)
                    {
                        j1 -= l * num3;
                        l = 0;
                    }
                    if (l >= i1)
                    {
                        return;
                    }
                    num4 = (i1 - l) >> 3;
                    num3 = num3 << 12;
                    j1 = j1 << 9;
                }
                else
                {
                    if ((i1 - l) > 7)
                    {
                        num4 = (i1 - l) >> 3;
                        num3 = ((k1 - j1) * anIntArray1468[num4]) >> 6;
                    }
                    else
                    {
                        num4 = 0;
                        num3 = 0;
                    }
                    j1 = j1 << 9;
                }
                k += l;
                if (lowMem)
                {
                    int num5 = 0;
                    int num6 = 0;
                    int num7 = l - textureInt1;
                    l1 += (k2 >> 3) * num7;
                    i2 += (l2 >> 3) * num7;
                    j2 += (i3 >> 3) * num7;
                    int num8 = j2 >> 12;
                    if (num8 != 0)
                    {
                        num = l1 / num8;
                        num2 = i2 / num8;
                        if (num < 0)
                        {
                            num = 0;
                        }
                        else if (num > 0xfc0)
                        {
                            num = 0xfc0;
                        }
                    }
                    l1 += k2;
                    i2 += l2;
                    j2 += i3;
                    num8 = j2 >> 12;
                    if (num8 != 0)
                    {
                        num5 = l1 / num8;
                        num6 = i2 / num8;
                        if (num5 < 7)
                        {
                            num5 = 7;
                        }
                        else if (num5 > 0xfc0)
                        {
                            num5 = 0xfc0;
                        }
                    }
                    int num9 = (num5 - num) >> 3;
                    int num10 = (num6 - num2) >> 3;
                    num += (j1 & 0x600000) >> 3;
                    int num11 = j1 >> 0x17;
                    if (aBoolean1463)
                    {
                        while (num4-- > 0)
                        {
                            ai[k++] = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            num += num9;
                            num2 += num10;
                            ai[k++] = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            num += num9;
                            num2 += num10;
                            ai[k++] = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            num += num9;
                            num2 += num10;
                            ai[k++] = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            num += num9;
                            num2 += num10;
                            ai[k++] = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            num += num9;
                            num2 += num10;
                            ai[k++] = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            num += num9;
                            num2 += num10;
                            ai[k++] = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            num += num9;
                            num2 += num10;
                            ai[k++] = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            num = num5;
                            num2 = num6;
                            l1 += k2;
                            i2 += l2;
                            j2 += i3;
                            int num12 = j2 >> 12;
                            if (num12 != 0)
                            {
                                num5 = l1 / num12;
                                num6 = i2 / num12;
                                if (num5 < 7)
                                {
                                    num5 = 7;
                                }
                                else if (num5 > 0xfc0)
                                {
                                    num5 = 0xfc0;
                                }
                            }
                            num9 = (num5 - num) >> 3;
                            num10 = (num6 - num2) >> 3;
                            j1 += num3;
                            num += (j1 & 0x600000) >> 3;
                            num11 = j1 >> 0x17;
                        }
                        num4 = (i1 - l) & 7;
                        while (num4-- > 0)
                        {
                            ai[k++] = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            num += num9;
                            num2 += num10;
                        }
                    }
                    else
                    {
                        while (num4-- > 0)
                        {
                            int num13 = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            if (num13 != 0)
                            {
                                ai[k] = num13;
                            }
                            k++;
                            num += num9;
                            num2 += num10;
                            num13 = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            if (num13 != 0)
                            {
                                ai[k] = num13;
                            }
                            k++;
                            num += num9;
                            num2 += num10;
                            num13 = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            if (num13 != 0)
                            {
                                ai[k] = num13;
                            }
                            k++;
                            num += num9;
                            num2 += num10;
                            num13 = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            if (num13 != 0)
                            {
                                ai[k] = num13;
                            }
                            k++;
                            num += num9;
                            num2 += num10;
                            num13 = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            if (num13 != 0)
                            {
                                ai[k] = num13;
                            }
                            k++;
                            num += num9;
                            num2 += num10;
                            num13 = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            if (num13 != 0)
                            {
                                ai[k] = num13;
                            }
                            k++;
                            num += num9;
                            num2 += num10;
                            num13 = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            if (num13 != 0)
                            {
                                ai[k] = num13;
                            }
                            k++;
                            num += num9;
                            num2 += num10;
                            num13 = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            if (num13 != 0)
                            {
                                ai[k] = num13;
                            }
                            k++;
                            num = num5;
                            num2 = num6;
                            l1 += k2;
                            i2 += l2;
                            j2 += i3;
                            int num14 = j2 >> 12;
                            if (num14 != 0)
                            {
                                num5 = l1 / num14;
                                num6 = i2 / num14;
                                if (num5 < 7)
                                {
                                    num5 = 7;
                                }
                                else if (num5 > 0xfc0)
                                {
                                    num5 = 0xfc0;
                                }
                            }
                            num9 = (num5 - num) >> 3;
                            num10 = (num6 - num2) >> 3;
                            j1 += num3;
                            num += (j1 & 0x600000) >> 3;
                            num11 = j1 >> 0x17;
                        }
                        num4 = (i1 - l) & 7;
                        while (num4-- > 0)
                        {
                            int num15 = ai1[(num2 & 0xfc0) + (num >> 6)] >> num11;
                            if (num15 != 0)
                            {
                                ai[k] = num15;
                            }
                            k++;
                            num += num9;
                            num2 += num10;
                        }
                    }
                }
                else
                {
                    int num16 = 0;
                    int num17 = 0;
                    int num18 = l - textureInt1;
                    l1 += (k2 >> 3) * num18;
                    i2 += (l2 >> 3) * num18;
                    j2 += (i3 >> 3) * num18;
                    int num19 = j2 >> 14;
                    if (num19 != 0)
                    {
                        num = l1 / num19;
                        num2 = i2 / num19;
                        if (num < 0)
                        {
                            num = 0;
                        }
                        else if (num > 0x3f80)
                        {
                            num = 0x3f80;
                        }
                    }
                    l1 += k2;
                    i2 += l2;
                    j2 += i3;
                    num19 = j2 >> 14;
                    if (num19 != 0)
                    {
                        num16 = l1 / num19;
                        num17 = i2 / num19;
                        if (num16 < 7)
                        {
                            num16 = 7;
                        }
                        else if (num16 > 0x3f80)
                        {
                            num16 = 0x3f80;
                        }
                    }
                    int num20 = (num16 - num) >> 3;
                    int num21 = (num17 - num2) >> 3;
                    num += j1 & 0x600000;
                    int num22 = j1 >> 0x17;
                    if (aBoolean1463)
                    {
                        while (num4-- > 0)
                        {
                            ai[k++] = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            num += num20;
                            num2 += num21;
                            ai[k++] = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            num += num20;
                            num2 += num21;
                            ai[k++] = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            num += num20;
                            num2 += num21;
                            ai[k++] = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            num += num20;
                            num2 += num21;
                            ai[k++] = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            num += num20;
                            num2 += num21;
                            ai[k++] = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            num += num20;
                            num2 += num21;
                            ai[k++] = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            num += num20;
                            num2 += num21;
                            ai[k++] = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            num = num16;
                            num2 = num17;
                            l1 += k2;
                            i2 += l2;
                            j2 += i3;
                            int num23 = j2 >> 14;
                            if (num23 != 0)
                            {
                                num16 = l1 / num23;
                                num17 = i2 / num23;
                                if (num16 < 7)
                                {
                                    num16 = 7;
                                }
                                else if (num16 > 0x3f80)
                                {
                                    num16 = 0x3f80;
                                }
                            }
                            num20 = (num16 - num) >> 3;
                            num21 = (num17 - num2) >> 3;
                            j1 += num3;
                            num += j1 & 0x600000;
                            num22 = j1 >> 0x17;
                        }
                        num4 = (i1 - l) & 7;
                        while (num4-- > 0)
                        {
                            ai[k++] = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            num += num20;
                            num2 += num21;
                        }
                    }
                    else
                    {
                        while (num4-- > 0)
                        {
                            int num24 = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            if (num24 != 0)
                            {
                                ai[k] = num24;
                            }
                            k++;
                            num += num20;
                            num2 += num21;
                            num24 = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            if (num24 != 0)
                            {
                                ai[k] = num24;
                            }
                            k++;
                            num += num20;
                            num2 += num21;
                            num24 = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            if (num24 != 0)
                            {
                                ai[k] = num24;
                            }
                            k++;
                            num += num20;
                            num2 += num21;
                            num24 = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            if (num24 != 0)
                            {
                                ai[k] = num24;
                            }
                            k++;
                            num += num20;
                            num2 += num21;
                            num24 = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            if (num24 != 0)
                            {
                                ai[k] = num24;
                            }
                            k++;
                            num += num20;
                            num2 += num21;
                            num24 = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            if (num24 != 0)
                            {
                                ai[k] = num24;
                            }
                            k++;
                            num += num20;
                            num2 += num21;
                            num24 = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            if (num24 != 0)
                            {
                                ai[k] = num24;
                            }
                            k++;
                            num += num20;
                            num2 += num21;
                            num24 = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            if (num24 != 0)
                            {
                                ai[k] = num24;
                            }
                            k++;
                            num = num16;
                            num2 = num17;
                            l1 += k2;
                            i2 += l2;
                            j2 += i3;
                            int num25 = j2 >> 14;
                            if (num25 != 0)
                            {
                                num16 = l1 / num25;
                                num17 = i2 / num25;
                                if (num16 < 7)
                                {
                                    num16 = 7;
                                }
                                else if (num16 > 0x3f80)
                                {
                                    num16 = 0x3f80;
                                }
                            }
                            num20 = (num16 - num) >> 3;
                            num21 = (num17 - num2) >> 3;
                            j1 += num3;
                            num += j1 & 0x600000;
                            num22 = j1 >> 0x17;
                        }
                        int num26 = (i1 - l) & 7;
                        while (num26-- > 0)
                        {
                            int num27 = ai1[(num2 & 0x3f80) + (num >> 7)] >> num22;
                            if (num27 != 0)
                            {
                                ai[k] = num27;
                            }
                            k++;
                            num += num20;
                            num2 += num21;
                        }
                    }
                }
            }
        }

        public static void nullLoader()
        {
            anIntArray1468 = null;
            anIntArray1468 = null;
            anIntArray1470 = null;
            anIntArray1471 = null;
            anIntArray1472 = null;
            aBackgroundArray1474s = null;
            aBooleanArray1475 = null;
            anIntArray1476 = null;
            anIntArrayArray1478 = null;
            anIntArrayArray1479 = null;
            anIntArray1480 = null;
            anIntArray1482 = null;
            anIntArrayArray1483 = null;
        }
    }
}

