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
        /// 22. Generate Parentheses
        /// 重點在 well-formed parentheses.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<string> GenerateParenthesis(int n)
        {
            List<string> list = new List<string>();
            backTrackGenerate(list, "", 0, 0, n);
            return list;
        }

        private static void backTrackGenerate(List<string> list, string str, int open, int close, int max)
        {
            if (str.Length == max * 2)
            {
                list.Add(str);
                return;
            }

            if (open < max)
                backTrackGenerate(list, str + "(", open + 1, close, max);
            if (close < open) //控制次數不能比open多,不然無法形成一個正常的()
                backTrackGenerate(list, str + ")", open, close + 1, max);
        }


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



        /// <summary>
        /// 46. Permutations
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            backTrack2(list, new List<int>(), nums);
            return list;
        }
        private static void backTrack2(List<IList<int>> list, List<int> tempList, int[] nums)
        {
            if (tempList.Count == nums.Length) list.Add(tempList.ToList());
            else if (tempList.Count > nums.Length) return;
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (tempList.Contains(nums[i])) continue;
                    tempList.Add(nums[i]);
                    backTrack2(list, tempList, nums);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }

    }
}
