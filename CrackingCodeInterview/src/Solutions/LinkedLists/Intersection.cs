using System;
using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.LinkedLists
{
    public class Intersection
    {
        //O(N*M)
        public static Node<T> getIntersectionNode<T>(Node<T> first, Node<T> second)
        {
            Node<T> current1 = first, current2 = second;
            while (current1 != null)
            {
                while (current2 != null)
                {
                    if (current1 == current2)
                    {
                        return current1;
                    }
                    current2 = current2.Next;
                }

                current1 = current1.Next;
                current2 = second;
            }
            return null;
        }

        public class Result<T>
        {
            public Node<T> tail;
            public int Size;
            public Result(Node<T> aTail, int aSize)
            {
                tail = aTail;
                Size = aSize;
            }
        }
        public static Node<T> getIntersection<T>(Node<T> first, Node<T> second)
        {
            if (first == null || second == null) return null;
            Result<T> fResult = getTailAndSize(first);
            Result<T> sResult = getTailAndSize(second);
            if(fResult.tail != sResult.tail)
                return null;
            Node<T> longer = fResult.Size>sResult.Size?first:second;
            Node<T> shorter = fResult.Size>sResult.Size?second:first;
            longer = getKthNode(longer, Math.Abs(fResult.Size-sResult.Size));

            while(shorter!= longer) //they both will be null in the end (if not intersecting!)
            {
                shorter = shorter.Next;
                longer = longer.Next;
            }
            return shorter;
        }

        private static Result<T> getTailAndSize<T>(Node<T> head)
        {
            if (head == null) return null;
            int size = 1;
            while (head.Next != null)
            {
                size++;
                head = head.Next;
            }
            return new Result<T>(head, size);
        }

        private static Node<T> getKthNode<T>(Node<T> node, int k)
        {
            while(node!= null && k > 0 )
            {
                k--;
                node = node.Next;
            }
            return node;
        }
    }
}