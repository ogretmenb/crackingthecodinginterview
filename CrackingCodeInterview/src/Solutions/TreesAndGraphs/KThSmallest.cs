using System;
using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class KThSmallest<T>
    {
        public class Result
        {
            public T item;
            public int index = 0;
            //public bool found;

        }        

        public static void findKThSmallest(TreeNode<T> treeRoot, int kThSmallestElementIndex, Result result)
        {
            if (treeRoot == null || kThSmallestElementIndex == 0)
                return;

            findKThSmallest(treeRoot.children == null ? null : treeRoot.children[0], kThSmallestElementIndex, result);
            if (result.index == kThSmallestElementIndex)
                return;
            result.item = treeRoot.item;
            result.index++;
            if (result.index == kThSmallestElementIndex)
            {
                return;
            }
            findKThSmallest(treeRoot.children == null ? null : treeRoot.children[1], kThSmallestElementIndex, result);
            if (result.index == kThSmallestElementIndex)
                return;
        }

        public static List<T> inOrderTravese(TreeNode<T> treeRoot)
        {
            List<T> result = new List<T>();
            if (treeRoot == null)
                return result;

            var leftChilds = inOrderTravese(treeRoot.children == null ? null : treeRoot.children[0]);
            result.AddRange(leftChilds);
            result.Add(treeRoot.item);
            var rightChilds = inOrderTravese(treeRoot.children == null ? null : treeRoot.children[1]);
            result.AddRange(rightChilds);
            return result;
        }

    }
}