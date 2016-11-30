namespace CEBL
{
    using System;

    public class NodeSubList
    {
        public NodeSub current;
        public NodeSub head = new NodeSub();

        public NodeSubList()
        {
            this.head.prevNodeSub = this.head;
            this.head.nextNodeSub = this.head;
        }

        public int getNodeCount()
        {
            int num = 0;
            for (NodeSub sub = this.head.prevNodeSub; sub != this.head; sub = sub.prevNodeSub)
            {
                num++;
            }
            return num;
        }

        public void insertHead(NodeSub nodeSub)
        {
            if (nodeSub.nextNodeSub != null)
            {
                nodeSub.unlinkSub();
            }
            nodeSub.nextNodeSub = this.head.nextNodeSub;
            nodeSub.prevNodeSub = this.head;
            nodeSub.nextNodeSub.prevNodeSub = nodeSub;
            nodeSub.prevNodeSub.nextNodeSub = nodeSub;
        }

        public NodeSub popTail()
        {
            NodeSub prevNodeSub = this.head.prevNodeSub;
            if (prevNodeSub == this.head)
            {
                return null;
            }
            prevNodeSub.unlinkSub();
            return prevNodeSub;
        }

        public NodeSub reverseGetFirst()
        {
            NodeSub prevNodeSub = this.head.prevNodeSub;
            if (prevNodeSub == this.head)
            {
                this.current = null;
                return null;
            }
            this.current = prevNodeSub.prevNodeSub;
            return prevNodeSub;
        }

        public NodeSub reverseGetNext()
        {
            NodeSub current = this.current;
            if (current == this.head)
            {
                this.current = null;
                return null;
            }
            this.current = current.prevNodeSub;
            return current;
        }
    }
}

