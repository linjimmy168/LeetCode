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
                if (nums[mid] < target) i = mid + 1; //此部分控制左搜尋
                else j = mid; //j最後會等於i,出迴圈
            }

            if (nums.Length == 0 || target != nums[i]) return result;
            else result[0] = i;

            j = nums.Length - 1;
            while (i < j)
            {
                int mid = (i + j) / 2 + 1;
                if (nums[mid] > target) j = mid - 1; //此部分控制右搜尋
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


       

        /// <summary>
        /// 153. Find Minimum in Rotated Sorted Array
        ///   int[] array = new int[] {10, 15, 1, 2, 3, 4,9 };
        ///   BinarySearch.FindMin(array);
        /// 此題由2分法找出轉折點,而轉折點的右邊第一數必為最小值, 而轉折點本身為最大值
        /// 所以先找到最大點之後 +1的位置即為最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMin(int[] nums)
        {
            int start = 0, end = nums.Length - 1;
            int target = nums[nums.Length - 1];
            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] <= target)
                {
                    end = mid;
                }
                else
                {
                    start = mid;
                }
            }
            return System.Math.Min(nums[end],nums[start]); //若為正常順序即錯誤
        }

        /// <summary>
        /// 162. Find Peak Element
        /// 這題跟LintCode條件不一樣
        /// int[] array = new int[] { 3,2,1};
        /// BinarySearch.FindPeakElement(array);
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindPeakElement(int[] nums)
        {
            if(nums == null || nums.Length <2 ){
                return 0;
            }
            int start = 0, end = nums.Length - 1;
            while (start + 1 < end)
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] > nums[mid + 1])
                {
                    end = mid;
                }
                else
                {
                    start = mid;
                }
            }
            return nums[start] > nums[end] ? start : end;
        }
    }
}