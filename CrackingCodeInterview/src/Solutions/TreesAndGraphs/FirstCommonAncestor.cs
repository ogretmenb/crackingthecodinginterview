using System;
using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class FirstCommonAncestor<T>
    {
      
        public static TreeNode<T> firstCommonAncestor(TreeNode<T> root, TreeNode<T> p, TreeNode<T> q)
        {

            if (!isDescendentR(p, root) && isDescendentR(q, root))
            {
                return q;
            }
            else if (isDescendentR(p, root) && !isDescendentR(q, root))
            {
                return p;
            }
            else if (!isDescendentR(p, root) && !isDescendentR(q, root))
            {
                return null;
            }
            else
            {
                //find firstCommonAncestor
                return firstCommonAncestor1(root, p, q);
            }          
        }
        /*  isDescendentR searches all nodes under root for p and q, including the nodes in each
            subtree (root. left and root. right). Then, it picks one of those subtrees and searches all of its nodes.
            Each subtree is searched over and over again. */
        public static TreeNode<T> firstCommonAncestor1(TreeNode<T> root, TreeNode<T> p, TreeNode<T> q)
        {
            //find firstCommonAncestor
            TreeNode<T> leftNode = root.children != null ? root.children[0] : null;
            TreeNode<T> rightNode = root.children != null ? root.children.Length == 2 ? root.children[1] : null : null;

            bool pIsOnLeft = isDescendentR(p, leftNode);
            bool qIsOnLeft = isDescendentR(q, leftNode);
            if (pIsOnLeft != qIsOnLeft)
                return root;
            TreeNode<T> childSide = pIsOnLeft ? leftNode : rightNode;
            return firstCommonAncestor(childSide, p, q);
        }

        //identify whether x is a descendent of n
        public static bool isDescendentR(TreeNode<T> x, TreeNode<T> n)
        {
            if (n == null)
                return false;
            else if (n == x)
                return true;
            else
            {
                TreeNode<T> leftNode = n.children != null ? n.children[0] : null;
                TreeNode<T> rightNode = n.children != null ? n.children.Length == 2 ? n.children[1] : null : null;
                if (isDescendentR(x, leftNode) || isDescendentR(x, rightNode))
                    return true;
                else
                    return false;
            }
        }



        public class Result
        {
            public TreeNode<T> node;
            public bool isAncestor;
            public Result(TreeNode<T> aNode, bool aIsAncestor)
            {
                node = aNode;
                isAncestor = aIsAncestor;
            }
        }

        public static TreeNode<T> commonAncestor(TreeNode<T> root, TreeNode<T> p, TreeNode<T> q)
        {
            Result r = commonAncestorHelper(root, p, q);
            if (r.isAncestor)
            {
                return r.node;
            }
            return null;
        }

        private static Result commonAncestorHelper(TreeNode<T> root, TreeNode<T> p, TreeNode<T> q)
        {
            if (root == null) return new Result(null, false);
            if (root == p && root == q)
                return new Result(root, true);

            TreeNode<T> leftNode = root.children != null ? root.children[0] : null;
            TreeNode<T> rightNode = root.children != null ? root.children.Length == 2 ? root.children[1] : null : null;
            Result leftSubTree = commonAncestorHelper(leftNode, p, q);
            if (leftSubTree.isAncestor) return leftSubTree;

            Result rightSubTree = commonAncestorHelper(rightNode, p, q);
            if (rightSubTree.isAncestor) return rightSubTree;


            if (leftSubTree.node != null && rightSubTree.node != null)
            {
                return new Result(root, true);
            }
            else if (root == p || root == q)
            {
                return new Result(root, leftSubTree.node != null || rightSubTree.node != null);
            }
            else
            {
                return new Result(leftSubTree.node != null ? leftSubTree.node : rightSubTree.node, false);
            }
        }
    }
}
