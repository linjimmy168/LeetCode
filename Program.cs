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
            root.right = new LintCode.TreeNode(2);
            root.right.left = new LintCode.TreeNode(3);
            var bt = new BinaryTreeDivideConquer();
            var result = bt.InorderTraversal(root);
            Console.Read();
        }
    }
}
