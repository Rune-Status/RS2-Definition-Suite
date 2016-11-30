using CEBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RS2_Definition_Suite.RS319
{

    public class VariableBit
    {

        public static List<VariableBit> cache;
        private static int count;
        public int setting, low, high, unknownIntOpcode3, unknownIntOpcode4;
        public String unknownStringOpcode10;
        private bool unknownBooleanOpcode2;

        public bool UnknownBooleanOpcode2
        {
            set
            {
                unknownBooleanOpcode2 = value;
            }
            get
            {
                return unknownBooleanOpcode2;
            }
        }

        public int UnknownIntOpcode3
        {
            set
            {
                unknownIntOpcode3 = value;
            }
            get
            {
                return unknownIntOpcode3;
            }
        }

        public int UnknownIntOpcode4
        {
            set
            {
                unknownIntOpcode4 = value;
            }
            get
            {
                return unknownIntOpcode4;
            }
        }

        public int Setting
        {
            set
            {
                setting = value;
            }
            get
            {
                return setting;
            }
        }

        public int Low
        {
            set
            {
                low = value;
                if (low > high)
                    low = high - 4;
            }
            get
            {
                return low;
            }
        }

        public int High
        {
            set
            {
                high = value;
                if (high < low)
                    high = low + 4;
            }
            get
            {
                return high;
            }
        }

        public String UnknownStringOpcode10
        {
            set
            {
                unknownStringOpcode10 = value;
            }
            get
            {
                return unknownStringOpcode10;
            }
        }

        public static int getCount()
        {
            return cache.Count;
        }

        public static void init(StreamLoader archive)
        {
            CEBL.Stream buffer = new CEBL.Stream(archive.getDataForName("varbit.dat"));
            count = buffer.readUnsignedWord();
            System.Console.WriteLine("VarBit cache size: " + count);
            if (cache == null)
                cache = new List<VariableBit>(count);

            for (int id = 0; id < count; id++)
            {
                if (cache.ElementAtOrDefault(id) == null)
                {
                    cache.Add(new VariableBit());
                    if (cache.Count - 1 > id)
                        System.Console.WriteLine("BitDefinition above id!");
                }
                cache[id].decode(buffer);
                //if (cache[j].unknownBooleanOpcode2)
                    //VariableParameter.parameters[cache[j].setting].aBoolean713 = true;
            }

            if (buffer.currentOffset != buffer.buffer.Length)
                System.Console.WriteLine("varbit load mismatch");
        }

        public VariableBit() {}

        public VariableBit(int setting, int high, 
            int low, int unknownIntOpcode3, 
            String unknownStringOpcode10, int unknownIntOpcode4, bool unknownBooleanOpcode2) {
            this.Setting = setting;
            this.High = high;
            this.Low = low;
            this.UnknownIntOpcode3 = unknownIntOpcode3;
            this.UnknownStringOpcode10 = unknownStringOpcode10;
            this.UnknownIntOpcode4 = unknownIntOpcode4;
            this.UnknownBooleanOpcode2 = unknownBooleanOpcode2;
        }

        private void decode(CEBL.Stream stream)
        {
            do
            {
                int j = stream.readUnsignedByte();
                if (j == 0)
                    return;
                if (j == 1)
                {
                    setting = stream.readUnsignedWord();
                    low = stream.readUnsignedByte();
                    high = stream.readUnsignedByte();
                }
                else if (j == 10)
                    unknownStringOpcode10 = stream.readString();
                else if (j == 2)
                    unknownBooleanOpcode2 = true;
                else if (j == 3)
                    unknownIntOpcode3 = stream.readDWord();
                else if (j == 4)
                    unknownIntOpcode4 = stream.readDWord();
                else
                    System.Console.WriteLine("Error unrecognised config code: " + j);
            } while (true);
        }

        public static void pack(BinaryWriter writer)
        {
            CEBL.Stream s = new CEBL.Stream(new byte[0x1e8480]);
            s.writeWord(VariableBit.cache.Count);//.writeShort();
            foreach (VariableBit varbit in VariableBit.cache.ToArray()) {
                if (varbit.setting != 0) {
                    s.writeByte(1);
                    s.writeWord(varbit.setting);
                    s.writeByte(varbit.low);
                    s.writeByte(varbit.high);
                }
                if(varbit.unknownBooleanOpcode2 != false)
                {
                    s.writeByte(2);
                }
                if(varbit.unknownStringOpcode10 != null && varbit.unknownStringOpcode10 != "")
                {
                    s.writeByte(10);
                    s.writeString(varbit.unknownStringOpcode10);
                }
                if (varbit.unknownIntOpcode3 != 0) {
                    s.writeByte(3);
                    s.writeDWord(varbit.unknownIntOpcode3);
                }
                if (varbit.unknownIntOpcode3 != 0)
                {
                    s.writeByte(3);
                    s.writeDWord(varbit.unknownIntOpcode3);
                }
                s.writeByte(0);
            }
            int bufferLength = s.currentOffset;
            byte[] destArray = new byte[s.currentOffset];
            Array.Copy(s.buffer, destArray, s.currentOffset);
            if(writer != null && destArray != null)
            {
                writer.Write(destArray, 0, bufferLength);
                writer.Close();
            }
        }

    }
}
