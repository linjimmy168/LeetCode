using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Math
    {
        public class ListNode
        {
            public int value;
            public ListNode next;
            public ListNode(int x) { value = x; }
        }

        /// <summary>
        /// 2. Add Two Numbers
        ///ListNode node1 = new ListNode(2);
        ///node1.next = new ListNode(4);
        ///node1.next.next = new ListNode(3);
        ///ListNode node2 = new ListNode(5);
        ///node2.next = new ListNode(6);
        ///node2.next.next = new ListNode(4);
        ///var nodeList = AddTwoNumbers(node1, node2);
        //    while (nodeList != null)
        //    {
        //        Console.WriteLine(nodeList.value);
        //        nodeList = nodeList.next;
        //    }
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode c1 = l1;
            ListNode c2 = l2;
            ListNode result = new ListNode(0); //若無此 就要去控制 第一次的時候要塞Val 之後都 用new ListNode(sum % 10); 不好寫
            ListNode tempNode = result;
            int sum = 0;

            while (c1 != null || c2 != null)
            {
                sum /= 10;     //都將計算歸零
                if (c1 != null)
                {
                    sum += c1.value;
                    c1 = c1.next;
                }

                if (c2 != null)
                {
                    sum += c2.value;
                    c2 = c2.next;
                }
                tempNode.next = new ListNode(sum % 10); //塞值
                tempNode = tempNode.next;
            }
            if (sum / 10 == 1)  //若要進位
                tempNode.next = new ListNode(1);

            return result.next;
        }

        /// <summary>
        /// 
        /// 7. Reverse Integer
        /// 
        /// Console.WriteLine(Math.Reverse(-123));
        /// Console.WriteLine(Math.Reverse(1534236469));  超過int範圍處理=>反過來90多億超過所以要判斷為0
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int newResult = result * 10 + x % 10;   //將先前的值進位 + 找出除10餘數
                if ((newResult - x % 10) / 10 != result)   //將前段公式反推回去,看是否可以成功,失敗的話代表 "溢位" 
                {
                    return 0;
                }
                result = newResult;
                x /= 10;
            }
            return result;
        }

        /// <summary>
        /// 12. Integer to Roman
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string IntToRoman(int num)
        {
            string[] roams = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            int[] nums = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string result = "";
            int i = 12;

            while (num > 0)
            {
                if (num >= nums[i])
                {
                    result += roams[i];
                    num -= nums[i];
                }
                else
                {
                    i--;
                }
            }
            return result;
        }



    }
}
