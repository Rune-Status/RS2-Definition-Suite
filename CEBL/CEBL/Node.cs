namespace CEBL
{
    using System;

    public class Node
    {
        public long id;
        public Node next;
        public Node prev;

        public void unlink()
        {
            if (this.next != null)
            {
                this.next.prev = this.prev;
                this.prev.next = this.next;
                this.prev = null;
                this.next = null;
            }
        }
    }
}

