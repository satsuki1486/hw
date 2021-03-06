using System.Linq;
using DotNet2020.DataStructure;

namespace DotNet2020.Amazon
{
    public static class DistanceBetweenNodesInBST
    {
        public static int BSTDistance(int[] nums, int n1, int n2)
        {
            if (nums == null || nums.Length == 0 || !nums.Contains(n1) || !nums.Contains(n2))
                return -1;
            var root = new TreeNode(nums[0]);
            var r = BuildBst(root, nums, 1);
            var lca = LCA(r, n1, n2);
            return Distance(lca, n1) + Distance(lca, n2);
        }

        private static TreeNode BuildBst(TreeNode root, int[] nums, int i)
        {
            if (i >= nums.Length)
                return null;
            var curr = new TreeNode(nums[i]);
            if (root == null)
                return curr;

            if (root.val > curr.val)
                root.left = BuildBst(curr, nums, i + 1);
            else
                root.right = BuildBst(curr, nums, i + 1);
            return root;
        }

        private static TreeNode LCA(TreeNode root, int n1, int n2)
        {
            if (n1 < root.val && n2 < root.val)
                return LCA(root.left, n1, n2);
            if (n1 > root.val && n2 > root.val)
                return LCA(root.right, n1, n2);
            return root;
        }

        private static int Distance(TreeNode root, int n)
        {
            if (root != null && root.val > n)
                return 1 + Distance(root.left, n);
            if (root != null && root.val < n)
                return 1 + Distance(root.right, n);
            return 0;
        }
    }
}
