using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercises2_Day_1
{
    class Node
    {
        public int value;
        public Node next;
        public Node(int d)
        {
            value = d;
            next = null;
        }
    }
    class LinkedList
    {
        public Node head = null;
        public void Print()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.value + " ");
                temp = temp.next;
            }
        }
        public void InsertNode(int x)
        {
            Node new_node = new Node(x);
            if (head == null)
            {
                head = new_node;
                return;
            }
            Node last = GetLastNode();
            last.next = new_node;
        }
        public Node GetLastNode()
        {
            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        public void Reverse()
        {
            Node prev = null;
            Node current = head;
            Node temp = null;

            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            head = prev;
        }
        private Node Merge(Node a, Node b)
        {
            Node result = null;

            if (a == null)
            {
                return b;
            } else if (b == null)
            {
                return a;
            }

            if (a.value <= b.value)
            {
                result = a;
                result.next = Merge(a.next, b);
            } else
            {
                result = b;
                result.next = Merge(a, b.next);
            }
            return result;
        }
        private void Split(Node source, LinkedList front, LinkedList back)
        {
            Node fast, slow;
            slow = source;
            fast = source.next;

            while (fast != null)
            {
                fast = fast.next;
                if (fast != null)
                {
                    slow = slow.next;
                    fast = fast.next;
                }
            }

            front.head = source;
            back.head = slow.next;
            slow.next = null;

        }
        private void MergeSort(LinkedList l)
        {
            Node h = l.head;
            LinkedList a = new LinkedList();
            LinkedList b = new LinkedList();

            if ((h == null || h.next == null))
            {
                return;
            }

            Split(h, a, b);

            MergeSort(a);
            MergeSort(b);

            l.head = Merge(a.head, b.head);

        }
        public void Sort()
        {
            MergeSort(this);
        }
        public int GetNthElementFromEnd(int n)
        {
            Node main = head;
            Node forward = head;
           
            for (int i = 0; i < n; i++)
            {
                if (forward == null) return -1;
                forward = forward.next;
            }

            while (forward != null)
            {
                main = main.next;
                forward = forward.next;
            }

            return main.value;
            
        }
    }
}
