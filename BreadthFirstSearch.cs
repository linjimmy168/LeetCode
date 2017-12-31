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
        /// TreeNode node = new TreeNode(1);
        /// node.left = new TreeNode(2);
        /// node.left.right = new TreeNode(5);
        /// node.left.right.left = new TreeNode(6);
        /// node.right = new TreeNode(3);
        /// node.right.right = new TreeNode(4);
        /// BreadthFirstSearch.MinDepth(node);
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null) return MinDepth(root.right) + 1;   //right,left 為null表示直接走到葉子
            if (root.right == null) return MinDepth(root.left) + 1;
            return System.Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
        }




        //public static IList<int> RightSideView(TreeNode root)
        //{
        //    List<int> result = new List<int>();
        //    rightView(root, result, 0);
        //    return result;
        //}
        //private static void rightView(TreeNode curr, List<int> result, int currDepth)
        //{
        //    if (curr == null)
        //    {
        //        return;
        //    }
        //    if (currDepth == result.Count)
        //    {
        //        result.Add(curr.val);
        //    }

        //    rightView(curr.right, result, currDepth + 1);
        //    rightView(curr.left, result, currDepth + 1);
        //}

        /// <summary>
        /// 199. Binary Tree Right Side View
        /// 解題思維: 使用廣度搜尋,不過是儲存右邊第一個
        /// 
        /// TreeNode node = new TreeNode(1);
        /// node.left = new TreeNode(2);
        /// node.left.right = new TreeNode(5);
        /// node.left.right.left = new TreeNode(6);
        /// node.right = new TreeNode(3);
        /// node.right.right = new TreeNode(4);
        /// BreadthFirstSearch.RightSideView(node);
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<int> RightSideView(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode cur = queue.Peek();
                result.Add(cur.val);
                int count = queue.Count;  //用count跟for loop控制List.Add所以左邊被遮住的地方就不會被加入
                for (int i = 0; i < count; i++)
                {
                    cur = queue.Dequeue();
                    if (cur.right != null) queue.Enqueue(cur.right);
                    if (cur.left != null) queue.Enqueue(cur.left);
                }
            }
            return result;
        }
    }
}
