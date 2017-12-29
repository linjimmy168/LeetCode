using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class Array
    {
        #region TwoSum
        /// <summary>
        /// TwoSum : Time complexity : O(n^2)  ; Space complexity : O(1)
        /// int[] input = new int[] { 3, 3 };
        /// context.TwoSum1(input, 6);4
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if ((target - nums[i]) == nums[j])
                    {
                        result[0] = i;
                        result[1] = j;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// TwoSum1 : Time complexity : O(n)  ; Space complexity : O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum1(int[] nums, int target)
        {
            var mapping = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var key = target - nums[i];
                if (mapping.ContainsKey(key))
                {
                    return new int[] { mapping[key], i };
                }
                else
                {
                    //if (!mapping.ContainsKey(nums[i]))
                    {
                        mapping.Add(nums[i], i);
                    }
                }
            }
            throw new ArgumentException("No");
        }
        #endregion

        //Median of Two Sorted Arrays
        public double findMedianSortedArrays(int[] A, int[] B)
        {
            int m = A.Length;
            int n = B.Length;
            if (m > n) //要讓B比較大成立
            {
                int[] temp = A; A = B; B = temp;
                int tmp = m; m = n; n = tmp;
            }

            int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2; //因為m個element => 有m+1個分法 所以 長度+1為分類
            while (iMin <= iMax)
            {
                int i = (iMin + iMax) / 2;
                int j = halfLen - i;
                if (i < iMax && B[j - 1] > A[i])
                {
                    iMin = iMin + 1; // i太小
                }
                else if (i > iMin && A[i - 1] > B[j])
                {
                    iMax = iMax - 1; //i is too big
                }
                else //i is perfect
                {
                    int maxLeft = 0;
                    if (i == 0) { maxLeft = B[j - 1]; }
                    else if (j == 0) { maxLeft = A[i - 1]; }
                    else { maxLeft = Math.Max(A[i - 1], B[j - 1]); }
                    if ((m + n) % 2 == 1) { return maxLeft; }

                    int minRight = 0;
                    if (i == m) { minRight = B[j]; }
                    else if (j == n) { minRight = A[i]; }
                    else { minRight = Math.Min(B[j], A[i]); }

                    return (maxLeft + minRight) / 2.0;
                }
            }
            return 0.0;
        }

        #region  11. Container With Most Water
        //Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate(i, ai). 
        //n vertical lines are drawn such that the two endpoints of line i is at(i, ai) and(i, 0). 
        //Find two lines, which together with x-axis forms a container, such that the container contains the most water.
        /// <summary>
        /// Time Complexity:O(n)
        /// Space complexity:O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int maxarea = 0, l = 0, r = height.Length - 1;
            while (l < r)
            {
                maxarea = Math.Max(maxarea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return maxarea;
        }
        #endregion


        //https://miafish.wordpress.com/2015/01/21/leetcode-oj-c-3sum/
        //3Sum
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            System.Array.Sort(nums);
            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int lo = i + 1, hei = nums.Length - 1, sum = -nums[i];
                while (hei > lo)
                {
                    if (nums[lo] + nums[hei] == sum)
                    {
                        List<int> tempList = new List<int>();
                        tempList.Add(nums[lo]);
                        tempList.Add(nums[hei]);
                        tempList.Add(sum);
                        result.Add(tempList);
                        while (hei > lo && nums[lo] == nums[lo + 1]) ++lo;
                        while (hei > lo && nums[hei] == nums[hei - 1]) --hei;
                        ++lo; --hei;
                    }
                    else if (nums[lo] + nums[hei] > sum) --hei;
                    else ++lo;
                }
            }
            return result;
        }
    }
}

