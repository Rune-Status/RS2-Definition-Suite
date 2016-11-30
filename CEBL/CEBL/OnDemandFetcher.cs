namespace CEBL
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class OnDemandFetcher
    {
        public NodeList aClass19_1344 = new NodeList();
        public NodeList aClass19_1358 = new NodeList();
        public NodeList aClass19_1368 = new NodeList();
        public NodeList aClass19_1370 = new NodeList();
        public int anInt1349;
        public int[] anIntArray1348;
        public int[] anIntArray1360;
        public int[,] crcs = new int[4, 0];
        public byte[,] fileStatus = new byte[4, 0];
        public byte[] gzipInputBuffer = new byte[0xfde8];
        public byte[] ioBuffer = new byte[500];
        public int[] mapIndices1;
        public int[] mapIndices2;
        public int[] mapIndices3;
        public int[] mapIndices4;
        public byte[] modelIndices;
        public NodeSubList nodeSubList = new NodeSubList();
        public int onDemandCycle;
        public NodeList requested = new NodeList();
        public string statusString = "";
        public int[,] versions = new int[4, 0];

        public void checkReceived(CacheUnpacker unpacker)
        {
            OnDemandData data;
            NodeList list;
            lock ((list = this.aClass19_1370))
            {
                data = (OnDemandData) this.aClass19_1370.popHead();
            }
            while (data != null)
            {
                byte[] buffer = null;
                if (unpacker.decompressors[0] != null)
                {
                    buffer = unpacker.decompressors[data.dataType + 1].decompress(data.ID);
                }
                lock ((list = this.aClass19_1370))
                {
                    if (buffer == null)
                    {
                        this.aClass19_1368.insertHead(data);
                    }
                    else
                    {
                        data.buffer = buffer;
                        lock (this.aClass19_1358)
                        {
                            this.aClass19_1358.insertHead(data);
                        }
                    }
                    data = (OnDemandData) this.aClass19_1370.popHead();
                }
            }
        }

        public int getAnimCount()
        {
            return this.anIntArray1360.Length;
        }

        public int getModelIndex(int i)
        {
            return (this.modelIndices[i] & 0xff);
        }

        public OnDemandData getNextNode()
        {
            OnDemandData data;
            lock (this.aClass19_1358)
            {
                data = (OnDemandData) this.aClass19_1358.popHead();
            }
            if (data == null)
            {
                return null;
            }
            lock (this.nodeSubList)
            {
                data.unlinkSub();
            }
            if (data.buffer != null)
            {
                int offset = 0;
                try
                {
                    GZipStream stream = new GZipStream(new MemoryStream(data.buffer), CompressionMode.Decompress);
                Label_0097:
                    if (offset == this.gzipInputBuffer.Length)
                    {
                        throw new Exception("buffer overflow!");
                    }
                    int num2 = stream.Read(this.gzipInputBuffer, offset, this.gzipInputBuffer.Length - offset);
                    if (num2 >= 1)
                    {
                        offset += num2;
                        goto Label_0097;
                    }
                }
                catch (IOException)
                {
                    throw new Exception("error unzipping");
                }
                data.buffer = new byte[offset];
                Array.Copy(this.gzipInputBuffer, 0, data.buffer, 0, offset);
            }
            return data;
        }

        public int getNodeCount()
        {
            lock (this.nodeSubList)
            {
                return this.nodeSubList.getNodeCount();
            }
        }

        public int getVersionCount(int j)
        {
            return ArrayMethods.getIntArray(this.versions, j).Length;
        }

        public void method548(int i)
        {
            this.method558(0, i);
        }

        public void method558(int i, int j)
        {
            if (((((i >= 0) && (i <= this.versions.Length)) && (j >= 0)) && (j <= this.getVersionCount(i))) && (this.versions[i, j] != 0))
            {
                lock (this.nodeSubList)
                {
                    for (OnDemandData data = (OnDemandData) this.nodeSubList.reverseGetFirst(); data != null; data = (OnDemandData) this.nodeSubList.reverseGetNext())
                    {
                        if ((data.dataType == i) && (data.ID == j))
                        {
                            return;
                        }
                    }
                    OnDemandData node = new OnDemandData {
                        dataType = i,
                        ID = j,
                        incomplete = true
                    };
                    lock (this.aClass19_1370)
                    {
                        this.aClass19_1370.insertHead(node);
                    }
                    this.nodeSubList.insertHead(node);
                }
            }
        }

        public void method560(int i, int j)
        {
            if ((this.versions[j, i] != 0) && (this.fileStatus[j, i] != 0))
            {
                OnDemandData node = new OnDemandData {
                    dataType = j,
                    ID = i,
                    incomplete = false
                };
                lock (this.aClass19_1344)
                {
                    this.aClass19_1344.insertHead(node);
                }
            }
        }

        public int method562(int i, int k, int l)
        {
            int num = (l << 8) + k;
            for (int j = 0; j < this.mapIndices1.Length; j++)
            {
                if (this.mapIndices1[j] == num)
                {
                    if (i == 0)
                    {
                        return this.mapIndices2[j];
                    }
                    return this.mapIndices3[j];
                }
            }
            return -1;
        }

        public bool method564(int i)
        {
            for (int j = 0; j < this.mapIndices1.Length; j++)
            {
                if (this.mapIndices3[j] == i)
                {
                    return true;
                }
            }
            return false;
        }

        public void method566()
        {
            lock (this.aClass19_1344)
            {
                this.aClass19_1344.removeAll();
            }
        }

        public bool method569(int i)
        {
            return (this.anIntArray1348[i] == 1);
        }

        public void start(StreamLoader streamLoader)
        {
            string[] strArray = new string[] { "model_version", "anim_version", "midi_version", "map_version" };
            for (int i = 0; i < 4; i++)
            {
                byte[] buffer = streamLoader.getDataForName(strArray[i]);
                int num2 = buffer.Length / 2;
                CEBL.Stream stream = new CEBL.Stream(buffer);
                if (num2 > ArrayMethods.getIntArray(this.versions, 0).Length)
                {
                    this.versions = new int[4, num2];
                    this.fileStatus = new byte[4, num2];
                }
                for (int num3 = 0; num3 < num2; num3++)
                {
                    this.versions[i, num3] = stream.readUnsignedWord();
                }
            }
            string[] strArray2 = new string[] { "model_crc", "anim_crc", "midi_crc", "map_crc" };
            for (int j = 0; j < 4; j++)
            {
                byte[] buffer2 = streamLoader.getDataForName(strArray2[j]);
                int num5 = buffer2.Length / 4;
                CEBL.Stream stream2 = new CEBL.Stream(buffer2);
                if (num5 > ArrayMethods.getIntArray(this.crcs, 0).Length)
                {
                    this.crcs = new int[4, num5];
                }
                for (int num6 = 0; num6 < num5; num6++)
                {
                    this.crcs[j, num6] = stream2.readDWord();
                }
            }
            byte[] buffer3 = streamLoader.getDataForName("model_index");
            int length = this.getVersionCount(0);
            this.modelIndices = new byte[length];
            for (int k = 0; k < length; k++)
            {
                if (k < buffer3.Length)
                {
                    this.modelIndices[k] = buffer3[k];
                }
                else
                {
                    this.modelIndices[k] = 0;
                }
            }
            buffer3 = streamLoader.getDataForName("map_index");
            CEBL.Stream stream3 = new CEBL.Stream(buffer3);
            length = buffer3.Length / 7;
            this.mapIndices1 = new int[length];
            this.mapIndices2 = new int[length];
            this.mapIndices3 = new int[length];
            this.mapIndices4 = new int[length];
            for (int m = 0; m < length; m++)
            {
                this.mapIndices1[m] = stream3.readUnsignedWord();
                this.mapIndices2[m] = stream3.readUnsignedWord();
                this.mapIndices3[m] = stream3.readUnsignedWord();
                this.mapIndices4[m] = stream3.readUnsignedByte();
            }
            buffer3 = streamLoader.getDataForName("anim_index");
            stream3 = new CEBL.Stream(buffer3);
            length = buffer3.Length / 2;
            this.anIntArray1360 = new int[length];
            for (int n = 0; n < length; n++)
            {
                this.anIntArray1360[n] = stream3.readUnsignedWord();
            }
            buffer3 = streamLoader.getDataForName("midi_index");
            stream3 = new CEBL.Stream(buffer3);
            length = buffer3.Length;
            this.anIntArray1348 = new int[length];
            for (int num11 = 0; num11 < length; num11++)
            {
                this.anIntArray1348[num11] = stream3.readUnsignedByte();
            }
        }
    }
}

