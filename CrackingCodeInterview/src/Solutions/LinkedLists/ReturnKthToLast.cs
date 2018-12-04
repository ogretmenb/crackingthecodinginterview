using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.LinkedLists
{
    public class ReturnKthToLast
    {
        public static Node<T> KthToLastListRecursive<T>(Node<T> head, int k, ref int index)
        {
           
            if (head == null)
            {               
                return null;
            }
            Node<T> node = KthToLastListRecursive(head.Next, k, ref index);
            index++;
            if (index == k)
            {
                return head;
            }
            return node;

        }

        public static Node<T> nthTolast<T>(Node<T> head, int k)
        {
            Node<T> p1 = head;
            Node<T> p2 = head;

            for (int i = 0; i < k; i++)
            {
                if (p1 == null) return null;
                p1 = p1.Next;
            }

            while (p1 != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }
            return p2;
        }
    }
}