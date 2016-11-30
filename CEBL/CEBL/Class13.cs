namespace CEBL
{
    using System;

    public class Class13
    {
        public static Class32 aClass32_305 = new Class32();

        public static int method225(byte[] abyte0, int i, byte[] abyte1, int j, int k)
        {
            lock (aClass32_305)
            {
                aClass32_305.aByteArray563 = abyte1;
                aClass32_305.anInt564 = k;
                aClass32_305.aByteArray568 = abyte0;
                aClass32_305.anInt569 = 0;
                aClass32_305.anInt565 = j;
                aClass32_305.anInt570 = i;
                aClass32_305.anInt577 = 0;
                aClass32_305.anInt576 = 0;
                aClass32_305.anInt566 = 0;
                aClass32_305.anInt567 = 0;
                aClass32_305.anInt571 = 0;
                aClass32_305.anInt572 = 0;
                aClass32_305.anInt579 = 0;
                method227(ref aClass32_305);
                i -= aClass32_305.anInt570;
                return i;
            }
        }

        private static void method226(ref Class32 class32)
        {
            int num14;
            byte num = class32.aByte573;
            int num2 = class32.anInt574;
            int num3 = class32.anInt584;
            int num4 = class32.anInt582;
            int[] numArray = Class32.anIntArray587;
            int index = class32.anInt581;
            byte[] buffer = class32.aByteArray568;
            int num6 = class32.anInt569;
            int num7 = class32.anInt570;
            int num8 = num7;
            int num9 = class32.anInt601 + 1;
            while (true)
            {
                bool flag2;
                if (num2 > 0)
                {
                    while (true)
                    {
                        if ((num7 == 0) || (num2 == 1))
                        {
                            break;
                        }
                        buffer[num6] = num;
                        num2--;
                        num6++;
                        num7--;
                        flag2 = true;
                    }
                    if (num7 == 0)
                    {
                        num2 = 1;
                        break;
                    }
                    buffer[num6] = num;
                    num6++;
                    num7--;
                }
                bool flag = true;
                while (flag)
                {
                    flag = false;
                    if (num3 == num9)
                    {
                        num2 = 0;
                        goto Label_025B;
                    }
                    num = (byte) num4;
                    index = numArray[index];
                    byte num10 = (byte) (index & 0xff);
                    index = index >> 8;
                    num3++;
                    if (num10 != num4)
                    {
                        num4 = num10;
                        if (num7 == 0)
                        {
                            num2 = 1;
                            break;
                        }
                        buffer[num6] = num;
                        num6++;
                        num7--;
                        flag = true;
                    }
                    else if (num3 == num9)
                    {
                        if (num7 == 0)
                        {
                            num2 = 1;
                            break;
                        }
                        buffer[num6] = num;
                        num6++;
                        num7--;
                        flag = true;
                    }
                }
                num2 = 2;
                index = numArray[index];
                byte num11 = (byte) (index & 0xff);
                index = index >> 8;
                if (++num3 != num9)
                {
                    if (num11 != num4)
                    {
                        num4 = num11;
                    }
                    else
                    {
                        num2 = 3;
                        index = numArray[index];
                        byte num12 = (byte) (index & 0xff);
                        index = index >> 8;
                        if (++num3 != num9)
                        {
                            if (num12 != num4)
                            {
                                num4 = num12;
                            }
                            else
                            {
                                index = numArray[index];
                                byte num13 = (byte) (index & 0xff);
                                index = index >> 8;
                                num3++;
                                num2 = (num13 & 0xff) + 4;
                                index = numArray[index];
                                num4 = (byte) (index & 0xff);
                                index = index >> 8;
                                num3++;
                            }
                        }
                    }
                }
                flag2 = true;
            }
        Label_025B:
            num14 = class32.anInt571;
            class32.anInt571 += num8 - num7;
            if (class32.anInt571 < num14)
            {
                class32.anInt572++;
            }
            class32.aByte573 = num;
            class32.anInt574 = num2;
            class32.anInt584 = num3;
            class32.anInt582 = num4;
            Class32.anIntArray587 = numArray;
            class32.anInt581 = index;
            class32.aByteArray568 = buffer;
            class32.anInt569 = num6;
            class32.anInt570 = num7;
        }

        private static void method227(ref Class32 class32)
        {
            int num = 0;
            int[] numArray = null;
            int[] numArray2 = null;
            int[] numArray3 = null;
            class32.anInt578 = 1;
            if (Class32.anIntArray587 == null)
            {
                Class32.anIntArray587 = new int[class32.anInt578 * 0x186a0];
            }
            for (bool flag = true; flag; flag = (class32.anInt584 == (class32.anInt601 + 1)) && (class32.anInt574 == 0))
            {
                bool flag2;
                if (method228(ref class32) == 0x17)
                {
                    break;
                }
                byte num2 = method228(ref class32);
                num2 = method228(ref class32);
                num2 = method228(ref class32);
                num2 = method228(ref class32);
                num2 = method228(ref class32);
                class32.anInt579++;
                num2 = method228(ref class32);
                num2 = method228(ref class32);
                num2 = method228(ref class32);
                num2 = method228(ref class32);
                num2 = method229(ref class32);
                class32.aBoolean575 = num2 != 0;
                class32.anInt580 = 0;
                num2 = method228(ref class32);
                class32.anInt580 = (class32.anInt580 << 8) | (num2 & 0xff);
                num2 = method228(ref class32);
                class32.anInt580 = (class32.anInt580 << 8) | (num2 & 0xff);
                num2 = method228(ref class32);
                class32.anInt580 = (class32.anInt580 << 8) | (num2 & 0xff);
                for (int i = 0; i < 0x10; i++)
                {
                    byte num4 = method229(ref class32);
                    class32.aBooleanArray590[i] = num4 == 1;
                }
                for (int j = 0; j < 0x100; j++)
                {
                    class32.aBooleanArray589[j] = false;
                }
                for (int k = 0; k < 0x10; k++)
                {
                    if (class32.aBooleanArray590[k])
                    {
                        for (int num7 = 0; num7 < 0x10; num7++)
                        {
                            if (method229(ref class32) == 1)
                            {
                                class32.aBooleanArray589[(k * 0x10) + num7] = true;
                            }
                        }
                    }
                }
                method231(ref class32);
                int num9 = class32.anInt588 + 2;
                int num10 = method230(3, ref class32);
                int num11 = method230(15, ref class32);
                for (int m = 0; m < num11; m++)
                {
                    int num13 = 0;
                    while (true)
                    {
                        if (method229(ref class32) == 0)
                        {
                            break;
                        }
                        num13++;
                        flag2 = true;
                    }
                    class32.aByteArray595[m] = (byte) num13;
                }
                byte[] buffer = new byte[6];
                for (byte n = 0; n < num10; n = (byte) (n + 1))
                {
                    buffer[n] = n;
                }
                for (int num16 = 0; num16 < num11; num16++)
                {
                    byte num17 = class32.aByteArray595[num16];
                    byte num18 = buffer[num17];
                    while (num17 > 0)
                    {
                        buffer[num17] = buffer[num17 - 1];
                        num17 = (byte) (num17 - 1);
                    }
                    buffer[0] = num18;
                    class32.aByteArray594[num16] = num18;
                }
                for (int num19 = 0; num19 < num10; num19++)
                {
                    int num20 = method230(5, ref class32);
                    for (int num21 = 0; num21 < num9; num21++)
                    {
                        while (true)
                        {
                            if (method229(ref class32) == 0)
                            {
                                break;
                            }
                            if (method229(ref class32) == 0)
                            {
                                num20++;
                            }
                            else
                            {
                                num20--;
                            }
                            flag2 = true;
                        }
                        class32.aByteArrayArray596[num19][num21] = (byte) num20;
                    }
                }
                for (int num23 = 0; num23 < num10; num23++)
                {
                    byte num24 = 0x20;
                    int num25 = 0;
                    for (int num26 = 0; num26 < num9; num26++)
                    {
                        if (class32.aByteArrayArray596[num23][num26] > num25)
                        {
                            num25 = class32.aByteArrayArray596[num23][num26];
                        }
                        if (class32.aByteArrayArray596[num23][num26] < num24)
                        {
                            num24 = class32.aByteArrayArray596[num23][num26];
                        }
                    }
                    method232(ref class32.anIntArrayArray597[num23], ref class32.anIntArrayArray598[num23], ref class32.anIntArrayArray599[num23], ref class32.aByteArrayArray596[num23], num24, num25, num9);
                    class32.anIntArray600[num23] = num24;
                }
                int num27 = class32.anInt588 + 1;
                int num28 = 0x186a0 * class32.anInt578;
                int index = -1;
                int num30 = 0;
                for (int num31 = 0; num31 <= 0xff; num31++)
                {
                    class32.anIntArray583[num31] = 0;
                }
                int num32 = 0xfff;
                for (int num33 = 15; num33 >= 0; num33--)
                {
                    for (int num34 = 15; num34 >= 0; num34--)
                    {
                        class32.aByteArray592[num32] = (byte) ((num33 * 0x10) + num34);
                        num32--;
                    }
                    class32.anIntArray593[num33] = num32 + 1;
                }
                int num35 = 0;
                if (num30 == 0)
                {
                    index++;
                    num30 = 50;
                    byte num36 = class32.aByteArray594[index];
                    num = class32.anIntArray600[num36];
                    numArray = class32.anIntArrayArray597[num36];
                    numArray3 = class32.anIntArrayArray599[num36];
                    numArray2 = class32.anIntArrayArray598[num36];
                }
                num30--;
                int num37 = num;
                int num38 = method230(num37, ref class32);
                while (num38 > numArray[num37])
                {
                    num37++;
                    byte num39 = method229(ref class32);
                    num38 = (num38 << 1) | num39;
                }
                int num40 = numArray3[num38 - numArray2[num37]];
                while (num40 != num27)
                {
                    int num48;
                    byte num49;
                    if ((num40 != 0) && (num40 != 1))
                    {
                        goto Label_072E;
                    }
                    int num41 = -1;
                    int num42 = 1;
                Label_05D0:
                    if (num40 == 0)
                    {
                        num41 += num42;
                    }
                    else if (num40 == 1)
                    {
                        num41 += 2 * num42;
                    }
                    num42 *= 2;
                    if (num30 == 0)
                    {
                        index++;
                        num30 = 50;
                        byte num43 = class32.aByteArray594[index];
                        num = class32.anIntArray600[num43];
                        numArray = class32.anIntArrayArray597[num43];
                        numArray3 = class32.anIntArrayArray599[num43];
                        numArray2 = class32.anIntArrayArray598[num43];
                    }
                    num30--;
                    int num44 = num;
                    int num45 = method230(num44, ref class32);
                    while (num45 > numArray[num44])
                    {
                        num44++;
                        byte num46 = method229(ref class32);
                        num45 = (num45 << 1) | num46;
                    }
                    num40 = numArray3[num45 - numArray2[num44]];
                    switch (num40)
                    {
                        case 0:
                        case 1:
                            goto Label_05D0;

                        default:
                        {
                            num41++;
                            byte num47 = class32.aByteArray591[class32.aByteArray592[class32.anIntArray593[0]] & 0xff];
                            class32.anIntArray583[num47 & 0xff] += num41;
                            while (num41 > 0)
                            {
                                Class32.anIntArray587[num35] = num47 & 0xff;
                                num35++;
                                num41--;
                            }
                            continue;
                        }
                    }
                Label_072E:
                    num48 = num40 - 1;
                    if (num48 < 0x10)
                    {
                        int num50 = class32.anIntArray593[0];
                        num49 = class32.aByteArray592[num50 + num48];
                        while (num48 > 3)
                        {
                            int num51 = num50 + num48;
                            class32.aByteArray592[num51] = class32.aByteArray592[num51 - 1];
                            class32.aByteArray592[num51 - 1] = class32.aByteArray592[num51 - 2];
                            class32.aByteArray592[num51 - 2] = class32.aByteArray592[num51 - 3];
                            class32.aByteArray592[num51 - 3] = class32.aByteArray592[num51 - 4];
                            num48 -= 4;
                        }
                        while (num48 > 0)
                        {
                            class32.aByteArray592[num50 + num48] = class32.aByteArray592[(num50 + num48) - 1];
                            num48--;
                        }
                        class32.aByteArray592[num50] = num49;
                    }
                    else
                    {
                        int num52 = num48 / 0x10;
                        int num53 = num48 % 0x10;
                        int num54 = class32.anIntArray593[num52] + num53;
                        num49 = class32.aByteArray592[num54];
                        while (num54 > class32.anIntArray593[num52])
                        {
                            class32.aByteArray592[num54] = class32.aByteArray592[num54 - 1];
                            num54--;
                        }
                        class32.anIntArray593[num52]++;
                        while (num52 > 0)
                        {
                            class32.anIntArray593[num52]--;
                            class32.aByteArray592[class32.anIntArray593[num52]] = class32.aByteArray592[(class32.anIntArray593[num52 - 1] + 0x10) - 1];
                            num52--;
                        }
                        class32.anIntArray593[0]--;
                        class32.aByteArray592[class32.anIntArray593[0]] = num49;
                        if (class32.anIntArray593[0] == 0)
                        {
                            int num55 = 0xfff;
                            for (int num56 = 15; num56 >= 0; num56--)
                            {
                                for (int num57 = 15; num57 >= 0; num57--)
                                {
                                    class32.aByteArray592[num55] = class32.aByteArray592[class32.anIntArray593[num56] + num57];
                                    num55--;
                                }
                                class32.anIntArray593[num56] = num55 + 1;
                            }
                        }
                    }
                    class32.anIntArray583[class32.aByteArray591[num49 & 0xff] & 0xff]++;
                    Class32.anIntArray587[num35] = class32.aByteArray591[num49 & 0xff] & 0xff;
                    num35++;
                    if (num30 == 0)
                    {
                        index++;
                        num30 = 50;
                        byte num58 = class32.aByteArray594[index];
                        num = class32.anIntArray600[num58];
                        numArray = class32.anIntArrayArray597[num58];
                        numArray3 = class32.anIntArrayArray599[num58];
                        numArray2 = class32.anIntArrayArray598[num58];
                    }
                    num30--;
                    int num59 = num;
                    int num60 = method230(num59, ref class32);
                    while (num60 > numArray[num59])
                    {
                        num59++;
                        byte num61 = method229(ref class32);
                        num60 = (num60 << 1) | num61;
                    }
                    num40 = numArray3[num60 - numArray2[num59]];
                }
                class32.anInt574 = 0;
                class32.aByte573 = 0;
                class32.anIntArray585[0] = 0;
                for (int num62 = 1; num62 <= 0x100; num62++)
                {
                    class32.anIntArray585[num62] = class32.anIntArray583[num62 - 1];
                }
                for (int num63 = 1; num63 <= 0x100; num63++)
                {
                    class32.anIntArray585[num63] += class32.anIntArray585[num63 - 1];
                }
                for (int num64 = 0; num64 < num35; num64++)
                {
                    byte num65 = (byte) (Class32.anIntArray587[num64] & 0xff);
                    Class32.anIntArray587[class32.anIntArray585[num65 & 0xff]] |= num64 << 8;
                    class32.anIntArray585[num65 & 0xff]++;
                }
                class32.anInt581 = Class32.anIntArray587[class32.anInt580] >> 8;
                class32.anInt584 = 0;
                class32.anInt581 = Class32.anIntArray587[class32.anInt581];
                class32.anInt582 = (byte) (class32.anInt581 & 0xff);
                class32.anInt581 = class32.anInt581 >> 8;
                class32.anInt584++;
                class32.anInt601 = num35;
                method226(ref class32);
            }
        }

        public static byte method228(ref Class32 class32)
        {
            return (byte) method230(8, ref class32);
        }

        public static byte method229(ref Class32 class32)
        {
            return (byte) method230(1, ref class32);
        }

        public static int method230(int i, ref Class32 class32)
        {
            while (true)
            {
                if (class32.anInt577 >= i)
                {
                    int num2 = (class32.anInt576 >> (class32.anInt577 - i)) & ((((int) 1) << i) - 1);
                    class32.anInt577 -= i;
                    return num2;
                }
                class32.anInt576 = (class32.anInt576 << 8) | (class32.aByteArray563[class32.anInt564] & 0xff);
                class32.anInt577 += 8;
                class32.anInt564++;
                class32.anInt565--;
                class32.anInt566++;
                if (class32.anInt566 == 0)
                {
                    class32.anInt567++;
                }
            }
        }

        public static void method231(ref Class32 class32)
        {
            class32.anInt588 = 0;
            for (int i = 0; i < 0x100; i++)
            {
                if (class32.aBooleanArray589[i])
                {
                    class32.aByteArray591[class32.anInt588] = (byte) i;
                    class32.anInt588++;
                }
            }
        }

        private static void method232(ref int[] ai, ref int[] ai1, ref int[] ai2, ref byte[] abyte0, int i, int j, int k)
        {
            int index = 0;
            for (int m = i; m <= j; m++)
            {
                for (int num3 = 0; num3 < k; num3++)
                {
                    if (abyte0[num3] == m)
                    {
                        ai2[index] = num3;
                        index++;
                    }
                }
            }
            for (int n = 0; n < 0x17; n++)
            {
                ai1[n] = 0;
            }
            for (int num5 = 0; num5 < k; num5++)
            {
                ai1[abyte0[num5] + 1]++;
            }
            for (int num6 = 1; num6 < 0x17; num6++)
            {
                ai1[num6] += ai1[num6 - 1];
            }
            for (int num7 = 0; num7 < 0x17; num7++)
            {
                ai[num7] = 0;
            }
            int num8 = 0;
            for (int num9 = i; num9 <= j; num9++)
            {
                num8 += ai1[num9 + 1] - ai1[num9];
                ai[num9] = num8 - 1;
                num8 = num8 << 1;
            }
            for (int num10 = i + 1; num10 <= j; num10++)
            {
                ai1[num10] = ((ai[num10 - 1] + 1) << 1) - ai1[num10];
            }
        }
    }
}

