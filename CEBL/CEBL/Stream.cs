namespace CEBL
{
    using System;
    using System.Text;

    public class Stream
    {
        public static int[] anIntArray1409 = new int[] { 
            0, 1, 3, 7, 15, 0x1f, 0x3f, 0x7f, 0xff, 0x1ff, 0x3ff, 0x7ff, 0xfff, 0x1fff, 0x3fff, 0x7fff, 
            0xffff, 0x1ffff, 0x3ffff, 0x7ffff, 0xfffff, 0x1fffff, 0x3fffff, 0x7fffff, 0xffffff, 0x1ffffff, 0x3ffffff, 0x7ffffff, 0xfffffff, 0x1fffffff, 0x3fffffff, 0x7fffffff, 
            -1
         };
        public int bitPosition;
		public int written;
        public byte[] buffer;
        public int currentOffset;
        public static NodeList nodeList = new NodeList();

        public Stream()
        {
        }
		
		private void incrementWritten(int value) {
			int temp = written + value;
			if (temp < 0) {
				temp = Int32.MaxValue;
			}
			written = temp;
		}

		public int size() {
			return written;
		}

        public Stream(byte[] abyte0)
        {
            this.buffer = abyte0;
            this.currentOffset = 0;
			written = 0;
        }

        public void finishBitAccess()
        {
            this.currentOffset = (this.bitPosition + 7) / 8;
        }

        public void initBitAccess()
        {
            this.bitPosition = this.currentOffset * 8;
        }

        public void method400(int i)
        {
            this.buffer[this.currentOffset++] = (byte) i;
            this.buffer[this.currentOffset++] = (byte) (i >> 8);
			incrementWritten(2);
        }

        public void method403(int j)
        {
            this.buffer[this.currentOffset++] = (byte) j;
            this.buffer[this.currentOffset++] = (byte) (j >> 8);
            this.buffer[this.currentOffset++] = (byte) (j >> 0x10);
            this.buffer[this.currentOffset++] = (byte) (j >> 0x18);
			incrementWritten(4);
        }

        public int method421()
        {
            int num = this.buffer[this.currentOffset] & 0xff;
            if (num < 0x80)
            {
                return (this.readUnsignedByte() - 0x40);
            }
            return (this.readUnsignedWord() - 0xc000);
        }

        public int method422()
        {
            int num = this.buffer[this.currentOffset] & 0xff;
            if (num < 0x80)
            {
                return this.readUnsignedByte();
            }
            return (this.readUnsignedWord() - 0x8000);
        }

        public void method424(int i)
        {
            this.buffer[this.currentOffset++] = (byte) -i;
			incrementWritten(1);
        }

        public void method425(int j)
        {
            this.buffer[this.currentOffset++] = (byte) (0x80 - j);
			incrementWritten(1);
        }

        public int method426()
        {
            return ((this.buffer[this.currentOffset++] - 0x80) & 0xff);
        }

        public int method427()
        {
            return (-this.buffer[this.currentOffset++] & 0xff);
        }

        public int method428()
        {
            return ((0x80 - this.buffer[this.currentOffset++]) & 0xff);
        }

        public byte method429()
        {
			return (byte) -this.buffer[this.currentOffset++];
        }

        public byte method430()
        {
            return (byte) (0x80 - this.buffer[this.currentOffset++]);
        }

        public void method431(int i)
        {
            this.buffer[this.currentOffset++] = (byte) i;
            this.buffer[this.currentOffset++] = (byte) (i >> 8);
			incrementWritten(2);
        }

        public void method432(int j)
        {
            this.buffer[this.currentOffset++] = (byte) (j >> 8);
            this.buffer[this.currentOffset++] = (byte) (j + 0x80);
			incrementWritten(2);
        }

        public void method433(int j)
        {
            this.buffer[this.currentOffset++] = (byte) (j + 0x80);
            this.buffer[this.currentOffset++] = (byte) (j >> 8);
			incrementWritten(2);
        }

        public int method434()
        {
            this.currentOffset += 2;
            return (((this.buffer[this.currentOffset - 1] & 0xff) << 8) + (this.buffer[this.currentOffset - 2] & 0xff));
        }

        public int method435()
        {
            this.currentOffset += 2;
            return (((this.buffer[this.currentOffset - 2] & 0xff) << 8) + ((this.buffer[this.currentOffset - 1] - 0x80) & 0xff));
        }

        public int method436()
        {
            this.currentOffset += 2;
            return (((this.buffer[this.currentOffset - 1] & 0xff) << 8) + ((this.buffer[this.currentOffset - 2] - 0x80) & 0xff));
        }

        public int method437()
        {
            this.currentOffset += 2;
            int num = ((this.buffer[this.currentOffset - 1] & 0xff) << 8) + (this.buffer[this.currentOffset - 2] & 0xff);
            if (num > 0x7fff)
            {
                num -= 0x10000;
            }
            return num;
        }

        public int method438()
        {
            this.currentOffset += 2;
            int num = ((this.buffer[this.currentOffset - 1] & 0xff) << 8) + ((this.buffer[this.currentOffset - 2] - 0x80) & 0xff);
            if (num > 0x7fff)
            {
                num -= 0x10000;
            }
            return num;
        }

        public int method439()
        {
            this.currentOffset += 4;
            return (((((this.buffer[this.currentOffset - 2] & 0xff) << 0x18) + ((this.buffer[this.currentOffset - 1] & 0xff) << 0x10)) + ((this.buffer[this.currentOffset - 4] & 0xff) << 8)) + (this.buffer[this.currentOffset - 3] & 0xff));
        }

        public int method440()
        {
            this.currentOffset += 4;
            return (((((this.buffer[this.currentOffset - 3] & 0xff) << 0x18) + ((this.buffer[this.currentOffset - 4] & 0xff) << 0x10)) + ((this.buffer[this.currentOffset - 1] & 0xff) << 8)) + (this.buffer[this.currentOffset - 2] & 0xff));
        }

        public void method441(int i, byte[] abyte0, int j)
        {
			int written = 0;
            for (int k = (i + j) - 1; k >= i; k--)
            {
                this.buffer[this.currentOffset++] = (byte) (abyte0[k] + 0x80);
				written++;
            }
			incrementWritten(written);
        }

        public void method442(int i, int j, byte[] abyte0)
        {
			//int written = 0;
            for (int k = (j + i) - 1; k >= j; k--)
            {
                abyte0[k] = this.buffer[this.currentOffset++];
				//written
            }
			//incrementWritten(written);
        }

        public int read3Bytes()
        {
            this.currentOffset += 3;
            return ((((this.buffer[this.currentOffset - 3] & 0xff) << 0x10) + ((this.buffer[this.currentOffset - 2] & 0xff) << 8)) + (this.buffer[this.currentOffset - 1] & 0xff));
        }

        public int readBits(int i)
        {
            int index = this.bitPosition >> 3;
            int num2 = 8 - (this.bitPosition & 7);
            int num3 = 0;
            this.bitPosition += i;
            while (i > num2)
            {
                num3 += (this.buffer[index++] & anIntArray1409[num2]) << (i - num2);
                i -= num2;
                num2 = 8;
            }
            if (i == num2)
            {
                return (num3 + (this.buffer[index] & anIntArray1409[num2]));
            }
            return (num3 + ((this.buffer[index] >> (num2 - i)) & anIntArray1409[i]));
        }

        public byte[] readBytes()
        {
            int currentOffset = this.currentOffset;
            while (this.buffer[this.currentOffset++] != 10)
            {
            }
            byte[] destinationArray = new byte[(this.currentOffset - currentOffset) - 1];
            Array.Copy(this.buffer, currentOffset, destinationArray, currentOffset - currentOffset, (this.currentOffset - 1) - currentOffset);
            return destinationArray;
        }

        public void readBytes(int i, int j, byte[] abyte0)
        {
            for (int k = j; k < (j + i); k++)
            {
                abyte0[k] = this.buffer[this.currentOffset++];
            }
        }

        public int readDWord()
        {
            this.currentOffset += 4;
            return (((((this.buffer[this.currentOffset - 4] & 0xff) << 0x18) + ((this.buffer[this.currentOffset - 3] & 0xff) << 0x10)) + ((this.buffer[this.currentOffset - 2] & 0xff) << 8)) + (this.buffer[this.currentOffset - 1] & 0xff));
        }

        public long readQWord()
        {
            long num = this.readDWord() & ((long) 0xffffffffL);
            long num2 = this.readDWord() & ((long) 0xffffffffL);
            return ((num << 0x20) + num2);
        }

        public byte readSignedByte()
        {
            return this.buffer[this.currentOffset++];
        }

        public int readSignedWord()
        {
            this.currentOffset += 2;
            int num = ((this.buffer[this.currentOffset - 2] & 0xff) << 8) + (this.buffer[this.currentOffset - 1] & 0xff);
            if (num > 0x7fff)
            {
                num -= 0x10000;
            }
            return num;
        }

        public string readString()
        {
            int currentOffset = this.currentOffset;
            while (this.buffer[this.currentOffset++] != 10)
            {
            }
            return new string(Encoding.ASCII.GetChars(this.buffer, currentOffset, (this.currentOffset - currentOffset) - 1));
        }

        public int readUnsignedByte()
        {
            return (this.buffer[this.currentOffset++] & 0xff);
        }

        public int readUnsignedWord()
        {
            this.currentOffset += 2;
            return (((this.buffer[this.currentOffset - 2] & 0xff) << 8) + (this.buffer[this.currentOffset - 1] & 0xff));
        }

        public void writeByte(int i)
        {
            this.buffer[this.currentOffset++] = (byte) i;
			incrementWritten(1);
        }

        public void writeBytes(int i)
        {
            this.buffer[(this.currentOffset - i) - 1] = (byte) i;
        }

        public void writeBytes(byte[] abyte0, int i, int j)
        {
			int written = 0;
            for (int k = j; k < (j + i); k++)
            {
                this.buffer[this.currentOffset++] = abyte0[k];
				written++;
            }
			incrementWritten(written);
        }

        public void writeDWord(int i)
        {
            this.buffer[this.currentOffset++] = (byte) (i >> 0x18);
            this.buffer[this.currentOffset++] = (byte) (i >> 0x10);
            this.buffer[this.currentOffset++] = (byte) (i >> 8);
            this.buffer[this.currentOffset++] = (byte) i;
			incrementWritten(4);
        }

        public void writeDWordBigEndian(int i)
        {
            this.buffer[this.currentOffset++] = (byte) (i >> 0x10);
            this.buffer[this.currentOffset++] = (byte) (i >> 8);
            this.buffer[this.currentOffset++] = (byte) i;
			incrementWritten(3);
        }

        public void writeQWord(long l)
        {
            try
            {
                this.buffer[this.currentOffset++] = (byte) ((int) (l >> 0x38));
                this.buffer[this.currentOffset++] = (byte) ((int) (l >> 0x30));
                this.buffer[this.currentOffset++] = (byte) ((int) (l >> 40));
                this.buffer[this.currentOffset++] = (byte) ((int) (l >> 0x20));
                this.buffer[this.currentOffset++] = (byte) ((int) (l >> 0x18));
                this.buffer[this.currentOffset++] = (byte) ((int) (l >> 0x10));
                this.buffer[this.currentOffset++] = (byte) ((int) (l >> 8));
                this.buffer[this.currentOffset++] = (byte) ((int) l);
				incrementWritten(8);
            }
            catch (Exception)
            {
            }
        }

        public void writeString(string s)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);
			int written = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                this.buffer[this.currentOffset + i] = bytes[i];
				written++;
            }
            this.currentOffset += bytes.Length;
            this.buffer[this.currentOffset++] = 10;
			incrementWritten(written + 1);
        }

        public void writeWord(int i)
        {
            this.buffer[this.currentOffset++] = (byte) (i >> 8);
            this.buffer[this.currentOffset++] = (byte) i;
			incrementWritten(2);
        }
    }
}

