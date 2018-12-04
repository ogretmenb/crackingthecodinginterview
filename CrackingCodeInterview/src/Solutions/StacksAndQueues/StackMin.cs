using System;
using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.StacksAndQueues
{
    public class StackNode<U> where U : IComparable<U>
    {
        public U value;
        public U smallest;

        public StackNode(U aVal)
        {
            value = aVal;
            smallest = value;
        }
    }
    public class StackMin<T> : Stack<StackNode<T>> where T : IComparable<T>
    {

        public new void Push(StackNode<T> item)
        {
            if (Count != 0)
            {
                var peekitem = base.Peek();
                item.smallest = item.value.CompareTo(peekitem.smallest) <= -1 ? item.value : peekitem.smallest;

            }
            base.Push(item);
        }

        public StackNode<T> Min()
        {
            return base.Peek();
        }
    }

    

}