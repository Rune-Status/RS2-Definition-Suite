namespace CEBL
{
    using System;
    using System.IO;
    using System.Threading;

    public class Decompressor
    {
        public int anInt311;
        public static byte[] buffer = new byte[520];
        public FileStream dataFile;
        public FileStream indexFile;

        public Decompressor(FileStream randomaccessfile, FileStream randomaccessfile1, int j)
        {
            this.anInt311 = j;
            this.dataFile = randomaccessfile;
            this.indexFile = randomaccessfile1;
        }

        public byte[] decompress(int i)
        {
            try
            {
                int num;
                this.seekTo(ref this.indexFile, i * 6);
                for (int j = 0; j < 6; j += num)
                {
                    num = this.indexFile.Read(Decompressor.buffer, j, 6 - j);
                    if (num == -1)
                    {
                        return null;
                    }
                }
                int num3 = (((Decompressor.buffer[0] & 0xff) << 0x10) + ((Decompressor.buffer[1] & 0xff) << 8)) + (Decompressor.buffer[2] & 0xff);
                int num4 = (((Decompressor.buffer[3] & 0xff) << 0x10) + ((Decompressor.buffer[4] & 0xff) << 8)) + (Decompressor.buffer[5] & 0xff);
                if ((num3 < 0) || (num3 > 0xffffff))
                {
                    return null;
                }
                if ((num4 <= 0) || (num4 > (this.dataFile.Length / 520L)))
                {
                    return null;
                }
                byte[] buffer = new byte[num3];
                int num5 = 0;
                for (int k = 0; num5 < num3; k++)
                {
                    if (num4 == 0)
                    {
                        return null;
                    }
                    this.seekTo(ref this.dataFile, num4 * 520);
                    int offset = 0;
                    int num8 = num3 - num5;
                    if (num8 > 0x200)
                    {
                        num8 = 0x200;
                    }
                    while (offset < (num8 + 8))
                    {
                        int num9 = this.dataFile.Read(Decompressor.buffer, offset, (num8 + 8) - offset);
                        if (num9 == -1)
                        {
                            return null;
                        }
                        offset += num9;
                    }
                    int num10 = ((Decompressor.buffer[0] & 0xff) << 8) + (Decompressor.buffer[1] & 0xff);
                    int num11 = ((Decompressor.buffer[2] & 0xff) << 8) + (Decompressor.buffer[3] & 0xff);
                    int num12 = (((Decompressor.buffer[4] & 0xff) << 0x10) + ((Decompressor.buffer[5] & 0xff) << 8)) + (Decompressor.buffer[6] & 0xff);
                    int num13 = Decompressor.buffer[7] & 0xff;
                    if (i == 3)
                    {
                    }
                    if (((num10 != i) || (num11 != k)) || (num13 != this.anInt311))
                    {
                        return null;
                    }
                    if ((num12 < 0) || (num12 > (((int) this.dataFile.Length) / 520)))
                    {
                        return null;
                    }
                    for (int m = 0; m < num8; m++)
                    {
                        buffer[num5++] = Decompressor.buffer[m + 8];
                    }
                    num4 = num12;
                }
                return buffer;
            }
            catch (IOException)
            {
                return null;
            }
        }

        public int getLocation(int index)
        {
            byte[] buffer = new byte[3];
            this.indexFile.Seek((long) ((index * 6) + 3), SeekOrigin.Begin);
            this.indexFile.Read(buffer, 0, 3);
            return (((buffer[0] << 0x10) + (buffer[1] << 8)) + buffer[2]);
        }

        public int getSize(int index)
        {
            byte[] buffer = new byte[3];
            this.indexFile.Seek((long) (index * 6), SeekOrigin.Begin);
            this.indexFile.Read(buffer, 0, 3);
            return (((buffer[0] << 0x10) + (buffer[1] << 8)) + buffer[2]);
        }

        public bool method234(int i, byte[] abyte0, int j)
        {
            bool flag = this.method235(true, j, i, abyte0);
            if (!flag)
            {
                flag = this.method235(false, j, i, abyte0);
            }
            return flag;
        }

        public bool method235(bool flag, int j, int k, byte[] abyte0)
        {
            try
            {
                int num;
                if (flag)
                {
                    int num2;
                    this.seekTo(ref this.indexFile, j * 6);
                    for (int m = 0; m < 6; m += num2)
                    {
                        num2 = this.indexFile.Read(buffer, m, 6 - m);
                        if (num2 == -1)
                        {
                            return false;
                        }
                    }
                    num = (((buffer[3] & 0xff) << 0x10) + ((buffer[4] & 0xff) << 8)) + (buffer[5] & 0xff);
                    if ((num <= 0) || (num > (this.dataFile.Length / 520L)))
                    {
                        return false;
                    }
                }
                else
                {
                    num = (int) ((this.dataFile.Length + 0x207L) / 520L);
                    if (num == 0)
                    {
                        num = 1;
                    }
                }
                buffer[0] = (byte) (k >> 0x10);
                buffer[1] = (byte) (k >> 8);
                buffer[2] = (byte) k;
                buffer[3] = (byte) (num >> 0x10);
                buffer[4] = (byte) (num >> 8);
                buffer[5] = (byte) num;
                this.seekTo(ref this.indexFile, j * 6);
                this.indexFile.Write(buffer, 0, 6);
                int offset = 0;
                for (int i = 0; offset < k; i++)
                {
                    int num6 = 0;
                    if (flag)
                    {
                        this.seekTo(ref this.dataFile, num * 520);
                        int num7 = 0;
                        while (num7 < 8)
                        {
                            int num8 = this.dataFile.Read(buffer, num7, 8 - num7);
                            if (num8 == -1)
                            {
                                break;
                            }
                            num7 += num8;
                        }
                        if (num7 == 8)
                        {
                            int num9 = ((buffer[0] & 0xff) << 8) + (buffer[1] & 0xff);
                            int num10 = ((buffer[2] & 0xff) << 8) + (buffer[3] & 0xff);
                            num6 = (((buffer[4] & 0xff) << 0x10) + ((buffer[5] & 0xff) << 8)) + (buffer[6] & 0xff);
                            int num11 = buffer[7] & 0xff;
                            if (((num9 != j) || (num10 != i)) || (num11 != this.anInt311))
                            {
                                return false;
                            }
                            if ((num6 < 0) || (num6 > (this.dataFile.Length / 520L)))
                            {
                                return false;
                            }
                        }
                    }
                    if (num6 == 0)
                    {
                        flag = false;
                        num6 = (int) ((this.dataFile.Length + 0x207L) / 520L);
                        if (num6 == 0)
                        {
                            num6++;
                        }
                        if (num6 == num)
                        {
                            num6++;
                        }
                    }
                    if ((k - offset) <= 0x200)
                    {
                        num6 = 0;
                    }
                    buffer[0] = (byte) (j >> 8);
                    buffer[1] = (byte) j;
                    buffer[2] = (byte) (i >> 8);
                    buffer[3] = (byte) i;
                    buffer[4] = (byte) (num6 >> 0x10);
                    buffer[5] = (byte) (num6 >> 8);
                    buffer[6] = (byte) num6;
                    buffer[7] = (byte) this.anInt311;
                    this.seekTo(ref this.dataFile, num * 520);
                    this.dataFile.Write(buffer, 0, 8);
                    int count = k - offset;
                    if (count > 0x200)
                    {
                        count = 0x200;
                    }
                    this.dataFile.Write(abyte0, offset, count);
                    offset += count;
                    num = num6;
                }
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        public void packAtEnd(int index, byte[] size, byte[] data)
        {
            int num = this.getLocation(index);
            int num2 = this.getSize(index);
            if ((num + num2) < data.Length)
            {
                num = (int) (this.dataFile.Length + 1L);
            }
            num = (int) ((num + 0x207L) / 520L);
            this.indexFile.Seek((long) (index * 6), SeekOrigin.Begin);
            this.indexFile.Write(size, 0, 3);
            byte[] buffer = new byte[] { (byte) (num >> 0x10), (byte) ((num & 0xffff) >> 8), (byte) (num & 0xff) };
            this.indexFile.Write(buffer, 0, 3);
            this.dataFile.Seek((long) (num * 520), SeekOrigin.Begin);
            this.dataFile.SetLength((num + data.Length) + this.dataFile.Length);
            byte[] buffer2 = new byte[] { size[0], size[1], size[2], buffer[0], buffer[1], buffer[2], (byte) index };
            byte[] destinationArray = new byte[data.Length + 0x200];
            Array.Copy(data, 0, destinationArray, 0x200, data.Length);
            this.dataFile.Seek(0x56f68L, SeekOrigin.Begin);
            this.dataFile.Read(destinationArray, 0, 0x200);
            this.dataFile.Seek((long) (num * 520), SeekOrigin.Begin);
            this.dataFile.Write(destinationArray, 0, destinationArray.Length);
        }

        public void seekTo(ref FileStream randomaccessfile, int j)
        {
            if ((j < 0) || (j > 0x3c00000))
            {
                j = 0x3c00000;
                try
                {
                    Thread.Sleep(0x3e8);
                }
                catch (Exception)
                {
                }
            }
            randomaccessfile.Position = j;
        }
    }
}

