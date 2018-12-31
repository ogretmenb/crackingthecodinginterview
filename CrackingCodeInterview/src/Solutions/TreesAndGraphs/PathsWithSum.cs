using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class PathsWithSum
    {

        internal class Result
        {
            //public int PartialSum = 0;
            //public int PartialSum = 0;
            public int TotalPaths = 0;
        }
        public static int CalculatePathsWithSum(BinaryTreeNode<int> aNode, int aSum)
        {
            if (aNode == null) return 0;
            int partialSum = 0;
            int pathsFromRoot = CalculatePathsWithSumRecursive(aNode, aSum, partialSum);

            int pathsOnleft = CalculatePathsWithSum(aNode.left, aSum);
            int pathsOnRight = CalculatePathsWithSum(aNode.right, aSum);

            
            return pathsFromRoot + pathsOnleft + pathsOnRight;
        }
        internal static int CalculatePathsWithSumRecursive(BinaryTreeNode<int> aNode, int aSum, int aPartialSum)
        {
            if (aNode == null)
                return 0;

            aPartialSum += aNode.Item;
            int totalPaths = 0;
            if (aPartialSum == aSum)
                totalPaths++;

            totalPaths += CalculatePathsWithSumRecursive(aNode.left, aSum, aPartialSum);
            totalPaths += CalculatePathsWithSumRecursive(aNode.right, aSum, aPartialSum);
            return totalPaths;
        }
    }
}