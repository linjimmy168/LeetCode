using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    public class Dynamic_Programming
    {
        /// <summary>
        /// 53. Maximum Subarray
        /// 
        ///  int[] nums = new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4 };
        ///
        /// Console.WriteLine(Dynamic_Programming.MaximumSubarray(nums).ToString());
        /// Console.ReadLine();
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        static public int MaximumSubarray(int[] nums)
        {
            int maxSoFar = nums[0], maxEndingHere = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                maxEndingHere = Math.Max(maxEndingHere + nums[i], nums[i]);  //累加起來(包含目前的值)都沒比目前的值大,直接取目前的值
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }
            return maxSoFar;
        }

        /// <summary>
        /// 62. Unique Paths
        /// A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        ///   
        /// Console.WriteLine(Dynamic_Programming.UniquePaths(2,2).ToString());
        /// Console.Read();
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int UniquePaths(int m, int n)
        {
            int[,] grid = new int[m,n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        grid[i, j] = 1;    //最外面那一層都為1
                    }
                    else
                    {
                        grid[i, j] = grid[i - 1, j] + grid[i, j - 1]; //上下累加
                    }
                }
            }
            return grid[m - 1,n - 1];
        }

        /// <summary>
        /// 44. Wildcard Matching
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool isMatch(string s,string p)
        {
            int m = s.Length, n = p.Length;
            var ws = s.ToCharArray();
            var wp = p.ToCharArray();

            bool[,] dp = new bool [m + 1, n + 1];

            dp[0, 0] = true;
            for (int j = 1; j <= n; j++)
                dp[0, j] = dp[0, j - 1] && wp[j - 1] == '*';
            for(int i = 1; i <= m; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    if (wp[j - 1] == '?' || ws[i - 1] == wp[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else if (wp[j - 1] == '*')
                        dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
                }
            }
            return dp[m, n];
        }
    }
}
