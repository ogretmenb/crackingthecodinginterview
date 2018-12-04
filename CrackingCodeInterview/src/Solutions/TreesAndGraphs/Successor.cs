using System;
using System.Collections.Generic;
using System.Linq;


namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    /*
    Here's one step of the logic: The successor of a specific node is the leftmost node of the
    right subtree. 
    What if there is no right subtree, though?
    if there is no right subtree than go back to the parent which has the predecessor node as left subtree!!!

     */
    public class SuccessorBSTNode
    {
        public SuccessorBSTNode left, right, parent;
        public int value;
        public SuccessorBSTNode(int aValue)
        {
            value = aValue;
        }

        public SuccessorBSTNode nextNodeInOrder(/* SuccessorBSTNode aNode*/)
        {
            //if (aNode == null) return null;

            if (/* aNode. */right != null) //The successor of a specific node is the leftmost node of the right subtree
            {
                SuccessorBSTNode leftmost = /* aNode. */right;
                while (leftmost.left != null)
                {
                    leftmost = leftmost.left;
                }
                return leftmost;
            }
            else
            {
                SuccessorBSTNode result = this;//aNode;
                while (result.parent != null && result.parent.right == result)
                {
                    result = result.parent;
                }
                return result.parent;
            }

        }
    }


}