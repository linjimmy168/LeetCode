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
            ListNode node = new ListNode(-10);
            ListNode preNode = new ListNode(-12);
            preNode.next = new ListNode(-11);
            preNode.next.next = node;
            node.next = new ListNode(-3);
            node.next.next = new ListNode(0);
            node.next.next.next = new ListNode(5);
            node.next.next.next.next = new ListNode(9);
            node.next.next.next.next.next = new ListNode(10);
            var a = DepthfirstSearch.SortedListToBST(preNode);
            Console.Read();
        }
    }
}
