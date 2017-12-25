using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class BinarySearch
    {
        /// <summary>
        /// 35. Search Insert Position
        /// Input: [1,3,5,6], 5
        /// Output: 2
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                dic.Add(nums[i], i);
                if (dic.ContainsKey(target) || nums[i] > target)
                {
                    return i;
                }
            }
            return nums.Length;
        }

        /// <summary>
        /// 50. Pow(x, n)
        /// 
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            return x * MyPow(x, n - 1);
        }
    }
}
