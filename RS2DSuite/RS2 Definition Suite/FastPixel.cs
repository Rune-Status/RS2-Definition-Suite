namespace RS2_Definition_Suite
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;

    public class FastPixel
    {
        private System.Drawing.Bitmap _bitmap;
        private int _height;
        private bool _isAlpha = false;
        private int _width;
        private BitmapData bmpData;
        private IntPtr bmpPtr;
        private bool locked = false;
        public byte[] rgbValues = new byte[4];

        public FastPixel(System.Drawing.Bitmap bitmap)
        {
            if (bitmap.PixelFormat == (bitmap.PixelFormat | PixelFormat.Indexed))
            {
                throw new Exception("Cannot lock an Indexed image.");
            }
            this._bitmap = bitmap;
            this._isAlpha = this.Bitmap.PixelFormat == (this.Bitmap.PixelFormat | PixelFormat.Alpha);
            this._width = bitmap.Width;
            this._height = bitmap.Height;
        }

        public void Clear(Color colour)
        {
            int num;
            if (!this.locked)
            {
                throw new Exception("Bitmap not locked.");
            }
            if (this.IsAlphaBitmap)
            {
                for (num = 0; num <= (this.rgbValues.Length - 1); num += 4)
                {
                    this.rgbValues[num] = colour.B;
                    this.rgbValues[num + 1] = colour.G;
                    this.rgbValues[num + 2] = colour.R;
                    this.rgbValues[num + 3] = colour.A;
                }
            }
            else
            {
                for (num = 0; num <= (this.rgbValues.Length - 1); num += 3)
                {
                    this.rgbValues[num] = colour.B;
                    this.rgbValues[num + 1] = colour.G;
                    this.rgbValues[num + 2] = colour.R;
                }
            }
        }

        public Color GetPixel(Point location)
        {
            return this.GetPixel(location.X, location.Y);
        }

        public Color GetPixel(int x, int y)
        {
            int num;
            int num2;
            int num3;
            int num4;
            if (!this.locked)
            {
                throw new Exception("Bitmap not locked.");
            }
            if (this.IsAlphaBitmap)
            {
                num = ((y * this.Width) + x) * 4;
                num2 = this.rgbValues[num];
                num3 = this.rgbValues[num + 1];
                num4 = this.rgbValues[num + 2];
                int alpha = this.rgbValues[num + 3];
                return Color.FromArgb(alpha, num4, num3, num2);
            }
            num = ((y * this.Width) + x) * 3;
            num2 = this.rgbValues[num];
            num3 = this.rgbValues[num + 1];
            num4 = this.rgbValues[num + 2];
            return Color.FromArgb(num4, num3, num2);
        }

        public void Lock()
        {
            int num;
            if (this.locked)
            {
                throw new Exception("Bitmap already locked.");
            }
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            this.bmpData = this.Bitmap.LockBits(rect, ImageLockMode.ReadWrite, this.Bitmap.PixelFormat);
            this.bmpPtr = this.bmpData.Scan0;
            if (this.IsAlphaBitmap)
            {
                num = (this.Width * this.Height) * 4;
                Marshal.Copy(this.bmpPtr, this.rgbValues, 0, this.rgbValues.Length);
            }
            else
            {
                num = (this.Width * this.Height) * 3;
                Marshal.Copy(this.bmpPtr, this.rgbValues, 0, this.rgbValues.Length);
            }
            this.locked = true;
        }

        public void SetPixel(Point location, Color colour)
        {
            this.SetPixel(location.X, location.Y, colour);
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int num;
            if (!this.locked)
            {
                throw new Exception("Bitmap not locked.");
            }
            if (this.IsAlphaBitmap)
            {
                num = ((y * this.Width) + x) * 4;
                this.rgbValues[num] = colour.B;
                this.rgbValues[num + 1] = colour.G;
                this.rgbValues[num + 2] = colour.R;
                this.rgbValues[num + 3] = colour.A;
            }
            else
            {
                num = ((y * this.Width) + x) * 3;
                this.rgbValues[num] = colour.B;
                this.rgbValues[num + 1] = colour.G;
                this.rgbValues[num + 2] = colour.R;
            }
        }

        public void Unlock(bool setPixels)
        {
            if (!this.locked)
            {
                throw new Exception("Bitmap not locked.");
            }
            if (setPixels)
            {
                Marshal.Copy(this.rgbValues, 0, this.bmpPtr, this.rgbValues.Length);
            }
            this.Bitmap.UnlockBits(this.bmpData);
            this.locked = false;
        }

        public System.Drawing.Bitmap Bitmap
        {
            get
            {
                return this._bitmap;
            }
        }

        public int Height
        {
            get
            {
                return this._height;
            }
        }

        public bool IsAlphaBitmap
        {
            get
            {
                return this._isAlpha;
            }
        }

        public int Width
        {
            get
            {
                return this._width;
            }
        }
    }
}

