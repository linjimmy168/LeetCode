using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LintCode;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new LintCode.TreeNode(1);
            root.left = new LintCode.TreeNode(-5);
            root.left.left = new LintCode.TreeNode(0);
            root.left.right = new LintCode.TreeNode(2);
            root.right = new LintCode.TreeNode(2);
            root.right.left = new LintCode.TreeNode(-4);
            root.right.right = new LintCode.TreeNode(-5);

            var bt = new BinaryTreeDivideConquer();
            var result = bt.findMinSubtree(root);
            Console.Read();
        }
    }
}
