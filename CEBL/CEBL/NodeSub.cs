namespace CEBL
{
    using System;

    public class NodeSub : Node
    {
        public static int anInt1305;
        public NodeSub nextNodeSub;
        public NodeSub prevNodeSub;

        public void unlinkSub()
        {
            if (this.nextNodeSub != null)
            {
                this.nextNodeSub.prevNodeSub = this.prevNodeSub;
                this.prevNodeSub.nextNodeSub = this.nextNodeSub;
                this.prevNodeSub = null;
                this.nextNodeSub = null;
            }
        }
    }
}

