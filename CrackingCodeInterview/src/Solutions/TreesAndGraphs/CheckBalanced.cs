using System;
using System.Collections.Generic;
using System.Linq;


namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class CheckBalanced<T>
    {
        public static bool IsBalanced(TreeNode<T> root)
        {
            if (root == null) return true;
            TreeNode<T> leftNode = root.children != null ? root.children[0] : null;
            TreeNode<T> rightNode = root.children != null ? root.children.Length == 2 ? root.children[1] : null : null;
            int heightDiff = getHeight(leftNode) - getHeight(rightNode);
            if (Math.Abs(heightDiff) > 1)
                return false;
            else
            {   //recursive step
                return IsBalanced(leftNode) && IsBalanced(rightNode);
            }
        }

        public static int getHeight(TreeNode<T> root)
        {
            if (root == null) return -1;
            else
            {
                TreeNode<T> leftNode = root.children != null ? root.children[0] : null;
                TreeNode<T> rightNode = root.children != null ? root.children.Length == 2 ? root.children[1] : null : null;
                return Math.Max(getHeight(leftNode), getHeight(rightNode)) + 1;
            }
        }
    }
}