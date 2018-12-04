using System;
using System.Collections.Generic;
using System.Linq;


namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class ListOfDepths<T>
    {
        public static List<LinkedList<TreeNode<T>>> createLevelLinkedList(TreeNode<T> root)
        {
            List<LinkedList<TreeNode<T>>> lists = new List<LinkedList<TreeNode<T>>>();
            createLevelLinkedList(root, lists, 0);

            return lists;
        }

        private static void createLevelLinkedList(TreeNode<T> root, List<LinkedList<TreeNode<T>>> lists, int level)
        {
            if (root == null) return;
            LinkedList<TreeNode<T>> list = null;
            if (lists.Count == level)
            {
                list = new LinkedList<TreeNode<T>>();
                lists.Add(list);
            }
            else
            {
                list = lists.ElementAt(level);
            }
            list.AddLast(root);
            createLevelLinkedList(root.children == null ? null : root.children[0], lists, level + 1);
            createLevelLinkedList(root.children == null ? null : root.children.Length == 2 ? root.children[1] : null, lists, level + 1);

        }


        public static List<LinkedList<TreeNode<T>>> createLevelLinkedlistBFS(TreeNode<T> root)
        {
            List<LinkedList<TreeNode<T>>> result = new List<LinkedList<TreeNode<T>>>();
            LinkedList<TreeNode<T>> current = new LinkedList<TreeNode<T>>();
            if (root != null)
            {
                current.AddLast(root);
            }

            while (current.Count != 0)
            {
                result.Add(current);
                LinkedList<TreeNode<T>> parents = current;
                current = new LinkedList<TreeNode<T>>();

                foreach (var listNode in parents)
                {
                    if (listNode.children != null)
                        current.AddLast(listNode.children[0]);
                    if (listNode.children != null && listNode.children.Length == 2)
                    {
                        current.AddLast(listNode.children[1]);
                    }
                }


            }

            return result;
        }
    }
}