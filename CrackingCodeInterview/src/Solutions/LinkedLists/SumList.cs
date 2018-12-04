using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.LinkedLists
{
    public class SumList
    {
        public static Node<int> Sum(Node<int> first, Node<int> second)
        {
            Node<int> firstCurrent = first;
            Node<int> secondCurrent = second;

            Node<int> resultHead = null, resultTail = null;
            int transfer = 0;
            while (firstCurrent != null || secondCurrent != null || transfer != 0)
            {
                int i = 0;
                if (firstCurrent != null)
                    i += firstCurrent.Value;
                if (secondCurrent != null)
                    i += secondCurrent.Value;

                int digit = i % 10;

                if (resultTail == null)
                {
                    resultTail = new Node<int>(digit + transfer);
                    resultHead = resultTail;
                }
                else
                {
                    resultTail.Next = new Node<int>(digit + transfer);
                    resultTail = resultTail.Next;
                }

                transfer = i / 10;
                if (firstCurrent != null) firstCurrent = firstCurrent.Next;
                if (secondCurrent != null) secondCurrent = secondCurrent.Next;
            }
            return resultHead;
        }


        public static Node<int> SumRecursive(Node<int> first, Node<int> second, int carry)
        {
            if (first == null && second == null && carry == 0)
                return null;

            int value = carry;
            if (first != null)
                value += first.Value;
            if (second != null)
                value += second.Value;

            Node<int> result = new Node<int>(value % 10);
            if (first != null || second != null)
            {
                result.Next = SumRecursive(first == null ? null : first.Next, second == null ? null : second.Next, value / 10);

            }

            return result;
        }
        public class PartialSum {
            public Node<int> sum = null;
            public int Carry=0;
        }
        public static Node<int> SumReverse(Node<int> first, Node<int> second)
        {
            //Node<int> totalResult=null;            
            PartialSum sum= SumReverseRecursive(first, second/* , ref totalResult, ref carry  */);
            if(sum.Carry>0)
            {
                Node<int> carryNode = new Node<int>(sum.Carry);
                carryNode.Next = sum.sum;
                sum.sum = carryNode;                
            }
            return sum.sum;
        }
        public static PartialSum SumReverseRecursive(Node<int> first, Node<int> second/* ,  ref Node<int> resultTotal, ref int carry */)
        {
            PartialSum result = null;
            int value = 0;
            if (first == null && second == null)
                result= new PartialSum();           
            else
            if (first != null || second != null)
            {
                result = SumReverseRecursive(first == null ? null : first.Next, second == null ? null : second.Next/* , ref  resultTotal, ref carry */);               
                value = result.Carry + first.Value + second.Value;
                            
                Node<int> addtoHead = new Node<int>(value % 10);
                result.Carry = value/10;
                if(result.sum==null)
                    result.sum = addtoHead;
                else{
                    addtoHead.Next = result.sum;
                    result.sum = addtoHead;
                }
               
            }   
            return result;        
        }
    }
}