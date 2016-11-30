using CEBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RS2_Definition_Suite.RS319
{

    public class VariableParameter
    {

        public static List<VariableParameter> parameters;
        private static int count;

        private int parameter;
        private int unknownIntOpcode1;
        private int unknownIntOpcode12;
        private int unknownIntOpcode2;
        private int unknownIntOpcode7;
        private string unknownStringOpcode10;
        public bool aBoolean713;

        public bool UnknownBooleanOpcode811
        {
            set
            {
                aBoolean713 = value;
            }
            get
            {
                return aBoolean713;
            }
        }

        public int UnknownIntOpcode1
        {
            set
            {
                unknownIntOpcode1 = value;
            }
            get
            {
                return unknownIntOpcode1;
            }
        }

        public int UnknownIntOpcode2
        {
            set
            {
                unknownIntOpcode2 = value;
            }
            get
            {
                return unknownIntOpcode2;
            }
        }
        public int UnknownIntOpcode7
        {
            set
            {
                unknownIntOpcode7 = value;
            }
            get
            {
                return unknownIntOpcode7;
            }
        }
        public int UnknownIntOpcode12
        {
            set
            {
                unknownIntOpcode12 = value;
            }
            get
            {
                return unknownIntOpcode12;
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

        public int Parameter
        {
            set
            {
                parameter = value;
            }
            get
            {
                return parameter;
            }
        }

        public static int getCount()
        {
            return parameters.Count;
        }

        public static void init(StreamLoader archive)
        {
            CEBL.Stream buffer = new CEBL.Stream(archive.getDataForName("varp.dat"));
            count = buffer.readUnsignedWord();
            if (parameters == null)
            {
                parameters = new List<VariableParameter>(count);
            }

            for (int id = 0; id < count; id++)
            {
                if (parameters.ElementAtOrDefault(id) == null)
                {
                    parameters.Add(new VariableParameter());
                    if (parameters.Count - 1 > id)
                        System.Console.WriteLine("Parameters above id!");
                }
                parameters[id].decode(buffer);
            }

            if (buffer.currentOffset != buffer.buffer.Length)
            {
                System.Console.WriteLine("varptype load mismatch");
            }
        }


        public VariableParameter() {
            aBoolean713 = false;
        }

        public VariableParameter(int parameter, int unknownIntOpcode1, 
            int unknownIntOpcode2, int unknownIntOpcode7, 
            String unknownStringOpcode10, int unknownIntOpcode12) {
            this.Parameter = parameter;
            this.UnknownIntOpcode1 = unknownIntOpcode1;
            this.UnknownIntOpcode2 = unknownIntOpcode2;
            this.UnknownIntOpcode7 = unknownIntOpcode7;
            this.UnknownStringOpcode10 = unknownStringOpcode10;
            this.UnknownIntOpcode12 = unknownIntOpcode12;
            aBoolean713 = false;
        }


        public void decode(CEBL.Stream buffer)
        {
            do
            {
                int opcode = buffer.readUnsignedByte();
                if (opcode == 0)
                {
                    return;
                }

                if (opcode == 1)
                {
                    unknownIntOpcode1 = buffer.readUnsignedByte();
                }
                else if (opcode == 2)
                {
                    unknownIntOpcode2 = buffer.readUnsignedByte();
                }
                else if (opcode == 5)
                {
                    parameter = buffer.readUnsignedWord();
                }
                else if (opcode == 7)
                {
                    unknownIntOpcode7 = buffer.readDWord();
                }
                else if(opcode == 8)
                {
                    aBoolean713 = true;
                }
                else if (opcode == 10)
                {
                    unknownStringOpcode10 = buffer.readString();
                } else if(opcode == 11)
                {
                    aBoolean713 = true;
                }
                else if (opcode == 12)
                {
                    unknownIntOpcode12 = buffer.readDWord();
                }
                else if (opcode != 4 || opcode != 6 || opcode != 13)
                {
                    System.Console.WriteLine("Error unrecognised config code: " + opcode);
                }
            } while (true);
        }

        public static void pack(BinaryWriter writer)
        {
            CEBL.Stream s = new CEBL.Stream(new byte[0x1e8480]);
            s.writeWord(VariableParameter.parameters.Count);//.writeShort();
            foreach (VariableParameter varp in VariableParameter.parameters.ToArray()) {
                if (varp.UnknownIntOpcode1 != 0) {
                    s.writeByte(1);
                    s.writeByte(varp.UnknownIntOpcode1);
                }
                if (varp.UnknownIntOpcode2 != 0) {
                    s.writeByte(2);
                    s.writeByte(varp.UnknownIntOpcode2);
                }
                //if (varp.anIntArray703 != null) {
                //    dat.writeByte(3);
                //}
                if (varp.parameter != 0) {
                    s.writeByte(5);
                    s.writeWord(varp.parameter);
                    //System.out.println(varp.parameter);
                }
                if (varp.UnknownIntOpcode7 != 0) {
                    s.writeByte(7);
                    s.writeDWord(varp.UnknownIntOpcode7);
                }
                if (varp.aBoolean713) {
                    s.writeByte(8);
                }
                if (varp.UnknownStringOpcode10 != null) {
                    s.writeByte(10);
                    s.writeString(varp.UnknownStringOpcode10);
                }
                if (varp.aBoolean713) {
                    s.writeByte(11);
                }
                if (varp.UnknownIntOpcode12 != 0) {
                    s.writeDWord(varp.UnknownIntOpcode12);
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
