using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class MinimalTree
    {
        public static void BuildMinimalTree(int[] aArray, ref TreeNode<int> aTree)
        {
            if (aArray == null)
                return;
            if(aArray.Length == 0)
                return;
            if (aArray.Length == 1)
            {
                //aTree.item = aArray[aArray.Length - 1];
                aTree = new TreeNode<int>(aArray[aArray.Length - 1]);
            }
            else
            {
                //aTree.item = aArray[aArray.Length / 2];
                aTree = new TreeNode<int>(aArray[aArray.Length / 2]);
                aTree.children = new TreeNode<int>[aArray.Length / 2 < aArray.Length - 1 ? 2 : 1];
                BuildMinimalTree(aArray.Take(aArray.Length / 2).ToArray(), ref aTree.children[0]);
                if (aArray.Length / 2 < aArray.Length - 1)
                    BuildMinimalTree(aArray.Skip(aArray.Length / 2 + 1).ToArray(), ref aTree.children[1]);
            }

        }
    }
}