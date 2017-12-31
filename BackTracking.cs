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

        //public static bool Exist(char[,] board, string word)
        //{
        //    int rowsIndex = board.GetLength(0);
        //    int colsIndex = board.Length / rowsIndex;
        //    bool[,] flagTable = new bool[rowsIndex, colsIndex];
        //    return backTrack(board, flagTable, word, 0, 0, true);
        //}

        //private static bool backTrack(char[,] board, bool[,] flagTable, string word, int rowsIndex, int colsIndex, bool success)
        //{
        //    if (word.Length == 0) return true;
        //    else if (rowsIndex == board.GetLength(0) - 1 && colsIndex == (board.Length / board.GetLength(0)) - 1 && flagTable[rowsIndex, colsIndex]) return false;
        //    else
        //    {
        //        for (int i = rowsIndex; i < board.GetLength(0); i++)
        //        {
        //            for (int j = colsIndex; j < (board.Length / board.GetLength(0)); j++)
        //            {
        //                if (board[i, j] == word[0] && flagTable[i, j] == false)
        //                {
        //                    flagTable[i, j] = true;
        //                    if (backTrack(board, flagTable, word.Substring(1), i + 1, j, success) || backTrack(board, flagTable, word.Substring(1), i, j + 1, success))
        //                        return true;
        //                    flagTable[i, j] = false;
        //                }
        //            }
        //        }
        //        return false;
        //    }
        //}

        public static bool[,] visited;
        public static bool Exist(char[,] board, string word)
        {
            int rows = board.GetLength(0);
            int columns = board.Length / board.GetLength(0);
            visited = new bool[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (search(board, word, i, j, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool search(char[,] board, string word, int i, int j, int index)
        {
            if (index == word.Length)
                return true;

            if (i >= board.GetLength(0) || i < 0 || j >= board.Length / board.GetLength(0) || j < 0)
                return false;

            if (board[i, j] != word[index] || visited[i, j])
                return false;

            visited[i, j] = true;
            if (search(board, word, i - 1, j, index + 1) ||
               search(board, word, i + 1, j, index + 1) ||
               search(board, word, i, j - 1, index + 1) ||
               search(board, word, i, j + 1, index + 1))
                return true;

            visited[i, j] = false;
            return false;
        }
    }
}
