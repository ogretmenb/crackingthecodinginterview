using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.LinkedLists
{
    public class DeleteMiddleNode
    {

        public static Node<T> Delete<T>(Node<T> node)
        {            
            if (node == null || node.Next == null)
                return null;
            else
            {
                Node<T> nextNode = node.Next;
                node.Value = nextNode.Value;
                node.Next=nextNode.Next;
                return node;
            }
        }
    }
}