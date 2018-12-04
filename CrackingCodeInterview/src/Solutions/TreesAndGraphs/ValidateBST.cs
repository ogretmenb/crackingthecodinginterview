namespace CrackingCodeInterview.Solutions.TreesAndGraphs
{
    public class ValidateBST
    {       
        public static bool IsValidBST(TreeNode<int> root, int min, int max)
        {
            bool result=true;
            if (root == null)
                return true;
            if (root.item < min || root.item > max)
                return false;
            TreeNode<int> leftNode = root.children != null ? root.children[0] : null;
            TreeNode<int> rightNode = root.children != null ? root.children.Length == 2 ? root.children[1] : null : null;

            result = IsValidBST(leftNode, min, root.item);
            if (!result) return false;

            result = IsValidBST(rightNode, root.item, max);
            if (!result) return false;

            return result;
        }
    }
}