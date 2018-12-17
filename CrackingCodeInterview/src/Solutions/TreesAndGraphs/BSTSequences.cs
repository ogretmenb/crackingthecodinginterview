using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class BSTSequences<T>
    {
        public static List<LinkedList<T>> allSequences(TreeNode<T> node)
        {

            List<LinkedList<T>> result = new List<LinkedList<T>>();

            if (node == null)
            {
                result.Add(new LinkedList<T>());
                return result;
            }
            LinkedList<T> prefix = new LinkedList<T>();
            prefix.AddLast(node.item);
            /* Recurse on left and right subtrees. */
            TreeNode<T> leftNode = node.children != null ? node.children[0] : null;
            TreeNode<T> rightNode = node.children != null ? node.children.Length == 2 ? node.children[1] : null : null;
            List<LinkedList<T>> leftSeq = allSequences(leftNode);
            List<LinkedList<T>> rightSeq = allSequences(rightNode);

            /* Weave together each list from the left and right sides. */
            foreach (LinkedList<T> left in leftSeq)
            {
                foreach (LinkedList<T> right in rightSeq)
                {
                    List<LinkedList<T>> weaved = new List<LinkedList<T>>();
                    weaveLists(left, right, weaved, prefix);
                    result.AddRange(weaved);
                }

            }
            return result;
        }

        /* Weave lists together in all possible ways. This algorithm works by removing the
        * head from one list, recursing, and then doing the same thing with the other
        * list. */
        public static void weaveLists(LinkedList<T> first, LinkedList<T> second, List<LinkedList<T>> results, LinkedList<T> prefix)
        {
            if (first.Count == 0 || second.Count == 0)
            {
                T[] arrayT = new T[prefix.Count]; prefix.CopyTo(arrayT, 0);
                
                LinkedList<T> result = new LinkedList<T>(arrayT);
                foreach (var item in first)
                {
                    result.AddLast(item);
                }
                foreach (var item in second)
                {
                    result.AddLast(item);
                }                
                results.Add(result);               
                return;
            }

            /* Recurse with head of first added to the prefix. Removing the head will damage
            * first, so we'll need to put it back where we found it afterwards. */
            T headfirst = first.First.Value;
            first.RemoveFirst();            
            prefix.AddLast(headfirst);
            weaveLists(first, second, results, prefix);
            prefix.RemoveLast();
            first.AddFirst(headfirst);
            

            /* Do the same thing with second, damaging and then restoring the list.*/
            T headSecond = second.First.Value;
            second.RemoveFirst();
            prefix.AddLast(headSecond);
            weaveLists(first, second, results, prefix);
            prefix.RemoveLast();
            second.AddFirst(headSecond);
        }
    }
}