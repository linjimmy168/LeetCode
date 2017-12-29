using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TwoPointer
    {
        /// <summary>
        /// 3. Longest Substring Without Repeating Characters
        /// 
        /// TwoPointer.LengthOfLongestSubstring("abcabcbb");
        /// 重點為如何使用Dictionary 去儲存重複key值的技術
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0) return 0;

            Dictionary<char, int> dic = new Dictionary<char, int>();
            int max = 0;
            for (int i = 0,j = 0; i < s.Length; i++) //使用i,j範圍來表示一字串的上限下限
            {
                if (dic.ContainsKey(s[i]))
                {
                    j = System.Math.Max(j, dic[s[i]]+1);  //dic[s[i]]+1: 找到此上一重複值的位置+1,即為上一個重複值的下一個位置(用來計算長度)
                    //為何此處用Max? 原因:只讓指標i,j往前跑不能往後跑,
                    //舉例來說adbccba 迴圈四次已發現c重複所以將j移至4但無Max時下一個b會導致j返回到3所以只能取最大值
                    dic[s[i]] = i;                  //從字典找出此重複值,更改為目前位置
                }
                else
                {
                    dic.Add(s[i], i);
                }
                max = System.Math.Max(max, i - j + 1); //+1原因:計算都是以陣列的值(起始值為0),但要回傳長度時要把0包含進去
            }
            return max;
        }


        /// <summary>
        /// 19. Remove Nth Node From End of List
        /// 使用fast, slow的方法移動
        ///  ListNode node = new ListNode(1);
        /// node.next = new ListNode(2);
        /// node.next.next = new ListNode(3);
        /// node.next.next.next = new ListNode(4);
        /// var a = TwoPointer.RemoveNthFromEnd(node, 1);
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode headNode = new ListNode(0); //初始化一個ListNode 可以使比免head只有一個時導致錯誤
            headNode.next = head;
            ListNode slow = headNode;
            ListNode fast = headNode;

            for (int i = 0; i < n; i++)
            {
                fast = fast.next;     //先移動n次
            }

            while (fast.next != null) //同步一起移動到fast的底
            {
                fast = fast.next;
                slow = slow.next;
            }

            if (slow.next != null) //slow.next即為要被換掉的node
                slow.next = slow.next.next;
            return headNode.next;
        }


        /// <summary>
        /// 75. Sort Colors
        /// int[] que = new int[] { 2, 1, 1, 0 };
        /// TwoPointer.SortColors(que);
        /// </summary>
        /// <param name="nums"></param>
        public static void SortColors(int[] nums)
        {
            int temp = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
        }
    }
}
