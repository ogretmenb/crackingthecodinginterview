using System;
using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.LinkedLists
{
    public class LoopDetection
    {
        public class ReferenceComparer<U> : IEqualityComparer<U> where U : class
        {
            bool IEqualityComparer<U>.Equals(U x, U y)
            {
                return x == y;
            }

            int IEqualityComparer<U>.GetHashCode(U obj)
            {
                return obj.GetHashCode();
            }
        }
        public static Node<T> DetectLoop<T>(Node<T> head)
        {
            ReferenceComparer<Node<T>> comparer = new ReferenceComparer<Node<T>>();
            Dictionary<Node<T>, int> dic = new Dictionary<Node<T>, int>(comparer);
            while (head != null)
            {
                if(dic.ContainsKey(head))
                    return head;
                else{
                    dic.Add(head,1);
                }
                head=head.Next;
            }
            return null;
        }
    }
}