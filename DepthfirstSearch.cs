using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class DepthfirstSearch
    {


        #region 105. Construct Binary Tree from Preorder and Inorder Traversal
        /// <summary>
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return BuilderHelper(0, 0, inorder.Length - 1, preorder, inorder);
        }
        /// <summary>
        /// 節點都是由preorder所抓出創出
        /// inorder只是拿來判斷左右樹
        /// Step1:從preorder中找到節點
        /// Step2:此點在inorder中的左右邊即為左右樹的點
        /// 
        ///  int[] preorder = new int[] { 1, 2, 4, 5, 3, 6, 7 };
        ///  int[] inorder = new int[] { 4, 2, 5, 1, 6, 3, 7 };
        ///  
        /// int[] preorder = new int[] { 1, 2, 4, 8, 9, 5, 10, 11, 3, 6, 12, 13, 7, 14, 15 };
        /// int[] inorder = new int[] { 8, 4, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15 };
        /// var obs = DepthfirstSearch.BuildTree(preorder, inorder);
        /// </summary>
        /// <param name="preStart">從preorder抓出目前要計算的節點;以自己這點的右邊</param>
        /// <param name="inStart">從inorder中抓出的節點;由此參考左右樹</param>
        /// <param name="inEnd">此次建構TreeNode所需的inorder範圍, 每次遞迴的時候由inIndex控制</param>
        /// <param name="preorder">提供節點(根)的資訊</param>
        /// <param name="inorder">提供值:根據拿到的節點,左邊為左樹,右邊為右樹</param>
        /// <returns></returns>
        public static TreeNode BuilderHelper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
        {
            //此部分控制preorder與inorder的進入(preStart > preorder.Length - 1 控制左樹;inStart > inEnd 控制右樹)
            if (preStart > preorder.Length - 1 || inStart > inEnd)
            {
                return null;
            }
            //Step1
            TreeNode root = new TreeNode(preorder[preStart]);
            int inIndex = 0; //在inorder中此次的節點
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == root.val) //在inorder中找到節點的位置
                {
                    inIndex = i; 
                    break;
                }
            }
            //Step2
            //左樹創建;preStart + 1:第一個元素都必為節點; inIndex 左邊都為左樹所以-1
            root.left = BuilderHelper(preStart + 1, inStart, inIndex - 1, preorder, inorder);
            //右樹創建;preStart + inIndex - inStart + 1:由inorder左右樹可推出preorder中左右樹的範圍 ;inIndex 右邊都為右樹所以+1
            root.right = BuilderHelper(preStart + inIndex - inStart + 1, inIndex + 1, inEnd, preorder, inorder);
            return root;
        }
        #endregion


        /// <summary>
        /// 109 Convert Sorted List to Binary Search Tree
        /// 
        /// ListNode node = new ListNode(-10);
        /// ListNode preNode = new ListNode(-12);
        /// preNode.next = new ListNode(-11);
        /// preNode.next.next = node;
        /// node.next = new ListNode(-3);
        /// node.next.next = new ListNode(0);
        /// node.next.next.next = new ListNode(5);
        /// node.next.next.next.next = new ListNode(9);
        /// node.next.next.next.next.next = new ListNode(10);
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static TreeNode SortedListToBST(ListNode head)
        {
            if (head == null) return null;
            return toBST(head, null);
        }

        public static TreeNode toBST(ListNode head, ListNode tail)
        {
            ListNode slow = head;
            ListNode fast = head;
            if (head == tail) return null;

            while (fast != tail && fast.next != tail) //由於不知道head的長度,所以用兩個指針, fast為slow的兩倍,當fast碰到底時,slow即為中間值
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            TreeNode thead = new TreeNode(slow.val);
            thead.left = toBST(head, slow);
            thead.right = toBST(slow.next, tail);
            return thead;
        }

        #region 110. Balanced Binary Tree
        /// <summary>
        /// TreeNode p = new TreeNode(1);
        /// p.left = new TreeNode(2);
        /// p.left.left = new TreeNode(4);
        /// p.left.right = new TreeNode(5);
        /// p.left.left.left = new TreeNode(6);
        /// p.right = new TreeNode(3);
        /// DepthfirstSearch.isBalanced2(p);
        /// 
        /// Balanced Tree 左樹,右樹 最多不超過一層,若為null也是平衡
        /// 速度較慢 O(N^2)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool isBalanced1(TreeNode root)
        {
            if (root == null) return true;
            int left = depth(root.left);
            int right = depth(root.right);

            return System.Math.Abs(left - right) <= 1 && isBalanced1(root.left) && isBalanced1(root.right); //遞迴左右樹都不超過1
        }
        private static int depth(TreeNode root)
        {
            if (root == null) return 0;
            return System.Math.Max(depth(root.left), depth(root.right)) + 1; //每進入一層+1
        }

        /// <summary>
        /// 速度較快 O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool isBalanced2(TreeNode root)
        {
            return dfsHeight(root) != -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int dfsHeight(TreeNode root)
        {
            if (root == null) return 0;
            int leftHeight = dfsHeight(root.left);
            if (leftHeight == -1) return -1;
            int rightHeight = dfsHeight(root.right);
            if (rightHeight == -1) return -1;

            if (System.Math.Abs(leftHeight - rightHeight) > 1) return -1; //若左右樹差距大於一層,回傳-1.. 上面leftHeight,rightHeight判斷會導致離開遞迴
            return System.Math.Max(leftHeight, rightHeight) + 1; //走到這邊兩種情況:1.+1計算樹層 2.要離開遞迴了,會直接把最樹層傳回去,就不會等於-1
        }

        #endregion
    }
}
