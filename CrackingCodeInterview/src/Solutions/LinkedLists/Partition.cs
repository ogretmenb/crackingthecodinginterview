using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.LinkedLists
{
    public class Partition
    {
        public static Node<int> doPartition(Node<int> head, int item)
        {
            Node<int> headerLessThanPivot = null; //= new Node<int>(item);
            Node<int> headerLessThanPivotTail = null;
            Node<int> headerGreaterOrEqualThanPivot = null;   
            Node<int> headerGreaterOrEqualThanPivotTail = null;           
            if (head == null)
            {
                return null;
            }
            Node<int> currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value < item)
                {
                    AppendNode(ref headerLessThanPivot, ref headerLessThanPivotTail, currentNode.Value);
                    /* Node<int> nodeNew = new Node<int>(currentNode.Value);
                    nodeNew.Next = headerLessThanPivot;
                    headerLessThanPivot = nodeNew; */
                }                
                else if (currentNode.Value >= item)
                {
                    /* Node<int> nodeNew = new Node<int>(currentNode.Value);
                    nodeNew.Next = headerGreaterThanPivot;
                    headerGreaterThanPivot = nodeNew;*/
                    AppendNode(ref headerGreaterOrEqualThanPivot, ref headerGreaterOrEqualThanPivotTail, currentNode.Value);
                }
                currentNode = currentNode.Next;
            }
            
            //Node<int> result = AppendNodes(headerLessThanPivot, headerGreaterOrEqualThanPivot);
            headerLessThanPivotTail.Next = headerGreaterOrEqualThanPivot;
            return headerLessThanPivot;



        }

        private static void AppendNode(ref Node<int> headerNode, ref Node<int> tailNode ,int value)
        {            
            Node<int> nodeNew = new Node<int>(value);
            if(headerNode == null)
                tailNode = nodeNew;
            nodeNew.Next = headerNode;
            headerNode = nodeNew;
        }
       /*  private static Node<int> AppendNodes(Node<int> first, Node<int> second)
        {
            Node<int> merged = first;
            if(merged == null) return second;
            while(merged.Next != null)
            {
                merged = merged.Next;
            }
            merged.Next = second;
            return first;
        } */
    }
}