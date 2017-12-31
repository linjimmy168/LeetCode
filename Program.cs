using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode node = new TreeNode(1);
            node.left = new TreeNode(2);
            node.left.right = new TreeNode(5);
            node.left.right.left = new TreeNode(6);
            node.right = new TreeNode(3);
            node.right.right = new TreeNode(4);
            BreadthFirstSearch.MinDepth(node);
            Console.Read();
        }
    }
}
