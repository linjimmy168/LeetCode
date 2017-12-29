using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class BackTracking
    {
        /// <summary>
        /// 39. Combination Sum
        /// 
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> list = new List<IList<int>>();
            System.Array.Sort(candidates);
            backTrack(list, new List<int>(), candidates, target, 0);
            return list;
        }

        private static void backTrack(List<IList<int>> list, List<int> tempList, int[] nums, int remain, int start)
        {
            if (remain < 0) return;
            else if (remain == 0) list.Add(tempList.ToList());
            else
            {
                for (int i = start; i < nums.Length; i++) //起始為0=>會變成排列E.g.[2,2,3],[2,3,2],[3,2,2]
                {
                    tempList.Add(nums[i]);
                    backTrack(list, tempList, nums, remain - nums[i], i);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
    }
}
