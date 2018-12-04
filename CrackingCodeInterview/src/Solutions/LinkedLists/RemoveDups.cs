using System.Collections.Generic;
using CrackingCodeInterview.Solutions.LinkedLists;

namespace CrackingCodeInterview.Solutions.LinkedLists
{
    public class RemoveDups
    {
        public static void DuplicateRemoval(Node<int> n)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Node<int> previous = null;
            while (n != null)
            {
                if (dict.ContainsKey(n.Value))
                {
                    previous.Next = n.Next;
                }
                else
                {
                    dict.Add(n.Value, 1);
                    previous = n;
                }

                n = n.Next;
            }
        }


        public static void DuplicateRemovalNoSpace(Node<int> n)
        {          
            Node<int> current = n;
            Node<int> runner = null;
            while (current!= null)
            {
                
                runner = current;
                while(runner.Next!= null)
                {
                    if(runner.Next.Value == current.Value)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else{
                        runner = runner.Next;
                    }
                }

                current = current.Next;
            }

        }

    }


}