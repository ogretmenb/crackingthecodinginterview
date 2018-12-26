using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class CheckSubtree<T>
    {
        public static bool IsSubtreeWithPreOrderTraversal(TreeNode<T> T1, TreeNode<T> T2)
        {
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            getPreOrderString(T1, sb1);
            getPreOrderString(T2, sb2);
            return sb1.ToString().Contains(sb2.ToString());
        }
        public static void getPreOrderString(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append("X");
                return;

            }
            TreeNode<T> leftNode = node.children != null ? node.children[0] : null;
            TreeNode<T> rightNode = node.children != null ? node.children.Length == 2 ? node.children[1] : null : null;

            //preorder traversal
            sb.Append(node.item.ToString().Trim() + " ");
            getPreOrderString(leftNode, sb);
            getPreOrderString(rightNode, sb);
        }

        public static bool IsSubtree(TreeNode<T> T1, TreeNode<T> T2)
        {
            if (T1 == null && T2 == null) return true;
            if (T1 == null) return false;
            if (T1.Equals(T2)) return true;

            TreeNode<T> leftNode = T1.children != null ? T1.children[0] : null;
            TreeNode<T> rightNode = T1.children != null ? T1.children.Length == 2 ? T1.children[1] : null : null;

            return IsSubtree(leftNode, T2) || IsSubtree(rightNode, T2);

        }
    }
}