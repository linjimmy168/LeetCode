using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class BreadthFirstSearch
    {
        /// <summary>
        /// 111. Minimum Depth of Binary Tree
        /// 此算法進入到葉子之後 再往上算 並直接比較取最小
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null) return MinDepth(root.right);
            if (root.right == null) return MinDepth(root.left);
            return System.Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
        }
        
    }
}
