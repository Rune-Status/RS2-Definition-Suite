namespace CEBL
{
    using System;

    public class OnDemandData : NodeSub
    {
        public byte[] buffer;
        public int dataType;
        public int ID;
        public bool incomplete = true;
        public int loopCycle;
    }
}

