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
        /// 34. Search for a Range (題目要求O(logn)複雜度 => binary search)
        ///  BinarySearch.SearchRange(new int[] { },0);
        ///  
        /// int[] array = new int[] { 5, 7, 7, 8, 8, 10 };
        /// BinarySearch.SearchRange(array, 8);
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] SearchRange(int[] nums, int target)
        {
            int i = 0, j = nums.Length - 1;
            int[] result = new int[] { -1, -1 };

            while (i < j)
            {
                int mid = (i + j) / 2;
                if (nums[mid] < target) i = mid + 1; //
                else j = mid; //j最後會等於i,出迴圈
            }

            if (nums.Length == 0 || target != nums[i]) return result;
            else result[0] = i;

            j = nums.Length - 1;
            while (i < j)
            {
                int mid = (i + j) / 2 + 1;
                if (nums[mid] > target) j = mid - 1;
                else i = mid;
            }
            result[1] = j;
            return result;
        }

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
