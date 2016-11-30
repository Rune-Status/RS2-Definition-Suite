namespace RS2_Definition_Suite
{
    using System;
    using System.Drawing;

    [Serializable]
    public class DrawingArea
    {
        public static int anInt1387;
        public static int bottomX;
        public static int bottomY;
        public static int centerX;
        public static int centerY;
        public static int height;
        public static int newBottomX;
        public static int newBottomY;
        public static int newTopX;
        public static int newTopY;
        public static int[] pixels;
        public static int topX;
        public static int topY;
        public static int width;

        public static void defaultDrawingAreaSize()
        {
            topX = 0;
            topY = 0;
            bottomX = width;
            bottomY = height;
            centerX = bottomX - 1;
            centerY = bottomX / 2;
        }

        public static void drawPixels(int i, int j, int k, int l, int i1)
        {
            if (k < topX)
            {
                i1 -= topX - k;
                k = topX;
            }
            if (j < topY)
            {
                i -= topY - j;
                j = topY;
            }
            if ((k + i1) > bottomX)
            {
                i1 = bottomX - k;
            }
            if ((j + i) > bottomY)
            {
                i = bottomY - j;
            }
            int num = width - i1;
            int num2 = k + (j * width);
            for (int m = -i; m < 0; m++)
            {
                for (int n = -i1; n < 0; n++)
                {
                    pixels[num2++] = l;
                }
                num2 += num;
            }
        }

        public static void fillPixels(int i, int j, int k, int l, int i1)
        {
            method339(i1, l, j, i);
            method339((i1 + k) - 1, l, j, i);
            method341(i1, l, k, i);
            method341(i1, l, k, (i + j) - 1);
        }

        public static Bitmap getImage()
        {
            Bitmap bitmap = new Bitmap(width, height);
            FastPixel pixel = new FastPixel(bitmap) {
                rgbValues = new byte[(width * height) * 4]
            };
            pixel.Lock();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (((i * width) + j) >= pixels.Length)
                    {
                        pixel.Unlock(true);
                        return bitmap;
                    }
                    int num3 = pixels[(i * width) + j];
                    if (num3 == -1)
                    {
                        pixel.SetPixel(j, i, Color.Black);
                    }
                    else
                    {
                        byte blue = (byte) (num3 & 0xff);
                        byte green = (byte) (num3 >> 8);
                        byte red = (byte) (num3 >> 0x10);
                        pixel.SetPixel(j, i, Color.FromArgb(red, green, blue));
                    }
                }
            }
            pixel.Unlock(true);
            return bitmap;
        }

        public static int[] getTransparentPixels(int width, int height)
        {
            int[] numArray = new int[width * height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    numArray[(i * width) + j] = -1;
                }
            }
            return numArray;
        }

        public static void initDrawingArea(int i, int j, int[] ai)
        {
            pixels = ai;
            width = j;
            height = i;
            setDrawingArea(i, 0, j, 0);
        }

        public static void method335(int i, int j, int k, int l, int i1, int k1)
        {
            if (k1 < topX)
            {
                k -= topX - k1;
                k1 = topX;
            }
            if (j < topY)
            {
                l -= topY - j;
                j = topY;
            }
            if ((k1 + k) > bottomX)
            {
                k = bottomX - k1;
            }
            if ((j + l) > bottomY)
            {
                l = bottomY - j;
            }
            int num = 0x100 - i1;
            int num2 = ((i >> 0x10) & 0xff) * i1;
            int num3 = ((i >> 8) & 0xff) * i1;
            int num4 = (i & 0xff) * i1;
            int num5 = width - k;
            int index = k1 + (j * width);
            for (int m = 0; m < l; m++)
            {
                for (int n = -k; n < 0; n++)
                {
                    int num9 = ((pixels[index] >> 0x10) & 0xff) * num;
                    int num10 = ((pixels[index] >> 8) & 0xff) * num;
                    int num11 = (pixels[index] & 0xff) * num;
                    int num12 = ((((num2 + num9) >> 8) << 0x10) + (((num3 + num10) >> 8) << 8)) + ((num4 + num11) >> 8);
                    pixels[index++] = num12;
                }
                index += num5;
            }
        }

        public static void method338(int i, int j, int k, int l, int i1, int j1)
        {
            method340(l, i1, i, k, j1);
            method340(l, i1, (i + j) - 1, k, j1);
            if (j >= 3)
            {
                method342(l, j1, k, i + 1, j - 2);
                method342(l, (j1 + i1) - 1, k, i + 1, j - 2);
            }
        }

        public static void method339(int i, int j, int k, int l)
        {
            if ((i >= topY) && (i < bottomY))
            {
                if (l < topX)
                {
                    k -= topX - l;
                    l = topX;
                }
                if ((l + k) > bottomX)
                {
                    k = bottomX - l;
                }
                int num = l + (i * width);
                for (int m = 0; m < k; m++)
                {
                    pixels[num + m] = j;
                }
            }
        }

        private static void method340(int i, int j, int k, int l, int i1)
        {
            if ((k >= topY) && (k < bottomY))
            {
                if (i1 < topX)
                {
                    j -= topX - i1;
                    i1 = topX;
                }
                if ((i1 + j) > bottomX)
                {
                    j = bottomX - i1;
                }
                int num = 0x100 - l;
                int num2 = ((i >> 0x10) & 0xff) * l;
                int num3 = ((i >> 8) & 0xff) * l;
                int num4 = (i & 0xff) * l;
                int index = i1 + (k * width);
                for (int m = 0; m < j; m++)
                {
                    int num7 = ((pixels[index] >> 0x10) & 0xff) * num;
                    int num8 = ((pixels[index] >> 8) & 0xff) * num;
                    int num9 = (pixels[index] & 0xff) * num;
                    int num10 = ((((num2 + num7) >> 8) << 0x10) + (((num3 + num8) >> 8) << 8)) + ((num4 + num9) >> 8);
                    pixels[index++] = num10;
                }
            }
        }

        public static void method341(int i, int j, int k, int l)
        {
            if ((l >= topX) && (l < bottomX))
            {
                if (i < topY)
                {
                    k -= topY - i;
                    i = topY;
                }
                if ((i + k) > bottomY)
                {
                    k = bottomY - i;
                }
                int num = l + (i * width);
                for (int m = 0; m < k; m++)
                {
                    pixels[num + (m * width)] = j;
                }
            }
        }

        private static void method342(int i, int j, int k, int l, int i1)
        {
            if ((j >= topX) && (j < bottomX))
            {
                if (l < topY)
                {
                    i1 -= topY - l;
                    l = topY;
                }
                if ((l + i1) > bottomY)
                {
                    i1 = bottomY - l;
                }
                int num = 0x100 - k;
                int num2 = ((i >> 0x10) & 0xff) * k;
                int num3 = ((i >> 8) & 0xff) * k;
                int num4 = (i & 0xff) * k;
                int index = j + (l * width);
                for (int m = 0; m < i1; m++)
                {
                    int num7 = ((pixels[index] >> 0x10) & 0xff) * num;
                    int num8 = ((pixels[index] >> 8) & 0xff) * num;
                    int num9 = (pixels[index] & 0xff) * num;
                    pixels[index] = ((((num2 + num7) >> 8) << 0x10) + (((num3 + num8) >> 8) << 8)) + ((num4 + num9) >> 8);
                    index += width;
                }
            }
        }

        public static void setAllPixelsToZero()
        {
            int num = width * height;
            for (int i = 0; i < num; i++)
            {
                pixels[i] = 0;
            }
        }

        public static void setDrawingArea(int i, int j, int k, int l)
        {
            if (j < 0)
            {
                j = 0;
            }
            if (l < 0)
            {
                l = 0;
            }
            if (k > width)
            {
                k = width;
            }
            if (i > height)
            {
                i = height;
            }
            topX = j;
            topY = l;
            bottomX = k;
            bottomY = i;
            centerX = bottomX - 1;
            centerY = bottomX / 2;
            anInt1387 = bottomY / 2;
        }
    }
}

