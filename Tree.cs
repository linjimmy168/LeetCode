using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Tree
    {
        #region 94. Binary Tree Inorder Traversal
        /// <summary>
        /// 使用遞迴 時間 528ms
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<int> InorderTraversal1(TreeNode root)
        {
            if (root == null) return BSTList;
            InorderTraversal1(root.left);
            BSTList.Add(root.val);
            InorderTraversal1(root.right);
            return BSTList;
        }
        public static IList<int> BSTList = new List<int>();

        /// <summary>
        /// 使用Stack 時間 485ms
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<int> InorderTraversal2(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            IList<int> result = new List<int>();
            TreeNode cur = root;   // 可以不使用cur,但為了方便閱讀

            while(cur != null || stack.Count != 0)
            {
                while (cur != null)  //巡左樹
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                result.Add(cur.val);
                cur = cur.right;
            }
            return result;
        }
        #endregion



        /// <summary>
        /// 100. Same Tree
        /// 
        ///  TreeNode p = new TreeNode(1);
        ///  p.left = new TreeNode(2);
        ///  p.right = new TreeNode(3);
        ///  
        ///  TreeNode q = new TreeNode(1);
        ///  q.left = new TreeNode(2);
        ///  q.right = new TreeNode(3);
        ///  Tree.IsSameTree(p, q);
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true; //走到底為null即相同
            if (p == null || q == null) return false;
            if (p.val == q.val) //值相同 即進入判斷
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            return false;
        }


        /// <summary>
        /// 102. Binary Tree Level Order Traversal
        /// 
        ///   TreeNode p = new TreeNode(3);
        ///   p.left = new TreeNode(9);
        ///   p.right = new TreeNode(20);
        ///   p.right.left = new TreeNode(15);
        ///   p.right.right = new TreeNode(7);
        ///   Tree.LevelOrder(p);
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count != 0) //每回圈一次 代表一層
            {
                int levelContain = queue.Count; //因為queue會一直增加,所以此部分是固定說這一層應該有幾個值
                List<int> level = new List<int>();
                for(int i=0;i< levelContain; i++)
                {
                    TreeNode tempNode = queue.Dequeue();
                    level.Add(tempNode.val);
                    if (tempNode.left != null) queue.Enqueue(tempNode.left);
                    if (tempNode.right != null) queue.Enqueue(tempNode.right);
                }
                result.Add(level);
            }
            return result;
        }
    }
}
