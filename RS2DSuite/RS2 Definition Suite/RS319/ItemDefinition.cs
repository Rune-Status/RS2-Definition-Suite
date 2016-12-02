using CEBL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Definition_Suite.RS319
{
    class ItemDefinition
    {
        public static void pack(String loc)
        {
            BinaryWriter datFile = new BinaryWriter(File.Create(loc + "obj.dat"));
            CEBL.Stream dat = new CEBL.Stream(new byte[0x1e8480]);
            BinaryWriter idxFile = new BinaryWriter(File.Create(loc + "obj.idx"));
            CEBL.Stream idx = new CEBL.Stream(new byte[0x1e8480]);
            idx.writeWord(totalItems);
            dat.writeWord(totalItems);
            for (int i = 0; i < totalItems; i++)
            {
                ItemDefinition item = ItemDefinition.get(i);
                int offset1 = dat.size();
                if (item.groundModel != 0)
                {
                    dat.writeByte(1);
                    dat.writeWord(item.groundModel);
                }
                if (item.name != "null")
                {
                    dat.writeByte(2);
                    dat.writeString(item.name);
                    //dat.writeByte(3);
                    //dat.writeString("It's a " + item.name + "");
                }
                if (item.description != null)
                {
                    dat.writeByte(3);
                    dat.writeBytes(item.description, item.description.Length, 0);
                } else
                {
                    byte[] description = Encoding.ASCII.GetBytes("It's a " + item.name + ".");
                    dat.writeByte(3);
                    dat.writeBytes(description, description.Length, 0);
                }
                if (item.modelZoom != 2000)
                {
                    dat.writeByte(4);
                    dat.writeWord(item.modelZoom);
                }
                if (item.rotationY != 0)
                {
                    dat.writeByte(5);
                    dat.writeWord(item.rotationY);
                }
                if (item.rotationX != 0)
                {
                    dat.writeByte(6);
                    dat.writeWord(item.rotationX);
                }
                if (item.offsetX != 0)
                {
                    dat.writeByte(7);
                    dat.writeWord(item.offsetX);
                }
                if (item.offsetY != 0)
                {
                    dat.writeByte(8);
                    dat.writeWord(item.offsetY);
                }
                if (item.stackable)
                {
                    dat.writeByte(11);
                }
                if (item.value != 1)
                {
                    dat.writeByte(12);
                    dat.writeDWord(item.value);
                }
                if (item.membersObject)
                {
                    dat.writeByte(16);
                }
                if (item.maleModel != -1)
                {
                    dat.writeByte(23);
                    dat.writeWord(item.maleModel);
                    dat.writeByte(0);
                }
                if (item.maleArm != -1)
                {
                    dat.writeByte(24);
                    dat.writeWord(item.maleArm);
                }
                if (item.femaleModel != -1)
                {
                    dat.writeByte(25);
                    dat.writeWord(item.femaleModel);
                    dat.writeByte(0);
                }
                if (item.femaleArm != -1)
                {
                    dat.writeByte(26);
                    dat.writeWord(item.femaleArm);
                }
                if (item.groundActions != null)
                {
                    for (int ii = 0; ii < item.groundActions.Length; ii++)
                    {
                        if (item.groundActions[ii] == null)
                        {
                            continue;
                        }
                        dat.writeByte(30 + ii);
                        dat.writeString(item.groundActions[ii]);
                    }
                }
                if (item.inventoryActions != null)
                {
                    for (int z = 0; z < item.inventoryActions.Length; z++)
                    {
                        if (item.inventoryActions[z] == null)
                        {
                            continue;
                        }
                        dat.writeByte(35 + z);
                        dat.writeString(item.inventoryActions[z]);
                    }
                }
                if (item.srcColors != null || item.destColors != null)
                {
                    dat.writeByte(40);
                    dat.writeByte(item.srcColors.Length);
                    for (int ii = 0; ii < item.srcColors.Length; ii++)
                    {
                        dat.writeWord(item.srcColors[ii]);
                        dat.writeWord(item.destColors[ii]);
                    }
                }
                if (item.maleEmblem != -1)
                {
                    dat.writeByte(78);
                    dat.writeWord(item.maleEmblem);
                }
                if (item.femaleEmblem != -1)
                {
                    dat.writeByte(79);
                    dat.writeWord(item.femaleEmblem);
                }
                if (item.maleDialogue != -1)
                {
                    dat.writeByte(90);
                    dat.writeWord(item.maleDialogue);
                }
                if (item.femaleDialogue != -1)
                {
                    dat.writeByte(91);
                    dat.writeWord(item.femaleDialogue);
                }
                if (item.maleHat != -1)
                {
                    dat.writeByte(92);
                    dat.writeWord(item.maleHat);
                }
                if (item.femaleHat != -1)
                {
                    dat.writeByte(93);
                    dat.writeWord(item.femaleHat);
                }
                if (item.scaleInventory != 0)
                {
                    dat.writeByte(95);
                    dat.writeWord(item.scaleInventory);
                }
                if (item.certId != -1)
                {
                    dat.writeByte(97);
                    dat.writeWord(item.certId);
                }
                if (item.certTemplateId != -1)
                {
                    dat.writeByte(98);
                    dat.writeWord(item.certTemplateId);
                }
                if (item.stackIds != null)
                {
                    for (int ii = 0; ii < item.stackIds.Length; ii++)
                    {
                        dat.writeByte(100 + ii);
                        dat.writeWord(item.stackIds[ii]);
                        dat.writeWord(item.stackAmounts[ii]);
                    }
                }
                if (item.scaleX != 128)
                {
                    dat.writeByte(110);
                    dat.writeWord(item.scaleX);
                }
                if (item.scaleZ != 128)
                {
                    dat.writeByte(111);
                    dat.writeWord(item.scaleZ);
                }
                if (item.scaleY != 128)
                {
                    dat.writeByte(112);
                    dat.writeWord(item.scaleY);
                }
                if (item.lightness != 0)
                {
                    dat.writeByte(113);
                    dat.writeByte(item.lightness);
                }
                if (item.shading != 0)
                {
                    dat.writeByte(114);
                    dat.writeByte(item.shading / 5);
                }
                if (item.team != 0)
                {
                    dat.writeByte(115);
                    dat.writeByte(item.team);
                }
                dat.writeByte(0);
                int offset2 = dat.size();
                int writeOffset = offset2 - offset1;
                idx.writeWord(writeOffset);
            }
            int bufferLength1 = dat.currentOffset;
            byte[] destArray1 = new byte[dat.currentOffset];
            Array.Copy(dat.buffer, destArray1, dat.currentOffset);
            if (datFile != null && destArray1 != null)
            {
                datFile.Write(destArray1, 0, bufferLength1);
                datFile.Close();
            }
            int bufferLength2 = idx.currentOffset;
            byte[] destArray2 = new byte[idx.currentOffset];
            Array.Copy(idx.buffer, destArray2, idx.currentOffset);
            if (idxFile != null && destArray2 != null)
            {
                idxFile.Write(destArray2, 0, bufferLength2);
                idxFile.Close();
            }
        }

        public static void nullLoader()
        {
            //mruNodes2 = null;
            //mruNodes1 = null;
            streamIndices = null;
            cache = null;
            stream = null;
        }

        public static void init(StreamLoader streamLoader)
        {
            ItemDefinition.stream = new CEBL.Stream(streamLoader.getDataForName("obj.dat"));
            CEBL.Stream stream = new CEBL.Stream(streamLoader.getDataForName("obj.idx"));
            totalItems = stream.readUnsignedWord();
            streamIndices = new int[totalItems];
            int i = 2;
            for (int j = 0; j < totalItems; j++)
            {
                streamIndices[j] = i;
                i += stream.readUnsignedWord();
            }

            cache = new ItemDefinition[10];
            for (int k = 0; k < 10; k++)
            {
                cache[k] = new ItemDefinition();
            }

            //itemDump(totalItems);
        }

        private void setDefaults()
        {
            groundModel = 0;
            name = null;
            description = null;
            srcColors = null;
            destColors = null;
            modelZoom = 2000;
            rotationY = 0;
            rotationX = 0;
            scaleInventory = 0;
            offsetX = 0;
            offsetY = 0;
            stackable = false;
            value = 1;
            membersObject = false;
            groundActions = null;
            inventoryActions = null;
            maleModel = -1;
            maleArm = -1;
            unknownByte0 = 0;
            femaleModel = -1;
            femaleArm = -1;
            unknownByte1 = 0;
            maleEmblem = -1;
            femaleEmblem = -1;
            maleDialogue = -1;
            maleHat = -1;
            femaleDialogue = -1;
            femaleHat = -1;
            stackIds = null;
            stackAmounts = null;
            certId = -1;
            certTemplateId = -1;
            scaleX = 128;
            scaleZ = 128;
            scaleY = 128;
            lightness = 0;
            shading = 0;
            team = 0;
        }

        public static ItemDefinition get(int i)
        {
            for (int j = 0; j < 10; j++)
            {
                if (cache[j].id == i)
                {
                    return cache[j];
                }
            }

            cacheIndex = (cacheIndex + 1) % 10;
            ItemDefinition itemDef = cache[cacheIndex];
            if (i < streamIndices.Length)
            {
                stream.currentOffset = streamIndices[i];
                itemDef.id = i;
                itemDef.setDefaults();
                itemDef.decode(stream);
                if (itemDef.certTemplateId != -1)
                {
                    itemDef.toNote();
                }
                if (!isMembers && itemDef.membersObject)
                {
                    itemDef.name = "Members Object";
                    itemDef.description = Encoding.ASCII.GetBytes("Login to a members' server to use this object.");
                    itemDef.groundActions = null;
                    itemDef.inventoryActions = null;
                    itemDef.team = 0;
                }
            }
            else
            {
                itemDef.id = i;
                itemDef.setDefaults();
            }
            /*if (itemDef.id == 6541)
            {
                itemDef.name = "Dragon sword";
                itemDef.modelZoom = 1275;
                itemDef.modelRotation1 = 1549;
                itemDef.modelRotation2 = 1818;
                itemDef.modelOffset2 = 9;
                itemDef.groundActions = new String[] { null, null, "Take", null, null };
                itemDef.actions = new String[] { null, "Wield", null, null, "Drop" };
                itemDef.modelID = 9357;
                itemDef.anInt165 = 9357;
                itemDef.anInt200 = 9357;
                itemDef.description = "This weapon made using ancient metals, has perfect length!".getBytes();
            }*/
            return itemDef;
        }

        private void toNote()
        {
            ItemDefinition itemDef = get(certTemplateId);
            groundModel = itemDef.groundModel;
            modelZoom = itemDef.modelZoom;
            rotationY = itemDef.rotationY;
            rotationX = itemDef.rotationX;

            scaleInventory = itemDef.scaleInventory;
            offsetX = itemDef.offsetX;
            offsetY = itemDef.offsetY;
            srcColors = itemDef.srcColors;
            destColors = itemDef.destColors;
            ItemDefinition itemDef_1 = get(certId);
            name = itemDef_1.name;
            membersObject = itemDef_1.membersObject;
            value = itemDef_1.value;
            String s = "a";
            if (itemDef_1 != null && itemDef_1.name != null) {
                char c = itemDef_1.name[0];
                if (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                {
                    s = "an";
                }
            }
            description = Encoding.ASCII.GetBytes(("Swap this note at any bank for " + s + " " + itemDef_1.name + "."));
            stackable = true;
        }

        private void decode(CEBL.Stream stream)
        {
            do
            {
                int i = stream.readUnsignedByte();
                if (i == 0)
                {
                    break;
                }
                if (i == 1)
                {
                    groundModel = stream.readUnsignedWord();
                }
                else if (i == 2)
                {
                    name = stream.readString();
                }
                else if (i == 3)
                {
                    description = stream.readBytes();
                }
                else if (i == 4)
                {
                    modelZoom = stream.readUnsignedWord();
                }
                else if (i == 5)
                {
                    rotationY = stream.readUnsignedWord();
                }
                else if (i == 6)
                {
                    rotationX = stream.readUnsignedWord();
                }
                else if (i == 7)
                {
                    offsetX = stream.readUnsignedWord();
                    if (offsetX > 32767)
                    {
                        offsetX -= 0x10000;
                    }
                }
                else if (i == 8)
                {
                    offsetY = stream.readUnsignedWord();
                    if (offsetY > 32767)
                    {
                        offsetY -= 0x10000;
                    }
                }
                else if (i == 10)
                {
                    dummyValue = stream.readUnsignedWord();
                }
                else if (i == 11)
                {
                    stackable = true;
                }
                else if (i == 12)
                {
                    value = stream.readDWord();
                }
                else if (i == 16)
                {
                    membersObject = true;
                }
                else if (i == 23)
                {
                    maleModel = stream.readUnsignedWord();
                    unknownByte0 = stream.readSignedByte();
                }
                else if (i == 24)
                {
                    maleArm = stream.readUnsignedWord();
                }
                else if (i == 25)
                {
                    femaleModel = stream.readUnsignedWord();
                    unknownByte1 = stream.readSignedByte();
                }
                else if (i == 26)
                {
                    femaleArm = stream.readUnsignedWord();
                }
                else if (i >= 30 && i < 35)
                {
                    if (groundActions == null)
                    {
                        groundActions = new String[5];
                    }
                    groundActions[i - 30] = stream.readString();
                    if (groundActions[i - 30].Equals("hidden"))
                    {
                        groundActions[i - 30] = null;
                    }
                }
                else if (i >= 35 && i < 40)
                {
                    if (inventoryActions == null)
                    {
                        inventoryActions = new String[5];
                    }
                    inventoryActions[i - 35] = stream.readString();
                }
                else if (i == 40)
                {
                    int j = stream.readUnsignedByte();
                    srcColors = new int[j];
                    destColors = new int[j];
                    for (int k = 0; k < j; k++)
                    {
                        srcColors[k] = stream.readUnsignedWord();
                        destColors[k] = stream.readUnsignedWord();
                    }

                }
                else if (i == 78)
                {
                    maleEmblem = stream.readUnsignedWord();
                }
                else if (i == 79)
                {
                    femaleEmblem = stream.readUnsignedWord();
                }
                else if (i == 90)
                {
                    maleDialogue = stream.readUnsignedWord();
                }
                else if (i == 91)
                {
                    femaleDialogue = stream.readUnsignedWord();
                }
                else if (i == 92)
                {
                    maleHat = stream.readUnsignedWord();
                }
                else if (i == 93)
                {
                    femaleHat = stream.readUnsignedWord();
                }
                else if (i == 95)
                {
                    scaleInventory = stream.readUnsignedWord();
                }
                else if (i == 97)
                {
                    certId = stream.readUnsignedWord();
                }
                else if (i == 98)
                {
                    certTemplateId = stream.readUnsignedWord();
                }
                else if (i >= 100 && i < 110)
                {
                    if (stackIds == null)
                    {
                        stackIds = new int[10];
                        stackAmounts = new int[10];
                    }
                    stackIds[i - 100] = stream.readUnsignedWord();
                    stackAmounts[i - 100] = stream.readUnsignedWord();
                }
                else if (i == 110)
                {
                    scaleX = stream.readUnsignedWord();
                }
                else if (i == 111)
                {
                    scaleZ = stream.readUnsignedWord();
                }
                else if (i == 112)
                {
                    scaleY = stream.readUnsignedWord();
                }
                else if (i == 113)
                {
                    lightness = stream.readSignedByte();
                }
                else if (i == 114)
                {
                    shading = stream.readSignedByte() * 5;
                }
                else if (i == 115)
                {
                    team = stream.readUnsignedByte();
                }
            } while (true);
        }

        private ItemDefinition()
        {
            id = -1;
        }

        private byte unknownByte1;
        public int value;
        private int[] srcColors;
        public int id;
        //public static MRUNodes mruNodes1 = new MRUNodes(100);
        //public static MRUNodes mruNodes2 = new MRUNodes(50);
        private int[] destColors;
        public bool membersObject;
        private int femaleEmblem;
        private int certTemplateId;
        private int femaleArm;
        private int maleModel;
        private int maleHat;
        private int scaleX;
        public String[] groundActions;
        private int offsetX;
        public String name;
        private static ItemDefinition[] cache;
        private int femaleHat;
        private int groundModel;
        private int maleDialogue;
        public bool stackable;
        public byte[] description;
        private int certId;
        private static int cacheIndex;
        public int modelZoom;
        public static bool isMembers = true;
        private static CEBL.Stream stream;
        private int shading;
        private int maleEmblem;
        private int maleArm;
        public String[] inventoryActions;
        public int rotationY;
        private int scaleY;
        private int scaleZ;
        private int[] stackIds;
        private int offsetY;
        private static int[] streamIndices;
        private int lightness;
        private int femaleDialogue;
        public int rotationX;
        private int femaleModel;
        private int[] stackAmounts;
        public int team;
        public static int totalItems;
        private int scaleInventory;
        private byte unknownByte0;
        private int dummyValue;

    }
}
