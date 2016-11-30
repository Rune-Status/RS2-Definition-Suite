namespace CEBL
{
    using System;

    public class StreamLoader
    {
        public bool aBoolean732;
        public byte[] aByteArray726;
        public int[] anIntArray728;
        public int[] anIntArray729;
        public int[] anIntArray730;
        public int[] anIntArray731;
        public int dataSize;

        public StreamLoader(byte[] abyte0)
        {
            Stream stream = new Stream(abyte0);
            int i = stream.read3Bytes();
            int j = stream.read3Bytes();
            if (j != i)
            {
                byte[] buffer = new byte[i];
                Class13.method225(buffer, i, abyte0, j, 6);
                this.aByteArray726 = buffer;
                stream = new Stream(this.aByteArray726);
                this.aBoolean732 = true;
            }
            else
            {
                this.aByteArray726 = abyte0;
                this.aBoolean732 = false;
            }
            this.dataSize = stream.readUnsignedWord();
            this.anIntArray728 = new int[this.dataSize];
            this.anIntArray729 = new int[this.dataSize];
            this.anIntArray730 = new int[this.dataSize];
            this.anIntArray731 = new int[this.dataSize];
            int num3 = stream.currentOffset + (this.dataSize * 10);
            for (int k = 0; k < this.dataSize; k++)
            {
                this.anIntArray728[k] = stream.readDWord();
                this.anIntArray729[k] = stream.read3Bytes();
                this.anIntArray730[k] = stream.read3Bytes();
                this.anIntArray731[k] = num3;
                num3 += this.anIntArray730[k];
            }
        }

        public byte[] getDataForName(string s)
        {
            byte[] buffer = null;
            int num = 0;
            s = s.ToUpper();
            for (int i = 0; i < s.Length; i++)
            {
                num = ((num * 0x3d) + s[i]) - 0x20;
            }
            for (int j = 0; j < this.dataSize; j++)
            {
                if (this.anIntArray728[j] == num)
                {
                    if (buffer == null)
                    {
                        buffer = new byte[this.anIntArray729[j]];
                    }
                    if (!this.aBoolean732)
                    {
                        Class13.method225(buffer, this.anIntArray729[j], this.aByteArray726, this.anIntArray730[j], this.anIntArray731[j]);
                        return buffer;
                    }
                    int num4 = this.aByteArray726[this.anIntArray731[j]];
                    Array.Copy(this.aByteArray726, this.anIntArray731[j], buffer, 0, this.anIntArray729[j]);
                    return buffer;
                }
            }
            return null;
        }
    }
}

