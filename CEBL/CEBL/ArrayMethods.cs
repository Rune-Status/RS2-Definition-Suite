namespace CEBL
{
    using System;

    public class ArrayMethods
    {
        public static void copyByteArray(ref byte[,] to, byte[] from, int index)
        {
            for (int i = 0; i < from.Length; i++)
            {
                to[index, i] = from[i];
            }
        }

        public static void copyIntArray(ref int[,] to, int[] from, int index)
        {
            for (int i = 0; i < from.Length; i++)
            {
                to[index, i] = from[i];
            }
        }

        public static byte[] getByteArray(byte[,] from, int index)
        {
            int num = from.GetUpperBound(1) + 1;
            byte[] buffer = new byte[num];
            for (int i = 0; i < num; i++)
            {
                buffer[i] = from[index, i];
            }
            return buffer;
        }

        public static int[] getIntArray(int[,] from, int index)
        {
            int num = from.GetUpperBound(1) + 1;
            int[] numArray = new int[num];
            for (int i = 0; i < num; i++)
            {
                numArray[i] = from[index, i];
            }
            return numArray;
        }
    }
}

