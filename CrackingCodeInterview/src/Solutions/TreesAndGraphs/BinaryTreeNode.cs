using System;
using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class BinaryTreeNode<T> where T : IComparable<T>
    {
        private T item;
        private int size;

        public BinaryTreeNode<T> left;
        public BinaryTreeNode<T> right;

        public BinaryTreeNode(T aItem)
        {
            item = aItem;
            size = 1;
        }

        public T Item => item;
        public int Size => size;

        public void insertinOrder(T aItem)
        {
            if (aItem.CompareTo(item) <= 0)
            {
                if (left == null)
                {
                    left = new BinaryTreeNode<T>(aItem);
                }
                else
                {
                    left.insertinOrder(aItem);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new BinaryTreeNode<T>(aItem);
                }
                else
                {
                    right.insertinOrder(aItem);
                }
            }
            size++;
        }

        public BinaryTreeNode<T> Find(T aItem)
        {
            int val = aItem.CompareTo(item);
            if (val == 0)
                return this;
            else if (val < 0)
            {
                return left != null ? left.Find(aItem) : null;
            }
            else
            {
                return right != null ? right.Find(aItem) : null;
            }
        }

        public BinaryTreeNode<T> getRandomNode()
        {
            Random rnd = new Random();
            int i = rnd.Next(Size);

            return getlthNode(i);
        }

        public BinaryTreeNode<T> getlthNode(int aI)
        {
            int leftSize = left == null ? 0 : left.size;
            if (aI < leftSize)
            {
                return left.getlthNode(aI);
            }
            else if (aI == leftSize)
            {
                return this;
            }
            else
            {
                //if we will retrieve the node on right we should recalculate the index as i-(leftSize+1)
                return right.getlthNode(aI - (leftSize + 1));
            }
        }




        public Dictionary<T, int> Randomness(int aNumberOfIterations)
        {
            Dictionary<T, int> result = new Dictionary<T, int>();
            while (aNumberOfIterations > 0)
            {
                BinaryTreeNode<T> rndNode = getRandomNode();
                if (result.ContainsKey(rndNode.Item))
                {
                    result[rndNode.Item]++;
                }
                else
                {
                    result[rndNode.Item] = 1;
                }
                aNumberOfIterations--;
            }
            return result;
        }
    }
}