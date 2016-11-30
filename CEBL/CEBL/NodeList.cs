namespace CEBL
{
    using System;

    public class NodeList
    {
        public Node current;
        public Node head = new Node();

        public NodeList()
        {
            this.head.prev = this.head;
            this.head.next = this.head;
        }

        public Node getFirst()
        {
            Node next = this.head.next;
            if (next == this.head)
            {
                this.current = null;
                return null;
            }
            this.current = next.next;
            return next;
        }

        public Node getNext()
        {
            Node current = this.current;
            if (current == this.head)
            {
                this.current = null;
                return null;
            }
            this.current = current.next;
            return current;
        }

        public void insertHead(Node node)
        {
            if (node.next != null)
            {
                node.unlink();
            }
            node.next = this.head.next;
            node.prev = this.head;
            node.next.prev = node;
            node.prev.next = node;
        }

        public void insertTail(Node node)
        {
            if (node.next != null)
            {
                node.unlink();
            }
            node.next = this.head;
            node.prev = this.head.prev;
            node.next.prev = node;
            node.prev.next = node;
        }

        public Node popHead()
        {
            Node prev = this.head.prev;
            if (prev == this.head)
            {
                return null;
            }
            prev.unlink();
            return prev;
        }

        public void removeAll()
        {
            if (this.head.prev != this.head)
            {
                while (true)
                {
                    Node prev = this.head.prev;
                    if (prev == this.head)
                    {
                        break;
                    }
                    prev.unlink();
                }
            }
        }

        public Node reverseGetFirst()
        {
            Node prev = this.head.prev;
            if (prev == this.head)
            {
                this.current = null;
                return null;
            }
            this.current = prev.prev;
            return prev;
        }

        public Node reverseGetNext()
        {
            Node current = this.current;
            if (current == this.head)
            {
                this.current = null;
                return null;
            }
            this.current = current.prev;
            return current;
        }
    }
}

