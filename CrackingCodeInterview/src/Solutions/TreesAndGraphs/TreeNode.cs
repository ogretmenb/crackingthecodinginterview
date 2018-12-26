using System;
using System.Collections.Generic;

namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class TreeNode<T>
    {
        public T item;
        public TreeNode<T>[] children;

        public TreeNode(T aItem)
        {
            item = aItem;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            if (!(obj is TreeNode<T>)) return false;
            if (this == obj) return true;    //bu probleme neden olabilir mi? 20181113
            TreeNode<T> newOne = obj as TreeNode<T>;
            TreeNode<T> thisOne = this;

            if (!newOne.item.Equals(thisOne.item))
                return false;

            if (newOne.children == null && thisOne.children == null || newOne.children == thisOne.children) return true;
            if (newOne.children != null && thisOne.children != null)
            {
                if (newOne.children.Length != thisOne.children.Length) return false;
            }
            if (newOne.children != null && this.children == null || newOne.children == null && this.children != null)
                return false;
            for (int i = 0; i < newOne.children.Length; i++)
            {
                bool result = Equals(newOne.children[i], thisOne.children[i]);
                if (!result) return result;
            }
            return true;
        }

        public override int GetHashCode() => this.item.GetHashCode();

    }
}