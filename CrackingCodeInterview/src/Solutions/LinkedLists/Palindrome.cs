using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.LinkedLists
{
    public class Palindrome
    {
        public static bool IsPalindrome<T>(Node<T> head)
        {
            if (head == null) return true;//an empty list is a palindrome
            int len = head.Length;
            if (len == 1) return true;     //a list with sigle element is also palindrome

            Node<T> fisrtXNodes = head.firstXNodes(len / 2);
            Node<T> lastXNodes = head.lastXNodes(len / 2);

            Node<T> reversedLastXnodes = lastXNodes.reverseNodes();

            return fisrtXNodes.Equals(reversedLastXnodes);
        }
        public static bool IsPalindromeWithStack<T>(Node<T> head)
        {
            Node<T> fast = head;
            Node<T> slow = head;
            Stack<T> stack = new Stack<T>();
            while (fast != null && fast.Next != null)
            {
                stack.Push(slow.Value);

                slow = slow.Next;
                fast = fast.Next.Next;
            }

            if (fast != null)
            {
                slow = slow.Next;
            }
            while (slow != null)
            {
                if (!stack.Pop().Equals(slow.Value))
                {
                    return false;
                }
                slow = slow.Next;
            }
            return true;
        }

        public class Result<T>
        {
            public Node<T> node;
            public bool result;

            public Result(Node<T> aNode, bool aResult)
            {
                node = aNode;
                result = aResult;
            }
        }
        public static bool isPalindrome_<T>(Node<T> head)
        {
            int len = head.Length;
            Result<T> p = isPalindromeRecurse(head, len);
            return p.result;
        }

        public static Result<T> isPalindromeRecurse<T>(Node<T> head, int length)
        {
            if (head == null || length == 0)
                return new Result<T>(head, true);
            else if (length == 1)
                return new Result<T>(head.Next, true);

            /* Recurse on sublist. */
            Result<T> res = isPalindromeRecurse(head.Next, length - 2);
            if (!res.result || res.node == null)
            {
                return res;
            }
            /* Check if matches corresponding node on other side. */
            res.result= (head.Value.Equals(res.node.Value));
            /* Return corresponding node. */
            res.node= res.node.Next;
            return res;
        }
    }
}